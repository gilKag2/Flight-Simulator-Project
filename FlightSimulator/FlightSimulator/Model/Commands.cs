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
    //singleton.
    public sealed class Commands
    {
        private TcpClient _client;
        private BinaryWriter _writer;
        private ISettingsModel _settings;
        private static Commands _instance = null;
        private static readonly object padLock = new object();
        public static Commands Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Commands();
                return _instance;
            }
        }
        public Commands()
        {
            _settings = ApplicationSettingsModel.Instance;
        }
        public void Connect()
        {
            _client = new TcpClient();

            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(_settings.FlightServerIP), _settings.FlightCommandPort);
            while (!_client.Connected)
            {
                try
                {
                    _client.Connect(ep);
                } catch (Exception) { }
            }
        }


    }
}
