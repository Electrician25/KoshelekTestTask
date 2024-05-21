using DatabaseLevel.DAL.Entities;

namespace KoshelekWebServer.IServices
{
    public interface IGetMessagesByDateService
    {
        public Task<Message[]> GetMessagesByDateServiceAsync(Message message);
    }
}