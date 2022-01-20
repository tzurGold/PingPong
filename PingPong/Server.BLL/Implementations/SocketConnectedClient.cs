using Server.BLL.Abstraction;
using System.Linq;
using System.Net.Sockets;

namespace Server.BLL.Implementations
{
    public class SocketConnectedClient : IConnectedClient
    {
        private Socket _clientSocket;

        public SocketConnectedClient(Socket clientSocket)
        {
            _clientSocket = clientSocket;
        }

        public byte[] Receive()
        {
            byte[] bytes = new byte[1024];
            int numByte = _clientSocket.Receive(bytes);
            return bytes.Take(numByte).ToArray();
        }

        public void Send(byte[] data)
        {
            _clientSocket.Send(data);
        }
    }
}
