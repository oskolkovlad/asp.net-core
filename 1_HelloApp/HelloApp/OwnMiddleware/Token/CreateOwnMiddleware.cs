using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HelloApp
{
    public class CreateOwnMiddleware
    {

        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app)
        {
            // С помощью метода UseMiddleware<T> в конструктор объекта TokenMiddleware будет внедряться объект для
            // параметра RequestDelegate next. Поэтому явным образом передавать значение для этого параметра нам не нужно.

            //app.UseMiddleware<TokenMiddleware>();
            // OR
            //app.UseToken();


            //Передача параметров
            app.UseToken("555555");

            app.Run(async context =>
            {
                await context.Response.WriteAsync("Start page!!!");
            });
        }
    }
}
