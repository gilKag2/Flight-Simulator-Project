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
        IPEndPoint ep;
        private static Commands _instance = null;
        private static readonly object padLock = new object();
        public static Commands Instance
        {
            get
            {
                lock (padLock)
                {
                    if (_instance == null)
                        _instance = new Commands();
                    return _instance;
                }
            }
        }
        public Commands()
        {
            _settings = ApplicationSettingsModel.Instance;
            ep = new IPEndPoint(IPAddress.Parse(_settings.FlightServerIP), _settings.FlightCommandPort); 
        }
        public void Connect()
        {
            _client = new TcpClient();
            
            // try to connect until sucess.
            while (!_client.Connected)
            {
                try
                {
                    _client.Connect(ep);
                } catch (Exception) { }
            }
        }
        public void SendCommands(string commands)
        {
            _writer = new BinaryWriter(_client.GetStream());
            // send here the data to the simulator on different thread !!!!!!!!!!!!!!1
        }


    }
}
