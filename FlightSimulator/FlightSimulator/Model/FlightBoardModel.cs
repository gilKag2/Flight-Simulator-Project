using FlightSimulator.ViewModels;
using System;
using System.ComponentModel;

namespace FlightSimulator.Model
{
    class FlightBoardModel : BaseNotify
    {
        private double _lon;
        private double _lat;
        private Settings _settings;
        private Info server;
        private Commands client;
        private bool _isConnected;
        private bool _isSettingsWindowOpen;
        public FlightBoardModel()
        {
            _isConnected = false;
            _isSettingsWindowOpen = false;
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
        public bool IsConnected
        {
            get
            {
                return _isConnected;
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
        public void CloseSettings()
        {
            if (!_isSettingsWindowOpen)
            {
                _settings.Close();
                _settings = null;
                _isSettingsWindowOpen = false;
            }
        }

        public void OpenSettings()
        {
            _settings = new Settings();
            _settings.Show();
            _isSettingsWindowOpen = true;
        }

        public void Connect()
        {
            server.OpenServer();
            client.Connect();
            _isConnected = true;
              
        }
        public void Disconnect()
        {
            _isConnected = false;
            throw new NotImplementedException();
        }
    }

}
