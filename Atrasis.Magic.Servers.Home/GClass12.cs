using System;
using System.Collections.Generic;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Request;
using Atrasis.Magic.Servers.Core.Network.Message.Session;
using Atrasis.Magic.Servers.Core.Network.Request;

namespace ns0
{
	// Token: 0x02000011 RID: 17
	public static class GClass12
	{
		// Token: 0x06000083 RID: 131 RVA: 0x00002876 File Offset: 0x00000A76
		public static int smethod_0()
		{
			return GClass12.dictionary_0.Count;
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00002882 File Offset: 0x00000A82
		public static int smethod_1()
		{
			return GClass12.gclass11_0.Length;
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00005044 File Offset: 0x00003244
		public static void smethod_2()
		{
			GClass12.dictionary_0 = new Dictionary<long, GClass11>();
			GClass12.gclass11_0 = new GClass11[Environment.ProcessorCount * 2];
			for (int i = 0; i < Environment.ProcessorCount * 2; i++)
			{
				GClass12.gclass11_0[i] = new GClass11(i, -1);
			}
		}

		// Token: 0x06000086 RID: 134 RVA: 0x0000508C File Offset: 0x0000328C
		public static void smethod_3(StartServerSessionMessage startServerSessionMessage_0)
		{
			if (GClass12.dictionary_0.ContainsKey(startServerSessionMessage_0.SessionId))
			{
				throw new Exception("GameModeClusterManager.onStartSessionMessageReceived: session already started!");
			}
			GClass11 gclass = GClass12.smethod_6();
			if (gclass != null)
			{
				GClass12.dictionary_0.Add(startServerSessionMessage_0.SessionId, gclass);
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

		// Token: 0x06000087 RID: 135 RVA: 0x0000510C File Offset: 0x0000330C
		public static void smethod_4(StopServerSessionMessage stopServerSessionMessage_0)
		{
			GClass11 gclass;
			if (GClass12.dictionary_0.Remove(stopServerSessionMessage_0.SessionId, out gclass))
			{
				gclass.SendMessage(stopServerSessionMessage_0);
			}
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00005134 File Offset: 0x00003334
		public static void smethod_5(ServerSessionMessage serverSessionMessage_0)
		{
			GClass11 gclass;
			if (GClass12.dictionary_0.TryGetValue(serverSessionMessage_0.SessionId, out gclass))
			{
				gclass.SendMessage(serverSessionMessage_0);
			}
		}

		// Token: 0x06000089 RID: 137 RVA: 0x0000515C File Offset: 0x0000335C
		private static GClass11 smethod_6()
		{
			GClass11 gclass = null;
			int i = 0;
			int num = int.MaxValue;
			while (i < GClass12.gclass11_0.Length)
			{
				GClass11 gclass2 = GClass12.gclass11_0[i];
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

		// Token: 0x0600008A RID: 138 RVA: 0x0000288B File Offset: 0x00000A8B
		public static void smethod_7(long long_1)
		{
			GClass12.long_0 += long_1;
			GClass12.int_0++;
			if (GClass12.int_0 >= 1000)
			{
				GClass12.long_0 /= (long)GClass12.int_0;
				GClass12.int_0 = 1;
			}
		}

		// Token: 0x0600008B RID: 139 RVA: 0x000028C8 File Offset: 0x00000AC8
		public static long smethod_8()
		{
			if (GClass12.int_0 != 0)
			{
				return GClass12.long_0 / (long)GClass12.int_0;
			}
			return 0L;
		}

		// Token: 0x0600008C RID: 140 RVA: 0x000051B0 File Offset: 0x000033B0
		public static void smethod_9()
		{
			for (int i = 0; i < GClass12.gclass11_0.Length; i++)
			{
				GClass12.gclass11_0[i].SendPing();
			}
		}

		// Token: 0x0400002D RID: 45
		private static Dictionary<long, GClass11> dictionary_0;

		// Token: 0x0400002E RID: 46
		private static GClass11[] gclass11_0;

		// Token: 0x0400002F RID: 47
		private static long long_0;

		// Token: 0x04000030 RID: 48
		private static int int_0;
	}
}
