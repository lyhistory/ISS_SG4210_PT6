using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.bl.Search
{
    public abstract class Converter<T> : JsonConverter
    {
        protected abstract T Create(Type objectType,JObject jObject);

        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader,
                                        Type objectType,
                                         object existingValue,
                                         JsonSerializer serializer)
        {
            // Load JObject from stream
            JObject jObject = JObject.Load(reader);

            // Create target object based on JObject
            T target = Create(objectType, jObject);

            // Populate the object properties
            serializer.Populate(jObject.CreateReader(), target);

            return target;
        }

        public override void WriteJson(JsonWriter writer,
                                       object value,
                                       JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
