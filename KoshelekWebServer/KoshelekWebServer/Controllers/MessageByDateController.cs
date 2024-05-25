using DatabaseLevel.DAL.Entities;
using KoshelekWebServer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KoshelekWebServer.Controllers
{
    [ApiController]
    [Route("/api/{controller}/")]
    public class MessageByDateController(
        IMessageByDateService getMessagesByDateService,
        ILogger<MessageByDateController> logger)
        : ControllerBase
    {
        [Route("Date")]
        async public Task<Message[]> GetMessageByDateAsync(DateTime dateTime)
        {
            logger.LogInformation("Request---> find message by date {DateTime}", dateTime);

            return await getMessagesByDateService.GetMessagesByDateServiceAsync(dateTime);
        }
    }
}