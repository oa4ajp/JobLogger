﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobLogger
{
    public interface ILogger
    {
        void LogMessage(string message, SeverityLevel severityLevel);
    }
}
