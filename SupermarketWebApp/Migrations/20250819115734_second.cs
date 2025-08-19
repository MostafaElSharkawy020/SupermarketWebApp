using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SupermarketWebApp.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "id", "description", "imagePath", "name" },
                values: new object[,]
                {
                    { 3, "dzdbzxfxbd", "dgafddsfs", "Meat" },
                    { 4, "dzdbzxfxbd", "dgafddsfs", "Poultry" },
                    { 5, "dzdbzxfxbd", "dgafddsfs", "Food Legumes" },
                    { 6, "dzdbzxfxbd", "dgafddsfs", "Canned Food" },
                    { 7, "dzdbzxfxbd", "dgafddsfs", "Drinks" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 7);
        }
    }
}
