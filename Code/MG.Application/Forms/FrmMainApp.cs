using MG.Application.Generic;

namespace MG.Application.Forms;

public class FrmMainApp: IFrmMainApp
{
    public ICrudGenerator CrudGenerator { get; set; }
    public FlowLayoutPanel FlowInput { get; set; }
    public FlowLayoutPanel FlowOutput { get; set; }
    public IGenerateControls GenerateControls { get; set; }

    public FrmMainApp(ICrudGenerator crudGenerator, IGenerateControls generateControls)
    {
        this.FlowInput = new FlowLayoutPanel();
        this.FlowOutput = new FlowLayoutPanel();
        this.CrudGenerator = crudGenerator;
        this.GenerateControls = generateControls;
        this.GenerateControls.AddInputControls(this);
        this.GenerateControls.AddOutputControls();
        this.GenerateControls.SetInputsFromParameters();
    }
}
