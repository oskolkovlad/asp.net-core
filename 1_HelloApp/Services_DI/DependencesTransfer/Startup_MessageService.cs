using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services_DI.DependencesTransfer;
using Services_DI.Services;

namespace Services_DI
{
    public class Startup_MessageService
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IMessageSender, EmailMessageSender>();
            services.AddTransient<MessageService>();

        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MessageService service)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<MessageMiddleware>();

            app.Run(async context =>
            {
                await context.Response.WriteAsync(service.Send());
            });

            app.Run(async context =>
            {
                IMessageSender message = context.RequestServices.GetService<IMessageSender>();
                context.Response.ContentType = "text/html;charset=utf-8";
                await context.Response.WriteAsync(message.Send());
            });
        }
    }
}
