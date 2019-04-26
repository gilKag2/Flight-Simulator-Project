using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace FlightSimulator.Model
{
    //singleton.
    public sealed class Commands
    {
        private TcpClient _client;
        private BinaryWriter _writer;
        private ISettingsModel _settings;
        private bool _isConnected;
        private bool _stop = false;
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
            _isConnected = false;
            _client = new TcpClient();
            _settings = ApplicationSettingsModel.Instance;
            ep = new IPEndPoint(IPAddress.Parse(_settings.FlightServerIP), _settings.FlightCommandPort);
        }

        public bool IsConnected
        {
            get
            {
                return _isConnected;
            }
        }
        public void Connect()
        {
            // try to connect until sucess.
            while (!_client.Connected)
            {
                try
                {
                    _client.Connect(ep);
                }
                catch (Exception) { }
            }
            _isConnected = true;
        }
        public void SendCommands(string[] commands) // not sure yet if we recieve array of strings, or long string and parse it.
        {
            _writer = new BinaryWriter(_client.GetStream());
            Thread thread = new Thread(delegate ()
            {
                while (!_stop)
                {
                    // send commands!!
                }
               // send the data every 2 seconds.
                Thread.Sleep(2000);
            });
            thread.Start();
            // send here the data to the simulator on different thread !!!!!!!!!!!!!!1
        }


        public void CloseConnection()
        {
            if (_client != null)
            {
                _client.Close();
                _writer.Close();
                _isConnected = false;
                _stop = true;
            }
        }

    }
}
