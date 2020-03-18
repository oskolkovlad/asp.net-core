using Microsoft.Extensions.DependencyInjection;

namespace Services_DI.Services
{
    public static class ServicesExtentions
    {
        public static void AddTimeService(this IServiceCollection service)
        {
            service.AddTransient<TimeService>();
        }
    }
}
