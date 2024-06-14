using System.Net;

namespace OrderService
{
    public class OrderGateWayMiddleWare
    {
        private readonly RequestDelegate _next;


        public OrderGateWayMiddleWare(RequestDelegate next)
        {
            _next = next;
        }
        private static readonly string[] Orders = new[]
        {
            "Pizza-order, ", "Momos-order,", "Roasted-Chicken-Order, ", "Kadhai-Paneer-Order, ", "Tea-Order, ", "Coffee-Order"
        };
        public async Task Invoke(HttpContext context)
        {
            foreach (var o in Orders)
            {
                await context.Response.WriteAsync(o);
            }
        }
        }
    }

