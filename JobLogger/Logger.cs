using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobLogger
{
    public class Logger
    {
        private LogType logType;
        private SeverityLevel severityLevel;
        private ILogger logger;

        public Logger(LogType logType, SeverityLevel severityLevel) 
        {
            this.logType = logType;
            this.severityLevel = severityLevel;
            SetLogType();
        }

        private void SetLogType() 
        {            
            switch (logType)
            {
                case LogType.CONSOLE:
                    logger = new ConsoleLogger();
                    break;
                case LogType.FILE:
                    logger = new FileLogger();
                    break;
                case LogType.DATABASE:
                    logger = new DataBaseLogger();
                    break;
                default:
                    break;
            }
        }

        public void LogMessage(string message)
        {
            if (message != null)
            {
                message.Trim();
                if (message.Length == 0)
                {
                    return;
                }
            }
            else 
            {
                return;
            }                                    

            ValidateLogType();
            ValidateLogSeverity();

            logger.LogMessage(message, severityLevel);
        }

        public void ValidateLogType() 
        {
            if (!Enum.IsDefined(typeof(LogType), logType))
            {
                throw new LoggerException("Invalid Log Type");
            }            
        }

        public void ValidateLogSeverity()
        {
            if(!Enum.IsDefined(typeof(SeverityLevel), severityLevel))
            {
                throw new LoggerException("Error or Warning or Message must be specified");
            }
        }
    }
}
