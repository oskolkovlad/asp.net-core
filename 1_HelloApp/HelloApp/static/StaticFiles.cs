using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace HelloApp
{
    public class StaticFiles
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();
            
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello World");
            });
        }
    }
}
