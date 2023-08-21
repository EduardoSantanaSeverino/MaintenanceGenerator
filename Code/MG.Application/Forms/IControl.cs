using System;
namespace MG.Application.Forms
{
	public interface IControl
	{
		string Name { get; set; }
		string Text { get; set; }
		string Path { get; set; }
	}
}

