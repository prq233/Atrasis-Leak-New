using System;
using Atrasis.Magic.Servers.Admin.Logic;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Servers.Admin.Models
{
	// Token: 0x0200000D RID: 13
	public class ServerEventModel : BaseModel
	{
		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000044 RID: 68 RVA: 0x00002272 File Offset: 0x00000472
		// (set) Token: 0x06000045 RID: 69 RVA: 0x0000227A File Offset: 0x0000047A
		public LogicArrayList<LogServerEventEntry> Events { get; set; }
	}
}
