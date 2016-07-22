using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaosAttractor
{
	public class Lorenz
	{
		public decimal x { get; private set; }
		public decimal y { get; private set; }
		public decimal z { get; private set; }

		private decimal a;
		private decimal b;
		private decimal c;

		private decimal dx;
		private decimal dy;
		private decimal dz;

		private int mod;
		private decimal time;
		private static int multiplier = 100000;

		public Lorenz(int modulus)
		{
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

			//FitRange();
		}

		public void AddNoise(int a, int b, int c)
		{
			unchecked
			{
				x = x + a;
				y = y + b;
				z = z + c;
			}
		}

		private void FitRange()
		{
			unchecked
			{
				x = FitN(x);
				y = FitN(y);
				z = FitN(z);
			}
		}

		private decimal FitN(decimal n)
		{
			unchecked
			{
				if (n < 1)
				{
					while (n < 1)
					{
						n = n + mod;
						n = n * mod;
					}
				}

				if (n > mod)
				{
					n = n % mod;
				}
			}
			return n;
		}
	}
}
