using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyCalculator.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DatetimeCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DatetimeUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatetimeCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DatetimeUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DatetimeCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DatetimeUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyRates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BaseCurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TargetCurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(19,6)", nullable: false),
                    DatetimeCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DatetimeUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrencyRates_Currencies_BaseCurrencyId",
                        column: x => x.BaseCurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CurrencyRates_Currencies_TargetCurrencyId",
                        column: x => x.TargetCurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DatetimeCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DatetimeUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Code", "DatetimeCreated", "DatetimeUpdated", "Description", "IsActive" },
                values: new object[,]
                {
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "EUR", new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 823, DateTimeKind.Unspecified).AddTicks(8141), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 823, DateTimeKind.Unspecified).AddTicks(8620), new TimeSpan(0, 0, 0, 0, 0)), "Euro", true },
                    { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), "USD", new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 823, DateTimeKind.Unspecified).AddTicks(9479), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 823, DateTimeKind.Unspecified).AddTicks(9491), new TimeSpan(0, 0, 0, 0, 0)), "US Dollar", true },
                    { new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), "CHF", new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 823, DateTimeKind.Unspecified).AddTicks(9508), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 823, DateTimeKind.Unspecified).AddTicks(9509), new TimeSpan(0, 0, 0, 0, 0)), "Swiss Franc", true },
                    { new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"), "GBP", new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 823, DateTimeKind.Unspecified).AddTicks(9512), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 823, DateTimeKind.Unspecified).AddTicks(9513), new TimeSpan(0, 0, 0, 0, 0)), "British Pound", true },
                    { new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"), "JPY", new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 823, DateTimeKind.Unspecified).AddTicks(9516), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 823, DateTimeKind.Unspecified).AddTicks(9517), new TimeSpan(0, 0, 0, 0, 0)), "Japanese Yen", true },
                    { new Guid("2aadd2df-7caf-45ab-9355-7f6332985a87"), "CAD", new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 823, DateTimeKind.Unspecified).AddTicks(9519), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 823, DateTimeKind.Unspecified).AddTicks(9520), new TimeSpan(0, 0, 0, 0, 0)), "Canadian Dollar", true }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DatetimeCreated", "DatetimeUpdated", "Description", "IsActive" },
                values: new object[,]
                {
                    { new Guid("ae49af2c-0203-430d-ba34-a1328b9f5ac8"), new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 988, DateTimeKind.Unspecified).AddTicks(2679), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 988, DateTimeKind.Unspecified).AddTicks(2688), new TimeSpan(0, 0, 0, 0, 0)), "admin", true },
                    { new Guid("902fde4b-4e5c-426b-ae79-fe7257905d0d"), new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 988, DateTimeKind.Unspecified).AddTicks(2717), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 988, DateTimeKind.Unspecified).AddTicks(2718), new TimeSpan(0, 0, 0, 0, 0)), "user", true }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DatetimeCreated", "DatetimeUpdated", "Email", "IsActive", "Password", "Username" },
                values: new object[,]
                {
                    { new Guid("8e0d3864-da2a-4c65-8433-2bb0cc11d724"), new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 987, DateTimeKind.Unspecified).AddTicks(1907), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 987, DateTimeKind.Unspecified).AddTicks(2012), new TimeSpan(0, 0, 0, 0, 0)), "admin@mshome.com", true, "XSvVA0tYXn+FoCY4km+1i9TGwWVHcxgCYTAB0AMlaAJkBC7PXdP55zR4y1EaJEsAPgXe8D0W/fo8Abb51nFSV21Q6Y2NOIP/X9+KlCnPQk5ZqjJz8RYL6GNps1EOOTi3", "admin" },
                    { new Guid("82e0ac26-d6a2-4adf-b3b3-a1e4d89bec3b"), new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 988, DateTimeKind.Unspecified).AddTicks(203), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 988, DateTimeKind.Unspecified).AddTicks(209), new TimeSpan(0, 0, 0, 0, 0)), "testuser@mshome.com", true, "JN04BtgnycOjt4aPufw6CEc0p3Wd1AWFuVPj8KR+ZW7TDJFBz4tcRHR/4cK2HXHOz6wWotRbuaLLgYY/cu6UGpPxEC/wmmd8U0Bqefh+GJl+gHhyfUtAXpUMXrfWO2DV", "testuser" }
                });

            migrationBuilder.InsertData(
                table: "CurrencyRates",
                columns: new[] { "Id", "BaseCurrencyId", "DatetimeCreated", "DatetimeUpdated", "IsActive", "TargetCurrencyId", "Value" },
                values: new object[,]
                {
                    { new Guid("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"), new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 825, DateTimeKind.Unspecified).AddTicks(2267), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 825, DateTimeKind.Unspecified).AddTicks(2279), new TimeSpan(0, 0, 0, 0, 0)), true, new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), 1.3764m },
                    { new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"), new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 825, DateTimeKind.Unspecified).AddTicks(2335), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 825, DateTimeKind.Unspecified).AddTicks(2337), new TimeSpan(0, 0, 0, 0, 0)), true, new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), 1.2079m },
                    { new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"), new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 825, DateTimeKind.Unspecified).AddTicks(2354), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 825, DateTimeKind.Unspecified).AddTicks(2355), new TimeSpan(0, 0, 0, 0, 0)), true, new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), 1.1379m },
                    { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"), new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 825, DateTimeKind.Unspecified).AddTicks(2342), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 825, DateTimeKind.Unspecified).AddTicks(2344), new TimeSpan(0, 0, 0, 0, 0)), true, new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"), 0.8731m },
                    { new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97"), new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 825, DateTimeKind.Unspecified).AddTicks(2348), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 825, DateTimeKind.Unspecified).AddTicks(2350), new TimeSpan(0, 0, 0, 0, 0)), true, new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"), 76.7200m },
                    { new Guid("39b4829c-d66c-4ab8-b2e3-eceb5fdf5066"), new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"), new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 825, DateTimeKind.Unspecified).AddTicks(2360), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 825, DateTimeKind.Unspecified).AddTicks(2361), new TimeSpan(0, 0, 0, 0, 0)), true, new Guid("2aadd2df-7caf-45ab-9355-7f6332985a87"), 1.5648m }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "DatetimeCreated", "DatetimeUpdated", "IsActive", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("e37bc6cd-5ab9-42ce-a64b-737d01607002"), new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 988, DateTimeKind.Unspecified).AddTicks(4401), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 988, DateTimeKind.Unspecified).AddTicks(4409), new TimeSpan(0, 0, 0, 0, 0)), true, new Guid("ae49af2c-0203-430d-ba34-a1328b9f5ac8"), new Guid("8e0d3864-da2a-4c65-8433-2bb0cc11d724") },
                    { new Guid("d3f211b7-560b-4650-aded-2df79848416c"), new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 988, DateTimeKind.Unspecified).AddTicks(4459), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 5, 16, 20, 51, 15, 988, DateTimeKind.Unspecified).AddTicks(4461), new TimeSpan(0, 0, 0, 0, 0)), true, new Guid("902fde4b-4e5c-426b-ae79-fe7257905d0d"), new Guid("82e0ac26-d6a2-4adf-b3b3-a1e4d89bec3b") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_Code",
                table: "Currencies",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyRates_BaseCurrencyId",
                table: "CurrencyRates",
                column: "BaseCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyRates_TargetCurrencyId",
                table: "CurrencyRates",
                column: "TargetCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrencyRates");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
