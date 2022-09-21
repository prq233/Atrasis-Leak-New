using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Avatar.Change;
using Atrasis.Magic.Logic.Command.Server;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Account;
using Atrasis.Magic.Servers.Core.Network.Message.Session.Change;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace ns0
{
	// Token: 0x0200001D RID: 29
	public class GClass16 : LogicAvatarChangeListener
	{
		// Token: 0x060000CB RID: 203 RVA: 0x00002827 File Offset: 0x00000A27
		public GClass16(LogicClientAvatar logicClientAvatar_1)
		{
			this.logicClientAvatar_0 = logicClientAvatar_1;
			this.logicArrayList_0 = new LogicArrayList<AvatarChange>();
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00002841 File Offset: 0x00000A41
		public bool method_0()
		{
			return this.logicArrayList_0.Size() != 0;
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00002851 File Offset: 0x00000A51
		public LogicArrayList<AvatarChange> method_1()
		{
			LogicArrayList<AvatarChange> logicArrayList = new LogicArrayList<AvatarChange>();
			logicArrayList.AddAll(this.logicArrayList_0);
			this.logicArrayList_0.Clear();
			return logicArrayList;
		}

		// Token: 0x060000CE RID: 206 RVA: 0x0000286F File Offset: 0x00000A6F
		public override void FreeDiamondsAdded(int count, int mode)
		{
			this.logicArrayList_0.Add(new DiamondAvatarChange
			{
				Count = count
			});
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00002888 File Offset: 0x00000A88
		public override void DiamondPurchaseMade(int type, int globalId, int level, int count, int villageType)
		{
			this.logicArrayList_0.Add(new DiamondAvatarChange
			{
				Count = -count
			});
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x000028A3 File Offset: 0x00000AA3
		public override void CommodityCountChanged(int commodityType, LogicData data, int count)
		{
			this.logicArrayList_0.Add(new CommodityCountAvatarChange
			{
				Type = commodityType,
				Data = data,
				Count = count
			});
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00006FD4 File Offset: 0x000051D4
		public override void WarPreferenceChanged(int preference)
		{
			ServerMessageManager.SendMessage(new GameAllowServerCommandMessage
			{
				AccountId = this.logicClientAvatar_0.GetId(),
				ServerCommand = new LogicPersonalWarPreferenceCommand(preference)
			}, 9);
			this.logicArrayList_0.Add(new WarPreferenceAvatarChange
			{
				Preference = preference
			});
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x000028CA File Offset: 0x00000ACA
		public override void ExpPointsGained(int count)
		{
			this.logicArrayList_0.Add(new ExpPointsAvatarChange
			{
				Points = count
			});
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x000028E3 File Offset: 0x00000AE3
		public override void ExpLevelGained(int count)
		{
			this.logicArrayList_0.Add(new ExpLevelAvatarChange
			{
				Points = count
			});
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x000028FC File Offset: 0x00000AFC
		public override void AllianceJoined(LogicLong allianceId, string allianceName, int allianceBadgeId, int allianceExpLevel, LogicAvatarAllianceRole allianceRole)
		{
			this.logicArrayList_0.Add(new AllianceJoinedAvatarChange
			{
				AllianceId = allianceId,
				AllianceName = allianceName,
				AllianceBadgeId = allianceBadgeId,
				AllianceExpLevel = allianceExpLevel,
				AllianceRole = allianceRole
			});
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00002933 File Offset: 0x00000B33
		public override void AllianceLeft()
		{
			this.logicArrayList_0.Add(new AllianceLeftAvatarChange());
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00002945 File Offset: 0x00000B45
		public override void AllianceLevelChanged(int expLevel)
		{
			this.logicArrayList_0.Add(new AllianceLevelAvatarChange
			{
				Level = expLevel
			});
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x0000295E File Offset: 0x00000B5E
		public override void AllianceUnitAdded(LogicCombatItemData data, int upgLevel)
		{
			this.logicArrayList_0.Add(new AllianceUnitAddedAvatarChange
			{
				Data = data,
				UpgradeLevel = upgLevel
			});
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x0000297E File Offset: 0x00000B7E
		public override void AllianceUnitRemoved(LogicCombatItemData data, int upgLevel)
		{
			this.logicArrayList_0.Add(new AllianceUnitRemovedAvatarChange
			{
				Data = data,
				UpgradeLevel = upgLevel
			});
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x0000299E File Offset: 0x00000B9E
		public override void AllianceUnitCountChanged(LogicCombatItemData data, int upgLevel, int count)
		{
			this.logicArrayList_0.Add(new AllianceUnitCountAvatarChange
			{
				Data = data,
				UpgradeLevel = upgLevel,
				Count = count
			});
		}

		// Token: 0x060000DA RID: 218 RVA: 0x000029C5 File Offset: 0x00000BC5
		public override void SetAllianceCastleLevel(int count)
		{
			this.logicArrayList_0.Add(new AllianceCastleLevelAvatarChange
			{
				Level = count
			});
		}

		// Token: 0x060000DB RID: 219 RVA: 0x000029DE File Offset: 0x00000BDE
		public override void SetTownHallLevel(int count)
		{
			this.logicArrayList_0.Add(new TownHallLevelAvatarChange
			{
				Level = count
			});
		}

		// Token: 0x060000DC RID: 220 RVA: 0x000029F7 File Offset: 0x00000BF7
		public override void SetVillage2TownHallLevel(int count)
		{
			this.logicArrayList_0.Add(new TownHallV2LevelAvatarChange
			{
				Level = count
			});
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00002A10 File Offset: 0x00000C10
		public override void LegendSeasonScoreChanged(int state, int score, int scoreChange, bool bestSeason, int villageType)
		{
			this.logicArrayList_0.Add(new LegendSeasonScoreAvatarChange
			{
				Entry = ((villageType == 0) ? this.logicClientAvatar_0.GetLegendSeasonEntry() : this.logicClientAvatar_0.GetLegendSeasonEntryVillage2())
			});
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00002A44 File Offset: 0x00000C44
		public override void ScoreChanged(LogicLong allianceId, int scoreGain, int minScoreGain, bool attacker, LogicLeagueData leagueData, LogicLeagueData prevLeagueData, int destructionPercentage)
		{
			this.logicArrayList_0.Add(new ScoreAvatarChange
			{
				Attacker = attacker,
				LeagueData = leagueData,
				PrevLeagueData = prevLeagueData,
				ScoreGain = scoreGain
			});
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00002A75 File Offset: 0x00000C75
		public override void DuelScoreChanged(LogicLong allianceId, int duelScoreGain, int resultType, bool attacker)
		{
			this.logicArrayList_0.Add(new DuelScoreAvatarChange
			{
				Attacker = attacker,
				DuelScoreGain = duelScoreGain,
				ResultType = resultType
			});
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00002A9D File Offset: 0x00000C9D
		public override void LeagueChanged(int leagueType, LogicLong leagueInstanceId)
		{
			this.logicArrayList_0.Add(new LeagueAvatarChange
			{
				LeagueInstanceId = leagueInstanceId,
				LeagueType = leagueType
			});
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00002ABD File Offset: 0x00000CBD
		public override void AttackShieldReduceCounterChanged(int count)
		{
			this.logicArrayList_0.Add(new AttackShieldReduceCounterAvatarChange
			{
				Count = count
			});
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00002AD6 File Offset: 0x00000CD6
		public override void DefenseVillageGuardCounterChanged(int count)
		{
			this.logicArrayList_0.Add(new DefenseVillageGuardCounterAvatarChange
			{
				Count = count
			});
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00002AEF File Offset: 0x00000CEF
		public override void REDPackageStateChanged(int value)
		{
			this.logicArrayList_0.Add(new REDPackageStateAvatarChange
			{
				State = value
			});
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00007024 File Offset: 0x00005224
		public override void AllianceUnitDonateOk(LogicCombatItemData data, int upgLevel, LogicLong streamId, bool quickDonate)
		{
			if (!this.logicClientAvatar_0.IsInAlliance())
			{
				return;
			}
			ServerMessageManager.SendMessage(new AllianceUnitDonateResponseMessage
			{
				AccountId = this.logicClientAvatar_0.GetAllianceId(),
				MemberId = this.logicClientAvatar_0.GetId(),
				MemberName = this.logicClientAvatar_0.GetName(),
				StreamId = streamId,
				Data = data,
				UpgradeLevel = upgLevel,
				QuickDonate = quickDonate,
				Success = true
			}, 11);
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x000070A4 File Offset: 0x000052A4
		public override void AllianceUnitDonateFailed(LogicCombatItemData data, int upgLevel, LogicLong streamId, bool quickDonate)
		{
			if (!this.logicClientAvatar_0.IsInAlliance())
			{
				return;
			}
			ServerMessageManager.SendMessage(new AllianceUnitDonateResponseMessage
			{
				AccountId = this.logicClientAvatar_0.GetAllianceId(),
				MemberId = this.logicClientAvatar_0.GetId(),
				StreamId = streamId,
				Data = data,
				UpgradeLevel = upgLevel,
				QuickDonate = quickDonate
			}, 11);
		}

		// Token: 0x04000048 RID: 72
		private readonly LogicClientAvatar logicClientAvatar_0;

		// Token: 0x04000049 RID: 73
		private readonly LogicArrayList<AvatarChange> logicArrayList_0;
	}
}
