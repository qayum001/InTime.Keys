using InTime.Keys.Infrastructure.Services.EmailServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InTime.Keys.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };



        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IBaseEmailService _baseEmailService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IBaseEmailService emailService)
        {
            _logger = logger;
            _baseEmailService = emailService;
        }
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var req = HttpContext;

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("send")]
        public async Task<ActionResult> TestEmailService(string email, string title, string message)
        {
            try
            {
                await _baseEmailService.Send(email, title, message);
                return Ok();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}