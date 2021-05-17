using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CurrencyCalculator.API.DbContexts;
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
    [Route("api/currencies")]
    public class CurrenciesController : ControllerBase
    {
        private readonly ICurrencyCalculatorRepository _currencyCalculatorRepository;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        /// <summary>
        /// Initializes a constructor for CurrenciesController
        /// </summary>
        /// <param name="currencyCalculatorRepository"></param>
        /// <param name="mapper"></param>
        /// <param name="uriService"></param>
        public CurrenciesController(ICurrencyCalculatorRepository currencyCalculatorRepository,
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
        /// Returns all (or paginated) the active currencies
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>All (or paginated) the active currencies</returns>
        /// <response code="200">Returns all (or paginated) the active currencies</response>
        [HttpGet()]
        [HttpHead]
        public ActionResult<PagedResponse<IEnumerable<CurrencyDto>>> GetCurrencies([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var currenciesFromRepo = _currencyCalculatorRepository.GetCurrencies(validFilter);
            var currenciesDto = _mapper.Map<IEnumerable<CurrencyDto>>(currenciesFromRepo);

            var totalRecords = _currencyCalculatorRepository.GetCurrencies().Count();
            var pagedReponse = PaginationHelper.CreatePagedReponse<CurrencyDto>(currenciesDto, validFilter, totalRecords, _uriService, route);

            return Ok(pagedReponse);
        }

        /// <summary>
        /// Returns a single active currency
        /// </summary>
        /// <param name="currencyId"></param>
        /// <returns>A single active currency</returns>
        /// <response code="200">Returns a single active currency</response>
        /// <response code="404">Unable to find the active currency</response>
        [HttpGet("{currencyId}", Name = "GetCurrency")]
        public ActionResult<CurrencyDto> GetCurrency(Guid currencyId)
        {
            var currencyFromRepo = _currencyCalculatorRepository.GetCurrency(currencyId);

            if (currencyFromRepo == null)
                return NotFound();

            return Ok(_mapper.Map<CurrencyDto>(currencyFromRepo));
        }

        /// <summary>
        /// Creates a currency
        /// </summary>
        /// <param name="currency"></param>
        /// <returns></returns>
        /// <response code="201">Creates a currency</response>
        /// <response code="409">Currency already exists</response>
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult<CurrencyDto> CreateCurrency(CurrencyForCreationDto currency)
        {
            var currencyEntity = _mapper.Map<Currency>(currency);
            if (_currencyCalculatorRepository.CurrencyExists(currencyEntity.Code))
                return Conflict();

            _currencyCalculatorRepository.AddCurrency(currencyEntity);
            _currencyCalculatorRepository.Save();

            var currencyToReturn = _mapper.Map<CurrencyDto>(currencyEntity);
            return CreatedAtRoute("GetCurrency",
                new { currencyId = currencyToReturn.Id },
                currencyToReturn);
        }

        /// <summary>
        /// Returns the available actions in header "Allow"
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Returns the available actions in header "Allow"</response>
        [HttpOptions]
        public IActionResult GetCurrenciesOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST,DELETE");
            return Ok();
        }

        /// <summary>
        /// Deletes a currency
        /// </summary>
        /// <param name="currencyId"></param>
        /// <returns></returns>
        /// <response code="204">Deletes a currency</response>
        /// <response code="404">Unable to find the active currency in order to delete</response>
        [Authorize(Roles = "admin")]
        [HttpDelete("{currencyId}")]
        public ActionResult DeleteCurrency(Guid currencyId)
        {
            var currencyFromRepo = _currencyCalculatorRepository.GetCurrency(currencyId);

            if (currencyFromRepo == null)
            {
                return NotFound();
            }

            _currencyCalculatorRepository.DeleteCurrency(currencyFromRepo);

            _currencyCalculatorRepository.Save();

            return NoContent();
        }
    }
}
