using GameShopEntity.DataAccessLayer.Entities;
using GameShopEntity.DataAccessLayer.Interface;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopEntity.DataAccessLayer.Seeding
{
    public class GameSeeder : ISeeder<Games>
    {
        private static readonly List<Games> games = new()
        {
            new Games
            {
                Id = 1,
                Title = "The Witcher 3: Wild Hunt",
                Description = "An open-world RPG set in a fantasy world full of magic and monsters.",
                Developer = "CD Projekt Red",
                Publisher = "CD Projekt",
                ReleaseDate = new DateTime(2015, 5, 19),
                Price = 39.99,
                AverageRating = 4.5
            },
            new Games
            {
                Id = 2,
                Title = "Dark Souls III",
                Description = "A challenging action RPG known for its dark atmosphere and intricate world design.",
                Developer = "FromSoftware",
                Publisher = "Bandai Namco Entertainment",
                ReleaseDate = new DateTime(2016, 3, 24),
                Price = 29.99,
                AverageRating = 4.0
            },
            new Games
            {
                Id = 3,
                Title = "Red Dead Redemption 2",
                Description = "An epic tale of life in America at the dawn of the modern age.",
                Developer = "Rockstar Games",
                Publisher = "Rockstar Games",
                ReleaseDate = new DateTime(2018, 10, 26),
                Price = 59.99,
                AverageRating = 4.7
            },
            new Games
            {
                Id = 4,
                Title = "The Legend of Zelda: Breath of the Wild",
                Description = "A groundbreaking open-world adventure set in the beloved Zelda universe.",
                Developer = "Nintendo",
                Publisher = "Nintendo",
                ReleaseDate = new DateTime(2017, 3, 3),
                Price = 59.99,
                AverageRating = 5.0
            },
            new Games
            {
                Id = 5,
                Title = "Sekiro: Shadows Die Twice",
                Description = "An action-adventure game that focuses on stealth and precision combat.",
                Developer = "FromSoftware",
                Publisher = "Activision",
                ReleaseDate = new DateTime(2019, 3, 22),
                Price = 59.99,
                AverageRating = 4.5
            },
            new Games
            {
                Id= 6,
                Title = "Assassin's Creed Valhalla",
                Description = "An action RPG set during the Viking expansion into England.",
                Developer = "Ubisoft",
                Publisher = "Ubisoft",
                ReleaseDate = new DateTime(2020, 11, 10),
                Price = 59.99,
                AverageRating = 3.5
            }
        };

        public void Seed(EntityTypeBuilder<Games> builder) => builder.HasData(games);
    }
}
