#region

using System;
using System.Net;
using System.Net.Sockets;

#endregion

namespace Framework.Network
{
    public class Server
    {
        public delegate void ClientDelegate(Client client);

        private Socket _listener;
        public event ClientDelegate ClientConnected;

        public void Start(IPAddress ip, int port)
        {
            _listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                _listener.Bind(new IPEndPoint(ip, port));
                _listener.Listen(100);
                Listen();
            }
            catch
            {
            }
        }

        private void Listen()
        {
            _listener.BeginAccept(OnAccept, null);
        }

        protected virtual void OnClientConnected(Client client)
        {
            if (ClientConnected != null)
                ClientConnected(client);
        }

        private void OnAccept(IAsyncResult ar)
        {
            try
            {
                var sock = _listener.EndAccept(ar);
                var client = new Client(sock);
                OnClientConnected(client);
            }
            catch
            {
            }

            Listen();
        }

        public void Stop()
        {
            _listener.Close();
        }
    }
}