using FlightSimulator.ViewModels;

namespace FlightSimulator.Model
{
    internal class AutoPilotModel : BaseNotify
    {

      
        private bool doneSending;

        public AutoPilotModel()
        {

        }

        public void SendCommands(string commands)
        {
            Commands client = Commands.Instance;
            string[] commandsArray = commands.Split('\n');
            client.SendCommands(commandsArray);
        }
    }
}