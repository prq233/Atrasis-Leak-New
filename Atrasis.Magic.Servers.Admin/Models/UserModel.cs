using System;
using Atrasis.Magic.Servers.Core.Database.Document;

namespace Atrasis.Magic.Servers.Admin.Models
{
	// Token: 0x02000011 RID: 17
	public class UserModel : BaseModel
	{
		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000056 RID: 86 RVA: 0x000022E9 File Offset: 0x000004E9
		// (set) Token: 0x06000057 RID: 87 RVA: 0x000022F1 File Offset: 0x000004F1
		public AccountDocument Account { get; set; }

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000058 RID: 88 RVA: 0x000022FA File Offset: 0x000004FA
		// (set) Token: 0x06000059 RID: 89 RVA: 0x00002302 File Offset: 0x00000502
		public GameDocument Avatar { get; set; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600005A RID: 90 RVA: 0x0000230B File Offset: 0x0000050B
		// (set) Token: 0x0600005B RID: 91 RVA: 0x00002313 File Offset: 0x00000513
		public bool Online { get; set; }
	}
}
