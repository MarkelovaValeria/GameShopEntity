using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApi.DataAccessLayer.Entities;
using UserApi.DataAccessLayer.Seeding;

namespace UserApi.DataAccessLayer.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasKey(user => user.Id);

            builder.Property(user => user.Username)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(user => user.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(user => user.PasswordHash)
                .IsRequired()
                .HasColumnType("varchar(255)");

            builder.Property(user => user.CreatedAt)
                .IsRequired()
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()");

            builder.Property(user => user.UpdatedAt)
                .IsRequired(false)
                .HasColumnType("datetime");

            builder.Property(user => user.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            new UserSeeder().Seed(builder);
        }
    }
}
