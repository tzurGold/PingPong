namespace Client.BLL.Abstractions
{
    public interface IClientFactory
    {
        ClientBase CreateClient(int port, string ip);
    }
}
