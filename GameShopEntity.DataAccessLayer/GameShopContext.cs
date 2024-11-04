using GameShopEntity.DataAccessLayer.Configurations;
using GameShopEntity.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopEntity.DataAccessLayer
{
    public class GameShopContext : DbContext
    {
        public DbSet<Games> Games { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<GameCategory> GameCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new GamesConfiguration());
            modelBuilder.ApplyConfiguration(new CategoriesConfiguration());
            modelBuilder.ApplyConfiguration(new GameCategoryConfiguration());

        }

        public GameShopContext(DbContextOptions<GameShopContext> options) : base(options)
        {

        }
    }
}
