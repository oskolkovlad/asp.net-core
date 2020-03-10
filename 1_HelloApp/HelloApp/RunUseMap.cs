using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HelloApp
{
    public class RunUseMap
    {

        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app)
        {
            app.MapWhen(context =>
            {
                return context.Request.Query.ContainsKey("id") &&
                       context.Request.Query["id"] == "5";
            }, HandlerId);


            app.Run(async context => await context.Response.WriteAsync("Good bye!"));


            // ����� Map(� ������ ���������� MapXXX()) ����������� ��� ������������� ���� ������� � ������������ ���������,
            // ������� ����� ������������ ������ �� ����� ����.

            // ��������� ������ Map
            app.Map("/home", home =>
            {
                home.Map("/index", Index);
                home.Map("/about", About);
            });

            //app.Run(async (context) => await context.Response.WriteAsync("404: Page is not found..."));


            var x = 10;
            var y = 45;

            // ����� Use ����� ��������� ���������� middleware, ������� ����� ������������ ������, �� � ��� ����� ����
            // ������ ��������� � ��������� ������� ��������� middleware.

            app.Use(async (context, next) =>
            {
                x *= y;

                // ������� Func<Task>, ������� ������������ ����� ������ �� ��������� � ��������� ��������� middleware

                // ��� ������������� ������ Use � �������� ���������� ���������� �������� ������� ���������,
                // ��� �� ������������� �������� ����� next.Invoke ����� ������ Response.WriteAsync()
                await next.Invoke();

                x *= 2;
                await context.Response.WriteAsync($"Result 2: {x}");
            });



            // ����� Run ������������ ����� ���������� ������ ��� ���������� ����������� middleware � ��������.
            // ������ ����������, ������������ ����� ����� Run, �� �������� ������� ������ ���������� � ������ ���������
            // ������� �� ��������.

            // ������ ��� ��� ������ ����� �� �������� ��������� ������� ����� �� ���������, �� ��� ������� �������� � ����� �����.
            // �� ���� �� ����� ���� �������� ������ ������.

            app.Run(async (context) =>
            {
                x *= 2;
                await context.Response.WriteAsync($"Result 1: {x}\n");
            });
        }

        private static void Index(IApplicationBuilder app)
        {
            app.Run(async (context) => await context.Response.WriteAsync("INDEX..."));
        }

        private static void About(IApplicationBuilder app)
        {
            app.Run(async (context) => await context.Response.WriteAsync("...ABOUT"));
        }

        private static void HandlerId(IApplicationBuilder app)
        {
            app.Run(async (context) => await context.Response.WriteAsync("id is equals to 5..."));
        }
    }
}
