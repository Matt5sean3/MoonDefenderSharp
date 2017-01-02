using System;
using System.Drawing;
using System.Collections.Generic;
using System.IO;

namespace MoonDefender
{
	public class SplashScreen : Screen
	{
		private Image splashImage;
		private StringFormat captionFormat;
		private List<String> introTexts;
		private String introText;
		private bool starting;
		private DateTime startTime;
		private Random rng;
		public SplashScreen (IScreen nextScreen) :
			base(nextScreen)
		{
			starting = true;
			splashImage = new Bitmap(
				typeof(SplashScreen)
				.Assembly
				.GetManifestResourceStream(
					"MoonDefender.SplashScreen.image"));
			captionFormat = new StringFormat (StringFormatFlags.NoWrap);
			captionFormat.Alignment = StringAlignment.Center;
			captionFormat.LineAlignment = StringAlignment.Near;
			rng = new Random ();
			/* Parse intro text */
			introTexts = new List<String> ();
			try {
				using (StreamReader sr = 
					new StreamReader(
						typeof(SplashScreen)
						.Assembly
						.GetManifestResourceStream (
							"MoonDefender.SplashScreen.introText"))) {
					while(!sr.EndOfStream)
						introTexts.Add(sr.ReadLine());
				}
			}
			catch(Exception e)
			{
				Console.WriteLine ("Failed to get intro text");
				Console.WriteLine (e.Message);
				/* It's recoverable */
				introTexts.Add("Don't know what to say!");
			}
		}

		/* Open and Close don't really matter in this case */
		protected override void Open() {
			starting = true;
			introText = introTexts[rng.Next () % introTexts.Count];
		}

		protected override void Close() {
		}

		protected override void Pause() {
		}

		protected override void Unpause() {
		}

		public override void Draw(Graphics ctx, DateTime currentTime, TimeSpan dt)
		{
			if (starting)
				startTime = currentTime;
			/* Grab the joystix font */

			ctx.Clear(Color.FromArgb(0xFF, 0x99, 0x99, 0x99));
			ctx.DrawString (
				"Created at",
				new Font(MoonDefender.Fonts.Families [0], 40),
				Brushes.Black,
				new PointF(400, 40),
				captionFormat);
			ctx.DrawString (introText,
				new Font (MoonDefender.Fonts.Families [0], 16),
				Brushes.Black,
				new PointF (400, 525),
				captionFormat);

			ctx.DrawImage (splashImage, 0, 0, 800, 600);

			/* Check that enough time has elapsed to close */
			if (currentTime - startTime < new TimeSpan (0, 0, 5))
				Active = false;
		}
	}
}

