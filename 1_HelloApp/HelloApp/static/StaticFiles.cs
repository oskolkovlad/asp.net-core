using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace HelloApp
{
    // Статические файлы и работа с ними
    public class StaticFiles
    {
        public void Configure(IApplicationBuilder app)
        {
            // Метод UseDirectoryBrowser

            //app.UseDirectoryBrowser();
            //app.UseDirectoryBrowser(new DirectoryBrowserOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\html")),

            //    RequestPath = new PathString("/pages")
            //});



            // Файлы по умолчанию
            /*
            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear(); // удаляем имена файлов по умолчанию
            options.DefaultFileNames.Add("content.html"); // добавляем новое имя файла
            app.UseDefaultFiles(options); // установка параметров

            //app.UseDefaultFiles();
            */



            /*
            app.UseStaticFiles();

            // Сопоставление каталогов с путями
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\html")),
                RequestPath = new PathString("/pages")
            });
            */



            // Метод UseFileServer() объединяет функциональность сразу всех трех вышеописанных методов
            // UseStaticFiles, UseDefaultFiles и UseDirectoryBrowser
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
