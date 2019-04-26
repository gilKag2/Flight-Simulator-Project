using FlightSimulator.Model.Interface;
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
            server = new TcpListener(ep);
            _settings = ApplicationSettingsModel.Instance;
            ep = new IPEndPoint(IPAddress.Parse(_settings.FlightServerIP), _settings.FlightInfoPort);
            _stop = false;
        }
      

        public void OpenServer()
        {
            // not sure here check this !!!!!!!!!!!!!111.
            if (server != null) CloseServer();
            
            server.Start();
        }
        public void CloseServer()
        {
            _stop = true;
            server.Stop();
        }


        public void Listen(FlightBoardModel model) {
            if (server == null) return;
            Thread thread = new Thread(() =>
            {
                try
                {
                    TcpClient client = server.AcceptTcpClient();
                    using (NetworkStream stream = client.GetStream()) {
                        while (!_stop)
                        {
                            Console.WriteLine("got a connection"); /// delete later its just for debug!!!!!!!!
                            byte[] data = new Byte[client.ReceiveBufferSize];
                            Int32 bytesReaden = stream.Read(data, 0, data.Length);
                            string[] parsedData = Encoding.ASCII.GetString(data, 0, bytesReaden).Split(',');
                            // the lon and lat values should be in the first two indexes.
                            model.Lon = Convert.ToDouble(parsedData[0]);
                            model.Lat = Convert.ToDouble(parsedData[1]);

                            // maybe think about a better way to return the values, maybe client handler. the lon and lat should be in the 0 and 1 places in the parsed data array.
                        }
                    }
                    client.Close();
                }
                catch (SocketException) { }
                
            });
            thread.Start();
            // read the data here !!!
        }
      
    }
}
