using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Avatar.Change;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Servers.Core.Network.Message.Session.Change;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace ns0
{
	// Token: 0x0200000D RID: 13
	public class GClass7 : LogicAvatarChangeListener
	{
		// Token: 0x06000036 RID: 54 RVA: 0x0000229E File Offset: 0x0000049E
		public GClass7(GClass6 gclass6_1, LogicClientAvatar logicClientAvatar_1, bool bool_1)
		{
			this.gclass6_0 = gclass6_1;
			this.logicClientAvatar_0 = logicClientAvatar_1;
			this.bool_0 = bool_1;
			if (bool_1)
			{
				this.logicArrayList_0 = new LogicArrayList<AvatarChange>();
			}
		}

		// Token: 0x06000037 RID: 55 RVA: 0x000022C9 File Offset: 0x000004C9
		public LogicArrayList<AvatarChange> method_0()
		{
			LogicArrayList<AvatarChange> logicArrayList = new LogicArrayList<AvatarChange>();
			logicArrayList.AddAll(this.logicArrayList_0);
			this.logicArrayList_0.Clear();
			return logicArrayList;
		}

		// Token: 0x06000038 RID: 56 RVA: 0x000022E7 File Offset: 0x000004E7
		public override void FreeDiamondsAdded(int count, int mode)
		{
			if (!this.bool_0)
			{
				return;
			}
			this.logicArrayList_0.Add(new DiamondAvatarChange
			{
				Count = count
			});
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002309 File Offset: 0x00000509
		public override void DiamondPurchaseMade(int type, int globalId, int level, int count, int villageType)
		{
			if (!this.bool_0)
			{
				return;
			}
			this.logicArrayList_0.Add(new DiamondAvatarChange
			{
				Count = -count
			});
		}

		// Token: 0x0600003A RID: 58 RVA: 0x0000232D File Offset: 0x0000052D
		public override void CommodityCountChanged(int commodityType, LogicData data, int count)
		{
			if (!this.bool_0)
			{
				return;
			}
			this.logicArrayList_0.Add(new CommodityCountAvatarChange
			{
				Type = commodityType,
				Data = data,
				Count = count
			});
		}

		// Token: 0x0600003B RID: 59 RVA: 0x0000235D File Offset: 0x0000055D
		public override void ExpPointsGained(int count)
		{
			if (!this.bool_0)
			{
				return;
			}
			this.logicArrayList_0.Add(new ExpPointsAvatarChange
			{
				Points = count
			});
		}

		// Token: 0x0600003C RID: 60 RVA: 0x0000237F File Offset: 0x0000057F
		public override void ExpLevelGained(int count)
		{
			if (!this.bool_0)
			{
				return;
			}
			this.logicArrayList_0.Add(new ExpLevelAvatarChange
			{
				Points = count
			});
		}

		// Token: 0x0600003D RID: 61 RVA: 0x000023A1 File Offset: 0x000005A1
		public override void AllianceJoined(LogicLong allianceId, string allianceName, int allianceBadgeId, int allianceExpLevel, LogicAvatarAllianceRole allianceRole)
		{
			if (!this.bool_0)
			{
				return;
			}
			this.logicArrayList_0.Add(new AllianceJoinedAvatarChange
			{
				AllianceId = allianceId,
				AllianceName = allianceName,
				AllianceBadgeId = allianceBadgeId,
				AllianceExpLevel = allianceExpLevel,
				AllianceRole = allianceRole
			});
		}

		// Token: 0x0600003E RID: 62 RVA: 0x000023E1 File Offset: 0x000005E1
		public override void AllianceLeft()
		{
			if (!this.bool_0)
			{
				return;
			}
			this.logicArrayList_0.Add(new AllianceLeftAvatarChange());
		}

		// Token: 0x0600003F RID: 63 RVA: 0x000023FC File Offset: 0x000005FC
		public override void AllianceLevelChanged(int expLevel)
		{
			if (!this.bool_0)
			{
				return;
			}
			this.logicArrayList_0.Add(new AllianceLevelAvatarChange
			{
				Level = expLevel
			});
		}

		// Token: 0x06000040 RID: 64 RVA: 0x0000241E File Offset: 0x0000061E
		public override void AllianceUnitAdded(LogicCombatItemData data, int upgLevel)
		{
			if (!this.bool_0)
			{
				return;
			}
			this.logicArrayList_0.Add(new AllianceUnitAddedAvatarChange
			{
				Data = data,
				UpgradeLevel = upgLevel
			});
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002447 File Offset: 0x00000647
		public override void AllianceUnitRemoved(LogicCombatItemData data, int upgLevel)
		{
			if (!this.bool_0)
			{
				return;
			}
			this.logicArrayList_0.Add(new AllianceUnitRemovedAvatarChange
			{
				Data = data,
				UpgradeLevel = upgLevel
			});
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00002470 File Offset: 0x00000670
		public override void AllianceUnitCountChanged(LogicCombatItemData data, int upgLevel, int count)
		{
			if (!this.bool_0)
			{
				return;
			}
			this.logicArrayList_0.Add(new AllianceUnitCountAvatarChange
			{
				Data = data,
				UpgradeLevel = upgLevel,
				Count = count
			});
		}

		// Token: 0x06000043 RID: 67 RVA: 0x000024A0 File Offset: 0x000006A0
		public override void SetAllianceCastleLevel(int count)
		{
			if (!this.bool_0)
			{
				return;
			}
			this.logicArrayList_0.Add(new AllianceCastleLevelAvatarChange
			{
				Level = count
			});
		}

		// Token: 0x06000044 RID: 68 RVA: 0x000024C2 File Offset: 0x000006C2
		public override void SetTownHallLevel(int count)
		{
			if (!this.bool_0)
			{
				return;
			}
			this.logicArrayList_0.Add(new TownHallLevelAvatarChange
			{
				Level = count
			});
		}

		// Token: 0x06000045 RID: 69 RVA: 0x000024E4 File Offset: 0x000006E4
		public override void SetVillage2TownHallLevel(int count)
		{
			if (!this.bool_0)
			{
				return;
			}
			this.logicArrayList_0.Add(new TownHallV2LevelAvatarChange
			{
				Level = count
			});
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00002506 File Offset: 0x00000706
		public override void LegendSeasonScoreChanged(int state, int score, int scoreChange, bool bestSeason, int villageType)
		{
			if (!this.bool_0)
			{
				return;
			}
			this.logicArrayList_0.Add(new LegendSeasonScoreAvatarChange
			{
				Entry = ((villageType == 0) ? this.logicClientAvatar_0.GetLegendSeasonEntry() : this.logicClientAvatar_0.GetLegendSeasonEntryVillage2())
			});
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00002543 File Offset: 0x00000743
		public override void ScoreChanged(LogicLong allianceId, int scoreGain, int minScoreGain, bool attacker, LogicLeagueData leagueData, LogicLeagueData prevLeagueData, int destructionPercentage)
		{
			if (!this.bool_0)
			{
				return;
			}
			this.logicArrayList_0.Add(new ScoreAvatarChange
			{
				Attacker = attacker,
				LeagueData = leagueData,
				PrevLeagueData = prevLeagueData,
				ScoreGain = scoreGain
			});
		}

		// Token: 0x06000048 RID: 72 RVA: 0x0000257D File Offset: 0x0000077D
		public override void DuelScoreChanged(LogicLong allianceId, int duelScoreGain, int resultType, bool attacker)
		{
			if (!this.bool_0)
			{
				return;
			}
			this.logicArrayList_0.Add(new DuelScoreAvatarChange
			{
				Attacker = attacker,
				DuelScoreGain = duelScoreGain,
				ResultType = resultType
			});
		}

		// Token: 0x06000049 RID: 73 RVA: 0x000025AE File Offset: 0x000007AE
		public override void LeagueChanged(int leagueType, LogicLong leagueInstanceId)
		{
			if (!this.bool_0)
			{
				return;
			}
			this.logicArrayList_0.Add(new LeagueAvatarChange
			{
				LeagueInstanceId = leagueInstanceId,
				LeagueType = leagueType
			});
		}

		// Token: 0x0600004A RID: 74 RVA: 0x000025D7 File Offset: 0x000007D7
		public override void AttackShieldReduceCounterChanged(int count)
		{
			if (!this.bool_0)
			{
				return;
			}
			this.logicArrayList_0.Add(new AttackShieldReduceCounterAvatarChange
			{
				Count = count
			});
		}

		// Token: 0x0600004B RID: 75 RVA: 0x000025F9 File Offset: 0x000007F9
		public override void DefenseVillageGuardCounterChanged(int count)
		{
			if (!this.bool_0)
			{
				return;
			}
			this.logicArrayList_0.Add(new DefenseVillageGuardCounterAvatarChange
			{
				Count = count
			});
		}

		// Token: 0x0600004C RID: 76 RVA: 0x0000261B File Offset: 0x0000081B
		public override void REDPackageStateChanged(int value)
		{
			if (!this.bool_0)
			{
				return;
			}
			this.logicArrayList_0.Add(new REDPackageStateAvatarChange
			{
				State = value
			});
		}

		// Token: 0x0600004D RID: 77 RVA: 0x0000263D File Offset: 0x0000083D
		public override void BattleFeedback(int type, int stars)
		{
			this.gclass6_0.method_9(type, stars);
		}

		// Token: 0x0400001D RID: 29
		private readonly GClass6 gclass6_0;

		// Token: 0x0400001E RID: 30
		private readonly LogicClientAvatar logicClientAvatar_0;

		// Token: 0x0400001F RID: 31
		private readonly LogicArrayList<AvatarChange> logicArrayList_0;

		// Token: 0x04000020 RID: 32
		private readonly bool bool_0;
	}
}
