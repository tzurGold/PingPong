namespace Server.BLL.Abstraction
{
    public interface IServerFactory
    {
        ServerBase CreateServer(int port);
    }
}
