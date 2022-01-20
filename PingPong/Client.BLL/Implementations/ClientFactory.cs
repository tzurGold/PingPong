using Client.BLL.Abstractions;
using UI.Implementations;

namespace Client.BLL.Implementations
{
    public class ClientFactory : IClientFactory
    {
        public ClientBase CreateClient(int port, string ip, NotifyException notifyException)
        {
            return new PingPongTcpClient(port, ip, notifyException);
        }
    }
}
