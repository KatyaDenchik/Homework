using PR2Konst.Loggers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace PR2Konst
{
    public class SerializerToJSON : ISerializer
    {
        public string CarFilePath => AppConfig.Instance.CarJSONFilePath;
        public string ParkingFilePath => AppConfig.Instance.ParkingJSONFilePath;
        public string AppConfigFilePath => AppConfig.Instance.AppConfigJSONFilePath;

        public T Deserialiazation<T>(string filePath) where T : class, new()
        {
            if (!File.Exists(filePath))
            {
                //Logger.Error($"Файлу по шляху {filePath} не знайдено!", new TxtLogger(), new MessageLogger());
                return new T();
            }

            FileStream stream1 = new FileStream(filePath, FileMode.OpenOrCreate);
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            var inObject = (T)ser.ReadObject(stream1);
            stream1.Close();
            return inObject;
        }

        public void Serialiaze<T>(T inObject, string filePath)
        {
            try
            {
                FileStream stream1 = new FileStream(filePath, FileMode.OpenOrCreate);
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
                ser.WriteObject(stream1, inObject);
                stream1.Position = 0;
                StreamReader sr = new StreamReader(stream1);
                stream1.Close();
            }
            catch (Exception e)
            {
                //Logger.Error(e.Message, new TxtLogger(), new MessageLogger());
            }
        }
        
    }
}
