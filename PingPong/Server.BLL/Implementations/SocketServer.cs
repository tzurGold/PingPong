using Server.BLL.Abstraction;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

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
                   DoAction(clientSocket);
                }
            }
            catch(Exception e)
            {

            }
        }


        private async Task DoAction(Socket clientSocket)
        {
            byte[] bytes = new Byte[1024];
            string data;

            try
            {
                while (true)
                {

                    int numByte = clientSocket.Receive(bytes);

                    data = Encoding.ASCII.GetString(bytes,
                                               0, numByte);

                    Console.WriteLine("Received: {0}", data);

                    byte[] message = Encoding.ASCII.GetBytes(data);
                    clientSocket.Send(message);
                }
            }
            catch(Exception e)
            {
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
                throw;
            }
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
