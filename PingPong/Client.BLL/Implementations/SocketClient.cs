using Client.BLL.Abstractions;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client.BLL.Implementations
{
    class SocketClient : ClientBase
    {
        private Socket _sender;

        public SocketClient(int port, string ip) : base(port, ip)
        {

        }

        public override void CloseConnection()
        {
            _sender.Close();
        }

        public override void CommunicateWithServer()
        {
            try
            {
                while (true)
                {
                    byte[] messageSent = Encoding.ASCII.GetBytes(Console.ReadLine());
                    int byteSent = _sender.Send(messageSent);
                    byte[] messageReceived = new byte[1024];
                    int byteRecv = _sender.Receive(messageReceived);
                    Console.WriteLine("Message from Server -> {0}",
                          Encoding.ASCII.GetString(messageReceived,
                                                     0, byteRecv));
                }
            }
            catch (Exception e)
            {
                
            }
            finally
            {
                _sender.Shutdown(SocketShutdown.Both);
            }
        }

        public override void Connect()
        {
            IPAddress ipAddr = IPAddress.Parse(Ip);
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, Port);

            _sender = new Socket(ipAddr.AddressFamily,
                   SocketType.Stream, ProtocolType.Tcp);

            _sender.Connect(localEndPoint);
        }
    }
}
