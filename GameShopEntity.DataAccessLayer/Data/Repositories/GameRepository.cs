using GameShopEntity.DataAccessLayer.Entities;
using GameShopEntity.DataAccessLayer.Interface;
using GameShopEntity.DataAccessLayer.Interface.Repositories;
using GameShopEntity.DataAccessLayer.Pagination;
using GameShopEntity.DataAccessLayer.Parameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopEntity.DataAccessLayer.Data.Repositories
{
    public class GameRepository : GenericRepository<Games>, IGameRepository
    {
        public GameRepository(GameShopContext gameShopContext) : base(gameShopContext)
        {
        }

        public Task AddGames(Games games)
        {
            return null;
        }

        public async Task AddGameCategoryAsync(GameCategory gameCreate)
        {
            await gameShopContext.GameCategories.AddAsync(gameCreate);
        }

        public Task DeleteGames(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GameCategory>> GetCategoriesByGameId(int id)
        {
            var categories = await table
                .SelectMany(g => g.GameCategories)
                .Include(g => g.Category)
                .Include(g=>g.Game)
                .Where(g => g.GameId == id)
                .ToListAsync();

            if((table.Select(g=>g.Title)==null) || (table.Select(c => c.GameCategories.Select(c => c.Category.Name)) == null))
            {
                Console.WriteLine("Game or Category == null");
            }

            return categories;
        }

        public override Task<Games> GetCompleteEntityAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Games> GetGamesByIdAsync(int id)
        {
            return await table.FirstOrDefaultAsync(x => x.Id == id);

        }



    }
}
