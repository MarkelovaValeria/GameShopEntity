using GameShopEntity.DataAccessLayer.Interface;
using GameShopEntity.DataAccessLayer.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopEntity.DataAccessLayer.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly GameShopContext databaseContext;
        public IGameRepository GameRepository{ get; }
        public async Task SaveChangesAsync()
        {
            await databaseContext.SaveChangesAsync();
        }

        public UnitOfWork(GameShopContext databaseContext, IGameRepository gameRepository)
        {
            this.databaseContext = databaseContext;
            GameRepository = gameRepository;
        }

    }
}
