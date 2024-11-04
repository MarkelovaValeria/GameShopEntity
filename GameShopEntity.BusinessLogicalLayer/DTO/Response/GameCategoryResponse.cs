using GameShopEntity.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopEntity.BusinessLogicalLayer.DTO.Response
{
    public class GameCategoryResponse
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public string Title { get; set; }

        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
