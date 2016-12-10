using System;
using System.Windows;

namespace MoonDefender
{
	public class MoonDefender
	{
		public static void Main(string[] argv)
		{
			MoonDefender game = new MoonDefender ();
			game.Run ();
		}
		public MoonDefender ()
		{
		}
		public void Run() 
		{
			Console.WriteLine ("Ran Moon Defender in C#!");
		}
	}
}

