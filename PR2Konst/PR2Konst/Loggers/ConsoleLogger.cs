using PR2Konst.Loggers.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR2Konst.Loggers
{
    public class ConsoleLogger : ILogger
    {
        public void WriteLog(string message, LogLevel logLevel = LogLevel.Info)
        {
            ConsoleColor consoleColor = logLevel switch
            {
                LogLevel.Debug => ConsoleColor.Yellow,
                LogLevel.Info => ConsoleColor.White,
                LogLevel.Error => ConsoleColor.Red,
            };


            Debug.WriteLine(message, consoleColor);
        }
    }
}
