using Client.BLL.Abstractions;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client.BLL.Implementations
{
    class SocketClient : ClientBase
    {
        public SocketClient(int port, string ip) : base(port, ip)
        {
        }

        public override void Run()
        {
            IPAddress ipAddr = IPAddress.Parse(Ip);
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, Port);

            Socket sender = new Socket(ipAddr.AddressFamily,
                   SocketType.Stream, ProtocolType.Tcp);
            try
            {
                sender.Connect(localEndPoint);
                CommunicateWithServer(sender);
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();
            }
            catch(SocketException e)
            {
                
            }
            catch(Exception e)
            {

            }
        }

        private void CommunicateWithServer(Socket sender)
        {
            try
            {
                while(true)
                {
                    byte[] messageSent = Encoding.ASCII.GetBytes(Console.ReadLine());
                    int byteSent = sender.Send(messageSent);
                    byte[] messageReceived = new byte[1024];
                    int byteRecv = sender.Receive(messageReceived);
                    Console.WriteLine("Message from Server -> {0}",
                          Encoding.ASCII.GetString(messageReceived,
                                                     0, byteRecv));
                }
            }
            catch(Exception e)
            {
                throw;
            }
        }
    }
}
