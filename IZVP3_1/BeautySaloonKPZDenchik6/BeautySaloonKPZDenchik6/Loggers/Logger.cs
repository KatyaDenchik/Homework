using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySaloonKPZDenchik6.Loggers
{
    public static class Logger
    {
        public static void Fatal(string message)
        {
            var stacktrace = new StackTrace();
            var prevFrame = stacktrace.GetFrame(1);
            var method = prevFrame.GetMethod();
            using (var txtWriter = new StreamWriter("./log.txt", true))
            {
                message = $"\n\n******************************* FATAL ERROR {DateTime.Now} *******************************" +
                      $"\nMethod: {method.Name}" +
                      $"\nIn class: {method.ReflectedType.Name}" +
                      $"\n{message}";

                txtWriter.WriteLine(message);
            }
        }
    }
}
