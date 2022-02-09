using Furion.DatabaseAccessor;
using Microsoft.AspNetCore.Identity;
using PowerAdmin.Domain.User.Repositories;
using PowerAdmin.EntityFramework.Shared.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PowerAdmin.EntityFramework.Identity.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<UserIdentity> userManager;

        public UserRepository(UserManager<UserIdentity> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<UserIdentity> GetProfile(ClaimsPrincipal principal)
        {
            return await userManager.GetUserAsync(principal);
        }

        public async Task<PagedList<UserIdentity>> GetUsers(string? search, int pageIndex = 1, int pageSize = 10)
        {
            var userQueryable = userManager.Users;

            if (!string.IsNullOrEmpty(search))
            {
                userQueryable = userQueryable.Where(x => x.UserName.Contains(search) || x.Email.Contains(search) || x.PhoneNumber.Contains(search));
            }

            return await userQueryable.ToPagedListAsync(pageIndex, pageSize);
        }
    }
}
