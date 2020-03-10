using Microsoft.AspNetCore.Builder;

namespace HelloApp
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ErrorHandlingMiddleware>();
        }

        public static IApplicationBuilder UseAuthenticationMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<AuthenticationMiddleware>();
        }

        public static IApplicationBuilder UseRoutingMiddelware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RoutingMiddleware>();
        }
    }
}
