using DatabaseLevel.DAL.Entities;

namespace KoshelekWebServer.Interfaces
{
    public interface IMessageByDateService
    {
        public Task<Message[]> GetMessagesByDateServiceAsync(DateTime date);
    }
}