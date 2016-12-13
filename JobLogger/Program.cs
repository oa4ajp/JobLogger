using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = "Test Message 4";
            Logger oJobLogger = new Logger(LogType.CONSOLE, SeverityLevel.WARNING);
            oJobLogger.LogMessage(message);
        }
    }
}
