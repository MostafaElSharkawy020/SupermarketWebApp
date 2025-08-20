using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupermarketWebApp.Migrations
{
    /// <inheritdoc />
    public partial class fifth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Cards_cardId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_cardId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "cardId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Users_cardId",
                table: "Users",
                column: "cardId",
                unique: true,
                filter: "[cardId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Cards_cardId",
                table: "Users",
                column: "cardId",
                principalTable: "Cards",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Cards_cardId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_cardId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "cardId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_cardId",
                table: "Users",
                column: "cardId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Cards_cardId",
                table: "Users",
                column: "cardId",
                principalTable: "Cards",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
