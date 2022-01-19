using Server.ServerUI.Abstractions;
using System;

namespace Server.ServerUI.Implementations
{
    public class ConsoleReader : IInput<string>
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
