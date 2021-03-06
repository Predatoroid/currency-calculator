// <auto-generated />
using System;
using CurrencyCalculator.API.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CurrencyCalculator.API.Migrations
{
    [DbContext(typeof(CurrencyCalculatorContext))]
    partial class CurrencyCalculatorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CurrencyCalculator.API.Entities.Currency", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<DateTimeOffset>("DatetimeCreated")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DatetimeUpdated")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Currencies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            Code = "EUR",
                            DatetimeCreated = new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 823, DateTimeKind.Unspecified).AddTicks(8141), new TimeSpan(0, 0, 0, 0, 0)),
                            DatetimeUpdated = new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 823, DateTimeKind.Unspecified).AddTicks(8620), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Euro",
                            IsActive = true
                        },
                        new
                        {
                            Id = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                            Code = "USD",
                            DatetimeCreated = new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 823, DateTimeKind.Unspecified).AddTicks(9479), new TimeSpan(0, 0, 0, 0, 0)),
                            DatetimeUpdated = new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 823, DateTimeKind.Unspecified).AddTicks(9491), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "US Dollar",
                            IsActive = true
                        },
                        new
                        {
                            Id = new Guid("2902b665-1190-4c70-9915-b9c2d7680450"),
                            Code = "CHF",
                            DatetimeCreated = new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 823, DateTimeKind.Unspecified).AddTicks(9508), new TimeSpan(0, 0, 0, 0, 0)),
                            DatetimeUpdated = new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 823, DateTimeKind.Unspecified).AddTicks(9509), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Swiss Franc",
                            IsActive = true
                        },
                        new
                        {
                            Id = new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                            Code = "GBP",
                            DatetimeCreated = new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 823, DateTimeKind.Unspecified).AddTicks(9512), new TimeSpan(0, 0, 0, 0, 0)),
                            DatetimeUpdated = new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 823, DateTimeKind.Unspecified).AddTicks(9513), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "British Pound",
                            IsActive = true
                        },
                        new
                        {
                            Id = new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                            Code = "JPY",
                            DatetimeCreated = new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 823, DateTimeKind.Unspecified).AddTicks(9516), new TimeSpan(0, 0, 0, 0, 0)),
                            DatetimeUpdated = new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 823, DateTimeKind.Unspecified).AddTicks(9517), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Japanese Yen",
                            IsActive = true
                        },
                        new
                        {
                            Id = new Guid("2aadd2df-7caf-45ab-9355-7f6332985a87"),
                            Code = "CAD",
                            DatetimeCreated = new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 823, DateTimeKind.Unspecified).AddTicks(9519), new TimeSpan(0, 0, 0, 0, 0)),
                            DatetimeUpdated = new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 823, DateTimeKind.Unspecified).AddTicks(9520), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Canadian Dollar",
                            IsActive = true
                        });
                });

            modelBuilder.Entity("CurrencyCalculator.API.Entities.CurrencyRate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BaseCurrencyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("DatetimeCreated")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DatetimeUpdated")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("TargetCurrencyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(19,6)");

                    b.HasKey("Id");

                    b.HasIndex("BaseCurrencyId");

                    b.HasIndex("TargetCurrencyId");

                    b.ToTable("CurrencyRates");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"),
                            BaseCurrencyId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            DatetimeCreated = new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 825, DateTimeKind.Unspecified).AddTicks(2267), new TimeSpan(0, 0, 0, 0, 0)),
                            DatetimeUpdated = new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 825, DateTimeKind.Unspecified).AddTicks(2279), new TimeSpan(0, 0, 0, 0, 0)),
                            IsActive = true,
                            TargetCurrencyId = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                            Value = 1.3764m
                        },
                        new
                        {
                            Id = new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                            BaseCurrencyId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            DatetimeCreated = new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 825, DateTimeKind.Unspecified).AddTicks(2335), new TimeSpan(0, 0, 0, 0, 0)),
                            DatetimeUpdated = new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 825, DateTimeKind.Unspecified).AddTicks(2337), new TimeSpan(0, 0, 0, 0, 0)),
                            IsActive = true,
                            TargetCurrencyId = new Guid("2902b665-1190-4c70-9915-b9c2d7680450"),
                            Value = 1.2079m
                        },
                        new
                        {
                            Id = new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
                            BaseCurrencyId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            DatetimeCreated = new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 825, DateTimeKind.Unspecified).AddTicks(2342), new TimeSpan(0, 0, 0, 0, 0)),
                            DatetimeUpdated = new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 825, DateTimeKind.Unspecified).AddTicks(2344), new TimeSpan(0, 0, 0, 0, 0)),
                            IsActive = true,
                            TargetCurrencyId = new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                            Value = 0.8731m
                        },
                        new
                        {
                            Id = new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97"),
                            BaseCurrencyId = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                            DatetimeCreated = new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 825, DateTimeKind.Unspecified).AddTicks(2348), new TimeSpan(0, 0, 0, 0, 0)),
                            DatetimeUpdated = new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 825, DateTimeKind.Unspecified).AddTicks(2350), new TimeSpan(0, 0, 0, 0, 0)),
                            IsActive = true,
                            TargetCurrencyId = new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                            Value = 76.7200m
                        },
                        new
                        {
                            Id = new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"),
                            BaseCurrencyId = new Guid("2902b665-1190-4c70-9915-b9c2d7680450"),
                            DatetimeCreated = new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 825, DateTimeKind.Unspecified).AddTicks(2354), new TimeSpan(0, 0, 0, 0, 0)),
                            DatetimeUpdated = new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 825, DateTimeKind.Unspecified).AddTicks(2355), new TimeSpan(0, 0, 0, 0, 0)),
                            IsActive = true,
                            TargetCurrencyId = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                            Value = 1.1379m
                        },
                        new
                        {
                            Id = new Guid("39b4829c-d66c-4ab8-b2e3-eceb5fdf5066"),
                            BaseCurrencyId = new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                            DatetimeCreated = new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 825, DateTimeKind.Unspecified).AddTicks(2360), new TimeSpan(0, 0, 0, 0, 0)),
                            DatetimeUpdated = new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 825, DateTimeKind.Unspecified).AddTicks(2361), new TimeSpan(0, 0, 0, 0, 0)),
                            IsActive = true,
                            TargetCurrencyId = new Guid("2aadd2df-7caf-45ab-9355-7f6332985a87"),
                            Value = 1.5648m
                        });
                });

            modelBuilder.Entity("CurrencyCalculator.API.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("DatetimeCreated")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DatetimeUpdated")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ae49af2c-0203-430d-ba34-a1328b9f5ac8"),
                            DatetimeCreated = new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 988, DateTimeKind.Unspecified).AddTicks(2679), new TimeSpan(0, 0, 0, 0, 0)),
                            DatetimeUpdated = new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 988, DateTimeKind.Unspecified).AddTicks(2688), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "admin",
                            IsActive = true
                        },
                        new
                        {
                            Id = new Guid("902fde4b-4e5c-426b-ae79-fe7257905d0d"),
                            DatetimeCreated = new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 988, DateTimeKind.Unspecified).AddTicks(2717), new TimeSpan(0, 0, 0, 0, 0)),
                            DatetimeUpdated = new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 988, DateTimeKind.Unspecified).AddTicks(2718), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "user",
                            IsActive = true
                        });
                });

            modelBuilder.Entity("CurrencyCalculator.API.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("DatetimeCreated")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DatetimeUpdated")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8e0d3864-da2a-4c65-8433-2bb0cc11d724"),
                            DatetimeCreated = new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 987, DateTimeKind.Unspecified).AddTicks(1907), new TimeSpan(0, 0, 0, 0, 0)),
                            DatetimeUpdated = new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 987, DateTimeKind.Unspecified).AddTicks(2012), new TimeSpan(0, 0, 0, 0, 0)),
                            Email = "admin@mshome.com",
                            IsActive = true,
                            Password = "XSvVA0tYXn+FoCY4km+1i9TGwWVHcxgCYTAB0AMlaAJkBC7PXdP55zR4y1EaJEsAPgXe8D0W/fo8Abb51nFSV21Q6Y2NOIP/X9+KlCnPQk5ZqjJz8RYL6GNps1EOOTi3",
                            Username = "admin"
                        },
                        new
                        {
                            Id = new Guid("82e0ac26-d6a2-4adf-b3b3-a1e4d89bec3b"),
                            DatetimeCreated = new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 988, DateTimeKind.Unspecified).AddTicks(203), new TimeSpan(0, 0, 0, 0, 0)),
                            DatetimeUpdated = new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 988, DateTimeKind.Unspecified).AddTicks(209), new TimeSpan(0, 0, 0, 0, 0)),
                            Email = "testuser@mshome.com",
                            IsActive = true,
                            Password = "JN04BtgnycOjt4aPufw6CEc0p3Wd1AWFuVPj8KR+ZW7TDJFBz4tcRHR/4cK2HXHOz6wWotRbuaLLgYY/cu6UGpPxEC/wmmd8U0Bqefh+GJl+gHhyfUtAXpUMXrfWO2DV",
                            Username = "testuser"
                        });
                });

            modelBuilder.Entity("CurrencyCalculator.API.Entities.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("DatetimeCreated")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DatetimeUpdated")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e37bc6cd-5ab9-42ce-a64b-737d01607002"),
                            DatetimeCreated = new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 988, DateTimeKind.Unspecified).AddTicks(4401), new TimeSpan(0, 0, 0, 0, 0)),
                            DatetimeUpdated = new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 988, DateTimeKind.Unspecified).AddTicks(4409), new TimeSpan(0, 0, 0, 0, 0)),
                            IsActive = true,
                            RoleId = new Guid("ae49af2c-0203-430d-ba34-a1328b9f5ac8"),
                            UserId = new Guid("8e0d3864-da2a-4c65-8433-2bb0cc11d724")
                        },
                        new
                        {
                            Id = new Guid("d3f211b7-560b-4650-aded-2df79848416c"),
                            DatetimeCreated = new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 988, DateTimeKind.Unspecified).AddTicks(4459), new TimeSpan(0, 0, 0, 0, 0)),
                            DatetimeUpdated = new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 988, DateTimeKind.Unspecified).AddTicks(4461), new TimeSpan(0, 0, 0, 0, 0)),
                            IsActive = true,
                            RoleId = new Guid("902fde4b-4e5c-426b-ae79-fe7257905d0d"),
                            UserId = new Guid("82e0ac26-d6a2-4adf-b3b3-a1e4d89bec3b")
                        });
                });

            modelBuilder.Entity("CurrencyCalculator.API.Entities.CurrencyRate", b =>
                {
                    b.HasOne("CurrencyCalculator.API.Entities.Currency", "BaseCurrency")
                        .WithMany()
                        .HasForeignKey("BaseCurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CurrencyCalculator.API.Entities.Currency", "TargetCurrency")
                        .WithMany()
                        .HasForeignKey("TargetCurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BaseCurrency");

                    b.Navigation("TargetCurrency");
                });

            modelBuilder.Entity("CurrencyCalculator.API.Entities.UserRole", b =>
                {
                    b.HasOne("CurrencyCalculator.API.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CurrencyCalculator.API.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CurrencyCalculator.API.Entities.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
