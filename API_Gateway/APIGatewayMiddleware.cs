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
            var path = context.Request.Path.Value;
            var httpClient = new HttpClient();

            // Route requests based on URL
            if (path.StartsWith("/users"))
            {
                // Forward request to User microservice
                var userResponse = await httpClient.GetAsync("https://demotestmicroservices-users.azurewebsites.net/");
                await context.Response.WriteAsync(await userResponse.Content.ReadAsStringAsync());
            }
            else if (path.StartsWith("/products"))
            {
                // Forward request to Product microservice
                var productsResponse = await httpClient.GetAsync("https://demotestmicroservices-products.azurewebsites.net/");
                await context.Response.WriteAsync(await productsResponse.Content.ReadAsStringAsync());
            }
            else if (path.StartsWith("/orders"))
            {
                // Forward request to Order microservice
                var ordersResponse = await httpClient.GetAsync("https://demotestmicroservices-orders.azurewebsites.net/");
                await context.Response.WriteAsync(await ordersResponse.Content.ReadAsStringAsync());
            }
            else
            {
                // Handle other routes or return 404
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                await context.Response.WriteAsync("Startup API Gateway project.");
            }
        }
    }
}
