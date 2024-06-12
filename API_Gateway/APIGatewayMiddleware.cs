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
            if (path.StartsWith("/v1/users"))
            {
                // Forward request to User microservice
                var userResponse = await httpClient.GetAsync("http://localhost:5023" + path);
                await context.Response.WriteAsync(await userResponse.Content.ReadAsStringAsync());
            }
            else if (path.StartsWith("/v1/products"))
            {
                // Forward request to Product microservice
                var productResponse = await httpClient.GetAsync("http://localhost:5183" + path);
                await context.Response.WriteAsync(await productResponse.Content.ReadAsStringAsync());
            }
            else if (path.StartsWith("/v1/orders"))
            {
                // Forward request to Order microservice
                var productResponse = await httpClient.GetAsync("http://localhost:5046" + path);
                await context.Response.WriteAsync(await productResponse.Content.ReadAsStringAsync());
            }
            else
            {
                // Handle other routes or return 404
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                await context.Response.WriteAsync("Page not found!");
            }
        }
    }
}
