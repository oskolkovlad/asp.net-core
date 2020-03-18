using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services_DI.Services;

namespace Services_DI
{
    public class Startup
    {
        private IServiceCollection _services;

        public void ConfigureServices(IServiceCollection services)
        {
            _services = services;

            //services.AddMvc();

            //services.AddTransient<IMessageSender, EmailMessageSender>();
            services.AddTransient<IMessageSender, SmsMessageSender>();
            //services.AddTransient<TimeService>();
            services.AddTimeService();
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMessageSender messageSender, TimeService timeService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            /*app.Run(async context =>
            {
                var sb = new StringBuilder();
                sb.Append("<h1>Все сервисы</h1>");
                sb.Append("<table>");
                sb.Append("<tr><th>Тип</th><th>Lifetime</th><th>Реализация</th></tr>");

                foreach(var s in _services)
                {
                    sb.Append("<tr>");
                    sb.Append($"<td>{s.ServiceType.FullName}</td>");
                    sb.Append($"<td>{s.Lifetime}</td>");
                    sb.Append($"<td>{s.ImplementationType?.FullName}</td>");
                    sb.Append("</tr>");
                }

                sb.Append("</table>");
                context.Response.ContentType = "text/html;charset=utf-8";

                await context.Response.WriteAsync(sb.ToString());
            });*/

            app.Run(async context =>
            {
                await context.Response.WriteAsync(messageSender.Send() + "\n");
                await context.Response.WriteAsync(timeService.GetTime());
            });
        }
    }
}
