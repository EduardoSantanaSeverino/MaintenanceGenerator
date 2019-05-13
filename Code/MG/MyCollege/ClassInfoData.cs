using System;
using System.Collections.Generic;
using System.Linq;
using MG.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MG.MyCollege
{
    public class ClassInfoData : ClassInfoDataBase, IClassInfoData
    {
        public ClassInfoData
        (
            string classesPath, 
            string className, 
            List<IItemToReplace> itemToReplaces, 
            List<ComboParameter> comboParameters = null
        ) : base(classesPath, className, itemToReplaces, comboParameters)
        {
        }
    }
}
