using DatabaseLevel.DAL.Entities;
using MessageSenderClient.Services;
using Microsoft.AspNetCore.Mvc;

namespace MessageSenderClient.Controllers
{
    [ApiController]
    [Route("/api/{controller}/")]
    public class SendMessageController(SendMessageService sendMessageService) : ControllerBase
    {
        [HttpPost("Send")]
        async public Task<Message> SendMessageAsync(Message message)
        {
            return await sendMessageService.SendMessageServiceAsync(message);
        }
    }
}