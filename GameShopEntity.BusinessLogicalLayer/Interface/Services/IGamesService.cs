using GameShopEntity.BusinessLogicalLayer.DTO.Request;
using GameShopEntity.BusinessLogicalLayer.DTO.Response;
using GameShopEntity.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopEntity.BusinessLogicalLayer.Interface.Services
{
    public interface IGamesService
    {
        Task<GameResponse> GetGamesByIdAsync(int id);
        Task<IEnumerable<GameCategoryResponse>> GetCategoriesByGameId(int id);
        Task CreateGame(GameRequest gameCreate);
    }
}
