using UI.Abstractions;

namespace UI.Implementations
{
    public class NotifyException
    {
        private IOutput<string> writer;

        public void Notify(string message)
        {
            writer.WriteLine(message);
        }
    }
}
