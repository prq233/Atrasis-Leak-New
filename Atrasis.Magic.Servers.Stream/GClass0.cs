using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Servers.Core.Database;
using Atrasis.Magic.Servers.Core.Util;

namespace ns0
{
	// Token: 0x02000003 RID: 3
	public static class GClass0
	{
		// Token: 0x06000003 RID: 3 RVA: 0x00002094 File Offset: 0x00000294
		[CompilerGenerated]
		public static CouchbaseDatabase smethod_0()
		{
			return GClass0.couchbaseDatabase_0;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x0000209B File Offset: 0x0000029B
		[CompilerGenerated]
		private static void smethod_1(CouchbaseDatabase couchbaseDatabase_2)
		{
			GClass0.couchbaseDatabase_0 = couchbaseDatabase_2;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000020A3 File Offset: 0x000002A3
		[CompilerGenerated]
		public static CouchbaseDatabase smethod_2()
		{
			return GClass0.couchbaseDatabase_1;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000020AA File Offset: 0x000002AA
		[CompilerGenerated]
		private static void smethod_3(CouchbaseDatabase couchbaseDatabase_2)
		{
			GClass0.couchbaseDatabase_1 = couchbaseDatabase_2;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000020B2 File Offset: 0x000002B2
		public static void smethod_4()
		{
			GClass0.smethod_1(new CouchbaseDatabase("magic-alliances", "data"));
			GClass0.smethod_3(new CouchbaseDatabase("magic-streams", "stream"));
			GClass9.smethod_0();
			GClass10.smethod_0();
			GClass5.smethod_1();
			WordCensorUtil.Init();
		}

		// Token: 0x04000001 RID: 1
		[CompilerGenerated]
		private static CouchbaseDatabase couchbaseDatabase_0;

		// Token: 0x04000002 RID: 2
		[CompilerGenerated]
		private static CouchbaseDatabase couchbaseDatabase_1;
	}
}
