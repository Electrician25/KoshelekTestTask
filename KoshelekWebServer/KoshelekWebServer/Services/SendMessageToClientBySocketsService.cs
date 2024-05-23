﻿using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;

namespace KoshelekWebServer.Services
{
    public class SendMessageToClientBySocketsService
    {
        private static ConcurrentBag<WebSocket> _sockets = new ConcurrentBag<WebSocket>();

        public async Task ReceiveMessages(WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            _sockets.Add(webSocket);
            WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

            while (!result.CloseStatus.HasValue)
            {
                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            }
            _sockets = new ConcurrentBag<WebSocket>(_sockets.Except(new[] { webSocket }));

            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
        }

        public static async Task BroadcastMessage(string message)
        {
            var messageBuffer = Encoding.UTF8.GetBytes(message);

            var tasks = _sockets.Select(async socket =>
            {
                if (socket.State == WebSocketState.Open)
                {
                    await socket.SendAsync(new ArraySegment<byte>(messageBuffer, 0, messageBuffer.Length), WebSocketMessageType.Text, true, CancellationToken.None);
                }
            });

            await Task.WhenAll(tasks);
        }
    }
}