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
    class SolrResponseConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Response).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            Response response = new Response();

            PropertyInfo[] properties = response.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo p in properties)
            {
                object v = jObject[p.Name];
                if (v != null)
                {
                    Type type = p.PropertyType;
                    if (type == typeof(List<BaseSearchValueObject>))
                    {
                        List<BaseSearchValueObject> dynamicFields = new List<BaseSearchValueObject>();
                        JArray jOpts = (JArray)jObject[p.Name];

                        if (jOpts.Count > 0)
                        {
                            dynamicFields = JsonConvert.DeserializeObject<List<BaseSearchValueObject>>(jOpts.ToString(), new SolrDocumentDetailConverter());
                            p.SetValue(response, dynamicFields, null);
                        }
                    }
                }
            }

            return response;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
