using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Servers.Core.Database;

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

		// Token: 0x06000005 RID: 5 RVA: 0x00002168 File Offset: 0x00000368
		public static void smethod_2()
		{
			GClass0.smethod_1(new CouchbaseDatabase("magic-alliances", "data"));
			GClass0.smethod_0().CreateIndexWithFilter("joinableAlliancesIndex", "meta().id LIKE '%KEY_PREFIX%%' AND type == 1 AND member_count BETWEEN 1 AND 49", new string[]
			{
				"meta().id",
				"type",
				"member_count",
				"required_score",
				"required_duel_score"
			});
			GClass0.smethod_0().CreateIndexWithFilter("searchAlliancesIndex", "meta().id LIKE '%KEY_PREFIX%%'", new string[]
			{
				"id_hi",
				"id_lo",
				"alliance_name",
				"war_freq",
				"origin",
				"member_count",
				"score",
				"duel_score",
				"xp_level",
				"required_score",
				"required_duel_score"
			});
		}

		// Token: 0x04000001 RID: 1
		[CompilerGenerated]
		private static CouchbaseDatabase couchbaseDatabase_0;
	}
}
