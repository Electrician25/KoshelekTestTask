using KoshelekWebServer.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace KoshelekWebServer.Controllers
{
    [ApiController]
    [Route("/api/{controller}/")]
    public class MessageSenderBySocketController(
        MessageSenderBySocketService sendMessageToClientBySocketsService,
        ILogger<MessageSenderBySocketController> logger)
        : ControllerBase
    {
        [Route("ws")]
        async public Task ListenWeb()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                WebSocket webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                logger.LogInformation("Listen---> client by {webSocket}, webSocket state: {webSocke}", webSocket, webSocket.State);
                await sendMessageToClientBySocketsService.ReceiveMessages(webSocket);
            }
            else
            {
                var response = HttpContext.Response.StatusCode = 400;
                logger.LogInformation("Listen end, status code: {response}", response);
            }
        }
    }
}