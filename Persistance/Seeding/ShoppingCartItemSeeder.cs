using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Seeding
{
    public class ShoppingCartItemSeeder : ISeeder<ShoppingCartItem>
    {

        private static readonly List<ShoppingCartItem> shoppingCartItems = new()
        {
            new ShoppingCartItem
            {
                Id = 1,
                GameId = 3,
                GameTitle = "Red Dead Redemption 2",
                Price = 59.99,
                ShoppingCartId = 1
            },
            new ShoppingCartItem
            {
                Id = 2,
                GameId = 5,
                GameTitle = "Sekiro: Shadows Die Twice",
                Price = 59.99,
                ShoppingCartId = 1
            },
            new ShoppingCartItem
            {
                Id = 3,
                GameId = 2,
                GameTitle = "Dark Souls III",
                Price = 29.99,
                ShoppingCartId = 1
            }

        };
        public void Seed(EntityTypeBuilder<ShoppingCartItem> builder) => builder.HasData(shoppingCartItems);
    }
}