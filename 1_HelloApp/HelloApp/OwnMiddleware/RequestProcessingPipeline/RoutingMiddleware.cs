using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace HelloApp
{
    public class RoutingMiddleware
    {
        readonly RequestDelegate _next;

        public RoutingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.Value.ToLower();

            if (path == "/index")
            {
                await context.Response.WriteAsync("This is home page...");
            }
            else if (path == "/about")
            {
                await context.Response.WriteAsync("About...");
            }
            else
            {
                context.Response.StatusCode = 404;
            }
        }
    }
}
