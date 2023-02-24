using BeautySaloonKPZDenchik6.Services;
using BeautySaloonKPZDenchik6.Services.Abstact;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySaloonKPZDenchik6.Helpers
{
    public class GenericJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(IService);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var target = JObject.Load(reader);
            if (target.ContainsKey("Servies"))
            {
                var result = Activator.CreateInstance<ServicesPackage>();
                serializer.Populate(target.CreateReader(), result);
                return result;
            }
            else
            {
                var result = Activator.CreateInstance<Service>();
                serializer.Populate(target.CreateReader(), result);
                return result;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
