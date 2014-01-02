using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace JSLibrary.Network.Server
{
    public class ClientConnector
    {


        public virtual void Start()
        {
            
        }

        public TcpClient Client { get; set; }

        public IPAddress IP { get; set; }
    }
}
