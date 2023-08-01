using MG.Application.Forms;

namespace MG.Application.Generic
{
    public interface IGenerateControls
    {
        void AddInputControls(IFrmMainApp form);
        void SetInputsFromParameters(List<IControl> inputControls);
        void AddOutputControls();
    }
}
