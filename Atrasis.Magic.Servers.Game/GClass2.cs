using System;
using System.Collections.Generic;
using Atrasis.Magic.Servers.Core.Network.Message.Session;

namespace ns0
{
	// Token: 0x02000006 RID: 6
	public static class GClass2
	{
		// Token: 0x06000024 RID: 36 RVA: 0x00002202 File Offset: 0x00000402
		public static int smethod_0()
		{
			return GClass2.dictionary_0.Count;
		}

		// Token: 0x06000025 RID: 37 RVA: 0x0000220E File Offset: 0x0000040E
		public static void smethod_1()
		{
			GClass2.dictionary_0 = new Dictionary<long, GClass1>();
		}

		// Token: 0x06000026 RID: 38 RVA: 0x0000221A File Offset: 0x0000041A
		public static void smethod_2(StartServerSessionMessage startServerSessionMessage_0)
		{
			if (GClass2.dictionary_0.ContainsKey(startServerSessionMessage_0.SessionId))
			{
				throw new Exception("GameSessionManager.onStartSessionMessageReceived: session already started!");
			}
			GClass2.dictionary_0.Add(startServerSessionMessage_0.SessionId, new GClass1(startServerSessionMessage_0));
		}

		// Token: 0x06000027 RID: 39 RVA: 0x0000321C File Offset: 0x0000141C
		public static void smethod_3(StopServerSessionMessage stopServerSessionMessage_0)
		{
			GClass1 gclass;
			if (GClass2.dictionary_0.Remove(stopServerSessionMessage_0.SessionId, out gclass))
			{
				gclass.Destruct();
			}
		}

		// Token: 0x06000028 RID: 40 RVA: 0x0000224F File Offset: 0x0000044F
		public static bool smethod_4(long long_0, out GClass1 gclass1_0)
		{
			return GClass2.dictionary_0.TryGetValue(long_0, out gclass1_0);
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00003244 File Offset: 0x00001444
		public static GClass1 smethod_5(long long_0)
		{
			GClass1 gclass;
			if (GClass2.dictionary_0.Remove(long_0, out gclass))
			{
				gclass.Destruct();
			}
			return gclass;
		}

		// Token: 0x0400000D RID: 13
		private static Dictionary<long, GClass1> dictionary_0;
	}
}
