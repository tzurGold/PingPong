using Server.BLL.Abstraction;

namespace Server.BLL.Implementations
{
    public class ServerFactory : IServerFactory
    {
        public ServerBase CreateServer(int port)
        {
            return new SocketServer(port);
        }
    }
}
