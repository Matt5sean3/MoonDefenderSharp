using System;

namespace MoonDefender
{
	public interface IBoundingShape
	{
		bool Check(Vector2 relativePosition);
	}
}
