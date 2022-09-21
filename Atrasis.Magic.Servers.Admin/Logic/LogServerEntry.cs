using System;
using Atrasis.Magic.Servers.Core.Util;

namespace Atrasis.Magic.Servers.Admin.Logic
{
	// Token: 0x02000019 RID: 25
	public class LogServerEntry
	{
		// Token: 0x060000B5 RID: 181 RVA: 0x00002660 File Offset: 0x00000860
		public LogServerEntry(LogType type, string message, int serverType, int serverId)
		{
			this.Type = type;
			this.Message = message;
			this.ServerType = serverType;
			this.ServerId = serverId;
			this.Time = TimeUtil.GetTimestamp();
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060000B6 RID: 182 RVA: 0x00002690 File Offset: 0x00000890
		public LogType Type { get; }

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060000B7 RID: 183 RVA: 0x00002698 File Offset: 0x00000898
		public string Message { get; }

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060000B8 RID: 184 RVA: 0x000026A0 File Offset: 0x000008A0
		public int ServerType { get; }

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060000B9 RID: 185 RVA: 0x000026A8 File Offset: 0x000008A8
		public int ServerId { get; }

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060000BA RID: 186 RVA: 0x000026B0 File Offset: 0x000008B0
		public int Time { get; }
	}
}
