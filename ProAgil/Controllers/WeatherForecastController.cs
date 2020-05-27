using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProAgil.Data;
using ProAgil.Model;

namespace ProAgil.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public readonly DataContext _context;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _context.Eventos.ToListAsync();
                return Ok(result);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
            
        }
    }
}
