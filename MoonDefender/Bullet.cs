using System;
using System.Drawing;
using System.Collections.Generic;

namespace MoonDefender
{
	public class Bullet : IEntity
	{
		private double mass;
		private bool live;
		private Tuple<double, double> position;
		private Tuple<double, double> velocity;
		private List<IEntity> gravitons;

		public Bullet (
			double newMass,
			Tuple<double, double> newPosition,
			Tuple<double, double> newVelocity)
		{
			live = true;
			mass = newMass;
			position = newPosition;
			velocity = newVelocity;
		}

		public 

		public Tuple<double, double> Position {
			get {
				return position;
			}
		}

		public bool Alive {
			get {
				return live;
			}
		}

		public void Draw(Graphics gfx, Pen pen, int currentTime, int dt) {
			Point[] bullet_curve = { 
				new Point(-5, 0),
				new Point(0, 10),
				new Point(5, 0)
			};
			gfx.DrawCurve(pen, bullet_curve);	
		}

		public void Step(int dt) {
			/* Clear out dead peers */
			gravitons.RemoveAll (peer => !peer.Alive);

			Tuple<double, double> acceleration = 
				new Tuple<double, double>(0.0, 0.0);
			/* Calculate Acceleration due to gravity */
			foreach (IEntity peer in gravitons) {
				if (peer.Mass <= 0.0)
					continue;
				double dx = peer.Position.Item1 - this.Position.Item1;
				double dy = peer.Position.Item2 - this.Position.Item2;
				double r2 = dx * dx + dy * dy;
				double r = Math.Sqrt (r2);
				Tuple<double, double> direction = new Tuple<double, double>(
					dx / r,
					dy / r);

				double acceleration_magnitude = Constants.Gravity * peer.Mass * this.Mass / r2;
				acceleration = new Tuple<double, double>(
					acceleration.Item1 + direction.Item1 * acceleration_magnitude,
					acceleration.Item2 + direction.Item2 * acceleration_magnitude);
			}

			/* Calculate change in position */
			position = new Tuple<double, double>(
				position.Item1 + velocity.Item1 * dt,
				position.Item2 + velocity.Item2 * dt
			);

			/* Calculate change in velocity */
		}

		public void AddPeer(IEntity peer) {
			gravitons.Add (peer);
		}

	}
}

