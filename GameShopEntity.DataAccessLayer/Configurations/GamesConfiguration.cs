using Microsoft.EntityFrameworkCore;
using GameShopEntity.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GameShopEntity.DataAccessLayer.Seeding;

namespace GameShopEntity.DataAccessLayer.Configurations
{
    public class GamesConfiguration : IEntityTypeConfiguration<Games>
    {
        public void Configure(EntityTypeBuilder<Games> builder)
        {
            builder.HasKey(game => game.Id);
            builder.Property(game => game.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(game => game.Description)
                   .HasColumnType("text")
                   .IsRequired();

            builder.Property(game=>game.Developer)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(game=>game.Publisher)
                .IsRequired()
                .HasMaxLength (50);

            builder.Property(game => game.ReleaseDate)
                .IsRequired(false)
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()");

            builder.Property(game => game.Price)
                .IsRequired(false)
                .HasColumnType("float");

            builder.Property(game => game.AverageRating)
                .IsRequired()
                .HasColumnType("float");

            new GameSeeder().Seed(builder);
        }
    }
}
