#region

using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;

#endregion

namespace Framework.Network
{
    public class Client
    {
        public delegate void DataReceivedDelegate(byte[] data);

        public event DataReceivedDelegate DataReceived;

        private readonly byte[] _buffer = new byte[4096];
        private readonly Socket _client;

        public Client(IPAddress ip, int port)
        {
            _client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
           // _client.BeginConnect(ip, port, OnConnect, this);
        }

        public Client(Socket client)
        {
            _client = client;
        }

        protected virtual void OnDataReceived(byte[] data)
        {
            if (DataReceived != null) 
                DataReceived(data);
        }

        public void Start()
        {
            Read();
        }

        public void Send(byte[] data)
        {
            try
            {
                if (_client.Connected)
                    _client.BeginSend(data, 0, data.Length, 0, OnSend, this);
            }
            catch
            {
            }
        }

        private void OnSend(IAsyncResult ar)
        {
            try
            {
                _client.EndReceive(ar);
            }
            catch
            {
                Close();
            }
        }

        private void Read()
        {
            if (_client.Connected)
                _client.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, OnReceive, this);
        }

        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                var bytesRead = _client.EndReceive(ar);
                if (bytesRead <= 0)
                {
                    Close();
                    return;
                }

                OnDataReceived(_buffer.Take(bytesRead).ToArray());

                if (_client.Connected)
                    Read();
            }
            catch
            {
                Close();
            }
        }

        public void Close()
        {
            try
            {
                if (_client.Connected)
                    _client.BeginDisconnect(true, OnDisconnect, this);
            }
            catch
            {
            }
        }

        private void OnDisconnect(IAsyncResult ar)
        {
            try
            {
                _client.EndDisconnect(ar);
            }
            catch
            {
            }
        }
    }
}