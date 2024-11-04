using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Seeding
{
        public class ShoppingCartSeeder : ISeeder<ShoppingCart>
        {
        public void Seed(EntityTypeBuilder<ShoppingCart> builder) => builder.HasData(shoppingCarts);


            private static readonly List<ShoppingCart> shoppingCarts = new()
        {
            new ShoppingCart
            {

                Id = 1,
                UserName = "User1"


            },
            new ShoppingCart
            {

                Id = 2,
                UserName = "User2"
            }
        };
    }

}
