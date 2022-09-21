using System;

namespace Atrasis.Magic.Servers.Admin.Logic
{
	// Token: 0x02000020 RID: 32
	public class ClusterPerformance
	{
		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060000E0 RID: 224 RVA: 0x000028B2 File Offset: 0x00000AB2
		// (set) Token: 0x060000E1 RID: 225 RVA: 0x000028BA File Offset: 0x00000ABA
		public int Ping { get; set; }

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060000E2 RID: 226 RVA: 0x000028C3 File Offset: 0x00000AC3
		// (set) Token: 0x060000E3 RID: 227 RVA: 0x000028CB File Offset: 0x00000ACB
		public int SessionCount { get; set; }

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060000E4 RID: 228 RVA: 0x000028D4 File Offset: 0x00000AD4
		// (set) Token: 0x060000E5 RID: 229 RVA: 0x000028DC File Offset: 0x00000ADC
		public bool Defined { get; set; }
	}
}
