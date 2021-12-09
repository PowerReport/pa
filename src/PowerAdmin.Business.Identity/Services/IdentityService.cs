using PowerAdmin.Business.Identity.Services.Interfaces;
using PowerAdmin.EntityFramework.Identity.Repositories.Interfaces;
using PowerAdmin.EntityFramework.Shared.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PowerAdmin.Business.Identity.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IIdentityRepository identityRepository;

        public IdentityService(IIdentityRepository identityRepository)
        {
            this.identityRepository = identityRepository;
        }

        public async Task<UserIdentity> GetProfile(ClaimsPrincipal user)
        {
            return await identityRepository.GetProfile(user);
        }
    }
}
