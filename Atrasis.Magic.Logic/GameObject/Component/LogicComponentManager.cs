using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.GameObject.Component
{
	// Token: 0x02000121 RID: 289
	public class LogicComponentManager
	{
		// Token: 0x06000F4E RID: 3918 RVA: 0x0003FFEC File Offset: 0x0003E1EC
		public LogicComponentManager(LogicLevel level)
		{
			this.logicLevel_0 = level;
			this.logicArrayList_1 = new LogicArrayList<LogicDataSlot>();
			this.logicArrayList_0 = new LogicArrayList<LogicComponent>[17];
			for (int i = 0; i < 17; i++)
			{
				this.logicArrayList_0[i] = new LogicArrayList<LogicComponent>(32);
			}
		}

		// Token: 0x06000F4F RID: 3919 RVA: 0x0004003C File Offset: 0x0003E23C
		public void Destruct()
		{
			for (int i = 0; i < 17; i++)
			{
				if (this.logicArrayList_0[i] != null)
				{
					this.logicArrayList_0[i].Destruct();
					this.logicArrayList_0[i] = null;
				}
			}
			if (this.logicArrayList_1 != null)
			{
				for (int j = this.logicArrayList_1.Size() - 1; j >= 0; j--)
				{
					this.logicArrayList_1[j].Destruct();
					this.logicArrayList_1.Remove(j);
				}
			}
		}

		// Token: 0x06000F50 RID: 3920 RVA: 0x0000A7CD File Offset: 0x000089CD
		public void AddComponent(LogicComponent component)
		{
			this.logicArrayList_0[(int)component.GetComponentType()].Add(component);
		}

		// Token: 0x06000F51 RID: 3921 RVA: 0x000400B4 File Offset: 0x0003E2B4
		public void ValidateTroopUpgradeLevels()
		{
			LogicAvatar homeOwnerAvatar = this.logicLevel_0.GetHomeOwnerAvatar();
			if (homeOwnerAvatar != null && homeOwnerAvatar.IsClientAvatar())
			{
				int[] array = new int[2];
				for (int i = 0; i < 2; i++)
				{
					LogicBuilding laboratory = this.logicLevel_0.GetGameObjectManagerAt(i).GetLaboratory();
					if (laboratory != null)
					{
						array[i] = laboratory.GetUpgradeLevel();
					}
				}
				LogicDataTable table = LogicDataTables.GetTable(LogicDataType.CHARACTER);
				for (int j = 0; j < table.GetItemCount(); j++)
				{
					LogicCharacterData logicCharacterData = (LogicCharacterData)table.GetItemAt(j);
					int unitUpgradeLevel = homeOwnerAvatar.GetUnitUpgradeLevel(logicCharacterData);
					int villageType = logicCharacterData.GetVillageType();
					int num = unitUpgradeLevel;
					if (unitUpgradeLevel >= logicCharacterData.GetUpgradeLevelCount())
					{
						num = logicCharacterData.GetUpgradeLevelCount() - 1;
					}
					int num2 = array[villageType];
					int requiredLaboratoryLevel;
					do
					{
						requiredLaboratoryLevel = logicCharacterData.GetRequiredLaboratoryLevel(num--);
					}
					while (num >= 0 && requiredLaboratoryLevel > num2);
					num++;
					if (unitUpgradeLevel > num)
					{
						homeOwnerAvatar.SetUnitUpgradeLevel(logicCharacterData, num);
						homeOwnerAvatar.GetChangeListener().CommodityCountChanged(1, logicCharacterData, num);
					}
				}
				LogicDataTable table2 = LogicDataTables.GetTable(LogicDataType.SPELL);
				for (int k = 0; k < table2.GetItemCount(); k++)
				{
					LogicSpellData logicSpellData = (LogicSpellData)table2.GetItemAt(k);
					int unitUpgradeLevel2 = homeOwnerAvatar.GetUnitUpgradeLevel(logicSpellData);
					int villageType2 = logicSpellData.GetVillageType();
					int num3 = unitUpgradeLevel2;
					if (unitUpgradeLevel2 >= logicSpellData.GetUpgradeLevelCount())
					{
						num3 = logicSpellData.GetUpgradeLevelCount() - 1;
					}
					int num4 = array[villageType2];
					int requiredLaboratoryLevel2;
					do
					{
						requiredLaboratoryLevel2 = logicSpellData.GetRequiredLaboratoryLevel(num3--);
					}
					while (num3 >= 0 && requiredLaboratoryLevel2 > num4);
					num3++;
					if (unitUpgradeLevel2 > num3)
					{
						homeOwnerAvatar.SetUnitUpgradeLevel(logicSpellData, num3);
						homeOwnerAvatar.GetChangeListener().CommodityCountChanged(1, logicSpellData, num3);
					}
				}
			}
		}

		// Token: 0x06000F52 RID: 3922 RVA: 0x00040268 File Offset: 0x0003E468
		public void CalculateLoot(bool includeStorage)
		{
			if (includeStorage)
			{
				LogicArrayList<LogicComponent> logicArrayList = this.logicArrayList_0[6];
				for (int i = 0; i < logicArrayList.Size(); i++)
				{
					((LogicResourceStorageComponent)logicArrayList[i]).RecalculateAvailableLoot();
				}
			}
			LogicArrayList<LogicComponent> logicArrayList2 = this.logicArrayList_0[5];
			for (int j = 0; j < logicArrayList2.Size(); j++)
			{
				((LogicResourceProductionComponent)logicArrayList2[j]).RecalculateAvailableLoot();
			}
			LogicArrayList<LogicComponent> logicArrayList3 = this.logicArrayList_0[11];
			Debugger.DoAssert(logicArrayList3.Size() < 2, "Too many war storage components");
			for (int k = 0; k < logicArrayList3.Size(); k++)
			{
				((LogicWarResourceStorageComponent)logicArrayList3[k]).RecalculateAvailableLoot();
			}
		}

		// Token: 0x06000F53 RID: 3923 RVA: 0x00040318 File Offset: 0x0003E518
		public void AddAvatarAllianceUnitsToCastle()
		{
			LogicBuilding allianceCastle = this.logicLevel_0.GetGameObjectManagerAt(0).GetAllianceCastle();
			if (allianceCastle != null)
			{
				LogicBunkerComponent bunkerComponent = allianceCastle.GetBunkerComponent();
				if (bunkerComponent != null)
				{
					bunkerComponent.RemoveAllUnits();
					LogicArrayList<LogicUnitSlot> allianceUnits = this.logicLevel_0.GetHomeOwnerAvatar().GetAllianceUnits();
					for (int i = 0; i < allianceUnits.Size(); i++)
					{
						LogicUnitSlot logicUnitSlot = allianceUnits[i];
						LogicCombatItemData logicCombatItemData = (LogicCombatItemData)logicUnitSlot.GetData();
						int count = logicUnitSlot.GetCount();
						if (logicCombatItemData != null)
						{
							if (logicCombatItemData.GetCombatItemType() == LogicCombatItemType.CHARACTER)
							{
								for (int j = 0; j < count; j++)
								{
									if (bunkerComponent.GetUnusedCapacity() >= logicCombatItemData.GetHousingSpace())
									{
										bunkerComponent.AddUnitImpl(logicCombatItemData, logicUnitSlot.GetLevel());
									}
								}
							}
						}
						else
						{
							Debugger.Error("LogicComponentManager::addAvatarAllianceUnitsToCastle - NULL character");
						}
					}
				}
			}
		}

		// Token: 0x06000F54 RID: 3924 RVA: 0x000403DC File Offset: 0x0003E5DC
		public void DivideAvatarResourcesToStorages()
		{
			LogicAvatar homeOwnerAvatar = this.logicLevel_0.GetHomeOwnerAvatar();
			if (homeOwnerAvatar != null)
			{
				LogicArrayList<LogicComponent> logicArrayList = this.logicArrayList_0[6];
				LogicArrayList<LogicComponent> logicArrayList2 = this.logicArrayList_0[11];
				LogicDataTable table = LogicDataTables.GetTable(LogicDataType.RESOURCE);
				for (int i = 0; i < table.GetItemCount(); i++)
				{
					LogicResourceData logicResourceData = (LogicResourceData)table.GetItemAt(i);
					if (!logicResourceData.IsPremiumCurrency())
					{
						if (logicResourceData.GetWarResourceReferenceData() != null)
						{
							Debugger.DoAssert(logicArrayList2.Size() < 2, "Too many war storage components");
							for (int j = 0; j < logicArrayList2.Size(); j++)
							{
								((LogicWarResourceStorageComponent)logicArrayList2[j]).SetCount(i, homeOwnerAvatar.GetResourceCount(logicResourceData));
							}
						}
						else
						{
							for (int k = 0; k < logicArrayList.Size(); k++)
							{
								((LogicResourceStorageComponent)logicArrayList[k]).SetCount(i, 0);
							}
							int num = homeOwnerAvatar.GetResourceCount(logicResourceData);
							if (this.logicLevel_0.GetBattleLog() != null && logicResourceData.GetVillageType() == 1)
							{
								num = LogicMath.Max(num - this.logicLevel_0.GetBattleLog().GetCostCount(logicResourceData), 0);
							}
							this.AddResources(i, num, true);
						}
					}
				}
			}
		}

		// Token: 0x06000F55 RID: 3925 RVA: 0x00040510 File Offset: 0x0003E710
		public int AddResources(int idx, int count, bool useRecommencedMax)
		{
			LogicArrayList<LogicComponent> logicArrayList = this.logicArrayList_0[6];
			while (count > 0)
			{
				int num = 0;
				for (int i = 0; i < logicArrayList.Size(); i++)
				{
					LogicResourceStorageComponent logicResourceStorageComponent = (LogicResourceStorageComponent)logicArrayList[i];
					int num2 = useRecommencedMax ? logicResourceStorageComponent.GetRecommendedMax(idx, count) : logicResourceStorageComponent.GetMax(idx);
					int count2 = logicResourceStorageComponent.GetCount(idx);
					if (num2 > count2)
					{
						num++;
					}
				}
				if (num > 0)
				{
					int valueA = (count + num - 1) / num;
					for (int j = 0; j < logicArrayList.Size(); j++)
					{
						LogicResourceStorageComponent logicResourceStorageComponent2 = (LogicResourceStorageComponent)logicArrayList[j];
						int num3 = useRecommencedMax ? logicResourceStorageComponent2.GetRecommendedMax(idx, count) : logicResourceStorageComponent2.GetMax(idx);
						int count3 = logicResourceStorageComponent2.GetCount(idx);
						int num4 = num3 - count3;
						if (num4 > 0)
						{
							int num5 = LogicMath.Min(valueA, count);
							if (num5 >= num4)
							{
								num--;
							}
							if (num5 <= num4)
							{
								num4 = num5;
							}
							logicResourceStorageComponent2.SetCount(idx, num4 + count3);
							count -= num4;
							if (count == 0)
							{
								return 0;
							}
						}
					}
				}
				if (num <= 0 && !useRecommencedMax)
				{
					return count;
				}
				useRecommencedMax &= (num > 0);
			}
			return 0;
		}

		// Token: 0x06000F56 RID: 3926 RVA: 0x0000A7E2 File Offset: 0x000089E2
		public LogicArrayList<LogicComponent> GetComponents(LogicComponentType componentType)
		{
			return this.logicArrayList_0[(int)componentType];
		}

		// Token: 0x06000F57 RID: 3927 RVA: 0x00040620 File Offset: 0x0003E820
		public void RemoveComponent(LogicComponent component)
		{
			LogicArrayList<LogicComponent> logicArrayList = this.logicArrayList_0[(int)component.GetComponentType()];
			int i = 0;
			int num = logicArrayList.Size();
			while (i < num)
			{
				if (logicArrayList[i] == component)
				{
					logicArrayList.Remove(i);
					return;
				}
				i++;
			}
		}

		// Token: 0x06000F58 RID: 3928 RVA: 0x00040664 File Offset: 0x0003E864
		public void RemoveGameObjectReferences(LogicGameObject gameObject)
		{
			for (int i = 0; i < 17; i++)
			{
				LogicArrayList<LogicComponent> logicArrayList = this.logicArrayList_0[0];
				for (int j = 0; j < logicArrayList.Size(); j++)
				{
					logicArrayList[j].RemoveGameObjectReferences(gameObject);
				}
			}
		}

		// Token: 0x06000F59 RID: 3929 RVA: 0x000406A8 File Offset: 0x0003E8A8
		public LogicComponent GetClosestComponent(int x, int y, LogicComponentFilter filter)
		{
			LogicArrayList<LogicComponent> logicArrayList = this.logicArrayList_0[(int)filter.GetComponentType()];
			LogicComponent logicComponent = null;
			int num = 0;
			int i = 0;
			int num2 = logicArrayList.Size();
			while (i < num2)
			{
				LogicComponent logicComponent2 = logicArrayList[i];
				if (filter.TestComponent(logicComponent2))
				{
					int distanceSquaredTo = logicComponent2.GetParent().GetPosition().GetDistanceSquaredTo(x, y);
					if (distanceSquaredTo < num || logicComponent == null)
					{
						num = distanceSquaredTo;
						logicComponent = logicComponent2;
					}
				}
				i++;
			}
			return logicComponent;
		}

		// Token: 0x06000F5A RID: 3930 RVA: 0x00040714 File Offset: 0x0003E914
		public int GetTotalUsedHousing(LogicCombatItemType unitType)
		{
			LogicArrayList<LogicComponent> logicArrayList = this.logicArrayList_0[0];
			int num = 0;
			for (int i = 0; i < logicArrayList.Size(); i++)
			{
				LogicUnitStorageComponent logicUnitStorageComponent = (LogicUnitStorageComponent)logicArrayList[i];
				if (logicUnitStorageComponent.GetStorageType() == unitType)
				{
					num += logicUnitStorageComponent.GetUsedCapacity();
				}
			}
			return num;
		}

		// Token: 0x06000F5B RID: 3931 RVA: 0x00040760 File Offset: 0x0003E960
		public int GetTotalMaxHousing(LogicCombatItemType combatItemType)
		{
			LogicArrayList<LogicComponent> logicArrayList = this.logicArrayList_0[0];
			LogicArrayList<LogicComponent> logicArrayList2 = this.logicArrayList_0[15];
			int num = 0;
			for (int i = 0; i < logicArrayList.Size(); i++)
			{
				LogicUnitStorageComponent logicUnitStorageComponent = (LogicUnitStorageComponent)logicArrayList[i];
				if (logicUnitStorageComponent.GetStorageType() == combatItemType)
				{
					num += logicUnitStorageComponent.GetMaxCapacity();
				}
			}
			return num + (int)((float)logicArrayList2.Size() * 30f);
		}

		// Token: 0x06000F5C RID: 3932 RVA: 0x000407C8 File Offset: 0x0003E9C8
		public int GetMaxBarrackLevel()
		{
			LogicArrayList<LogicComponent> logicArrayList = this.logicArrayList_0[3];
			if (logicArrayList.Size() > 0)
			{
				int num = -1;
				int num2 = 0;
				do
				{
					LogicUnitProductionComponent logicUnitProductionComponent = (LogicUnitProductionComponent)logicArrayList[num2];
					if (logicUnitProductionComponent.GetProductionType() == LogicCombatItemType.CHARACTER && logicUnitProductionComponent.GetParent().GetGameObjectType() == LogicGameObjectType.BUILDING)
					{
						LogicBuilding logicBuilding = (LogicBuilding)logicUnitProductionComponent.GetParent();
						if (logicBuilding.GetBuildingData().GetProducesUnitsOfType() == 1)
						{
							num = LogicMath.Max(logicBuilding.GetUpgradeLevel(), num);
						}
					}
				}
				while (++num2 != logicArrayList.Size());
				return num;
			}
			return -1;
		}

		// Token: 0x06000F5D RID: 3933 RVA: 0x00040850 File Offset: 0x0003EA50
		public int GetMaxDarkBarrackLevel()
		{
			LogicArrayList<LogicComponent> logicArrayList = this.logicArrayList_0[3];
			if (logicArrayList.Size() > 0)
			{
				int num = -1;
				int num2 = 0;
				do
				{
					LogicUnitProductionComponent logicUnitProductionComponent = (LogicUnitProductionComponent)logicArrayList[num2];
					if (logicUnitProductionComponent.GetProductionType() == LogicCombatItemType.CHARACTER && logicUnitProductionComponent.GetParent().GetGameObjectType() == LogicGameObjectType.BUILDING)
					{
						LogicBuilding logicBuilding = (LogicBuilding)logicUnitProductionComponent.GetParent();
						if (logicBuilding.GetBuildingData().GetProducesUnitsOfType() == 2 && (!logicBuilding.IsConstructing() || logicBuilding.IsUpgrading()))
						{
							num = LogicMath.Max(logicBuilding.GetUpgradeLevel(), num);
						}
					}
				}
				while (++num2 != logicArrayList.Size());
				return num;
			}
			return -1;
		}

		// Token: 0x06000F5E RID: 3934 RVA: 0x000408EC File Offset: 0x0003EAEC
		public int GetMaxSpellForgeLevel()
		{
			LogicArrayList<LogicComponent> logicArrayList = this.logicArrayList_0[3];
			if (logicArrayList.Size() > 0)
			{
				int num = -1;
				int num2 = 0;
				do
				{
					LogicUnitProductionComponent logicUnitProductionComponent = (LogicUnitProductionComponent)logicArrayList[num2];
					if (logicUnitProductionComponent.GetProductionType() != LogicCombatItemType.CHARACTER && logicUnitProductionComponent.GetParent().GetGameObjectType() == LogicGameObjectType.BUILDING)
					{
						LogicBuilding logicBuilding = (LogicBuilding)logicUnitProductionComponent.GetParent();
						if (logicBuilding.GetBuildingData().GetProducesUnitsOfType() == 1 && (!logicBuilding.IsConstructing() || logicBuilding.IsUpgrading()))
						{
							num = LogicMath.Max(logicBuilding.GetUpgradeLevel(), num);
						}
					}
				}
				while (++num2 != logicArrayList.Size());
				return num;
			}
			return -1;
		}

		// Token: 0x06000F5F RID: 3935 RVA: 0x00040988 File Offset: 0x0003EB88
		public int GetMaxMiniSpellForgeLevel()
		{
			LogicArrayList<LogicComponent> logicArrayList = this.logicArrayList_0[3];
			if (logicArrayList.Size() > 0)
			{
				int num = -1;
				int num2 = 0;
				do
				{
					LogicUnitProductionComponent logicUnitProductionComponent = (LogicUnitProductionComponent)logicArrayList[num2];
					if (logicUnitProductionComponent.GetProductionType() != LogicCombatItemType.CHARACTER && logicUnitProductionComponent.GetParent().GetGameObjectType() == LogicGameObjectType.BUILDING)
					{
						LogicBuilding logicBuilding = (LogicBuilding)logicUnitProductionComponent.GetParent();
						if (logicBuilding.GetBuildingData().GetProducesUnitsOfType() == 2 && (!logicBuilding.IsConstructing() || logicBuilding.IsUpgrading()))
						{
							num = LogicMath.Max(logicBuilding.GetUpgradeLevel(), num);
						}
					}
				}
				while (++num2 != logicArrayList.Size());
				return num;
			}
			return -1;
		}

		// Token: 0x06000F60 RID: 3936 RVA: 0x00040A24 File Offset: 0x0003EC24
		public void DivideAvatarUnitsToStorages(int villageType)
		{
			if (this.logicLevel_0.GetHomeOwnerAvatar() != null)
			{
				if (villageType == 1)
				{
					for (int i = this.logicArrayList_1.Size() - 1; i >= 0; i--)
					{
						this.logicArrayList_1[i].Destruct();
						this.logicArrayList_1.Remove(i);
					}
					LogicAvatar homeOwnerAvatar = this.logicLevel_0.GetHomeOwnerAvatar();
					LogicArrayList<LogicComponent> logicArrayList = this.logicArrayList_0[15];
					if (homeOwnerAvatar.GetUnitsNewTotalVillage2() > 0 && !LogicDataTables.GetGlobals().Village2TrainingOnlyUseRegularStorage())
					{
						LogicArrayList<LogicDataSlot> unitsNewVillage = homeOwnerAvatar.GetUnitsNewVillage2();
						int j = 0;
						IL_146:
						while (j < unitsNewVillage.Size())
						{
							LogicDataSlot logicDataSlot = unitsNewVillage[j];
							LogicCharacterData logicCharacterData = (LogicCharacterData)logicDataSlot.GetData();
							int count = logicDataSlot.GetCount();
							int num = -1;
							for (int k = 0; k < this.logicArrayList_1.Size(); k++)
							{
								if (this.logicArrayList_1[k].GetData() == logicCharacterData)
								{
									num = k;
									IL_E5:
									if (count > 0)
									{
										if (num != -1)
										{
											this.logicArrayList_1[num].SetCount(this.logicArrayList_1[num].GetCount() + count);
											this.logicArrayList_1.Add(new LogicDataSlot(logicCharacterData, count));
										}
										else
										{
											this.logicArrayList_1.Add(new LogicDataSlot(logicCharacterData, count));
										}
									}
									j++;
									goto IL_146;
								}
							}
							goto IL_E5;
						}
						for (int l = 0; l < this.logicArrayList_1.Size(); l++)
						{
							homeOwnerAvatar.CommodityCountChangeHelper(8, this.logicArrayList_1[l].GetData(), -this.logicArrayList_1[l].GetCount());
						}
						for (int m = 0; m < this.logicArrayList_1.Size(); m++)
						{
							LogicDataSlot logicDataSlot2 = this.logicArrayList_1[m];
							LogicCharacterData logicCharacterData2 = (LogicCharacterData)logicDataSlot2.GetData();
							int num2 = logicDataSlot2.GetCount();
							if (num2 > 0)
							{
								for (int n = 0; n < logicArrayList.Size(); n++)
								{
									LogicVillage2UnitComponent logicVillage2UnitComponent = (LogicVillage2UnitComponent)logicArrayList[n];
									int maxUnitsInCamp = logicVillage2UnitComponent.GetMaxUnitsInCamp(logicCharacterData2);
									int num3 = LogicMath.Min(num2, maxUnitsInCamp);
									logicVillage2UnitComponent.SetUnit(logicCharacterData2, num3);
									logicVillage2UnitComponent.TrainUnit(logicCharacterData2);
									num2 -= num3;
									if (num2 <= 0)
									{
										break;
									}
								}
							}
						}
						return;
					}
					int num4 = 0;
					IL_2E3:
					while (num4 < logicArrayList.Size())
					{
						LogicVillage2UnitComponent logicVillage2UnitComponent2 = (LogicVillage2UnitComponent)logicArrayList[num4];
						LogicCombatItemData unitData = logicVillage2UnitComponent2.GetUnitData();
						int num5 = -1;
						for (int num6 = 0; num6 < this.logicArrayList_1.Size(); num6++)
						{
							if (this.logicArrayList_1[num6].GetData() == unitData)
							{
								num5 = num6;
								IL_290:
								if (num5 == -1)
								{
									this.logicArrayList_1.Add(new LogicDataSlot(unitData, -logicVillage2UnitComponent2.GetUnitCount()));
								}
								else
								{
									this.logicArrayList_1[num5].SetCount(this.logicArrayList_1[num5].GetCount() - logicVillage2UnitComponent2.GetUnitCount());
								}
								num4++;
								goto IL_2E3;
							}
						}
						goto IL_290;
					}
					LogicArrayList<LogicDataSlot> unitsVillage = homeOwnerAvatar.GetUnitsVillage2();
					int num7 = 0;
					IL_39E:
					while (num7 < unitsVillage.Size())
					{
						LogicDataSlot logicDataSlot3 = unitsVillage[num7];
						LogicCombatItemData logicCombatItemData = (LogicCombatItemData)logicDataSlot3.GetData();
						int count2 = logicDataSlot3.GetCount();
						int num8 = -1;
						for (int num9 = 0; num9 < this.logicArrayList_1.Size(); num9++)
						{
							if (this.logicArrayList_1[num9].GetData() == logicCombatItemData)
							{
								num8 = num9;
								IL_356:
								if (num8 == -1)
								{
									this.logicArrayList_1.Add(new LogicDataSlot(logicCombatItemData, count2));
								}
								else
								{
									this.logicArrayList_1[num8].SetCount(this.logicArrayList_1[num8].GetCount() + count2);
								}
								num7++;
								goto IL_39E;
							}
						}
						goto IL_356;
					}
					for (int num10 = 0; num10 < this.logicArrayList_1.Size(); num10++)
					{
						LogicDataSlot logicDataSlot4 = this.logicArrayList_1[num10];
						LogicCharacterData logicCharacterData3 = (LogicCharacterData)logicDataSlot4.GetData();
						int num11 = logicDataSlot4.GetCount();
						if (num11 != 0)
						{
							for (int num12 = 0; num12 < logicArrayList.Size(); num12++)
							{
								LogicVillage2UnitComponent logicVillage2UnitComponent3 = (LogicVillage2UnitComponent)logicArrayList[num12];
								if (logicVillage2UnitComponent3.GetUnitData() == logicCharacterData3)
								{
									int highestBuildingLevel = this.logicLevel_0.GetGameObjectManagerAt(1).GetHighestBuildingLevel(logicCharacterData3.GetProductionHouseData());
									if (logicCharacterData3.IsUnlockedForProductionHouseLevel(highestBuildingLevel))
									{
										if (num11 < 0)
										{
											int unitCount = logicVillage2UnitComponent3.GetUnitCount();
											if (unitCount >= -num11)
											{
												logicVillage2UnitComponent3.SetUnit(logicCharacterData3, LogicMath.Max(0, unitCount + num11));
												num11 += unitCount;
											}
											else
											{
												logicVillage2UnitComponent3.SetUnit(logicCharacterData3, 0);
												num11 += unitCount;
											}
										}
										else
										{
											int num13 = LogicMath.Min(logicVillage2UnitComponent3.GetMaxUnitsInCamp(logicCharacterData3), num11);
											logicVillage2UnitComponent3.SetUnit(logicCharacterData3, num13);
											num11 -= num13;
										}
										logicVillage2UnitComponent3.TrainUnit(logicCharacterData3);
									}
									else
									{
										logicVillage2UnitComponent3.RemoveUnits();
									}
								}
								if (num11 == 0)
								{
									break;
								}
							}
							if (num11 > 0)
							{
								homeOwnerAvatar.SetUnitCountVillage2(logicCharacterData3, 0);
								homeOwnerAvatar.GetChangeListener().CommodityCountChanged(7, logicCharacterData3, 0);
							}
						}
					}
					return;
				}
				else
				{
					for (int num14 = this.logicArrayList_1.Size() - 1; num14 >= 0; num14--)
					{
						this.logicArrayList_1[num14].Destruct();
						this.logicArrayList_1.Remove(num14);
					}
					LogicArrayList<LogicComponent> logicArrayList2 = this.logicArrayList_0[0];
					for (int num15 = 0; num15 < logicArrayList2.Size(); num15++)
					{
						LogicUnitStorageComponent logicUnitStorageComponent = (LogicUnitStorageComponent)logicArrayList2[num15];
						int num16 = 0;
						IL_5EC:
						while (num16 < logicUnitStorageComponent.GetUnitTypeCount())
						{
							LogicCombatItemData unitType = logicUnitStorageComponent.GetUnitType(num16);
							int unitCount2 = logicUnitStorageComponent.GetUnitCount(num16);
							int num17 = -1;
							for (int num18 = 0; num18 < this.logicArrayList_1.Size(); num18++)
							{
								if (this.logicArrayList_1[num18].GetData() == unitType)
								{
									num17 = num18;
									IL_5A3:
									if (num17 != -1)
									{
										this.logicArrayList_1[num17].SetCount(this.logicArrayList_1[num17].GetCount() - unitCount2);
									}
									else
									{
										this.logicArrayList_1.Add(new LogicDataSlot(unitType, -unitCount2));
									}
									num16++;
									goto IL_5EC;
								}
							}
							goto IL_5A3;
						}
					}
					LogicArrayList<LogicDataSlot> units = this.logicLevel_0.GetHomeOwnerAvatar().GetUnits();
					int num19 = 0;
					IL_6CA:
					while (num19 < units.Size())
					{
						LogicDataSlot logicDataSlot5 = units[num19];
						int num20 = -1;
						for (int num21 = 0; num21 < this.logicArrayList_1.Size(); num21++)
						{
							if (this.logicArrayList_1[num21].GetData() == logicDataSlot5.GetData())
							{
								num20 = num21;
								IL_673:
								if (num20 != -1)
								{
									this.logicArrayList_1[num20].SetCount(this.logicArrayList_1[num20].GetCount() + logicDataSlot5.GetCount());
								}
								else
								{
									this.logicArrayList_1.Add(new LogicDataSlot(logicDataSlot5.GetData(), logicDataSlot5.GetCount()));
								}
								num19++;
								goto IL_6CA;
							}
						}
						goto IL_673;
					}
					LogicArrayList<LogicDataSlot> spells = this.logicLevel_0.GetHomeOwnerAvatar().GetSpells();
					int num22 = 0;
					IL_794:
					while (num22 < spells.Size())
					{
						LogicDataSlot logicDataSlot6 = spells[num22];
						int num23 = -1;
						for (int num24 = 0; num24 < this.logicArrayList_1.Size(); num24++)
						{
							if (this.logicArrayList_1[num24].GetData() == logicDataSlot6.GetData())
							{
								num23 = num24;
								IL_73D:
								if (num23 != -1)
								{
									this.logicArrayList_1[num23].SetCount(this.logicArrayList_1[num23].GetCount() + logicDataSlot6.GetCount());
								}
								else
								{
									this.logicArrayList_1.Add(new LogicDataSlot(logicDataSlot6.GetData(), logicDataSlot6.GetCount()));
								}
								num22++;
								goto IL_794;
							}
						}
						goto IL_73D;
					}
					for (int num25 = 0; num25 < this.logicArrayList_1.Size(); num25++)
					{
						LogicDataSlot logicDataSlot7 = this.logicArrayList_1[num25];
						LogicCombatItemData data = (LogicCombatItemData)logicDataSlot7.GetData();
						int num26 = logicDataSlot7.GetCount();
						if (num26 != 0)
						{
							for (int num27 = 0; num27 < logicArrayList2.Size(); num27++)
							{
								LogicUnitStorageComponent logicUnitStorageComponent2 = (LogicUnitStorageComponent)logicArrayList2[num27];
								if (num26 >= 0)
								{
									while (logicUnitStorageComponent2.CanAddUnit(data))
									{
										logicUnitStorageComponent2.AddUnit(data);
										if (--num26 <= 0)
										{
											break;
										}
									}
								}
								else
								{
									int unitTypeIndex = logicUnitStorageComponent2.GetUnitTypeIndex(data);
									if (unitTypeIndex != -1)
									{
										int unitCount3 = logicUnitStorageComponent2.GetUnitCount(unitTypeIndex);
										if (unitCount3 >= -num26)
										{
											logicUnitStorageComponent2.RemoveUnits(data, -num26);
											break;
										}
										logicUnitStorageComponent2.RemoveUnits(data, unitCount3);
										num26 += unitCount3;
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06000F61 RID: 3937 RVA: 0x000412AC File Offset: 0x0003F4AC
		public bool IsHeroUnlocked(LogicHeroData data)
		{
			LogicArrayList<LogicComponent> logicArrayList = this.logicArrayList_0[10];
			for (int i = 0; i < logicArrayList.Size(); i++)
			{
				LogicHeroBaseComponent logicHeroBaseComponent = (LogicHeroBaseComponent)logicArrayList[i];
				if (logicHeroBaseComponent.GetHeroData() == data && !((LogicBuilding)logicHeroBaseComponent.GetParent()).IsLocked())
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000F62 RID: 3938 RVA: 0x00041300 File Offset: 0x0003F500
		public void DebugVillage2UnitAdded(bool updateComponents)
		{
			LogicAvatar homeOwnerAvatar = this.logicLevel_0.GetHomeOwnerAvatar();
			if (homeOwnerAvatar != null && updateComponents)
			{
				LogicArrayList<LogicComponent> logicArrayList = this.logicArrayList_0[15];
				LogicArrayList<LogicDataSlot> unitsVillage = homeOwnerAvatar.GetUnitsVillage2();
				for (int i = 0; i < LogicMath.Min(logicArrayList.Size(), unitsVillage.Size()); i++)
				{
					LogicVillage2UnitComponent logicVillage2UnitComponent = (LogicVillage2UnitComponent)logicArrayList[i];
					LogicCharacterData logicCharacterData = (LogicCharacterData)unitsVillage[i].GetData();
					logicVillage2UnitComponent.RemoveUnits();
					logicVillage2UnitComponent.SetUnit(logicCharacterData, logicVillage2UnitComponent.GetMaxUnitsInCamp(logicCharacterData));
				}
			}
		}

		// Token: 0x06000F63 RID: 3939 RVA: 0x00041388 File Offset: 0x0003F588
		public void Tick()
		{
			bool flag = this.logicLevel_0.IsInCombatState();
			for (int i = 0; i < 17; i++)
			{
				LogicArrayList<LogicComponent> logicArrayList = this.logicArrayList_0[i];
				int j = 0;
				int num = logicArrayList.Size();
				while (j < num)
				{
					LogicComponent logicComponent = logicArrayList[j];
					if (logicComponent.IsEnabled())
					{
						logicComponent.Tick();
					}
					j++;
				}
				if (i == 0 && !flag)
				{
					i = 1;
				}
			}
		}

		// Token: 0x06000F64 RID: 3940 RVA: 0x00002463 File Offset: 0x00000663
		public void SubTick()
		{
		}

		// Token: 0x0400064D RID: 1613
		private readonly LogicLevel logicLevel_0;

		// Token: 0x0400064E RID: 1614
		private readonly LogicArrayList<LogicComponent>[] logicArrayList_0;

		// Token: 0x0400064F RID: 1615
		private readonly LogicArrayList<LogicDataSlot> logicArrayList_1;
	}
}
