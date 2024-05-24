using DatabaseLevel.DAL.Entities;
using DatabaseLevel.DAL.EntityFramework;
using KoshelekWebServer.Interfaces;

namespace MessageSenderClient.Services
{
    public class MessageSenderService(
        ApplicationContext applicationContext,
        ILogger<MessageSenderService> logger) : IMessageSenderService
    {
        async public Task<Message> SaveMessageServiceAsync(Message userMessage)
        {
            await applicationContext.Messages.AddAsync(userMessage);
            applicationContext.SaveChanges();

            logger.LogInformation("Save message---> " +
                "id:{userMessage.Id}, text{userMessage.MessageText}, date:{userMessage.Date}",
                userMessage.Id, userMessage.MessageText, userMessage.Date);

            return userMessage;
        }
    }
}