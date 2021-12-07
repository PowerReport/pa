using PowerAdmin.EntityFramework.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PowerAdmin.EntityFramework.Identity.Repositories.Interfaces
{
    public interface IIdentityRepository
    {
        Task<UserIdentity> GetProfile(ClaimsPrincipal user);
    }
}
