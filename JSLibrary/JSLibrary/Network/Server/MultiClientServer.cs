﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace JSLibrary.Network.Server
{
    public abstract class MultiClientServer
    {

        private ServerFactory tFactory;
        private TcpListener listener;

        public MultiClientServer(ServerFactory tFactory, TcpListener listener)
        {
            this.tFactory = tFactory;
            this.listener = listener;
        }


        public void Start()
        {
            TcpClient client = listener.AcceptTcpClient();
            ClientConnector cc = CreateConnector();
            cc.Client = client;
            tFactory.CreateThread(cc.Start);
        }

        public abstract ClientConnector CreateConnector();
    }
}
