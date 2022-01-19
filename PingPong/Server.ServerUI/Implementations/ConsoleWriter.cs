using Server.ServerUI.Abstractions;
using System;

namespace Server.ServerUI.Implementations
{
    public class ConsoleWriter : IOutput<string>
    {
        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }
    }
}
