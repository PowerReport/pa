using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerAdmin.Business.Identity.Dtos.Identity;
using PowerAdmin.Business.Identity.Services.Interfaces;

namespace PowerAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IIdentityService identityService;

        public UsersController(IIdentityService identityService)
        {
            this.identityService = identityService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedList<UserDto>>> GetUsers(string? search, int pageIndex = 1, int pageSize = 10)
        {
            return await identityService.GetUsers(search, pageIndex, pageSize);
        }
    }
}
