using DatabaseLevel.DAL.Entities;
using DatabaseLevel.DAL.EntityFramework;

namespace MessageSenderClient.Services
{
    public class SendMessageService(ApplicationContext applicationContext)
    {
        async public Task<Message> SendMessageServiceAsync(Message userMessage)
        {
            await applicationContext.Messages.AddAsync(userMessage);
            applicationContext.SaveChanges();

            return userMessage;
        }
    }
}