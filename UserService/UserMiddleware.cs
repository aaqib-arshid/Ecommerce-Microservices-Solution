namespace UserService
{
    public class UserMiddleware
    {
        private readonly RequestDelegate _next;


        public UserMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        private static readonly string[] Users = new[]
        {
            "Aaqib, ", "Pratik, ", "Chintan, ", "Saurabh, ", "New-User"
        };
        public async Task Invoke(HttpContext context)
        {
            foreach (var o in Users)
            {
                await context.Response.WriteAsync(o);
            }
        }
    }
}
