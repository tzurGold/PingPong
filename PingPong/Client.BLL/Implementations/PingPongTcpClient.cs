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
        private TcpClient _client;

        public PingPongTcpClient(int port, string ip) : base(port, ip)
        {
            _client = new TcpClient();
        }

        public override void CommunicateWithServer()
        {
            IFormatter formatter = new BinaryFormatter();
            NetworkStream stream = null;
            try
            { 
                stream = _client.GetStream();

                while(true)
                {
                    formatter.Serialize(stream, new Person("T", 18));

                    Person p = (Person)formatter.Deserialize(stream);

                    Console.WriteLine("Received: {0}", p);
                }
            }
            catch (Exception e)
            {

            }
            finally
            {
                stream.Close();
            }
        }

        public override void Connect()
        {
            _client.Connect(Ip, Port);
        }

        public override void CloseConnection()
        {
            _client.Close();
        }
    }
}
