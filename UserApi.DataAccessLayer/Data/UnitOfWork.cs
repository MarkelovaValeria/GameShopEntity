
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApi.DataAccessLayer.Interface;
using UserApi.DataAccessLayer.Interface.Repositories;

namespace UserApi.DataAccessLayer.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly UserContext databaseContext;
        public IUserRepository UserRepository{ get; }
        public async Task SaveChangesAsync()
        {
            await databaseContext.SaveChangesAsync();
        }

        public UnitOfWork(UserContext databaseContext, IUserRepository userRepository)
        {
            this.databaseContext = databaseContext;
            UserRepository = userRepository;
        }

    }
}
