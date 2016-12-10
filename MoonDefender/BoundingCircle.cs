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

		public bool Check(Tuple<double, double> relativeLocation)
		{
			return relativeLocation.Item1 * relativeLocation.Item1 + 
				relativeLocation.Item2 * relativeLocation.Item2 <=
				radius * radius;
		}
	}
}

