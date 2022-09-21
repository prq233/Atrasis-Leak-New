using System;
using System.Collections.Concurrent;
using System.Threading;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Database.Document;
using Atrasis.Magic.Servers.Core.Util;

namespace ns0
{
	// Token: 0x02000006 RID: 6
	public static class GClass2
	{
		// Token: 0x0600001B RID: 27 RVA: 0x00002177 File Offset: 0x00000377
		public static int smethod_0()
		{
			return GClass2.concurrentDictionary_0.Count;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002B00 File Offset: 0x00000D00
		public static void smethod_1()
		{
			GClass2.concurrentDictionary_0 = new ConcurrentDictionary<long, GClass1>();
			GClass2.long_0 = ((long)TimeUtil.GetTimestamp() & 36028797018963967L);
			GClass2.thread_0 = new Thread(new ThreadStart(GClass2.smethod_2));
			GClass2.thread_0.Start();
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002B4C File Offset: 0x00000D4C
		private static void smethod_2()
		{
			for (;;)
			{
				foreach (GClass1 gclass in GClass2.concurrentDictionary_0.Values)
				{
					gclass.method_6();
				}
				Thread.Sleep(5000);
			}
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002BA8 File Offset: 0x00000DA8
		public static GClass1 smethod_3(GClass3 gclass3_0, AccountDocument accountDocument_0)
		{
			long key = gclass3_0.method_9();
			GClass1 gclass = new GClass1(key, gclass3_0, accountDocument_0);
			Logging.Assert(GClass2.concurrentDictionary_0.TryAdd(key, gclass), "ProxySessionManager.m_sessions.TryAdd(id, proxySession) return false");
			return gclass;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002183 File Offset: 0x00000383
		public static bool smethod_4(long long_1, out GClass1 gclass1_0)
		{
			return GClass2.concurrentDictionary_0.TryGetValue(long_1, out gclass1_0);
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002BDC File Offset: 0x00000DDC
		public static void smethod_5(GClass1 gclass1_0)
		{
			GClass1 gclass;
			GClass2.concurrentDictionary_0.TryRemove(gclass1_0.Id, out gclass);
		}

		// Token: 0x0400000D RID: 13
		private static ConcurrentDictionary<long, GClass1> concurrentDictionary_0;

		// Token: 0x0400000E RID: 14
		private static Thread thread_0;

		// Token: 0x0400000F RID: 15
		private static long long_0;
	}
}
