using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Generic
{
    public class AttributeProperty
    {
        public string Description { get; set; }
        public bool ShowOnList { get; set; }
        public bool ShowOnCreate { get; set; }
        public bool ShowOnUpdate { get; set; }
        public bool Hidden { get; set; }
    }
}
