namespace MG.Application.AspnetBoilerPlate._8._1._0.PlaceHolders;

public class PlaceHolderItem_app_module_ts_place1 : PlaceHolderItem_Base
{
        
    public PlaceHolderItem_app_module_ts_place1():base("///app.module.ts.place1///") {}

    public override string Process(string fileContent)
    {

        // Split the content into lines
        string[] lines = fileContent.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

        int lastImportIndex = 0;
            
        for (int index = 0; index < lines.Length; index++)
        {
            // Process each line here
            var line = lines[index];
            if (this.IsImportLine(line))
            {
                lastImportIndex = index;
            }

            if (!this.IsImportLine(line) && !this.IsCommentLine(line) && !this.IsSpaceLine(line))
            {
                lines[lastImportIndex] += Environment.NewLine + this.Name;
                break;
            }
        }
           
        // Convert lines array back to fileContent string
        return string.Join(Environment.NewLine, lines);;
    }
}
