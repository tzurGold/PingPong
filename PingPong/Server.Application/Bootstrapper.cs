using Server.BLL.Abstraction;
using Server.BLL.Implementations;
using System;

namespace Server.Application
{
    public class Bootstrapper
    {
        private readonly string[] _args;
        private const int _minPort = 0;
        private const int _maxPort = 65536;

        public Bootstrapper(string[] args)
        {
            _args = args;
        }

        public ServerBase Initialize()
        {
            IServerFactory serverFactory = new ServerFactory();
            int port = 0;
            if(_args.Length != 1 || !int.TryParse(_args[0], out port) || port < _minPort || port > _maxPort)
            {
                Console.WriteLine("Invalid port entered");
                return null;
            }
            return serverFactory.CreateServer(port); 
        }
    }
}
