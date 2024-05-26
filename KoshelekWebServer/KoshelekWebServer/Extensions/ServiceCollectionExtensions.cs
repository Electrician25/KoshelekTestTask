using KoshelekWebServer.Interfaces;
using KoshelekWebServer.Services;
using MessageSenderClient.Services;

namespace KoshelekWebServer.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationtServices(this IServiceCollection services)
        {
            services.AddTransient<IMessageSenderService, MessageSenderService>();
            services.AddTransient<ICreatorMessageService, CreatorMessageService>();
            services.AddTransient<IMessageByDateService, MessageByDateService>();
            services.AddSingleton<MessageSenderBySocketService, MessageSenderBySocketService>();

            return services;
        }
    }
}