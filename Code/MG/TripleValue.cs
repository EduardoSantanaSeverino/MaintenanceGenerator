using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG
{
    public class TripleValue<T, X, Y, Z>
    {
        public TripleValue(T _key, X _value, Y _valueAlt, Z _valueAppened)
        {
            this.Key = _key;
            this.Value = _value;
            this.ValueAlt = _valueAlt;
            this.ValueAppened = _valueAppened;
        }
        public T Key { get; set; }
        public X Value { get; set; }
        public Y ValueAlt { get; set; }
        public Z ValueAppened { get; set; }

        public override string ToString()
        {
            return "Key:" + this.Key.ToString() + ", Value: " + this.Value + ", ValueAlt: " + this.ValueAlt + ", ValueAppened: " + this.ValueAppened;
        }
    }
}
