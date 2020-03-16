using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace HelloApp
{
    // ����������� ����� � ������ � ����
    public class StaticFiles
    {
        public void Configure(IApplicationBuilder app)
        {
            // ����� UseDirectoryBrowser

            //app.UseDirectoryBrowser();
            //app.UseDirectoryBrowser(new DirectoryBrowserOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\html")),

            //    RequestPath = new PathString("/pages")
            //});



            // ����� �� ���������
            /*
            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear(); // ������� ����� ������ �� ���������
            options.DefaultFileNames.Add("content.html"); // ��������� ����� ��� �����
            app.UseDefaultFiles(options); // ��������� ����������

            //app.UseDefaultFiles();
            */



            /*
            app.UseStaticFiles();

            // ������������� ��������� � ������
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\html")),
                RequestPath = new PathString("/pages")
            });
            */



            // ����� UseFileServer() ���������� ���������������� ����� ���� ���� ������������� �������
            // UseStaticFiles, UseDefaultFiles � UseDirectoryBrowser
            app.UseFileServer(new FileServerOptions
            {
                EnableDirectoryBrowsing = true,
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\html")),
                RequestPath = new PathString("/pages"),
                EnableDefaultFiles = false
            });



            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello World");
            });
        }
    }
}
