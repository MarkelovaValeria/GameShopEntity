using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopEntity.DataAccessLayer.Parameters
{
    public class GameCategoryParameter : QueryStringParameters
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int CategoryId { get; set; }
    }
}
