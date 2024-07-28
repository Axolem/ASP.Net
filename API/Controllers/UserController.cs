using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        public object? GetUser { get; private set; }

        [HttpPost]
        public ActionResult<string> Post([FromBody] User user)
        {
            Console.WriteLine(user.Id);
            return ModelState.IsValid ? "Saved" : BadRequest(ModelState);
        }

        private IActionResult CreatedAtAction()
        {
            throw new NotImplementedException();
        }
    }
}
