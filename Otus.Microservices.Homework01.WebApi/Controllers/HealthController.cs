using Microsoft.AspNetCore.Mvc;

namespace Otus.Microservices.Homework01.WebApi.Controllers
{
    [ApiController]
    [Route( "[controller]" )]
    public class HealthController : Controller
    {
        [HttpGet]
        [Route( "" )]
        public IActionResult Index()
        {
            return Ok( new { Status = "OK" } );
        }
    }
}
