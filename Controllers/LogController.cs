using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using eecs113_final_project_webapp.Models;

namespace LogController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly DBContext _context;

        public LogController(DBContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("event")]
        public IActionResult PostActionEvent(ActionEvent item)
        {
            _context.AddActionEvent(item);

            return StatusCode(201);
        }
        [HttpPost]
        [Route("weather")]
        public IActionResult PostWeatherData(WeatherData item)
        {
            _context.AddWeatherData(item);

            return StatusCode(201);
        }
    }
}