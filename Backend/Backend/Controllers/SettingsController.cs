using Backend.DTO;
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
    public class SettingsController : ControllerBase
    {
        private readonly ILogger<SettingsController> _logger;

        public SettingsController(ILogger<SettingsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetSettings"), Authorize]
        public IActionResult Get()
        {
            var settingslist = new List<Settings>();
            try
            {
                using (var context = new TempContext())
                {
                    var list = context.Settings.ToList();
                    if (list.Count == 0)
                    {
                        return BadRequest();
                    }
                    foreach (var setting in list)
                    {
                        settingslist.Add(new Settings { id = setting.Id, name = setting.Name, value = setting.Value});
                    }
                }
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
            return Ok(settingslist);           
        }
        [HttpPost(Name = "PostSettings"), Authorize]
        public IActionResult Post(SettingsDTO settingsDTO)
        {
            try
            {
                using (var context = new TempContext())
                {
                    context.Settings.Where(x => x.Id == 1).First().Value = settingsDTO.value1;
                    context.Settings.Where(x => x.Id == 2).First().Value = settingsDTO.value2;
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
            return NoContent();
        }
    }
}


