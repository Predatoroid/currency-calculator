using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using CurrencyCalculator.API.Models;
using CurrencyCalculator.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyCalculator.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a constructor for AuthController
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="mapper"></param>
        public AuthController(IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository ??
                throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Authenticates the user and creates a JWT token
        /// </summary>
        /// <param name="userForLoginDto"></param>
        /// <returns></returns>
        /// <response code="200">Authenticates the user and creates a JWT token</response>
        /// <response code="401">The credentials are incorrect</response>
        [AllowAnonymous]
        [HttpPost("login")]
        [Produces(MediaTypeNames.Application.Json)]
        public ActionResult<UserDto> Login([FromBody] UserForLoginDto userForLoginDto)
        {
            var userDto = _userRepository.Login(userForLoginDto);
            if (userDto == null)
                return Unauthorized("The username or password is incorrect.");
            
            return Ok(userDto);
        }
    }
}
