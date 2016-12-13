using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobLogger
{
    public class ConsoleLogger : ILogger
    {
        public void LogMessage(string message, SeverityLevel severityLevel)
        {
            switch (severityLevel)
            {
                case SeverityLevel.ERROR:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case SeverityLevel.WARNING:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case SeverityLevel.MESSAGE:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                default:
                    return;
            }

            Console.WriteLine(DateTime.Now.ToShortDateString() + message);

            //Sets the foreground and background console colors to their defaults.
            Console.ResetColor();
        }
    }
}
