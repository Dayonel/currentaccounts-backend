using Microsoft.AspNetCore.Mvc;

namespace CurrentAccounts.Controllers
{
    [ApiController]
    [Route("api/status")]
    public class StatusController 
    {
        [HttpGet]
        public IActionResult Get()
        {
            return new ObjectResult("OK");
        }
    }
}
