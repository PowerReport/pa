using PowerAdmin.EntityFramework.Shared.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PowerAdmin.Domain.User.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserIdentity> GetProfile(ClaimsPrincipal principal);

        Task<PagedList<UserIdentity>> GetUsers(string? search, int pageIndex = 1, int pageSize = 10);
    }
}
