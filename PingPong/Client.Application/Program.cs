namespace Client.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Bootstrapper bootstrapper = new Bootstrapper();

            ServerBase server = bootstrapper.Initialize();

            server?.Run();
        }
    }
}
