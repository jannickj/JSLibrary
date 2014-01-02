using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace JSLibrary.Network.Server
{
    public abstract class MultiClientServer
    {
        private Dictionary<IPAddress, ClientConnector> connectionLookup = new Dictionary<IPAddress, ClientConnector>();
        private ServerFactory tFactory;
        private TcpListener listener;

        public MultiClientServer(ServerFactory tFactory, TcpListener listener)
        {
            this.tFactory = tFactory;
            this.listener = listener;
        }


        public void Start()
        {
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                ClientConnector cc = CreateConnector();
                cc.Client = client;
                
                var thread = tFactory.CreateThread(cc.Start);
                var ipadd = ((IPEndPoint)client.Client.RemoteEndPoint).Address;
                cc.IP = ipadd;
                lock (this)
                {
                    connectionLookup.Add(ipadd, cc);
                }
                thread.Start();
            }
        }

        public abstract ClientConnector CreateConnector();
    }
}
