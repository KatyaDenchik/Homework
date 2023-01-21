using PR2Konst.Loggers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PR2Konst.Loggers
{
    public class MessageLogger : ILogger
    {
        public void WriteLog(string message, LogLevel logLevel = LogLevel.Info)
        {
            MessageBoxImage messageBoxImage = logLevel switch
            {
                LogLevel.Debug => MessageBoxImage.Exclamation,
                LogLevel.Info => MessageBoxImage.Information,
                LogLevel.Error => MessageBoxImage.Error,
            };
            MessageBox.Show(message, logLevel.ToString(), MessageBoxButton.OK, messageBoxImage);

        }
    }
}
