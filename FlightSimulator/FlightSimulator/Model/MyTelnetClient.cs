using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class MyTelnetClient : TelnetClient
    {
        private TcpClient client;
        public void connect(string ip, int port)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
            client = new TcpClient(ep);
            client.Connect(ep);
        }

        public void disconnect()
        {
            client.Close();
        }

        public string read()
        {
            throw new NotImplementedException();
        }

        public void write(string command)
        {
            throw new NotImplementedException();
        }
    }
}
