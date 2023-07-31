using MG.Application.Forms;
using Spectre.Console;

namespace MG.Console;

public class Presentation
{
    public List<Table> Tables { get; set; }
    
    public Presentation()
    {
        Tables = new  List<Table>();
    }

    public void AddInputsToTable(FlowLayoutPanel forms)
    {
        var table = new Table();
        table.Title = new TableTitle("Input Parameters");
        table.AddColumn("Name");
        table.AddColumn("Value");
        
        foreach (FlowLayoutPanel control in forms.Controls)
        {
            table.AddRow(control.Controls[0].Text, control.Controls[1].Text);
        }
        table.Columns[0].PadLeft(3).PadRight(5);
        table.Columns[1].PadLeft(3).PadRight(5);
        this.Tables.Add(table);
    }

    public void AddOutputsToTable(FlowLayoutPanel forms)
    {
        foreach (var control in forms.Controls)
        {
            var table = new Table();
            table.Title = new TableTitle("[green]Output Generated Files[/]");
            table.AddColumn(control.Name.Replace("rtb",""));
            table.AddRow(control.Text.EscapeMarkup());
            table.Columns[0].PadLeft(3).PadRight(5);
            table.Columns[0].NoWrap();
            table.Columns[0].PadTop(-3);
            table.Columns[0].PadBottom(-3);
            this.Tables.Add(table);
        }
    }

    public void RenderTables()
    {
        foreach (var table in this.Tables)
        {
            table.Border(TableBorder.Heavy);
            table.Expand();
           
            AnsiConsole.Write(table);
        }
    }
}