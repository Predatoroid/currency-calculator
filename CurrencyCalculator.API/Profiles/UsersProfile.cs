using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CurrencyCalculator.API.Entities;
using CurrencyCalculator.API.Helpers;
using CurrencyCalculator.API.Models;

namespace CurrencyCalculator.API.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(
                    dest => dest.UserRoles,
                    opt => opt.MapFrom(src => src.UserRoles.Select(x => x.Role.Description))
                );
                
            CreateMap<UserDto, User>();

            CreateMap<UserForCreationDto, User>()
                .ForMember(
                    dest => dest.Password,
                    opt => opt.MapFrom(src => CipherHelper.Encrypt(src.Password, "CurrencyCalculator"))
                );

        }
    }
}
