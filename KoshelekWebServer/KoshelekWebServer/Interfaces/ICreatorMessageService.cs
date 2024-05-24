using DatabaseLevel.DAL.Entities;

namespace KoshelekWebServer.Interfaces
{
    public interface ICreatorMessageService
    {
        public string GetMessage(Message message);
    }
}