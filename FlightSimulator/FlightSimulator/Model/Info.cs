using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    // singleton
    public sealed class Info
    {
        private TcpListener server;
        private TcpClient client;
        private BinaryReader reader;
        private IPEndPoint ep;
        private bool clientConnected;
        private ISettingsModel _settings;
        private static Info _instance;
        private static readonly object padLock = new object();
        public static Info Instance {
            get
            {
                // thread safety.
                lock (padLock)
                {
                    if (_instance == null)
                        _instance = new Info();
                    return _instance;
                }
            }
    }
        public Info()
        {
             ep = new IPEndPoint(IPAddress.Parse(_settings.FlightServerIP), _settings.FlightInfoPort);
            _settings = ApplicationSettingsModel.Instance;
            clientConnected = false;
        }
        public void closeServer()
        {
            clientConnected = false;
            client.Close();
            server.Stop();
        }

        public void openServer()
        {
            // not sure here check this !!!!!!!!!!!!!111.
            if (server != null) closeServer();
            server = new TcpListener(ep);
            server.Start();
        }

        public string[] listen()
        {
            if (!clientConnected)
            {
                client = server.AcceptTcpClient();
                reader = new BinaryReader(client.GetStream());
                clientConnected = true;
            }

            // read the data here !!!
        }
}
