using System;
using Atrasis.Magic.Servers.Core.Util;

namespace Atrasis.Magic.Servers.Admin.Logic
{
	// Token: 0x0200001C RID: 28
	public class LogServerEventEntry
	{
		// Token: 0x060000C4 RID: 196 RVA: 0x00002739 File Offset: 0x00000939
		public LogServerEventEntry(string type, string message)
		{
			this.Type = type;
			this.Message = message;
			this.Time = TimeUtil.GetTimestamp();
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060000C5 RID: 197 RVA: 0x0000275A File Offset: 0x0000095A
		// (set) Token: 0x060000C6 RID: 198 RVA: 0x00002762 File Offset: 0x00000962
		public string Type { get; set; }

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060000C7 RID: 199 RVA: 0x0000276B File Offset: 0x0000096B
		// (set) Token: 0x060000C8 RID: 200 RVA: 0x00002773 File Offset: 0x00000973
		public string Message { get; set; }

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060000C9 RID: 201 RVA: 0x0000277C File Offset: 0x0000097C
		public int Time { get; }
	}
}
