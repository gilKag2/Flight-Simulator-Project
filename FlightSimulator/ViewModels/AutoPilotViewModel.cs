using FlightSimulator.Model;
using System.Windows.Input;
using System;
using System.ComponentModel;
using System.Windows.Media;

namespace FlightSimulator.ViewModels
{
    public class AutoPilotViewModel : BaseNotify
    {
        private AutoPilotModel model;
        private string _commands;
        private Brush _backgroundColor;
        public Brush BackgroundColor
        {
            get
            {
                return _backgroundColor;
            }
            set
            {
                _backgroundColor = value;
                NotifyPropertyChanged("Background Color");
            }
        }

        public AutoPilotViewModel()
        {
            model = new AutoPilotModel();
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged(e.PropertyName);
            };
            _commands = "";
            BackgroundColor = Brushes.White;
        }

        public string Commands
        {
            get
            {
                return _commands;
            }
            set
            {
                _commands = value;
                BackgroundColor = Brushes.LightPink;
                NotifyPropertyChanged("Commands");
            }
        }

        private ICommand _okCommand;
        public ICommand OkCommand => _okCommand ?? (_okCommand = new CommandHandler(() => OnOK()));

        private void OnOK()
        {
            if (_commands == "") return;

            model.SendCommands(Commands);
            Commands = "";
            BackgroundColor = Brushes.White;

        }
        private ICommand _clearCommand;
        public ICommand ClearCommand => _clearCommand ?? (_clearCommand = new CommandHandler(() => OnClear()));
        
        private void OnClear()
        {
            BackgroundColor = Brushes.White;
           Commands = "";
        }
    }
}
