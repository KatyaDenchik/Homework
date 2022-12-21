using PR2Konst.Loggers.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PR2Konst.Loggers
{
    public static class Logger
    {
        public static void Debug(string message, params ILogger[] loggers) => Log(message, LogLevel.Debug, loggers);

        public static void Info(string message, params ILogger[] loggers) => Log(message, LogLevel.Info, loggers);
        public static void Error(string message, params ILogger[] loggers) => Log(message, LogLevel.Error, loggers);
        private static void Log(string message, LogLevel logLevel, params ILogger[] loggers)
        {
            if (!loggers.Any())
            {
                loggers = new ILogger[] { new ConsoleLogger() };
            }
            if (logLevel == LogLevel.Debug)
            {
#if DEBUG
#else
                return;
#endif
            }
            foreach (var logger in loggers)
            {
                logger.WriteLog(message, logLevel);
            }
        }
    }
}
