using Client.BLL.Abstractions;
using Client.BLL.Implementations;
using System;

namespace Client.Application
{
    public class Bootstrapper
    {
        private const int _minPort = 0;
        private const int _maxPort = 65536;

        public ClientBase Initialize()
        {
            IClientFactory clientFactory = new ClientFactory();
            int port = 0;
            string ip = string.Empty;
            while(port < _minPort || port > _maxPort)
            {
                Console.WriteLine("Enter ip:port");
                string input = Console.ReadLine();
                ip = input.Substring(0, input.IndexOf(":"));
                port = int.Parse(input.Substring(input.IndexOf(":") + 1));
            }
            return clientFactory.CreateClient(port, ip); 
        }
    }
}
