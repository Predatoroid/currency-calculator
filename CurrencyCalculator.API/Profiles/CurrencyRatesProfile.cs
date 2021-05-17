using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CurrencyCalculator.API.Entities;

namespace CurrencyCalculator.API.Profiles
{
    public class CurrencyRatesProfile : Profile
    {
        public CurrencyRatesProfile()
        {
            CreateMap<CurrencyRate, Models.CurrencyRateDto>()
                .ForMember(
                    dest => dest.BaseCurrencyCode,
                    opt => opt.MapFrom(src => src.BaseCurrency.Code)
                )
                .ForMember(
                    dest => dest.TargetCurrencyCode,
                    opt => opt.MapFrom(src => src.TargetCurrency.Code)
                );

            CreateMap<Models.CurrencyRateForCreationDto, CurrencyRate>();
        }
    }
}
