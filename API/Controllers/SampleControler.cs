using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SampleControler : Controller
    {
        [ApiVersion("1.0")]
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Hello, ASP.NET Core Web API";
        }

        /// <summary>

        /// Gets a specific item by ID.

        /// </summary>

        /// <param name="id">The ID of the item.</param>

        /// <returns>The requested item.</returns>

        [ApiVersion("2.0")]
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "Hello, ASP.NET Core Web API v2";
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
