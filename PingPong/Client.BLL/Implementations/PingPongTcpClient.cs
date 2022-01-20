using Client.BLL.Abstractions;
using System;
using System.Net.Sockets;

namespace Client.BLL.Implementations
{
    public class PingPongTcpClient : ClientBase
    {
        public PingPongTcpClient(int port, string ip) : base(port, ip)
        {

        }

        public override void Run()
        {
            TcpClient client = new TcpClient(Ip, Port);

            byte[] data = System.Text.Encoding.ASCII.GetBytes(Console.ReadLine());

            NetworkStream stream = client.GetStream();

            stream.Write(data, 0, data.Length);

            data = new Byte[256];

            int bytes = stream.Read(data, 0, data.Length);
            string responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            Console.WriteLine("Received: {0}", responseData);

            stream.Close();
            client.Close();
        }
    }
}
