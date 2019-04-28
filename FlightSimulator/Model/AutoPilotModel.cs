using FlightSimulator.ViewModels;

namespace FlightSimulator.Model
{
    internal class AutoPilotModel : BaseNotify
    {

        public void SendCommands(string commands)
        {
            string[] commandsArray = commands.Split('\n');
            int len = commandsArray.Length;
            // get rid of '\r' in each string
            for (int i = 0; i< len; i++)
            {
                if (commandsArray[i].EndsWith("\r")) commandsArray[i] = commandsArray[i].Substring(0, commandsArray[i].Length - 1);
            }

            Commands.Instance.SendCommands(commandsArray);
        }
    }
}