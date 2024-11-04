using GameShopEntity.DataAccessLayer.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopEntity.DataAccessLayer.Interface
{
    public interface IUnitOfWork
    {
        IGameRepository GameRepository { get; }
        Task SaveChangesAsync();
    }
}
