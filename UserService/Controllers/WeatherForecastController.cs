using Microsoft.AspNetCore.Mvc;

namespace UserService.Controllers
{
    [ApiController]
    [Route("v1")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Users = new[]
        {
            "Aaqib", "Pratik", "Chintan", "Saurabh"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("users")]
        public IEnumerable<string> Get()
        {
            return Users;
        }
    }
}
