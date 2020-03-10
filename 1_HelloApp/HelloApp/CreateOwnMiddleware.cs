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
            // � ������� ������ UseMiddleware<T> � ����������� ������� TokenMiddleware ����� ���������� ������ ���
            // ��������� RequestDelegate next. ������� ����� ������� ���������� �������� ��� ����� ��������� ��� �� �����.

            //app.UseMiddleware<TokenMiddleware>();
            // OR
            //app.UseToken();


            //�������� ����������
            app.UseToken("555555");

            app.Run(async context =>
            {
                await context.Response.WriteAsync("Start page!!!");
            });
        }
    }
}
