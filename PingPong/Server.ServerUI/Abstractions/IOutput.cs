namespace Server.ServerUI.Abstractions
{
    public interface IOutput<T>
    {
        void WriteLine(T output);
    }
}
