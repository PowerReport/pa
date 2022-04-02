using PowerAdmin.Admin.Usecases.Profile;
using PowerAdmin.Admin.Usecases.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PowerAdmin.Admin.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<GetProfileCase.Response> GetProfile(ClaimsPrincipal principal);

        Task<PagedList<GetUsersCase.Response>> GetUsers(string? search, int pageIndex = 1, int pageSize = 10);

        Task<GetUserCase.Response> GetUser(string id);

        Task<CreateUserCase.Response> CreateUser(CreateUserCase.Request request);
    }
}
