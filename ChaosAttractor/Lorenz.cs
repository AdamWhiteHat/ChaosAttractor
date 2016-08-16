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

		public int MaxOutputX { get; private set; }
		public int MaxOutputY { get; private set; }
		public int MaxOutputZ { get; private set; }

		public TransformDelegate TransformationFunction { get; set; }

		public delegate void TransformDelegate(Lorenz system);

		private decimal a;
		private decimal b;
		private decimal c;

		private decimal x;
		private decimal y;
		private decimal z;

		private decimal dx;
		private decimal dy;
		private decimal dz;

		private decimal time;

		public Lorenz(int scale)
		{
			MaxOutputX = 0;
			MaxOutputY = 0;
			MaxOutputZ = 0;

			Scale = scale;

			a = 10 + PseudoRandomNoise.GetRandom3();
			b = 28 + PseudoRandomNoise.GetRandom3();
			c = (8 + PseudoRandomNoise.GetRandom3()) / 3.0m;

			x = 0.01m; 
			y = + PseudoRandomNoise.GetRandom3();
			z = + PseudoRandomNoise.GetRandom3();

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

			if (TransformationFunction != null)
			{
				TransformationFunction.Invoke(this);
			}

			MaxOutputX = Math.Max(MaxOutputX, Math.Abs((int)dx));
			MaxOutputY = Math.Max(MaxOutputY, Math.Abs((int)dy));
			MaxOutputZ = Math.Max(MaxOutputZ, Math.Abs((int)dz));
		}		

		private int FitRange(decimal n, int scale, int max)
		{
			int val = (int)Math.Abs(n * scale);
			val = Math.Min(val, max - 1);
			if (val >= max - 1) // Truncates value outside of range
			{
				val = 0;
			}
			return val;
		}

		public static class Transform
		{
			public static void Tan(Lorenz system)
			{
				system.x = 6 * (decimal)Math.Tan((double)system.x);
				system.y = 6 * (decimal)Math.Tan((double)system.y);
			}			

			public static void MixedCosTan(Lorenz system)
			{
				system.x = 16 * (decimal)Math.Cos((double)system.x);
				system.y = 8 * (decimal)Math.Tan((double)system.y);
			}
			
			public static void TanCos(Lorenz system)
			{
				system.x = 16 * (decimal)Math.Tan(Math.Cos((double)system.x));
				system.y = 16 * (decimal)Math.Tan(Math.Cos((double)system.y));
			}
			
			public static void TanSin(Lorenz system)
			{
				system.x = 16 * (decimal)Math.Tan(Math.Sin((double)system.x));
				system.y = 16 * (decimal)Math.Tan(Math.Sin((double)system.y));
			}			
		}
	}
}
