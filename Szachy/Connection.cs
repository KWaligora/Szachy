using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;

namespace Szachy
{
    public class Connection
    {
        public Connection(bool host)
        {
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            Socket internalSocket;
            byte[] recBuffer = new byte[256];

            serverSocket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1024));
            serverSocket.Listen(1);
            clientSocket.Connect("127.0.0.1", 1024);
            internalSocket = serverSocket.Accept();
            clientSocket.Send(ASCIIEncoding.ASCII.GetBytes("Hello world!"));
            internalSocket.Receive(recBuffer);
            Console.WriteLine(ASCIIEncoding.ASCII.GetString(recBuffer));

            Console.Read();
        }
    }
}
