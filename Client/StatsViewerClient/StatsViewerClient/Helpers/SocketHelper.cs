using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace Client_Lab1_PRN222.Helpers
{
    internal class SocketHelper
    {
        private const string SERVER_IP = "127.0.0.1";
        private const int SERVER_PORT = 9000;

        public static T SendRequest<T>(object request)
        {
            using TcpClient client = new TcpClient();
            client.Connect(SERVER_IP, SERVER_PORT);

            using NetworkStream stream = client.GetStream();

            string jsonRequest = JsonSerializer.Serialize(request);
            byte[] sendData = Encoding.UTF8.GetBytes(jsonRequest);

            stream.Write(sendData, 0, sendData.Length);
            stream.Flush();

            client.Client.Shutdown(SocketShutdown.Send);

            using MemoryStream ms = new MemoryStream();
            byte[] buffer = new byte[4096];
            int bytesRead;
            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                ms.Write(buffer, 0, bytesRead);
            }

            if (ms.Length == 0)
                throw new Exception("Server closed connection without response");

            string jsonResponse = Encoding.UTF8.GetString(ms.ToArray());

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<T>(jsonResponse, options)
                   ?? throw new Exception("Invalid server response");
        }
    }
}