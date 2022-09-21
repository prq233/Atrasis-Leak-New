using System;
using System.Collections.Generic;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Request;
using Atrasis.Magic.Servers.Core.Network.Message.Session;
using Atrasis.Magic.Servers.Core.Network.Request;

namespace ns0
{
	// Token: 0x02000010 RID: 16
	public static class GClass10
	{
		// Token: 0x0600005C RID: 92 RVA: 0x000026CA File Offset: 0x000008CA
		public static int smethod_0()
		{
			return GClass10.dictionary_0.Count;
		}

		// Token: 0x0600005D RID: 93 RVA: 0x000026D6 File Offset: 0x000008D6
		public static int smethod_1()
		{
			return GClass10.gclass9_0.Length;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00003B90 File Offset: 0x00001D90
		public static void smethod_2()
		{
			GClass10.dictionary_0 = new Dictionary<long, GClass9>();
			GClass10.gclass9_0 = new GClass9[Environment.ProcessorCount * 2];
			for (int i = 0; i < Environment.ProcessorCount * 2; i++)
			{
				GClass10.gclass9_0[i] = new GClass9(i, -1);
			}
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00003BD8 File Offset: 0x00001DD8
		public static void smethod_3(StartServerSessionMessage startServerSessionMessage_0)
		{
			if (GClass10.dictionary_0.ContainsKey(startServerSessionMessage_0.SessionId))
			{
				throw new Exception("GameModeClusterManager.onStartSessionMessageReceived: session already started!");
			}
			GClass9 gclass = GClass10.smethod_6();
			if (gclass != null)
			{
				GClass10.dictionary_0.Add(startServerSessionMessage_0.SessionId, gclass);
				gclass.SendMessage(startServerSessionMessage_0);
				return;
			}
			if (startServerSessionMessage_0.BindRequestMessage != null)
			{
				ServerRequestManager.SendResponse(new BindServerSocketResponseMessage(), startServerSessionMessage_0.BindRequestMessage);
			}
			ServerMessageManager.SendMessage(new StartServerSessionFailedMessage
			{
				SessionId = startServerSessionMessage_0.SessionId
			}, startServerSessionMessage_0.Sender);
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00003C58 File Offset: 0x00001E58
		public static void smethod_4(StopServerSessionMessage stopServerSessionMessage_0)
		{
			GClass9 gclass;
			if (GClass10.dictionary_0.Remove(stopServerSessionMessage_0.SessionId, out gclass))
			{
				gclass.SendMessage(stopServerSessionMessage_0);
			}
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00003C80 File Offset: 0x00001E80
		public static void smethod_5(ServerSessionMessage serverSessionMessage_0)
		{
			GClass9 gclass;
			if (GClass10.dictionary_0.TryGetValue(serverSessionMessage_0.SessionId, out gclass))
			{
				gclass.SendMessage(serverSessionMessage_0);
			}
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00003CA8 File Offset: 0x00001EA8
		private static GClass9 smethod_6()
		{
			GClass9 gclass = null;
			int i = 0;
			int num = int.MaxValue;
			while (i < GClass10.gclass9_0.Length)
			{
				GClass9 gclass2 = GClass10.gclass9_0[i];
				long num2 = gclass2.method_0();
				if (num2 <= 2000L && (gclass == null || num2 < (long)num))
				{
					gclass = gclass2;
					num = (int)num2;
				}
				i++;
			}
			return gclass;
		}

		// Token: 0x06000063 RID: 99 RVA: 0x000026DF File Offset: 0x000008DF
		public static void smethod_7(long long_1)
		{
			GClass10.long_0 += long_1;
			GClass10.int_0++;
			if (GClass10.int_0 >= 1000)
			{
				GClass10.long_0 /= (long)GClass10.int_0;
				GClass10.int_0 = 1;
			}
		}

		// Token: 0x06000064 RID: 100 RVA: 0x0000271C File Offset: 0x0000091C
		public static long smethod_8()
		{
			if (GClass10.int_0 != 0)
			{
				return GClass10.long_0 / (long)GClass10.int_0;
			}
			return 0L;
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00003CFC File Offset: 0x00001EFC
		public static void smethod_9()
		{
			for (int i = 0; i < GClass10.gclass9_0.Length; i++)
			{
				GClass10.gclass9_0[i].SendPing();
			}
		}

		// Token: 0x04000027 RID: 39
		private static Dictionary<long, GClass9> dictionary_0;

		// Token: 0x04000028 RID: 40
		private static GClass9[] gclass9_0;

		// Token: 0x04000029 RID: 41
		private static long long_0;

		// Token: 0x0400002A RID: 42
		private static int int_0;
	}
}
