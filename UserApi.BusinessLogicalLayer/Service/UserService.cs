using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApi.BusinessLogicalLayer.Interface.Services;
using UserApi.DataAccessLayer.Entities;
using UserApi.DataAccessLayer.Interface;
using UserApi.DataAccessLayer.Interface.Repositories;

namespace UserApi.BusinessLogicalLayer.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserRepository userRepository;

        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            this.unitOfWork = unitOfWork;
            this.userRepository = userRepository;
        }

        public async Task<bool> CheckIfEmailExistsAsync(string email)
        {
            return await userRepository.CheckIfEmailExistsAsync(email);
        }

        public async Task<bool> CheckIfUsernameExistsAsync(string username)
        {
            return await userRepository.CheckIfUsernameExistsAsync(username);
        }

        public async Task CreateUserAsync(Users user)
        {
            bool isEmailExists = await CheckIfEmailExistsAsync(user.Email);
            bool isUsernameExists = await CheckIfUsernameExistsAsync(user.Username);

            if (isEmailExists || isUsernameExists)
            {
                throw new Exception("User with the given email or username already exists.");
            }

            await userRepository.AddUserAsync(user);

            await unitOfWork.CommitAsync();
        }
    }
}
