using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Generic
{
    public abstract class ItemToReplaceBase : IItemToReplace
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string LabelText { get; set; }
    }
}
