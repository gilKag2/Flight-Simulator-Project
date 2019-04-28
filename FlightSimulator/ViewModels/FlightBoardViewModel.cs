using FlightSimulator.Model;
using System.ComponentModel;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    public
        class FlightBoardViewModel : BaseNotify
    {
        private double _lon;
        private double _lat;
        private FlightBoardModel model;
        private Settings settings;
        public FlightBoardViewModel()
        {
            settings = new Settings();
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
            set
            {
                _lon = value;
                NotifyPropertyChanged("Lon");
            }
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
                return model.IsConnected;
            }
        }
        private ICommand _settingsCommand;
        public ICommand SettingsCommand => _settingsCommand ?? (_settingsCommand = new CommandHandler(() => OnSettings()));

        private void OnSettings()
        {
          if (!settings.IsLoaded ) settings = new Settings();

          settings.Show();


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
