using System;
namespace MG.Application.Forms
{
	public class FlowLayoutPanel : Control
	{
		public FlowLayoutPanel()
		{
		}

		public List<IControl> Controls { get; set; } = new List<IControl>();

		public IControl Find(string name)
		{
			if (this.Controls == null || !this.Controls.Any())
			{
				return null;
			}

			var retValue = (from panel in this.Controls
				from control in ((FlowLayoutPanel)panel).Controls
				where control.Name == name
				select control).FirstOrDefault();

			if (retValue != null)
			{
				return retValue;
			}

			return null;
		}
    }
}

