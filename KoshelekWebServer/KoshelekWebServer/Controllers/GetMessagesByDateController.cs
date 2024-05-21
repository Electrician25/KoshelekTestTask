using DatabaseLevel.DAL.Entities;
using KoshelekWebServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace KoshelekWebServer.Controllers
{
    [ApiController]
    [Route("/api/{controller}/")]
    public class GetMessagesByDateController(GetMessagesByDateService getMessagesByDateService) : ControllerBase
    {
        [HttpGet("Get")]
        async public Task<Message[]> GetMessageByDateAsync(Message message)
        {
            return await getMessagesByDateService.GetMessagesByDateServiceAsync(message);
        }
    }
}