using PowerAdmin.EntityFramework.Identity.Entities;
using PowerAdmin.EntityFramework.Identity.Repositories.Interfaces;
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
        public Task<UserIdentity> GetProfile(ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }
    }
}
