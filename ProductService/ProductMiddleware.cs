namespace ProductService
{
    public class ProductMiddleware
    {
        private readonly RequestDelegate _next;


        public ProductMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        private static readonly string[] Products = new[]
       {
             "Pizza, ", "Momos, ", "Roasted-Chicken, ", "Kadhai-paneer, ", "Tea, ", "Coffee, ", "New-Item"
        };
        public async Task Invoke(HttpContext context)
        {
            foreach (var o in Products)
            {
                await context.Response.WriteAsync(o);
            }
        }
    }
}
