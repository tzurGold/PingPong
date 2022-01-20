using Common.DTOs;
using Server.BLL.Abstraction;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Server.BLL.Implementations
{
    public class TcpServerAction : IAction
    {
        public void Execute(IConnectedClient connectedClient)
        {
            IFormatter formatter = new BinaryFormatter();
            Person p = (Person)formatter.Deserialize(new MemoryStream(connectedClient.Receive()));
            Console.WriteLine(p);

            MemoryStream memoryStream = new MemoryStream();
            formatter.Serialize(memoryStream, p);
            byte[] data = memoryStream.ToArray();
            connectedClient.Send(data);
        }
    }
}
