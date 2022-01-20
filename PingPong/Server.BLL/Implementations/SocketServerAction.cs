using Server.BLL.Abstraction;
using System;
using System.Text;

namespace Server.BLL.Implementations
{
    public class SocketServerAction : IAction
    {
        public void Execute(IConnectedClient connectedClient)
        {
            while (true)
            {
                byte[] bytes = connectedClient.Receive();
                string data = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                Console.WriteLine(data);

                byte[] message = Encoding.ASCII.GetBytes(data);
                connectedClient.Send(message);
            }
        }
    }
}
