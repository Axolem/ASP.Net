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


        [HttpPost]
        public ActionResult<string> Post([FromBody] string value)
        {

            value = $"RecievedL {value.Trim()}";
            //return value;
            //return Ok(value);
            //return BadRequest();
            return NotFound(value);
        }

        //[HttpPost]
        //public ActionResult<User> AddUser([FromBody] User user)
        //{
        //    return CreatedAtAction(nameof(GetUser), new object { id = user.id }, user);
        //}
    }

    //public class User
    //{
    //    public string id = Guid.NewGuid().ToString();
    //}
}
