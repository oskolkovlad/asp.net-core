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


            // Метод Map(и методы расширения MapXXX()) применяется для сопоставления пути запроса с определенным делегатом,
            // который будет обрабатывать запрос по этому пути.

            // Вложенные методы Map
            app.Map("/home", home =>
            {
                home.Map("/index", Index);
                home.Map("/about", About);
            });

            //app.Run(async (context) => await context.Response.WriteAsync("404: Page is not found..."));


            var x = 10;
            var y = 45;

            // Метод Use также добавляет компоненты middleware, которые также обрабатывают запрос, но в нем может быть
            // вызван следующий в конвейере запроса компонент middleware.

            app.Use(async (context, next) =>
            {
                x *= y;

                // делегат Func<Task>, который представляет собой ссылку на следующий в конвейере компонент middleware

                // При использовании метода Use и передаче выполнения следующему делегату следует учитывать,
                // что не рекомендуется вызывать метод next.Invoke после метода Response.WriteAsync()
                await next.Invoke();

                x *= 2;
                await context.Response.WriteAsync($"Result 2: {x}");
            });



            // Метод Run представляет собой простейший способ для добавления компонентов middleware в конвейер.
            // Однако компоненты, определенные через метод Run, не вызывают никакие другие компоненты и дальше обработку
            // запроса не передают.

            // Причем так как данный метод не передает обработку запроса далее по конвейеру, то его следует помещать в самом конце.
            // До него же могут быть помещены другие методы.

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
