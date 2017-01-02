using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MoonDefender
{
	public class MenuScreen : Screen
	{
		private List<IOption> options;
		Control host;
		MouseEventHandler mouseDownHandler;
		MouseEventHandler mouseUpHandler;

		private void handleMouseDown (Object sender, MouseEventArgs e) {
			/* Handle mouse down events */
			foreach (IOption option in options) {
				/* Check bounding shape of the option */
			}
		}

		private void handleMouseUp (Object sender, MouseEventArgs e) {
			/* Handle mouse up events */
		}

		public MenuScreen (Control control)
		{
			host = control;
			options = new List<IOption> ();
			mouseDownHandler = new MouseEventHandler (handleMouseDown);
			mouseUpHandler = new MouseEventHandler (handleMouseUp);
		}

		protected override void Open ()
		{
		}
		protected override void Close ()
		{
		}
		protected override void Pause ()
		{
			/* Deregister event handlers */
			host.MouseDown -= mouseDownHandler;
			host.MouseUp -= mouseUpHandler;
		}
		protected override void Unpause ()
		{
			/* Register event handlers */
			host.MouseDown += mouseDownHandler;
			host.MouseUp += mouseUpHandler;
		}
		public override void Draw (Graphics ctx, DateTime currentTime, TimeSpan dt)
		{
			ctx.Clear(Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF));
		}

		public override IScreen Next {
			get {
				return this;
			}
		}
	}
}

