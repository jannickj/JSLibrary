using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace JSLibrary.Network.Server
{
    public class ConnectedClient
    {
        private System.Net.Sockets.TcpClient client;

        public ConnectedClient(TcpClient client)
        {
            // TODO: Complete member initialization
            this.client = client;
        }

        public virtual void Start()
        {

        }
    }
}
