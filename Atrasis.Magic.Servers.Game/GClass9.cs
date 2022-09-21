using System;
using System.Collections.Concurrent;
using System.Threading;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Message.Home;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Network.Message.Session;
using Atrasis.Magic.Servers.Core.Network.Message.Session.State;
using Atrasis.Magic.Servers.Core.Util;
using Atrasis.Magic.Titan.Math;

namespace ns0
{
	// Token: 0x02000014 RID: 20
	public static class GClass9
	{
		// Token: 0x0600008F RID: 143 RVA: 0x00002547 File Offset: 0x00000747
		public static void smethod_0()
		{
			GClass9.concurrentDictionary_0 = new ConcurrentDictionary<long, GClass9.Class9>();
			GClass9.thread_0 = new Thread(new ThreadStart(GClass9.smethod_1));
			GClass9.thread_0.Start();
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00006098 File Offset: 0x00004298
		private static void smethod_1()
		{
			for (;;)
			{
				foreach (GClass9.Class9 @class in GClass9.concurrentDictionary_0.Values)
				{
					if (!@class.bool_0)
					{
						if (ServerStatus.Status != ServerStatusType.SHUTDOWN_STARTED)
						{
							if (ServerStatus.Status != ServerStatusType.MAINTENANCE)
							{
								GClass9.Class9 class2 = GClass9.smethod_2(@class);
								if (class2 != null)
								{
									@class.bool_0 = true;
									class2.bool_0 = true;
									@class.gclass1_0.SendMessage(new GameDuelMatchmakingResultMessage
									{
										EnemySessionId = class2.gclass1_0.Id
									}, 9);
									continue;
								}
								continue;
							}
						}
						AttackHomeFailedMessage attackHomeFailedMessage = new AttackHomeFailedMessage();
						ServerStatusType status = ServerStatus.Status;
						if (status != ServerStatusType.SHUTDOWN_STARTED)
						{
							if (status == ServerStatusType.COOLDOWN_AFTER_MAINTENANCE)
							{
								attackHomeFailedMessage.SetReason(AttackHomeFailedMessage.Reason.COOLDOWN_AFTER_MAINTENANCE);
							}
						}
						else
						{
							attackHomeFailedMessage.SetReason(AttackHomeFailedMessage.Reason.SHUTDOWN_ATTACK_DISABLED);
						}
						@class.gclass1_0.SendPiranhaMessage(attackHomeFailedMessage, 1);
						@class.gclass1_0.method_22();
					}
				}
				Thread.Sleep(250);
			}
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00006194 File Offset: 0x00004394
		private static GClass9.Class9 smethod_2(GClass9.Class9 class9_0)
		{
			LogicClientAvatar logicClientAvatar = class9_0.gclass1_0.method_1().LogicClientAvatar;
			int num = TimeUtil.GetTimestamp() - class9_0.int_0;
			int num2 = 50 + LogicMath.Clamp(num * 150 / 15, 0, 150);
			foreach (GClass9.Class9 @class in GClass9.concurrentDictionary_0.Values)
			{
				if (!@class.bool_0)
				{
					LogicClientAvatar logicClientAvatar2 = @class.gclass1_0.method_1().LogicClientAvatar;
					if (!logicClientAvatar.GetId().Equals(logicClientAvatar2.GetId()) && (!logicClientAvatar.IsInAlliance() || !logicClientAvatar2.IsInAlliance() || !logicClientAvatar.GetAllianceId().Equals(logicClientAvatar2.GetAllianceId())) && LogicMath.Abs(logicClientAvatar.GetDuelScore() - logicClientAvatar2.GetDuelScore()) <= num2)
					{
						return @class;
					}
				}
			}
			return null;
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00002573 File Offset: 0x00000773
		public static void smethod_3(GClass1 gclass1_0, byte[] byte_0)
		{
			if (!gclass1_0.method_8())
			{
				gclass1_0.method_9(GClass9.concurrentDictionary_0.TryAdd(gclass1_0.Id, new GClass9.Class9(gclass1_0, byte_0)));
			}
		}

		// Token: 0x06000093 RID: 147 RVA: 0x0000628C File Offset: 0x0000448C
		public static void smethod_4(GClass1 gclass1_0)
		{
			if (gclass1_0.method_8())
			{
				GClass9.Class9 @class;
				gclass1_0.method_9(!GClass9.concurrentDictionary_0.TryRemove(gclass1_0.Id, out @class));
			}
		}

		// Token: 0x06000094 RID: 148 RVA: 0x000062BC File Offset: 0x000044BC
		public static void smethod_5(GameDuelMatchmakingResultMessage gameDuelMatchmakingResultMessage_0)
		{
			GClass9.Class9 @class;
			bool flag = GClass9.concurrentDictionary_0.TryRemove(gameDuelMatchmakingResultMessage_0.SessionId, out @class) && !@class.gclass1_0.IsDestructed();
			GClass9.Class9 class2;
			bool flag2 = GClass9.concurrentDictionary_0.TryRemove(gameDuelMatchmakingResultMessage_0.EnemySessionId, out class2) && !class2.gclass1_0.IsDestructed();
			if (flag && flag2)
			{
				GClass1 gclass1_ = @class.gclass1_0;
				GClass1 gclass1_2 = class2.gclass1_0;
				gclass1_.method_9(false);
				gclass1_2.method_9(false);
				LogicLong logicLong = GClass15.smethod_3(gclass1_, null, null);
				LogicLong logicLong_ = GClass15.smethod_3(gclass1_2, null, null);
				GClass17 gclass = GClass19.smethod_1(gclass1_.method_1(), gclass1_2.method_1(), logicLong, logicLong_);
				gclass1_.method_1().method_5(gclass);
				gclass1_2.method_1().method_5(gclass);
				GClass9.smethod_6(gclass1_, gclass1_2.method_1().Id, logicLong, gclass.method_1(), class2.byte_0);
				GClass9.smethod_6(gclass1_2, gclass1_.method_1().Id, logicLong_, gclass.method_1(), @class.byte_0);
				return;
			}
			if (flag)
			{
				GClass9.concurrentDictionary_0.TryAdd(@class.gclass1_0.Id, @class);
				@class.bool_0 = false;
				return;
			}
			GClass9.concurrentDictionary_0.TryAdd(@class.gclass1_0.Id, @class);
			@class.bool_0 = false;
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00006410 File Offset: 0x00004610
		private static void smethod_6(GClass1 gclass1_0, LogicLong logicLong_0, LogicLong logicLong_1, long long_0, byte[] byte_0)
		{
			gclass1_0.method_24(new GameDuelState
			{
				HomeId = logicLong_0,
				HomeData = byte_0,
				PlayerAvatar = gclass1_0.method_1().LogicClientAvatar,
				SaveTime = -1,
				AvatarId = logicLong_0,
				LiveReplayId = logicLong_1,
				DuelEntryId = long_0
			});
		}

		// Token: 0x04000029 RID: 41
		private static ConcurrentDictionary<long, GClass9.Class9> concurrentDictionary_0;

		// Token: 0x0400002A RID: 42
		private static Thread thread_0;

		// Token: 0x02000015 RID: 21
		private class Class9
		{
			// Token: 0x06000096 RID: 150 RVA: 0x0000259A File Offset: 0x0000079A
			public Class9(GClass1 gclass1_1, byte[] byte_1)
			{
				this.int_0 = TimeUtil.GetTimestamp();
				this.byte_0 = byte_1;
				this.gclass1_0 = gclass1_1;
			}

			// Token: 0x0400002B RID: 43
			public readonly GClass1 gclass1_0;

			// Token: 0x0400002C RID: 44
			public readonly byte[] byte_0;

			// Token: 0x0400002D RID: 45
			public readonly int int_0;

			// Token: 0x0400002E RID: 46
			public bool bool_0;
		}
	}
}
