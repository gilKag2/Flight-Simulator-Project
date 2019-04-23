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
    public sealed class Info
    {
        private TcpListener server;
        private TcpClient client;
        private BinaryReader reader;
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
            _settings = ApplicationSettingsModel.Instance;
        }
        public void closeServer()
        {
            client.Close();
            server.Stop();
        }

        public void openServer()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(_settings.FlightServerIP), _settings.FlightInfoPort);
            if (server != null) closeServer();
            server = new TcpListener(ep);
            server.Start();
        }
}
