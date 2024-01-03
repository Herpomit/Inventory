using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Inventory.Repository.Migrations
{
    /// <inheritdoc />
    public partial class mg_01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EnventoryRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "Roles", "Admin", "ADMIN" },
                    { 2, null, "Roles", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "EnventoryUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "84e22835-568a-47be-b748-cb932ecfab23", "Users", "info@admin.com", false, false, null, "INFO@ADMIN.COM", "ADMIN", "AQAAAAIAAYagAAAAECXXl/ah66woRSls1Q5JwydK1MtirNswQe0aKDKnpTSRYLm6TZ01PaNwSAKFteD6Sg==", "123456789", false, "315a4a60-c526-4ad7-8da7-a78ea2a08e27", false, "admin" });

            migrationBuilder.InsertData(
                table: "EnventoryUserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EnventoryRole",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EnventoryRole",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EnventoryUser",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EnventoryUserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 });
        }
    }
}
