using DatabaseLevel.DAL.Entities;
using KoshelekWebServer.Services;
using MessageSenderClient.Services;
using Microsoft.AspNetCore.Mvc;

namespace MessageSenderClient.Controllers
{
    [ApiController]
    [Route("/api/{controller}/")]
    public class SendMessageController(SendMessageService sendMessageService,
        CreateMessageService createMessageService) : ControllerBase
    {
        [HttpPost("Send")]
        async public Task<Message> SendMessageAsync([FromBody] Message message)
        {
            message.Date = DateTime.UtcNow;
            await SendMessageToClientBySocketsService.BroadcastMessage(createMessageService.GetMessage(message));

            return await sendMessageService.SendMessageServiceAsync(message);
        }
    }
}