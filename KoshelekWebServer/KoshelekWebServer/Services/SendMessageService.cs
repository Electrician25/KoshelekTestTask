using DatabaseLevel.DAL.Entities;
using DatabaseLevel.DAL.EntityFramework;
using KoshelekWebServer.IServices;

namespace MessageSenderClient.Services
{
    public class SendMessageService(ApplicationContext applicationContext) : ISendMessageService
    {
        async public Task<Message> SendMessageServiceAsync(Message userMessage)
        {
            await applicationContext.Messages.AddAsync(userMessage);
            applicationContext.SaveChanges();

            return userMessage;
        }
    }
}