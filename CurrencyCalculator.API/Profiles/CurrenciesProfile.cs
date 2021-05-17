using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace CurrencyCalculator.API.Profiles
{
    public class CurrenciesProfile : Profile
    {
        public CurrenciesProfile()
        {
            CreateMap<Entities.Currency, Models.CurrencyDto>();
            CreateMap<Models.CurrencyForCreationDto, Entities.Currency>();
        }
    }
}
