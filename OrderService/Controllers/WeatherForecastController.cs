using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("v1")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Orders = new[]
        {
            "Pizza order", "Momos order", "Roasted Chicken order", "Kadhai paneer order", "Tea order", "Coffee order"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("orders")]
        public IEnumerable<string> Get()
        {
            return Orders;
        }
    }
}
