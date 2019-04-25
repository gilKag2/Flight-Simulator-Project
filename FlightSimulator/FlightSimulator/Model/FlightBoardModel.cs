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
        private bool _isSettingsWindowOpen = false;
        public double Lat
        {
            get
            {
                return _lat;
            }
        }

        public double Lon
        {
            get
            {
                return _lon;
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
            throw new NotImplementedException();
        }
    }
}
