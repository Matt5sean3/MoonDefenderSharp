using System;
using System.Drawing;

namespace MoonDefender
{
	public interface IOption
	{
		Vector2 Position {
			get;
		}
		IBoundingShape Shape {
			get;
		}
		void Execute ();
		void Draw (Graphics ctx, DateTime currentTime, TimeSpan dt);
	}
}

