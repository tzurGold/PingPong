using System;

namespace Client.BLL.Abstractions
{
    public abstract class ClientBase
    {
        protected readonly int Port;

        protected readonly string Ip;

        public ClientBase(int port, string ip)
        {
            Port = port;
            Ip = ip;
        }

        public abstract void Connect();

        public abstract void CommunicateWithServer();

        public abstract void CloseConnection();

        public void Run()
        {
            try
            {
                Connect();
                CommunicateWithServer();
                CloseConnection();
            }
            catch (Exception e)
            {

            }
        }
    }
}
