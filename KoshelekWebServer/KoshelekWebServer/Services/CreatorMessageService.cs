using DatabaseLevel.DAL.Entities;
using KoshelekWebServer.Interfaces;

namespace KoshelekWebServer.Services
{
    public class CreatorMessageService(ILogger<CreatorMessageService> logger) : ICreatorMessageService
    {
        public string GetMessage(Message message)
        {
            var text = message.MessageText;
            var date = message.Date;

            var resultMessage = $"MESSAGE={text} DATE={date}";
            logger.LogInformation("Create message---> " +
                "DATE: {date}, MESSAGETEXT: {text}, FULLMESSAGE:{resultMessage}",
                date, text, resultMessage);

            return resultMessage;
        }
    }
}