using Server.BLL.Abstraction;
using System;
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
                    Task.Run(() => DoAction(clientSocket));
                }
            }
            catch(Exception e)
            {

            }
        }


        private void DoAction(Socket clientSocket)
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
                IPAddress ipAddr = IPAddress.Parse("127.0.0.1");
                IPEndPoint localEndPoint = new IPEndPoint(ipAddr, Port);
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
