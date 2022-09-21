using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Util
{
	// Token: 0x0200000A RID: 10
	public static class LogicDebugUtil
	{
		// Token: 0x06000044 RID: 68 RVA: 0x00012690 File Offset: 0x00010890
		public static void LoadDebugJSON(LogicLevel level, string json)
		{
			LogicJSONObject logicJSONObject = LogicJSONParser.ParseObject(json);
			if (logicJSONObject != null)
			{
				LogicArrayList<LogicComponent> components = level.GetComponentManager().GetComponents(LogicComponentType.UNIT_STORAGE);
				for (int i = 0; i < components.Size(); i++)
				{
					((LogicUnitStorageComponent)components[i]).RemoveAllUnits();
				}
				level.SetLoadingVillageType(0);
				LogicDebugUtil.LoadDebugJSONArray(level, logicJSONObject.GetJSONArray("buildings"), LogicGameObjectType.BUILDING, 0);
				LogicDebugUtil.LoadDebugJSONArray(level, logicJSONObject.GetJSONArray("obstacles"), LogicGameObjectType.OBSTACLE, 0);
				LogicDebugUtil.LoadDebugJSONArray(level, logicJSONObject.GetJSONArray("traps"), LogicGameObjectType.TRAP, 0);
				LogicDebugUtil.LoadDebugJSONArray(level, logicJSONObject.GetJSONArray("decos"), LogicGameObjectType.DECO, 0);
				level.SetLoadingVillageType(1);
				LogicDebugUtil.LoadDebugJSONArray(level, logicJSONObject.GetJSONArray("buildings2"), LogicGameObjectType.BUILDING, 1);
				LogicDebugUtil.LoadDebugJSONArray(level, logicJSONObject.GetJSONArray("obstacles2"), LogicGameObjectType.OBSTACLE, 1);
				LogicDebugUtil.LoadDebugJSONArray(level, logicJSONObject.GetJSONArray("traps2"), LogicGameObjectType.TRAP, 1);
				LogicDebugUtil.LoadDebugJSONArray(level, logicJSONObject.GetJSONArray("decos2"), LogicGameObjectType.DECO, 1);
				level.SetLoadingVillageType(-1);
			}
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00012788 File Offset: 0x00010988
		public static void LoadDebugJSONArray(LogicLevel level, LogicJSONArray jsonArray, LogicGameObjectType gameObjectType, int villageType)
		{
			if (jsonArray != null)
			{
				LogicGameObjectManager gameObjectManagerAt = level.GetGameObjectManagerAt(villageType);
				LogicArrayList<LogicGameObject> logicArrayList = new LogicArrayList<LogicGameObject>();
				logicArrayList.AddAll(gameObjectManagerAt.GetGameObjects(gameObjectType));
				for (int i = 0; i < logicArrayList.Size(); i++)
				{
					gameObjectManagerAt.RemoveGameObject(logicArrayList[i]);
				}
				for (int j = 0; j < jsonArray.Size(); j++)
				{
					LogicJSONObject jsonobject = jsonArray.GetJSONObject(j);
					LogicJSONNumber jsonnumber = jsonobject.GetJSONNumber("data");
					LogicJSONNumber jsonnumber2 = jsonobject.GetJSONNumber("lvl");
					LogicJSONBoolean jsonboolean = jsonobject.GetJSONBoolean("locked");
					LogicJSONNumber jsonnumber3 = jsonobject.GetJSONNumber("x");
					LogicJSONNumber jsonnumber4 = jsonobject.GetJSONNumber("y");
					if (jsonnumber != null && jsonnumber3 != null && jsonnumber4 != null)
					{
						LogicGameObjectData logicGameObjectData = (LogicGameObjectData)LogicDataTables.GetDataById(jsonnumber.GetIntValue());
						if (logicGameObjectData != null)
						{
							LogicGameObject logicGameObject = LogicGameObjectFactory.CreateGameObject(logicGameObjectData, level, villageType);
							if (gameObjectType == LogicGameObjectType.BUILDING)
							{
								((LogicBuilding)logicGameObject).StartConstructing(true);
							}
							if (jsonboolean != null && jsonboolean.IsTrue())
							{
								((LogicBuilding)logicGameObject).Lock();
							}
							logicGameObject.Load(jsonobject);
							gameObjectManagerAt.AddGameObject(logicGameObject, -1);
							if (jsonnumber2 != null)
							{
								LogicDebugUtil.SetBuildingUpgradeLevel(level, logicGameObject.GetGlobalID(), jsonnumber2.GetIntValue(), villageType);
							}
						}
					}
				}
			}
		}

		// Token: 0x06000046 RID: 70 RVA: 0x000128BC File Offset: 0x00010ABC
		public static void SetBuildingUpgradeLevel(LogicLevel level, int gameObjectId, int upgLevel, int villageType)
		{
			LogicGameObject gameObjectByID = level.GetGameObjectManagerAt(villageType).GetGameObjectByID(gameObjectId);
			if (gameObjectByID != null)
			{
				if (gameObjectByID.GetGameObjectType() == LogicGameObjectType.BUILDING)
				{
					LogicBuilding logicBuilding = (LogicBuilding)gameObjectByID;
					LogicBuildingData buildingData = logicBuilding.GetBuildingData();
					if ((logicBuilding.GetGearLevel() > 0 || logicBuilding.IsGearing()) && buildingData.GetMinUpgradeLevelForGearUp() > upgLevel)
					{
						upgLevel = buildingData.GetMinUpgradeLevelForGearUp();
					}
					if (buildingData.IsTownHall())
					{
						level.GetPlayerAvatar().SetTownHallLevel(upgLevel);
					}
					logicBuilding.SetUpgradeLevel(LogicMath.Max(upgLevel - 1, 0));
					logicBuilding.FinishConstruction(false, true);
					logicBuilding.SetUpgradeLevel(upgLevel);
					if (logicBuilding.GetListener() != null)
					{
						logicBuilding.GetListener().RefreshState();
					}
					if (buildingData.IsTownHall() || buildingData.IsTownHallVillage2())
					{
						level.RefreshNewShopUnlocks(buildingData.GetVillageType());
						return;
					}
				}
				else if (gameObjectByID.GetGameObjectType() == LogicGameObjectType.TRAP)
				{
					LogicTrap logicTrap = (LogicTrap)gameObjectByID;
					logicTrap.SetUpgradeLevel(LogicMath.Max(upgLevel - 1, 0));
					logicTrap.FinishConstruction(false);
					logicTrap.SetUpgradeLevel(upgLevel);
					logicTrap.RepairTrap();
					if (logicTrap.GetListener() != null)
					{
						logicTrap.GetListener().RefreshState();
						return;
					}
				}
				else if (gameObjectByID.GetGameObjectType() == LogicGameObjectType.VILLAGE_OBJECT)
				{
					LogicVillageObject logicVillageObject = (LogicVillageObject)gameObjectByID;
					logicVillageObject.SetUpgradeLevel(LogicMath.Max(upgLevel - 1, 0));
					logicVillageObject.SetUpgradeLevel(upgLevel);
					if (logicVillageObject.GetListener() != null)
					{
						logicVillageObject.GetListener().RefreshState();
					}
				}
			}
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00012A04 File Offset: 0x00010C04
		public static void AddDebugTroopsPreset(LogicLevel level, int townHallLevel, LogicClientAvatar playerAvatar)
		{
			if (playerAvatar != null)
			{
				LogicDataTable table = LogicDataTables.GetTable(LogicDataType.CHARACTER);
				LogicDataTable table2 = LogicDataTables.GetTable(LogicDataType.SPELL);
				int maxUpgradeLevelForTownHallLevel = LogicDataTables.GetBuildingByName("Laboratory", null).GetMaxUpgradeLevelForTownHallLevel(townHallLevel);
				int num = LogicDebugUtil.GetTotalCharacterMaxHousing(townHallLevel, true) / 5;
				for (int i = 0; i < table.GetItemCount(); i++)
				{
					playerAvatar.SetUnitCount((LogicCharacterData)table.GetItemAt(i), 0);
				}
				for (int j = 0; j < table2.GetItemCount(); j++)
				{
					playerAvatar.SetUnitCount((LogicSpellData)table2.GetItemAt(j), 0);
				}
				for (int k = 0; k < 7; k++)
				{
					if (k != 2 && k != 5)
					{
						LogicCharacterData logicCharacterData = (LogicCharacterData)table.GetItemAt(k);
						if (logicCharacterData.GetVillageType() == 0)
						{
							int count = 0;
							for (int l = logicCharacterData.GetUpgradeLevelCount(); l >= 2; l--)
							{
								int requiredLaboratoryLevel = logicCharacterData.GetRequiredLaboratoryLevel(l - 1);
								if (maxUpgradeLevelForTownHallLevel >= requiredLaboratoryLevel)
								{
									count = l - 1;
									IL_DD:
									playerAvatar.SetUnitCount(logicCharacterData, num / logicCharacterData.GetHousingSpace());
									playerAvatar.SetUnitUpgradeLevel(logicCharacterData, count);
									goto IL_F8;
								}
							}
							goto IL_DD;
						}
					}
					IL_F8:;
				}
				return;
			}
			Debugger.Warning("addDebugTroopsPreset: pAvatar is NULL");
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00012B20 File Offset: 0x00010D20
		public static int GetTotalCharacterMaxHousing(int townHallLevel, bool includeAllianceCastle)
		{
			LogicTownhallLevelData townHallLevel2 = LogicDataTables.GetTownHallLevel(townHallLevel);
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.BUILDING);
			int num = 0;
			for (int i = 0; i < table.GetItemCount(); i++)
			{
				LogicBuildingData logicBuildingData = (LogicBuildingData)table.GetItemAt(i);
				if (includeAllianceCastle || logicBuildingData != LogicDataTables.GetAllianceCastleData())
				{
					int unlockedBuildingCount = townHallLevel2.GetUnlockedBuildingCount(logicBuildingData);
					if (unlockedBuildingCount > 0 && !logicBuildingData.IsForgesSpells())
					{
						num += unlockedBuildingCount * logicBuildingData.GetUnitStorageCapacity(logicBuildingData.GetMaxUpgradeLevelForTownHallLevel(townHallLevel));
					}
				}
			}
			return num;
		}
	}
}
