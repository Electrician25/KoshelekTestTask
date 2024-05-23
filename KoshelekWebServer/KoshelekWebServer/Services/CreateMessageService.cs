using DatabaseLevel.DAL.Entities;

namespace KoshelekWebServer.Services
{
    public class CreateMessageService
    {
        public string GetMessage(Message message)
        {
            var text = message.MessageText;
            var date = message.Date;
            var resultMessage = $"MESSAGE={text} DATE={date}";

            return resultMessage;
        }
    }
}