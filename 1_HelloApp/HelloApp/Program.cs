using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace HelloApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // � ������ Main ���������� ����� � ���������� ������� IHostBuilder ���������� ����� Build(), ������� ����������
            // ������� ���� - ������ IHost, � ������ �������� �������������� ���-����������. � ����� ��� �����������������
            // ������� � IHost ���������� ����� Run.

            CreateHostBuilder(args).Build().Run();

            // ����� ����� ���������� ��������, � ���-������ �������� ������������ ��� �������� HTTP-�������.
        }

        // ����� ��������� ���������� ASP.NET Core, ��������� ������ IHost, � ������ �������� �������������� ���-����������.
        // ��� �������� IHost ����������� ������ IHostBuilder.
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            // ��������������� �������� IHostBuilder ������������ � ������� ������ Host.CreateDefaultBuilder(args).
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<AuthMiddleware>();
                });
    }
}
