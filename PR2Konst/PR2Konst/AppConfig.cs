using PR2Konst.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR2Konst
{
    public enum TypeOfSerialiaze
    {
        XML,
        JSON,
        BIN
    }
    public class AppConfig
    {
        public static AppConfig Instance { get; set; } = new AppConfig();

        public int SaveTime = 10000;
        public string CarXMLFilePath { get; set; } = @".\Cars.xml";
        public string ParkingXMLFilePath { get; set; } = @".\Parkings.xml";
        public string AppConfigXMLFilePath { get; set; } = @".\AppConfig.xml";
        public string CarJSONFilePath { get; set; } = @".\Cars.json";
        public string ParkingJSONFilePath { get; set; } = @".\Parkings.json";
        public string AppConfigJSONFilePath { get; set; } = @".\AppConfig.json";

        public TypeOfSerialiaze typeOfSerialiaze { get; set; }
        public string AppConfigBINFilePath { get; set; } = @".\AppConfig.dat";
        public string ParkingBINFilePath { get; set; } = @".\Parkings.dat";
        public string CarBINFilePath { get; set; } = @".\Cars.dat";


        public AppConfig()
        {

        }
    }
}
