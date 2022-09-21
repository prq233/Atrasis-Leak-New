using System;

namespace Atrasis.Magic.Servers.Admin.Models
{
	// Token: 0x02000008 RID: 8
	public class ErrorViewModel
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000020 RID: 32 RVA: 0x0000215B File Offset: 0x0000035B
		// (set) Token: 0x06000021 RID: 33 RVA: 0x00002163 File Offset: 0x00000363
		public string RequestId { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000022 RID: 34 RVA: 0x0000216C File Offset: 0x0000036C
		public bool ShowRequestId
		{
			get
			{
				return !string.IsNullOrEmpty(this.RequestId);
			}
		}
	}
}
