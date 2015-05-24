using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using nus.iss.crs.dm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.bl.Search
{
    public class Response
    {
        public int numFound { get; set; }
        public int start { get; set; }
        public List<BaseSearchValueObject> baseSearchValueObject { get; set; }
    }

    public class ResponseConverter : JsonConverter
    {
        //protected abstract T Create(Type objectType,JObject jObject);

        public override bool CanConvert(Type objectType)
        {
            return typeof(BaseSearchValueObject).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader,
                                        Type objectType,
                                        object existingValue,
                                        JsonSerializer serializer)
        {
            // Load JObject from stream
            JObject jObject = JObject.Load(reader);
            BaseSearchValueObject baseSearchValueObject = new BaseSearchValueObject();
            var properties = jObject.Properties().ToList();

            // Populate the object properties
            serializer.Populate(jObject.CreateReader(), baseSearchValueObject);

            return baseSearchValueObject;
        }

        public override void WriteJson(JsonWriter writer,object value,JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
