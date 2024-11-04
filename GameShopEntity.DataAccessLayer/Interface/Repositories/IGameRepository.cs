using GameShopEntity.DataAccessLayer.Entities;
using GameShopEntity.DataAccessLayer.Pagination;
using GameShopEntity.DataAccessLayer.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopEntity.DataAccessLayer.Interface.Repositories
{                                                                         
    public interface IGameRepository:IRepository<Games>
    {
        Task AddGames(Games games);
        Task DeleteGames(int Id);
        Task<Games> GetGamesByIdAsync(int id);
        Task<IEnumerable<GameCategory>> GetCategoriesByGameId(int id);
        Task AddGameCategoryAsync(GameCategory game);
    }
}
