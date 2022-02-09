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

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<UserIdentity> GetProfile(ClaimsPrincipal principal)
        {
            return await userRepository.GetProfile(principal);
        }

        public async Task<PagedList<UserIdentity>> GetUsers(string? search, int pageIndex = 1, int pageSize = 10)
        {
            return await userRepository.GetUsers(search, pageIndex, pageSize);
        }

        public async Task<UserIdentity> GetUser(string id)
        {
            return await userRepository.GetUser(id);
        }
    }
}
