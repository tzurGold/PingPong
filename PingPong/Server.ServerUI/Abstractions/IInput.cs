namespace Server.ServerUI.Abstractions
{
    public interface IInput<T>
    {
        T ReadLine();
    }
}
