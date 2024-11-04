using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopEntity.BusinessLogicalLayer.DTO.Request
{
    public class GameRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public double? Price { get; set; }
        public List<int> CategoryId { get; set; }
    }
}
