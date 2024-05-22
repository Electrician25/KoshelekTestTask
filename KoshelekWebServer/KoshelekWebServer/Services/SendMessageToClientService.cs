using System.Net;
using System.Net.Sockets;
using System.Text;

namespace KoshelekWebServer.Services
{
    public class SendMessageToClientService
    {
        private const int port = 8080;
        private const string adres = "127.0.0.1";
        private static List<Socket> clients = new();
        private static IPAddress apiAdres = IPAddress.Parse(adres);
        private static TcpListener tcpListener = new(apiAdres, port);

        async public Task SendMessageToClientAsync(string message)
        {
            tcpListener.Start();
            while (true)
            {
                Socket client = tcpListener.AcceptSocket();
                if (client.Connected)
                {
                    clients.Add(client);
                    Thread nuevoHilo = new Thread(() => Listeners(client));
                    nuevoHilo.Start();
                }
            }
        }

        private static void Listeners(Socket client)
        {
            Console.WriteLine("Client:" + client.RemoteEndPoint + " now connected to server.");
            NetworkStream stream = new NetworkStream(client);

            while (true)
            {
                while (!stream.DataAvailable) ;
                while (client.Available < 3) ; // match against "get"

                byte[] bytes = new byte[client.Available];
                stream.Read(bytes, 0, bytes.Length);
                string s = Encoding.UTF8.GetString(bytes);
            }
        }

    }
}