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
    // singleton
    public sealed class Info
    {
        private TcpListener server;
        private TcpClient client;
        private BinaryReader reader;
        private IPEndPoint ep;
        IClientHandler ch;
        private bool _stop;
        private ISettingsModel _settings;
        private static Info _instance;
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
        public Info()
        {
            ep = new IPEndPoint(IPAddress.Parse(_settings.FlightServerIP), _settings.FlightInfoPort);
            _settings = ApplicationSettingsModel.Instance;
            _stop = false;
            ch = new ClientHandler();

        }
        public void OpenServer()
        {
            // not sure here check this !!!!!!!!!!!!!111.
            if (server != null) CloseServer();
            server = new TcpListener(ep);
            server.Start();
        }
        public void CloseServer()
        {
            _stop = true;
            client.Close();
            server.Stop();
            reader.Close();
        }


        public void Listen() /// maybe return array of string, or send the info by some event.,
        {
            Thread thread = new Thread(() =>
            {
                try
                {
                    TcpClient client = server.AcceptTcpClient();
                    reader = new BinaryReader(client.GetStream());
                    while (!_stop)
                    {
                        Console.WriteLine("got a connection"); /// delete later its just for debug!!!!!!!!
                        ch.HandleClient(client);
                    }
                }
                catch (SocketException) { }
            });
            thread.Start();
            // read the data here !!!
        }

    }
}
