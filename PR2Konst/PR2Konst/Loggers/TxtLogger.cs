using PR2Konst.Loggers.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR2Konst.Loggers
{
    public class TxtLogger : ILogger
    {
        public void WriteLog(string message, LogLevel logLevel = LogLevel.Info)
        {
            using (var txtWriter = new StreamWriter("./log.txt",true))
            {
                txtWriter.WriteLine($"[{logLevel}]:{message}\t{DateTime.Now}");
            }
        }
    }
}
