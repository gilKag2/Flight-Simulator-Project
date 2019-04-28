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
            Console.WriteLine("trying to connect - client");
            _client = new TcpClient();
            Thread thread = new Thread(() =>
            {
                // try to connect until sucess.
                while (!_client.Connected)
                {
                    try
                    {
                        _client.Connect(ep);
                        Console.WriteLine("connected - client");
                        //Thread.CurrentThread.Abort();
                    }
                    catch (Exception) { }
                }
            });
            thread.Start();
            _isConnected = true;
        }
        public void SendCommands(string[] commands)
        {
            if (!_isConnected) return;

            Thread thread = new Thread(delegate ()
            {
                using (NetworkStream stream = _client.GetStream())
                {
                    foreach (string command in commands)
                    {
                        Console.WriteLine("sending data - client");
                        Byte[] data = Encoding.ASCII.GetBytes(command + "\r\n");
                        stream.Write(data, 0, data.Length);
                        stream.Flush();
                        // send the data every 2 seconds.
                        Thread.Sleep(2000);
                    }
                }

            });
            thread.Start();
        }


        public void CloseConnection()
        {
            if (_client != null)
            {
                _client.Close();
                Thread.CurrentThread.Abort();
                _isConnected = false;
                _stop = true;
            }
        }

    }
}
