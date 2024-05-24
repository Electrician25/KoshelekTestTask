using KoshelekWebServer.Services;
using MessageSenderClient.Services;

namespace KoshelekWebServer.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationtServices(this IServiceCollection services)
        {
            services.AddTransient<MessageSenderService, MessageSenderService>();
            services.AddTransient<CreatorMessageService, CreatorMessageService>();
            services.AddTransient<MessageByDateService, MessageByDateService>();
            services.AddSingleton<MessageSenderBySocketService, MessageSenderBySocketService>();

            return services;
        }
    }
}