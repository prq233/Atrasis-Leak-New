using System;
using Atrasis.Magic.Logic.Command;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Mode
{
	// Token: 0x02000024 RID: 36
	public class LogicGameListener
	{
		// Token: 0x06000168 RID: 360 RVA: 0x00002463 File Offset: 0x00000663
		public void Destruct()
		{
		}

		// Token: 0x06000169 RID: 361 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void ReplayFailed()
		{
		}

		// Token: 0x0600016A RID: 362 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void NotEnoughWorkers(LogicCommand command, int villageType)
		{
		}

		// Token: 0x0600016B RID: 363 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void NotEnoughResources(LogicResourceData data, int count, LogicCommand command, bool unk)
		{
		}

		// Token: 0x0600016C RID: 364 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void NotEnoughResources(LogicResourceData data1, int count1, LogicResourceData data2, int count2, LogicCommand command, bool unk)
		{
		}

		// Token: 0x0600016D RID: 365 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void NotEnoughDiamonds()
		{
		}

		// Token: 0x0600016E RID: 366 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void BuildingCapReached(LogicBuildingData data)
		{
		}

		// Token: 0x0600016F RID: 367 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void BuildingGearUpCapReached(LogicBuildingData data)
		{
		}

		// Token: 0x06000170 RID: 368 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void TrapCapReached(LogicTrapData data)
		{
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void DecoCapReached(LogicDecoData data)
		{
		}

		// Token: 0x06000172 RID: 370 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void AllianceCreated()
		{
		}

		// Token: 0x06000173 RID: 371 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void AllianceJoined()
		{
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void AllianceLeft()
		{
		}

		// Token: 0x06000175 RID: 373 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void AllianceSettingsChanged()
		{
		}

		// Token: 0x06000176 RID: 374 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void LevelUp(int expLevel)
		{
		}

		// Token: 0x06000177 RID: 375 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void ShowTroopPlacementTutorial(int data)
		{
		}

		// Token: 0x06000178 RID: 376 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void TownHallLevelTooLow(int lvl)
		{
		}

		// Token: 0x06000179 RID: 377 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void AchievementCompleted(LogicAchievementData data)
		{
		}

		// Token: 0x0600017A RID: 378 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void AchievementProgress(LogicAchievementData data)
		{
		}

		// Token: 0x0600017B RID: 379 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void DiamondsBought()
		{
		}

		// Token: 0x0600017C RID: 380 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void UnitUpgradeCompleted(LogicCombatItemData data, int upgLevel, bool tick)
		{
		}

		// Token: 0x0600017D RID: 381 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void MatchmakingCommandExecuted()
		{
		}

		// Token: 0x0600017E RID: 382 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void MatchmakingVillage2CommandExecuted()
		{
		}

		// Token: 0x0600017F RID: 383 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void AttackerPlaced(LogicData data)
		{
		}

		// Token: 0x06000180 RID: 384 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void BattleEndedByPlayer()
		{
		}

		// Token: 0x06000181 RID: 385 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void LegendSeasonScoreChanged(int state, int score, int scoreChange, bool bestSeason, int villageType)
		{
		}

		// Token: 0x06000182 RID: 386 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void ChallengeStateChanged(LogicLong challengeId, LogicLong argsId, int challengeState)
		{
		}

		// Token: 0x06000183 RID: 387 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void CancelFriendlyVersusBattle()
		{
		}

		// Token: 0x06000184 RID: 388 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void NameChanged(string name)
		{
		}

		// Token: 0x06000185 RID: 389 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void UnitReceivedFromAlliance(string name, LogicCombatItemData data, int upgLevel)
		{
		}

		// Token: 0x06000186 RID: 390 RVA: 0x00002B33 File Offset: 0x00000D33
		public virtual LogicJSONObject ParseCompressedHomeJSON(byte[] compressed, int length)
		{
			return null;
		}

		// Token: 0x06000187 RID: 391 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void StarBonusAdded(int goldCount, int elixirCount, int darkElixirCount)
		{
		}

		// Token: 0x06000188 RID: 392 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void DuelReplayShared(LogicLong replayId)
		{
		}

		// Token: 0x06000189 RID: 393 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void ShieldActivated(int hours)
		{
		}
	}
}
