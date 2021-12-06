using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PowerAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProfile()
        {
            throw new NotImplementedException();
        }
    }
}
