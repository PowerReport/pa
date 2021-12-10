using Microsoft.AspNetCore.Identity;
using PowerAdmin.EntityFramework.Identity.Repositories.Interfaces;
using PowerAdmin.EntityFramework.Shared.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PowerAdmin.EntityFramework.Identity.Repositories
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly UserManager<UserIdentity> userManager;

        public IdentityRepository(UserManager<UserIdentity> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<UserIdentity> GetProfile(ClaimsPrincipal principal)
        {
            return await userManager.GetUserAsync(principal);
        }
    }
}
