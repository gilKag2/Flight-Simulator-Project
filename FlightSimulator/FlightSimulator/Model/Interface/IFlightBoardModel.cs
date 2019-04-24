using FlightSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model.Interface
{
    class IFlightBoardModel : INotifyPropertyChanged
    {
        double Lon { get; set; }
        double Lat { get; set; }
        void OpenSettings();
        void closeSettings();
    }
}
