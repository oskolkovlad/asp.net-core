using Microsoft.AspNetCore.Http;
using Services_DI.Services;
using System.Threading.Tasks;

namespace Services_DI.DependencesTransfer
{
    public class MessageMiddleware
    {
        private readonly RequestDelegate next;

        public MessageMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, IMessageSender messageSender)
        {
            context.Response.ContentType = "text/html;charset=utf-8";
            await context.Response.WriteAsync(messageSender.Send());
        }
    }
}
