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
    public class GameRatingSeeder : ISeeder<GameRating>
    {
        private static readonly List<GameRating> gameRatings = new()
        {
            new GameRating
            {
                Id = 1, // Унікальний ідентифікатор рейтингу
                GameId = 1, // Ідентифікатор гри (відповідає The Witcher 3)
                UserId = 1, // Ідентифікатор користувача (перший користувач)
                Rating = 5, // Оцінка
                Comment = "An amazing game with great storytelling!", // Коментар
                Created = DateTime.UtcNow // Дата створення рейтингу
            }
        };

        public void Seed(EntityTypeBuilder<GameRating> builder) => builder.HasData(gameRatings);
    }
}
