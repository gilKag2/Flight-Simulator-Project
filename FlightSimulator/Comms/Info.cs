﻿using FlightSimulator.Model.Interface;
using FlightSimulator.ViewModels;
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
    // singleton
    public sealed class Info : BaseNotify
    {
        private TcpListener server;
        private IPEndPoint ep;
        volatile private bool _stop;
        private ISettingsModel _settings;
        private static Info _instance;
        private bool _isConnected;
        private static readonly object padLock = new object();
        public static Info Instance
        {
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

        public bool IsConnected { get => _isConnected; set => _isConnected = value; }

        public Info()
        {
            _settings = ApplicationSettingsModel.Instance;
            ep = new IPEndPoint(IPAddress.Parse(_settings.FlightServerIP), _settings.FlightInfoPort);

            _stop = false;
        }


        public void OpenServer()
        {
            server = new TcpListener(ep);
            server.Start();
            IsConnected = true;

        }
        public void CloseServer()
        {
            if (server == null) return;
            _stop = true;
            server.Stop();
            IsConnected = false;
        }


        public void Listen(FlightBoardModel model)
        {
            if (server == null) return;

            Thread thread = new Thread(() =>
            {
                try
                {
                    TcpClient client = server.AcceptTcpClient();

                    using (NetworkStream stream = client.GetStream())
                    {
                        while (!_stop && stream != null && stream.CanRead)
                        {
                            try
                            {

                                byte[] data = new Byte[client.ReceiveBufferSize];
                                Int32 bytesReaden = stream.Read(data, 0, data.Length);
                                string[] parsedData = Encoding.ASCII.GetString(data, 0, bytesReaden).Split(',');

                                double lon = Convert.ToDouble(parsedData[0]);
                                double lat = Convert.ToDouble(parsedData[1]);

                                // the lon and lat values should be in the first two indexes.
                                model.Lon = Convert.ToDouble(parsedData[0]);
                                model.Lat = Convert.ToDouble(parsedData[1]);


                            }
                            catch (Exception) { }
                        }
                    }
                    client.Close();
                }
                catch (SocketException) { }

            });
            thread.Start();
        }

    }
}
