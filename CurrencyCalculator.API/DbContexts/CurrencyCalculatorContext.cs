using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyCalculator.API.Entities;
using CurrencyCalculator.API.Helpers;
using Microsoft.EntityFrameworkCore;

namespace CurrencyCalculator.API.DbContexts
{
    public class CurrencyCalculatorContext : DbContext
    {
        protected CurrencyCalculatorContext()
        {
        }

        public CurrencyCalculatorContext(DbContextOptions<CurrencyCalculatorContext> options) : base(options)
        {
        }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CurrencyRate> CurrencyRates { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>().HasData(
                new Currency()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    Code = "EUR",
                    Description = "Euro",
                    DatetimeCreated = DateTime.UtcNow,
                    DatetimeUpdated = DateTime.UtcNow,
                    IsActive = true
                },
                new Currency()
                {
                    Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    Code = "USD",
                    Description = "US Dollar",
                    DatetimeCreated = DateTime.UtcNow,
                    DatetimeUpdated = DateTime.UtcNow,
                    IsActive = true
                },
                new Currency()
                {
                    Id = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                    Code = "CHF",
                    Description = "Swiss Franc",
                    DatetimeCreated = DateTime.UtcNow,
                    DatetimeUpdated = DateTime.UtcNow,
                    IsActive = true
                },
                new Currency()
                {
                    Id = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                    Code = "GBP",
                    Description = "British Pound",
                    DatetimeCreated = DateTime.UtcNow,
                    DatetimeUpdated = DateTime.UtcNow,
                    IsActive = true
                },
                new Currency()
                {
                    Id = Guid.Parse("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                    Code = "JPY",
                    Description = "Japanese Yen",
                    DatetimeCreated = DateTime.UtcNow,
                    DatetimeUpdated = DateTime.UtcNow,
                    IsActive = true
                },
                new Currency()
                {
                    Id = Guid.Parse("2aadd2df-7caf-45ab-9355-7f6332985a87"),
                    Code = "CAD",
                    Description = "Canadian Dollar",
                    DatetimeCreated = DateTime.UtcNow,
                    DatetimeUpdated = DateTime.UtcNow,
                    IsActive = true
                }
                );

            modelBuilder.Entity<CurrencyRate>().HasData(
                new CurrencyRate()
                {
                    Id = Guid.Parse("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"),
                    BaseCurrencyId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    TargetCurrencyId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    Value = 1.3764m,
                    DatetimeCreated = DateTime.UtcNow,
                    DatetimeUpdated = DateTime.UtcNow,
                    IsActive = true
                },
                new CurrencyRate()
                {
                    Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                    BaseCurrencyId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    TargetCurrencyId = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                    Value = 1.2079m,
                    DatetimeCreated = DateTime.UtcNow,
                    DatetimeUpdated = DateTime.UtcNow,
                    IsActive = true
                },
                new CurrencyRate()
                {
                    Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
                    BaseCurrencyId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    TargetCurrencyId = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                    Value = 0.8731m,
                    DatetimeCreated = DateTime.UtcNow,
                    DatetimeUpdated = DateTime.UtcNow,
                    IsActive = true
                },
                new CurrencyRate()
                {
                    Id = Guid.Parse("d173e20d-159e-4127-9ce9-b0ac2564ad97"),
                    BaseCurrencyId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    TargetCurrencyId = Guid.Parse("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                    Value = 76.7200m,
                    DatetimeCreated = DateTime.UtcNow,
                    DatetimeUpdated = DateTime.UtcNow,
                    IsActive = true
                },
                new CurrencyRate()
                {
                     Id = Guid.Parse("40ff5488-fdab-45b5-bc3a-14302d59869a"),
                     BaseCurrencyId = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                     TargetCurrencyId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                     Value = 1.1379m,
                     DatetimeCreated = DateTime.UtcNow,
                     DatetimeUpdated = DateTime.UtcNow,
                     IsActive = true
                },
                new CurrencyRate()
                {
                    Id = Guid.Parse("39b4829c-d66c-4ab8-b2e3-eceb5fdf5066"),
                    BaseCurrencyId = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                    TargetCurrencyId = Guid.Parse("2aadd2df-7caf-45ab-9355-7f6332985a87"),
                    Value = 1.5648m,
                    DatetimeCreated = DateTime.UtcNow,
                    DatetimeUpdated = DateTime.UtcNow,
                    IsActive = true
                }
                );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.Parse("8e0d3864-da2a-4c65-8433-2bb0cc11d724"),
                    Username = "admin",
                    Email = "admin@mshome.com",
                    Password = CipherHelper.Encrypt("123456", "CurrencyCalculator"),
                    DatetimeCreated = DateTime.UtcNow,
                    DatetimeUpdated = DateTime.UtcNow,
                    IsActive = true
                },
                new User
                {
                    Id = Guid.Parse("82e0ac26-d6a2-4adf-b3b3-a1e4d89bec3b"),
                    Username = "testuser",
                    Email = "testuser@mshome.com",
                    Password = CipherHelper.Encrypt("123456", "CurrencyCalculator"),
                    DatetimeCreated = DateTime.UtcNow,
                    DatetimeUpdated = DateTime.UtcNow,
                    IsActive = true
                }
                );

            modelBuilder.Entity<Role>().HasData(
               new Role
               {
                   Id = Guid.Parse("ae49af2c-0203-430d-ba34-a1328b9f5ac8"),
                   Description = "admin",
                   DatetimeCreated = DateTime.UtcNow,
                   DatetimeUpdated = DateTime.UtcNow,
                   IsActive = true
               },
               new Role
               {
                   Id = Guid.Parse("902fde4b-4e5c-426b-ae79-fe7257905d0d"),
                   Description = "user",
                   DatetimeCreated = DateTime.UtcNow,
                   DatetimeUpdated = DateTime.UtcNow,
                   IsActive = true
               }
               );

            modelBuilder.Entity<UserRole>().HasData(
               new UserRole
               {
                   Id = Guid.Parse("e37bc6cd-5ab9-42ce-a64b-737d01607002"),
                   UserId = Guid.Parse("8e0d3864-da2a-4c65-8433-2bb0cc11d724"),
                   RoleId = Guid.Parse("ae49af2c-0203-430d-ba34-a1328b9f5ac8"),
                   DatetimeCreated = DateTime.UtcNow,
                   DatetimeUpdated = DateTime.UtcNow,
                   IsActive = true
               },
               new UserRole
               {
                   Id = Guid.Parse("d3f211b7-560b-4650-aded-2df79848416c"),
                   UserId = Guid.Parse("82e0ac26-d6a2-4adf-b3b3-a1e4d89bec3b"),
                   RoleId = Guid.Parse("902fde4b-4e5c-426b-ae79-fe7257905d0d"),
                   DatetimeCreated = DateTime.UtcNow,
                   DatetimeUpdated = DateTime.UtcNow,
                   IsActive = true
               }
               );

            base.OnModelCreating(modelBuilder);
        }
    }
}
