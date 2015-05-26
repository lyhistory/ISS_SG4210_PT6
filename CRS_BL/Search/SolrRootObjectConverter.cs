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
    public class Params
    {
        public string q { get; set; }
        public string indent { get; set; }
        public string wt { get; set; }
    }

    public class ResponseHeader
    {
        public int status { get; set; }
        public int QTime { get; set; }
        public Params @params { get; set; }
    }

    public class Response
    {
        public int numFound { get; set; }
        public int start { get; set; }
        public List<BaseSearchValueObject> baseSearchValueObject { get; set; }
    }

    public class RootObject
    {
        public ResponseHeader responseHeader { get; set; }
        public Response response { get; set; }
    }

    public class SolrRootObjectConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(RootObject).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader,Type objectType,object existingValue,JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            RootObject rootObject = new RootObject();

            PropertyInfo[] properties = rootObject.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach(PropertyInfo p in properties)
            {
                object v = jObject[p.Name];
                if(v != null)
                {
                    Type type = p.PropertyType;
                    if (type == typeof(Response))
                    {
                        Response dynamicFields = new Response();
                        JArray jOpts = (JArray)jObject[p.Name];

                        if (jOpts.Count > 0)
                        {
                            dynamicFields = JsonConvert.DeserializeObject<Response>(jOpts.ToString(), new SolrResponseConverter());
                            p.SetValue(rootObject, dynamicFields, null);
                        }
                    }
                }
            }

            return rootObject;
        }

        public override void WriteJson(JsonWriter writer,object value,JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
