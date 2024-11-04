using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopEntity.DataAccessLayer.Entities
{
    public class GameRating
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public Games Games { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime Created { get; set; }
    }
}
