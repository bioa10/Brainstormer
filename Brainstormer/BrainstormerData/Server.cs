using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BrainstormerData
{
    public class Server
    {
        public Server(IPAddress ip,int port)
        {
            IP = ip;
            Port = port;
            Socket = new TcpListener(IP,Port);
        }

        public void Start()
        {
            Socket.Start();
        }

        public int Port { get; private set; }
        public TcpListener Socket { get; private set; }
        public IPAddress IP { get; private set; }
    }
}
