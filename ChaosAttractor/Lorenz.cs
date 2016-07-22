using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaosAttractor
{
	public class Lorenz
	{
		public int X { get { return FitRange(x, Scale, MaxRange); } }
		public int Y { get { return FitRange(y, Scale, MaxRange); } }
		public int Z { get { return FitRange(z, Scale, MaxRange); } }
		public int Scale { get; set; }
		public int MaxRange { get; set; }

		public int MaxOutput { get; private set; }

		private decimal a;
		private decimal b;
		private decimal c;

		private decimal x;
		private decimal y;
		private decimal z;

		private decimal dx;
		private decimal dy;
		private decimal dz;

		private int mod;
		private decimal time;
		//private static int multiplier = 100000;


		public Lorenz(int modulus)
		{
			MaxOutput = 0;
			mod = modulus;

			a = 10;
			b = 28;
			c = 8 / 3.0m;

			x = 0.01m;
			y = 0;
			z = 0;

			dx = 0;
			dy = 0;
			dz = 0;

			time = 0.01m;
		}

		public void Step()
		{
			dx = ((a * y) - (a * x)) * time;
			dy = ((b * x) - y - (x * z)) * time;
			dz = ((x * y) - (c * z)) * time;
			x = x + dx;
			y = y + dy;
			z = z + dz;

			MaxOutput = Math.Max(MaxOutput, Math.Abs((int)dx));
			MaxOutput = Math.Max(MaxOutput, Math.Abs((int)dy));
			MaxOutput = Math.Max(MaxOutput, Math.Abs((int)dz));
													 
			//MaxOutput = Math.Max(MaxOutput, Math.Abs((int)x));
			//MaxOutput = Math.Max(MaxOutput, Math.Abs((int)y));
			//MaxOutput = Math.Max(MaxOutput, Math.Abs((int)z));
		}

		//public void AddNoise(int a, int b, int c)
		//{
		//	unchecked
		//	{
		//		x = x + a;
		//		y = y + b;
		//		z = z + c;
		//	}
		//}

		private int FitRange(decimal n, int scale, int max)
		{
			int val = (int)Math.Abs(n * scale);
			val = Math.Min(val, max - 1);
			if (val>=max-1) // Truncates value outside of range
			{
				val = 0;
			}
			return val;
		}

		//private decimal FitN(decimal n)
		//{
		//	unchecked
		//	{
		//		if (n < 1)
		//		{
		//			while (n < 1)
		//			{
		//				n = n + mod;
		//				n = n * mod;
		//			}
		//		}

		//		if (n > mod)
		//		{
		//			n = n % mod;
		//		}
		//	}
		//	return n;
		//}
	}
}
