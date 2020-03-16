using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace HelloApp
{
    public class Errors
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            env.EnvironmentName = "Production";
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }
            // обработка ошибок HTTP
            app.UseStatusCodePages();
            app.UseStatusCodePagesWithRedirects("/error?code={0}");
            app.UseStatusCodePagesWithReExecute("/error", "?code={0}");

            app.Map("/error", ap => ap.Run(async context =>
            {
                await context.Response.WriteAsync($"Err: {context.Request.Query["code"]}");
            }));

            /*app.Map("/error", ap => ap.Run(async context =>
            {
                await context.Response.WriteAsync("DivideByZeroException occured!");
            }));*/

            /*app.Run(async context =>
            {
                var x = 0;
                var y = 1 / x;
                await context.Response.WriteAsync(y.ToString());
            });*/
        }
    }
}
