using System;

namespace Atrasis.Magic.Servers.Admin.Models
{
	// Token: 0x0200000A RID: 10
	public class ChartData
	{
		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000037 RID: 55 RVA: 0x0000221D File Offset: 0x0000041D
		// (set) Token: 0x06000038 RID: 56 RVA: 0x00002225 File Offset: 0x00000425
		public string[] Labels { get; set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000039 RID: 57 RVA: 0x0000222E File Offset: 0x0000042E
		// (set) Token: 0x0600003A RID: 58 RVA: 0x00002236 File Offset: 0x00000436
		public int[] Datas { get; set; }
	}
}
