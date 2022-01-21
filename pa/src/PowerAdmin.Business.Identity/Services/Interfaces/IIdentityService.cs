using PowerAdmin.Business.Identity.Dtos.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PowerAdmin.Business.Identity.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<UserDto> GetProfile(ClaimsPrincipal principal);

        Task<PagedList<UserDto>> GetUsers(string? search, int pageIndex = 1, int pageSize = 10);
    }
}
