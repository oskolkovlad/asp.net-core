using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace HelloApp
{
    // Класс middleware должен иметь конструктор, который принимает параметр типа RequestDelegate.
    // Через этот параметр можно получить ссылку на тот делегат запроса, который стоит следующим в конвейере обработки запроса.

    // Также в классе должен быть определен метод, который должен называться либо Invoke, либо InvokeAsync.
    // Причем этот метод должен возвращать объект Task и принимать в качестве параметра контекст запроса - объект HttpContext.
    // Данный метод собственно и будет обрабатывать запрос.
    public class TokenMiddleware
    {
        readonly RequestDelegate _next;
        string _pattern;

        public TokenMiddleware(RequestDelegate next, string pattern)
        {
            _next = next;
            _pattern = pattern;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["token"];

            if(token != _pattern)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Token is invalid...");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
