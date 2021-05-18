using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyCalculator.API.DbContexts;
using CurrencyCalculator.API.Entities;
using CurrencyCalculator.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CurrencyCalculator.API.Services
{
    public class CurrencyCalculatorRepository : ICurrencyCalculatorRepository, IDisposable
    {
        private readonly CurrencyCalculatorContext _context;

        public CurrencyCalculatorRepository(CurrencyCalculatorContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddCurrency(Currency currency)
        {
            if (currency == null)
                throw new ArgumentNullException(nameof(currency));

            currency.DatetimeCreated = DateTime.UtcNow;
            currency.DatetimeUpdated = DateTime.UtcNow;
            currency.IsActive = true;

            _context.Currencies.Add(currency);
        }

        public bool CurrencyExists(string currencyCode)
        {
            var currencyEntity = GetCurrency(currencyCode);
            return currencyEntity != null;
        }

        

        public void AddCurrencyRate(CurrencyRate currencyRate)
        {
            if (currencyRate == null)
                throw new ArgumentNullException(nameof(currencyRate));

            currencyRate.DatetimeCreated = DateTime.UtcNow;
            currencyRate.DatetimeUpdated = DateTime.UtcNow;
            currencyRate.IsActive = true;

            _context.CurrencyRates.Add(currencyRate);
        }

        public void DeleteCurrency(Currency currency)
        {
            _context.Currencies.Remove(currency);
        }

        public void DeleteCurrencyRate(CurrencyRate currencyRate)
        {
            _context.CurrencyRates.Remove(currencyRate);
        }

        public IEnumerable<Currency> GetCurrencies()
        {
            return _context.Currencies
                .Where(x => x.IsActive)
                .ToList();
        }

        public IEnumerable<Currency> GetCurrencies(PaginationFilter filter)
        {
            return _context.Currencies
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .Where(x => x.IsActive)
                .OrderBy(x => x.Code)
                .ToList();
        }

        public IEnumerable<CurrencyRate> GetCurrencyRates()
        {
            return _context.CurrencyRates
                .Include("BaseCurrency")
                .Include("TargetCurrency")
                .Where(x => x.IsActive).ToList();
        }

        public IEnumerable<CurrencyRate> GetCurrencyRates(PaginationFilter filter)
        {
            return _context.CurrencyRates
                .Include("BaseCurrency")
                .Include("TargetCurrency")
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .Where(x => x.IsActive)
                .OrderBy(x => x.Id)
                .ToList();
        }

        public Currency GetCurrency(Guid currencyId)
        {
            if (currencyId == Guid.Empty)
                throw new ArgumentNullException(nameof(currencyId));

            return _context.Currencies.FirstOrDefault(x => x.Id == currencyId && x.IsActive);
        }

        public Currency GetCurrency(string currencyCode)
        {
            return _context.Currencies.FirstOrDefault(x => x.Code == currencyCode && x.IsActive);
        }

        public CurrencyRate GetCurrencyRate(Guid currencyRateId)
        {
            if (currencyRateId == Guid.Empty)
                throw new ArgumentNullException(nameof(currencyRateId));

            return _context.CurrencyRates
                .Include("BaseCurrency")
                .Include("TargetCurrency")
                .FirstOrDefault(x => x.Id == currencyRateId && x.IsActive);
        }

        public CurrencyRate GetCurrencyRate(Guid baseCurrencyId, Guid targetCurrencyId)
        {
            if (baseCurrencyId == Guid.Empty)
                throw new ArgumentNullException(nameof(baseCurrencyId));

            if (targetCurrencyId == Guid.Empty)
                throw new ArgumentNullException(nameof(targetCurrencyId));

            return _context.CurrencyRates
                .Include("BaseCurrency")
                .Include("TargetCurrency")
                .FirstOrDefault(x => x.BaseCurrencyId == baseCurrencyId 
                                  && x.TargetCurrencyId == targetCurrencyId
                                  && x.IsActive);
        }

        public CurrencyRate GetCurrencyRate(string baseCurrencyCode, string targetCurrencyCode)
        {
            return _context.CurrencyRates
                .Include("BaseCurrency")
                .Include("TargetCurrency")
                .FirstOrDefault(x => x.BaseCurrency.Code == baseCurrencyCode 
                                  && x.TargetCurrency.Code == targetCurrencyCode
                                  && x.IsActive);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCurrency(Currency currency)
        {
            // no code in this implementation
        }

        public void UpdateCurrencyRate(CurrencyRate currencyRate)
        {
            // no code in this implementation
        }

        public decimal? Calculate(string baseCurrencyCode, string targetCurrencyCode, decimal amount)
        {
            if (baseCurrencyCode == String.Empty)
                throw new ArgumentException($"{nameof(baseCurrencyCode)} is empty.");

            if (targetCurrencyCode == String.Empty)
                throw new ArgumentException($"{nameof(targetCurrencyCode)} is empty.");

            var currencyRate = GetCurrencyRate(baseCurrencyCode, targetCurrencyCode);
            if (currencyRate == null)
                return null;

            return currencyRate.Value * amount;
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
