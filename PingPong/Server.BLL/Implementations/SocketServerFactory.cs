using Server.BLL.Abstraction;
using UI.Implementations;

namespace Server.BLL.Implementations
{
    public class SocketServerFactory : IServerFactory
    {
        public ServerBase CreateServer(int port, NotifyException notifyException, IAction action)
        {
            return new SocketServer(port, notifyException, action);
        }
    }
}
