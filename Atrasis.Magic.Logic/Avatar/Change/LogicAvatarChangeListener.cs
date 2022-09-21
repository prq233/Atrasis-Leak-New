using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Offer;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Avatar.Change
{
	// Token: 0x02000203 RID: 515
	public class LogicAvatarChangeListener
	{
		// Token: 0x06001B26 RID: 6950 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void Destruct()
		{
		}

		// Token: 0x06001B27 RID: 6951 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void FreeDiamondsAdded(int count, int mode)
		{
		}

		// Token: 0x06001B28 RID: 6952 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void DiamondPurchaseMade(int type, int globalId, int level, int count, int villageType)
		{
		}

		// Token: 0x06001B29 RID: 6953 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void CommodityCountChanged(int commodityType, LogicData data, int count)
		{
		}

		// Token: 0x06001B2A RID: 6954 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void WarPreferenceChanged(int preference)
		{
		}

		// Token: 0x06001B2B RID: 6955 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void RevengeUsed(LogicLong id)
		{
		}

		// Token: 0x06001B2C RID: 6956 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void ExpPointsGained(int count)
		{
		}

		// Token: 0x06001B2D RID: 6957 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void ExpLevelGained(int count)
		{
		}

		// Token: 0x06001B2E RID: 6958 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void AllianceJoined(LogicLong allianceId, string allianceName, int allianceBadgeId, int allianceExpLevel, LogicAvatarAllianceRole allianceRole)
		{
		}

		// Token: 0x06001B2F RID: 6959 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void AllianceLevelChanged(int expLevel)
		{
		}

		// Token: 0x06001B30 RID: 6960 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void AllianceLeft()
		{
		}

		// Token: 0x06001B31 RID: 6961 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void AllianceUnitDonateOk(LogicCombatItemData data, int upgLevel, LogicLong streamId, bool quickDonate)
		{
		}

		// Token: 0x06001B32 RID: 6962 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void AllianceUnitDonateFailed(LogicCombatItemData data, int upgLevel, LogicLong streamId, bool quickDonate)
		{
		}

		// Token: 0x06001B33 RID: 6963 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void WarDonateOk(LogicCombatItemData data, int upgLevel, LogicLong streamId, bool quickDonate)
		{
		}

		// Token: 0x06001B34 RID: 6964 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void WarDonateFailed(LogicCombatItemData data, int upgLevel, LogicLong streamId, bool quickDonate)
		{
		}

		// Token: 0x06001B35 RID: 6965 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void StartWar(LogicArrayList<LogicLong> excludeMembers)
		{
		}

		// Token: 0x06001B36 RID: 6966 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void CancelWar()
		{
		}

		// Token: 0x06001B37 RID: 6967 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void StartArrangedWar(LogicArrayList<LogicLong> excludeMembers, LogicLong allianceId, int unk1, int unk2, int unk3)
		{
		}

		// Token: 0x06001B38 RID: 6968 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void AllianceUnitRemoved(LogicCombatItemData data, int upgLevel)
		{
		}

		// Token: 0x06001B39 RID: 6969 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void AllianceUnitAdded(LogicCombatItemData data, int upgLevel)
		{
		}

		// Token: 0x06001B3A RID: 6970 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void AllianceUnitCountChanged(LogicCombatItemData data, int upgLevel, int count)
		{
		}

		// Token: 0x06001B3B RID: 6971 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void RequestAllianceUnits(int upgLevel, int usedCapacity, int maxCapacity, int spellUsedCapacity, int maxSpellCapacity, string message)
		{
		}

		// Token: 0x06001B3C RID: 6972 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void SetAllianceCastleLevel(int count)
		{
		}

		// Token: 0x06001B3D RID: 6973 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void KickPlayer(LogicLong playerId, string message)
		{
		}

		// Token: 0x06001B3E RID: 6974 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void SetTownHallLevel(int count)
		{
		}

		// Token: 0x06001B3F RID: 6975 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void SetVillage2TownHallLevel(int count)
		{
		}

		// Token: 0x06001B40 RID: 6976 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void DeliverableAllianceGift(LogicDeliverableGift deliverableGift)
		{
		}

		// Token: 0x06001B41 RID: 6977 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void LegendSeasonScoreChanged(int state, int score, int scoreChange, bool bestSeason, int villageType)
		{
		}

		// Token: 0x06001B42 RID: 6978 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void ScoreChanged(LogicLong allianceId, int scoreGain, int minScoreGain, bool attacker, LogicLeagueData leagueData, LogicLeagueData prevLeagueData, int destructionPercentage)
		{
		}

		// Token: 0x06001B43 RID: 6979 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void DuelScoreChanged(LogicLong allianceId, int duelScoreGain, int resultType, bool attacker)
		{
		}

		// Token: 0x06001B44 RID: 6980 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void SendClanMail(string message)
		{
		}

		// Token: 0x06001B45 RID: 6981 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void ShareReplay(LogicLong replayId, string message)
		{
		}

		// Token: 0x06001B46 RID: 6982 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void ShareDuelReplay(LogicLong replayId, string message)
		{
		}

		// Token: 0x06001B47 RID: 6983 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void AllianceChatFilterChanged(bool enabled)
		{
		}

		// Token: 0x06001B48 RID: 6984 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void SendChallengeRequest(string message, int layoutId, bool warLayout, int villageType)
		{
		}

		// Token: 0x06001B49 RID: 6985 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void SendFriendlyBattleRequest(string message, LogicLong id, int layoutId, bool warLayout, int villageType)
		{
		}

		// Token: 0x06001B4A RID: 6986 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void StarBonusAdded(int goldCount, int elixirCount, int darkElixirCount)
		{
		}

		// Token: 0x06001B4B RID: 6987 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void WarTroopRequestMessageChanged(string message)
		{
		}

		// Token: 0x06001B4C RID: 6988 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void LeagueChanged(int leagueType, LogicLong leagueInstanceId)
		{
		}

		// Token: 0x06001B4D RID: 6989 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void AllianceXpGained(int count)
		{
		}

		// Token: 0x06001B4E RID: 6990 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void AttackStarted()
		{
		}

		// Token: 0x06001B4F RID: 6991 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void AttackShieldReduceCounterChanged(int count)
		{
		}

		// Token: 0x06001B50 RID: 6992 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void DefenseVillageGuardCounterChanged(int count)
		{
		}

		// Token: 0x06001B51 RID: 6993 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void BattleFeedback(int type, int stars)
		{
		}

		// Token: 0x06001B52 RID: 6994 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void REDPackageStateChanged(int value)
		{
		}

		// Token: 0x06001B53 RID: 6995 RVA: 0x00002B30 File Offset: 0x00000D30
		public virtual int GetCurrentTimestamp()
		{
			return -1;
		}
	}
}
