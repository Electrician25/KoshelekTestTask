using DatabaseLevel.DAL.Entities;
using DatabaseLevel.DAL.EntityFramework;

namespace MessageSenderClient.Services
{
    public class SendMessageService(ApplicationContext applicationContext)
    {
        async public Task<Message> SendMessageServiceAsync(Message userMessage)
        {
            userMessage.Date = DateTime.UtcNow;
            await applicationContext.Messages.AddAsync(userMessage);
            applicationContext.SaveChanges();

            return userMessage;
        }
    }
}