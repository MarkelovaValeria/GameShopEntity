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
    public class UserRoleSeeder : ISeeder<UserRole>
    {
        private static readonly List<UserRole> userRoles = new()
        {
            new UserRole
            {
                UserId = 1,
                RoleId = 1  // Призначення користувача з Id = 1 на роль Admin
            },
            new UserRole
            {
                UserId = 2,
                RoleId = 2  // Призначення користувача з Id = 2 на роль User
            },
            new UserRole
            {
                UserId = 3,
                RoleId = 2  // Призначення користувача з Id = 3 на роль User
            }
        };

        public void Seed(EntityTypeBuilder<UserRole> builder) => builder.HasData(userRoles);
    }
}
