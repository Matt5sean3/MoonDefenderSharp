using System;

namespace MoonDefender
{
	public class Vector2
	{
		private double x;
		private double y;

		public double X {
			get {
				return x;
			}
			set {
				x = value;
			}
		}

		public double Y {
			get {
				return y;
			}
			set {
				x = value;
			}
		}

		public Vector2 ()
		{
			x = 0;
			y = 0;
		}

		public Vector2(double newX, double newY)
		{
			x = newX;
			y = newY;
		}

		public double Length2 {
			get {
				return X * X + Y * Y;
			}
		}

		public double Length {
			get {
				return Math.Sqrt (this.Length2);
			}
		}

		public Vector2 Normal
		{
			get {
				double magnitude = Length;
				return new Vector2 (X / Length, Y / Length);
			}
		}

		public static Vector2 operator+(Vector2 left, Vector2 right)
		{
			return new Vector2 (
				left.X + right.X,
				left.Y + right.Y);
		}

		public static Vector2 operator-(Vector2 left, Vector2 right) {
			return new Vector2 (
				left.X - right.X,
				left.Y - right.Y);
		}

		public static Vector2 operator*(Vector2 left, double right) {
			return new Vector2 (
				left.X * right,
				left.Y * right);
		}
	}
}

