using Server.BLL.Abstraction;

namespace Server.BLL.Implementations
{
    public class SocketServerFactory : IServerFactory
    {
        public ServerBase CreateServer(int port)
        {
            return new SocketServer(port);
        }
    }
}
