using System;
using Atrasis.Magic.Logic.Data;

namespace Atrasis.Magic.Logic.Time
{
	// Token: 0x02000015 RID: 21
	public class LogicTime
	{
		// Token: 0x060000E2 RID: 226 RVA: 0x00002939 File Offset: 0x00000B39
		public void IncreaseTick()
		{
			this.int_0++;
			if ((this.int_0 & 3) == 0)
			{
				this.int_1++;
			}
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00002961 File Offset: 0x00000B61
		public bool IsFullTick()
		{
			return (this.int_0 + 1 & 3) == 0;
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00002970 File Offset: 0x00000B70
		public int GetTick()
		{
			return this.int_0;
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00002978 File Offset: 0x00000B78
		public int GetFullTick()
		{
			return this.int_1;
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00002980 File Offset: 0x00000B80
		public int GetTotalMS()
		{
			return this.int_1 << 6;
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x0000298A File Offset: 0x00000B8A
		public static int GetMSInTicks(int time)
		{
			if (LogicDataTables.GetGlobals().MoreAccurateTime())
			{
				return time / 16;
			}
			return time * 60 / 1000;
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x000029A7 File Offset: 0x00000BA7
		public static int GetSecondsInTicks(int time)
		{
			if (LogicDataTables.GetGlobals().MoreAccurateTime())
			{
				return (int)(1000L * (long)time / 16L);
			}
			return time * 60;
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x000029D1 File Offset: 0x00000BD1
		public static int GetTicksInSeconds(int tick)
		{
			if (LogicDataTables.GetGlobals().MoreAccurateTime())
			{
				return (int)(16L * (long)tick / 1000L);
			}
			return tick / 60;
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00016EFC File Offset: 0x000150FC
		public static int GetTicksInMS(int tick)
		{
			if (LogicDataTables.GetGlobals().MoreAccurateTime())
			{
				return (int)(16L * (long)tick);
			}
			int num = 1000 * (tick / 60);
			int num2 = tick % 60;
			if (num2 > 0)
			{
				num += 2133 * num2 >> 7;
			}
			return num;
		}

		// Token: 0x060000EB RID: 235 RVA: 0x000029FB File Offset: 0x00000BFB
		public static int GetCooldownSecondsInTicks(int time)
		{
			if (LogicDataTables.GetGlobals().MoreAccurateTime())
			{
				return (int)(1000L * (long)time / 64L);
			}
			return time * 15;
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00002A25 File Offset: 0x00000C25
		public static int GetCooldownTicksInSeconds(int time)
		{
			if (LogicDataTables.GetGlobals().MoreAccurateTime())
			{
				return (int)(((long)time << 6) / 1000L);
			}
			return time / 15;
		}

		// Token: 0x0400006A RID: 106
		private int int_0;

		// Token: 0x0400006B RID: 107
		private int int_1;
	}
}
