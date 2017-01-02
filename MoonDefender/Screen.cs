using System;
using System.Drawing;

namespace MoonDefender
{
	public abstract class Screen : IScreen
	{
		private bool paused, active;
		private IScreen next;

		public Screen (IScreen nextScreen)
		{
			next = nextScreen;
			active = false;
			paused = true;
		}

		public Screen ()
		{
			next = this;
			active = false;
			paused = true;
		}

		/* Sub-classes implement these */

		/* Initialization actions */
		protected abstract void Open ();

		/* Clean-up actions */
		protected abstract void Close ();

		/* Unpausing actions */
		protected abstract void Unpause ();

		/* Pausing actions */
		protected abstract void Pause ();

		public bool Paused 
		{
			get
			{
				return paused;
			}
			set 
			{
				if (value == paused) /* nop */
					return;
				else if (value) {
					/* pause */
					paused = true;
					Pause ();
				} else {
					/* unpause */
					/* Can't unpause an inactive screen */
					if (!active) /* TODO throw an exception here */
						return;
					paused = false;
					Unpause ();
				}
			}
		}

		public bool Active 
		{
			get {
				return active;
			}
			set {
				if (active == value) /* nop */
					return;
				else if (value) {
					active = true;
					Open ();
					Paused = false; /* unpause on start */
				} else {
					Paused = true; /* pause before close */
					Close ();
					active = false;
				}
			}
		}

		/* Still gets left to subclasses */
		public abstract void Draw(Graphics ctx, DateTime currentTime, TimeSpan dt);
		public virtual IScreen Next {
			get {
				next.Active = true;
				return next;
			}
		}
	}
}

