using System;
using System.Collections.Generic;

namespace MoonDefender
{
	public class CollisionGroup : List<ICollision>, ICollision
	{
		public void Run() {
			this.RemoveAll (collision => collision.Dead);
			foreach (ICollision collision in this) {
				collision.Run ();
			}	
		}
		public bool Dead {
			get {
				this.RemoveAll (collision => collision.Dead);
				return this.Count <= 0;
			}
		}
	}
}

