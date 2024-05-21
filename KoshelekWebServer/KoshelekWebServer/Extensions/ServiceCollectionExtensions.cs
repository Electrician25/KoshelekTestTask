using KoshelekWebServer.IServices;
using KoshelekWebServer.Services;
using MessageSenderClient.Services;

namespace KoshelekWebServer.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationtServices(this IServiceCollection services)
        {
            services.AddTransient<ISendMessageService, SendMessageService>();
            services.AddTransient<IGetMessagesByDateService, GetMessagesByDateService>();
            return services;
        }
    }
}