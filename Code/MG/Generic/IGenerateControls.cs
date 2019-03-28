using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Generic
{
    public interface IGenerateControls
    {
        List<IItemToReplace> ItemToReplaces { get; }

        void AddInputControls();

        void AddOutputControls();
    }
}
