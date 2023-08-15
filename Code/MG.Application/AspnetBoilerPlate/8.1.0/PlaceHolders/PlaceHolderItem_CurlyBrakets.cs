namespace MG.Application.AspnetBoilerPlate._8._1._0.PlaceHolders;

public class PlaceHolderItem_CurlyBrakets: PlaceHolderItem_Base
{

    public PlaceHolderItem_CurlyBrakets(string name, string startWith) : base(name)
    {
        this.StartWith = startWith.Replace(" ", "").ToLower();
    }

    private string StartWith { get; set; }
    
    public override string Process(string fileContent)
    {

        // Split the content into lines
        string[] lines = fileContent.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

        int lastIndex = lines.Length - 1;
        string stringFindingClosing = "";
        for (int index = 0; index < lines.Length; index++)
        {
            // Process each line here
            var line = lines[index];
            // if (this.IsStartingLine("declarations:[",line))
            if (this.IsStartingLine(this.StartWith,line))
            {
                lastIndex = index;
                stringFindingClosing += line + Environment.NewLine;
            }

            if (index > lastIndex)
            {
                stringFindingClosing += line + Environment.NewLine;
                if (MatchingBrackets.IsPaired(stringFindingClosing))
                {
                    lines[index] = this.Name + Environment.NewLine + line;
                    break;
                }
               
            }
            
        }
           
        // Convert lines array back to fileContent string
        return string.Join(Environment.NewLine, lines);;
    }
    
}