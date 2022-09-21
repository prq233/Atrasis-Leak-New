using System;

namespace Atrasis.Magic.Servers.Core.Util
{
	// Token: 0x0200000F RID: 15
	public static class TimeUtil
	{
		// Token: 0x0600003B RID: 59 RVA: 0x00009EF8 File Offset: 0x000080F8
		public static int GetTimestamp()
		{
			return (int)DateTime.UtcNow.Subtract(TimeUtil.dateTime_0).TotalSeconds;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00009F20 File Offset: 0x00008120
		public static int GetTimestamp(DateTime utc)
		{
			return (int)utc.Subtract(TimeUtil.dateTime_0).TotalSeconds;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00009F44 File Offset: 0x00008144
		public static long GetTimestampMS()
		{
			return (long)((int)DateTime.UtcNow.Subtract(TimeUtil.dateTime_0).TotalMilliseconds);
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00009F70 File Offset: 0x00008170
		public static long GetTimestampMS(DateTime utc)
		{
			return (long)((int)utc.Subtract(TimeUtil.dateTime_0).TotalMilliseconds);
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00004827 File Offset: 0x00002A27
		public static DateTime GetDateTimeFromTimestamp(int timestamp)
		{
			return TimeUtil.dateTime_0.AddSeconds((double)timestamp);
		}

		// Token: 0x0400001C RID: 28
		private static readonly DateTime dateTime_0 = new DateTime(1970, 1, 1);
	}
}
