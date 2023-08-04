using MG.Application.Generic;

namespace MG.Application.AspnetBoilerPlate._8._1._0
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
