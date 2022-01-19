namespace Server.BLL.Abstraction
{
    public abstract class ServerBase
    {
        protected readonly int Port;

        public ServerBase(int port)
        {
            Port = port;
        }

        public abstract void Run();

        protected abstract void Listen();

        protected abstract void Connect();

        protected abstract void DoAction();
    }
}
