using PowerAdmin.Domain.User.Factories;
using PowerAdmin.Domain.User.Models;
using PowerAdmin.Domain.User.Repositories;
using PowerAdmin.Domain.User.Services.Interfaces;
using PowerAdmin.EntityFramework.Shared.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PowerAdmin.Domain.User.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IUserFactory userFactory;

        public UserService(IUserRepository userRepository, IUserFactory userFactory)
        {
            this.userRepository = userRepository;
            this.userFactory = userFactory;
        }

        public async Task<UserIdentity> GetProfile(ClaimsPrincipal principal)
        {
            return await userRepository.GetProfile(principal);
        }

        public async Task<PagedList<UserIdentity>> GetAll(string? search, int pageIndex = 1, int pageSize = 10)
        {
            return await userRepository.GetAll(search, pageIndex, pageSize);
        }

        public async Task<UserIdentity> Get(string id)
        {
            return await userRepository.Get(id);
        }

        public async Task<UserIdentity> Create(UserName userName, Password password, Password confirmPassword, PhoneNumber phoneNumber, Email email, bool twoFactorEnabled = false)
        {
            var (user, userPassword) = await userFactory.CreateUser(userName, password, confirmPassword, phoneNumber, email, twoFactorEnabled);

            return await userRepository.Add(user, userPassword);
        }
    }
}
