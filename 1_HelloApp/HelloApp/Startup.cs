using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HelloApp
{
    // ����� Startup �������� ������� ������ � ���������� ASP.NET Core. ���� ����� ���������� ������������ ����������,
    // ����������� �������, ������� ���������� ����� ������������, ������������� ���������� ��� ��������� ������� ��� middleware.

    // ����� Startup ������ ���������� ����� Configure(), � ����� ����������� � Startup �����
    // ���������� ����������� ������ � ����� ConfigureServices().
    public class Startup
    {
        IWebHostEnvironment _env;

        public Startup(IWebHostEnvironment env)
        {
            _env = env;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        // �������������� ����� ConfigureServices() ������������ �������, ������� ������������ �����������.
        // � �������� ��������� �� ��������� ������ IServiceCollection, ������� � ������������ ��������� �������� � ����������.
        // � ������� ������� ���������� ����� ������� ������������ ������������ ���������� ��� ������������� ��������.
        // ��� ������ ����� ����� Add[��������_�������].
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        // ����� Configure �������������, ��� ���������� ����� ������������ ������. ���� ����� �������� ������������.
        // ��� ��������� �����������, ������� ������������ ������, ������������ ������ ������� IApplicationBuilder.
        // ������ IApplicationBuilder �������� ������������ ���������� ��� ������ Configure.

        // ����� ����, ����� ������� ��������� ��� ���� �������������� �������� - ������ IWebHostEnvironment, �������
        // ��������� �������� ���������� � �����, � ������� ����������� ����������, � ����������������� � ���.
        public void Configure(IApplicationBuilder app/*, IWebHostEnvironment env*/)
        {
            // ���������� middleware ��������������� � ������� ������� ���������� Run, Map � Use ������� IApplicationBuilder,
            // ������� ���������� � ����� Configure() ������ Startup. ������ ��������� ����� ���� ���������
            // ��� ��������� ����� (���������� inline ���������), ���� ����� ���� ������� � ��������� �����.


            // ��� ������ ���� app.UseXXX ��� ��� � ������������ ����� ���������� ����������� middleware ��� ��������� �������.
            // �� ���� � ��� ���������� �������� ��������� �������� ���������:

            // - ��������� ��������� ������ - Diagnostics. ����������� ����� app.UseDeveloperExceptionPage()
            // - ��������� ������������� - EndpointRoutingMiddleware. ����������� ����� app.UseRouting()
            // - ��������� EndpointMiddleware, ������� ���������� �����, ���� ������ ������ ��
            // �������� "/" (�� ���� ������������ ��������� � ����� ���-����������). ����������� ����� ����� app.UseEndpoints()


            // ���� ���������� � �������� ����������
            if (_env.IsDevelopment())
            {
                // �� ������� ���������� �� ������, ��� ������� ������
                app.UseDeveloperExceptionPage();
            }

            // ��������� ����������� �������������
            app.UseRouting();

            int x = 2;
            // ������������� ������, ������� ����� ��������������
            app.UseEndpoints(endpoints =>
            {
                // ��������� ������� - �������� ��������� ������� � ���� ������� context
                endpoints.MapGet("/", async context =>
                {
                    x *= x;
                    // �������� ������ � ���� ������ "Hello World!"
                    await context.Response.WriteAsync($"Application name: {_env.ApplicationName}");
                    await context.Response.WriteAsync($"\nResult: {x}");

                    // ����� ����� ��������, ��� ������� Google Chrome ����� �������� ��� ������� - ���� ���������� � ����������,
                    // � ������ - � ����� ������ favicon.ico,������� � Google Chrome ��������� ����� ���������� �� 2 ����,
                    // � ������� ������.
                });
            });
        }
    }
}
