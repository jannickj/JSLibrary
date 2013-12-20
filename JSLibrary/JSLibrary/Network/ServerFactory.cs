using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using JSLibrary.Network.Server;
using System.Net.Sockets;

namespace JSLibrary.Network
{
    public class ServerFactory
    {
        public Thread CreateThread(Action start)
        {
            return new Thread(new ParameterizedThreadStart(_ => start()));
        }

        public ConnectedClient CreateClientPoint(TcpClient client)
        {
            return new ConnectedClient(client);
        }

    }
}
