using System;
using System.Drawing;
using System.Collections.Generic;

namespace MoonDefender
{
	public class Bullet : Ballistic
	{
		private bool live;

		public Bullet (
			double newMass,
			Vector2 newPosition,
			Vector2 newVelocity) : 
			base(newMass, newPosition, newVelocity)
		{

			live = true;
		}

		public override bool Alive {
			get {
				return live;
			}
		}

		public override void Draw(Graphics gfx, Pen pen, int currentTime, int dt) {
			Point[] bullet_curve = { 
				new Point(-5, -5),
				new Point(0, 5),
				new Point(5, -5)
			};
			gfx.DrawCurve(pen, bullet_curve);	
		}

		public override IBoundingShape Bounds {
			get {
				return new BoundingBox(
					new Vector2(10, 10), 
					new Vector2(-5, -5));
			}
		}

		public override int MaxHealth {
			get {
				return 1;
			}
		}

		public override int CurrentHealth {
			get {
				if (this.Alive)
					return 1;
				else
					return 0;
			}
		}
	}
}

