using MG.Application.Generic;

namespace MG.Application.SocialUplift
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
