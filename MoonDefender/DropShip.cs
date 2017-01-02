using System;
using System.Drawing;

namespace MoonDefender
{
	public class DropShip : Ballistic
	{
		private int health;
		private int maxHealth;

		public DropShip (
			double newMass,
			Vector2 newPosition,
			Vector2 newVelocity,
			int newHealth) :
			base(newMass, newPosition, newVelocity)
		{
			maxHealth = newHealth;
			health = newHealth;
		}

		public override bool Alive {
			get {
				return health > 0;
			}
		}

		public override void Draw (Graphics gfx, Pen pen, int currentTime, int dt)
		{
			/*
			gfx.FillPie(
				new SolidBrush (new ColorConverter ()),
				new Rectangle(-5, -5, 5, 5),
				0,
				360);
			*/
		}

		public override IBoundingShape Bounds {
			get {
				return new BoundingCircle (10.0);
			}
		}

		public override int MaxHealth {
			get {
				return maxHealth;
			}
		}

		public override int CurrentHealth {
			get {
				return health;
			}
		}
	}
}

