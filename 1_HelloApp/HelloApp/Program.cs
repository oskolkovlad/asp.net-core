using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace HelloApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // В методе Main вызывается метод у созданного объекта IHostBuilder вызывается метод Build(), который собственно
            // создает хост - объект IHost, в рамках которого развертывается веб-приложение. А затем для непосредственного
            // запуска у IHost вызывается метод Run.

            CreateHostBuilder(args).Build().Run();

            // После этого приложение запущено, и веб-сервер начинает прослушивать все входящие HTTP-запросы.
        }

        // Чтобы запустить приложение ASP.NET Core, необходим объект IHost, в рамках которого развертывается веб-приложение.
        // Для создания IHost применяется объект IHostBuilder.
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            // Непосредственно создание IHostBuilder производится с помощью метода Host.CreateDefaultBuilder(args).
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<StaticFiles>();
                    //webBuilder.UseWebRoot("static");
                });
    }
}
