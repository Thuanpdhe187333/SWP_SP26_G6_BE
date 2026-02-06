using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;

namespace StatsDataServer.Network
{
    public class SocketServer
    {
        public static void Start()
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 9000);
            listener.Start();

            while (true)
            {
                Socket client = listener.AcceptSocket();
                byte[] buffer = new byte[2048];
                int len = client.Receive(buffer);

                string request = Encoding.UTF8.GetString(buffer, 0, len);

                Console.WriteLine("Client: " + request);

                client.Send(Encoding.UTF8.GetBytes("Data from SQL Server"));
            }
        }
    }
}
