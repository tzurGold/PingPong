using System;

namespace Server.UI
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

        public void Initialize()
        {
            int port = 0;
            if(!int.TryParse(_args[1], out port) || port < _minPort || port > _maxPort)
            {
                Console.WriteLine("Invalid port entered");
                //return null
            }
            //return new 
        }
    }
}
