using System.Net;

namespace API_Gateway
{
    public class APIGatewayMiddleware
    {
        private readonly RequestDelegate _next;

        public APIGatewayMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string? path = context.Request.Path.Value;
            var httpClient = new HttpClient();

            var response = path switch
            {
                string p when p.StartsWith("/users") => await httpClient.GetAsync("https://demotestmicroservices-users.azurewebsites.net/"),
                string p when p.StartsWith("/products") => await httpClient.GetAsync("https://demotestmicroservices-products.azurewebsites.net/"),
                string p when p.StartsWith("/orders") => await httpClient.GetAsync("https://demotestmicroservices-orders.azurewebsites.net/"),
                _ => null
            };

            if (response != null)
            {
                await context.Response.WriteAsync(await response.Content.ReadAsStringAsync());
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                await context.Response.WriteAsync("Startup API Gateway project.");
            }

        }
    }
}
