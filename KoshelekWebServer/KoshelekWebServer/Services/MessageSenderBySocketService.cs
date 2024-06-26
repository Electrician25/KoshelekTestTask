﻿using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;

namespace KoshelekWebServer.Services
{
    public class MessageSenderBySocketService(ILogger<MessageSenderBySocketService> logger)
    {
        private static ConcurrentBag<WebSocket> _sockets = new();

        async public Task ReceiveMessages(WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];

            _sockets.Add(webSocket);

            logger.LogInformation("SendMessageToClientBySocketsService---> Listening...");

            await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
        }

        public static async Task BroadcastMessage(string message)
        {
            var messageBuffer = Encoding.UTF8.GetBytes(message);

            var tasks = _sockets.Select(async socket =>
            {
                if (socket.State == WebSocketState.Open)
                {
                    await socket.SendAsync
                    (
                        new ArraySegment<byte>(messageBuffer, 0, messageBuffer.Length),
                        WebSocketMessageType.Text, true, CancellationToken.None
                    );
                }
            });

            await Task.WhenAll(tasks);
        }
    }
}