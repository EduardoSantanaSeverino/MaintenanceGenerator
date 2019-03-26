using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.MyCollege
{
    public class ItemConfig
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool CreateDirectory { get; set; }
        public bool IsChecked { get; set; }
    }
}
