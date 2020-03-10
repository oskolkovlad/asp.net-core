using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            // ���� ���������� � �������� ����������
            if (_env.IsDevelopment())
            {
                // �� ������� ���������� �� ������, ��� ������� ������
                app.UseDeveloperExceptionPage();
            }

            // ��������� ����������� �������������
            app.UseRouting();

            // ������������� ������, ������� ����� ��������������
            app.UseEndpoints(endpoints =>
            {
                // ��������� ������� - �������� ��������� ������� � ���� ������� context
                endpoints.MapGet("/", async context =>
                {
                    // �������� ������ � ���� ������ "Hello World!"
                    await context.Response.WriteAsync($"Application name: {_env.ApplicationName}");
                });
            });
        }
    }
}
