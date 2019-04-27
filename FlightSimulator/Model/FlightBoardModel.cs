using FlightSimulator.ViewModels;
using System;
using System.ComponentModel;

namespace FlightSimulator.Model
{
    public class FlightBoardModel : BaseNotify
    {
        private double _lon;
        private double _lat;
        private Info server;
        private Commands client;
        private bool _isConnected;
      
        public FlightBoardModel()
        {
            _isConnected = false;
            server = Info.Instance;
            client = Commands.Instance;
        }
        public double Lat
        {
            get
            {
                return _lat;
            }
            set
            {
                _lat = value;
                NotifyPropertyChanged("Lat");
            }
        }
        public double Lon
        {
            get
            {
                return _lon;
            }
            set
            {
                _lon = value;
                NotifyPropertyChanged("Lon");
            }
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
            server.OpenServer();
            server.Listen(this);
            client.Connect();
            
            _isConnected = true;

        }
        public void Disconnect()
        {
            _isConnected = false;
            client.CloseConnection();
            server.CloseServer();
        }
    }

}
