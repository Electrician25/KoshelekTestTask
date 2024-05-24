using DatabaseLevel.DAL.Entities;
using KoshelekWebServer.Services;
using MessageSenderClient.Services;
using Microsoft.AspNetCore.Mvc;

namespace MessageSenderClient.Controllers
{
    [ApiController]
    [Route("/api/{controller}/")]
    public class MessageSenderController
        (MessageSenderService sendMessageService,
        CreatorMessageService createMessageService,
        ILogger<MessageSenderController> logger)
        : ControllerBase
    {
        [HttpPost("Send")]
        async public Task<Message> SendMessageAsync([FromBody] Message message)
        {
            logger.LogInformation("Request---> send message by web-sockets {message}", message.MessageText);

            message.Date = DateTime.UtcNow;
            await MessageSenderBySocketService.BroadcastMessage(createMessageService.GetMessage(message));

            return await sendMessageService.SaveMessageServiceAsync(message);
        }
    }
}