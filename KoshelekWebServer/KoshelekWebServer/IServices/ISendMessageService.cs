using DatabaseLevel.DAL.Entities;

namespace KoshelekWebServer.IServices
{
    public interface ISendMessageService
    {
        public Task<Message> SendMessageServiceAsync(Message userMessage);
    }
}