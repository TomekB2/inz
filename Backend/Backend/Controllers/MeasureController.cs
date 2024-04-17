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
    public class MeasureController : ControllerBase
    {
        private readonly ILogger<MeasureController> _logger;

        public MeasureController(ILogger<MeasureController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetFermentationList"), Authorize]
        public IActionResult Get()
        {
            var measureList = new List<MeasureList>();
            try
            {
                using (var context = new TempContext())
                {
                    var list = context.Measures.ToList();
                    foreach (var measure in list)
                    {
                        measureList.Add(new MeasureList { id = measure.Id, name = $"{measure.StartTime} - {measure.EndTime}" });
                    }
                }
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
            return Ok(measureList);           
        }
    }
}


