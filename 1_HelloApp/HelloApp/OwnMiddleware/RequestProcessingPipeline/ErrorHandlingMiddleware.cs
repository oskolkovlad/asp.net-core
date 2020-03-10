using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace HelloApp
{
    public class ErrorHandlingMiddleware
    {
        readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next.Invoke(context);

            var status = context.Response.StatusCode;

            if (status.Equals(403))
            {
                await context.Response.WriteAsync("Access Denied!");
            }
            else if (status.Equals(404))
            {
                await context.Response.WriteAsync("Page is not found!");
            }
        }
    }
}
