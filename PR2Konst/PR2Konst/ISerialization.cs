using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PR2Konst
{
    public interface ISerializer
    {
        void Serialiaze<T>(T inObject, string filePath);

        string CarFilePath { get;} 
        string ParkingFilePath { get;} 
        string AppConfigFilePath { get;}

        T Deserialiazation<T>(string filePath) where T : class, new();
    }
}

