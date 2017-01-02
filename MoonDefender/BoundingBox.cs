using System;

namespace MoonDefender
{
	public class BoundingBox : IBoundingShape
	{
		Vector2 offset;
		Vector2 dims;

		public BoundingBox (
			Vector2 newOffset,
			Vector2 newDims)
		{
			offset = newOffset;
			dims = newDims;
		}

		public bool Check(Vector2 relativePosition)
		{
			Vector2 position = relativePosition - offset;
			return position.X >= 0 && 
				position.X <= dims.X &&
				position.Y >= 0 && 
				position.Y <= dims.Y;
		}
	}
}
