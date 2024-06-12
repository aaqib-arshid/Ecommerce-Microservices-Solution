using Microsoft.AspNetCore.Mvc;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("v1")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Products = new[]
        {
             "Pizza", "Momos", "Roasted Chicken", "Kadhai paneer", "Tea", "Coffee"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("products")]
        public IEnumerable<string> Get()
        {
            return Products;
        }
    }
}
