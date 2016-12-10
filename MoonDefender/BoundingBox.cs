using System;

namespace MoonDefender
{
	public class BoundingBox : IBoundingShape
	{
		private double width;
		private double height;

		public BoundingBox (double newWidth, double newHeight)
		{
			width = newWidth;
			height = newHeight;
		}

		public bool Check(Tuple<double, double> relativePosition)
		{
			return relativePosition.Item1 > 0 && 
				relativePosition.Item1 < width &&
				relativePosition.Item2 > 0 && 
				relativePosition.Item2 < height;
		}
	}
}
