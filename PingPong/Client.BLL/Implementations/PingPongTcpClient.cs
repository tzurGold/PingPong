using Client.BLL.Abstractions;
using Common.DTOs;
using System;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

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

            IFormatter formatter = new BinaryFormatter();

            NetworkStream stream = client.GetStream();

            formatter.Serialize(stream, new Person("T", 18));

            Person p = (Person)formatter.Deserialize(stream);

            Console.WriteLine("Received: {0}", p);

            stream.Close();
            client.Close();
        }
    }
}
