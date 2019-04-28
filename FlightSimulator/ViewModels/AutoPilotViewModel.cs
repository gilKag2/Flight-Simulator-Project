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
        private string _text;
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
                NotifyPropertyChanged("BackgroundColor");
            }
        }

        public AutoPilotViewModel()
        {
            model = new AutoPilotModel();
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged(e.PropertyName);
            };
            _text = "";
            BackgroundColor = Brushes.White;
        }

        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                if (_text != "") BackgroundColor = Brushes.LightPink;
                else BackgroundColor = Brushes.White;
                NotifyPropertyChanged("Text");
            }
        }

        private ICommand _okCommand;
        public ICommand OkCommand => _okCommand ?? (_okCommand = new CommandHandler(() => OnOK()));

        /*
         * command for the OK button, sends the data, clears the text and change the color to white.
         */
        private void OnOK()
        {
            if (_text == "") return;

            model.SendCommands(Text);
            Text = "";
            BackgroundColor = Brushes.White;

        }
        private ICommand _clearCommand;
        public ICommand ClearCommand => _clearCommand ?? (_clearCommand = new CommandHandler(() => OnClear()));
        
        /* 
         * command for the clear button, clears the text and changes the color back to white.
         */
        private void OnClear()
        {
           Text = "";
            BackgroundColor = Brushes.White;

        }
    }
}
