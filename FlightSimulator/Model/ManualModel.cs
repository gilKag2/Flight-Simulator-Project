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
        private ManualViewModel manualVM;

        public ManualModel(ManualViewModel manualVM) 
        {
            this.manualVM = manualVM;
        }

        public void setCommands(string command) {
            string[] commandPrep = { command };
            Commands.Instance.SendCommands(commandPrep);
        }
    }
}
