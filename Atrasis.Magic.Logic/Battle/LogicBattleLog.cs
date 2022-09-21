using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Battle
{
	// Token: 0x020001FC RID: 508
	public class LogicBattleLog
	{
		// Token: 0x060019D8 RID: 6616 RVA: 0x00061D60 File Offset: 0x0005FF60
		public LogicBattleLog(LogicLevel level)
		{
			this.logicLevel_0 = level;
			this.logicLong_0 = new LogicLong();
			this.logicLong_1 = new LogicLong();
			this.logicArrayList_6 = new LogicArrayList<LogicDataSlot>();
			this.logicArrayList_0 = new LogicArrayList<LogicDataSlot>();
			this.logicArrayList_1 = new LogicArrayList<LogicDataSlot>();
			this.logicArrayList_5 = new LogicArrayList<LogicDataSlot>();
			this.logicArrayList_2 = new LogicArrayList<LogicDataSlot>();
			this.logicArrayList_3 = new LogicArrayList<LogicDataSlot>();
			this.logicArrayList_4 = new LogicArrayList<LogicUnitSlot>();
		}

		// Token: 0x060019D9 RID: 6617 RVA: 0x00061DE0 File Offset: 0x0005FFE0
		public void Destruct()
		{
			this.logicLevel_0 = null;
			this.string_0 = null;
			this.string_1 = null;
			this.string_2 = null;
			this.string_3 = null;
			this.logicLong_0 = null;
			this.logicLong_1 = null;
			this.logicLong_2 = null;
			this.logicLong_3 = null;
		}

		// Token: 0x060019DA RID: 6618 RVA: 0x0001129F File Offset: 0x0000F49F
		public int GetVillageType()
		{
			return this.int_1;
		}

		// Token: 0x060019DB RID: 6619 RVA: 0x000112A7 File Offset: 0x0000F4A7
		public void SetVillageType(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x060019DC RID: 6620 RVA: 0x000112B0 File Offset: 0x0000F4B0
		public int GetStars()
		{
			return ((this.int_6 >= 50) ? 1 : 0) + ((this.int_6 == 100) ? 1 : 0) + (this.bool_1 ? 1 : 0);
		}

		// Token: 0x060019DD RID: 6621 RVA: 0x000112DC File Offset: 0x0000F4DC
		public bool GetTownHallDestroyed()
		{
			return this.bool_1;
		}

		// Token: 0x060019DE RID: 6622 RVA: 0x000112E4 File Offset: 0x0000F4E4
		public void SetTownHallDestroyed(bool destroyed)
		{
			this.bool_1 = destroyed;
		}

		// Token: 0x060019DF RID: 6623 RVA: 0x00061E2C File Offset: 0x0006002C
		public int GetStolenResources(LogicResourceData data)
		{
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				if (this.logicArrayList_0[i].GetData() == data)
				{
					return this.logicArrayList_0[i].GetCount();
				}
			}
			return 0;
		}

		// Token: 0x060019E0 RID: 6624 RVA: 0x00061E78 File Offset: 0x00060078
		public void IncreaseStolenResourceCount(LogicResourceData data, int count)
		{
			if (this.logicLevel_0 != null)
			{
				this.logicLevel_0.GetAchievementManager().IncreaseLoot(data, count);
			}
			int num = -1;
			int i = 0;
			while (i < this.logicArrayList_0.Size())
			{
				if (this.logicArrayList_0[i].GetData() == data)
				{
					num = i;
					IL_4C:
					if (num != -1)
					{
						this.logicArrayList_0[num].SetCount(this.logicArrayList_0[num].GetCount() + count);
						return;
					}
					this.logicArrayList_0.Add(new LogicDataSlot(data, count));
					return;
				}
				else
				{
					i++;
				}
			}
			goto IL_4C;
		}

		// Token: 0x060019E1 RID: 6625 RVA: 0x000112ED File Offset: 0x0000F4ED
		public LogicArrayList<LogicDataSlot> GetCastedSpells()
		{
			return this.logicArrayList_2;
		}

		// Token: 0x060019E2 RID: 6626 RVA: 0x000112F5 File Offset: 0x0000F4F5
		public LogicArrayList<LogicDataSlot> GetCastedUnits()
		{
			return this.logicArrayList_3;
		}

		// Token: 0x060019E3 RID: 6627 RVA: 0x000112FD File Offset: 0x0000F4FD
		public LogicArrayList<LogicUnitSlot> GetCastedAllianceUnits()
		{
			return this.logicArrayList_4;
		}

		// Token: 0x060019E4 RID: 6628 RVA: 0x00061F0C File Offset: 0x0006010C
		public int GetCostCount(LogicData data)
		{
			for (int i = 0; i < this.logicArrayList_6.Size(); i++)
			{
				if (this.logicArrayList_6[i].GetData() == data)
				{
					return this.logicArrayList_6[i].GetCount();
				}
			}
			return 0;
		}

		// Token: 0x060019E5 RID: 6629 RVA: 0x00061F58 File Offset: 0x00060158
		public bool GetBattleStarted()
		{
			if (!this.bool_0)
			{
				int matchType = this.logicLevel_0.GetMatchType();
				return (matchType < 10 && (matchType == 3 || matchType == 7 || matchType == 8 || matchType == 9)) || this.logicArrayList_3.Size() + this.logicArrayList_2.Size() + this.logicArrayList_4.Size() > 0;
			}
			return true;
		}

		// Token: 0x060019E6 RID: 6630 RVA: 0x00011305 File Offset: 0x0000F505
		public bool HasDeployedUnits()
		{
			return this.logicArrayList_3.Size() + this.logicArrayList_2.Size() + this.logicArrayList_4.Size() > 0;
		}

		// Token: 0x060019E7 RID: 6631 RVA: 0x0001132D File Offset: 0x0000F52D
		public bool GetBattleEnded()
		{
			return this.bool_0;
		}

		// Token: 0x060019E8 RID: 6632 RVA: 0x00011335 File Offset: 0x0000F535
		public void SetBattleEnded(int battleTime)
		{
			this.int_0 = battleTime;
			this.bool_0 = true;
		}

		// Token: 0x060019E9 RID: 6633 RVA: 0x00011345 File Offset: 0x0000F545
		public void SetAttackerHomeId(LogicLong homeId)
		{
			this.logicLong_0 = homeId;
		}

		// Token: 0x060019EA RID: 6634 RVA: 0x0001134E File Offset: 0x0000F54E
		public LogicLong GetDefenderHomeId()
		{
			return this.logicLong_1;
		}

		// Token: 0x060019EB RID: 6635 RVA: 0x00011356 File Offset: 0x0000F556
		public void SetDefenderHomeId(LogicLong homeId)
		{
			this.logicLong_1 = homeId;
		}

		// Token: 0x060019EC RID: 6636 RVA: 0x0001135F File Offset: 0x0000F55F
		public void SetAttackerAllianceId(LogicLong allianceId)
		{
			this.logicLong_2 = allianceId;
		}

		// Token: 0x060019ED RID: 6637 RVA: 0x00011368 File Offset: 0x0000F568
		public void SetDefenderAllianceId(LogicLong allianceId)
		{
			this.logicLong_3 = allianceId;
		}

		// Token: 0x060019EE RID: 6638 RVA: 0x00011371 File Offset: 0x0000F571
		public void SetAttackerAllianceBadge(int badgeId)
		{
			this.int_9 = badgeId;
		}

		// Token: 0x060019EF RID: 6639 RVA: 0x0001137A File Offset: 0x0000F57A
		public void SetDefenderAllianceBadge(int badgeId)
		{
			this.int_10 = badgeId;
		}

		// Token: 0x060019F0 RID: 6640 RVA: 0x00011383 File Offset: 0x0000F583
		public void SetAttackerAllianceLevel(int level)
		{
			this.int_13 = level;
		}

		// Token: 0x060019F1 RID: 6641 RVA: 0x0001138C File Offset: 0x0000F58C
		public void SetDefenderAllianceLevel(int level)
		{
			this.int_14 = level;
		}

		// Token: 0x060019F2 RID: 6642 RVA: 0x00011395 File Offset: 0x0000F595
		public void SetAttackerAllianceName(string name)
		{
			this.string_0 = name;
		}

		// Token: 0x060019F3 RID: 6643 RVA: 0x0001139E File Offset: 0x0000F59E
		public void SetDefenderAllianceName(string name)
		{
			this.string_1 = name;
		}

		// Token: 0x060019F4 RID: 6644 RVA: 0x000113A7 File Offset: 0x0000F5A7
		public void SetAttackerStars(int star)
		{
			this.int_2 = star;
		}

		// Token: 0x060019F5 RID: 6645 RVA: 0x000113B0 File Offset: 0x0000F5B0
		public void SetAttackerScore(int count)
		{
			this.int_3 = count;
		}

		// Token: 0x060019F6 RID: 6646 RVA: 0x000113B9 File Offset: 0x0000F5B9
		public void SetDefenderScore(int count)
		{
			this.int_4 = count;
		}

		// Token: 0x060019F7 RID: 6647 RVA: 0x000113C2 File Offset: 0x0000F5C2
		public void SetOriginalAttackerScore(int count)
		{
			this.int_7 = count;
		}

		// Token: 0x060019F8 RID: 6648 RVA: 0x000113CB File Offset: 0x0000F5CB
		public void SetOriginalDefenderScore(int count)
		{
			this.int_8 = count;
		}

		// Token: 0x060019F9 RID: 6649 RVA: 0x000113D4 File Offset: 0x0000F5D4
		public void SetAttackerName(string name)
		{
			this.string_2 = name;
		}

		// Token: 0x060019FA RID: 6650 RVA: 0x000113DD File Offset: 0x0000F5DD
		public void SetDefenderName(string name)
		{
			this.string_3 = name;
		}

		// Token: 0x060019FB RID: 6651 RVA: 0x000113E6 File Offset: 0x0000F5E6
		public void SetAllianceUsed(bool used)
		{
			this.bool_2 = used;
		}

		// Token: 0x060019FC RID: 6652 RVA: 0x00061FBC File Offset: 0x000601BC
		public void CalculateAvailableResources(LogicLevel level, int matchType)
		{
			for (int i = this.logicArrayList_1.Size() - 1; i >= 0; i--)
			{
				this.logicArrayList_1[i].Destruct();
				this.logicArrayList_1.Remove(i);
			}
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.RESOURCE);
			int j = 0;
			while (j < table.GetItemCount())
			{
				LogicResourceData logicResourceData = (LogicResourceData)table.GetItemAt(j);
				LogicResourceData warResourceReferenceData = logicResourceData.GetWarResourceReferenceData();
				LogicDataSlot logicDataSlot = null;
				if (warResourceReferenceData != null)
				{
					for (int k = 0; k < this.logicArrayList_1.Size(); k++)
					{
						if (this.logicArrayList_1[k].GetData() == warResourceReferenceData)
						{
							logicDataSlot = this.logicArrayList_1[k];
							IL_A2:
							Debugger.DoAssert(logicDataSlot != null, "Didn't find the resource slot");
							goto IL_C9;
						}
					}
					goto IL_A2;
				}
				this.logicArrayList_1.Add(logicDataSlot = new LogicDataSlot(logicResourceData, 0));
				IL_C9:
				if (matchType == 8)
				{
					goto IL_21A;
				}
				if (matchType == 9)
				{
					goto IL_21A;
				}
				LogicComponentManager componentManagerAt = level.GetComponentManagerAt(level.GetVillageType());
				if (warResourceReferenceData == null)
				{
					LogicArrayList<LogicComponent> components = componentManagerAt.GetComponents(LogicComponentType.RESOURCE_PRODUCTION);
					LogicArrayList<LogicComponent> components2 = componentManagerAt.GetComponents(LogicComponentType.RESOURCE_STORAGE);
					for (int l = 0; l < components.Size(); l++)
					{
						LogicResourceProductionComponent logicResourceProductionComponent = (LogicResourceProductionComponent)components[l];
						if (logicResourceProductionComponent.GetParent().IsAlive() && logicResourceProductionComponent.IsEnabled() && logicResourceProductionComponent.GetResourceData() == logicResourceData)
						{
							logicDataSlot.SetCount(logicDataSlot.GetCount() + logicResourceProductionComponent.GetStealableResourceCount());
						}
					}
					for (int m = 0; m < components2.Size(); m++)
					{
						LogicResourceStorageComponent logicResourceStorageComponent = (LogicResourceStorageComponent)components2[m];
						if (logicResourceStorageComponent.GetParent().IsAlive() && logicResourceStorageComponent.IsEnabled())
						{
							logicDataSlot.SetCount(logicDataSlot.GetCount() + logicResourceStorageComponent.GetStealableResourceCount(j));
						}
					}
				}
				else
				{
					LogicArrayList<LogicComponent> components3 = componentManagerAt.GetComponents(LogicComponentType.WAR_RESOURCE_STORAGE);
					for (int n = 0; n < components3.Size(); n++)
					{
						LogicWarResourceStorageComponent logicWarResourceStorageComponent = (LogicWarResourceStorageComponent)components3[n];
						if (logicWarResourceStorageComponent.GetParent().IsAlive() && logicWarResourceStorageComponent.IsEnabled())
						{
							logicDataSlot.SetCount(logicDataSlot.GetCount() + logicWarResourceStorageComponent.GetStealableResourceCount(j));
						}
					}
				}
				IL_26B:
				j++;
				continue;
				IL_21A:
				LogicAvatar homeOwnerAvatar = level.GetHomeOwnerAvatar();
				if (homeOwnerAvatar != null)
				{
					LogicArrayList<LogicDataSlot> resources = homeOwnerAvatar.GetResources();
					for (int num = 0; num < resources.Size(); num++)
					{
						if (resources[num].GetData() == logicResourceData)
						{
							logicDataSlot.SetCount(resources[num].GetCount());
						}
					}
					goto IL_26B;
				}
				goto IL_26B;
			}
		}

		// Token: 0x060019FD RID: 6653 RVA: 0x00062244 File Offset: 0x00060444
		public void IncrementDeployedAttackerUnits(LogicCombatItemData data, int count)
		{
			int num = (data.GetCombatItemType() != LogicCombatItemType.HERO) ? LogicDataTables.GetGlobals().GetUnitHousingCostMultiplier() : LogicDataTables.GetGlobals().GetHeroHousingCostMultiplier();
			int maxHousingSpace = LogicDataTables.GetTownHallLevel(this.logicLevel_0.GetTownHallLevel(0)).GetMaxHousingSpace();
			if (maxHousingSpace > 0)
			{
				this.int_11 = (100000 * this.int_5 / maxHousingSpace + 50) / 100;
			}
			this.int_5 += num * data.GetHousingSpace() * count / 100;
			int num2 = -1;
			int i = 0;
			while (i < this.logicArrayList_3.Size())
			{
				if (this.logicArrayList_3[i].GetData() == data)
				{
					num2 = i;
					IL_A1:
					if (num2 != -1)
					{
						this.logicArrayList_3[num2].SetCount(this.logicArrayList_3[num2].GetCount() + count);
						return;
					}
					this.logicArrayList_3.Add(new LogicDataSlot(data, count));
					return;
				}
				else
				{
					i++;
				}
			}
			goto IL_A1;
		}

		// Token: 0x060019FE RID: 6654 RVA: 0x00062330 File Offset: 0x00060530
		public void IncrementDeployedAllianceUnits(LogicCombatItemData data, int count, int upgLevel)
		{
			int num = (data.GetCombatItemType() != LogicCombatItemType.HERO) ? LogicDataTables.GetGlobals().GetUnitHousingCostMultiplier() : LogicDataTables.GetGlobals().GetHeroHousingCostMultiplier();
			int maxHousingSpace = LogicDataTables.GetTownHallLevel(this.logicLevel_0.GetTownHallLevel(0)).GetMaxHousingSpace();
			if (maxHousingSpace > 0)
			{
				this.int_11 = (100000 * this.int_5 / maxHousingSpace + 50) / 100;
			}
			this.int_5 += num * data.GetHousingSpace() * count / 100;
			int num2 = -1;
			int i = 0;
			while (i < this.logicArrayList_4.Size())
			{
				if (this.logicArrayList_4[i].GetData() == data && this.logicArrayList_4[i].GetLevel() == upgLevel)
				{
					num2 = i;
					IL_B5:
					if (num2 != -1)
					{
						this.logicArrayList_4[num2].SetCount(this.logicArrayList_4[num2].GetCount() + count);
						return;
					}
					this.logicArrayList_4.Add(new LogicUnitSlot(data, upgLevel, count));
					return;
				}
				else
				{
					i++;
				}
			}
			goto IL_B5;
		}

		// Token: 0x060019FF RID: 6655 RVA: 0x00062430 File Offset: 0x00060630
		public void IncrementCastedSpells(LogicSpellData data, int count)
		{
			this.int_5 += LogicDataTables.GetGlobals().GetSpellHousingCostMultiplier() * data.GetHousingSpace() * count / 100;
			this.int_11 = (100000 * this.int_5 / LogicDataTables.GetTownHallLevel(this.logicLevel_0.GetTownHallLevel(0)).GetMaxHousingSpace() + 50) / 100;
			int num = -1;
			int i = 0;
			while (i < this.logicArrayList_2.Size())
			{
				if (this.logicArrayList_2[i].GetData() == data)
				{
					num = i;
					IL_84:
					if (num != -1)
					{
						this.logicArrayList_2[num].SetCount(this.logicArrayList_2[num].GetCount() + count);
						return;
					}
					this.logicArrayList_2.Add(new LogicDataSlot(data, count));
					return;
				}
				else
				{
					i++;
				}
			}
			goto IL_84;
		}

		// Token: 0x06001A00 RID: 6656 RVA: 0x000624FC File Offset: 0x000606FC
		public void IncrementDestroyedBuildingCount(LogicBuildingData data)
		{
			LogicBuildingClassData buildingClass = data.GetBuildingClass();
			if (buildingClass.IsTownHall() || buildingClass.IsTownHall2())
			{
				this.bool_1 = true;
			}
			if (this.logicLevel_0 != null)
			{
				LogicAvatar homeOwnerAvatar = this.logicLevel_0.GetHomeOwnerAvatar();
				if (homeOwnerAvatar != null && homeOwnerAvatar.IsClientAvatar() && this.logicLevel_0.GetState() == 2)
				{
					int matchType = this.logicLevel_0.GetMatchType();
					if (matchType != 2 && matchType != 5)
					{
						this.logicLevel_0.GetAchievementManager().BuildingDestroyedInPvP(data);
					}
				}
			}
		}

		// Token: 0x06001A01 RID: 6657 RVA: 0x0006257C File Offset: 0x0006077C
		public void SetCombatItemLevel(LogicData data, int upgLevel)
		{
			int num = -1;
			int i = 0;
			while (i < this.logicArrayList_5.Size())
			{
				if (this.logicArrayList_5[i].GetData() == data)
				{
					num = i;
					IL_32:
					if (num != -1)
					{
						this.logicArrayList_5[num].SetCount(upgLevel);
						return;
					}
					this.logicArrayList_5.Add(new LogicDataSlot(data, upgLevel));
					return;
				}
				else
				{
					i++;
				}
			}
			goto IL_32;
		}

		// Token: 0x06001A02 RID: 6658 RVA: 0x000113EF File Offset: 0x0000F5EF
		public int GetDestructionPercentage()
		{
			return this.int_6;
		}

		// Token: 0x06001A03 RID: 6659 RVA: 0x000113F7 File Offset: 0x0000F5F7
		public int GetDeployedHousingSpace()
		{
			return this.int_5;
		}

		// Token: 0x06001A04 RID: 6660 RVA: 0x000113FF File Offset: 0x0000F5FF
		public void SetDestructionPercentage(int percentage)
		{
			if (this.int_6 <= percentage)
			{
				this.int_6 = percentage;
				return;
			}
			Debugger.Warning("LogicBattleLog: m_destructionPercentage decreases");
		}

		// Token: 0x06001A05 RID: 6661 RVA: 0x0001141C File Offset: 0x0000F61C
		public LogicJSONObject GenerateDefenderJSON()
		{
			return this.GenerateBattleLogJSON(this.logicLong_0, this.logicLong_2, this.int_9, this.string_0, this.int_10, this.int_13, this.int_14);
		}

		// Token: 0x06001A06 RID: 6662 RVA: 0x0001144E File Offset: 0x0000F64E
		public LogicJSONObject GenerateAttackerJSON()
		{
			return this.GenerateBattleLogJSON(this.logicLong_1, this.logicLong_3, this.int_10, this.string_1, this.int_9, this.int_14, this.int_13);
		}

		// Token: 0x06001A07 RID: 6663 RVA: 0x000625E4 File Offset: 0x000607E4
		public LogicJSONObject GenerateBattleLogJSON(LogicLong homeId, LogicLong allianceId, int allianceBadgeId, string allianceName, int allianceBadgeId2, int allianceExpLevel, int allianceExpLevel2)
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			logicJSONObject.Put("villageType", new LogicJSONNumber(this.int_1));
			bool flag = true;
			if (((long)this.logicLevel_0.GetMatchType() & 4294967294L) != 8L)
			{
				logicJSONObject.Put("loot", LogicBattleLog.DataSlotArrayToJSONArray(this.logicArrayList_0));
				logicJSONObject.Put("availableLoot", LogicBattleLog.DataSlotArrayToJSONArray(this.logicArrayList_1));
				flag = false;
			}
			logicJSONObject.Put("units", LogicBattleLog.DataSlotArrayToJSONArray(this.logicArrayList_3));
			if (!flag && this.logicArrayList_4 != null && this.logicArrayList_4.Size() > 0)
			{
				logicJSONObject.Put("cc_units", LogicBattleLog.UnitSlotArrayToJSONArray(this.logicArrayList_4));
			}
			if (this.logicArrayList_6 != null && this.logicArrayList_6.Size() > 0)
			{
				logicJSONObject.Put("costs", LogicBattleLog.DataSlotArrayToJSONArray(this.logicArrayList_6));
			}
			if (!flag)
			{
				logicJSONObject.Put("spells", LogicBattleLog.DataSlotArrayToJSONArray(this.logicArrayList_2));
			}
			logicJSONObject.Put("levels", LogicBattleLog.DataSlotArrayToJSONArray(this.logicArrayList_5));
			LogicJSONObject logicJSONObject2 = new LogicJSONObject();
			logicJSONObject2.Put("townhallDestroyed", new LogicJSONBoolean(this.bool_1));
			logicJSONObject2.Put("battleEnded", new LogicJSONBoolean(this.bool_0));
			if (!flag)
			{
				logicJSONObject2.Put("allianceUsed", new LogicJSONBoolean(this.bool_2));
			}
			logicJSONObject2.Put("destructionPercentage", new LogicJSONNumber(this.int_6));
			logicJSONObject2.Put("battleTime", new LogicJSONNumber(this.int_0));
			if (!flag)
			{
				logicJSONObject2.Put("originalAttackerScore", new LogicJSONNumber(this.int_7));
				logicJSONObject2.Put("attackerScore", new LogicJSONNumber(this.int_3));
				logicJSONObject2.Put("originalDefenderScore", new LogicJSONNumber(this.int_8));
				logicJSONObject2.Put("defenderScore", new LogicJSONNumber(this.int_4));
			}
			logicJSONObject2.Put("allianceName", new LogicJSONString(allianceName));
			if (!flag)
			{
				logicJSONObject2.Put("attackerStars", new LogicJSONNumber(this.int_2));
			}
			if (this.logicLevel_0.GetMatchType() <= 7)
			{
				logicJSONObject2.Put("attackerName", new LogicJSONString(this.string_2));
				logicJSONObject2.Put("defenderName", new LogicJSONString(this.string_3));
				int value = 100;
				if (LogicDataTables.GetGlobals().UseTownHallLootPenaltyInWar())
				{
					value = LogicDataTables.GetGlobals().GetLootMultiplierByTownHallDiff(this.logicLevel_0.GetVisitorAvatar().GetTownHallLevel(), this.logicLevel_0.GetHomeOwnerAvatar().GetTownHallLevel());
				}
				logicJSONObject2.Put("lootMultiplierByTownHallDiff", new LogicJSONNumber(value));
			}
			LogicJSONArray logicJSONArray = new LogicJSONArray(2);
			logicJSONArray.Add(new LogicJSONNumber(homeId.GetHigherInt()));
			logicJSONArray.Add(new LogicJSONNumber(homeId.GetLowerInt()));
			logicJSONObject2.Put("homeID", logicJSONArray);
			if (allianceBadgeId != -2)
			{
				logicJSONObject2.Put("allianceBadge", new LogicJSONNumber(allianceBadgeId));
			}
			if (allianceBadgeId2 != -2)
			{
				logicJSONObject2.Put("allianceBadge2", new LogicJSONNumber(allianceBadgeId2));
			}
			if (allianceId != null)
			{
				LogicJSONArray logicJSONArray2 = new LogicJSONArray(2);
				logicJSONArray2.Add(new LogicJSONNumber(allianceId.GetHigherInt()));
				logicJSONArray2.Add(new LogicJSONNumber(allianceId.GetLowerInt()));
				logicJSONObject2.Put("allianceID", logicJSONArray2);
			}
			if (!flag)
			{
				logicJSONObject2.Put("deployedHousingSpace", new LogicJSONNumber(this.int_5));
				logicJSONObject2.Put("armyDeploymentPercentage", new LogicJSONNumber(this.int_11));
			}
			if (allianceExpLevel != 0)
			{
				logicJSONObject2.Put("allianceExp", new LogicJSONNumber(allianceExpLevel));
			}
			if (allianceExpLevel2 != 0)
			{
				logicJSONObject2.Put("allianceExp2", new LogicJSONNumber(allianceExpLevel2));
			}
			logicJSONObject.Put("stats", logicJSONObject2);
			return logicJSONObject;
		}

		// Token: 0x06001A08 RID: 6664 RVA: 0x0006298C File Offset: 0x00060B8C
		public LogicJSONObject LoadBattleLogFromJSON(LogicJSONObject root)
		{
			LogicJSONNumber jsonnumber = root.GetJSONNumber("villageType");
			if (jsonnumber != null)
			{
				this.int_1 = jsonnumber.GetIntValue();
			}
			LogicJSONNode logicJSONNode = root.Get("loot");
			if (logicJSONNode != null && logicJSONNode.GetJSONNodeType() == LogicJSONNodeType.ARRAY)
			{
				LogicBattleLog.AddJSONDataSlotsToArray((LogicJSONArray)logicJSONNode, this.logicArrayList_0);
			}
			else if (this.int_1 != 1)
			{
				Debugger.Warning("LogicBattleLog has no loot.");
			}
			LogicJSONNode logicJSONNode2 = root.Get("units");
			if (logicJSONNode2 != null && logicJSONNode2.GetJSONNodeType() == LogicJSONNodeType.ARRAY)
			{
				LogicBattleLog.AddJSONDataSlotsToArray((LogicJSONArray)logicJSONNode2, this.logicArrayList_3);
			}
			else
			{
				Debugger.Warning("LogicBattleLog has no loot.");
			}
			LogicJSONNode logicJSONNode3 = root.Get("cc_units");
			if (logicJSONNode3 != null && logicJSONNode3.GetJSONNodeType() == LogicJSONNodeType.ARRAY)
			{
				LogicBattleLog.AddJSONUnitSlotsToArray((LogicJSONArray)logicJSONNode3, this.logicArrayList_4);
			}
			LogicJSONNode logicJSONNode4 = root.Get("costs");
			if (logicJSONNode4 != null && logicJSONNode4.GetJSONNodeType() == LogicJSONNodeType.ARRAY)
			{
				LogicBattleLog.AddJSONDataSlotsToArray((LogicJSONArray)logicJSONNode4, this.logicArrayList_6);
			}
			LogicJSONNode logicJSONNode5 = root.Get("spells");
			if (logicJSONNode5 != null && logicJSONNode5.GetJSONNodeType() == LogicJSONNodeType.ARRAY)
			{
				LogicBattleLog.AddJSONDataSlotsToArray((LogicJSONArray)logicJSONNode5, this.logicArrayList_6);
			}
			else if (this.int_1 != 1)
			{
				Debugger.Warning("LogicBattleLog has no spells.");
			}
			LogicJSONNode logicJSONNode6 = root.Get("levels");
			if (logicJSONNode6 != null && logicJSONNode6.GetJSONNodeType() == LogicJSONNodeType.ARRAY)
			{
				LogicBattleLog.AddJSONDataSlotsToArray((LogicJSONArray)logicJSONNode6, this.logicArrayList_5);
			}
			else
			{
				Debugger.Warning("LogicBattleLog has no levels.");
			}
			LogicJSONNode logicJSONNode7 = root.Get("stats");
			if (logicJSONNode7 != null && logicJSONNode7.GetJSONNodeType() == LogicJSONNodeType.OBJECT)
			{
				LogicJSONObject logicJSONObject = (LogicJSONObject)logicJSONNode7;
				LogicJSONBoolean jsonboolean = logicJSONObject.GetJSONBoolean("townhallDestroyed");
				if (jsonboolean != null)
				{
					this.bool_1 = jsonboolean.IsTrue();
				}
				LogicJSONBoolean jsonboolean2 = logicJSONObject.GetJSONBoolean("battleEnded");
				if (jsonboolean2 != null)
				{
					this.bool_0 = jsonboolean2.IsTrue();
				}
				LogicJSONBoolean jsonboolean3 = logicJSONObject.GetJSONBoolean("allianceUsed");
				if (jsonboolean3 != null)
				{
					this.bool_2 = jsonboolean3.IsTrue();
				}
				LogicJSONNumber jsonnumber2 = logicJSONObject.GetJSONNumber("destructionPercentage");
				if (jsonnumber2 != null)
				{
					this.int_6 = jsonnumber2.GetIntValue();
				}
				LogicJSONNumber jsonnumber3 = logicJSONObject.GetJSONNumber("battleTime");
				if (jsonnumber3 != null)
				{
					this.int_0 = jsonnumber3.GetIntValue();
				}
				LogicJSONNumber jsonnumber4 = logicJSONObject.GetJSONNumber("attackerScore");
				if (jsonnumber4 != null)
				{
					this.int_3 = jsonnumber4.GetIntValue();
				}
				LogicJSONNumber jsonnumber5 = logicJSONObject.GetJSONNumber("defenderScore");
				if (jsonnumber5 != null)
				{
					this.int_4 = jsonnumber5.GetIntValue();
				}
				LogicJSONNumber jsonnumber6 = logicJSONObject.GetJSONNumber("originalAttackerScore");
				if (jsonnumber6 != null)
				{
					this.int_7 = jsonnumber6.GetIntValue();
				}
				else
				{
					this.int_3 = -1;
				}
				LogicJSONNumber jsonnumber7 = logicJSONObject.GetJSONNumber("originalDefenderScore");
				if (jsonnumber7 != null)
				{
					this.int_8 = jsonnumber7.GetIntValue();
				}
				else
				{
					this.int_8 = -1;
				}
				this.LoadAttackerNameFromJson(logicJSONObject);
				this.LoadDefenderNameFromJson(logicJSONObject);
				LogicJSONNumber jsonnumber8 = logicJSONObject.GetJSONNumber("lootMultiplierByTownHallDiff");
				if (jsonnumber8 != null)
				{
					this.int_12 = jsonnumber8.GetIntValue();
				}
				else
				{
					this.int_12 = -1;
				}
				LogicJSONNumber jsonnumber9 = logicJSONObject.GetJSONNumber("deployedHousingSpace");
				if (jsonnumber9 != null)
				{
					this.int_5 = jsonnumber9.GetIntValue();
				}
				LogicJSONNumber jsonnumber10 = logicJSONObject.GetJSONNumber("armyDeploymentPercentage");
				if (jsonnumber10 != null)
				{
					this.int_11 = jsonnumber10.GetIntValue();
				}
				LogicJSONNumber jsonnumber11 = logicJSONObject.GetJSONNumber("attackerStars");
				if (jsonnumber11 != null)
				{
					this.int_2 = jsonnumber11.GetIntValue();
				}
				return logicJSONObject;
			}
			Debugger.Warning("LogicBattleLog has no stats.");
			return null;
		}

		// Token: 0x06001A09 RID: 6665 RVA: 0x00062CF0 File Offset: 0x00060EF0
		public void LoadAttackerNameFromJson(LogicJSONObject jsonObject)
		{
			LogicJSONString jsonstring = jsonObject.GetJSONString("attackerName");
			if (jsonstring != null)
			{
				this.string_2 = jsonstring.GetStringValue();
				return;
			}
			this.string_2 = string.Empty;
		}

		// Token: 0x06001A0A RID: 6666 RVA: 0x00062D24 File Offset: 0x00060F24
		public void LoadDefenderNameFromJson(LogicJSONObject jsonObject)
		{
			LogicJSONString jsonstring = jsonObject.GetJSONString("defenderName");
			if (jsonstring != null)
			{
				this.string_3 = jsonstring.GetStringValue();
				return;
			}
			this.string_3 = string.Empty;
		}

		// Token: 0x06001A0B RID: 6667 RVA: 0x00062D58 File Offset: 0x00060F58
		public static void AddJSONDataSlotsToArray(LogicJSONArray jsonArray, LogicArrayList<LogicDataSlot> slot)
		{
			for (int i = 0; i < jsonArray.Size(); i++)
			{
				LogicJSONArray jsonarray = jsonArray.GetJSONArray(i);
				if (jsonarray != null && jsonarray.Size() == 2)
				{
					LogicData dataById = LogicDataTables.GetDataById(jsonArray.GetJSONNumber(0).GetIntValue());
					int intValue = jsonarray.GetJSONNumber(1).GetIntValue();
					slot.Add(new LogicDataSlot(dataById, intValue));
				}
			}
		}

		// Token: 0x06001A0C RID: 6668 RVA: 0x00062DB8 File Offset: 0x00060FB8
		public static void AddJSONUnitSlotsToArray(LogicJSONArray jsonArray, LogicArrayList<LogicUnitSlot> slot)
		{
			for (int i = 0; i < jsonArray.Size(); i++)
			{
				LogicJSONArray jsonarray = jsonArray.GetJSONArray(i);
				if (jsonarray != null && jsonarray.Size() == 2)
				{
					LogicData dataById = LogicDataTables.GetDataById(jsonArray.GetJSONNumber(0).GetIntValue());
					int intValue = jsonarray.GetJSONNumber(1).GetIntValue();
					int intValue2 = jsonarray.GetJSONNumber(2).GetIntValue();
					slot.Add(new LogicUnitSlot(dataById, intValue, intValue2));
				}
			}
		}

		// Token: 0x06001A0D RID: 6669 RVA: 0x00062E28 File Offset: 0x00061028
		public static LogicJSONArray DataSlotArrayToJSONArray(LogicArrayList<LogicDataSlot> dataSlotArray)
		{
			LogicJSONArray logicJSONArray = new LogicJSONArray(dataSlotArray.Size());
			for (int i = 0; i < dataSlotArray.Size(); i++)
			{
				LogicDataSlot logicDataSlot = dataSlotArray[i];
				LogicJSONArray logicJSONArray2 = new LogicJSONArray();
				logicJSONArray2.Add(new LogicJSONNumber(logicDataSlot.GetData().GetGlobalID()));
				logicJSONArray2.Add(new LogicJSONNumber(logicDataSlot.GetCount()));
				logicJSONArray.Add(logicJSONArray2);
			}
			return logicJSONArray;
		}

		// Token: 0x06001A0E RID: 6670 RVA: 0x00062E90 File Offset: 0x00061090
		public static LogicJSONArray UnitSlotArrayToJSONArray(LogicArrayList<LogicUnitSlot> dataSlotArray)
		{
			LogicJSONArray logicJSONArray = new LogicJSONArray(dataSlotArray.Size());
			for (int i = 0; i < dataSlotArray.Size(); i++)
			{
				LogicUnitSlot logicUnitSlot = dataSlotArray[i];
				LogicJSONArray logicJSONArray2 = new LogicJSONArray();
				logicJSONArray2.Add(new LogicJSONNumber(logicUnitSlot.GetData().GetGlobalID()));
				logicJSONArray2.Add(new LogicJSONNumber(logicUnitSlot.GetLevel()));
				logicJSONArray2.Add(new LogicJSONNumber(logicUnitSlot.GetCount()));
				logicJSONArray.Add(logicJSONArray2);
			}
			return logicJSONArray;
		}

		// Token: 0x04000DF1 RID: 3569
		private LogicLevel logicLevel_0;

		// Token: 0x04000DF2 RID: 3570
		private LogicLong logicLong_0;

		// Token: 0x04000DF3 RID: 3571
		private LogicLong logicLong_1;

		// Token: 0x04000DF4 RID: 3572
		private LogicLong logicLong_2;

		// Token: 0x04000DF5 RID: 3573
		private LogicLong logicLong_3;

		// Token: 0x04000DF6 RID: 3574
		private readonly LogicArrayList<LogicDataSlot> logicArrayList_0;

		// Token: 0x04000DF7 RID: 3575
		private readonly LogicArrayList<LogicDataSlot> logicArrayList_1;

		// Token: 0x04000DF8 RID: 3576
		private readonly LogicArrayList<LogicDataSlot> logicArrayList_2;

		// Token: 0x04000DF9 RID: 3577
		private readonly LogicArrayList<LogicDataSlot> logicArrayList_3;

		// Token: 0x04000DFA RID: 3578
		private readonly LogicArrayList<LogicUnitSlot> logicArrayList_4;

		// Token: 0x04000DFB RID: 3579
		private readonly LogicArrayList<LogicDataSlot> logicArrayList_5;

		// Token: 0x04000DFC RID: 3580
		private readonly LogicArrayList<LogicDataSlot> logicArrayList_6;

		// Token: 0x04000DFD RID: 3581
		private int int_0;

		// Token: 0x04000DFE RID: 3582
		private int int_1;

		// Token: 0x04000DFF RID: 3583
		private int int_2;

		// Token: 0x04000E00 RID: 3584
		private int int_3;

		// Token: 0x04000E01 RID: 3585
		private int int_4;

		// Token: 0x04000E02 RID: 3586
		private int int_5;

		// Token: 0x04000E03 RID: 3587
		private int int_6;

		// Token: 0x04000E04 RID: 3588
		private int int_7;

		// Token: 0x04000E05 RID: 3589
		private int int_8;

		// Token: 0x04000E06 RID: 3590
		private int int_9;

		// Token: 0x04000E07 RID: 3591
		private int int_10;

		// Token: 0x04000E08 RID: 3592
		private int int_11;

		// Token: 0x04000E09 RID: 3593
		private int int_12;

		// Token: 0x04000E0A RID: 3594
		private int int_13;

		// Token: 0x04000E0B RID: 3595
		private int int_14;

		// Token: 0x04000E0C RID: 3596
		private string string_0;

		// Token: 0x04000E0D RID: 3597
		private string string_1;

		// Token: 0x04000E0E RID: 3598
		private string string_2;

		// Token: 0x04000E0F RID: 3599
		private string string_3;

		// Token: 0x04000E10 RID: 3600
		private bool bool_0;

		// Token: 0x04000E11 RID: 3601
		private bool bool_1;

		// Token: 0x04000E12 RID: 3602
		private bool bool_2;
	}
}
