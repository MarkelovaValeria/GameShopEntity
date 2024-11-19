using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApi.DataAccessLayer.Entities;
using UserApi.DataAccessLayer.Seeding;

namespace UserApi.DataAccessLayer.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(role => role.RoleId);

            builder.Property(role => role.RoleName)
                .IsRequired()
                .HasMaxLength(50);

            new RoleSeeder().Seed(builder);
        }
    }
}
