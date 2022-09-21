using System;
using System.Collections.Generic;
using Atrasis.Magic.Servers.Core.Network.Message.Session;

namespace ns0
{
	// Token: 0x02000005 RID: 5
	public static class GClass2
	{
		// Token: 0x06000009 RID: 9 RVA: 0x0000210A File Offset: 0x0000030A
		public static int smethod_0()
		{
			return GClass2.dictionary_0.Count;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002116 File Offset: 0x00000316
		public static void smethod_1()
		{
			GClass2.dictionary_0 = new Dictionary<long, GClass1>();
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002122 File Offset: 0x00000322
		public static void smethod_2(StartServerSessionMessage startServerSessionMessage_0)
		{
			if (GClass2.dictionary_0.ContainsKey(startServerSessionMessage_0.SessionId))
			{
				throw new Exception("ChatSessionManager.onStartSessionMessageReceived: session already started!");
			}
			GClass2.dictionary_0.Add(startServerSessionMessage_0.SessionId, new GClass1(startServerSessionMessage_0));
		}

		// Token: 0x0600000C RID: 12 RVA: 0x0000224C File Offset: 0x0000044C
		public static void smethod_3(StopServerSessionMessage stopServerSessionMessage_0)
		{
			GClass1 gclass;
			if (GClass2.dictionary_0.Remove(stopServerSessionMessage_0.SessionId, out gclass))
			{
				gclass.Destruct();
			}
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002157 File Offset: 0x00000357
		public static bool smethod_4(long long_0, out GClass1 gclass1_0)
		{
			return GClass2.dictionary_0.TryGetValue(long_0, out gclass1_0);
		}

		// Token: 0x04000003 RID: 3
		private static Dictionary<long, GClass1> dictionary_0;
	}
}
