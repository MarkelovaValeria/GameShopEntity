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
    public class UserSeeder : ISeeder<User>
    {
        private static readonly List<User> users = new()
        {
            new User
            {
                Id = 1,
                Name = "Name 1",
                Email = "example@gmail.com"
            },
            new User
            {
                Id = 2,
                Name = "Name 2",
                Email = "example2@gmail.com"
            }
        };

        public void Seed(EntityTypeBuilder<User> builder) => builder.HasData(users);

    }
}
