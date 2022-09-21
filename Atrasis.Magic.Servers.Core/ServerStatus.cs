using System;
using System.Runtime.CompilerServices;

namespace Atrasis.Magic.Servers.Core
{
	// Token: 0x02000009 RID: 9
	public static class ServerStatus
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000026 RID: 38 RVA: 0x00004794 File Offset: 0x00002994
		// (set) Token: 0x06000027 RID: 39 RVA: 0x0000479B File Offset: 0x0000299B
		public static ServerStatus.ServerStatusChanged OnServerStatusChanged { get; set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000028 RID: 40 RVA: 0x000047A3 File Offset: 0x000029A3
		// (set) Token: 0x06000029 RID: 41 RVA: 0x000047AA File Offset: 0x000029AA
		public static ServerStatusType Status { get; private set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600002A RID: 42 RVA: 0x000047B2 File Offset: 0x000029B2
		// (set) Token: 0x0600002B RID: 43 RVA: 0x000047B9 File Offset: 0x000029B9
		public static int Time { get; private set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600002C RID: 44 RVA: 0x000047C1 File Offset: 0x000029C1
		// (set) Token: 0x0600002D RID: 45 RVA: 0x000047C8 File Offset: 0x000029C8
		public static int NextTime { get; private set; }

		// Token: 0x0600002E RID: 46 RVA: 0x000047D0 File Offset: 0x000029D0
		public static void SetStatus(ServerStatusType type, int time, int nextTime)
		{
			ServerStatus.Status = type;
			ServerStatus.Time = time;
			ServerStatus.NextTime = nextTime;
			if (ServerStatus.OnServerStatusChanged != null)
			{
				ServerStatus.OnServerStatusChanged(type, time, nextTime);
			}
		}

		// Token: 0x04000013 RID: 19
		[CompilerGenerated]
		private static ServerStatus.ServerStatusChanged serverStatusChanged_0;

		// Token: 0x04000014 RID: 20
		[CompilerGenerated]
		private static ServerStatusType serverStatusType_0;

		// Token: 0x04000015 RID: 21
		[CompilerGenerated]
		private static int int_0;

		// Token: 0x04000016 RID: 22
		[CompilerGenerated]
		private static int int_1;

		// Token: 0x0200000A RID: 10
		// (Invoke) Token: 0x06000030 RID: 48
		public delegate void ServerStatusChanged(ServerStatusType type, int time, int nextTime);
	}
}
