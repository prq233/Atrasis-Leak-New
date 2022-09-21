using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Account;
using Atrasis.Magic.Titan.Math;

namespace ns0
{
	// Token: 0x0200001C RID: 28
	public static class GClass15
	{
		// Token: 0x060000C4 RID: 196 RVA: 0x000027BB File Offset: 0x000009BB
		public static void smethod_0()
		{
			GClass15.gclass14_0 = new GClass14();
			GClass15.concurrentDictionary_0 = new ConcurrentDictionary<long, GClass12>();
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00006EC4 File Offset: 0x000050C4
		public static void smethod_1(int int_0)
		{
			foreach (KeyValuePair<long, GClass12> keyValuePair in GClass15.concurrentDictionary_0)
			{
				if (DateTime.UtcNow.Subtract(keyValuePair.Value.method_1()).TotalMinutes >= 10.0)
				{
					Logging.Error("LiveReplayManager.update: Live replay not finished after 10 minutes");
					GClass12 gclass;
					GClass15.concurrentDictionary_0.TryRemove(keyValuePair.Key, out gclass);
				}
				else
				{
					GClass15.smethod_6(new ServerUpdateLiveReplayMessage
					{
						AccountId = keyValuePair.Key,
						Milliseconds = int_0
					});
				}
			}
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x000027D1 File Offset: 0x000009D1
		private static LogicLong smethod_2()
		{
			if (GClass15.long_0 == 0L)
			{
				return GClass15.long_0 = (long)(ServerCore.Id + 1);
			}
			return GClass15.long_0 += (long)ServerManager.GetServerCount(9);
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00006F7C File Offset: 0x0000517C
		public static LogicLong smethod_3(GClass1 gclass1_0, LogicLong logicLong_0, LogicLong logicLong_1)
		{
			LogicLong logicLong = GClass15.smethod_2();
			Logging.Assert(GClass15.concurrentDictionary_0.TryAdd(logicLong, new GClass12(logicLong, logicLong_0, logicLong_1, gclass1_0)), "LiveReplayManager.m_liveReplays.TryAdd(id, allianceId, allianceStreamId, new LiveReplay(session)) return false");
			return logicLong;
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00006FB4 File Offset: 0x000051B4
		public static void smethod_4(LogicLong logicLong_0)
		{
			GClass12 gclass;
			GClass15.concurrentDictionary_0.TryRemove(logicLong_0, out gclass);
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00002807 File Offset: 0x00000A07
		public static bool smethod_5(LogicLong logicLong_0, out GClass12 gclass12_0)
		{
			return GClass15.concurrentDictionary_0.TryGetValue(logicLong_0, out gclass12_0);
		}

		// Token: 0x060000CA RID: 202 RVA: 0x0000281A File Offset: 0x00000A1A
		public static void smethod_6(ServerMessage serverMessage_0)
		{
			GClass15.gclass14_0.SendMessage(serverMessage_0);
		}

		// Token: 0x04000045 RID: 69
		private static GClass14 gclass14_0;

		// Token: 0x04000046 RID: 70
		private static ConcurrentDictionary<long, GClass12> concurrentDictionary_0;

		// Token: 0x04000047 RID: 71
		private static long long_0;
	}
}
