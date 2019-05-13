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
        
        public override string GetSpecificType()
        {
            if (!string.IsNullOrEmpty(_specificType))
                return _specificType;

            var classHeader = this.LoadedClass.Where(x => x.Contains("Tenant<")).ToList().FirstOrDefault();
            if (classHeader != null)
            {
                var index = classHeader.IndexOf("<");
                var specificInitial = classHeader.Substring(index + 1, 1);
                if (specificInitial != "i")
                    _specificType = "long";
                else
                    _specificType = "int";

            }
            else
                _specificType = "int";

            return _specificType;

        }
    }
}
