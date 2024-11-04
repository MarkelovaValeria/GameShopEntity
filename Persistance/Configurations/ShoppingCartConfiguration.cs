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
    public class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.HasKey(cart => cart.Id); // Вказуємо, що Id є первинним ключем

            builder.Property(cart => cart.UserName)
                .IsRequired() // Username обов'язковий
                .HasMaxLength(50); // Максимальна довжина 50 символів

            builder.Property(cart => cart.TotalPrice)
                .IsRequired(false);

            builder.HasMany(c => c.Items)
                .WithOne(i => i.ShoppingCart)
                .HasForeignKey(i => i.ShoppingCartId)
                .OnDelete(DeleteBehavior.Cascade);

            new ShoppingCartSeeder().Seed(builder);

        }
    }
}
