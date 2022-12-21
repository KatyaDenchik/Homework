using PR2Konst.Loggers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace PR2Konst
{
    public static class SerialiazeHelper
    {
        public static void SerialiazeToXml<T>(T inObject, string filePath)
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
                //Logger.Error(e.Message, new TxtLogger(), new MessageLogger());
            }
        }

        public static T DeserialiazationFromXml<T>(string filePath) where T : class, new()
        {
            if (!File.Exists(filePath))
            {
                //Logger.Error($"Файлу по шляху {filePath} не знайдено!", new TxtLogger(), new MessageLogger());
                return new T();
            }

            try
            {
                XmlSerializer reader = new XmlSerializer(typeof(T));
                StreamReader file = new StreamReader(filePath);

                var obj = (T)reader.Deserialize(file);

                file.Close();

                return obj;
            }
            catch (Exception e)
            {
                //Logger.Error(e.Message, new TxtLogger(), new MessageLogger());
                return new T();
            }
        }

        public static void SerialiazeToJson<T>( T inObject, string inFileName)
        {
          
            try
            {
                FileStream stream1 = new FileStream(inFileName, FileMode.OpenOrCreate);
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
        public static T DeserializationFromJson<T>(string inFileName) where T : class, new ()
        {
            if (!File.Exists(inFileName))
            {
                //Logger.Error($"Файлу по шляху {inFileName} не знайдено!", new TxtLogger(),new MessageLogger());
                return new T();
            }

            FileStream stream1 = new FileStream(inFileName, FileMode.OpenOrCreate);
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            var inObject = (T)ser.ReadObject(stream1);
            stream1.Close();
            return inObject;
        }
    }
}

