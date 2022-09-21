using System;
using System.Collections.Generic;
using Atrasis.Magic.Servers.Core.Util;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Admin.Logic
{
	// Token: 0x0200001B RID: 27
	public class LogClientEventEntry
	{
		// Token: 0x060000BF RID: 191 RVA: 0x000026F1 File Offset: 0x000008F1
		public LogClientEventEntry(LogClientEventEntry.EventType type, LogicLong accountId, Dictionary<string, object> args)
		{
			this.Type = type;
			this.AccountId = accountId;
			this.Args = args;
			this.Time = TimeUtil.GetTimestamp();
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060000C0 RID: 192 RVA: 0x00002719 File Offset: 0x00000919
		public LogClientEventEntry.EventType Type { get; }

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060000C1 RID: 193 RVA: 0x00002721 File Offset: 0x00000921
		public LogicLong AccountId { get; }

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060000C2 RID: 194 RVA: 0x00002729 File Offset: 0x00000929
		public Dictionary<string, object> Args { get; }

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060000C3 RID: 195 RVA: 0x00002731 File Offset: 0x00000931
		public int Time { get; }

		// Token: 0x02000030 RID: 48
		public enum EventType
		{
			// Token: 0x04000093 RID: 147
			OUT_OF_SYNC
		}
	}
}
