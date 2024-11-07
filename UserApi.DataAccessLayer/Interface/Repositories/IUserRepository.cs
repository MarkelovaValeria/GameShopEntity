using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApi.DataAccessLayer.Entities;

namespace UserApi.DataAccessLayer.Interface.Repositories
{
    public interface IUserRepository : IRepository<Users>
    {
        Task<bool> CheckIfUsernameExistsAsync(string username);

        Task<bool> CheckIfEmailExistsAsync(string email);
    }
}
