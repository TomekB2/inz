using Backend.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
        [ApiController]
        [Route("[controller]")]
        public class StopFermentationController : ControllerBase
        {
            private readonly ILogger<StopFermentationController> _logger;

            public StopFermentationController(ILogger<StopFermentationController> logger)
            {
                _logger = logger;
            }

            [HttpPost(Name = "StopFermentation"), Authorize]
            public IActionResult Post()
            {
                try
                {
                    using (var context = new TempContext())
                    {
                        var ferment = context.Measures.Where(x => x.IsActive == true).First();
                        ferment.IsActive = false;
                        ferment.EndTime = DateTime.UtcNow;
                        context.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    return BadRequest(e.ToString());
                    throw;
                }
                return NoContent();
            }
        [HttpGet(Name = "GetActiveStartDate"), Authorize]
        public IActionResult Get()
        {
            try
            {
                using (var context = new TempContext())
                {
                    var ferment = context.Measures.Where(x => x.IsActive == true).First();
                    return Ok(new ActiveDate { activeDate = ferment.StartTime });
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
                throw;
            }
        }
    }
    }
