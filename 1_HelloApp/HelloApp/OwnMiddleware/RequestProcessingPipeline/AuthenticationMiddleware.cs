using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace HelloApp
{
    public class AuthenticationMiddleware
    {
        readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!string.IsNullOrWhiteSpace(context.Request.Query["token"]))
            {
                await _next.Invoke(context);
            }
            else
            {
                context.Response.StatusCode = 403;
            }
        }
    }
}
