using Microsoft.AspNetCore.Mvc;
using AppContext = _12LB.Model.AppContext;
using User = _12LB.Model.User;

namespace _12LB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestBDController(AppContext dbContext) : ControllerBase
    {
        //AppContext appDb = new();
        private readonly AppContext _dbContext = dbContext;

        [HttpGet] public IActionResult Index()
        {
            var userslist = _dbContext.Users.ToList();
            return Ok(userslist);
        }
    }
}
