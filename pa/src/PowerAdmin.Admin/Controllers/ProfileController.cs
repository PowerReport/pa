using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerAdmin.Admin.Services.Interfaces;
using PowerAdmin.Admin.Usecases.Profile;

namespace PowerAdmin.Admin.Controllers
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
        public async Task<ActionResult<GetProfileCase.Response>> GetProfile()
        {
            return await identityService.GetProfile(User);
        }
    }
}
