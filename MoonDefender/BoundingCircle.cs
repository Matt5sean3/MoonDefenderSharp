using System;

namespace MoonDefender
{
	public class BoundingCircle : IBoundingShape
	{
		private double radius;

		public BoundingCircle (double newRadius)
		{
			radius = newRadius;
		}

		public bool Check(Vector2 relativeLocation)
		{
			return relativeLocation.Length2 <= radius * radius;
		}
	}
}

