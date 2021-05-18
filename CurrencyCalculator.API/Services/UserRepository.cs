using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CurrencyCalculator.API.DbContexts;
using CurrencyCalculator.API.Entities;
using CurrencyCalculator.API.Helpers;
using CurrencyCalculator.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CurrencyCalculator.API.Services
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private readonly CurrencyCalculatorContext _context;
        private readonly IMapper _mapper;
        private readonly double _hoursForTokenToExpire = 1;
        private readonly string _secretKey;

        public UserRepository(CurrencyCalculatorContext context
            , IMapper mapper
            , IOptions<AppSettings> options)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            AppSettings appSettings = options.Value;
            _secretKey = appSettings.SecretKey;
        }

        public User AddUser(User user)
        {
            IEnumerable<Role> roles = GetRoles(user.UserRoles.Select(x => x.Role.Description));
            User userEntity = _mapper.Map<User>(user);
            AddUser(userEntity, roles);

            return userEntity;
        }

        public void AddUser(User user, IEnumerable<Role> roles)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            user.DatetimeCreated = DateTime.UtcNow;
            user.DatetimeUpdated = DateTime.UtcNow;
            user.IsActive = true;

            _context.Users.Add(user);
            _context.UserRoles.AddRange(roles.Select(role => new UserRole
            {
                User = user,
                Role = role
            }));
        }

        public bool UserExists(string username)
        {
            var userEntity = GetUserByUsername(username);
            return userEntity != null;
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users
                .Include("UserRoles")
                .Include("UserRoles.Role")
                .Where(x => x.IsActive)
                .ToList();
        }

        public IEnumerable<User> GetUsers(PaginationFilter filter)
        {
            return _context.Users
                .Include("UserRoles")
                .Include("UserRoles.Role")
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .Where(x => x.IsActive)
                .OrderBy(x => x.Username)
                .ToList();
        }

        public IEnumerable<Role> GetRoles()
        {
            return _context.Roles
                .Where(x => x.IsActive)
                .ToList();
        }

        public IEnumerable<Role> GetRoles(IEnumerable<string> names)
        {
            if (names == null)
                return new List<Role>();

            return _context.Roles
                .Where(x => names.Contains(x.Description) && x.IsActive);
        }

        public User GetUser(Guid userId)
        {
            if (userId == Guid.Empty)
                throw new ArgumentNullException(nameof(userId));

            return _context.Users
                .Include("UserRoles")
                .Include("UserRoles.Role")
                .FirstOrDefault(x => x.Id == userId && x.IsActive);
        }

        public User GetUserByUsername(string username)
        {
            return _context.Users
                .Include("UserRoles")
                .Include("UserRoles.Role")
                .FirstOrDefault(x => x.Username == username && x.IsActive);
        }

        public void UpdateUserPasswordOnly(Guid userId, string passwordHash)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserWithoutPassword(User user, IEnumerable<Role> roles)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public UserDto Login(UserForLoginDto userForLoginDto)
        {
            if (userForLoginDto == null)
                throw new ArgumentNullException(nameof(userForLoginDto));

            User user = GetUserByUsername(userForLoginDto.Username);
            
            if (user == null || userForLoginDto.Password != CipherHelper.Decrypt(user.Password, _secretKey))
                return null;

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Token = JWTHelper.GenerateToken(
                    user.Id,
                    user.UserRoles.Select(ur => ur.Role.Description),
                    _secretKey,
                    _hoursForTokenToExpire
                    ),
                UserRoles = user.UserRoles.Select(ur => ur.Role.Description).ToList(),
                IsActive = true
            };
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }
    }
}
