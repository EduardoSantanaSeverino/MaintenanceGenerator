namespace MG.Application.Forms;

public class Control : IControl
{ 
    public Control(string name, string text)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Text = text ?? throw new ArgumentNullException(nameof(text));
    }
    
    public Control()
    {
    }
    
    public string Name { get; set; }
    public string Text { get; set; }
}
