using MG.Application.Forms;

namespace MG.Application.Generic
{
    public interface IFrmMainApp
    {
        ICrudGenerator CrudGenerator { get; set; }
        FlowLayoutPanel FlowInput { get; set; }
        FlowLayoutPanel FlowOutput { get; set; }
        IGenerateControls GenerateControls { get; set; }
    }
}