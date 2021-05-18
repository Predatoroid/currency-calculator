using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using CurrencyCalculator.API.Entities;
using CurrencyCalculator.API.Helpers;
using CurrencyCalculator.API.Models;
using CurrencyCalculator.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyCalculator.API.Controllers
{
    [Authorize(Roles = "admin")]
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        /// <summary>
        /// Initializes a constructor for UsersController
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="mapper"></param>
        /// <param name="uriService"></param>
        public UsersController(IUserRepository userRepository,
            IMapper mapper,
            IUriService uriService)
        {
            _userRepository = userRepository ??
                throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
            _uriService = uriService ??
                throw new ArgumentNullException(nameof(uriService));
        }

        /// <summary>
        /// Returns all (or paginated) the active users
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>All (or paginated) the active users</returns>
        /// <response code="200">Returns all (or paginated) the active users</response>
        [HttpGet()]
        [HttpHead]
        [Produces(MediaTypeNames.Application.Json)]
        public ActionResult<PagedResponse<IEnumerable<UserDto>>> GetUsers([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var usersFromRepo = _userRepository.GetUsers(validFilter);
            var usersDto = _mapper.Map<IEnumerable<UserDto>>(usersFromRepo);

            var totalRecords = _userRepository.GetUsers().Count();
            var pagedReponse = PaginationHelper.CreatePagedReponse<UserDto>(usersDto, validFilter, totalRecords, _uriService, route);

            return Ok(pagedReponse);
        }

        /// <summary>
        /// Returns a single active user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>A single active user</returns>
        /// <response code="200">Returns a single active user</response>
        /// <response code="404">Unable to find the active user</response>
        [HttpGet("{userId}", Name = "GetUser")]
        [Produces(MediaTypeNames.Application.Json)]
        public ActionResult<UserDto> GetUser(Guid userId)
        {
            var userFromRepo = _userRepository.GetUser(userId);
            if (userFromRepo == null)
                return NotFound();

            return Ok(_mapper.Map<UserDto>(userFromRepo));
        }

        /// <summary>
        /// Creates a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <response code="201">Creates a user</response>
        /// <response code="409">User already exists</response>
        [HttpPost()]
        [Produces(MediaTypeNames.Application.Json)]
        public ActionResult<UserDto> CreateUser(UserForCreationDto user)
        {
            var userEntity = _mapper.Map<User>(user);
            if (_userRepository.UserExists(userEntity.Username))
                return Conflict();

            _userRepository.AddUser(userEntity);
            _userRepository.Save();

            var userToReturn = _mapper.Map<UserDto>(userEntity);
            return CreatedAtRoute("GetUser",
                new { userId = userToReturn.Id },
                userToReturn);
        }
    }
}
