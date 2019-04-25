using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    public 
        class FlightBoardViewModel : BaseNotify
    {
        private double _lon;
        private double _lat;
        private FlightBoardModel model;
        public FlightBoardViewModel()
        {
            model = new FlightBoardModel();
            model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged(e.PropertyName);
            };
         }
        
        public double Lon
        {
            get
            {
                return _lon;
            }
        }

        public double Lat
        {
            get
            {
                return _lat;
            }
        }
        public bool IsConnected
        {
            get
            {
                return model.IsConnected;
            }
        }
        private ICommand _settingsCommand;
        public ICommand SettingsCommand => _settingsCommand ?? (_settingsCommand = new CommandHandler(() => OnSettings()));

        private void OnSettings()
        {
            model.OpenSettings();
        }
        private ICommand _connectCommand;
        public ICommand ConnectCommand => _connectCommand ?? (_connectCommand = new CommandHandler(() => OnConnect()));

        private void OnConnect()
        {
            model.Connect();
        }
        private ICommand _disconnectCommand;
        public ICommand DisconnectCommand => _disconnectCommand ?? (_disconnectCommand = new CommandHandler(() => OnDisconnect()));

        private void OnDisconnect()
        {
            model.Disconnect();
        }
    }
}
