using MG.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.MyCollege
{
    public class GenerateControls : GenerateControlsBase, IGenerateControls
    {
        public GenerateControls(List<ItemToReplace> itemToReplaces, IFrmMainApp form) : base(itemToReplaces, form)
        {
        }
    }
}
