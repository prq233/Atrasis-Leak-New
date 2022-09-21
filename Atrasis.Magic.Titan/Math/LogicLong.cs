using System;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Titan.Math
{
	// Token: 0x02000013 RID: 19
	public class LogicLong
	{
		// Token: 0x06000084 RID: 132 RVA: 0x000042C9 File Offset: 0x000024C9
		public LogicLong()
		{
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00004756 File Offset: 0x00002956
		public LogicLong(int highInteger, int lowInteger)
		{
			this.int_0 = highInteger;
			this.int_1 = lowInteger;
		}

		// Token: 0x06000086 RID: 134 RVA: 0x0000476C File Offset: 0x0000296C
		public static long ToLong(int highValue, int lowValue)
		{
			return (long)highValue << 32 | (long)((ulong)lowValue);
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00004776 File Offset: 0x00002976
		public LogicLong Clone()
		{
			return new LogicLong(this.int_0, this.int_1);
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00004789 File Offset: 0x00002989
		public bool IsZero()
		{
			return this.int_0 == 0 && this.int_1 == 0;
		}

		// Token: 0x06000089 RID: 137 RVA: 0x0000479E File Offset: 0x0000299E
		public int GetHigherInt()
		{
			return this.int_0;
		}

		// Token: 0x0600008A RID: 138 RVA: 0x000047A6 File Offset: 0x000029A6
		public int GetLowerInt()
		{
			return this.int_1;
		}

		// Token: 0x0600008B RID: 139 RVA: 0x000047AE File Offset: 0x000029AE
		public void Decode(ByteStream stream)
		{
			this.int_0 = stream.ReadInt();
			this.int_1 = stream.ReadInt();
		}

		// Token: 0x0600008C RID: 140 RVA: 0x000047C8 File Offset: 0x000029C8
		public void Encode(ChecksumEncoder stream)
		{
			stream.WriteInt(this.int_0);
			stream.WriteInt(this.int_1);
		}

		// Token: 0x0600008D RID: 141 RVA: 0x000047E2 File Offset: 0x000029E2
		public int HashCode()
		{
			return this.int_1 + 31 * this.int_0;
		}

		// Token: 0x0600008E RID: 142 RVA: 0x000047F4 File Offset: 0x000029F4
		public override int GetHashCode()
		{
			return this.HashCode();
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00005D18 File Offset: 0x00003F18
		public override bool Equals(object obj)
		{
			if (obj != null)
			{
				LogicLong logicLong = obj as LogicLong;
				if (logicLong != null)
				{
					return logicLong.int_0 == this.int_0 && logicLong.int_1 == this.int_1;
				}
			}
			return false;
		}

		// Token: 0x06000090 RID: 144 RVA: 0x000047FC File Offset: 0x000029FC
		public bool Equals(LogicLong logicLong)
		{
			return logicLong != null && logicLong.int_0 == this.int_0 && logicLong.int_1 == this.int_1;
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00004821 File Offset: 0x00002A21
		public static bool Equals(LogicLong a1, LogicLong a2)
		{
			if (a1 != null && a2 != null)
			{
				return a1.int_0 == a2.int_0 && a1.int_1 == a2.int_1;
			}
			return a1 == null && a2 == null;
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00004851 File Offset: 0x00002A51
		public override string ToString()
		{
			return string.Format("LogicLong({0}-{1})", this.int_0, this.int_1);
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00004873 File Offset: 0x00002A73
		public static implicit operator LogicLong(long Long)
		{
			return new LogicLong((int)(Long >> 32), (int)Long);
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00004881 File Offset: 0x00002A81
		public static implicit operator long(LogicLong Long)
		{
			return (long)Long.int_0 << 32 | (long)((ulong)Long.int_1);
		}

		// Token: 0x04000022 RID: 34
		private int int_0;

		// Token: 0x04000023 RID: 35
		private int int_1;
	}
}
