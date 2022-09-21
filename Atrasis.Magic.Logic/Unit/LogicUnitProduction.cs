using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Time;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Unit
{
	// Token: 0x02000014 RID: 20
	public class LogicUnitProduction
	{
		// Token: 0x060000B1 RID: 177 RVA: 0x000026F0 File Offset: 0x000008F0
		public LogicUnitProduction(LogicLevel level, LogicDataType unitProductionType, int villageType)
		{
			this.logicLevel_0 = level;
			this.int_0 = villageType;
			this.logicDataType_0 = unitProductionType;
			this.logicArrayList_0 = new LogicArrayList<LogicUnitProductionSlot>();
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x000157C4 File Offset: 0x000139C4
		public void Destruct()
		{
			for (int i = this.logicArrayList_0.Size() - 1; i >= 0; i--)
			{
				this.logicArrayList_0[i].Destruct();
				this.logicArrayList_0.Remove(i);
			}
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
			if (this.logicTimer_1 != null)
			{
				this.logicTimer_1.Destruct();
				this.logicTimer_1 = null;
			}
			this.logicLevel_0 = null;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00002718 File Offset: 0x00000918
		public LogicDataType GetUnitProductionType()
		{
			return this.logicDataType_0;
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00002720 File Offset: 0x00000920
		public bool IsLocked()
		{
			return this.bool_0;
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00002728 File Offset: 0x00000928
		public void SetLocked(bool state)
		{
			this.bool_0 = state;
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00002731 File Offset: 0x00000931
		public bool IsBoostPaused()
		{
			return this.bool_1;
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00002739 File Offset: 0x00000939
		public void SetBoostPause(bool state)
		{
			this.bool_1 = state;
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00002742 File Offset: 0x00000942
		public int GetRemainingBoostTimeSecs()
		{
			if (this.logicTimer_1 != null)
			{
				return this.logicTimer_1.GetRemainingSeconds(this.logicLevel_0.GetLogicTime());
			}
			return 0;
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00002764 File Offset: 0x00000964
		public int GetMaxBoostTimeSecs()
		{
			if (this.logicDataType_0 == LogicDataType.SPELL)
			{
				return LogicDataTables.GetGlobals().GetSpellFactoryBoostSecs();
			}
			if (this.logicDataType_0 == LogicDataType.CHARACTER)
			{
				return LogicDataTables.GetGlobals().GetBarracksBoostSecs();
			}
			return 0;
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00002790 File Offset: 0x00000990
		public int GetRemainingSeconds()
		{
			if (this.logicTimer_0 != null)
			{
				return this.logicTimer_0.GetRemainingSeconds(this.logicLevel_0.GetLogicTime());
			}
			return 0;
		}

		// Token: 0x060000BB RID: 187 RVA: 0x000027B2 File Offset: 0x000009B2
		public int GetRemainingMS()
		{
			if (this.logicTimer_0 != null)
			{
				return this.logicTimer_0.GetRemainingMS(this.logicLevel_0.GetLogicTime());
			}
			return 0;
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00015844 File Offset: 0x00013A44
		public int GetTotalSeconds()
		{
			LogicUnitProductionSlot logicUnitProductionSlot = null;
			int i = 0;
			while (i < this.logicArrayList_0.Size())
			{
				LogicUnitProductionSlot logicUnitProductionSlot2 = this.logicArrayList_0[i];
				if (logicUnitProductionSlot2.IsTerminate())
				{
					i++;
				}
				else
				{
					logicUnitProductionSlot = logicUnitProductionSlot2;
					IL_31:
					if (logicUnitProductionSlot != null)
					{
						LogicAvatar homeOwnerAvatar = this.logicLevel_0.GetHomeOwnerAvatar();
						LogicCombatItemData logicCombatItemData = (LogicCombatItemData)logicUnitProductionSlot.GetData();
						return logicCombatItemData.GetTrainingTime(homeOwnerAvatar.GetUnitUpgradeLevel(logicCombatItemData), this.logicLevel_0, 0);
					}
					return 0;
				}
			}
			goto IL_31;
		}

		// Token: 0x060000BD RID: 189 RVA: 0x000158B8 File Offset: 0x00013AB8
		public int GetTotalRemainingSeconds()
		{
			LogicAvatar homeOwnerAvatar = this.logicLevel_0.GetHomeOwnerAvatar();
			int totalMaxHousing = this.logicLevel_0.GetComponentManagerAt(this.int_0).GetTotalMaxHousing((this.logicDataType_0 != LogicDataType.CHARACTER) ? LogicCombatItemType.SPELL : LogicCombatItemType.CHARACTER);
			int num = (this.logicDataType_0 == LogicDataType.CHARACTER) ? homeOwnerAvatar.GetUnitsTotalCapacity() : homeOwnerAvatar.GetSpellsTotalCapacity();
			int num2 = totalMaxHousing - num;
			int num3 = 0;
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				LogicUnitProductionSlot logicUnitProductionSlot = this.logicArrayList_0[i];
				LogicCombatItemData logicCombatItemData = (LogicCombatItemData)logicUnitProductionSlot.GetData();
				int housingSpace = logicCombatItemData.GetHousingSpace();
				int num4 = logicUnitProductionSlot.GetCount();
				if (num4 > 0)
				{
					if (i == 0)
					{
						if (!logicUnitProductionSlot.IsTerminate() && num2 - housingSpace >= 0 && this.logicTimer_0 != null)
						{
							num3 += this.logicTimer_0.GetRemainingSeconds(this.logicLevel_0.GetLogicTime());
						}
						num2 -= housingSpace;
						num4--;
					}
					for (int j = 0; j < num4; j++)
					{
						if (!logicUnitProductionSlot.IsTerminate() && num2 - housingSpace >= 0)
						{
							num3 += logicCombatItemData.GetTrainingTime(homeOwnerAvatar.GetUnitUpgradeLevel(logicCombatItemData), this.logicLevel_0, 0);
						}
						num2 -= housingSpace;
					}
				}
			}
			return num3;
		}

		// Token: 0x060000BE RID: 190 RVA: 0x000027D4 File Offset: 0x000009D4
		public bool IsTutorialCapacityFull()
		{
			return this.logicLevel_0.GetHomeOwnerAvatar().GetUnitsTotalCapacity() + this.GetTotalCount() >= 20;
		}

		// Token: 0x060000BF RID: 191 RVA: 0x000027F4 File Offset: 0x000009F4
		public int GetMaxTrainCount()
		{
			return this.logicLevel_0.GetComponentManagerAt(this.int_0).GetTotalMaxHousing((this.logicDataType_0 != LogicDataType.CHARACTER) ? LogicCombatItemType.SPELL : LogicCombatItemType.CHARACTER) * 2;
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x0000281B File Offset: 0x00000A1B
		public int GetTutorialMax()
		{
			return 20;
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x0000281F File Offset: 0x00000A1F
		public int GetTutorialCount()
		{
			return this.logicLevel_0.GetHomeOwnerAvatar().GetUnitsTotalCapacity() + this.GetTotalCount();
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00002838 File Offset: 0x00000A38
		public int GetSlotCount()
		{
			return this.logicArrayList_0.Size();
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00002845 File Offset: 0x00000A45
		public int GetTrainingCount(int idx)
		{
			return this.logicArrayList_0[idx].GetCount();
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x000159E8 File Offset: 0x00013BE8
		public LogicCombatItemData GetCurrentlyTrainedUnit()
		{
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				if (!this.logicArrayList_0[i].IsTerminate())
				{
					return (LogicCombatItemData)this.logicArrayList_0[i].GetData();
				}
			}
			return null;
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00015A38 File Offset: 0x00013C38
		public int GetCurrentlyTrainedIndex()
		{
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				if (!this.logicArrayList_0[i].IsTerminate())
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00015A74 File Offset: 0x00013C74
		public int GetWaitingForSpaceUnitCount(LogicCombatItemData data)
		{
			int num = 0;
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				LogicUnitProductionSlot logicUnitProductionSlot = this.logicArrayList_0[i];
				if (logicUnitProductionSlot.GetData() == data && logicUnitProductionSlot.IsTerminate())
				{
					num += logicUnitProductionSlot.GetCount();
				}
			}
			return num;
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00015AC4 File Offset: 0x00013CC4
		public LogicUnitProductionSlot GetCurrentlyTrainedSlot()
		{
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				if (!this.logicArrayList_0[i].IsTerminate())
				{
					return this.logicArrayList_0[i];
				}
			}
			return null;
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00015B08 File Offset: 0x00013D08
		public LogicCombatItemData GetWaitingForSpaceUnit()
		{
			if (this.logicArrayList_0.Size() > 0)
			{
				LogicUnitProductionSlot logicUnitProductionSlot = this.logicArrayList_0[0];
				if (logicUnitProductionSlot.IsTerminate() || (this.logicTimer_0 != null && this.logicTimer_0.GetRemainingSeconds(this.logicLevel_0.GetLogicTime()) == 0))
				{
					return (LogicCombatItemData)logicUnitProductionSlot.GetData();
				}
			}
			return null;
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00015B68 File Offset: 0x00013D68
		public int GetBoostMultiplier()
		{
			if (this.logicDataType_0 == LogicDataType.SPELL)
			{
				if (LogicDataTables.GetGlobals().UseNewTraining())
				{
					return LogicDataTables.GetGlobals().GetSpellFactoryBoostNewMultiplier();
				}
				return LogicDataTables.GetGlobals().GetSpellFactoryBoostMultiplier();
			}
			else
			{
				if (this.logicDataType_0 != LogicDataType.CHARACTER)
				{
					return 1;
				}
				if (LogicDataTables.GetGlobals().UseNewTraining())
				{
					return LogicDataTables.GetGlobals().GetBarracksBoostNewMultiplier();
				}
				return LogicDataTables.GetGlobals().GetBarracksBoostMultiplier();
			}
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00015BD0 File Offset: 0x00013DD0
		public bool ProductionCompleted(bool speedUp)
		{
			bool flag = false;
			if (!this.bool_0)
			{
				LogicComponentFilter logicComponentFilter = new LogicComponentFilter();
				logicComponentFilter.SetComponentType(LogicComponentType.UNIT_STORAGE);
				for (;;)
				{
					LogicAvatar homeOwnerAvatar = this.logicLevel_0.GetHomeOwnerAvatar();
					LogicComponentManager componentManagerAt = this.logicLevel_0.GetComponentManagerAt(this.int_0);
					LogicCombatItemData logicCombatItemData = this.GetWaitingForSpaceUnit();
					if (speedUp)
					{
						if (this.logicArrayList_0.Size() <= 0)
						{
							break;
						}
						logicCombatItemData = (LogicCombatItemData)this.logicArrayList_0[0].GetData();
					}
					if (logicCombatItemData == null)
					{
						goto IL_243;
					}
					bool flag2 = this.logicArrayList_0[0].IsTerminate();
					LogicBuildingData productionHouseData = logicCombatItemData.GetProductionHouseData();
					LogicGameObjectManager gameObjectManagerAt = this.logicLevel_0.GetGameObjectManagerAt(this.int_0);
					LogicBuilding logicBuilding = gameObjectManagerAt.GetHighestBuilding(productionHouseData);
					if (LogicDataTables.GetGlobals().UseTroopWalksOutFromTraining())
					{
						int numGameObjects = gameObjectManagerAt.GetNumGameObjects();
						for (int i = 0; i < numGameObjects; i++)
						{
							LogicGameObject gameObjectByIndex = gameObjectManagerAt.GetGameObjectByIndex(i);
							if (gameObjectByIndex.GetGameObjectType() == LogicGameObjectType.BUILDING)
							{
								LogicBuilding logicBuilding2 = (LogicBuilding)gameObjectByIndex;
								LogicUnitProductionComponent unitProductionComponent = logicBuilding2.GetUnitProductionComponent();
								if (unitProductionComponent != null && unitProductionComponent.GetProductionType() == logicCombatItemData.GetCombatItemType() && logicBuilding2.GetBuildingData().GetProducesUnitsOfType() == logicCombatItemData.GetUnitOfType() && !logicBuilding2.IsUpgrading() && !logicBuilding2.IsConstructing() && logicCombatItemData.IsUnlockedForProductionHouseLevel(logicBuilding2.GetUpgradeLevel()))
								{
									if (logicBuilding != null)
									{
										int expPoints = this.logicLevel_0.GetPlayerAvatar().GetExpPoints();
										if (logicBuilding2.Rand(expPoints) % 1000 > 750)
										{
											logicBuilding = logicBuilding2;
										}
									}
									else
									{
										logicBuilding = logicBuilding2;
									}
								}
							}
						}
					}
					if (logicBuilding == null)
					{
						goto IL_272;
					}
					LogicUnitStorageComponent logicUnitStorageComponent = (LogicUnitStorageComponent)componentManagerAt.GetClosestComponent(logicBuilding.GetX(), logicBuilding.GetY(), logicComponentFilter);
					if (logicUnitStorageComponent == null)
					{
						goto IL_24B;
					}
					if (logicUnitStorageComponent.CanAddUnit(logicCombatItemData))
					{
						homeOwnerAvatar.CommodityCountChangeHelper(0, logicCombatItemData, 1);
						logicUnitStorageComponent.AddUnit(logicCombatItemData);
						if (flag2)
						{
							this.RemoveUnit(logicCombatItemData, -1);
						}
						else
						{
							this.StartProducingNextUnit();
						}
						flag = true;
						if (this.logicArrayList_0.Size() <= 0 || !this.logicArrayList_0[0].IsTerminate() || this.logicArrayList_0[0].GetCount() <= 0)
						{
							goto IL_272;
						}
					}
					else
					{
						logicComponentFilter.AddIgnoreObject(logicUnitStorageComponent.GetParent());
					}
				}
				return false;
				IL_243:
				logicComponentFilter.Destruct();
				return false;
				IL_24B:
				if (this.logicTimer_0 != null && this.logicTimer_0.GetRemainingSeconds(this.logicLevel_0.GetLogicTime()) == 0)
				{
					flag = this.TrainingFinished();
				}
				IL_272:
				logicComponentFilter.Destruct();
				if (flag)
				{
					this.int_1 = 0;
				}
				else
				{
					this.int_1 = 2000;
				}
			}
			return flag;
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00015E70 File Offset: 0x00014070
		public void RemoveTrainedUnit(LogicCombatItemData data)
		{
			int num = -1;
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				if (this.logicArrayList_0[i].GetData() == data && this.logicArrayList_0[i].IsTerminate())
				{
					num = i;
					IL_43:
					if (num != -1)
					{
						LogicUnitProductionSlot logicUnitProductionSlot = this.logicArrayList_0[num];
						if (logicUnitProductionSlot.GetCount() > 1)
						{
							logicUnitProductionSlot.SetCount(logicUnitProductionSlot.GetCount() - 1);
						}
						else
						{
							this.logicArrayList_0.Remove(num);
							logicUnitProductionSlot.Destruct();
						}
						this.MergeSlots();
						if (this.GetWaitingForSpaceUnit() != null)
						{
							this.ProductionCompleted(false);
						}
					}
					return;
				}
			}
			goto IL_43;
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00015F14 File Offset: 0x00014114
		public bool RemoveUnit(LogicCombatItemData data, int index)
		{
			bool flag = false;
			LogicUnitProductionSlot logicUnitProductionSlot;
			if (index <= -1 || this.logicArrayList_0.Size() <= index || this.logicArrayList_0[index].GetData() != data)
			{
				index = -1;
				int i = 0;
				while (i < this.logicArrayList_0.Size())
				{
					if (this.logicArrayList_0[i].GetData() == data)
					{
						index = i;
						IL_6D:
						if (index == -1)
						{
							return false;
						}
						logicUnitProductionSlot = this.logicArrayList_0[index];
						goto IL_80;
					}
					else
					{
						i++;
					}
				}
				goto IL_6D;
			}
			logicUnitProductionSlot = this.logicArrayList_0[index];
			IL_80:
			int count = logicUnitProductionSlot.GetCount();
			if (count > 0)
			{
				flag = true;
				logicUnitProductionSlot.SetCount(count - 1);
				if (count == 1)
				{
					if (this.GetCurrentlyTrainedIndex() == index && this.logicTimer_0 != null)
					{
						this.logicTimer_0.Destruct();
						this.logicTimer_0 = null;
					}
					this.logicArrayList_0[index].Destruct();
					this.logicArrayList_0.Remove(index);
				}
			}
			if (this.logicArrayList_0.Size() > 0)
			{
				LogicUnitProductionSlot currentlyTrainedSlot = this.GetCurrentlyTrainedSlot();
				if (currentlyTrainedSlot != null && this.logicTimer_0 == null)
				{
					LogicAvatar homeOwnerAvatar = this.logicLevel_0.GetHomeOwnerAvatar();
					LogicCombatItemData logicCombatItemData = (LogicCombatItemData)currentlyTrainedSlot.GetData();
					this.logicTimer_0 = new LogicTimer();
					this.logicTimer_0.StartTimer(logicCombatItemData.GetTrainingTime(homeOwnerAvatar.GetUnitUpgradeLevel(logicCombatItemData), this.logicLevel_0, 0), this.logicLevel_0.GetLogicTime(), false, -1);
					if (flag)
					{
						this.MergeSlots();
					}
				}
				else
				{
					if (!flag)
					{
						return false;
					}
					this.MergeSlots();
				}
			}
			else
			{
				if (!flag)
				{
					return false;
				}
				this.MergeSlots();
			}
			return true;
		}

		// Token: 0x060000CD RID: 205 RVA: 0x0001609C File Offset: 0x0001429C
		public void SpeedUp()
		{
			LogicAvatar homeOwnerAvatar = this.logicLevel_0.GetHomeOwnerAvatar();
			int totalMaxHousing = this.logicLevel_0.GetComponentManagerAt(this.int_0).GetTotalMaxHousing((this.logicDataType_0 != LogicDataType.CHARACTER) ? LogicCombatItemType.SPELL : LogicCombatItemType.CHARACTER);
			int num = (this.logicDataType_0 == LogicDataType.CHARACTER) ? homeOwnerAvatar.GetUnitsTotalCapacity() : homeOwnerAvatar.GetSpellsTotalCapacity();
			int num2 = totalMaxHousing - num;
			bool flag = false;
			while (!flag && this.logicArrayList_0.Size() > 0)
			{
				LogicUnitProductionSlot logicUnitProductionSlot = this.logicArrayList_0[0];
				LogicCombatItemData logicCombatItemData = (LogicCombatItemData)logicUnitProductionSlot.GetData();
				int num3 = logicUnitProductionSlot.GetCount();
				if (num3 <= 0)
				{
					break;
				}
				flag = true;
				do
				{
					num2 -= logicCombatItemData.GetHousingSpace();
					if (num2 >= 0)
					{
						this.ProductionCompleted(true);
						flag = false;
					}
				}
				while (--num3 > 0);
			}
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00002858 File Offset: 0x00000A58
		public LogicUnitProductionSlot GetUnit(int index)
		{
			if (index > -1 && this.logicArrayList_0.Size() > index)
			{
				return this.logicArrayList_0[index];
			}
			return null;
		}

		// Token: 0x060000CF RID: 207 RVA: 0x0001615C File Offset: 0x0001435C
		public void MergeSlots()
		{
			LogicAvatar homeOwnerAvatar = this.logicLevel_0.GetHomeOwnerAvatar();
			if (this.logicArrayList_0.Size() > 0 && this.logicArrayList_0.Size() > 1)
			{
				for (int i = 1; i < this.logicArrayList_0.Size(); i++)
				{
					LogicUnitProductionSlot logicUnitProductionSlot = this.logicArrayList_0[i];
					LogicUnitProductionSlot logicUnitProductionSlot2 = this.logicArrayList_0[i - 1];
					if (logicUnitProductionSlot.GetData() == logicUnitProductionSlot2.GetData() && logicUnitProductionSlot.IsTerminate() == logicUnitProductionSlot2.IsTerminate())
					{
						this.logicArrayList_0.Remove(i--);
						logicUnitProductionSlot2.SetCount(logicUnitProductionSlot2.GetCount() + logicUnitProductionSlot.GetCount());
						logicUnitProductionSlot.Destruct();
					}
				}
			}
			LogicComponentManager componentManagerAt = this.logicLevel_0.GetComponentManagerAt(this.int_0);
			int num = (this.logicDataType_0 == LogicDataType.SPELL) ? homeOwnerAvatar.GetSpellsTotalCapacity() : homeOwnerAvatar.GetUnitsTotalCapacity();
			int num2 = componentManagerAt.GetTotalMaxHousing((this.logicDataType_0 != LogicDataType.CHARACTER) ? LogicCombatItemType.SPELL : LogicCombatItemType.CHARACTER) - num;
			int j = 0;
			int num3 = num2;
			while (j < this.logicArrayList_0.Size())
			{
				LogicUnitProductionSlot logicUnitProductionSlot3 = this.logicArrayList_0[j];
				LogicCombatItemData logicCombatItemData = (LogicCombatItemData)logicUnitProductionSlot3.GetData();
				int count = logicUnitProductionSlot3.GetCount();
				int num4 = logicCombatItemData.GetHousingSpace() * count;
				if (num3 < num4)
				{
					if (count > 1)
					{
						int num5 = num3 / logicCombatItemData.GetHousingSpace();
						if (num5 > 0)
						{
							int num6 = count - num5;
							if (num6 > 0)
							{
								logicUnitProductionSlot3.SetCount(num5);
								this.logicArrayList_0.Add(j + 1, new LogicUnitProductionSlot(logicCombatItemData, num6, logicUnitProductionSlot3.IsTerminate()));
								return;
							}
						}
					}
					return;
				}
				num3 -= num4;
				j++;
			}
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x000162F8 File Offset: 0x000144F8
		public void StartProducingNextUnit()
		{
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
			if (this.logicArrayList_0.Size() > 0)
			{
				LogicCombatItemData currentlyTrainedUnit = this.GetCurrentlyTrainedUnit();
				if (currentlyTrainedUnit != null)
				{
					this.RemoveUnit(currentlyTrainedUnit, -1);
				}
			}
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00016340 File Offset: 0x00014540
		public bool TrainingFinished()
		{
			bool result = false;
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
			if (this.logicArrayList_0.Size() > 0)
			{
				LogicUnitProductionSlot currentlyTrainedSlot = this.GetCurrentlyTrainedSlot();
				int currentlyTrainedIndex = this.GetCurrentlyTrainedIndex();
				if (currentlyTrainedSlot != null)
				{
					if (currentlyTrainedSlot.GetCount() == 1)
					{
						currentlyTrainedSlot.SetTerminate(true);
					}
					else
					{
						currentlyTrainedSlot.SetCount(currentlyTrainedSlot.GetCount() - 1);
						LogicUnitProductionSlot logicUnitProductionSlot = this.logicArrayList_0[LogicMath.Max(currentlyTrainedIndex - 1, 0)];
						if (logicUnitProductionSlot != null && logicUnitProductionSlot.IsTerminate() && logicUnitProductionSlot.GetData().GetGlobalID() == currentlyTrainedSlot.GetData().GetGlobalID())
						{
							logicUnitProductionSlot.SetCount(logicUnitProductionSlot.GetCount() + 1);
						}
						else
						{
							this.logicArrayList_0.Add(currentlyTrainedIndex, new LogicUnitProductionSlot(currentlyTrainedSlot.GetData(), 1, true));
						}
					}
				}
				if (this.logicArrayList_0.Size() > 0)
				{
					LogicCombatItemData currentlyTrainedUnit = this.GetCurrentlyTrainedUnit();
					if (currentlyTrainedUnit != null && this.logicTimer_0 == null)
					{
						this.logicTimer_0 = new LogicTimer();
						this.logicTimer_0.StartTimer(currentlyTrainedUnit.GetTrainingTime(this.logicLevel_0.GetHomeOwnerAvatar().GetUnitUpgradeLevel(currentlyTrainedUnit), this.logicLevel_0, 0), this.logicLevel_0.GetLogicTime(), false, -1);
						result = true;
					}
				}
			}
			this.MergeSlots();
			return result;
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00016480 File Offset: 0x00014680
		public bool DragSlot(int slotIdx, int dragIdx)
		{
			this.bool_0 = false;
			if (slotIdx > -1 && slotIdx < this.logicArrayList_0.Size())
			{
				LogicCombatItemData currentlyTrainedUnit = this.GetCurrentlyTrainedUnit();
				LogicUnitProductionSlot logicUnitProductionSlot = this.logicArrayList_0[slotIdx];
				this.logicArrayList_0.Remove(slotIdx);
				if (logicUnitProductionSlot != null)
				{
					if (slotIdx <= dragIdx)
					{
						dragIdx--;
					}
					if (dragIdx >= 0 && dragIdx <= this.logicArrayList_0.Size())
					{
						this.logicArrayList_0.Add(dragIdx, logicUnitProductionSlot);
						this.MergeSlots();
						LogicCombatItemData currentlyTrainedUnit2 = this.GetCurrentlyTrainedUnit();
						int currentlyTrainedIndex = this.GetCurrentlyTrainedIndex();
						if (currentlyTrainedUnit != currentlyTrainedUnit2 && (dragIdx >= currentlyTrainedIndex || currentlyTrainedIndex == slotIdx || currentlyTrainedIndex == dragIdx + 1))
						{
							if (this.logicTimer_0 != null)
							{
								this.logicTimer_0.Destruct();
								this.logicTimer_0 = null;
							}
							LogicAvatar homeOwnerAvatar = this.logicLevel_0.GetHomeOwnerAvatar();
							this.logicTimer_0 = new LogicTimer();
							this.logicTimer_0.StartTimer(currentlyTrainedUnit2.GetTrainingTime(homeOwnerAvatar.GetUnitUpgradeLevel(currentlyTrainedUnit2), this.logicLevel_0, 0), this.logicLevel_0.GetLogicTime(), false, -1);
						}
					}
					return true;
				}
			}
			return false;
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00016588 File Offset: 0x00014788
		public int AddUnitToQueue(LogicCombatItemData data)
		{
			if (data != null)
			{
				if (this.CanAddUnitToQueue(data, false))
				{
					LogicAvatar homeOwnerAvatar = this.logicLevel_0.GetHomeOwnerAvatar();
					int i = this.logicArrayList_0.Size() - 1;
					while (i >= 0)
					{
						LogicUnitProductionSlot logicUnitProductionSlot = this.logicArrayList_0[i];
						if (logicUnitProductionSlot == null)
						{
							i--;
						}
						else
						{
							if (logicUnitProductionSlot.GetData() == data)
							{
								logicUnitProductionSlot.SetCount(logicUnitProductionSlot.GetCount() + 1);
								this.MergeSlots();
								return i;
							}
							IL_68:
							this.logicArrayList_0.Add(new LogicUnitProductionSlot(data, 1, false));
							this.MergeSlots();
							if (this.logicArrayList_0.Size() <= 0)
							{
								return -1;
							}
							LogicCombatItemData currentlyTrainedUnit = this.GetCurrentlyTrainedUnit();
							if (currentlyTrainedUnit != null && this.logicTimer_0 == null)
							{
								this.logicTimer_0 = new LogicTimer();
								this.logicTimer_0.StartTimer(currentlyTrainedUnit.GetTrainingTime(homeOwnerAvatar.GetUnitUpgradeLevel(currentlyTrainedUnit), this.logicLevel_0, 0), this.logicLevel_0.GetLogicTime(), false, -1);
								return -1;
							}
							return -1;
						}
					}
					goto IL_68;
				}
			}
			else
			{
				Debugger.Error("LogicUnitProduction - Trying to add NULL character!");
			}
			return -1;
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x0001667C File Offset: 0x0001487C
		public int AddUnitToQueue(LogicCombatItemData data, int index, bool ignoreCapacity)
		{
			if (data != null)
			{
				if (this.CanAddUnitToQueue(data, ignoreCapacity))
				{
					LogicAvatar homeOwnerAvatar = this.logicLevel_0.GetHomeOwnerAvatar();
					LogicCombatItemData currentlyTrainedUnit = this.GetCurrentlyTrainedUnit();
					this.logicArrayList_0.Add(index, new LogicUnitProductionSlot(data, 1, false));
					this.MergeSlots();
					if (currentlyTrainedUnit != null)
					{
						if (this.GetCurrentlyTrainedUnit() == data || this.GetCurrentlyTrainedIndex() != index)
						{
							return index;
						}
					}
					else
					{
						currentlyTrainedUnit = this.GetCurrentlyTrainedUnit();
					}
					if (this.logicTimer_0 != null)
					{
						this.logicTimer_0.Destruct();
						this.logicTimer_0 = null;
					}
					this.logicTimer_0 = new LogicTimer();
					this.logicTimer_0.StartTimer(currentlyTrainedUnit.GetTrainingTime(homeOwnerAvatar.GetUnitUpgradeLevel(currentlyTrainedUnit), this.logicLevel_0, 0), this.logicLevel_0.GetLogicTime(), false, -1);
					return index;
				}
			}
			else
			{
				Debugger.Error("LogicUnitProduction - Trying to add NULL character!");
			}
			return -1;
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00016748 File Offset: 0x00014948
		public bool CanAddUnitToQueue(LogicCombatItemData data, bool ignoreCapacity)
		{
			if (data != null)
			{
				if (data.GetDataType() == this.logicDataType_0)
				{
					LogicBuilding highestBuilding = this.logicLevel_0.GetGameObjectManagerAt(0).GetHighestBuilding(data.GetProductionHouseData());
					if (highestBuilding != null)
					{
						if (!data.IsUnlockedForProductionHouseLevel(highestBuilding.GetUpgradeLevel()))
						{
							return false;
						}
						if (data.GetUnitOfType() != highestBuilding.GetBuildingData().GetProducesUnitsOfType())
						{
							return false;
						}
					}
					if (this.logicLevel_0.GetMissionManager().IsTutorialFinished() || this.logicLevel_0.GetHomeOwnerAvatar().GetUnitsTotalCapacity() + this.GetTotalCount() < 20)
					{
						if (ignoreCapacity)
						{
							return true;
						}
						LogicAvatar homeOwnerAvatar = this.logicLevel_0.GetHomeOwnerAvatar();
						int num = this.logicLevel_0.GetComponentManagerAt(this.int_0).GetTotalMaxHousing((this.logicDataType_0 != LogicDataType.CHARACTER) ? LogicCombatItemType.SPELL : LogicCombatItemType.CHARACTER) * 2;
						int num2 = this.GetTotalCount() + data.GetHousingSpace() + ((this.logicDataType_0 == LogicDataType.CHARACTER) ? homeOwnerAvatar.GetUnitsTotalCapacity() : homeOwnerAvatar.GetSpellsTotalCapacity());
						return num >= num2;
					}
				}
				else
				{
					Debugger.Error("Trying to add wrong unit type to UnitProduction");
				}
			}
			else
			{
				Debugger.Error("Trying to add NULL troop to UnitProduction");
			}
			return false;
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x0000287A File Offset: 0x00000A7A
		public bool CanBeBoosted()
		{
			return !this.bool_1 && this.GetBoostMultiplier() > 0 && this.GetBoostCost() > 0;
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00002898 File Offset: 0x00000A98
		public int GetBoostCost()
		{
			if (this.logicDataType_0 == LogicDataType.CHARACTER)
			{
				return this.logicLevel_0.GetGameMode().GetCalendar().GetUnitProductionBoostCost();
			}
			return this.logicLevel_0.GetGameMode().GetCalendar().GetSpellProductionBoostCost();
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00016854 File Offset: 0x00014A54
		public void Boost()
		{
			if (this.logicTimer_1 != null)
			{
				this.logicTimer_1.Destruct();
				this.logicTimer_1 = null;
			}
			this.logicTimer_1 = new LogicTimer();
			this.logicTimer_1.StartTimer(this.GetMaxBoostTimeSecs(), this.logicLevel_0.GetLogicTime(), false, -1);
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x000028CE File Offset: 0x00000ACE
		public void StopBoost()
		{
			if (this.logicTimer_1 != null && !this.bool_1)
			{
				this.bool_1 = true;
			}
		}

		// Token: 0x060000DA RID: 218 RVA: 0x000168A4 File Offset: 0x00014AA4
		public int GetTotalCount()
		{
			int num = 0;
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				LogicUnitProductionSlot logicUnitProductionSlot = this.logicArrayList_0[i];
				LogicCombatItemData logicCombatItemData = (LogicCombatItemData)logicUnitProductionSlot.GetData();
				num += logicCombatItemData.GetHousingSpace() * logicUnitProductionSlot.GetCount();
			}
			return num;
		}

		// Token: 0x060000DB RID: 219 RVA: 0x000028E7 File Offset: 0x00000AE7
		public void SubTick()
		{
			if (this.logicTimer_1 != null && this.bool_1)
			{
				this.logicTimer_1.StartTimer(this.logicTimer_1.GetRemainingSeconds(this.logicLevel_0.GetLogicTime()), this.logicLevel_0.GetLogicTime(), false, -1);
			}
		}

		// Token: 0x060000DC RID: 220 RVA: 0x000168F4 File Offset: 0x00014AF4
		public void Tick()
		{
			if (this.GetRemainingBoostTimeSecs() > 0 && this.logicTimer_0 != null && !this.IsBoostPaused())
			{
				this.logicTimer_0.FastForwardSubticks(4 * this.GetBoostMultiplier() - 4);
			}
			bool flag = false;
			if (this.logicTimer_0 != null)
			{
				flag = (this.logicTimer_0.GetRemainingSeconds(this.logicLevel_0.GetLogicTime()) == 0);
			}
			if (this.int_1 > 0)
			{
				this.int_1 = (flag ? 0 : LogicMath.Max(this.int_1 - 64, 0));
			}
			if (this.logicTimer_1 != null && this.logicTimer_1.GetRemainingSeconds(this.logicLevel_0.GetLogicTime()) <= 0)
			{
				this.logicTimer_1.Destruct();
				this.logicTimer_1 = null;
			}
			if ((flag || this.GetWaitingForSpaceUnit() != null) && this.int_1 == 0)
			{
				this.ProductionCompleted(false);
			}
		}

		// Token: 0x060000DD RID: 221 RVA: 0x000169C8 File Offset: 0x00014BC8
		public void FastForwardTime(int secs)
		{
			if (this.logicTimer_1 != null && !this.bool_1)
			{
				int remainingSeconds = this.logicTimer_1.GetRemainingSeconds(this.logicLevel_0.GetLogicTime());
				if (remainingSeconds <= secs)
				{
					this.logicTimer_1.Destruct();
					this.logicTimer_1 = null;
				}
				else
				{
					this.logicTimer_1.StartTimer(remainingSeconds - secs, this.logicLevel_0.GetLogicTime(), false, -1);
				}
			}
			if (this.GetRemainingBoostTimeSecs() > 0)
			{
				if (this.GetBoostMultiplier() >= 2 && !this.IsBoostPaused())
				{
					secs = LogicMath.Min(secs, this.GetRemainingBoostTimeSecs()) * (this.GetBoostMultiplier() - 1) + secs;
				}
				if (this.logicTimer_0 != null && !this.IsBoostPaused())
				{
					this.logicTimer_0.FastForwardSubticks(4 * this.GetBoostMultiplier() - 4);
				}
			}
			while (secs > 0)
			{
				LogicUnitProductionSlot currentlyTrainedSlot = this.GetCurrentlyTrainedSlot();
				if (currentlyTrainedSlot == null)
				{
					break;
				}
				if (this.logicTimer_0 == null)
				{
					LogicCombatItemData logicCombatItemData = (LogicCombatItemData)currentlyTrainedSlot.GetData();
					this.logicTimer_0 = new LogicTimer();
					this.logicTimer_0.StartTimer(logicCombatItemData.GetTrainingTime(this.logicLevel_0.GetHomeOwnerAvatar().GetUnitUpgradeLevel(logicCombatItemData), this.logicLevel_0, 0), this.logicLevel_0.GetLogicTime(), false, -1);
				}
				int remainingSeconds2 = this.logicTimer_0.GetRemainingSeconds(this.logicLevel_0.GetLogicTime());
				if (secs < remainingSeconds2)
				{
					this.logicTimer_0.StartTimer(remainingSeconds2 - secs, this.logicLevel_0.GetLogicTime(), false, -1);
					return;
				}
				secs -= remainingSeconds2;
				this.logicTimer_0.StartTimer(0, this.logicLevel_0.GetLogicTime(), false, -1);
				if (!this.ProductionCompleted(false))
				{
					break;
				}
			}
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00002927 File Offset: 0x00000B27
		public void LoadingFinished()
		{
			if (this.GetWaitingForSpaceUnit() != null)
			{
				this.ProductionCompleted(false);
			}
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00002927 File Offset: 0x00000B27
		public void UnitRemoved()
		{
			if (this.GetWaitingForSpaceUnit() != null)
			{
				this.ProductionCompleted(false);
			}
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00016B60 File Offset: 0x00014D60
		public void Load(LogicJSONObject root)
		{
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
			if (this.logicTimer_1 != null)
			{
				this.logicTimer_1.Destruct();
				this.logicTimer_1 = null;
			}
			for (int i = this.logicArrayList_0.Size() - 1; i >= 0; i--)
			{
				this.logicArrayList_0[i].Destruct();
				this.logicArrayList_0.Remove(i);
			}
			LogicJSONObject jsonobject = root.GetJSONObject("unit_prod");
			if (jsonobject != null)
			{
				LogicJSONArray jsonarray = jsonobject.GetJSONArray("slots");
				if (jsonarray != null)
				{
					for (int j = 0; j < jsonarray.Size(); j++)
					{
						LogicJSONObject jsonobject2 = jsonarray.GetJSONObject(j);
						if (jsonobject2 != null)
						{
							LogicJSONNumber jsonnumber = jsonobject2.GetJSONNumber("id");
							if (jsonnumber != null)
							{
								LogicData dataById = LogicDataTables.GetDataById(jsonnumber.GetIntValue());
								if (dataById != null)
								{
									LogicJSONNumber jsonnumber2 = jsonobject2.GetJSONNumber("cnt");
									LogicJSONBoolean jsonboolean = jsonobject2.GetJSONBoolean("t");
									if (jsonnumber2 != null && jsonnumber2.GetIntValue() > 0)
									{
										LogicUnitProductionSlot logicUnitProductionSlot = new LogicUnitProductionSlot(dataById, jsonnumber2.GetIntValue(), false);
										if (jsonboolean != null)
										{
											logicUnitProductionSlot.SetTerminate(jsonboolean.IsTrue());
										}
										this.logicArrayList_0.Add(logicUnitProductionSlot);
									}
								}
							}
						}
					}
				}
				if (this.logicArrayList_0.Size() > 0)
				{
					LogicUnitProductionSlot currentlyTrainedSlot = this.GetCurrentlyTrainedSlot();
					if (currentlyTrainedSlot != null)
					{
						LogicJSONNumber jsonnumber3 = jsonobject.GetJSONNumber("t");
						if (jsonnumber3 != null)
						{
							this.logicTimer_0 = new LogicTimer();
							this.logicTimer_0.StartTimer(jsonnumber3.GetIntValue(), this.logicLevel_0.GetLogicTime(), false, -1);
						}
						else
						{
							LogicCombatItemData logicCombatItemData = (LogicCombatItemData)currentlyTrainedSlot.GetData();
							LogicAvatar homeOwnerAvatar = this.logicLevel_0.GetHomeOwnerAvatar();
							int index = 0;
							if (homeOwnerAvatar != null)
							{
								index = homeOwnerAvatar.GetUnitUpgradeLevel(logicCombatItemData);
							}
							this.logicTimer_0 = new LogicTimer();
							this.logicTimer_0.StartTimer(logicCombatItemData.GetTrainingTime(index, this.logicLevel_0, 0), this.logicLevel_0.GetLogicTime(), false, -1);
						}
					}
				}
				LogicJSONNumber jsonnumber4 = jsonobject.GetJSONNumber("boost_t");
				if (jsonnumber4 != null)
				{
					this.logicTimer_1 = new LogicTimer();
					this.logicTimer_1.StartTimer(jsonnumber4.GetIntValue(), this.logicLevel_0.GetLogicTime(), false, -1);
				}
				LogicJSONBoolean jsonboolean2 = jsonobject.GetJSONBoolean("boost_pause");
				if (jsonboolean2 != null)
				{
					this.bool_1 = jsonboolean2.IsTrue();
					return;
				}
			}
			else
			{
				Debugger.Warning("LogicUnitProduction::load - Component wasn't found from the JSON");
			}
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00016DC0 File Offset: 0x00014FC0
		public void Save(LogicJSONObject root)
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			if (this.logicTimer_0 != null)
			{
				logicJSONObject.Put("t", new LogicJSONNumber(this.logicTimer_0.GetRemainingSeconds(this.logicLevel_0.GetLogicTime())));
			}
			if (this.logicArrayList_0.Size() > 0)
			{
				LogicJSONArray logicJSONArray = new LogicJSONArray();
				for (int i = 0; i < this.logicArrayList_0.Size(); i++)
				{
					LogicUnitProductionSlot logicUnitProductionSlot = this.logicArrayList_0[i];
					if (logicUnitProductionSlot != null)
					{
						LogicJSONObject logicJSONObject2 = new LogicJSONObject();
						logicJSONObject2.Put("id", new LogicJSONNumber(logicUnitProductionSlot.GetData().GetGlobalID()));
						logicJSONObject2.Put("cnt", new LogicJSONNumber(logicUnitProductionSlot.GetCount()));
						if (logicUnitProductionSlot.IsTerminate())
						{
							logicJSONObject2.Put("t", new LogicJSONBoolean(true));
						}
						logicJSONArray.Add(logicJSONObject2);
					}
				}
				logicJSONObject.Put("slots", logicJSONArray);
			}
			if (this.logicTimer_1 != null)
			{
				logicJSONObject.Put("boost_t", new LogicJSONNumber(this.logicTimer_1.GetRemainingSeconds(this.logicLevel_0.GetLogicTime())));
			}
			if (this.bool_1)
			{
				logicJSONObject.Put("boost_pause", new LogicJSONBoolean(true));
			}
			root.Put("unit_prod", logicJSONObject);
		}

		// Token: 0x04000060 RID: 96
		public const int TUTORIAL_MAX_CAPACITY = 20;

		// Token: 0x04000061 RID: 97
		private LogicLevel logicLevel_0;

		// Token: 0x04000062 RID: 98
		private LogicTimer logicTimer_0;

		// Token: 0x04000063 RID: 99
		private LogicTimer logicTimer_1;

		// Token: 0x04000064 RID: 100
		private readonly LogicArrayList<LogicUnitProductionSlot> logicArrayList_0;

		// Token: 0x04000065 RID: 101
		private readonly int int_0;

		// Token: 0x04000066 RID: 102
		private readonly LogicDataType logicDataType_0;

		// Token: 0x04000067 RID: 103
		private int int_1;

		// Token: 0x04000068 RID: 104
		private bool bool_0;

		// Token: 0x04000069 RID: 105
		private bool bool_1;
	}
}
