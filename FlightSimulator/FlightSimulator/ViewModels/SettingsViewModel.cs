using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    class SettingsViewModel : BaseNotify
    {
        private ISettingsModel _settings;
        public SettingsViewModel()
        {
            _settings = new ApplicationSettingsModel();
        }
        public string FlightServerIp
        {
            get
            {
                return _settings.FlightServerIP;
            }
            set
            {
                _settings.FlightServerIP = value;
                NotifyPropertyChanged("FlightServerIp");
            }
        }
        public int FlightInfoPort
        {
            get
            {
                return _settings.FlightInfoPort;
            }
            set
            {
                _settings.FlightInfoPort = value;
                NotifyPropertyChanged("FlightInfoPort");
            }
        }
        public int FlightCommandPort
        {
            get
            {
                return _settings.FlightCommandPort;
            }
            set
            {
                _settings.FlightCommandPort = value;
                NotifyPropertyChanged("FlightCommandPort");
            }
        }

        public void Save()
        {
            _settings.SaveSettings();
        }
        public void Reload()
        {
            _settings.ReloadSettings();
        }
        private ICommand _okCommand;
        public ICommand OkCommand => _okCommand ?? (_okCommand = new CommandHandler(() => OnOk()));

        private void OnOk()
        {
            Save();
        }
        private ICommand _cancelCommand;
        public ICommand CancelCommand => _cancelCommand ?? (_cancelCommand = new CommandHandler(() => OnCancel()));

        private void OnCancel()
        {
            Reload();
        }
    }
}
