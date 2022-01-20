using Client.BLL.Abstractions;

namespace Client.BLL.Implementations
{
    public class ClientFactory : IClientFactory
    {
        public ClientBase CreateClient(int port, string ip)
        {
            return new PingPongTcpClient(port, ip);
        }
    }
}
