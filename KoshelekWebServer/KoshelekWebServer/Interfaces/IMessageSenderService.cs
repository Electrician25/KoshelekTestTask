using DatabaseLevel.DAL.Entities;

namespace KoshelekWebServer.Interfaces
{
    public interface IMessageSenderService
    {
        public Task<Message> SaveMessageServiceAsync(Message userMessage);
    }
}