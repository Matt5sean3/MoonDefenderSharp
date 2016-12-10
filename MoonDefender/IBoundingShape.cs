using System;

namespace MoonDefender
{
	public interface IBoundingShape
	{
		bool Check(Tuple<double, double> relativePosition);
	}
}
