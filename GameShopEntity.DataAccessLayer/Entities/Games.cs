using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopEntity.DataAccessLayer.Entities
{
    public class Games
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public double? Price { get; set; }
        public double AverageRating { get; set; }

        public ICollection<GameRating> Ratings { get; set; }
        public ICollection<GameCategory> GameCategories { get; set; }
    }
}
