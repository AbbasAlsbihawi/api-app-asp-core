using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api_app.Migrations
{
    /// <inheritdoc />
    public partial class seeduser1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "UserName" },
                values: new object[,]
                {
                    { 1, "abbas" },
                    { 2, "ali" },
                    { 3, "ahmed" },
                    { 4, "mohammed" },
                    { 5, "kadem" },
                    { 6, "hussain" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
