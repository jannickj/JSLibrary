using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace JSLibrary.Network.Server
{
    public class ClientConnector
    {


        public virtual void Start()
        {

        }

        public TcpClient Client { get; set; }
    }
}
