using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Database;
using Atrasis.Magic.Servers.Core.Settings;
using Atrasis.Magic.Servers.Core.Util;
using Atrasis.Magic.Titan.Math;
using MaxMind.Db;
using MaxMind.GeoIP2;

namespace ns0
{
	// Token: 0x02000003 RID: 3
	public static class GClass0
	{
		// Token: 0x06000003 RID: 3 RVA: 0x00002098 File Offset: 0x00000298
		[CompilerGenerated]
		public static DatabaseReader smethod_0()
		{
			return GClass0.databaseReader_0;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x0000209F File Offset: 0x0000029F
		[CompilerGenerated]
		private static void smethod_1(DatabaseReader databaseReader_1)
		{
			GClass0.databaseReader_0 = databaseReader_1;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000020A7 File Offset: 0x000002A7
		[CompilerGenerated]
		public static GClass7 smethod_2()
		{
			return GClass0.gclass7_0;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000020AE File Offset: 0x000002AE
		[CompilerGenerated]
		private static void smethod_3(GClass7 gclass7_1)
		{
			GClass0.gclass7_0 = gclass7_1;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000020B6 File Offset: 0x000002B6
		[CompilerGenerated]
		public static CouchbaseDatabase smethod_4()
		{
			return GClass0.couchbaseDatabase_0;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000020BD File Offset: 0x000002BD
		[CompilerGenerated]
		private static void smethod_5(CouchbaseDatabase couchbaseDatabase_1)
		{
			GClass0.couchbaseDatabase_0 = couchbaseDatabase_1;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000020C5 File Offset: 0x000002C5
		[CompilerGenerated]
		public static RedisDatabase smethod_6()
		{
			return GClass0.redisDatabase_0;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000020CC File Offset: 0x000002CC
		[CompilerGenerated]
		private static void smethod_7(RedisDatabase redisDatabase_1)
		{
			GClass0.redisDatabase_0 = redisDatabase_1;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000025C4 File Offset: 0x000007C4
		public static void smethod_8()
		{
			GClass0.smethod_1(new DatabaseReader("Assets/GeoIP-Country.mmdb", FileAccessMode.Memory));
			GClass0.smethod_3(new GClass7(EnvironmentSettings.Servers[ServerCore.Type][ServerCore.Id].ServerIP, 9339));
			GClass0.smethod_5(new CouchbaseDatabase("magic-players", "account"));
			GClass0.smethod_4().CreateIndexWithFilter("googleServiceId", "meta().id LIKE '%KEY_PREFIX%%'", new string[]
			{
				"meta().id",
				"googleServiceId"
			});
			GClass0.smethod_7(new RedisDatabase("magic-session", -1));
			ServerStatus.OnServerStatusChanged = new ServerStatus.ServerStatusChanged(GClass0.smethod_10);
			GClass4.smethod_0();
			GClass2.smethod_1();
			Class1.smethod_0();
			GClass12.smethod_0();
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000020D4 File Offset: 0x000002D4
		public static void smethod_9()
		{
			GClass0.smethod_2().method_0();
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000020E0 File Offset: 0x000002E0
		private static void smethod_10(ServerStatusType serverStatusType_0, int int_0, int int_1)
		{
			if (serverStatusType_0 == ServerStatusType.SHUTDOWN_STARTED)
			{
				GClass4.smethod_6(LogicMath.Max(int_0 - TimeUtil.GetTimestamp(), 0));
				return;
			}
			if (serverStatusType_0 != ServerStatusType.MAINTENANCE)
			{
				return;
			}
			GClass4.smethod_5();
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002103 File Offset: 0x00000303
		public static int smethod_11()
		{
			if (ServerStatus.Status == ServerStatusType.COOLDOWN_AFTER_MAINTENANCE)
			{
				return LogicMath.Max(ServerStatus.Time - TimeUtil.GetTimestamp(), 0);
			}
			return 0;
		}

		// Token: 0x04000001 RID: 1
		[CompilerGenerated]
		private static DatabaseReader databaseReader_0;

		// Token: 0x04000002 RID: 2
		[CompilerGenerated]
		private static GClass7 gclass7_0;

		// Token: 0x04000003 RID: 3
		[CompilerGenerated]
		private static CouchbaseDatabase couchbaseDatabase_0;

		// Token: 0x04000004 RID: 4
		[CompilerGenerated]
		private static RedisDatabase redisDatabase_0;
	}
}
