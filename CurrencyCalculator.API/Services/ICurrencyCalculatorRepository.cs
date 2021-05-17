using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyCalculator.API.Entities;
using CurrencyCalculator.API.Models;

namespace CurrencyCalculator.API.Services
{
    public interface ICurrencyCalculatorRepository
    {
        IEnumerable<Currency> GetCurrencies();
        IEnumerable<Currency> GetCurrencies(PaginationFilter paginationFilter);
        Currency GetCurrency(Guid currencyId);
        Currency GetCurrency(string currencyCode);
        void AddCurrency(Currency currency);
        bool CurrencyExists(string currencyCode);
        void UpdateCurrency(Currency currency);
        void DeleteCurrency(Currency currency);
        IEnumerable<CurrencyRate> GetCurrencyRates();
        IEnumerable<CurrencyRate> GetCurrencyRates(PaginationFilter paginationFilte);
        CurrencyRate GetCurrencyRate(Guid currencyRateId);
        CurrencyRate GetCurrencyRate(Guid baseCurrencyId, Guid targetCurrencyId);
        CurrencyRate GetCurrencyRate(string baseCurrencyCode, string targetCurrencyCode);
        void AddCurrencyRate(CurrencyRate currencyRate);
        void UpdateCurrencyRate(CurrencyRate currencyRate);
        void DeleteCurrencyRate(CurrencyRate currencyRate);
        decimal? Calculate(string baseCurrencyCode, string targetCurrencyCode, decimal amount);
        bool Save();
    }
}
