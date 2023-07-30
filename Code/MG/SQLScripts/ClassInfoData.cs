using System.Collections.Generic;
using MG.Generic;

namespace MG.SQLScripts
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
