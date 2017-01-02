using System;
using System.Drawing;

namespace MoonDefender
{
	public interface IScreen
	{
		bool Active {
			get;
			set;
		}
		bool Paused {
			get;
			set;
		}
		IScreen Next {
			get;
		}
		void Draw (Graphics ctx, DateTime currentTime, TimeSpan dt);
	}
}

