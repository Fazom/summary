using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace LB13.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("testlogin")]
        [HttpGet]
        public IActionResult GetLogin()
        {
            return Ok($"Ваш логин: {User.Identity.Name}");
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "admin")]
        [Route("testadmin")]
        [HttpGet]
        public IActionResult GetAdmin()
        {
            return Ok($"Здравствуйте админ: {User.Identity.Name}");
        }
    }
}
