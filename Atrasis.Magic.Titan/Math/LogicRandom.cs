using System;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Titan.Math
{
	// Token: 0x02000016 RID: 22
	public class LogicRandom
	{
		// Token: 0x060000AC RID: 172 RVA: 0x000042C9 File Offset: 0x000024C9
		public LogicRandom()
		{
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00004958 File Offset: 0x00002B58
		public LogicRandom(int seed)
		{
			this.int_0 = seed;
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00004967 File Offset: 0x00002B67
		public int GetIteratedRandomSeed()
		{
			return this.int_0;
		}

		// Token: 0x060000AF RID: 175 RVA: 0x0000496F File Offset: 0x00002B6F
		public void SetIteratedRandomSeed(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x000062BC File Offset: 0x000044BC
		public int Rand(int max)
		{
			if (max > 0)
			{
				int num = this.int_0;
				if (num == 0)
				{
					num = -1;
				}
				int num2 = num ^ num << 13 ^ (num ^ num << 13) >> 17;
				int num3 = num2 ^ 32 * num2;
				this.int_0 = num3;
				if (num3 < 0)
				{
					num3 = -num3;
				}
				return num3 % max;
			}
			return 0;
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00006304 File Offset: 0x00004504
		public int IterateRandomSeed()
		{
			int num = this.int_0;
			if (num == 0)
			{
				num = -1;
			}
			int num2 = num ^ num << 13 ^ (num ^ num << 13) >> 17;
			return num2 ^ 32 * num2;
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00004978 File Offset: 0x00002B78
		public void Decode(ByteStream stream)
		{
			this.int_0 = stream.ReadInt();
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00004986 File Offset: 0x00002B86
		public void Encode(ChecksumEncoder stream)
		{
			stream.WriteInt(this.int_0);
		}

		// Token: 0x0400002A RID: 42
		private int int_0;
	}
}
