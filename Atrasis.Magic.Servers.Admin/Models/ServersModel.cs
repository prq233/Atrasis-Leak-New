using System;
using System.Collections.Generic;
using Atrasis.Magic.Servers.Admin.Logic;

namespace Atrasis.Magic.Servers.Admin.Models
{
	// Token: 0x0200000E RID: 14
	public class ServersModel : BaseModel
	{
		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000047 RID: 71 RVA: 0x00002283 File Offset: 0x00000483
		// (set) Token: 0x06000048 RID: 72 RVA: 0x0000228B File Offset: 0x0000048B
		public Dictionary<string, List<ServerPerformance>> Servers { get; set; }
	}
}
