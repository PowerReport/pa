using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerAdmin.Business.Identity.Dtos.Identity;
using PowerAdmin.Business.Identity.Services.Interfaces;

namespace PowerAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IIdentityService identityService;

        public ProfileController(IIdentityService identityService)
        {
            this.identityService = identityService;
        }

        [HttpGet]
        public async Task<ActionResult<UserDto>> GetProfile()
        {
            return await identityService.GetProfile(User);
        }
    }
}
