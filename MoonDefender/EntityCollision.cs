using System;

namespace MoonDefender
{
	public abstract class EntityCollision : ICollision
	{
		private IEntity left;
		private IEntity right;

		public EntityCollision (IEntity newLeft, IEntity newRight)
		{
			left = newLeft;
			right = newRight;
		}

		public abstract void Run();

		public bool Dead {
			get {
				return !left.Alive || !right.Alive;
			}
		}
	}
}

