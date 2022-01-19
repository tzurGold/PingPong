using Server.BLL.Abstraction;
using System;
using System.Net;
using System.Net.Sockets;

namespace Server.BLL.Implementations
{
    public class SocketServer : ServerBase
    {
        public SocketServer(int port) : base(port)
        {

        }

        public override void Run()
        {
            try
            {
                Socket listener = Listen();
                while (true)
                {
                    Socket clientSocket = listener.Accept();
                }
            }
            catch(Exception e)
            {

            }
        }

        private void Connect()
        {
            throw new System.NotImplementedException();
        }

        private void DoAction()
        {
            throw new System.NotImplementedException();
        }

        private Socket Listen()
        {
            try
            {
                IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddr = ipHost.AddressList[0];
                IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 11111);
                Socket listener = new Socket(ipAddr.AddressFamily,
                             SocketType.Stream, ProtocolType.Tcp);

                listener.Bind(localEndPoint);

                listener.Listen(10);

                return listener;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
