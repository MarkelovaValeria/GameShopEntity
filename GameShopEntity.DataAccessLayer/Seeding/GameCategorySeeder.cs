using GameShopEntity.DataAccessLayer.Entities;
using GameShopEntity.DataAccessLayer.Interface;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopEntity.DataAccessLayer.Seeding
{
    public class GameCategorySeeder : ISeeder<GameCategory>
    {
        private static readonly List<GameCategory> gameCategories = new()
        {
            new GameCategory
            {
                Id = 1,
                GameId = 1, // The Witcher 3: Wild Hunt
                CategoryId = 3 // RPG
            },
            new GameCategory
            {
                Id = 2,
                GameId = 2, // Dark Souls III
                CategoryId = 1 // Action
            },
            new GameCategory
            {
                Id = 3,
                GameId = 3, // Red Dead Redemption 2
                CategoryId = 13 // Open World
            },
            new GameCategory
            {
                Id = 4,
                GameId = 4, // The Legend of Zelda: Breath of the Wild
                CategoryId = 2 // Adventure
            },
            new GameCategory
            {
                Id = 5,
                GameId = 5, // Sekiro: Shadows Die Twice
                CategoryId = 1 // Action
            },
            new GameCategory
            {
                Id = 6,
                GameId = 6, // Assassin's Creed Valhalla
                CategoryId = 1 // Action
            }
        };

        public void Seed(EntityTypeBuilder<GameCategory> builder) => builder.HasData(gameCategories);
    }
}