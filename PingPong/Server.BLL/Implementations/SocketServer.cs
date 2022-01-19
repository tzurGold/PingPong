using Server.BLL.Abstraction;

namespace Server.BLL.Implementations
{
    public class SocketServer : ServerBase
    {
        public SocketServer(int port) : base(port)
        {
        }

        public override void Run()
        {
            throw new System.NotImplementedException();
        }

        protected override void Connect()
        {
            throw new System.NotImplementedException();
        }

        protected override void DoAction()
        {
            throw new System.NotImplementedException();
        }

        protected override void Listen()
        {
            throw new System.NotImplementedException();
        }
    }
}
