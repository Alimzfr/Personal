using Microsoft.AspNetCore.Mvc;

namespace Alimzfr.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ConnectionController : ControllerBase
    {
        public ConnectionController()
        {
        }

        [HttpGet]
        public IActionResult CheckConnection()
        {
            return Ok();
        }
    }
}