using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApi.DataAccessLayer.Entities;

namespace UserApi.BusinessLogicalLayer.Interface.Services
{
    public interface IUserService
    {
        Task<bool> CheckIfUsernameExistsAsync(string username);

        Task<bool> CheckIfEmailExistsAsync(string email);
        Task CreateUserAsync(Users user);

    }
}
