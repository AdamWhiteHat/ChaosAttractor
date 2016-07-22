using System;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ChaosAttractor
{
	public class ComplexModulus
	{
		public int X { get { return (int)_x; } }
		public int Y { get { return (int)_y; } }
		decimal _x;
		decimal _y;
		decimal p;

		private int size;
		private long iteration;

		public ComplexModulus(int maxSize)
		{
			_x = 0m;
			_y = 0m;
			iteration = 1;
			size = maxSize;
			p = 1.4142135623730950488016887242096980785696718753769480731766797379907324784621070388503m;
		}

		public void Step()
		{
			unchecked
			{
				_x = step();
				_y = step();
				_x = _x * size;
				_y = _y * size;
			}
		}

		private decimal step()
		{
			iteration += 1;
			p = (decimal)Math.Abs(Math.Sqrt(Math.Sin(Math.Pow((double)iteration, (double)p)+Math.Tan(Math.E*iteration))));
			return p % 1;

			//n = n * 11011; //n = n * size;			
		}
	}
}
