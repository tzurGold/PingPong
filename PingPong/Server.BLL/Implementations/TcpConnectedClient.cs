using Server.BLL.Abstraction;
using System.Net.Sockets;

namespace Server.BLL.Implementations
{
    public class TcpConnectedClient : IConnectedClient
    {
        private NetworkStream _stream;

        public TcpConnectedClient(TcpClient client)
        {
            _stream = client.GetStream();
        }

        public byte[] Receive()
        {
            byte[] data = new byte[256];
            _stream.Read(data, 0, data.Length);
            return data;
        }

        public void Send(byte[] data)
        {
            _stream.Write(data, 0, data.Length);
        }
    }
}
