using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;
using System.Security.Cryptography;

namespace ChaosAttractor
{
	public static class PseudoRandomNoise
	{
		private static RNGCryptoServiceProvider rand = new RNGCryptoServiceProvider();

		public static int GetRandom3()
		{
			int sign = GetRandom2();
			int number = GetRandom2();

			if (sign == 1) // Positive
			{
				if (number == 1) // One
				{
					return 1;
				}
				else // Zero
				{
					return 0;
				}
			}
			else // Negative
			{
				if (number == 0) // One
				{
					return -1;
				}
				else // Zero
				{
					// To make all outcomes equally likely, we cant have two paths leading to zero.
					// Solution: One quarter of the time, roll the dice again.
					return GetRandom3();
				}
			}
		}

		public static int GetRandom2()
		{
			return GetRandomBool() ? -1 : 1;
		}

		public static bool GetRandomBool()
		{
			return (GetByte() % 2 == 0);
		}

		private static byte GetByte()
		{
			byte[] result = new byte[1];
			rand.GetNonZeroBytes(result);
			return result[0];
		}
	}
}
