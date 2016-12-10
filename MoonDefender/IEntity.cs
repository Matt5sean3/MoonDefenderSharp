using System;
using System.Drawing;

namespace MoonDefender
{
	/*
	 * The most generic game object that has position, velocity, and can be drawn.
	 */
	public interface IEntity
	{
		/*
		 *  The current position of the object
		 */
		Tuple<double, double> Position 
		{
			get;
		}

		double Mass {
			get;
		}

		/*
		 *  Advance the object through one step of the simulation
		 */
		void Step (int dt);

		/*
		 *  Add an object with mass to calculate gravity against
		 */
		void AddPeer (IMass mass);

		/*
		 *  The bounding box to use for the object
		 */
		IBoundingShape Bounds
		{
			get;
		}

		/*
		 *  Maximum health of the entity
		 */
		int MaxHealth {
			get;
		}

		/*
		 *  The amount of health the entity has left
		 */
		int CurrentHealth {
			get;
		}

		/*
		 *  Whether the object is still alive
		 */
		bool Alive {
			get;
		}

		/*
		 *  Draw the object
		 */
		void Draw(Graphics gfx, Pen pen, int currentTime, int dt);

	}
}

