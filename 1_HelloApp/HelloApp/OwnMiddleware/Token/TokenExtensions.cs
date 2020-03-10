using Microsoft.AspNetCore.Builder;

namespace HelloApp
{
    public static class TokenExtensions
    {
        public static IApplicationBuilder UseToken(this IApplicationBuilder app)
        {
            return app.UseMiddleware<TokenMiddleware>();
        }

        // Передача параметров
        public static IApplicationBuilder UseToken(this IApplicationBuilder app, string pattern)
        {
            return app.UseMiddleware<TokenMiddleware>(pattern);
        }
    }
}
