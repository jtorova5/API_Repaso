using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RepasoAPI.Migrations
{
    /// <inheritdoc />
    public partial class CustomerSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "id", "email", "password", "name" },
                values: new object[,]
                {
                    { 1, "john.doe@example.com", "123", "John" },
                    { 2, "jane.smith@example.com", "456", "Jane" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "id",
                keyValue: 2);
        }
    }
}
