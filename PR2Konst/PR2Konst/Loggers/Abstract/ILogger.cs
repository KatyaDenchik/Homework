﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR2Konst.Loggers.Abstract
{
    public interface ILogger
    {
        void WriteLog(string message, LogLevel logLevel = LogLevel.Info );
    }
}
