using System;
using Atrasis.Magic.Servers.Core.Util;

namespace Atrasis.Magic.Servers.Admin.Logic
{
	// Token: 0x0200001A RID: 26
	public class LogGameEntry
	{
		// Token: 0x060000BB RID: 187 RVA: 0x000026B8 File Offset: 0x000008B8
		public LogGameEntry(LogType type, string message)
		{
			this.Type = type;
			this.Message = message;
			this.Time = TimeUtil.GetTimestamp();
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060000BC RID: 188 RVA: 0x000026D9 File Offset: 0x000008D9
		public LogType Type { get; }

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060000BD RID: 189 RVA: 0x000026E1 File Offset: 0x000008E1
		public string Message { get; }

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060000BE RID: 190 RVA: 0x000026E9 File Offset: 0x000008E9
		public int Time { get; }
	}
}
