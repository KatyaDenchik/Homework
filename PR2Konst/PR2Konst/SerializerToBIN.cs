using PR2Konst.Loggers;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PR2Konst
{
    public class SerializerToBIN : ISerializer
    {
        public string CarFilePath => AppConfig.Instance.CarBINFilePath;
        public string ParkingFilePath => AppConfig.Instance.ParkingBINFilePath;
        public string AppConfigFilePath => AppConfig.Instance.AppConfigBINFilePath;

        public T Deserialiazation<T>(string filePath) where T : class, new()
        {
            if (!File.Exists(filePath))
            {
                //Logger.Error($"Файлу по шляху {filePath} не знайдено!", new TxtLogger(), new MessageLogger());
                return new T();
            }

            FileStream stream = new FileStream(filePath, FileMode.OpenOrCreate);
            var formatter = new BinaryFormatter();
            var inObject = (T)formatter.Deserialize(stream);
            stream.Close();
            return inObject;
        }

        public void Serialiaze<T>(T inObject, string filePath)
        {
            try
            {
                FileStream stream = new FileStream(filePath, FileMode.OpenOrCreate);
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, inObject);
                stream.Close();
            }
            catch (Exception e)
            {
                //Logger.Error(e.Message, new TxtLogger(), new MessageLogger());
            }
        }

    }
}
