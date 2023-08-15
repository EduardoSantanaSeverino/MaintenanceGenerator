namespace MG.Application.AspnetBoilerPlate._8._1._0.PlaceHolders;

public class PlaceHolderItem_app_module_ts_place2 : PlaceHolderItem_Base
{
        
    public PlaceHolderItem_app_module_ts_place2():base("///app.module.ts.place2///") {}

    public override string Process(string fileContent)
    {

        // Split the content into lines
        string[] lines = fileContent.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

        int lastIndex = lines.Length - 1;
            
        for (int index = 0; index < lines.Length; index++)
        {
            // Process each line here
            var line = lines[index];
            if (this.IsStartingLine("declarations:[",line))
            {
                lastIndex = index;
            }

            if (index > lastIndex && this.IsStartingLine("]", line))
            {
                lines[index] = this.Name + Environment.NewLine + line;
                break;
            }
               
        }
           
        // Convert lines array back to fileContent string
        return string.Join(Environment.NewLine, lines);;
    }
    
}