using PR2Konst.Loggers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace PR2Konst
{
    public class SerializerToXML : ISerializer
    {
        public string CarFilePath => AppConfig.Instance.CarXMLFilePath;
        public string ParkingFilePath => AppConfig.Instance.ParkingXMLFilePath;
        public string AppConfigFilePath => AppConfig.Instance.AppConfigXMLFilePath;

        public T Deserialiazation<T>(string filePath) where T : class, new()
        {
            if (!File.Exists(filePath))
            {
                Logger.Error($"Файлу по шляху {filePath} не знайдено!");
                return new T();
            }
            StreamReader file = null;
            try
            {
                XmlSerializer reader = new XmlSerializer(typeof(T));
                file = new StreamReader(filePath);

                var obj = (T)reader.Deserialize(file);

                file.Close();

                return obj;
            }
            catch (Exception e)
            {
                Logger.Error(e.Message, new TxtLogger(), new MessageLogger());

                file?.Close();
                return new T();
            }
        }

        public void Serialiaze<T>(T inObject, string filePath)
        {
            try
            {
                XmlSerializer writer = new XmlSerializer(typeof(T));
                StreamWriter file = new StreamWriter(filePath);

                writer.Serialize(file, inObject);

                file.Close();
            }
            catch (Exception e)
            {
                Logger.Error(e.Message, new TxtLogger(), new MessageLogger());
            }
        }

    }
}
