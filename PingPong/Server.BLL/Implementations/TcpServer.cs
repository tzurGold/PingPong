using Common.DTOs;
using Server.BLL.Abstraction;
using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace Server.BLL.Implementations
{
    public class TcpServer : ServerBase
    {

        private TcpListener _listener;

        public TcpServer(int port) : base(port)
        {
        }

        public override void Run()
        {
            try
            {
                Listen();
                while (true)
                {
                    TcpClient client = _listener.AcceptTcpClient();
                    Task.Run(() => DoAction(client));
                }
            }
            catch (Exception e)
            {

            }
        }

        protected override void Listen()
        {
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            _listener = new TcpListener(localAddr, Port);
            _listener.Start();
        }

        private void DoAction(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            IFormatter formatter = new BinaryFormatter();

            Person p = (Person)formatter.Deserialize(stream);

            Console.WriteLine(p);

            byte[] data = new byte[256];
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
            formatter.Serialize(memoryStream, p);
            data = memoryStream.ToArray();

        }
    }
}
