namespace MG.Application.Generic;

public interface IPlaceHolderItem
{
    string Name { get; }
    string Process(string fileContent);
}