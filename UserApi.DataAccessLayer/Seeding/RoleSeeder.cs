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
    public class RoleSeeder : ISeeder<Role>
    {
        private static readonly List<Role> roles = new()
        {
            new Role
            {
                RoleId = 1,
                RoleName = "Admin"
            },
            new Role
            {
                RoleId = 2,
                RoleName = "User"
            },
            new Role
            {
                RoleId = 3,
                RoleName = "Moderator"
            }
        };

        public void Seed(EntityTypeBuilder<Role> builder) => builder.HasData(roles);
    }
}
