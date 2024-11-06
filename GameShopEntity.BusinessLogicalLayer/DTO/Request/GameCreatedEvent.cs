using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopEntity.BusinessLogicalLayer.DTO.Request
{
    public class GameCreatedEvent
    {
        public int GameId { get; set; }
        public string Title { get; set; }
        public double? Price { get; set; }
    }
}
