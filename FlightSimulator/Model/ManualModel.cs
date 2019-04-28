using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.ViewModels;
using System.ComponentModel;

namespace FlightSimulator.Model
{
    internal class ManualModel : BaseNotify
    {
        // sends the set command.
        public void SetCommands(string command) {
            string[] commandPrep = { command };
            Commands.Instance.SendCommands(commandPrep);
        }
    }
}
