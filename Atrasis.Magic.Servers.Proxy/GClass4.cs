using System;
using System.Collections.Concurrent;
using System.Net.Sockets;
using System.Threading;
using Atrasis.Magic.Logic.Message.Account;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Util;

namespace ns0
{
	// Token: 0x02000009 RID: 9
	public static class GClass4
	{
		// Token: 0x06000034 RID: 52 RVA: 0x00002D2C File Offset: 0x00000F2C
		public static void smethod_0()
		{
			GClass4.bool_0 = true;
			GClass4.long_0 = TimeUtil.GetTimestampMS();
			GClass4.concurrentDictionary_0 = new ConcurrentDictionary<long, GClass3>();
			GClass4.thread_0 = new Thread(new ThreadStart(GClass4.smethod_1));
			GClass4.thread_0.Name = "Client Connection Manager";
			GClass4.thread_0.Start();
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00002D84 File Offset: 0x00000F84
		private static void smethod_1()
		{
			while (GClass4.bool_0)
			{
				foreach (GClass3 gclass in GClass4.concurrentDictionary_0.Values)
				{
					if (!gclass.method_2().method_14())
					{
						GClass7.smethod_3(gclass);
					}
				}
				Thread.Sleep(1000);
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00002DF8 File Offset: 0x00000FF8
		public static GClass3 smethod_2(Socket socket_0, SocketAsyncEventArgs socketAsyncEventArgs_0)
		{
			long num = (GClass4.long_0 = (GClass4.long_0 + 1L & 36028797018963967L)) | (long)ServerCore.Id << 55;
			GClass3 gclass = new GClass3(socket_0, socketAsyncEventArgs_0, num);
			Logging.Assert(GClass4.concurrentDictionary_0.TryAdd(num, gclass), "ClientConnectionManager.m_connections.TryAdd(id, clientConnection) return false");
			return gclass;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x0000227D File Offset: 0x0000047D
		public static bool smethod_3(long long_1, out GClass3 gclass3_0)
		{
			return GClass4.concurrentDictionary_0.TryGetValue(long_1, out gclass3_0);
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002E50 File Offset: 0x00001050
		public static bool smethod_4(GClass3 gclass3_0)
		{
			GClass3 gclass;
			return GClass4.concurrentDictionary_0.TryRemove(gclass3_0.method_9(), out gclass);
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002E70 File Offset: 0x00001070
		public static void smethod_5()
		{
			foreach (GClass3 gclass3_ in GClass4.concurrentDictionary_0.Values)
			{
				GClass7.smethod_3(gclass3_);
			}
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002EC0 File Offset: 0x000010C0
		public static void smethod_6(int int_0)
		{
			foreach (GClass3 gclass in GClass4.concurrentDictionary_0.Values)
			{
				ShutdownStartedMessage shutdownStartedMessage = new ShutdownStartedMessage();
				shutdownStartedMessage.SetSecondsUntilShutdown(int_0);
				gclass.method_1().method_10(shutdownStartedMessage);
			}
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00002F24 File Offset: 0x00001124
		public static void smethod_7(GClass3 gclass3_0, int int_0)
		{
			if (gclass3_0.method_10() == GEnum0.const_2)
			{
				if (int_0 != 0)
				{
					DisconnectedMessage disconnectedMessage = new DisconnectedMessage();
					disconnectedMessage.SetReason(int_0);
					gclass3_0.method_1().method_10(disconnectedMessage);
				}
				else
				{
					GClass7.smethod_3(gclass3_0);
				}
			}
			gclass3_0.method_14(GEnum0.const_4);
		}

		// Token: 0x0600003C RID: 60 RVA: 0x0000228B File Offset: 0x0000048B
		public static int smethod_8()
		{
			return GClass4.concurrentDictionary_0.Count;
		}

		// Token: 0x04000021 RID: 33
		private static Thread thread_0;

		// Token: 0x04000022 RID: 34
		private static ConcurrentDictionary<long, GClass3> concurrentDictionary_0;

		// Token: 0x04000023 RID: 35
		private static bool bool_0;

		// Token: 0x04000024 RID: 36
		private static long long_0;
	}
}
