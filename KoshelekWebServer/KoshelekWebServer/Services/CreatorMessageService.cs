using DatabaseLevel.DAL.Entities;
using KoshelekWebServer.Exceptions;
using KoshelekWebServer.Interfaces;

namespace KoshelekWebServer.Services
{
    public class CreatorMessageService(ILogger<CreatorMessageService> logger) : ICreatorMessageService
    {
        public string GetMessage(Message message)
        {
            var text = message.MessageText;

            if (text.Length > 128)
            {
                logger.LogInformation("Error length meessage");
                throw new MessageToLargeException("Message have more 128 chars");
            }

            var date = message.Date;

            var resultMessage = $"MESSAGE={text} DATE={date}";

            logger.LogInformation("Create message---> " +
                "DATE: {date}, MESSAGETEXT: {text}, FULLMESSAGE:{resultMessage}",
                date, text, resultMessage);

            return resultMessage;
        }
    }
}