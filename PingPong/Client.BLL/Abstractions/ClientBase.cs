namespace Client.BLL.Abstractions
{
    public abstract class ClientBase
    {
        protected readonly int Port;

        protected readonly string Ip;

        public ClientBase(int port, string ip)
        {
            Port = port;
            Ip = ip;
        }

        public abstract void Run();
    }
}
