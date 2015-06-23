using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRSClient
{
    public class ComboItem
    {
        string name;
            string val;
            object obj;
        public ComboItem(string name, string val, object obj)
        {
            this.name = name;
            this.val = val;
            this.obj = obj;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Value
        {
            get { return val; }
            set { val = value; }
        }

        public object Tag
        {
            get { return obj; }
            set { obj = value; }
        }

        public override string ToString()
        {
            return name;
        }
    }
}
