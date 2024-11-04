﻿// <auto-generated />
using System;
using GameShopEntity.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GameShopEntity.DataAccessLayer.Migrations
{
    [DbContext(typeof(GameShopContext))]
    [Migration("20241022144709_create1")]
    partial class create1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GameShopEntity.DataAccessLayer.Entities.Categories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Games that emphasize physical challenges, including hand-eye coordination and reaction-time. Players often face fast-paced gameplay with a focus on combat and movement.",
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Games that prioritize story-driven experiences, often involving exploration and puzzle-solving. Players typically navigate through a narrative and interact with characters and environments.",
                            Name = "Adventure"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Games where players assume the roles of characters in a fictional setting. Players often engage in quests, develop their character's abilities, and experience an evolving story.",
                            Name = "Role-Playing Game (RPG)"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Games designed to replicate real-world activities or systems. These games can simulate anything from flying airplanes to managing a city, offering a realistic experience of the subject matter.",
                            Name = "Simulation"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Games that require players to use planning and tactics to achieve victory. Players often manage resources, make decisions, and control units or characters to outsmart opponents.",
                            Name = "Strategy"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Games that simulate the practice of sports or physical activities. Players can engage in individual or team-based competitions, representing real-world sports such as football, basketball, or racing.",
                            Name = "Sports"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Games that challenge players with logical problems or tasks. The objective is often to solve puzzles using critical thinking, pattern recognition, or spatial reasoning.",
                            Name = "Puzzle"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Games designed to evoke fear, tension, and suspense. Players typically encounter terrifying situations, monsters, or psychological themes, often requiring them to survive or escape.",
                            Name = "Horror"
                        },
                        new
                        {
                            Id = 9,
                            Description = "Games focused on close combat between characters. Players control fighters in one-on-one battles, utilizing special moves and combos to defeat opponents.",
                            Name = "Fighting"
                        },
                        new
                        {
                            Id = 10,
                            Description = "Games that involve shooting enemies using firearms or projectile weapons. These can be first-person shooters (FPS), where players see through the eyes of the character, or third-person shooters, where the camera is positioned behind the character.",
                            Name = "Shooter"
                        },
                        new
                        {
                            Id = 11,
                            Description = "Games that involve navigating a character across platforms and obstacles, often requiring jumping and climbing. Players typically overcome challenges to reach goals or complete levels.",
                            Name = "Platformer"
                        },
                        new
                        {
                            Id = 12,
                            Description = "Games centered around racing vehicles against opponents or against the clock. These can include realistic simulations or arcade-style racing with power-ups and stunts.",
                            Name = "Racing"
                        },
                        new
                        {
                            Id = 13,
                            Description = "Games that feature expansive environments allowing players to explore freely. These games often include a mix of quests, exploration, and side activities within a large, interactive world.",
                            Name = "Open World"
                        },
                        new
                        {
                            Id = 14,
                            Description = "Games that allow large numbers of players to interact in a virtual world. These games can include elements from various genres, often featuring character progression, trading, and cooperative gameplay.",
                            Name = "MMO (Massively Multiplayer Online)"
                        },
                        new
                        {
                            Id = 15,
                            Description = "Games characterized by procedurally generated levels, permadeath, and turn-based gameplay. Players often collect items and face increasingly difficult challenges in a randomized environment.",
                            Name = "Roguelike/Roguelite"
                        },
                        new
                        {
                            Id = 16,
                            Description = "A subgenre of action-adventure games that emphasize exploration and platforming. Players typically gain new abilities that allow them to access previously unreachable areas within a connected world.",
                            Name = "Metroidvania"
                        },
                        new
                        {
                            Id = 17,
                            Description = "A multiplayer mode where players fight to be the last one standing on a shrinking map, often involving scavenging for weapons and resources.",
                            Name = "Battle Royale"
                        },
                        new
                        {
                            Id = 18,
                            Description = "Games that emphasize avoiding detection and using stealth tactics to accomplish objectives. Players often need to navigate environments quietly and strategically.",
                            Name = "Stealth"
                        },
                        new
                        {
                            Id = 19,
                            Description = "Games where players make minimal actions to progress, often involving resource management and automation over time.",
                            Name = "Idle/Incremental"
                        },
                        new
                        {
                            Id = 20,
                            Description = "Interactive stories that focus on narrative and character development, often featuring branching storylines based on player choices.",
                            Name = "Visual Novel"
                        },
                        new
                        {
                            Id = 21,
                            Description = "Games that challenge players to match their actions to the rhythm of music, often involving timing and coordination.",
                            Name = "Rhythm"
                        },
                        new
                        {
                            Id = 22,
                            Description = "Games that use a deck of cards as the primary gameplay mechanic, often involving strategy and chance in card play.",
                            Name = "Card Game"
                        },
                        new
                        {
                            Id = 23,
                            Description = "Digital adaptations of traditional board games, often involving strategy, luck, and player interaction.",
                            Name = "Board Game"
                        },
                        new
                        {
                            Id = 24,
                            Description = "Games designed to teach players about specific subjects or skills, often incorporating elements of fun and engagement.",
                            Name = "Educational"
                        },
                        new
                        {
                            Id = 25,
                            Description = "Games that challenge players to survive in a hostile environment, often involving resource management, crafting, and combat.",
                            Name = "Survival"
                        },
                        new
                        {
                            Id = 26,
                            Description = "Games set in a fictional universe often inspired by mythology and magic, allowing players to explore magical realms and engage with fantastical creatures.",
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = 27,
                            Description = "Games that explore futuristic or extraterrestrial themes, often involving advanced technology, space exploration, or dystopian societies.",
                            Name = "Sci-Fi"
                        },
                        new
                        {
                            Id = 28,
                            Description = "Games that are set in a specific historical period, often incorporating real events and figures into the gameplay.",
                            Name = "Historical"
                        },
                        new
                        {
                            Id = 29,
                            Description = "Games that focus on managing resources and making decisions to achieve specific goals, such as city-building or business management.",
                            Name = "Management/Simulation"
                        },
                        new
                        {
                            Id = 30,
                            Description = "Games that primarily use text for storytelling and interaction, often relying on player input to navigate the story.",
                            Name = "Text-Based"
                        });
                });

            modelBuilder.Entity("GameShopEntity.DataAccessLayer.Entities.GameCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoriesId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("GamesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoriesId");

                    b.HasIndex("GamesId");

                    b.ToTable("GameCategory");
                });

            modelBuilder.Entity("GameShopEntity.DataAccessLayer.Entities.GameRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("GamesId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GamesId");

                    b.HasIndex("UserId");

                    b.ToTable("GameRating");
                });

            modelBuilder.Entity("GameShopEntity.DataAccessLayer.Entities.Games", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("AverageRating")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Developer")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("ReleaseDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AverageRating = 4.5,
                            Description = "An open-world RPG set in a fantasy world full of magic and monsters.",
                            Developer = "CD Projekt Red",
                            Price = 39.990000000000002,
                            Publisher = "CD Projekt",
                            ReleaseDate = new DateTime(2015, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Witcher 3: Wild Hunt"
                        },
                        new
                        {
                            Id = 2,
                            AverageRating = 4.0,
                            Description = "A challenging action RPG known for its dark atmosphere and intricate world design.",
                            Developer = "FromSoftware",
                            Price = 29.989999999999998,
                            Publisher = "Bandai Namco Entertainment",
                            ReleaseDate = new DateTime(2016, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Dark Souls III"
                        },
                        new
                        {
                            Id = 3,
                            AverageRating = 4.7000000000000002,
                            Description = "An epic tale of life in America at the dawn of the modern age.",
                            Developer = "Rockstar Games",
                            Price = 59.990000000000002,
                            Publisher = "Rockstar Games",
                            ReleaseDate = new DateTime(2018, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Red Dead Redemption 2"
                        },
                        new
                        {
                            Id = 4,
                            AverageRating = 5.0,
                            Description = "A groundbreaking open-world adventure set in the beloved Zelda universe.",
                            Developer = "Nintendo",
                            Price = 59.990000000000002,
                            Publisher = "Nintendo",
                            ReleaseDate = new DateTime(2017, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Legend of Zelda: Breath of the Wild"
                        },
                        new
                        {
                            Id = 5,
                            AverageRating = 4.5,
                            Description = "An action-adventure game that focuses on stealth and precision combat.",
                            Developer = "FromSoftware",
                            Price = 59.990000000000002,
                            Publisher = "Activision",
                            ReleaseDate = new DateTime(2019, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Sekiro: Shadows Die Twice"
                        },
                        new
                        {
                            Id = 6,
                            AverageRating = 3.5,
                            Description = "An action RPG set during the Viking expansion into England.",
                            Developer = "Ubisoft",
                            Price = 59.990000000000002,
                            Publisher = "Ubisoft",
                            ReleaseDate = new DateTime(2020, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Assassin's Creed Valhalla"
                        });
                });

            modelBuilder.Entity("GameShopEntity.DataAccessLayer.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("GameShopEntity.DataAccessLayer.Entities.GameCategory", b =>
                {
                    b.HasOne("GameShopEntity.DataAccessLayer.Entities.Categories", "Categories")
                        .WithMany("GameCategories")
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameShopEntity.DataAccessLayer.Entities.Games", "Games")
                        .WithMany("GameCategories")
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categories");

                    b.Navigation("Games");
                });

            modelBuilder.Entity("GameShopEntity.DataAccessLayer.Entities.GameRating", b =>
                {
                    b.HasOne("GameShopEntity.DataAccessLayer.Entities.Games", "Games")
                        .WithMany("Ratings")
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameShopEntity.DataAccessLayer.Entities.User", "User")
                        .WithMany("GameRatings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Games");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GameShopEntity.DataAccessLayer.Entities.Categories", b =>
                {
                    b.Navigation("GameCategories");
                });

            modelBuilder.Entity("GameShopEntity.DataAccessLayer.Entities.Games", b =>
                {
                    b.Navigation("GameCategories");

                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("GameShopEntity.DataAccessLayer.Entities.User", b =>
                {
                    b.Navigation("GameRatings");
                });
#pragma warning restore 612, 618
        }
    }
}
