using Client.BLL.Abstractions;
using UI.Implementations;

namespace Client.BLL.Implementations
{
    public class SocketClientFactory : IClientFactory
    {
        public ClientBase CreateClient(int port, string ip, NotifyException notifyException)
        {
            return new SocketClient(port, ip, notifyException);
        }
    }
}
