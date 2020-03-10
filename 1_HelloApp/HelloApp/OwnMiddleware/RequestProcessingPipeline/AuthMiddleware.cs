using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace HelloApp
{
    public class AuthMiddleware
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseErrorHandlingMiddleware();
            app.UseAuthenticationMiddleware();
            app.UseRoutingMiddelware();
        }
    }
}
