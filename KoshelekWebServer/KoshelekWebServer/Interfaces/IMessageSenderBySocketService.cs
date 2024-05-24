using System.Net.WebSockets;

namespace KoshelekWebServer.Interfaces
{
    public interface IMessageSenderBySocketService
    {
        public Task ReceiveMessages(WebSocket webSocket);
    }
}