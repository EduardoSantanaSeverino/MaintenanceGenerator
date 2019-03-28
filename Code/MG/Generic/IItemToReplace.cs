using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Generic
{
    public interface IItemToReplace
    {
         int Id { get; set; }
         string Key { get; set; }
         string Value { get; set; }
         string LabelText { get; set; }
    }
}
