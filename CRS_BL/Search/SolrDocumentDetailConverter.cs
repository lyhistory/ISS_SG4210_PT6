using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using nus.iss.crs.dm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.bl.Search
{
    class SolrDocumentDetailConverter : JsonConverter
    {

        public override bool CanConvert(Type objectType)
        {
            return typeof(BaseSearchValueObject).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            BaseSearchValueObject baseSearchValueObject = new BaseSearchValueObject();

            PropertyInfo[] properties = baseSearchValueObject.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo p in properties)
            {
                object v = jObject[p.Name];
                if (v != null)
                {
                    Type type = p.PropertyType;
                    if (type == typeof(BaseSearchValueObject))
                    {
                        BaseSearchValueObject dynamicFields = new BaseSearchValueObject();
                        JArray jOpts = (JArray)jObject[p.Name];

                        if (jOpts.Count > 0)
                        {
                            dynamicFields = JsonConvert.DeserializeObject<BaseSearchValueObject>(jOpts.ToString());
                            p.SetValue(baseSearchValueObject, dynamicFields, null);
                        }
                    }
                }
            }

            return baseSearchValueObject;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
