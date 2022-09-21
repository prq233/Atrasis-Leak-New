using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Command.Server;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Message.Avatar.Attack;
using Atrasis.Magic.Logic.Message.Battle;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Account;
using Atrasis.Magic.Servers.Core.Network.Message.Request.Stream;
using Atrasis.Magic.Servers.Core.Network.Request;
using Atrasis.Magic.Titan.Math;

namespace ns0
{
	// Token: 0x0200001E RID: 30
	public class GClass17
	{
		// Token: 0x060000E6 RID: 230 RVA: 0x00002B08 File Offset: 0x00000D08
		[CompilerGenerated]
		public DateTime method_0()
		{
			return this.dateTime_0;
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00002B10 File Offset: 0x00000D10
		public long method_1()
		{
			return this.long_0;
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x0000710C File Offset: 0x0000530C
		public GClass17(long long_1, GClass5 gclass5_2, GClass5 gclass5_3, LogicLong logicLong_2, LogicLong logicLong_3)
		{
			this.long_0 = long_1;
			this.gclass5_0 = gclass5_2;
			this.gclass5_1 = gclass5_3;
			this.logicLong_0 = logicLong_2;
			this.logicLong_1 = logicLong_3;
			this.gclass18_0 = new GClass18();
			this.gclass18_1 = new GClass18();
			this.dateTime_0 = DateTime.UtcNow;
			this.method_2(this.gclass5_0, this.gclass5_1);
			this.method_2(this.gclass5_1, this.gclass5_0);
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x0000718C File Offset: 0x0000538C
		private void method_2(GClass5 gclass5_2, GClass5 gclass5_3)
		{
			GClass17.Class11 @class = new GClass17.Class11();
			@class.gclass17_0 = this;
			@class.gclass5_0 = gclass5_2;
			Village2BattleResultAttackEntry village2BattleResultAttackEntry = new Village2BattleResultAttackEntry();
			village2BattleResultAttackEntry.SetAccountId(gclass5_3.Id);
			village2BattleResultAttackEntry.SetAvatarId(gclass5_3.Id);
			village2BattleResultAttackEntry.SetHomeId(gclass5_3.Id);
			village2BattleResultAttackEntry.SetName(gclass5_3.LogicClientAvatar.GetName());
			if (gclass5_3.LogicClientAvatar.IsInAlliance())
			{
				village2BattleResultAttackEntry.SetAllianceId(gclass5_3.LogicClientAvatar.GetAllianceId());
				village2BattleResultAttackEntry.SetAllianceName(gclass5_3.LogicClientAvatar.GetAllianceName());
				village2BattleResultAttackEntry.SetAllianceBadgeId(gclass5_3.LogicClientAvatar.GetAllianceBadgeId());
				village2BattleResultAttackEntry.SetAllianceExpLevel(gclass5_3.LogicClientAvatar.GetAllianceLevel());
			}
			village2BattleResultAttackEntry.SetRemainingSeconds(LogicDataTables.GetGlobals().GetAttackLengthSecs() + LogicDataTables.GetGlobals().GetAttackVillage2PreparationLengthSecs());
			ServerRequestManager.Create(new CreateVillage2AttackEntryRequestMessage
			{
				Entry = village2BattleResultAttackEntry,
				OwnerId = @class.gclass5_0.Id
			}, ServerManager.GetDocumentSocket(11, @class.gclass5_0.Id), 30).OnComplete = new ServerRequestArgs.CompleteHandler(@class.method_0);
		}

		// Token: 0x060000EA RID: 234 RVA: 0x0000729C File Offset: 0x0000549C
		public void method_3(GClass5 gclass5_2)
		{
			GClass18 gclass = this.gclass5_0.Id.Equals(gclass5_2.Id) ? this.gclass18_0 : this.gclass18_1;
			if (gclass.method_2())
			{
				return;
			}
			gclass.method_3(true);
		}

		// Token: 0x060000EB RID: 235 RVA: 0x000072E0 File Offset: 0x000054E0
		public void method_4(DuelProgressMessage duelProgressMessage_0)
		{
			if (this.gclass5_0.Id.Equals(duelProgressMessage_0.AvatarId))
			{
				if (!this.gclass18_0.method_2())
				{
					if (this.gclass18_0.method_6() != duelProgressMessage_0.RemainingSeconds)
					{
						this.gclass18_0.method_7(duelProgressMessage_0.RemainingSeconds);
						this.method_12(this.village2BattleResultAttackEntry_1, this.gclass18_1, this.gclass18_0);
						return;
					}
				}
				return;
			}
			if (!this.gclass18_1.method_2())
			{
				if (this.gclass18_1.method_6() != duelProgressMessage_0.RemainingSeconds)
				{
					this.gclass18_1.method_7(duelProgressMessage_0.RemainingSeconds);
					this.method_12(this.village2BattleResultAttackEntry_0, this.gclass18_0, this.gclass18_1);
					return;
				}
			}
		}

		// Token: 0x060000EC RID: 236 RVA: 0x000073A0 File Offset: 0x000055A0
		public void method_5(DuelResultMessage duelResultMessage_0)
		{
			GClass18 gclass = this.gclass5_0.Id.Equals(duelResultMessage_0.AvatarId) ? this.gclass18_0 : this.gclass18_1;
			if (gclass.method_2())
			{
				return;
			}
			gclass.method_3(true);
			gclass.method_7(0);
			gclass.method_1(duelResultMessage_0.ReplayId);
			gclass.method_15(duelResultMessage_0.BattleLog);
			gclass.method_13(duelResultMessage_0.DestructionPercentage);
			gclass.method_11(duelResultMessage_0.Stars);
			if (this.gclass18_0.method_2() && this.gclass18_1.method_2())
			{
				this.method_7();
			}
			this.method_12(this.village2BattleResultAttackEntry_0, this.gclass18_0, this.gclass18_1);
			this.method_12(this.village2BattleResultAttackEntry_1, this.gclass18_1, this.gclass18_0);
		}

		// Token: 0x060000ED RID: 237 RVA: 0x0000746C File Offset: 0x0000566C
		public void method_6()
		{
			if (this.bool_0)
			{
				Logging.Error("GameDuel.stopDuel: duel already stopped!");
				return;
			}
			this.gclass18_0.method_3(true);
			this.gclass18_1.method_3(true);
			this.method_7();
			this.method_12(this.village2BattleResultAttackEntry_0, this.gclass18_0, this.gclass18_1);
			this.method_12(this.village2BattleResultAttackEntry_1, this.gclass18_1, this.gclass18_0);
		}

		// Token: 0x060000EE RID: 238 RVA: 0x000074DC File Offset: 0x000056DC
		private void method_7()
		{
			if (this.bool_0)
			{
				return;
			}
			this.bool_0 = true;
			this.method_9();
			if (this.gclass5_0.method_4() == this)
			{
				this.gclass5_0.method_5(null);
			}
			if (this.gclass5_1.method_4() == this)
			{
				this.gclass5_1.method_5(null);
			}
			GClass19.smethod_2(this.long_0);
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00007540 File Offset: 0x00005740
		public void method_8(DuelAttackEventMessage duelAttackEventMessage_0)
		{
			if (this.gclass5_0.Id.Equals(duelAttackEventMessage_0.AvatarId))
			{
				if (this.gclass5_1.method_0() == null)
				{
					return;
				}
				AttackEventMessage attackEventMessage = new AttackEventMessage();
				attackEventMessage.SetEventType(duelAttackEventMessage_0.Type);
				attackEventMessage.SetEventArg(this.gclass18_1.method_6());
				this.gclass5_1.method_0().SendPiranhaMessage(attackEventMessage, 1);
				return;
			}
			else
			{
				if (this.gclass5_0.method_0() == null)
				{
					return;
				}
				AttackEventMessage attackEventMessage2 = new AttackEventMessage();
				attackEventMessage2.SetEventType(duelAttackEventMessage_0.Type);
				attackEventMessage2.SetEventArg(this.gclass18_0.method_6());
				this.gclass5_0.method_0().SendPiranhaMessage(attackEventMessage2, 1);
				return;
			}
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x000075EC File Offset: 0x000057EC
		private void method_9()
		{
			int num = 2;
			int num2 = 2;
			if (this.gclass18_0.method_10() != this.gclass18_1.method_10())
			{
				if (this.gclass18_0.method_10() > this.gclass18_1.method_10())
				{
					num = 1;
					num2 = 0;
				}
				else
				{
					num2 = 1;
					num = 0;
				}
			}
			else if (this.gclass18_0.method_12() != this.gclass18_1.method_12())
			{
				if (this.gclass18_0.method_12() > this.gclass18_1.method_12())
				{
					num = 1;
					num2 = 0;
				}
				else
				{
					num2 = 1;
					num = 0;
				}
			}
			this.gclass18_0.method_9(num);
			this.gclass18_1.method_9(num2);
			if (num != 2 && num2 != 2)
			{
				int duelScore = this.gclass5_0.LogicClientAvatar.GetDuelScore();
				int duelScore2 = this.gclass5_1.LogicClientAvatar.GetDuelScore();
				int num3 = LogicELOMath.CalculateNewRating(num == 1, duelScore, duelScore2, 60);
				int num4 = LogicELOMath.CalculateNewRating(num2 == 1, duelScore2, duelScore, 60);
				int num5 = num3 - duelScore;
				int num6 = num4 - duelScore2;
				if (duelScore < 1000 && num5 < 0)
				{
					num5 = duelScore * num5 / 1000;
				}
				if (duelScore2 < 1000 && num6 < 0)
				{
					num6 = duelScore2 * num6 / 1000;
				}
				if (num == 1 && num5 <= 0)
				{
					num5 = 1;
				}
				if (num2 == 1 && num6 <= 0)
				{
					num6 = 1;
				}
				this.gclass18_0.method_17(num5);
				this.gclass18_1.method_17(num6);
				this.method_10(this.gclass5_0, num, num5);
				this.method_10(this.gclass5_1, num2, num6);
				this.method_11(this.gclass5_0, this.gclass18_0, this.village2BattleResultAttackEntry_0, duelScore);
				this.method_11(this.gclass5_1, this.gclass18_1, this.village2BattleResultAttackEntry_1, duelScore2);
			}
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00007798 File Offset: 0x00005998
		private void method_10(GClass5 gclass5_2, int int_0, int int_1)
		{
			LogicDuelScoreChangedCommand logicDuelScoreChangedCommand = new LogicDuelScoreChangedCommand();
			logicDuelScoreChangedCommand.SetData(int_1, int_0, false);
			gclass5_2.method_13(logicDuelScoreChangedCommand);
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x000077BC File Offset: 0x000059BC
		private void method_11(GClass5 gclass5_2, GClass18 gclass18_2, Village2BattleResultAttackEntry village2BattleResultAttackEntry_2, int int_0)
		{
			if (gclass18_2.method_8() != 1)
			{
				return;
			}
			if (gclass5_2.LogicClientAvatar.GetLootLimitCooldown())
			{
				return;
			}
			LogicDuelLootAwardedCommand logicDuelLootAwardedCommand = new LogicDuelLootAwardedCommand();
			LogicLeagueVillage2Data leagueVillage = LogicGamePlayUtil.GetLeagueVillage2(int_0);
			gclass18_2.method_19(leagueVillage.GetGoldReward());
			gclass18_2.method_21(leagueVillage.GetGoldReward());
			if (gclass5_2.LogicClientAvatar.GetVariableByName("LootLimitWinCount") == 2)
			{
				gclass18_2.method_5(true);
				gclass18_2.method_23(leagueVillage.GetBonusGold());
				gclass18_2.method_25(leagueVillage.GetBonusElixir());
			}
			LogicLong matchId = (village2BattleResultAttackEntry_2 != null) ? village2BattleResultAttackEntry_2.GetId() : new LogicLong(-1, -1);
			logicDuelLootAwardedCommand.SetDatas(gclass18_2.method_18(), gclass18_2.method_20(), gclass18_2.method_22(), gclass18_2.method_24(), matchId);
			gclass5_2.method_13(logicDuelLootAwardedCommand);
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00007874 File Offset: 0x00005A74
		private void method_12(Village2BattleResultAttackEntry village2BattleResultAttackEntry_2, GClass18 gclass18_2, GClass18 gclass18_3)
		{
			village2BattleResultAttackEntry_2.SetRemainingSeconds(gclass18_3.method_6());
			if (gclass18_2.method_2())
			{
				village2BattleResultAttackEntry_2.SetAttackerStars(gclass18_2.method_10());
				village2BattleResultAttackEntry_2.SetAttackerDestructionPercentage(gclass18_2.method_12());
				if (gclass18_2.method_0() != null)
				{
					village2BattleResultAttackEntry_2.SetAttackerReplayId(gclass18_2.method_0());
					village2BattleResultAttackEntry_2.SetAttackerReplayMajorVersion(9);
					village2BattleResultAttackEntry_2.SetAttackerReplayBuildVersion(256);
					village2BattleResultAttackEntry_2.SetAttackerReplayContentVersion(ResourceManager.GetContentVersion());
				}
				village2BattleResultAttackEntry_2.SetAttackerBattleLog(gclass18_2.method_14());
			}
			if (gclass18_3.method_2())
			{
				village2BattleResultAttackEntry_2.SetOpponentStars(gclass18_3.method_10());
				village2BattleResultAttackEntry_2.SetOpponentDestructionPercentage(gclass18_3.method_12());
				if (gclass18_3.method_0() != null)
				{
					village2BattleResultAttackEntry_2.SetOpponentReplayId(gclass18_3.method_0());
					village2BattleResultAttackEntry_2.SetOpponentReplayMajorVersion(9);
					village2BattleResultAttackEntry_2.SetOpponentReplayBuildVersion(256);
					village2BattleResultAttackEntry_2.SetOpponentReplayContentVersion(ResourceManager.GetContentVersion());
				}
				village2BattleResultAttackEntry_2.SetOpponentBattleLog(gclass18_3.method_14());
			}
			if (this.bool_0)
			{
				village2BattleResultAttackEntry_2.SetBattleEnded(true);
				village2BattleResultAttackEntry_2.SetResultType(gclass18_2.method_8());
				village2BattleResultAttackEntry_2.SetScoreCount(gclass18_2.method_16());
				village2BattleResultAttackEntry_2.SetGoldCount(gclass18_2.method_18());
				village2BattleResultAttackEntry_2.SetElixirCount(gclass18_2.method_20());
				if (gclass18_2.method_4())
				{
					village2BattleResultAttackEntry_2.SetBonusGoldCount(gclass18_2.method_22());
					village2BattleResultAttackEntry_2.SetBonusElixirCount(gclass18_2.method_24());
				}
			}
			this.method_13(village2BattleResultAttackEntry_2);
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x000079B0 File Offset: 0x00005BB0
		private void method_13(Village2AttackEntry village2AttackEntry_0)
		{
			GClass5 gclass = (this.village2BattleResultAttackEntry_0 == village2AttackEntry_0) ? this.gclass5_0 : this.gclass5_1;
			if (gclass.method_0() != null)
			{
				Village2AttackEntryUpdateMessage village2AttackEntryUpdateMessage = new Village2AttackEntryUpdateMessage();
				village2AttackEntryUpdateMessage.SetAttackEntry(village2AttackEntry_0);
				gclass.method_0().SendPiranhaMessage(village2AttackEntryUpdateMessage, 1);
			}
			ServerMessageManager.SendMessage(new UpdateVillage2AttackEntryMessage
			{
				AccountId = village2AttackEntry_0.GetId(),
				Entry = village2AttackEntry_0
			}, ServerManager.GetDocumentSocket(11, gclass.Id));
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00002B18 File Offset: 0x00000D18
		public LogicLong method_14(GClass5 gclass5_2)
		{
			if (gclass5_2 != this.gclass5_0)
			{
				return this.logicLong_0;
			}
			return this.logicLong_1;
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00007A24 File Offset: 0x00005C24
		public bool method_15()
		{
			return DateTime.UtcNow.Subtract(this.method_0()).TotalMinutes >= 10.0;
		}

		// Token: 0x0400004A RID: 74
		[CompilerGenerated]
		private readonly DateTime dateTime_0;

		// Token: 0x0400004B RID: 75
		private readonly long long_0;

		// Token: 0x0400004C RID: 76
		private readonly GClass5 gclass5_0;

		// Token: 0x0400004D RID: 77
		private readonly GClass5 gclass5_1;

		// Token: 0x0400004E RID: 78
		private readonly LogicLong logicLong_0;

		// Token: 0x0400004F RID: 79
		private readonly LogicLong logicLong_1;

		// Token: 0x04000050 RID: 80
		private Village2BattleResultAttackEntry village2BattleResultAttackEntry_0;

		// Token: 0x04000051 RID: 81
		private Village2BattleResultAttackEntry village2BattleResultAttackEntry_1;

		// Token: 0x04000052 RID: 82
		private GClass18 gclass18_0;

		// Token: 0x04000053 RID: 83
		private GClass18 gclass18_1;

		// Token: 0x04000054 RID: 84
		private bool bool_0;

		// Token: 0x0200001F RID: 31
		[CompilerGenerated]
		private sealed class Class11
		{
			// Token: 0x060000F8 RID: 248 RVA: 0x00007A5C File Offset: 0x00005C5C
			internal void method_0(ServerRequestArgs serverRequestArgs_0)
			{
				if (serverRequestArgs_0.ErrorCode == ServerRequestError.Success && serverRequestArgs_0.ResponseMessage.Success)
				{
					Village2BattleResultAttackEntry village2BattleResultAttackEntry = (Village2BattleResultAttackEntry)((CreateVillage2AttackEntryResponseMessage)serverRequestArgs_0.ResponseMessage).Entry;
					if (this.gclass17_0.gclass5_0 == this.gclass5_0)
					{
						this.gclass17_0.village2BattleResultAttackEntry_0 = village2BattleResultAttackEntry;
						this.gclass17_0.gclass5_0.method_18(village2BattleResultAttackEntry);
						this.gclass17_0.method_12(this.gclass17_0.village2BattleResultAttackEntry_0, this.gclass17_0.gclass18_0, this.gclass17_0.gclass18_1);
						return;
					}
					this.gclass17_0.village2BattleResultAttackEntry_1 = village2BattleResultAttackEntry;
					this.gclass17_0.gclass5_1.method_18(village2BattleResultAttackEntry);
					this.gclass17_0.method_12(this.gclass17_0.village2BattleResultAttackEntry_1, this.gclass17_0.gclass18_1, this.gclass17_0.gclass18_0);
				}
			}

			// Token: 0x04000055 RID: 85
			public GClass17 gclass17_0;

			// Token: 0x04000056 RID: 86
			public GClass5 gclass5_0;
		}
	}
}
