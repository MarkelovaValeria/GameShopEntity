using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameShopEntity.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Developer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GETDATE()"),
                    Price = table.Column<double>(type: "float", nullable: true),
                    AverageRating = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    GamesId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CategoriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameCategory_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameCategory_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameRating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    GamesId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameRating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameRating_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameRating_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Games that emphasize physical challenges, including hand-eye coordination and reaction-time. Players often face fast-paced gameplay with a focus on combat and movement.", "Action" },
                    { 2, "Games that prioritize story-driven experiences, often involving exploration and puzzle-solving. Players typically navigate through a narrative and interact with characters and environments.", "Adventure" },
                    { 3, "Games where players assume the roles of characters in a fictional setting. Players often engage in quests, develop their character's abilities, and experience an evolving story.", "Role-Playing Game (RPG)" },
                    { 4, "Games designed to replicate real-world activities or systems. These games can simulate anything from flying airplanes to managing a city, offering a realistic experience of the subject matter.", "Simulation" },
                    { 5, "Games that require players to use planning and tactics to achieve victory. Players often manage resources, make decisions, and control units or characters to outsmart opponents.", "Strategy" },
                    { 6, "Games that simulate the practice of sports or physical activities. Players can engage in individual or team-based competitions, representing real-world sports such as football, basketball, or racing.", "Sports" },
                    { 7, "Games that challenge players with logical problems or tasks. The objective is often to solve puzzles using critical thinking, pattern recognition, or spatial reasoning.", "Puzzle" },
                    { 8, "Games designed to evoke fear, tension, and suspense. Players typically encounter terrifying situations, monsters, or psychological themes, often requiring them to survive or escape.", "Horror" },
                    { 9, "Games focused on close combat between characters. Players control fighters in one-on-one battles, utilizing special moves and combos to defeat opponents.", "Fighting" },
                    { 10, "Games that involve shooting enemies using firearms or projectile weapons. These can be first-person shooters (FPS), where players see through the eyes of the character, or third-person shooters, where the camera is positioned behind the character.", "Shooter" },
                    { 11, "Games that involve navigating a character across platforms and obstacles, often requiring jumping and climbing. Players typically overcome challenges to reach goals or complete levels.", "Platformer" },
                    { 12, "Games centered around racing vehicles against opponents or against the clock. These can include realistic simulations or arcade-style racing with power-ups and stunts.", "Racing" },
                    { 13, "Games that feature expansive environments allowing players to explore freely. These games often include a mix of quests, exploration, and side activities within a large, interactive world.", "Open World" },
                    { 14, "Games that allow large numbers of players to interact in a virtual world. These games can include elements from various genres, often featuring character progression, trading, and cooperative gameplay.", "MMO (Massively Multiplayer Online)" },
                    { 15, "Games characterized by procedurally generated levels, permadeath, and turn-based gameplay. Players often collect items and face increasingly difficult challenges in a randomized environment.", "Roguelike/Roguelite" },
                    { 16, "A subgenre of action-adventure games that emphasize exploration and platforming. Players typically gain new abilities that allow them to access previously unreachable areas within a connected world.", "Metroidvania" },
                    { 17, "A multiplayer mode where players fight to be the last one standing on a shrinking map, often involving scavenging for weapons and resources.", "Battle Royale" },
                    { 18, "Games that emphasize avoiding detection and using stealth tactics to accomplish objectives. Players often need to navigate environments quietly and strategically.", "Stealth" },
                    { 19, "Games where players make minimal actions to progress, often involving resource management and automation over time.", "Idle/Incremental" },
                    { 20, "Interactive stories that focus on narrative and character development, often featuring branching storylines based on player choices.", "Visual Novel" },
                    { 21, "Games that challenge players to match their actions to the rhythm of music, often involving timing and coordination.", "Rhythm" },
                    { 22, "Games that use a deck of cards as the primary gameplay mechanic, often involving strategy and chance in card play.", "Card Game" },
                    { 23, "Digital adaptations of traditional board games, often involving strategy, luck, and player interaction.", "Board Game" },
                    { 24, "Games designed to teach players about specific subjects or skills, often incorporating elements of fun and engagement.", "Educational" },
                    { 25, "Games that challenge players to survive in a hostile environment, often involving resource management, crafting, and combat.", "Survival" },
                    { 26, "Games set in a fictional universe often inspired by mythology and magic, allowing players to explore magical realms and engage with fantastical creatures.", "Fantasy" },
                    { 27, "Games that explore futuristic or extraterrestrial themes, often involving advanced technology, space exploration, or dystopian societies.", "Sci-Fi" },
                    { 28, "Games that are set in a specific historical period, often incorporating real events and figures into the gameplay.", "Historical" },
                    { 29, "Games that focus on managing resources and making decisions to achieve specific goals, such as city-building or business management.", "Management/Simulation" },
                    { 30, "Games that primarily use text for storytelling and interaction, often relying on player input to navigate the story.", "Text-Based" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "AverageRating", "Description", "Developer", "Price", "Publisher", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, 4.5, "An open-world RPG set in a fantasy world full of magic and monsters.", "CD Projekt Red", 39.990000000000002, "CD Projekt", new DateTime(2015, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Witcher 3: Wild Hunt" },
                    { 2, 4.0, "A challenging action RPG known for its dark atmosphere and intricate world design.", "FromSoftware", 29.989999999999998, "Bandai Namco Entertainment", new DateTime(2016, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dark Souls III" },
                    { 3, 4.7000000000000002, "An epic tale of life in America at the dawn of the modern age.", "Rockstar Games", 59.990000000000002, "Rockstar Games", new DateTime(2018, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Red Dead Redemption 2" },
                    { 4, 5.0, "A groundbreaking open-world adventure set in the beloved Zelda universe.", "Nintendo", 59.990000000000002, "Nintendo", new DateTime(2017, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Legend of Zelda: Breath of the Wild" },
                    { 5, 4.5, "An action-adventure game that focuses on stealth and precision combat.", "FromSoftware", 59.990000000000002, "Activision", new DateTime(2019, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sekiro: Shadows Die Twice" },
                    { 6, 3.5, "An action RPG set during the Viking expansion into England.", "Ubisoft", 59.990000000000002, "Ubisoft", new DateTime(2020, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Assassin's Creed Valhalla" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameCategory_CategoriesId",
                table: "GameCategory",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_GameCategory_GamesId",
                table: "GameCategory",
                column: "GamesId");

            migrationBuilder.CreateIndex(
                name: "IX_GameRating_GamesId",
                table: "GameRating",
                column: "GamesId");

            migrationBuilder.CreateIndex(
                name: "IX_GameRating_UserId",
                table: "GameRating",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameCategory");

            migrationBuilder.DropTable(
                name: "GameRating");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
