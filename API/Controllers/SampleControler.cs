using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SampleControler : Controller
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Hello, ASP.NET Core Web API";
        }
    }
}
