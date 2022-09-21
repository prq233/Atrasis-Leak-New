using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Servers.Core.Database.Document;
using Couchbase;
using Couchbase.IO;

namespace ns0
{
	// Token: 0x0200001C RID: 28
	public class GClass11
	{
		// Token: 0x06000093 RID: 147 RVA: 0x00002561 File Offset: 0x00000761
		[CompilerGenerated]
		public ResponseStatus method_0()
		{
			return this.responseStatus_0;
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00002569 File Offset: 0x00000769
		[CompilerGenerated]
		public AccountDocument method_1()
		{
			return this.accountDocument_0;
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00002571 File Offset: 0x00000771
		[CompilerGenerated]
		public ulong method_2()
		{
			return this.ulong_0;
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00002579 File Offset: 0x00000779
		public GClass11(IOperationResult<string> ioperationResult_0)
		{
			this.responseStatus_0 = ioperationResult_0.Status;
			this.accountDocument_0 = CouchbaseDocument.Load<AccountDocument>(ioperationResult_0.Value);
			this.ulong_0 = ioperationResult_0.Cas;
		}

		// Token: 0x0400007A RID: 122
		[CompilerGenerated]
		private readonly ResponseStatus responseStatus_0;

		// Token: 0x0400007B RID: 123
		[CompilerGenerated]
		private readonly AccountDocument accountDocument_0;

		// Token: 0x0400007C RID: 124
		[CompilerGenerated]
		private readonly ulong ulong_0;
	}
}
