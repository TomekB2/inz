using Microsoft.AspNetCore.Mvc;

namespace Inz.HealthCheck
{
    [Route("api")]
    [ApiController]
    public class EndpointController : ControllerBase
    {
        [HttpGet("HealthCheck")]
        public ActionResult Get()
        {
            return NoContent();
        }
    }
}

