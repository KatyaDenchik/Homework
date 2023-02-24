using BeautySaloonKPZDenchik6.Loggers;
using BeautySaloonKPZDenchik6.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace BeautySaloonKPZDenchik6.Helpers
{
    /// <summary>
    /// Клас для роботи з JSON файлами
    /// </summary>
    public class SerializerToJSON
    {
        /// <summary>
        /// Метод, який десереалізує файл у форматі JSON 
        /// </summary>
        /// <typeparam name="T">Тип до якого потрібно десеріалізувати</typeparam>
        /// <param name="filePath"></param>
        /// <returns>Повертає десеріалізований об'єкт</returns>
        public T Deserialiazation<T>(string filePath) where T : class, new()
        {
            if (!File.Exists(filePath))
            {
                return new T();
            }

            using FileStream stream = new FileStream(filePath, FileMode.OpenOrCreate);
            using StreamReader streamReader = new StreamReader(stream);

            JsonSerializerSettings serSettings = new JsonSerializerSettings();
            serSettings.Formatting = Formatting.Indented;
            serSettings.Converters.Add(new GenericJsonConverter());
            var inObject = JsonConvert.DeserializeObject<T>(streamReader.ReadToEnd(), serSettings);

            return inObject;
        }


        /// <summary>
        /// Метод, який сереалізує файл у форматі JSON 
        /// </summary>
        /// <typeparam name="T">Тип який потрібно серіалізувати</typeparam>
        /// <param name="inObject">Об'єкт який потрібно серіалізувати</param>
        /// <param name="filePath"></param>
        public void Serialiaze<T>(T inObject, string filePath)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.Never
            };
            try
            {
                using StreamWriter stream = new StreamWriter(filePath);
                JsonSerializer serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;

                using JsonWriter writer = new JsonTextWriter(stream);
                serializer.Serialize(writer, inObject);
            }
            catch (Exception e)
            {
                Logger.Fatal(e.Message);
            }
        }
    }
}
