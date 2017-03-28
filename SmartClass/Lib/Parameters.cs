using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartClass.Lib
{
    class Parameters
    {
        public String Name { get; set; }
        public String Value { get; set; }
        public KeyValuePair<String, String> keyValue
        {
            get
            {
                return new KeyValuePair<string, string>(Name, Value);
            }
        }
        public Parameters(String _name, String _value)
        {
            this.Name = _name;
            this.Value = _value;
        }

        public override bool Equals(object obj)
        {
            if(!(obj is Parameters))
            {
                return false;
            }
            var p = (Parameters)obj;
            return this.Name == p.Name && this.Value == p.Value;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + Value.GetHashCode();
        }
    }
}
