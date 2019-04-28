using FlightSimulator.Model;
using System;
using System.ComponentModel;

namespace FlightSimulator.ViewModels
{
    class ManualViewModel : BaseNotify
    {
        private double vm_rudder;
        private double vm_throttle;
        private double vm_aileron;
        private double vm_elevator;
        private ManualModel manualModel;
        public ManualViewModel()
        {
            this.manualModel = new ManualModel(this);
        }

        public double VM_rudder
        {
            get => vm_rudder;
            set
            {
                vm_rudder = value;
                this.manualModel.setCommands("set /controls/flight/rudder " + value.ToString("0.00"));
                NotifyPropertyChanged("VM_rudder");
            }
        }

        public double VM_throttle
        {
            get => vm_throttle;
            set
            {
                vm_throttle = value;
                this.manualModel.setCommands("set /controls/engines/current-engine/throttle " + value.ToString("0.00"));
                NotifyPropertyChanged("VM_throttle");
            }
        }

        public double VM_aileron
        {
            get => vm_aileron;
            set
            {
                vm_aileron = value;
                this.manualModel.setCommands("set /controls/flight/aileron " + value.ToString("0.00"));
                NotifyPropertyChanged("VM_aileron");
            }
        }


        public double VM_elevator
        {
            get => vm_elevator;
            set
            {
                vm_elevator = value;
                this.manualModel.setCommands("set /controls/flight/elevator " + value.ToString("0.00"));
                NotifyPropertyChanged("VM_elevator");
            }
        }

    }
}
