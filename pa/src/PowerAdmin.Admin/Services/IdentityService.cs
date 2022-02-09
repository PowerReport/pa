using Mapster;
using PowerAdmin.Admin.Services.Interfaces;
using PowerAdmin.Admin.Usecases.Profile;
using PowerAdmin.Admin.Usecases.User;
using PowerAdmin.Domain.User.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PowerAdmin.Admin.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IUserService userService;

        public IdentityService(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<GetProfileCase.Response> GetProfile(ClaimsPrincipal principal)
        {
            var user = await userService.GetProfile(principal);

            return user.Adapt<GetProfileCase.Response>();
        }

        public async Task<PagedList<GetUsersCase.Response>> GetUsers(string? search, int pageIndex = 1, int pageSize = 10)
        {
            var users = await userService.GetUsers(search, pageIndex, pageSize);

            return users.Adapt<PagedList<GetUsersCase.Response>>();
        }
    }
}
