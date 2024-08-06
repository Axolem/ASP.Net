using Microsoft.AspNetCore.Mvc;
using uniapi.Models;

namespace uniapi.Controllers
{
    [ApiController]
    [Route("universities")]
    public class UniversityController : ControllerBase
    {

        private readonly ILogger<UniversityController> _logger;

        public UniversityController(ILogger<UniversityController> logger)
        {
            _logger = logger;
        }

        public async Task<List<University>> Index()
        {
            try
            {
                return await University.All();
            }
            catch (Exception)
            {
                NotFound();
                return [];
            }
        }
    }
}
