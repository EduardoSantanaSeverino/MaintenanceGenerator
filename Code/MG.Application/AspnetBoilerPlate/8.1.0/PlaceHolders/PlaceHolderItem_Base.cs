using MG.Application.Generic;

namespace MG.Application.AspnetBoilerPlate._8._1._0.PlaceHolders;

public abstract class PlaceHolderItem_Base : IPlaceHolderItem
{
    public PlaceHolderItem_Base(string name)
    {
        this.Name = name;
    }
    public string Name { get; }

    public virtual bool IsStartingLine(string startWith,string line)
    {
        if (string.IsNullOrWhiteSpace(line))
        {
            return false;
        }
        return line.ToLower().Trim().Replace(" ", "").StartsWith(startWith);
    }
    
    public virtual bool IsStartingLineWithSpace(string startWith,string line)
    {
        if (string.IsNullOrWhiteSpace(line))
        {
            return false;
        }
        return line.ToLower().Trim().Replace(" ", "").StartsWith(startWith);
    }

    public virtual bool IsImportLine(string line)
    {
        if (string.IsNullOrWhiteSpace(line))
        {
            return false;
        }
        return line.ToLower().Trim().Replace(" ", "").StartsWith("import{");
    }

    public virtual bool IsSpaceLine(string line)
    {
        return string.IsNullOrWhiteSpace(line);
    }
        
    public virtual bool IsCommentLine(string line)
    {
        if (string.IsNullOrWhiteSpace(line))
        {
            return false;
        }
        return line.ToLower().Trim().Replace(" ", "").StartsWith("//");
    }

    public abstract string Process(string fileContent);
}
