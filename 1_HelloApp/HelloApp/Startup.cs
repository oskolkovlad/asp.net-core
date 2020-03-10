using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HelloApp
{
    // Класс Startup является входной точкой в приложение ASP.NET Core. Этот класс производит конфигурацию приложения,
    // настраивает сервисы, которые приложение будет использовать, устанавливает компоненты для обработки запроса или middleware.

    // Класс Startup должен определять метод Configure(), и также опционально в Startup можно
    // определить конструктор класса и метод ConfigureServices().
    public class Startup
    {
        IWebHostEnvironment _env;

        public Startup(IWebHostEnvironment env)
        {
            _env = env;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        // Необязательный метод ConfigureServices() регистрирует сервисы, которые используются приложением.
        // В качестве параметра он принимает объект IServiceCollection, который и представляет коллекцию сервисов в приложении.
        // С помощью методов расширений этого объекта производится конфигурация приложения для использования сервисов.
        // Все методы имеют форму Add[название_сервиса].
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        // Метод Configure устанавливает, как приложение будет обрабатывать запрос. Этот метод является обязательным.
        // Для установки компонентов, которые обрабатывают запрос, используются методы объекта IApplicationBuilder.
        // Объект IApplicationBuilder является обязательным параметром для метода Configure.

        // Кроме того, метод нередко принимает еще один необязательный параметр - объект IWebHostEnvironment, который
        // позволяет получить информацию о среде, в которой запускается приложение, и взаимодействовать с ней.
        public void Configure(IApplicationBuilder app/*, IWebHostEnvironment env*/)
        {
            // Компоненты middleware конфигурируются с помощью методов расширений Run, Map и Use объекта IApplicationBuilder,
            // который передается в метод Configure() класса Startup. Каждый компонент может быть определен
            // как анонимный метод (встроенный inline компонент), либо может быть вынесен в отдельный класс.


            // Все вызовы типа app.UseXXX как раз и представляют собой добавление компонентов middleware для обработки запроса.
            // То есть у нас получается примерно следующий конвейер обработки:

            // - Компонент обработки ошибок - Diagnostics. Добавляется через app.UseDeveloperExceptionPage()
            // - Компонент маршрутизации - EndpointRoutingMiddleware. Добавляется через app.UseRouting()
            // - Компонент EndpointMiddleware, который отправляет ответ, если запрос пришел по
            // маршруту "/" (то есть пользователь обратился к корню веб-приложения). Добавляется через метод app.UseEndpoints()


            // если приложение в процессе разработки
            if (_env.IsDevelopment())
            {
                // то выводим информацию об ошибке, при наличии ошибки
                app.UseDeveloperExceptionPage();
            }

            /*if (_env.IsEnvironment("Test")) // Если проект в состоянии "Test"
            {
                await context.Response.WriteAsync("В состоянии тестирования");
            }*/

            // добавляем возможности маршрутизации
            app.UseRouting();

            int x = 2;
            // устанавливаем адреса, которые будут обрабатываться
            app.UseEndpoints(endpoints =>
            {
                // обработка запроса - получаем констекст запроса в виде объекта context
                endpoints.MapGet("/", async context =>
                {
                    x *= x;
                    // отправка ответа в виде строки "Hello World!"
                    await context.Response.WriteAsync($"Application name: {_env.ApplicationName}");
                    await context.Response.WriteAsync($"\nResult: {x}");

                    // Также стоит отметить, что браузер Google Chrome может посылать два запроса - один собственно к приложению,
                    // а другой - к файлу иконки favicon.ico,поэтому в Google Chrome результат может отличаться не 2 раза,
                    // а гораздо больше.
                });
            });
        }
    }
}
