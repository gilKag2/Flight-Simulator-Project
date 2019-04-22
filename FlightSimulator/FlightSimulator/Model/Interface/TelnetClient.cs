using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model.Interface
{
    public interface TelnetClient
    {
        void connect(string ip, int port);
        void disconnect();
        void write(string command);
        string read();
    }
}
