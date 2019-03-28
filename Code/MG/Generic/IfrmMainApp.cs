namespace MG.Generic
{
    public interface IFrmMainApp
    {
        ICrudGenerator CrudGenerator { get; set; }
        System.Windows.Forms.FlowLayoutPanel FlowInput { get; set; }
        System.Windows.Forms.FlowLayoutPanel FlowOutput { get; set; }
    }
}