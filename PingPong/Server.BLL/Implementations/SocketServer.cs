using Server.BLL.Abstraction;
using System;
using System.Net;
using System.Net.Sockets;
using UI.Implementations;

namespace Server.BLL.Implementations
{
    public class SocketServer : ServerBase
    {

        private Socket _listener;

        public SocketServer(int port, NotifyException notifyException, IAction action)
            : base(port, notifyException, action)
        {

        }

        protected override void CloseConnection()
        {
            _listener.Close();
        }

        protected override IConnectedClient Connect()
        {
            Socket clientSocket = _listener.Accept();
            return new SocketConnectedClient(clientSocket);
        }

        protected override void Listen()
        {
            try
            {
                IPAddress ipAddr = IPAddress.Parse("127.0.0.1");
                IPEndPoint localEndPoint = new IPEndPoint(ipAddr, Port);
                _listener = new Socket(ipAddr.AddressFamily,
                             SocketType.Stream, ProtocolType.Tcp);

                _listener.Bind(localEndPoint);

                _listener.Listen(10);
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                _listener.Close();
            }
        }
    }
}
