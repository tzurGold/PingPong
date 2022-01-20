using Client.BLL.Abstractions;

namespace Client.BLL.Implementations
{
    public class PingPongTcpClient : ClientBase
    {
        public PingPongTcpClient(int port, string ip) : base(port, ip)
        {

        }

        public override void Run()
        {
            
        }
    }
}
