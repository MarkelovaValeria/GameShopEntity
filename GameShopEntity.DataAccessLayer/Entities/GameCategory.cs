using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopEntity.DataAccessLayer.Entities
{
    public class GameCategory
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public Games Game { get; set; }

        public int CategoryId { get; set; }
        public Categories Category { get; set; }
    }
}
