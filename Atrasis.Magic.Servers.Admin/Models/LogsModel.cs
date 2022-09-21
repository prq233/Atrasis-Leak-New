using System;
using Atrasis.Magic.Servers.Admin.Logic;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Servers.Admin.Models
{
	// Token: 0x0200000C RID: 12
	public class LogsModel : BaseModel
	{
		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600003F RID: 63 RVA: 0x00002250 File Offset: 0x00000450
		// (set) Token: 0x06000040 RID: 64 RVA: 0x00002258 File Offset: 0x00000458
		public LogicArrayList<LogServerEntry> ServerLogs { get; set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000041 RID: 65 RVA: 0x00002261 File Offset: 0x00000461
		// (set) Token: 0x06000042 RID: 66 RVA: 0x00002269 File Offset: 0x00000469
		public LogicArrayList<LogGameEntry> GameLogs { get; set; }
	}
}
