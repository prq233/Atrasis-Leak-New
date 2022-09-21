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
		private static void smethod_1(CouchbaseDatabase couchbaseDatabase_1)
		{
			GClass0.couchbaseDatabase_0 = couchbaseDatabase_1;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002C38 File Offset: 0x00000E38
		public static void smethod_2()
		{
			GClass0.smethod_1(new CouchbaseDatabase("magic-players", "game"));
			GClass11.smethod_4();
			GClass10.smethod_0();
			GClass9.smethod_0();
			GClass19.smethod_0();
			GClass7.smethod_0();
			GClass2.smethod_1();
			GClass15.smethod_0();
			GClass8.smethod_2();
			WordCensorUtil.Init();
		}

		// Token: 0x04000001 RID: 1
		[CompilerGenerated]
		private static CouchbaseDatabase couchbaseDatabase_0;
	}
}
