using Newtonsoft.Json.Linq;
using nus.iss.crs.dm.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.bl.Search
{
    class PersonConverter : Converter<Registration>
    {
        protected override Registration Create(Type objectType, JObject jObject)
        {
            //if (FieldExists("Skill", jObject))
            //{
            //    return new Artist();
            //}
            //else if (FieldExists("Department", jObject))
            //{
            //    return new Employee();
            //}
            //else
            //{
            //    return new Person();
            //}
            return new Registration();
        }

        private bool FieldExists(string fieldName, JObject jObject)
        {
            return jObject[fieldName] != null;
        }
    }
}
