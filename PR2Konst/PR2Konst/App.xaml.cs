using PR2Konst.Loggers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace PR2Konst
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            
            TimerCallback tm = new TimerCallback(e =>
            {
                Repositiry.Save();
            });
            Task.Factory.StartNew(() =>
            {
                Timer timer = new Timer(tm, null, 0, AppConfig.Instance.SaveTime);

                while (true)
                {
                }
            });
        }
    }
}
