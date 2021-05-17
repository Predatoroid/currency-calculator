using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CurrencyCalculator.API.Entities;
using CurrencyCalculator.API.Helpers;
using CurrencyCalculator.API.Models;
using CurrencyCalculator.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyCalculator.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/currencyrates")]
    public class CurrencyRatesController : ControllerBase
    {
        private readonly ICurrencyCalculatorRepository _currencyCalculatorRepository;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        /// <summary>
        /// Initializes a constructor for CurrencyRatesController
        /// </summary>
        /// <param name="currencyCalculatorRepository"></param>
        /// <param name="mapper"></param>
        /// <param name="uriService"></param>
        public CurrencyRatesController(ICurrencyCalculatorRepository currencyCalculatorRepository,
            IMapper mapper,
            IUriService uriService)
        {
            _currencyCalculatorRepository = currencyCalculatorRepository ??
                throw new ArgumentNullException(nameof(currencyCalculatorRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
            _uriService = uriService ??
                throw new ArgumentNullException(nameof(uriService));
        }

        /// <summary>
        /// Returns all (or paginated) the active currency rates
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>All (or paginated) the active currency rates</returns>
        /// <response code="200">Returns all (or paginated) the active currency rates</response>
        [HttpGet()]
        [HttpHead]
        public ActionResult<PagedResponse<IEnumerable<CurrencyRateDto>>> GetCurrencyRates([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var currencyRatesFromRepo = _currencyCalculatorRepository.GetCurrencyRates(validFilter);

            var currencyRatesDto = _mapper.Map<IEnumerable<CurrencyRateDto>>(currencyRatesFromRepo);

            var totalRecords = _currencyCalculatorRepository.GetCurrencyRates().Count();
            var pagedReponse = PaginationHelper.CreatePagedReponse<CurrencyRateDto>(currencyRatesDto, validFilter, totalRecords, _uriService, route);

            return Ok(pagedReponse);
        }

        /// <summary>
        /// Returns a single active currency rate
        /// </summary>
        /// <param name="currencyRateId"></param>
        /// <returns>A single active currency rate</returns>
        /// <response code="200">Returns a single active currency rate</response>
        /// <response code="404">Unable to find the active currency rate</response>
        [HttpGet("{currencyRateId}", Name = "GetCurrencyRate")]
        public ActionResult<CurrencyRateDto> GetCurrencyRate(Guid currencyRateId)
        {
            var currencyRateFromRepo = _currencyCalculatorRepository.GetCurrencyRate(currencyRateId);

            if (currencyRateFromRepo == null)
                return NotFound();

            return Ok(_mapper.Map<CurrencyRateDto>(currencyRateFromRepo));
        }

        /// <summary>
        /// Returns a single active currency rate by base and target currency codes
        /// </summary>
        /// <param name="baseCurrencyCode"></param>
        /// <param name="targetCurrencyCode"></param>
        /// <returns>A single active currency rate by base and target currency codes</returns>
        /// <response code="200">Returns a single active currency rate by base and target currency codes</response>
        /// <response code="404">Unable to find the active currency rate by base and target currency codes</response>
        [HttpGet("{baseCurrencyCode}/{targetCurrencyCode}")]
        public ActionResult<CurrencyRateDto> GetCurrencyRate(string baseCurrencyCode, string targetCurrencyCode)
        {
            var currencyRateFromRepo = _currencyCalculatorRepository.GetCurrencyRate(baseCurrencyCode, targetCurrencyCode);

            if (currencyRateFromRepo == null)
                return NotFound();

            return Ok(_mapper.Map<CurrencyRateDto>(currencyRateFromRepo));
        }

        /// <summary>
        /// Calculates the result of CurrencyRate.Value * amount
        /// </summary>
        /// <param name="baseCurrencyCode"></param>
        /// <param name="targetCurrencyCode"></param>
        /// <param name="amount"></param>
        /// <returns>The result of CurrencyRate.Value * amount</returns>
        /// <response code="200">Returns the result of CurrencyRate.Value * amount</response>
        /// <response code="404">Unable to find the active currency rate in order to calculate</response>
        [HttpGet("{baseCurrencyCode}/{targetCurrencyCode}/{amount}")]
        public ActionResult<decimal?> Calculate(string baseCurrencyCode, string targetCurrencyCode, decimal amount)
        {
            var convertedValue = _currencyCalculatorRepository.Calculate(baseCurrencyCode, targetCurrencyCode, amount);

            if (convertedValue == null)
                return NotFound();

            return Ok(convertedValue);
        }

        /// <summary>
        /// Creates a currency rate
        /// </summary>
        /// <param name="currencyRate"></param>
        /// <returns></returns>
        /// <response code="201">Creates a currency rate</response>
        /// <response code="409">Currency rate already exists</response>
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult<CurrencyRateDto> CreateCurrencyRate(CurrencyRateForCreationDto currencyRate)
        {
            if (currencyRate == null)
                throw new ArgumentNullException(nameof(currencyRate));

            var baseCurrency = _currencyCalculatorRepository.GetCurrency(currencyRate.BaseCurrencyCode);
            if (baseCurrency == null)
                throw new ArgumentException("Base currency doesn't exist.");

            var targetCurrency = _currencyCalculatorRepository.GetCurrency(currencyRate.TargetCurrencyCode);
            if (targetCurrency == null)
                throw new ArgumentException("Target currency doesn't exist.");

            var currencyRateFromRepo = _currencyCalculatorRepository.GetCurrencyRate(baseCurrency.Id, targetCurrency.Id);
            if (currencyRateFromRepo != null)
                return Conflict();

            var currencyRateEntity = _mapper.Map<CurrencyRate>(currencyRate);
            currencyRateEntity.BaseCurrencyId = baseCurrency.Id;
            currencyRateEntity.TargetCurrencyId = targetCurrency.Id;
            _currencyCalculatorRepository.AddCurrencyRate(currencyRateEntity);
            _currencyCalculatorRepository.Save();

            var currencyRateToReturn = _mapper.Map<CurrencyRateDto>(currencyRateEntity);
            return CreatedAtRoute("GetCurrencyRate",
                new { currencyRateId = currencyRateToReturn.Id },
                currencyRateToReturn);
        }

        /// <summary>
        /// Returns the available actions in header "Allow"
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Returns the available actions in header "Allow"</response>
        [HttpOptions]
        public IActionResult GetCurrencyRatesOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST,DELETE");
            return Ok();
        }

        /// <summary>
        /// Deletes a currency rate
        /// </summary>
        /// <param name="currencyRateId"></param>
        /// <returns></returns>
        /// <response code="204">Deletes a currency rate</response>
        /// <response code="404">Unable to find the active currency rate in order to delete</response>
        [Authorize(Roles = "admin")]
        [HttpDelete("{currencyRateId}")]
        public ActionResult DeleteCurrencyRate(Guid currencyRateId)
        {
            var currencyRateFromRepo = _currencyCalculatorRepository.GetCurrencyRate(currencyRateId);

            if (currencyRateFromRepo == null)
                return NotFound();

            _currencyCalculatorRepository.DeleteCurrencyRate(currencyRateFromRepo);
            _currencyCalculatorRepository.Save();

            return NoContent();
        }
    }
}
