using System;
using Atrasis.Magic.Logic.Avatar.Change;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Avatar
{
	// Token: 0x020001FE RID: 510
	public abstract class LogicAvatar
	{
		// Token: 0x06001A16 RID: 6678 RVA: 0x00011519 File Offset: 0x0000F719
		public LogicAvatar()
		{
			this.m_allianceCastleLevel = -1;
		}

		// Token: 0x06001A17 RID: 6679 RVA: 0x0006307C File Offset: 0x0006127C
		public virtual void InitBase()
		{
			this.m_listener = new LogicAvatarChangeListener();
			this.m_resourceCount = new LogicArrayList<LogicDataSlot>();
			this.m_resourceCap = new LogicArrayList<LogicDataSlot>();
			this.m_unitCount = new LogicArrayList<LogicDataSlot>();
			this.m_spellCount = new LogicArrayList<LogicDataSlot>();
			this.m_unitUpgrade = new LogicArrayList<LogicDataSlot>();
			this.m_spellUpgrade = new LogicArrayList<LogicDataSlot>();
			this.m_heroUpgrade = new LogicArrayList<LogicDataSlot>();
			this.m_heroHealth = new LogicArrayList<LogicDataSlot>();
			this.m_heroState = new LogicArrayList<LogicDataSlot>();
			this.m_heroMode = new LogicArrayList<LogicDataSlot>();
			this.m_unitCountVillage2 = new LogicArrayList<LogicDataSlot>();
			this.m_unitCountNewVillage2 = new LogicArrayList<LogicDataSlot>();
			this.m_achievementProgress = new LogicArrayList<LogicDataSlot>();
			this.m_lootedNpcGold = new LogicArrayList<LogicDataSlot>();
			this.m_lootedNpcElixir = new LogicArrayList<LogicDataSlot>();
			this.m_npcStars = new LogicArrayList<LogicDataSlot>();
			this.m_variables = new LogicArrayList<LogicDataSlot>();
			this.m_unitPreset1 = new LogicArrayList<LogicDataSlot>();
			this.m_unitPreset2 = new LogicArrayList<LogicDataSlot>();
			this.m_unitPreset3 = new LogicArrayList<LogicDataSlot>();
			this.m_previousArmy = new LogicArrayList<LogicDataSlot>();
			this.m_eventUnitCounter = new LogicArrayList<LogicDataSlot>();
			this.m_allianceUnitCount = new LogicArrayList<LogicUnitSlot>();
			this.m_achievementRewardClaimed = new LogicArrayList<LogicData>();
			this.m_missionCompleted = new LogicArrayList<LogicData>();
			this.m_freeActionCount = new LogicArrayList<LogicDataSlot>();
		}

		// Token: 0x06001A18 RID: 6680 RVA: 0x000631B4 File Offset: 0x000613B4
		public virtual void Destruct()
		{
			if (this.m_listener != null)
			{
				this.m_listener.Destruct();
				this.m_listener = null;
			}
			if (this.m_resourceCap != null)
			{
				this.ClearDataSlotArray(this.m_resourceCap);
				this.m_resourceCap = null;
			}
			if (this.m_unitCount != null)
			{
				this.ClearDataSlotArray(this.m_unitCount);
				this.m_unitCount = null;
			}
			if (this.m_spellCount != null)
			{
				this.ClearDataSlotArray(this.m_spellCount);
				this.m_spellCount = null;
			}
			if (this.m_unitUpgrade != null)
			{
				this.ClearDataSlotArray(this.m_unitUpgrade);
				this.m_unitUpgrade = null;
			}
			if (this.m_spellUpgrade != null)
			{
				this.ClearDataSlotArray(this.m_spellUpgrade);
				this.m_spellUpgrade = null;
			}
			if (this.m_heroUpgrade != null)
			{
				this.ClearDataSlotArray(this.m_heroUpgrade);
				this.m_heroUpgrade = null;
			}
			if (this.m_heroHealth != null)
			{
				this.ClearDataSlotArray(this.m_heroHealth);
				this.m_heroHealth = null;
			}
			if (this.m_heroState != null)
			{
				this.ClearDataSlotArray(this.m_heroState);
				this.m_heroState = null;
			}
			if (this.m_allianceUnitCount != null)
			{
				this.ClearUnitSlotArray(this.m_allianceUnitCount);
				this.m_allianceUnitCount = null;
			}
			if (this.m_achievementProgress != null)
			{
				this.ClearDataSlotArray(this.m_achievementProgress);
				this.m_achievementProgress = null;
			}
			if (this.m_npcStars != null)
			{
				this.ClearDataSlotArray(this.m_npcStars);
				this.m_npcStars = null;
			}
			if (this.m_lootedNpcGold != null)
			{
				this.ClearDataSlotArray(this.m_lootedNpcGold);
				this.m_lootedNpcGold = null;
			}
			if (this.m_lootedNpcElixir != null)
			{
				this.ClearDataSlotArray(this.m_lootedNpcElixir);
				this.m_lootedNpcElixir = null;
			}
			if (this.m_heroMode != null)
			{
				this.ClearDataSlotArray(this.m_heroMode);
				this.m_heroMode = null;
			}
			if (this.m_variables != null)
			{
				this.ClearDataSlotArray(this.m_variables);
				this.m_variables = null;
			}
			if (this.m_unitPreset1 != null)
			{
				this.ClearDataSlotArray(this.m_unitPreset1);
				this.m_unitPreset1 = null;
			}
			if (this.m_unitPreset2 != null)
			{
				this.ClearDataSlotArray(this.m_unitPreset2);
				this.m_unitPreset2 = null;
			}
			if (this.m_unitPreset3 != null)
			{
				this.ClearDataSlotArray(this.m_unitPreset3);
				this.m_unitPreset3 = null;
			}
			if (this.m_previousArmy != null)
			{
				this.ClearDataSlotArray(this.m_previousArmy);
				this.m_previousArmy = null;
			}
			if (this.m_eventUnitCounter != null)
			{
				this.ClearDataSlotArray(this.m_eventUnitCounter);
				this.m_eventUnitCounter = null;
			}
			if (this.m_unitCountVillage2 != null)
			{
				this.ClearDataSlotArray(this.m_unitCountVillage2);
				this.m_unitCountVillage2 = null;
			}
			if (this.m_unitCountNewVillage2 != null)
			{
				this.ClearDataSlotArray(this.m_unitCountNewVillage2);
				this.m_unitCountNewVillage2 = null;
			}
		}

		// Token: 0x06001A19 RID: 6681 RVA: 0x00011528 File Offset: 0x0000F728
		public LogicAvatarChangeListener GetChangeListener()
		{
			return this.m_listener;
		}

		// Token: 0x06001A1A RID: 6682 RVA: 0x00011530 File Offset: 0x0000F730
		public void SetChangeListener(LogicAvatarChangeListener listener)
		{
			this.m_listener = listener;
		}

		// Token: 0x06001A1B RID: 6683 RVA: 0x00011539 File Offset: 0x0000F739
		public void SetLevel(LogicLevel level)
		{
			this.m_level = level;
		}

		// Token: 0x06001A1C RID: 6684 RVA: 0x00002465 File Offset: 0x00000665
		public virtual bool IsClientAvatar()
		{
			return false;
		}

		// Token: 0x06001A1D RID: 6685 RVA: 0x00002465 File Offset: 0x00000665
		public virtual bool IsNpcAvatar()
		{
			return false;
		}

		// Token: 0x06001A1E RID: 6686 RVA: 0x00063430 File Offset: 0x00061630
		public virtual void GetChecksum(ChecksumHelper checksumHelper)
		{
			checksumHelper.StartObject("LogicAvatar");
			checksumHelper.StartArray("m_pResourceCount");
			for (int i = 0; i < this.m_resourceCount.Size(); i++)
			{
				this.m_resourceCount[i].GetChecksum(checksumHelper);
			}
			checksumHelper.EndArray();
			checksumHelper.StartArray("m_pResourceCap");
			for (int j = 0; j < this.m_resourceCap.Size(); j++)
			{
				this.m_resourceCap[j].GetChecksum(checksumHelper);
			}
			checksumHelper.EndArray();
			checksumHelper.StartArray("m_pUnitCount");
			for (int k = 0; k < this.m_unitCount.Size(); k++)
			{
				this.m_unitCount[k].GetChecksum(checksumHelper);
			}
			checksumHelper.EndArray();
			checksumHelper.StartArray("m_pSpellCount");
			for (int l = 0; l < this.m_spellCount.Size(); l++)
			{
				this.m_spellCount[l].GetChecksum(checksumHelper);
			}
			checksumHelper.EndArray();
			checksumHelper.StartArray("m_pAllianceUnitCount");
			for (int m = 0; m < this.m_allianceUnitCount.Size(); m++)
			{
				this.m_allianceUnitCount[m].GetChecksum(checksumHelper);
			}
			checksumHelper.EndArray();
			checksumHelper.StartArray("m_pUnitUpgrade");
			for (int n = 0; n < this.m_unitUpgrade.Size(); n++)
			{
				this.m_unitUpgrade[n].GetChecksum(checksumHelper);
			}
			checksumHelper.EndArray();
			checksumHelper.StartArray("m_pSpellUpgrade");
			for (int num = 0; num < this.m_spellUpgrade.Size(); num++)
			{
				this.m_spellUpgrade[num].GetChecksum(checksumHelper);
			}
			checksumHelper.EndArray();
			checksumHelper.StartArray("m_pUnitCountVillage2");
			for (int num2 = 0; num2 < this.m_unitCountVillage2.Size(); num2++)
			{
				this.m_unitCountVillage2[num2].GetChecksum(checksumHelper);
			}
			checksumHelper.EndArray();
			checksumHelper.WriteValue("m_townHallLevel", this.m_townHallLevel);
			checksumHelper.WriteValue("m_townHallLevelVillage2", this.m_townHallLevelVillage2);
			checksumHelper.EndObject();
		}

		// Token: 0x06001A1F RID: 6687 RVA: 0x0006364C File Offset: 0x0006184C
		public void CommodityCountChangeHelper(int commodityType, LogicData data, int count)
		{
			LogicDataType dataType = data.GetDataType();
			if (dataType <= LogicDataType.NPC)
			{
				if (dataType != LogicDataType.RESOURCE)
				{
					if (dataType != LogicDataType.CHARACTER)
					{
						if (dataType != LogicDataType.NPC)
						{
							return;
						}
						switch (commodityType)
						{
						case 0:
						{
							int count2 = this.GetNpcStars((LogicNpcData)data) + count;
							this.SetNpcStars((LogicNpcData)data, count2);
							this.m_listener.CommodityCountChanged(0, data, count2);
							return;
						}
						case 1:
						{
							int count3 = this.GetLootedNpcGold((LogicNpcData)data) + count;
							this.SetLootedNpcGold((LogicNpcData)data, count3);
							this.m_listener.CommodityCountChanged(1, data, count3);
							return;
						}
						case 2:
						{
							int count4 = this.GetLootedNpcElixir((LogicNpcData)data) + count;
							this.SetLootedNpcElixir((LogicNpcData)data, count4);
							this.m_listener.CommodityCountChanged(2, data, count4);
							return;
						}
						default:
							return;
						}
					}
				}
				else
				{
					if (commodityType == 0)
					{
						int resourceCount = this.GetResourceCount((LogicResourceData)data);
						int num = LogicMath.Max(resourceCount + count, 0);
						if (count > 0)
						{
							int resourceCap = this.GetResourceCap((LogicResourceData)data);
							if (num > resourceCap)
							{
								num = resourceCap;
							}
							if (resourceCount >= resourceCap)
							{
								num = resourceCap;
							}
							if (num <= resourceCount)
							{
								return;
							}
						}
						this.SetResourceCount((LogicResourceData)data, num);
						this.m_listener.CommodityCountChanged(0, data, num);
						return;
					}
					if (commodityType != 1)
					{
						return;
					}
					int count5 = this.GetResourceCap((LogicResourceData)data) + count;
					this.SetResourceCap((LogicResourceData)data, count5);
					this.m_listener.CommodityCountChanged(1, data, count5);
					return;
				}
			}
			else
			{
				if (dataType == LogicDataType.ACHIEVEMENT)
				{
					int count6 = LogicMath.Max(this.GetAchievementProgress((LogicAchievementData)data) + count, 0);
					this.SetAchievementProgress((LogicAchievementData)data, count6);
					this.m_listener.CommodityCountChanged(0, data, count6);
					return;
				}
				if (dataType != LogicDataType.SPELL)
				{
					if (dataType != LogicDataType.HERO)
					{
						return;
					}
					LogicHeroData logicHeroData = (LogicHeroData)data;
					if (commodityType == 0)
					{
						int count7 = LogicMath.Clamp(this.GetHeroHealth(logicHeroData) + count, 0, logicHeroData.GetFullRegenerationTimeSec(this.GetUnitUpgradeLevel(logicHeroData)));
						this.SetHeroHealth(logicHeroData, count7);
						this.GetChangeListener().CommodityCountChanged(0, data, count7);
						return;
					}
					if (commodityType != 1)
					{
						return;
					}
					int count8 = LogicMath.Clamp(this.GetUnitUpgradeLevel(logicHeroData) + count, 0, logicHeroData.GetUpgradeLevelCount() - 1);
					this.SetUnitUpgradeLevel((LogicCombatItemData)data, count8);
					this.m_listener.CommodityCountChanged(1, data, count8);
					return;
				}
			}
			if (commodityType == 0)
			{
				int count9 = LogicMath.Max(this.GetUnitCount((LogicCombatItemData)data) + count, 0);
				this.SetUnitCount((LogicCombatItemData)data, count9);
				this.m_listener.CommodityCountChanged(0, data, count9);
				return;
			}
			if (commodityType == 1)
			{
				LogicCombatItemData logicCombatItemData = (LogicCombatItemData)data;
				int count10 = LogicMath.Clamp(this.GetUnitUpgradeLevel((LogicCombatItemData)data) + count, 0, logicCombatItemData.GetUpgradeLevelCount() - 1);
				this.SetUnitUpgradeLevel((LogicCombatItemData)data, count10);
				this.m_listener.CommodityCountChanged(1, data, count10);
				return;
			}
			switch (commodityType)
			{
			case 7:
			{
				int count11 = LogicMath.Max(this.GetUnitCountVillage2((LogicCombatItemData)data) + count, 0);
				this.SetUnitCountVillage2((LogicCombatItemData)data, count11);
				this.m_listener.CommodityCountChanged(7, data, count11);
				return;
			}
			case 8:
			{
				int count12 = LogicMath.Max(this.GetUnitCountNewVillage2((LogicCombatItemData)data) + count, 0);
				this.SetUnitCountNewVillage2((LogicCombatItemData)data, count12);
				this.m_listener.CommodityCountChanged(8, data, count12);
				return;
			}
			case 9:
			{
				int count13 = LogicMath.Max(this.GetFreeActionCount(data) + count, 0);
				this.SetFreeActionCount(data, count13);
				this.m_listener.CommodityCountChanged(9, data, count13);
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x06001A20 RID: 6688 RVA: 0x000639A4 File Offset: 0x00061BA4
		public void SetCommodityCount(int commodityType, LogicData data, int count)
		{
			LogicDataType dataType = data.GetDataType();
			if (dataType <= LogicDataType.MISSION)
			{
				if (dataType <= LogicDataType.CHARACTER)
				{
					if (dataType != LogicDataType.RESOURCE)
					{
						if (dataType != LogicDataType.CHARACTER)
						{
							return;
						}
					}
					else
					{
						if (commodityType == 0)
						{
							this.SetResourceCount((LogicResourceData)data, count);
							return;
						}
						if (commodityType != 1)
						{
							Debugger.Error("setCommodityCount - Unknown resource commodity");
							return;
						}
						this.SetResourceCap((LogicResourceData)data, count);
						return;
					}
				}
				else if (dataType != LogicDataType.NPC)
				{
					if (dataType != LogicDataType.MISSION)
					{
						return;
					}
					if (commodityType == 0)
					{
						this.SetMissionCompleted((LogicMissionData)data, count != 0);
						return;
					}
					return;
				}
				else
				{
					switch (commodityType)
					{
					case 0:
						this.SetNpcStars((LogicNpcData)data, count);
						return;
					case 1:
						this.SetLootedNpcGold((LogicNpcData)data, count);
						return;
					case 2:
						this.SetLootedNpcElixir((LogicNpcData)data, count);
						return;
					default:
						return;
					}
				}
			}
			else if (dataType <= LogicDataType.SPELL)
			{
				if (dataType != LogicDataType.ACHIEVEMENT)
				{
					if (dataType != LogicDataType.SPELL)
					{
						return;
					}
				}
				else
				{
					if (commodityType == 0)
					{
						this.SetAchievementProgress((LogicAchievementData)data, count);
						return;
					}
					if (commodityType != 1)
					{
						return;
					}
					this.SetAchievementRewardClaimed((LogicAchievementData)data, count != 0);
					return;
				}
			}
			else if (dataType != LogicDataType.HERO)
			{
				if (dataType != LogicDataType.VARIABLE)
				{
					return;
				}
				if (commodityType == 0)
				{
					this.SetVariable(data, count);
					return;
				}
				return;
			}
			else
			{
				switch (commodityType)
				{
				case 0:
					this.SetHeroHealth((LogicHeroData)data, count);
					return;
				case 1:
					this.SetUnitUpgradeLevel((LogicHeroData)data, count);
					return;
				case 2:
					this.SetHeroState((LogicHeroData)data, count);
					return;
				case 3:
					this.SetHeroMode((LogicHeroData)data, count);
					return;
				default:
					return;
				}
			}
			switch (commodityType)
			{
			case 0:
				this.SetUnitCount((LogicCombatItemData)data, count);
				return;
			case 1:
				this.SetUnitUpgradeLevel((LogicCombatItemData)data, count);
				return;
			case 2:
				this.SetUnitPresetCount((LogicCombatItemData)data, 0, count);
				return;
			case 3:
				this.SetUnitPresetCount((LogicCombatItemData)data, 1, count);
				return;
			case 4:
				this.SetUnitPresetCount((LogicCombatItemData)data, 2, count);
				return;
			case 5:
				this.SetUnitPresetCount((LogicCombatItemData)data, 3, count);
				return;
			case 6:
				this.SetEventUnitCounterCount((LogicCombatItemData)data, count);
				return;
			case 7:
				this.SetUnitCountVillage2((LogicCombatItemData)data, count);
				return;
			case 8:
				this.SetUnitCountNewVillage2((LogicCombatItemData)data, count);
				return;
			case 9:
				this.SetFreeActionCount(data, count);
				return;
			default:
				Debugger.Error("setCommodityCount - Unknown resource commodity");
				return;
			}
		}

		// Token: 0x06001A21 RID: 6689 RVA: 0x00063BC4 File Offset: 0x00061DC4
		public void ClearDataSlotArray(LogicArrayList<LogicDataSlot> dataSlotArray)
		{
			for (int i = 0; i < dataSlotArray.Size(); i++)
			{
				dataSlotArray[i].Destruct();
			}
			dataSlotArray.Clear();
		}

		// Token: 0x06001A22 RID: 6690 RVA: 0x00063BF4 File Offset: 0x00061DF4
		public void ClearUnitSlotArray(LogicArrayList<LogicUnitSlot> unitSlotArray)
		{
			for (int i = 0; i < unitSlotArray.Size(); i++)
			{
				unitSlotArray[i].Destruct();
			}
			unitSlotArray.Clear();
		}

		// Token: 0x06001A23 RID: 6691 RVA: 0x00002465 File Offset: 0x00000665
		public virtual bool AddDuelReward(int goldCount, int elixirCount, int bonusGoldCount, int bonusElixirCount, LogicLong matchId)
		{
			return false;
		}

		// Token: 0x06001A24 RID: 6692 RVA: 0x00002465 File Offset: 0x00000665
		public virtual bool AddStarBonusReward(int goldCount, int elixirCount, int darkElixirCount)
		{
			return false;
		}

		// Token: 0x06001A25 RID: 6693 RVA: 0x00002465 File Offset: 0x00000665
		public virtual bool AddWarReward(int gold, int elixir, int darkElixir, int unk, LogicLong warInstanceId)
		{
			return false;
		}

		// Token: 0x06001A26 RID: 6694 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void UpdateLootLimitCooldown()
		{
		}

		// Token: 0x06001A27 RID: 6695 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void UpdateStarBonusLimitCooldown()
		{
		}

		// Token: 0x06001A28 RID: 6696 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void FastForwardLootLimit(int secs)
		{
		}

		// Token: 0x06001A29 RID: 6697 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void FastForwardStarBonusLimit(int secs)
		{
		}

		// Token: 0x06001A2A RID: 6698 RVA: 0x00002465 File Offset: 0x00000665
		public virtual bool IsInAlliance()
		{
			return false;
		}

		// Token: 0x06001A2B RID: 6699 RVA: 0x00011542 File Offset: 0x0000F742
		public virtual LogicLong GetAllianceId()
		{
			return 0L;
		}

		// Token: 0x06001A2C RID: 6700 RVA: 0x00002465 File Offset: 0x00000665
		public virtual int GetAllianceBadgeId()
		{
			return 0;
		}

		// Token: 0x06001A2D RID: 6701 RVA: 0x00002B36 File Offset: 0x00000D36
		public virtual LogicAvatarAllianceRole GetAllianceRole()
		{
			return LogicAvatarAllianceRole.MEMBER;
		}

		// Token: 0x06001A2E RID: 6702 RVA: 0x00002B33 File Offset: 0x00000D33
		public virtual string GetAllianceName()
		{
			return null;
		}

		// Token: 0x06001A2F RID: 6703 RVA: 0x00002B36 File Offset: 0x00000D36
		public virtual int GetExpLevel()
		{
			return 1;
		}

		// Token: 0x06001A30 RID: 6704 RVA: 0x00002B33 File Offset: 0x00000D33
		public virtual string GetName()
		{
			return null;
		}

		// Token: 0x06001A31 RID: 6705 RVA: 0x00011552 File Offset: 0x0000F752
		public bool IsInExpLevelCap()
		{
			return this.GetExpLevel() >= LogicDataTables.GetExperienceLevelCount();
		}

		// Token: 0x06001A32 RID: 6706 RVA: 0x00063C24 File Offset: 0x00061E24
		public bool IsHeroAvailableForAttack(LogicHeroData data)
		{
			if (((long)this.GetHeroState(data) & 4294967294L) == 2L)
			{
				int unitUpgradeLevel = this.GetUnitUpgradeLevel(data);
				int heroHitpoints = data.GetHeroHitpoints(this.GetHeroHealth(data), unitUpgradeLevel);
				return data.HasEnoughHealthForAttack(heroHitpoints, unitUpgradeLevel);
			}
			return false;
		}

		// Token: 0x06001A33 RID: 6707 RVA: 0x00063C70 File Offset: 0x00061E70
		public bool IsHeroAvailableForDefense(LogicHeroData data)
		{
			if (this.GetHeroState(data) == 3)
			{
				int unitUpgradeLevel = this.GetUnitUpgradeLevel(data);
				int heroHitpoints = data.GetHeroHitpoints(this.GetHeroHealth(data), unitUpgradeLevel);
				return data.HasEnoughHealthForAttack(heroHitpoints, unitUpgradeLevel);
			}
			return false;
		}

		// Token: 0x06001A34 RID: 6708 RVA: 0x00063CA8 File Offset: 0x00061EA8
		public int GetHeroHealth(LogicHeroData data)
		{
			int num = -1;
			int i = 0;
			while (i < this.m_heroHealth.Size())
			{
				if (this.m_heroHealth[i].GetData() == data)
				{
					num = i;
					IL_32:
					if (num != -1)
					{
						return this.m_heroHealth[num].GetCount();
					}
					return 0;
				}
				else
				{
					i++;
				}
			}
			goto IL_32;
		}

		// Token: 0x06001A35 RID: 6709 RVA: 0x00063D00 File Offset: 0x00061F00
		public void SetHeroHealth(LogicHeroData data, int count)
		{
			int num = -1;
			int i = 0;
			while (i < this.m_heroHealth.Size())
			{
				if (this.m_heroHealth[i].GetData() == data)
				{
					num = i;
					IL_32:
					if (num != -1)
					{
						this.m_heroHealth[num].SetCount(count);
						return;
					}
					this.m_heroHealth.Add(new LogicDataSlot(data, count));
					return;
				}
				else
				{
					i++;
				}
			}
			goto IL_32;
		}

		// Token: 0x06001A36 RID: 6710 RVA: 0x00063D68 File Offset: 0x00061F68
		public bool FastForwardHeroHealth(LogicHeroData data, int secs)
		{
			int num = LogicMath.Max(0, secs);
			int num2 = this.GetHeroHealth(data);
			if (num2 != 0)
			{
				num2 = LogicMath.Max(0, num2 - num);
				this.SetHeroHealth(data, num2);
				this.GetChangeListener().CommodityCountChanged(0, data, num2);
				return num2 == 0;
			}
			return false;
		}

		// Token: 0x06001A37 RID: 6711 RVA: 0x00063DB0 File Offset: 0x00061FB0
		public void SetHeroDefenseState()
		{
			for (int i = 0; i < this.m_heroState.Size(); i++)
			{
				LogicDataSlot logicDataSlot = this.m_heroState[i];
				if (logicDataSlot.GetCount() != 0)
				{
					logicDataSlot.SetCount(3);
					this.SetHeroHealth((LogicHeroData)logicDataSlot.GetData(), 0);
				}
			}
		}

		// Token: 0x06001A38 RID: 6712 RVA: 0x00063E04 File Offset: 0x00062004
		public int GetFreeActionCount(LogicData data)
		{
			for (int i = 0; i < this.m_freeActionCount.Size(); i++)
			{
				if (this.m_freeActionCount[i].GetData() == data)
				{
					return this.m_freeActionCount[i].GetCount();
				}
			}
			return 0;
		}

		// Token: 0x06001A39 RID: 6713 RVA: 0x00063E50 File Offset: 0x00062050
		public void SetFreeActionCount(LogicData data, int count)
		{
			int num = -1;
			int i = 0;
			while (i < this.m_achievementProgress.Size())
			{
				if (this.m_achievementProgress[i].GetData() == data)
				{
					num = i;
					IL_32:
					if (num != -1)
					{
						this.m_freeActionCount[num].SetCount(count);
						return;
					}
					this.m_freeActionCount.Add(new LogicDataSlot(data, count));
					return;
				}
				else
				{
					i++;
				}
			}
			goto IL_32;
		}

		// Token: 0x06001A3A RID: 6714 RVA: 0x00063EB8 File Offset: 0x000620B8
		public void SetFreeUnitCount(LogicCombatItemData data, int count, LogicLevel level)
		{
			int maxValue;
			if (data.GetCombatItemType() == LogicCombatItemType.HERO)
			{
				maxValue = LogicDataTables.GetGlobals().GetFreeHeroHealthCap();
			}
			else
			{
				maxValue = data.GetHousingSpace() + 2 * level.GetComponentManagerAt(data.GetVillageType()).GetTotalMaxHousing(data.GetCombatItemType()) * LogicDataTables.GetGlobals().GetFreeUnitHousingCapPercentage() / (2 * data.GetHousingSpace());
			}
			int freeActionCount = this.GetFreeActionCount(data);
			int num = LogicMath.Clamp(freeActionCount + count, 0, maxValue);
			if (num != freeActionCount)
			{
				this.SetFreeActionCount(data, num);
				this.m_listener.CommodityCountChanged(9, data, num);
			}
		}

		// Token: 0x06001A3B RID: 6715 RVA: 0x00063F40 File Offset: 0x00062140
		public int GetHeroState(LogicHeroData data)
		{
			int num = -1;
			int i = 0;
			while (i < this.m_heroState.Size())
			{
				if (this.m_heroState[i].GetData() == data)
				{
					num = i;
					IL_32:
					if (num != -1)
					{
						return this.m_heroState[num].GetCount();
					}
					return 0;
				}
				else
				{
					i++;
				}
			}
			goto IL_32;
		}

		// Token: 0x06001A3C RID: 6716 RVA: 0x00063F98 File Offset: 0x00062198
		public void SetHeroState(LogicHeroData data, int count)
		{
			int num = -1;
			int i = 0;
			while (i < this.m_heroState.Size())
			{
				if (this.m_heroState[i].GetData() == data)
				{
					num = i;
					IL_32:
					if (num != -1)
					{
						this.m_heroState[num].SetCount(count);
						return;
					}
					this.m_heroState.Add(new LogicDataSlot(data, count));
					return;
				}
				else
				{
					i++;
				}
			}
			goto IL_32;
		}

		// Token: 0x06001A3D RID: 6717 RVA: 0x00064000 File Offset: 0x00062200
		public int GetHeroMode(LogicHeroData data)
		{
			int num = -1;
			int i = 0;
			while (i < this.m_heroMode.Size())
			{
				if (this.m_heroMode[i].GetData() == data)
				{
					num = i;
					IL_32:
					if (num != -1)
					{
						return this.m_heroMode[num].GetCount();
					}
					return 0;
				}
				else
				{
					i++;
				}
			}
			goto IL_32;
		}

		// Token: 0x06001A3E RID: 6718 RVA: 0x00064058 File Offset: 0x00062258
		public void SetHeroMode(LogicHeroData data, int count)
		{
			int num = -1;
			int i = 0;
			while (i < this.m_heroMode.Size())
			{
				if (this.m_heroMode[i].GetData() == data)
				{
					num = i;
					IL_32:
					if (num != -1)
					{
						this.m_heroMode[num].SetCount(count);
						return;
					}
					this.m_heroMode.Add(new LogicDataSlot(data, count));
					return;
				}
				else
				{
					i++;
				}
			}
			goto IL_32;
		}

		// Token: 0x06001A3F RID: 6719 RVA: 0x00011564 File Offset: 0x0000F764
		public int GetHeroHealCost(LogicHeroData data)
		{
			return LogicGamePlayUtil.GetSpeedUpCost(this.GetHeroHealth(data), 2, data.GetVillageType());
		}

		// Token: 0x06001A40 RID: 6720 RVA: 0x000640C0 File Offset: 0x000622C0
		public int GetVariable(LogicData data)
		{
			int num = -1;
			int i = 0;
			while (i < this.m_variables.Size())
			{
				if (this.m_variables[i].GetData() == data)
				{
					num = i;
					IL_32:
					if (num != -1)
					{
						return this.m_variables[num].GetCount();
					}
					return 0;
				}
				else
				{
					i++;
				}
			}
			goto IL_32;
		}

		// Token: 0x06001A41 RID: 6721 RVA: 0x00064118 File Offset: 0x00062318
		public void SetVariable(LogicData data, int count)
		{
			int num = -1;
			for (int i = 0; i < this.m_variables.Size(); i++)
			{
				if (this.m_variables[i].GetData() == data)
				{
					num = i;
					IL_32:
					if (num != -1)
					{
						this.m_variables[num].SetCount(count);
					}
					else
					{
						this.m_variables.Add(new LogicDataSlot(data, count));
					}
					this.m_listener.CommodityCountChanged(0, data, count);
					return;
				}
			}
			goto IL_32;
		}

		// Token: 0x06001A42 RID: 6722 RVA: 0x00064190 File Offset: 0x00062390
		public int GetVariableByName(string name)
		{
			LogicData variableByName = LogicDataTables.GetVariableByName(name, null);
			if (variableByName == null)
			{
				Debugger.Error("getVariableByName() Invalid Name " + name);
			}
			return this.GetVariable(variableByName);
		}

		// Token: 0x06001A43 RID: 6723 RVA: 0x000641C0 File Offset: 0x000623C0
		public void SetVariableByName(string name, int value)
		{
			LogicData variableByName = LogicDataTables.GetVariableByName(name, null);
			if (variableByName == null)
			{
				Debugger.Error("setVariableByName() Invalid Name " + name);
			}
			this.SetVariable(variableByName, value);
		}

		// Token: 0x06001A44 RID: 6724 RVA: 0x00011579 File Offset: 0x0000F779
		public int GetVillageToGoTo()
		{
			return this.GetVariableByName("VillageToGoTo");
		}

		// Token: 0x06001A45 RID: 6725 RVA: 0x00011586 File Offset: 0x0000F786
		public void SetAccountBound()
		{
			this.SetVariableByName("AccountBound", 1);
		}

		// Token: 0x06001A46 RID: 6726 RVA: 0x00011594 File Offset: 0x0000F794
		public int GetVillage2BarrackLevel()
		{
			return this.GetVariableByName("Village2BarrackLevel");
		}

		// Token: 0x06001A47 RID: 6727 RVA: 0x000115A1 File Offset: 0x0000F7A1
		public void SetVillage2BarrackLevel(int value)
		{
			this.SetVariableByName("Village2BarrackLevel", value);
		}

		// Token: 0x06001A48 RID: 6728 RVA: 0x000115AF File Offset: 0x0000F7AF
		public bool IsChallengeStarted()
		{
			return this.GetVariableByName("ChallengeStarted") != 0;
		}

		// Token: 0x06001A49 RID: 6729 RVA: 0x000115BF File Offset: 0x0000F7BF
		public int GetUnusedResourceCap(LogicResourceData data)
		{
			return LogicMath.Max(this.GetResourceCap(data) - this.GetResourceCount(data), 0);
		}

		// Token: 0x06001A4A RID: 6730 RVA: 0x000115D6 File Offset: 0x0000F7D6
		public bool IsAccountBound()
		{
			return this.GetVariableByName("AccountBound") != 0;
		}

		// Token: 0x06001A4B RID: 6731 RVA: 0x000115E6 File Offset: 0x0000F7E6
		public int GetSecondsSinceLastFriendListOpened()
		{
			return this.m_level.GetGameMode().GetStartTime() + this.m_level.GetLogicTime().GetTotalMS() / 1000 - this.GetVariableByName("FriendListLastOpened");
		}

		// Token: 0x06001A4C RID: 6732 RVA: 0x0001161B File Offset: 0x0000F81B
		public void UpdateLastFriendListOpened()
		{
			this.SetVariableByName("FriendListLastOpened", this.m_level.GetGameMode().GetStartTime() + this.m_level.GetLogicTime().GetTotalMS() / 1000);
		}

		// Token: 0x06001A4D RID: 6733 RVA: 0x000641F0 File Offset: 0x000623F0
		public int GetResourceCap(LogicResourceData data)
		{
			if (!data.IsPremiumCurrency())
			{
				int num = -1;
				int i = 0;
				while (i < this.m_resourceCap.Size())
				{
					if (this.m_resourceCap[i].GetData() == data)
					{
						num = i;
						IL_46:
						if (num != -1)
						{
							return this.m_resourceCap[num].GetCount();
						}
						return 0;
					}
					else
					{
						i++;
					}
				}
				goto IL_46;
			}
			Debugger.Warning("LogicClientAvatar::getResourceCap shouldn't be used for diamonds");
			return 0;
		}

		// Token: 0x06001A4E RID: 6734 RVA: 0x0006425C File Offset: 0x0006245C
		public void SetResourceCap(LogicResourceData data, int count)
		{
			if (data.IsPremiumCurrency())
			{
				Debugger.Warning("LogicClientAvatar::setResourceCap shouldn't be used for diamonds");
				return;
			}
			int num = -1;
			int i = 0;
			while (i < this.m_resourceCap.Size())
			{
				if (this.m_resourceCap[i].GetData() == data)
				{
					num = i;
					IL_45:
					if (num != -1)
					{
						this.m_resourceCap[num].SetCount(count);
						return;
					}
					this.m_resourceCap.Add(new LogicDataSlot(data, count));
					return;
				}
				else
				{
					i++;
				}
			}
			goto IL_45;
		}

		// Token: 0x06001A4F RID: 6735 RVA: 0x0001164F File Offset: 0x0000F84F
		public LogicArrayList<LogicDataSlot> GetResources()
		{
			return this.m_resourceCount;
		}

		// Token: 0x06001A50 RID: 6736 RVA: 0x000642D8 File Offset: 0x000624D8
		public virtual int GetResourceCount(LogicResourceData data)
		{
			if (!data.IsPremiumCurrency())
			{
				int num = -1;
				int i = 0;
				while (i < this.m_resourceCount.Size())
				{
					if (this.m_resourceCount[i].GetData() == data)
					{
						num = i;
						IL_3A:
						if (num != -1)
						{
							return this.m_resourceCount[num].GetCount();
						}
						return 0;
					}
					else
					{
						i++;
					}
				}
				goto IL_3A;
			}
			Debugger.Warning("LogicAvatar::getResourceCount shouldn't be used for diamonds");
			return 0;
		}

		// Token: 0x06001A51 RID: 6737 RVA: 0x00064340 File Offset: 0x00062540
		public void SetResourceCount(LogicResourceData data, int count)
		{
			if (!data.IsPremiumCurrency())
			{
				int num = -1;
				int i = 0;
				while (i < this.m_resourceCount.Size())
				{
					if (this.m_resourceCount[i].GetData() == data)
					{
						num = i;
						IL_3D:
						if (num != -1)
						{
							this.m_resourceCount[num].SetCount(count);
						}
						else
						{
							this.m_resourceCount.Add(new LogicDataSlot(data, count));
						}
						if (this.m_level != null && this.m_level.GetState() == 1)
						{
							this.m_level.GetComponentManagerAt(data.GetVillageType()).DivideAvatarResourcesToStorages();
							return;
						}
						return;
					}
					else
					{
						i++;
					}
				}
				goto IL_3D;
			}
			Debugger.Warning("LogicAvatar::setResourceCount shouldn't be used for diamonds");
		}

		// Token: 0x06001A52 RID: 6738 RVA: 0x00011657 File Offset: 0x0000F857
		public bool IsDarkElixirUnlocked()
		{
			return this.GetResourceCap(LogicDataTables.GetDarkElixirData()) > 0;
		}

		// Token: 0x06001A53 RID: 6739 RVA: 0x000643EC File Offset: 0x000625EC
		public int GetDamagingSpellsTotal()
		{
			int num = 0;
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.SPELL);
			int i = 0;
			IL_83:
			while (i < table.GetItemCount())
			{
				LogicSpellData logicSpellData = (LogicSpellData)table.GetItemAt(i);
				int num2 = -1;
				for (int j = 0; j < this.m_spellCount.Size(); j++)
				{
					if (this.m_spellCount[j].GetData() == logicSpellData)
					{
						num2 = j;
						IL_55:
						if (num2 != -1 && (logicSpellData.IsBuildingDamageSpell() || logicSpellData.GetSummonTroop() != null))
						{
							num += this.m_spellCount[num2].GetCount();
						}
						i++;
						goto IL_83;
					}
				}
				goto IL_55;
			}
			return num;
		}

		// Token: 0x06001A54 RID: 6740 RVA: 0x00064488 File Offset: 0x00062688
		public int GetSpellsTotalCapacity()
		{
			int num = 0;
			for (int i = 0; i < this.m_spellCount.Size(); i++)
			{
				LogicDataSlot logicDataSlot = this.m_spellCount[i];
				LogicCombatItemData logicCombatItemData = (LogicCombatItemData)logicDataSlot.GetData();
				num += logicCombatItemData.GetHousingSpace() * logicDataSlot.GetCount();
			}
			return num;
		}

		// Token: 0x06001A55 RID: 6741 RVA: 0x000644D8 File Offset: 0x000626D8
		public int GetUnitsTotalCapacity()
		{
			int num = 0;
			for (int i = 0; i < this.m_unitCount.Size(); i++)
			{
				LogicDataSlot logicDataSlot = this.m_unitCount[i];
				LogicCombatItemData logicCombatItemData = (LogicCombatItemData)logicDataSlot.GetData();
				num += logicCombatItemData.GetHousingSpace() * logicDataSlot.GetCount();
			}
			return num;
		}

		// Token: 0x06001A56 RID: 6742 RVA: 0x00064528 File Offset: 0x00062728
		public int GetUnitsTotal()
		{
			int num = 0;
			for (int i = 0; i < this.m_unitCount.Size(); i++)
			{
				num += this.m_unitCount[i].GetCount();
			}
			return num;
		}

		// Token: 0x06001A57 RID: 6743 RVA: 0x00064564 File Offset: 0x00062764
		public int GetUnitsTotalVillage2()
		{
			int num = 0;
			for (int i = 0; i < this.m_unitCountVillage2.Size(); i++)
			{
				num += this.m_unitCountVillage2[i].GetCount();
			}
			return num;
		}

		// Token: 0x06001A58 RID: 6744 RVA: 0x000645A0 File Offset: 0x000627A0
		public int GetUnitsNewTotalVillage2()
		{
			int num = 0;
			for (int i = 0; i < this.m_unitCountNewVillage2.Size(); i++)
			{
				num += this.m_unitCountNewVillage2[i].GetCount();
			}
			return num;
		}

		// Token: 0x06001A59 RID: 6745 RVA: 0x00011667 File Offset: 0x0000F867
		public LogicArrayList<LogicUnitSlot> GetAllianceUnits()
		{
			return this.m_allianceUnitCount;
		}

		// Token: 0x06001A5A RID: 6746 RVA: 0x000645DC File Offset: 0x000627DC
		public int GetAllianceUnitCount(LogicCombatItemData data, int upgLevel)
		{
			int num = -1;
			int i = 0;
			while (i < this.m_allianceUnitCount.Size())
			{
				if (this.m_allianceUnitCount[i].GetData() == data && this.m_allianceUnitCount[i].GetLevel() == upgLevel)
				{
					num = i;
					IL_46:
					if (num != -1)
					{
						return this.m_allianceUnitCount[num].GetCount();
					}
					return 0;
				}
				else
				{
					i++;
				}
			}
			goto IL_46;
		}

		// Token: 0x06001A5B RID: 6747 RVA: 0x0001166F File Offset: 0x0000F86F
		public void AddAllianceUnit(LogicCombatItemData data, int upgLevel)
		{
			this.SetAllianceUnitCount(data, upgLevel, this.GetAllianceUnitCount(data, upgLevel) + 1);
		}

		// Token: 0x06001A5C RID: 6748 RVA: 0x00064648 File Offset: 0x00062848
		public void SetAllianceUnitCount(LogicCombatItemData data, int upgLevel, int count)
		{
			int num = -1;
			int i = 0;
			while (i < this.m_allianceUnitCount.Size())
			{
				if (this.m_allianceUnitCount[i].GetData() == data && this.m_allianceUnitCount[i].GetLevel() == upgLevel)
				{
					num = i;
					IL_46:
					if (num != -1)
					{
						if (data.GetCombatItemType() != LogicCombatItemType.CHARACTER)
						{
							this.m_allianceCastleUsedSpellCapacity += (count - this.m_allianceUnitCount[num].GetCount()) * data.GetHousingSpace();
						}
						else
						{
							this.m_allianceCastleUsedCapacity += (count - this.m_allianceUnitCount[num].GetCount()) * data.GetHousingSpace();
						}
						this.m_allianceUnitCount[num].SetCount(count);
						return;
					}
					this.m_allianceUnitCount.Add(new LogicUnitSlot(data, upgLevel, count));
					if (data.GetCombatItemType() != LogicCombatItemType.CHARACTER)
					{
						this.m_allianceCastleUsedSpellCapacity += count * data.GetHousingSpace();
						return;
					}
					this.m_allianceCastleUsedCapacity += count * data.GetHousingSpace();
					return;
				}
				else
				{
					i++;
				}
			}
			goto IL_46;
		}

		// Token: 0x06001A5D RID: 6749 RVA: 0x00064750 File Offset: 0x00062950
		public void RemoveAllianceUnit(LogicCombatItemData data, int upgLevel)
		{
			int allianceUnitCount = this.GetAllianceUnitCount(data, upgLevel);
			if (allianceUnitCount > 0)
			{
				this.SetAllianceUnitCount(data, upgLevel, allianceUnitCount - 1);
				return;
			}
			Debugger.Warning("LogicClientAvatar::removeAllianceUnit called but unit count is already 0");
		}

		// Token: 0x06001A5E RID: 6750 RVA: 0x00064780 File Offset: 0x00062980
		public int GetUnitCount(LogicCombatItemData data)
		{
			if (data.GetCombatItemType() != LogicCombatItemType.CHARACTER)
			{
				int num = -1;
				int i = 0;
				while (i < this.m_spellCount.Size())
				{
					if (this.m_spellCount[i].GetData() == data)
					{
						num = i;
						IL_3A:
						if (num != -1)
						{
							return this.m_spellCount[num].GetCount();
						}
						return 0;
					}
					else
					{
						i++;
					}
				}
				goto IL_3A;
			}
			int num2 = -1;
			int j = 0;
			while (j < this.m_unitCount.Size())
			{
				if (this.m_unitCount[j].GetData() == data)
				{
					num2 = j;
					IL_82:
					if (num2 != -1)
					{
						return this.m_unitCount[num2].GetCount();
					}
					return 0;
				}
				else
				{
					j++;
				}
			}
			goto IL_82;
		}

		// Token: 0x06001A5F RID: 6751 RVA: 0x00064828 File Offset: 0x00062A28
		public void SetUnitCount(LogicCombatItemData data, int count)
		{
			if (data.GetCombatItemType() != LogicCombatItemType.CHARACTER)
			{
				int num = -1;
				int i = 0;
				while (i < this.m_spellCount.Size())
				{
					if (this.m_spellCount[i].GetData() == data)
					{
						num = i;
						IL_3A:
						if (num != -1)
						{
							this.m_spellCount[num].SetCount(count);
							return;
						}
						this.m_spellCount.Add(new LogicDataSlot(data, count));
						return;
					}
					else
					{
						i++;
					}
				}
				goto IL_3A;
			}
			int num2 = -1;
			int j = 0;
			while (j < this.m_unitCount.Size())
			{
				if (this.m_unitCount[j].GetData() == data)
				{
					num2 = j;
					IL_96:
					if (num2 != -1)
					{
						this.m_unitCount[num2].SetCount(count);
						return;
					}
					this.m_unitCount.Add(new LogicDataSlot(data, count));
					return;
				}
				else
				{
					j++;
				}
			}
			goto IL_96;
		}

		// Token: 0x06001A60 RID: 6752 RVA: 0x000648F4 File Offset: 0x00062AF4
		public int GetUnitCountVillage2(LogicCombatItemData data)
		{
			if (data.GetCombatItemType() == LogicCombatItemType.CHARACTER)
			{
				int num = -1;
				int i = 0;
				while (i < this.m_unitCountVillage2.Size())
				{
					if (this.m_unitCountVillage2[i].GetData() == data)
					{
						num = i;
						IL_3A:
						if (num != -1)
						{
							return this.m_unitCountVillage2[num].GetCount();
						}
						return 0;
					}
					else
					{
						i++;
					}
				}
				goto IL_3A;
			}
			return 0;
		}

		// Token: 0x06001A61 RID: 6753 RVA: 0x00064954 File Offset: 0x00062B54
		public void SetUnitCountVillage2(LogicCombatItemData data, int count)
		{
			if (data.GetCombatItemType() == LogicCombatItemType.CHARACTER)
			{
				int num = -1;
				int i = 0;
				while (i < this.m_unitCountVillage2.Size())
				{
					if (this.m_unitCountVillage2[i].GetData() == data)
					{
						num = i;
						IL_3A:
						if (num != -1)
						{
							this.m_unitCountVillage2[num].SetCount(count);
							return;
						}
						this.m_unitCountVillage2.Add(new LogicDataSlot(data, count));
						return;
					}
					else
					{
						i++;
					}
				}
				goto IL_3A;
			}
		}

		// Token: 0x06001A62 RID: 6754 RVA: 0x000649C4 File Offset: 0x00062BC4
		public int GetUnitCountNewVillage2(LogicCombatItemData data)
		{
			if (data.GetCombatItemType() == LogicCombatItemType.CHARACTER)
			{
				int num = -1;
				int i = 0;
				while (i < this.m_unitCountNewVillage2.Size())
				{
					if (this.m_unitCountNewVillage2[i].GetData() == data)
					{
						num = i;
						IL_3A:
						if (num != -1)
						{
							return this.m_unitCountNewVillage2[num].GetCount();
						}
						return 0;
					}
					else
					{
						i++;
					}
				}
				goto IL_3A;
			}
			return 0;
		}

		// Token: 0x06001A63 RID: 6755 RVA: 0x00064A24 File Offset: 0x00062C24
		public void SetUnitCountNewVillage2(LogicCombatItemData data, int count)
		{
			if (data.GetCombatItemType() == LogicCombatItemType.CHARACTER)
			{
				int num = -1;
				int i = 0;
				while (i < this.m_unitCountNewVillage2.Size())
				{
					if (this.m_unitCountNewVillage2[i].GetData() == data)
					{
						num = i;
						IL_3A:
						if (num != -1)
						{
							this.m_unitCountNewVillage2[num].SetCount(count);
							return;
						}
						this.m_unitCountNewVillage2.Add(new LogicDataSlot(data, count));
						return;
					}
					else
					{
						i++;
					}
				}
				goto IL_3A;
			}
		}

		// Token: 0x06001A64 RID: 6756 RVA: 0x00064A94 File Offset: 0x00062C94
		public int GetUnitUpgradeLevel(LogicCombatItemData data)
		{
			if (!data.UseUpgradeLevelByTownHall())
			{
				if (data.GetCombatItemType() == LogicCombatItemType.CHARACTER)
				{
					int num = -1;
					int i = 0;
					while (i < this.m_unitUpgrade.Size())
					{
						if (this.m_unitUpgrade[i].GetData() == data)
						{
							num = i;
							IL_45:
							if (num != -1)
							{
								return this.m_unitUpgrade[num].GetCount();
							}
							return 0;
						}
						else
						{
							i++;
						}
					}
					goto IL_45;
				}
				if (data.GetCombatItemType() == LogicCombatItemType.SPELL)
				{
					int num2 = -1;
					int j = 0;
					while (j < this.m_spellUpgrade.Size())
					{
						if (this.m_spellUpgrade[j].GetData() == data)
						{
							num2 = j;
							IL_99:
							if (num2 != -1)
							{
								return this.m_spellUpgrade[num2].GetCount();
							}
							return 0;
						}
						else
						{
							j++;
						}
					}
					goto IL_99;
				}
				int num3 = -1;
				int k = 0;
				while (k < this.m_heroUpgrade.Size())
				{
					if (this.m_heroUpgrade[k].GetData() == data)
					{
						num3 = k;
						IL_E9:
						if (num3 != -1)
						{
							return this.m_heroUpgrade[num3].GetCount();
						}
						return 0;
					}
					else
					{
						k++;
					}
				}
				goto IL_E9;
			}
			return data.GetUpgradeLevelByTownHall((data.GetVillageType() == 1) ? this.m_townHallLevelVillage2 : this.m_townHallLevel);
		}

		// Token: 0x06001A65 RID: 6757 RVA: 0x00064BC4 File Offset: 0x00062DC4
		public void SetUnitUpgradeLevel(LogicCombatItemData data, int count)
		{
			LogicCombatItemType combatItemType = data.GetCombatItemType();
			int upgradeLevelCount = data.GetUpgradeLevelCount();
			if (combatItemType <= LogicCombatItemType.CHARACTER)
			{
				if (upgradeLevelCount <= count)
				{
					Debugger.Warning("LogicAvatar::setUnitUpgradeLevel - Level is out of bounds!");
					count = upgradeLevelCount - 1;
				}
				int num = -1;
				int i = 0;
				while (i < this.m_unitUpgrade.Size())
				{
					if (this.m_unitUpgrade[i].GetData() == data)
					{
						num = i;
						IL_14E:
						if (num != -1)
						{
							this.m_unitUpgrade[num].SetCount(count);
							return;
						}
						this.m_unitUpgrade.Add(new LogicDataSlot(data, count));
						return;
					}
					else
					{
						i++;
					}
				}
				goto IL_14E;
			}
			if (combatItemType == LogicCombatItemType.HERO)
			{
				if (upgradeLevelCount <= count)
				{
					Debugger.Warning("LogicAvatar::setUnitUpgradeLevel - Level is out of bounds!");
					count = upgradeLevelCount - 1;
				}
				int num2 = -1;
				int j = 0;
				while (j < this.m_heroUpgrade.Size())
				{
					if (this.m_heroUpgrade[j].GetData() == data)
					{
						num2 = j;
						IL_5E:
						if (num2 != -1)
						{
							this.m_heroUpgrade[num2].SetCount(count);
							return;
						}
						this.m_heroUpgrade.Add(new LogicDataSlot(data, count));
						return;
					}
					else
					{
						j++;
					}
				}
				goto IL_5E;
			}
			if (upgradeLevelCount <= count)
			{
				Debugger.Warning("LogicAvatar::setSpellUpgradeLevel - Level is out of bounds!");
				count = upgradeLevelCount - 1;
			}
			int num3 = -1;
			int k = 0;
			while (k < this.m_spellUpgrade.Size())
			{
				if (this.m_spellUpgrade[k].GetData() == data)
				{
					num3 = k;
					IL_D5:
					if (num3 != -1)
					{
						this.m_spellUpgrade[num3].SetCount(count);
						return;
					}
					this.m_spellUpgrade.Add(new LogicDataSlot(data, count));
					return;
				}
				else
				{
					k++;
				}
			}
			goto IL_D5;
		}

		// Token: 0x06001A66 RID: 6758 RVA: 0x00064D4C File Offset: 0x00062F4C
		public int GetNpcStars(LogicNpcData data)
		{
			int num = -1;
			int i = 0;
			while (i < this.m_npcStars.Size())
			{
				if (this.m_npcStars[i].GetData() == data)
				{
					num = i;
					IL_32:
					if (num != -1)
					{
						return this.m_npcStars[num].GetCount();
					}
					return 0;
				}
				else
				{
					i++;
				}
			}
			goto IL_32;
		}

		// Token: 0x06001A67 RID: 6759 RVA: 0x00064DA4 File Offset: 0x00062FA4
		public void SetNpcStars(LogicNpcData data, int count)
		{
			int num = -1;
			int i = 0;
			while (i < this.m_npcStars.Size())
			{
				if (this.m_npcStars[i].GetData() == data)
				{
					num = i;
					IL_32:
					if (num != -1)
					{
						this.m_npcStars[num].SetCount(count);
						return;
					}
					this.m_npcStars.Add(new LogicDataSlot(data, count));
					return;
				}
				else
				{
					i++;
				}
			}
			goto IL_32;
		}

		// Token: 0x06001A68 RID: 6760 RVA: 0x00064E0C File Offset: 0x0006300C
		public int GetTotalNpcStars()
		{
			int num = 0;
			for (int i = 0; i < this.m_npcStars.Size(); i++)
			{
				num += this.m_npcStars[i].GetCount();
			}
			return num;
		}

		// Token: 0x06001A69 RID: 6761 RVA: 0x00064E48 File Offset: 0x00063048
		public int GetLootedNpcGold(LogicNpcData data)
		{
			int num = -1;
			int i = 0;
			while (i < this.m_lootedNpcGold.Size())
			{
				if (this.m_lootedNpcGold[i].GetData() == data)
				{
					num = i;
					IL_32:
					if (num != -1)
					{
						return this.m_lootedNpcGold[num].GetCount();
					}
					return 0;
				}
				else
				{
					i++;
				}
			}
			goto IL_32;
		}

		// Token: 0x06001A6A RID: 6762 RVA: 0x00064EA0 File Offset: 0x000630A0
		public void SetLootedNpcGold(LogicNpcData data, int count)
		{
			int num = -1;
			int i = 0;
			while (i < this.m_lootedNpcGold.Size())
			{
				if (this.m_lootedNpcGold[i].GetData() == data)
				{
					num = i;
					IL_32:
					if (num != -1)
					{
						this.m_lootedNpcGold[num].SetCount(count);
						return;
					}
					this.m_lootedNpcGold.Add(new LogicDataSlot(data, count));
					return;
				}
				else
				{
					i++;
				}
			}
			goto IL_32;
		}

		// Token: 0x06001A6B RID: 6763 RVA: 0x00064F08 File Offset: 0x00063108
		public int GetLootedNpcElixir(LogicNpcData data)
		{
			int num = -1;
			int i = 0;
			while (i < this.m_lootedNpcElixir.Size())
			{
				if (this.m_lootedNpcElixir[i].GetData() == data)
				{
					num = i;
					IL_32:
					if (num != -1)
					{
						return this.m_lootedNpcElixir[num].GetCount();
					}
					return 0;
				}
				else
				{
					i++;
				}
			}
			goto IL_32;
		}

		// Token: 0x06001A6C RID: 6764 RVA: 0x00064F60 File Offset: 0x00063160
		public void SetLootedNpcElixir(LogicNpcData data, int count)
		{
			int num = -1;
			int i = 0;
			while (i < this.m_lootedNpcElixir.Size())
			{
				if (this.m_lootedNpcElixir[i].GetData() == data)
				{
					num = i;
					IL_32:
					if (num != -1)
					{
						this.m_lootedNpcElixir[num].SetCount(count);
						return;
					}
					this.m_lootedNpcElixir.Add(new LogicDataSlot(data, count));
					return;
				}
				else
				{
					i++;
				}
			}
			goto IL_32;
		}

		// Token: 0x06001A6D RID: 6765 RVA: 0x00064FC8 File Offset: 0x000631C8
		public int GetUnitPresetCount(LogicCombatItemData data, int type)
		{
			LogicArrayList<LogicDataSlot> logicArrayList = null;
			switch (type)
			{
			case 0:
				logicArrayList = this.m_previousArmy;
				break;
			case 1:
				logicArrayList = this.m_unitPreset1;
				break;
			case 2:
				logicArrayList = this.m_unitPreset2;
				break;
			case 3:
				logicArrayList = this.m_unitPreset3;
				break;
			}
			int num = -1;
			int i = 0;
			while (i < logicArrayList.Size())
			{
				if (logicArrayList[i].GetData() == data)
				{
					num = i;
					IL_64:
					if (num != -1)
					{
						return logicArrayList[num].GetCount();
					}
					return 0;
				}
				else
				{
					i++;
				}
			}
			goto IL_64;
		}

		// Token: 0x06001A6E RID: 6766 RVA: 0x0006504C File Offset: 0x0006324C
		public void SetUnitPresetCount(LogicCombatItemData data, int type, int count)
		{
			LogicArrayList<LogicDataSlot> logicArrayList = null;
			switch (type)
			{
			case 0:
				logicArrayList = this.m_previousArmy;
				break;
			case 1:
				logicArrayList = this.m_unitPreset1;
				break;
			case 2:
				logicArrayList = this.m_unitPreset2;
				break;
			case 3:
				logicArrayList = this.m_unitPreset3;
				break;
			}
			int num = -1;
			int i = 0;
			while (i < logicArrayList.Size())
			{
				if (logicArrayList[i].GetData() == data)
				{
					num = i;
					IL_64:
					if (num != -1)
					{
						logicArrayList[num].SetCount(count);
						return;
					}
					logicArrayList.Add(new LogicDataSlot(data, count));
					return;
				}
				else
				{
					i++;
				}
			}
			goto IL_64;
		}

		// Token: 0x06001A6F RID: 6767 RVA: 0x000650DC File Offset: 0x000632DC
		public int GetEventUnitCounterCount(LogicCombatItemData data)
		{
			int num = -1;
			int i = 0;
			while (i < this.m_eventUnitCounter.Size())
			{
				if (this.m_eventUnitCounter[i].GetData() == data)
				{
					num = i;
					IL_32:
					if (num != -1)
					{
						return this.m_eventUnitCounter[num].GetCount();
					}
					return 0;
				}
				else
				{
					i++;
				}
			}
			goto IL_32;
		}

		// Token: 0x06001A70 RID: 6768 RVA: 0x00065134 File Offset: 0x00063334
		public void SetEventUnitCounterCount(LogicCombatItemData data, int count)
		{
			int num = -1;
			int i = 0;
			while (i < this.m_eventUnitCounter.Size())
			{
				if (this.m_eventUnitCounter[i].GetData() == data)
				{
					num = i;
					IL_32:
					if (num != -1)
					{
						this.m_eventUnitCounter[num].SetCount(count);
						return;
					}
					this.m_eventUnitCounter.Add(new LogicDataSlot(data, count));
					return;
				}
				else
				{
					i++;
				}
			}
			goto IL_32;
		}

		// Token: 0x06001A71 RID: 6769 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void XpGainHelper(int count)
		{
		}

		// Token: 0x06001A72 RID: 6770 RVA: 0x00011683 File Offset: 0x0000F883
		public LogicArrayList<LogicDataSlot> GetUnits()
		{
			return this.m_unitCount;
		}

		// Token: 0x06001A73 RID: 6771 RVA: 0x0001168B File Offset: 0x0000F88B
		public LogicArrayList<LogicDataSlot> GetUnitUpgradeLevels()
		{
			return this.m_unitUpgrade;
		}

		// Token: 0x06001A74 RID: 6772 RVA: 0x00011693 File Offset: 0x0000F893
		public LogicArrayList<LogicDataSlot> GetUnitsVillage2()
		{
			return this.m_unitCountVillage2;
		}

		// Token: 0x06001A75 RID: 6773 RVA: 0x0001169B File Offset: 0x0000F89B
		public LogicArrayList<LogicDataSlot> GetUnitsNewVillage2()
		{
			return this.m_unitCountNewVillage2;
		}

		// Token: 0x06001A76 RID: 6774 RVA: 0x000116A3 File Offset: 0x0000F8A3
		public LogicArrayList<LogicDataSlot> GetSpells()
		{
			return this.m_spellCount;
		}

		// Token: 0x06001A77 RID: 6775 RVA: 0x000116AB File Offset: 0x0000F8AB
		public LogicArrayList<LogicDataSlot> GetSpellUpgradeLevels()
		{
			return this.m_spellUpgrade;
		}

		// Token: 0x06001A78 RID: 6776 RVA: 0x000116B3 File Offset: 0x0000F8B3
		public LogicArrayList<LogicDataSlot> GetResourceCaps()
		{
			return this.m_resourceCap;
		}

		// Token: 0x06001A79 RID: 6777 RVA: 0x0006519C File Offset: 0x0006339C
		public void SetMissionCompleted(LogicMissionData data, bool state)
		{
			int num = -1;
			for (int i = 0; i < this.m_missionCompleted.Size(); i++)
			{
				if (this.m_missionCompleted[i] == data)
				{
					num = i;
					IL_2D:
					if (state)
					{
						if (num == -1)
						{
							this.m_missionCompleted.Add(data);
							return;
						}
					}
					else if (num != -1)
					{
						this.m_missionCompleted.Remove(num);
					}
					return;
				}
			}
			goto IL_2D;
		}

		// Token: 0x06001A7A RID: 6778 RVA: 0x000651FC File Offset: 0x000633FC
		public bool IsMissionCompleted(LogicMissionData data)
		{
			int num = -1;
			for (int i = 0; i < this.m_missionCompleted.Size(); i++)
			{
				if (this.m_missionCompleted[i] == data)
				{
					num = i;
					IL_2D:
					return num != -1;
				}
			}
			goto IL_2D;
		}

		// Token: 0x06001A7B RID: 6779 RVA: 0x00065240 File Offset: 0x00063440
		public int GetAchievementProgress(LogicAchievementData data)
		{
			int num = -1;
			int i = 0;
			while (i < this.m_achievementProgress.Size())
			{
				if (this.m_achievementProgress[i].GetData() == data)
				{
					num = i;
					IL_32:
					if (num != -1)
					{
						return this.m_achievementProgress[num].GetCount();
					}
					return 0;
				}
				else
				{
					i++;
				}
			}
			goto IL_32;
		}

		// Token: 0x06001A7C RID: 6780 RVA: 0x00065298 File Offset: 0x00063498
		public void SetAchievementProgress(LogicAchievementData data, int count)
		{
			int num = -1;
			int i = 0;
			while (i < this.m_achievementProgress.Size())
			{
				if (this.m_achievementProgress[i].GetData() == data)
				{
					num = i;
					IL_32:
					if (num != -1)
					{
						this.m_achievementProgress[num].SetCount(count);
						return;
					}
					this.m_achievementProgress.Add(new LogicDataSlot(data, count));
					return;
				}
				else
				{
					i++;
				}
			}
			goto IL_32;
		}

		// Token: 0x06001A7D RID: 6781 RVA: 0x00065300 File Offset: 0x00063500
		public void SetAchievementRewardClaimed(LogicAchievementData data, bool claimed)
		{
			int num = -1;
			for (int i = 0; i < this.m_achievementRewardClaimed.Size(); i++)
			{
				if (this.m_achievementRewardClaimed[i] == data)
				{
					num = i;
					IL_2D:
					if (claimed)
					{
						if (num == -1)
						{
							this.m_achievementRewardClaimed.Add(data);
							return;
						}
					}
					else if (num != -1)
					{
						this.m_achievementRewardClaimed.Remove(num);
					}
					return;
				}
			}
			goto IL_2D;
		}

		// Token: 0x06001A7E RID: 6782 RVA: 0x00065360 File Offset: 0x00063560
		public bool IsAchievementRewardClaimed(LogicAchievementData data)
		{
			int num = -1;
			for (int i = 0; i < this.m_achievementRewardClaimed.Size(); i++)
			{
				if (this.m_achievementRewardClaimed[i] == data)
				{
					num = i;
					IL_2D:
					return num != -1;
				}
			}
			goto IL_2D;
		}

		// Token: 0x06001A7F RID: 6783 RVA: 0x000653A4 File Offset: 0x000635A4
		public bool IsAchievementCompleted(LogicAchievementData data)
		{
			int num = -1;
			int num2 = 0;
			for (int i = 0; i < this.m_achievementProgress.Size(); i++)
			{
				if (this.m_achievementProgress[i].GetData() == data)
				{
					num = i;
					IL_34:
					if (num != -1)
					{
						num2 = this.m_achievementProgress[num].GetCount();
					}
					return num2 >= data.GetActionCount();
				}
			}
			goto IL_34;
		}

		// Token: 0x06001A80 RID: 6784 RVA: 0x000116BB File Offset: 0x0000F8BB
		public int GetTownHallLevel()
		{
			return this.m_townHallLevel;
		}

		// Token: 0x06001A81 RID: 6785 RVA: 0x000116C3 File Offset: 0x0000F8C3
		public void SetTownHallLevel(int level)
		{
			this.m_townHallLevel = level;
		}

		// Token: 0x06001A82 RID: 6786 RVA: 0x000116CC File Offset: 0x0000F8CC
		public int GetVillage2TownHallLevel()
		{
			return this.m_townHallLevelVillage2;
		}

		// Token: 0x06001A83 RID: 6787 RVA: 0x000116D4 File Offset: 0x0000F8D4
		public void SetVillage2TownHallLevel(int level)
		{
			this.m_townHallLevelVillage2 = level;
		}

		// Token: 0x06001A84 RID: 6788 RVA: 0x000116DD File Offset: 0x0000F8DD
		public int GetAllianceCastleLevel()
		{
			return this.m_allianceCastleLevel;
		}

		// Token: 0x06001A85 RID: 6789 RVA: 0x00065408 File Offset: 0x00063608
		public void SetAllianceCastleLevel(int level)
		{
			this.m_allianceCastleLevel = level;
			if (this.m_allianceCastleLevel == -1)
			{
				this.m_allianceCastleTotalCapacity = 0;
				this.m_allianceCastleTotalSpellCapacity = 0;
				return;
			}
			LogicBuildingData allianceCastleData = LogicDataTables.GetAllianceCastleData();
			this.m_allianceCastleTotalCapacity = allianceCastleData.GetUnitStorageCapacity(level);
			this.m_allianceCastleTotalSpellCapacity = allianceCastleData.GetAltUnitStorageCapacity(level);
		}

		// Token: 0x06001A86 RID: 6790 RVA: 0x000116E5 File Offset: 0x0000F8E5
		public int GetRedPackageState()
		{
			return this.m_redPackageState;
		}

		// Token: 0x06001A87 RID: 6791 RVA: 0x00065454 File Offset: 0x00063654
		public int GetRedPackageCount()
		{
			int num = 0;
			for (int i = 4; i < 17; i *= 2)
			{
				if ((this.m_redPackageState & i) != 0)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06001A88 RID: 6792 RVA: 0x000116ED File Offset: 0x0000F8ED
		public void SetRedPackageState(int state)
		{
			if (this.m_redPackageState != state)
			{
				this.m_redPackageState = state;
				this.m_listener.REDPackageStateChanged(state);
			}
		}

		// Token: 0x06001A89 RID: 6793 RVA: 0x0001170B File Offset: 0x0000F90B
		public void ResetRedPackageState()
		{
			this.m_redPackageState &= 252;
		}

		// Token: 0x06001A8A RID: 6794 RVA: 0x0001171F File Offset: 0x0000F91F
		public bool HasAllianceCastle()
		{
			return this.m_allianceCastleLevel != -1;
		}

		// Token: 0x06001A8B RID: 6795 RVA: 0x0001172D File Offset: 0x0000F92D
		public int GetAllianceCastleTotalCapacity()
		{
			return this.m_allianceCastleTotalCapacity;
		}

		// Token: 0x06001A8C RID: 6796 RVA: 0x00011735 File Offset: 0x0000F935
		public int GetAllianceCastleTotalSpellCapacity()
		{
			return this.m_allianceCastleTotalSpellCapacity;
		}

		// Token: 0x06001A8D RID: 6797 RVA: 0x0001173D File Offset: 0x0000F93D
		public int GetAllianceCastleUsedCapacity()
		{
			return this.m_allianceCastleUsedCapacity;
		}

		// Token: 0x06001A8E RID: 6798 RVA: 0x00011745 File Offset: 0x0000F945
		public int GetAllianceCastleUsedSpellCapacity()
		{
			return this.m_allianceCastleUsedSpellCapacity;
		}

		// Token: 0x06001A8F RID: 6799 RVA: 0x0001174D File Offset: 0x0000F94D
		public int GetAllianceCastleFreeCapacity()
		{
			return this.m_allianceCastleTotalCapacity - this.m_allianceCastleUsedCapacity;
		}

		// Token: 0x06001A90 RID: 6800 RVA: 0x0001175C File Offset: 0x0000F95C
		public int GetAllianceCastleFreeSpellCapacity()
		{
			return this.m_allianceCastleTotalSpellCapacity - this.m_allianceCastleUsedSpellCapacity;
		}

		// Token: 0x06001A91 RID: 6801 RVA: 0x00065480 File Offset: 0x00063680
		public int GetAttackStrength(int villageType)
		{
			LogicComponentManager componentManagerAt = this.m_level.GetComponentManagerAt(villageType);
			LogicArrayList<LogicHeroData> logicArrayList = new LogicArrayList<LogicHeroData>();
			LogicArrayList<LogicCharacterData> logicArrayList2 = new LogicArrayList<LogicCharacterData>();
			LogicArrayList<LogicSpellData> logicArrayList3 = new LogicArrayList<LogicSpellData>();
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.HERO);
			LogicDataTable table2 = LogicDataTables.GetTable(LogicDataType.CHARACTER);
			LogicDataTable table3 = LogicDataTables.GetTable(LogicDataType.SPELL);
			int maxBarrackLevel = componentManagerAt.GetMaxBarrackLevel();
			int maxDarkBarrackLevel = componentManagerAt.GetMaxDarkBarrackLevel();
			int maxSpellForgeLevel = componentManagerAt.GetMaxSpellForgeLevel();
			int maxMiniSpellForgeLevel = componentManagerAt.GetMaxMiniSpellForgeLevel();
			for (int i = 0; i < table.GetItemCount(); i++)
			{
				LogicHeroData logicHeroData = (LogicHeroData)table.GetItemAt(i);
				if (componentManagerAt.IsHeroUnlocked(logicHeroData) && logicHeroData.IsProductionEnabled() && logicHeroData.GetVillageType() == villageType)
				{
					logicArrayList.Add(logicHeroData);
				}
			}
			for (int j = 0; j < table2.GetItemCount(); j++)
			{
				LogicCharacterData logicCharacterData = (LogicCharacterData)table2.GetItemAt(j);
				if (logicCharacterData.GetVillageType() == villageType && logicCharacterData.IsUnlockedForBarrackLevel((logicCharacterData.GetUnitOfType() == 1) ? maxBarrackLevel : maxDarkBarrackLevel) && logicCharacterData.IsProductionEnabled())
				{
					logicArrayList2.Add(logicCharacterData);
				}
			}
			for (int k = 0; k < table3.GetItemCount(); k++)
			{
				LogicSpellData logicSpellData = (LogicSpellData)table3.GetItemAt(k);
				if (logicSpellData.GetVillageType() == villageType && logicSpellData.IsUnlockedForProductionHouseLevel((logicSpellData.GetUnitOfType() == 1) ? maxSpellForgeLevel : maxMiniSpellForgeLevel) && logicSpellData.IsProductionEnabled())
				{
					logicArrayList3.Add(logicSpellData);
				}
			}
			int[] array = new int[logicArrayList.Size()];
			int[] array2 = new int[logicArrayList2.Size()];
			int[] array3 = new int[logicArrayList3.Size()];
			for (int l = 0; l < logicArrayList.Size(); l++)
			{
				array[l] = this.GetUnitUpgradeLevel(logicArrayList[l]);
			}
			for (int m = 0; m < logicArrayList2.Size(); m++)
			{
				array2[m] = this.GetUnitUpgradeLevel(logicArrayList2[m]);
			}
			for (int n = 0; n < logicArrayList3.Size(); n++)
			{
				array3[n] = this.GetUnitUpgradeLevel(logicArrayList3[n]);
			}
			int totalMaxHousing = componentManagerAt.GetTotalMaxHousing(LogicCombatItemType.CHARACTER);
			int unitStorageCapacity = LogicDataTables.GetBuildingByName("Spell Forge", null).GetUnitStorageCapacity(0);
			int unitStorageCapacity2 = LogicDataTables.GetBuildingByName("Mini Spell Factory", null).GetUnitStorageCapacity(0);
			int castleUpgLevel = (villageType == 0) ? this.m_allianceCastleLevel : -1;
			return (int)LogicStrengthUtil.GetAttackStrength(this.m_townHallLevel, castleUpgLevel, logicArrayList, array, logicArrayList2, array2, totalMaxHousing, logicArrayList3, array3, unitStorageCapacity + unitStorageCapacity2);
		}

		// Token: 0x06001A92 RID: 6802
		public abstract LogicLeagueData GetLeagueTypeData();

		// Token: 0x06001A93 RID: 6803
		public abstract void SaveToReplay(LogicJSONObject jsonObject);

		// Token: 0x06001A94 RID: 6804
		public abstract void SaveToDirect(LogicJSONObject jsonObject);

		// Token: 0x06001A95 RID: 6805
		public abstract void LoadForReplay(LogicJSONObject jsonObject, bool direct);

		// Token: 0x04000E17 RID: 3607
		protected LogicAvatarChangeListener m_listener;

		// Token: 0x04000E18 RID: 3608
		protected int m_townHallLevel;

		// Token: 0x04000E19 RID: 3609
		protected int m_townHallLevelVillage2;

		// Token: 0x04000E1A RID: 3610
		protected int m_allianceCastleLevel;

		// Token: 0x04000E1B RID: 3611
		protected int m_allianceCastleTotalCapacity;

		// Token: 0x04000E1C RID: 3612
		protected int m_allianceCastleUsedCapacity;

		// Token: 0x04000E1D RID: 3613
		protected int m_allianceCastleTotalSpellCapacity;

		// Token: 0x04000E1E RID: 3614
		protected int m_allianceCastleUsedSpellCapacity;

		// Token: 0x04000E1F RID: 3615
		protected int m_allianceUnitVisitCapacity;

		// Token: 0x04000E20 RID: 3616
		protected int m_allianceUnitSpellVisitCapacity;

		// Token: 0x04000E21 RID: 3617
		protected int m_allianceBadgeId;

		// Token: 0x04000E22 RID: 3618
		protected int m_leagueType;

		// Token: 0x04000E23 RID: 3619
		protected int m_redPackageState;

		// Token: 0x04000E24 RID: 3620
		protected LogicLevel m_level;

		// Token: 0x04000E25 RID: 3621
		protected LogicArrayList<LogicDataSlot> m_resourceCount;

		// Token: 0x04000E26 RID: 3622
		protected LogicArrayList<LogicDataSlot> m_resourceCap;

		// Token: 0x04000E27 RID: 3623
		protected LogicArrayList<LogicDataSlot> m_unitCount;

		// Token: 0x04000E28 RID: 3624
		protected LogicArrayList<LogicDataSlot> m_spellCount;

		// Token: 0x04000E29 RID: 3625
		protected LogicArrayList<LogicDataSlot> m_unitUpgrade;

		// Token: 0x04000E2A RID: 3626
		protected LogicArrayList<LogicDataSlot> m_spellUpgrade;

		// Token: 0x04000E2B RID: 3627
		protected LogicArrayList<LogicDataSlot> m_heroUpgrade;

		// Token: 0x04000E2C RID: 3628
		protected LogicArrayList<LogicDataSlot> m_heroHealth;

		// Token: 0x04000E2D RID: 3629
		protected LogicArrayList<LogicDataSlot> m_heroState;

		// Token: 0x04000E2E RID: 3630
		protected LogicArrayList<LogicDataSlot> m_heroMode;

		// Token: 0x04000E2F RID: 3631
		protected LogicArrayList<LogicDataSlot> m_unitCountVillage2;

		// Token: 0x04000E30 RID: 3632
		protected LogicArrayList<LogicDataSlot> m_unitCountNewVillage2;

		// Token: 0x04000E31 RID: 3633
		protected LogicArrayList<LogicDataSlot> m_achievementProgress;

		// Token: 0x04000E32 RID: 3634
		protected LogicArrayList<LogicDataSlot> m_lootedNpcGold;

		// Token: 0x04000E33 RID: 3635
		protected LogicArrayList<LogicDataSlot> m_lootedNpcElixir;

		// Token: 0x04000E34 RID: 3636
		protected LogicArrayList<LogicDataSlot> m_npcStars;

		// Token: 0x04000E35 RID: 3637
		protected LogicArrayList<LogicDataSlot> m_variables;

		// Token: 0x04000E36 RID: 3638
		protected LogicArrayList<LogicDataSlot> m_unitPreset1;

		// Token: 0x04000E37 RID: 3639
		protected LogicArrayList<LogicDataSlot> m_unitPreset2;

		// Token: 0x04000E38 RID: 3640
		protected LogicArrayList<LogicDataSlot> m_unitPreset3;

		// Token: 0x04000E39 RID: 3641
		protected LogicArrayList<LogicDataSlot> m_previousArmy;

		// Token: 0x04000E3A RID: 3642
		protected LogicArrayList<LogicDataSlot> m_eventUnitCounter;

		// Token: 0x04000E3B RID: 3643
		protected LogicArrayList<LogicDataSlot> m_freeActionCount;

		// Token: 0x04000E3C RID: 3644
		protected LogicArrayList<LogicUnitSlot> m_allianceUnitCount;

		// Token: 0x04000E3D RID: 3645
		protected LogicArrayList<LogicData> m_achievementRewardClaimed;

		// Token: 0x04000E3E RID: 3646
		protected LogicArrayList<LogicData> m_missionCompleted;
	}
}
