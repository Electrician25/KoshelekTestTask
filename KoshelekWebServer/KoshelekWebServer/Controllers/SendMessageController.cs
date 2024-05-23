using DatabaseLevel.DAL.Entities;
using KoshelekWebServer.Services;
using MessageSenderClient.Services;
using Microsoft.AspNetCore.Mvc;

namespace MessageSenderClient.Controllers
{
    [ApiController]
    [Route("/api/{controller}/")]
    public class SendMessageController(SendMessageService sendMessageService) : ControllerBase
    {
        [HttpPost("Send")]
        async public Task<Message> SendMessageAsync([FromBody] Message message)
        {
            await SendMessageToClientBySocketsService.BroadcastMessage(message.MessageText);
            return await sendMessageService.SendMessageServiceAsync(message);
        }
    }
}