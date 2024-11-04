using GameShopEntity.DataAccessLayer.Entities;
using GameShopEntity.DataAccessLayer.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopEntity.DataAccessLayer.Configurations
{
    public class GameCategoryConfiguration : IEntityTypeConfiguration<GameCategory>
    {
        public void Configure(EntityTypeBuilder<GameCategory> builder)
        {
            builder.HasKey(gc => gc.Id);

            builder.HasOne(gc => gc.Game)
                .WithMany(c => c.GameCategories);

            builder.HasOne(gc => gc.Category)
                .WithMany(g => g.GameCategories);

            new GameCategorySeeder().Seed(builder);
        }
    }
}