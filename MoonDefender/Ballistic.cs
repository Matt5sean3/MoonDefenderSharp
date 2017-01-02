using System;
using System.Collections.Generic;
using System.Drawing;

namespace MoonDefender
{
	public abstract class Ballistic : IEntity
	{

		private double mass;
		private Vector2 position;
		private Vector2 velocity;
		private List<IEntity> gravitons;

		public Ballistic (
			double newMass,
			Vector2 newPosition,
			Vector2 newVelocity)
		{
			mass = newMass;
			position = newPosition;
			velocity = newVelocity;
			gravitons = new List<IEntity> ();
		}

		public double Mass {
			get {
				return mass;
			}
		}

		public Vector2 Position {
			get {
				return position;
			}
		}

		public void AddPeer(IEntity graviton) {
			gravitons.Add (graviton);
		}

		public void Step(int dt) {
			/* Clear out dead peers */
			gravitons.RemoveAll (peer => !peer.Alive);

			Vector2 acceleration = 
				new Vector2(0.0, 0.0);
			/* Calculate Acceleration due to gravity */
			foreach (IEntity peer in gravitons) {
				if (peer.Mass <= 0.0)
					continue;
				Vector2 diff = peer.Position - this.Position;
				acceleration = acceleration + diff.Normal * (Constants.Gravity * peer.Mass / diff.Length2);
			}

			/* Calculate change in position */
			position += acceleration * (0.5 * dt * dt) + velocity * dt;

			/* Calculate change in velocity */
			velocity += acceleration * dt;
		}

		public abstract IBoundingShape Bounds {
			get;
		}

		public abstract int MaxHealth {
			get;
		}

		public abstract int CurrentHealth {
			get;
		}

		public abstract bool Alive {
			get;
		}

		public abstract void Draw(Graphics gfx, Pen pen, int currentTime, int dt);
	}
}

