using DatabaseLevel.DAL.Entities;
using DatabaseLevel.DAL.EntityFramework;

namespace MessageSenderClient.Services
{
    public class SendMessageService(
        ApplicationContext applicationContext,
        ILogger<SendMessageService> logger)
    {
        async public Task<Message> SaveMessageServiceAsync(Message userMessage)
        {
            await applicationContext.Messages.AddAsync(userMessage);
            applicationContext.SaveChanges();
            logger.LogInformation("Save message---> id:{userMessage.Id}, text{userMessage.MessageText}, date:{userMessage.Date}", userMessage.Id, userMessage.MessageText, userMessage.Date);

            return userMessage;
        }
    }
}