using System;
namespace MG.Application.Forms
{
	public class FlowLayoutPanel : Control
	{
		public FlowLayoutPanel()
		{
		}

		public List<IControl> Controls { get; set; } = new List<IControl>();
    }
}

