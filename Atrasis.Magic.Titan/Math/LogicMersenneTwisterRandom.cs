using System;

namespace Atrasis.Magic.Titan.Math
{
	// Token: 0x02000015 RID: 21
	public class LogicMersenneTwisterRandom
	{
		// Token: 0x060000A6 RID: 166 RVA: 0x0000494B File Offset: 0x00002B4B
		public LogicMersenneTwisterRandom() : this(324876476)
		{
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x000060EC File Offset: 0x000042EC
		public LogicMersenneTwisterRandom(int seed)
		{
			this.int_0 = new int[624];
			this.int_0[0] = seed;
			for (int i = 1; i < 624; i++)
			{
				seed = 1812433253 * (seed ^ seed >> 30) + 1812433253;
				this.int_0[i] = seed;
			}
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00006148 File Offset: 0x00004348
		public void Initialize(int seed)
		{
			this.int_1 = 0;
			this.int_0[0] = seed;
			for (int i = 1; i < 624; i++)
			{
				seed = 1812433253 * (seed ^ seed >> 30) + 1812433253;
				this.int_0[i] = seed;
			}
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00006194 File Offset: 0x00004394
		public void Generate()
		{
			int i = 1;
			int num = 0;
			while (i <= 624)
			{
				int num2 = (this.int_0[i % this.int_0.Length] & int.MaxValue) + (this.int_0[num] & int.MinValue);
				int num3 = num2 >> 1 ^ this.int_0[(i + 396) % this.int_0.Length];
				if ((num2 & 1) == 1)
				{
					num3 ^= -1727483681;
				}
				this.int_0[num] = num3;
				i++;
				num++;
			}
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00006210 File Offset: 0x00004410
		public int NextInt()
		{
			if (this.int_1 == 0)
			{
				this.Generate();
			}
			int num = this.int_0[this.int_1];
			this.int_1 = (this.int_1 + 1) % 624;
			num ^= num >> 11;
			return num ^ (num << 7 & -1658038656) ^ ((num ^ (num << 7 & -1658038656)) << 15 & -272236544) ^ (num ^ (num << 7 & -1658038656) ^ ((num ^ (num << 7 & -1658038656)) << 15 & -272236544)) >> 18;
		}

		// Token: 0x060000AB RID: 171 RVA: 0x0000629C File Offset: 0x0000449C
		public int Rand(int max)
		{
			int num = this.NextInt();
			if (num < 0)
			{
				num = -num;
			}
			return num % max;
		}

		// Token: 0x04000027 RID: 39
		public const int SEED_COUNT = 624;

		// Token: 0x04000028 RID: 40
		private readonly int[] int_0;

		// Token: 0x04000029 RID: 41
		private int int_1;
	}
}
