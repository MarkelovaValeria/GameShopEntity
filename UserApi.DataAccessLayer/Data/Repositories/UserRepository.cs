using UserApi.DataAccessLayer.Entities;
using UserApi.DataAccessLayer.Interface;
using UserApi.DataAccessLayer.Interface.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApi.DataAccessLayer.Data.Repositories
{
    public class UserRepository : GenericRepository<Users>, IUserRepository
    {
        public UserRepository(UserContext userApiContext) : base(userApiContext)
        {
        }

        public async Task AddUserAsync(Users user)
        {
            await table.AddAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await table.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                table.Remove(user);
            }
        }

        public async Task<bool> CheckIfUsernameExistsAsync(string username)
        {
            return await table.AnyAsync(x => x.Username == username);
        }

        
        public async Task<bool> CheckIfEmailExistsAsync(string email)
        {
            return await table.AnyAsync(x => x.Email == email);
        }

       
        public async Task<Users> GetUserByIdAsync(int id)
        {
            return await table.FirstOrDefaultAsync(x => x.Id == id);
        }

        
        public async Task<IEnumerable<Users>> GetAllUsersAsync()
        {
            return await table.ToListAsync();
        }

        
        public override async Task<Users> GetCompleteEntityAsync(int id)
        {
            return await table.Include(u => u.UserRoles) 
                                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
