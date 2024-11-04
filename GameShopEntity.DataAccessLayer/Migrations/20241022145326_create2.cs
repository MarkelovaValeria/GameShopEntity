using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameShopEntity.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class create2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameCategory_Categories_CategoriesId",
                table: "GameCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_GameCategory_Games_GamesId",
                table: "GameCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameCategory",
                table: "GameCategory");

            migrationBuilder.DropIndex(
                name: "IX_GameCategory_CategoriesId",
                table: "GameCategory");

            migrationBuilder.DropIndex(
                name: "IX_GameCategory_GamesId",
                table: "GameCategory");

            migrationBuilder.DropColumn(
                name: "CategoriesId",
                table: "GameCategory");

            migrationBuilder.DropColumn(
                name: "GamesId",
                table: "GameCategory");

            migrationBuilder.RenameTable(
                name: "GameCategory",
                newName: "GameCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameCategories",
                table: "GameCategories",
                column: "Id");

            migrationBuilder.InsertData(
                table: "GameCategories",
                columns: new[] { "Id", "CategoryId", "GameId" },
                values: new object[,]
                {
                    { 1, 3, 1 },
                    { 2, 1, 2 },
                    { 3, 13, 3 },
                    { 4, 2, 4 },
                    { 5, 1, 5 },
                    { 6, 1, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameCategories_CategoryId",
                table: "GameCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_GameCategories_GameId",
                table: "GameCategories",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameCategories_Categories_CategoryId",
                table: "GameCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameCategories_Games_GameId",
                table: "GameCategories",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameCategories_Categories_CategoryId",
                table: "GameCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_GameCategories_Games_GameId",
                table: "GameCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameCategories",
                table: "GameCategories");

            migrationBuilder.DropIndex(
                name: "IX_GameCategories_CategoryId",
                table: "GameCategories");

            migrationBuilder.DropIndex(
                name: "IX_GameCategories_GameId",
                table: "GameCategories");

            migrationBuilder.DeleteData(
                table: "GameCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GameCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GameCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GameCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "GameCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "GameCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.RenameTable(
                name: "GameCategories",
                newName: "GameCategory");

            migrationBuilder.AddColumn<int>(
                name: "CategoriesId",
                table: "GameCategory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GamesId",
                table: "GameCategory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameCategory",
                table: "GameCategory",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_GameCategory_CategoriesId",
                table: "GameCategory",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_GameCategory_GamesId",
                table: "GameCategory",
                column: "GamesId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameCategory_Categories_CategoriesId",
                table: "GameCategory",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameCategory_Games_GamesId",
                table: "GameCategory",
                column: "GamesId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
