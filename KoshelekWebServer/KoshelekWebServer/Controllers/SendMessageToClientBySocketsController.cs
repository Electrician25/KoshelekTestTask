using KoshelekWebServer.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace KoshelekWebServer.Controllers
{
    [ApiController]
    [Route("/api/{controller}/")]
    public class SendMessageToClientBySocketsController(SendMessageToClientBySocketsService sendMessageToClientBySocketsService) : ControllerBase
    {
        [Route("ws")]
        async public Task ListenWeb()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                WebSocket webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                await sendMessageToClientBySocketsService.ReceiveMessages(webSocket);
            }
            else
            {
                HttpContext.Response.StatusCode = 400;
            }
        }
    }
}