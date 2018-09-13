using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Szachy
{
    public class Connection
    {
        public bool isHost { get; }
        TcpListener server;
        TcpClient client; // communicate with the server
        public Connection(bool isHost, string ip, short port)
        {
            this.isHost = isHost;
            if (isHost)
            {
                server = new TcpListener(IPAddress.Parse(ip), port);
                server.Start();
                Console.WriteLine("Waiting for connection at: {0} {1}", ip, port);
                client = server.AcceptTcpClient();
                Console.WriteLine("Connected");
            }
            else
            {
                client = new TcpClient();
                Console.WriteLine("Connecting at: {0} {1}", ip, port);
                client.Connect(ip, port);
                if (client.Connected)
                    Console.WriteLine("Connected");
            }
        }

        public void send()
        {
            send("Hello World!\n");
        }

        public void send(string str)
        {
            BinaryWriter writer = new BinaryWriter(client.GetStream());
            Console.WriteLine("Sending: {0}", str);
            writer.Write(str);
        }

        public void receive()
        {
            Console.WriteLine("Waiting for a message");
            BinaryReader reader = new BinaryReader(client.GetStream());
            Console.WriteLine("Received: {0}",reader.ReadString());
        }

        ~Connection()
        {
            client.Close();
        }
    }
}
