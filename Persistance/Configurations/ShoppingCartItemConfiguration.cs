using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.Seeding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Configurations
{
    public class ShoppingCartItemConfiguration : IEntityTypeConfiguration<ShoppingCartItem>
    {
        public void Configure(EntityTypeBuilder<ShoppingCartItem> builder)
        {
            builder.HasKey(game => game.Id);

            builder.Property(game => game.GameId)
                .IsRequired();

            builder.Property(game => game.GameTitle)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(game => game.Price)
                .IsRequired()
                .HasColumnType("float");

            new ShoppingCartItemSeeder().Seed(builder);
        }
    }
}