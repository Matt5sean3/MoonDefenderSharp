using System;

namespace MoonDefender
{
	public interface ICollision
	{
		void Run();
		bool Dead {
			get;
		}
	}
}
	