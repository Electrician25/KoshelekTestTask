using DatabaseLevel.DAL.Entities;
using KoshelekWebServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace KoshelekWebServer.Controllers
{
    [ApiController]
    [Route("/api/{controller}/")]
    public class GetMessagesByDateController(
        GetMessagesByDateService getMessagesByDateService,
        ILogger<GetMessagesByDateService> logger)
        : ControllerBase
    {
        [Route("Date")]
        async public Task<Message[]> GetMessageByDateAsync(string dateTime)
        {
            logger.LogInformation("Request---> find message by date {DateTime}", dateTime);

            return await getMessagesByDateService.GetMessagesByDateServiceAsync(dateTime);
        }
    }
}