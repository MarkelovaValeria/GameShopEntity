using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApi.DataAccessLayer.Entities;
using UserApi.DataAccessLayer.Interface;

namespace UserApi.DataAccessLayer.Seeding
{
    public class UserSeeder : ISeeder<Users>
    {
        private static readonly List<Users> users = new()
        {
            new Users
            {
                UserId = 1,
                Username = "john_doe",
                Email = "john.doe@example.com",
                PasswordHash = "hashed_password_1",  
                CreatedAt = new DateTime(2023, 1, 15),
                IsActive = true
            },
            new Users
            {
                UserId = 2,
                Username = "jane_smith",
                Email = "jane.smith@example.com",
                PasswordHash = "hashed_password_2",  
                CreatedAt = new DateTime(2023, 2, 10),
                IsActive = true
            },
            new Users
            {
                UserId = 3,
                Username = "michael_brown",
                Email = "michael.brown@example.com",
                PasswordHash = "hashed_password_3",  
                CreatedAt = new DateTime(2023, 3, 5),
                IsActive = false
            }
        };

        public void Seed(EntityTypeBuilder<Users> builder) => builder.HasData(users);
    }
}

