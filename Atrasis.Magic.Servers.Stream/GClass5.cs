using System;
using System.Collections.Generic;
using Atrasis.Magic.Servers.Core.Network.Message.Session;

namespace ns0
{
	// Token: 0x02000008 RID: 8
	public static class GClass5
	{
		// Token: 0x06000019 RID: 25 RVA: 0x00002141 File Offset: 0x00000341
		public static int smethod_0()
		{
			return GClass5.dictionary_0.Count;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x0000214D File Offset: 0x0000034D
		public static void smethod_1()
		{
			GClass5.dictionary_0 = new Dictionary<long, GClass4>();
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002159 File Offset: 0x00000359
		public static void smethod_2(StartServerSessionMessage startServerSessionMessage_0)
		{
			if (GClass5.dictionary_0.ContainsKey(startServerSessionMessage_0.SessionId))
			{
				throw new Exception("AllianceSessionManager.onStartSessionMessageReceived: session already started!");
			}
			GClass5.dictionary_0.Add(startServerSessionMessage_0.SessionId, new GClass4(startServerSessionMessage_0));
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000027BC File Offset: 0x000009BC
		public static void smethod_3(StopServerSessionMessage stopServerSessionMessage_0)
		{
			GClass4 gclass;
			if (GClass5.dictionary_0.Remove(stopServerSessionMessage_0.SessionId, out gclass))
			{
				gclass.Destruct();
			}
		}

		// Token: 0x0600001D RID: 29 RVA: 0x0000218E File Offset: 0x0000038E
		public static bool smethod_4(long long_0, out GClass4 gclass4_0)
		{
			return GClass5.dictionary_0.TryGetValue(long_0, out gclass4_0);
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000027E4 File Offset: 0x000009E4
		public static GClass4 smethod_5(long long_0)
		{
			GClass4 gclass;
			if (GClass5.dictionary_0.Remove(long_0, out gclass))
			{
				gclass.Destruct();
			}
			return gclass;
		}

		// Token: 0x04000006 RID: 6
		private static Dictionary<long, GClass4> dictionary_0;
	}
}
