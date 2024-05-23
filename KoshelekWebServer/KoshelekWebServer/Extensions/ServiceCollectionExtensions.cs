using KoshelekWebServer.Services;
using MessageSenderClient.Services;

namespace KoshelekWebServer.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationtServices(this IServiceCollection services)
        {
            services.AddTransient<SendMessageService, SendMessageService>();
            services.AddTransient<CreateMessageService, CreateMessageService>();
            services.AddTransient<GetMessagesByDateService, GetMessagesByDateService>();
            services.AddSingleton<SendMessageToClientBySocketsService, SendMessageToClientBySocketsService>();

            return services;
        }
    }
}