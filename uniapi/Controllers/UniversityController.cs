using Microsoft.AspNetCore.Mvc;
using uniapi.Models;

namespace uniapi.Controllers
{
    [ApiController]
    [Route("api/universities")]
    public class UniversityController : ControllerBase
    {

        private readonly ILogger<UniversityController> _logger;
        private readonly IWebHostEnvironment _env;

        public UniversityController(ILogger<UniversityController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        [HttpGet]

        public async Task<ActionResult<List<IDictionary<string, string>>>> Index([FromHeader(Name = "X-API-KEY")] string? k, [FromQuery] bool addresses = false)
        {
            try
            {
                return addresses ? (ActionResult<List<IDictionary<string, string>>>)Ok(await University.AllWithAddresses()) : (ActionResult<List<IDictionary<string, string>>>)Ok(await University.All());
            }
            catch (Exception e)
            {
                if (_env.IsDevelopment())
                {
                    Console.Write(e.ToString());
                }

                return StatusCode(500, "An internal server error occurred.");
            }
        }
    }
}
