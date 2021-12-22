using Mapster;
using PowerAdmin.Business.Identity.Dtos.Identity;
using PowerAdmin.Business.Identity.Services.Interfaces;
using PowerAdmin.EntityFramework.Identity.Repositories.Interfaces;
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

        public async Task<UserDto> GetProfile(ClaimsPrincipal principal)
        {
            var user = await identityRepository.GetProfile(principal);

            return user.Adapt<UserDto>();
        }

        public async Task<PagedList<UserDto>> GetUsers(string? search, int pageIndex = 1, int pageSize = 10)
        {
            var users = await identityRepository.GetUsers(search, pageIndex, pageSize);

            return users.Adapt<PagedList<UserDto>>();
        }
    }
}
