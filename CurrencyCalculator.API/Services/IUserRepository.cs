using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyCalculator.API.Entities;
using CurrencyCalculator.API.Models;

namespace CurrencyCalculator.API.Services
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        IEnumerable<User> GetUsers(PaginationFilter filter);
        User GetUser(Guid userId);
        User GetUserByUsername(string username);
        User AddUser(User user);
        void AddUser(User user, IEnumerable<Role> roles);
        bool UserExists(string username);
        void UpdateUserWithoutPassword(User user, IEnumerable<Role> roles);
        void UpdateUserPasswordOnly(Guid userId, string passwordHash);
        void DeleteUser(User user);
        IEnumerable<Role> GetRoles();
        IEnumerable<Role> GetRoles(IEnumerable<string> names);
        bool Save();
        UserDto Login(UserForLoginDto userForLoginDto);
    }
}
