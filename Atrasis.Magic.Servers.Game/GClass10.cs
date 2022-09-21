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
	// Token: 0x02000016 RID: 22
	public static class GClass10
	{
		// Token: 0x06000097 RID: 151 RVA: 0x000025BB File Offset: 0x000007BB
		public static void smethod_0()
		{
			GClass10.concurrentDictionary_0 = new ConcurrentDictionary<long, GClass10.Class10>();
			GClass10.thread_0 = new Thread(new ThreadStart(GClass10.smethod_1));
			GClass10.thread_0.Start();
		}

		// Token: 0x06000098 RID: 152 RVA: 0x0000646C File Offset: 0x0000466C
		private static void smethod_1()
		{
			for (;;)
			{
				foreach (GClass10.Class10 @class in GClass10.concurrentDictionary_0.Values)
				{
					if (!@class.bool_0)
					{
						if (ServerStatus.Status != ServerStatusType.SHUTDOWN_STARTED && ServerStatus.Status != ServerStatusType.MAINTENANCE)
						{
							if (ServerStatus.Status != ServerStatusType.COOLDOWN_AFTER_MAINTENANCE)
							{
								GClass5 gclass = GClass10.smethod_2(@class);
								if (gclass != null)
								{
									@class.gclass1_0.SendMessage(new GameMatchmakingResultMessage
									{
										EnemyId = gclass.Id
									}, 9);
									@class.bool_0 = true;
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

		// Token: 0x06000099 RID: 153 RVA: 0x00006564 File Offset: 0x00004764
		private static GClass5 smethod_2(GClass10.Class10 class10_0)
		{
			GClass5 gclass = class10_0.gclass1_0.method_1();
			LogicClientAvatar logicClientAvatar = gclass.LogicClientAvatar;
			int num = TimeUtil.GetTimestamp() - class10_0.int_0;
			int num2 = GClass10.smethod_4(logicClientAvatar.GetScore());
			int num3 = 50 + LogicMath.Clamp(num * num2 / 30 - 50, 0, num2 - 50);
			int num4 = LogicMath.Clamp(num / 10, 1, 4);
			foreach (GClass5 gclass2 in GClass7.smethod_2().Values)
			{
				LogicClientAvatar logicClientAvatar2 = gclass2.LogicClientAvatar;
				if ((!logicClientAvatar.IsInAlliance() || !logicClientAvatar2.IsInAlliance() || !logicClientAvatar.GetAllianceId().Equals(logicClientAvatar2.GetAllianceId())) && (gclass2.LogicClientAvatar.GetNameSetByUser() && DateTime.UtcNow.Subtract(gclass2.method_6()).TotalMinutes >= 2.0 && gclass2.method_2() == null && (gclass2.GetRemainingProtectionTimeSeconds() <= 0 || GClass10.smethod_3(logicClientAvatar.GetScore(), num))) && LogicMath.Abs(logicClientAvatar.GetTownHallLevel() - logicClientAvatar2.GetTownHallLevel()) <= num4 && LogicMath.Abs(logicClientAvatar.GetScore() - logicClientAvatar2.GetScore()) <= num3 && !gclass.method_12(gclass2.Id))
				{
					return gclass2;
				}
			}
			return null;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x000025E7 File Offset: 0x000007E7
		private static bool smethod_3(int int_0, int int_1)
		{
			return int_1 >= 5 && int_0 < 5000 && ServerCore.Random.Rand(100000) >= 95000 + int_0;
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00002614 File Offset: 0x00000814
		private static int smethod_4(int int_0)
		{
			if (int_0 < 1000)
			{
				return 750;
			}
			if (int_0 < 2500)
			{
				return 500;
			}
			if (int_0 < 5000)
			{
				return 250;
			}
			return 150;
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00002645 File Offset: 0x00000845
		public static void smethod_5(GClass1 gclass1_0)
		{
			if (!gclass1_0.method_6())
			{
				Logging.Assert(GClass10.concurrentDictionary_0.TryAdd(gclass1_0.Id, new GClass10.Class10(gclass1_0)), "GameMatchmakingManager.m_queue.TryAdd(session.Id, new MatchmakingEntry(session)) return false");
				gclass1_0.method_7(true);
			}
		}

		// Token: 0x0600009D RID: 157 RVA: 0x000066E0 File Offset: 0x000048E0
		public static void smethod_6(GClass1 gclass1_0)
		{
			if (gclass1_0.method_6())
			{
				GClass10.Class10 @class;
				Logging.Assert(GClass10.concurrentDictionary_0.TryRemove(gclass1_0.Id, out @class), "GameMatchmakingManager.m_queue.TryRemove(session.Id, out _) return false");
			}
			gclass1_0.method_7(false);
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00006718 File Offset: 0x00004918
		public static void smethod_7(GameMatchmakingResultMessage gameMatchmakingResultMessage_0)
		{
			GClass10.Class10 @class;
			if (GClass10.concurrentDictionary_0.TryGetValue(gameMatchmakingResultMessage_0.SessionId, out @class))
			{
				GClass1 gclass1_ = @class.gclass1_0;
				GClass5 gclass = GClass7.smethod_5(gameMatchmakingResultMessage_0.EnemyId);
				if (gclass1_.method_2() != null)
				{
					return;
				}
				if (gclass.method_0() == null)
				{
					GClass10.smethod_6(gclass1_);
					LogicLong logicLong = GClass15.smethod_3(gclass1_, null, null);
					if (gclass.GetRemainingProtectionTimeSeconds() <= 0 && gclass.method_2() == null)
					{
						gclass.method_3(new GClass6(gclass1_.AccountId, logicLong));
					}
					@class.gclass1_0.method_1().method_11(gameMatchmakingResultMessage_0.EnemyId);
					gclass1_.method_24(new GameMatchedAttackState
					{
						HomeId = gclass.Id,
						HomeData = gclass.HomeData,
						HomeOwnerAvatar = gclass.LogicClientAvatar,
						PlayerAvatar = gclass1_.method_1().LogicClientAvatar,
						MaintenanceTime = gclass.MaintenanceTime,
						SaveTime = gclass.SaveTime,
						GameDefenderLocked = (gclass.method_2() != null),
						LiveReplayId = logicLong
					});
					return;
				}
				@class.bool_0 = false;
			}
		}

		// Token: 0x0400002F RID: 47
		private static ConcurrentDictionary<long, GClass10.Class10> concurrentDictionary_0;

		// Token: 0x04000030 RID: 48
		private static Thread thread_0;

		// Token: 0x02000017 RID: 23
		private class Class10
		{
			// Token: 0x0600009F RID: 159 RVA: 0x00002676 File Offset: 0x00000876
			public Class10(GClass1 gclass1_1)
			{
				this.int_0 = TimeUtil.GetTimestamp();
				this.gclass1_0 = gclass1_1;
			}

			// Token: 0x04000031 RID: 49
			public readonly GClass1 gclass1_0;

			// Token: 0x04000032 RID: 50
			public readonly int int_0;

			// Token: 0x04000033 RID: 51
			public bool bool_0;
		}
	}
}
