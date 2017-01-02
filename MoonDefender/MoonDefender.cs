using System;
using System.IO;
using System.Resources;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace MoonDefender
{
	public class MoonDefender : Form
	{
		/* A helper class to manage loading resource fonts */
		private class MemoryFont
		{
			private IntPtr fontPtr;
			private int size;
			public MemoryFont(String resourceName)
			{
				Stream fontStream =
					typeof(MoonDefender)
						.Assembly
						.GetManifestResourceStream(
							resourceName);
				size = (int) fontStream.Length;
				byte[] fontData = new byte[size];
				fontStream.Read(fontData, 0, size);
				fontStream.Close();
				fontPtr = Marshal.AllocHGlobal(size);
				Marshal.Copy (fontData, 0, fontPtr, size);
			}

			~MemoryFont() {
				Marshal.FreeHGlobal(fontPtr);
			}

			public int Size {
				get {
					return size;
				}
			}

			public IntPtr Ptr {
				get {
					return fontPtr;
				}
			}
		}

		private static MemoryFont joystix;

		public static PrivateFontCollection Fonts;

		/* Static Constructor */
		static MoonDefender()
		{
			/* Enable custom fonts */
			System.Windows.Forms.Application.SetCompatibleTextRenderingDefault (true);
			Fonts = new PrivateFontCollection ();
			joystix = new MemoryFont ("MoonDefender.MoonDefender.joystix");
			Fonts.AddMemoryFont (joystix.Ptr, joystix.Size);
		}

		public static void Main(string[] argv)
		{
			MoonDefender game = new MoonDefender ();
			Application.Run (game);
		}

		/* Instance Parts */
		private DateTime time;
		private IScreen activeScreen;
		private IScreen menuScreen;

		public MoonDefender ()
		{
			Text = "Moon Defender #";
			Size = new Size (800, 600);
			try 
			{
				/* Easier to just treat the icon as a separate resource */
				Icon = new Icon(typeof(MoonDefender).Assembly.GetManifestResourceStream("MoonDefender.MoonDefender.icon"));
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
				Environment.Exit (1);
			}

			/* Use the internal double buffer */
			DoubleBuffered = true;
			Paint += new PaintEventHandler (PaintGame);
			time = DateTime.UtcNow;
			menuScreen = new MenuScreen (this);
			activeScreen = new SplashScreen (menuScreen);
			activeScreen.Active = true;

			CenterToScreen ();
		}

		public void PaintGame (Object sender, PaintEventArgs e)
		{
			DateTime lastTime = time;
			time = DateTime.UtcNow;
			/* keep progressing to the next screen until a usable one is available */
			while(!activeScreen.Active)
				activeScreen = activeScreen.Next;
			activeScreen.Draw (e.Graphics, time, time - lastTime);
		}
	}
}

