using FlightSimulator.ViewModels;

namespace FlightSimulator.Model
{
    internal class AutoPilotModel : BaseNotify
    {

      
        public void SendCommands(string commands)
        {
            Commands client = Commands.Instance;
            if (!client.IsConnected) return;
            string[] commandsArray = commands.Split('\n');
            client.SendCommands(commandsArray);
        }
    }
}