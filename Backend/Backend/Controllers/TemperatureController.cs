using Backend.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemperatureController : ControllerBase
    {
        private readonly ILogger<TemperatureController> _logger;

        public TemperatureController(ILogger<TemperatureController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetTemperatures"), Authorize]
        public IActionResult Get(int id)
        {
            var TemperatureList = new List<TemperatureList>();
            try
            {
                using (var context = new TempContext())
                {
                    var list = context.Temperatures.Where(x => x.MeasureId == id).ToList();
                    if (list.Count == 0)
                    {
                        return BadRequest();
                    }
                    foreach (var temperature in list)
                    {
                        TemperatureList.Add(new TemperatureList { id = temperature.Id, date = temperature.Date, insideTemperature = temperature.InsideTemperature, outsideTemperature = temperature.OutsideTemperature});
                    }
                }
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
            return Ok(TemperatureList);           
        }
    }
}


