using System;
using System.Runtime.CompilerServices;
using System.Text;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Mode;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace ns0
{
	// Token: 0x02000013 RID: 19
	public static class GClass8
	{
		// Token: 0x06000089 RID: 137 RVA: 0x00002538 File Offset: 0x00000738
		[CompilerGenerated]
		public static LogicClientAvatar smethod_0()
		{
			return GClass8.logicClientAvatar_0;
		}

		// Token: 0x0600008A RID: 138 RVA: 0x0000253F File Offset: 0x0000073F
		[CompilerGenerated]
		private static void smethod_1(LogicClientAvatar logicClientAvatar_1)
		{
			GClass8.logicClientAvatar_0 = logicClientAvatar_1;
		}

		// Token: 0x0600008B RID: 139 RVA: 0x000057E4 File Offset: 0x000039E4
		public static void smethod_2()
		{
			GClass8.smethod_1(new LogicClientAvatar());
			GClass8.smethod_0().SetName("Atrasis - Private CoC Server");
			GClass8.smethod_0().SetExpLevel(500);
			GClass8.smethod_0().SetScore(5000);
			GClass8.smethod_0().SetLeagueType(LogicDataTables.GetTable(LogicDataType.LEAGUE).GetItemCount() - 1);
			GClass8.logicRandom_0 = new LogicRandom(Environment.TickCount);
			GClass8.logicArrayList_0 = new LogicArrayList<LogicBuildingData>();
			GClass8.logicArrayList_1 = new LogicArrayList<LogicBuildingData>();
			GClass8.logicArrayList_2 = new LogicArrayList<LogicTrapData>();
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.BUILDING);
			LogicDataTable table2 = LogicDataTables.GetTable(LogicDataType.TRAP);
			for (int i = 0; i < table.GetItemCount(); i++)
			{
				LogicBuildingData logicBuildingData = (LogicBuildingData)table.GetItemAt(i);
				if (logicBuildingData.IsEnabledInVillageType(0))
				{
					if (logicBuildingData.GetBuildingClass().GetName() == "Defense")
					{
						GClass8.logicArrayList_0.Add(logicBuildingData);
					}
					else
					{
						GClass8.logicArrayList_1.Add(logicBuildingData);
					}
				}
			}
			for (int j = 0; j < table2.GetItemCount(); j++)
			{
				LogicTrapData logicTrapData = (LogicTrapData)table2.GetItemAt(j);
				if (logicTrapData.IsEnabledInVillageType(0))
				{
					GClass8.logicArrayList_2.Add(logicTrapData);
				}
			}
		}

		// Token: 0x0600008C RID: 140 RVA: 0x0000590C File Offset: 0x00003B0C
		public static byte[] smethod_3(LogicGameObjectData logicGameObjectData_0)
		{
			LogicGameMode logicGameMode = new LogicGameMode();
			LogicLevel level = logicGameMode.GetLevel();
			LogicGameObjectManager gameObjectManagerAt = level.GetGameObjectManagerAt(0);
			level.SetLoadingVillageType(-1);
			level.SetVillageType(0);
			level.SetExperienceVersion(1);
			level.SetHomeOwnerAvatar(GClass8.smethod_0());
			LogicBuilding logicBuilding = new LogicBuilding(LogicDataTables.GetTownHallData(), level, 0);
			logicBuilding.SetInitialPosition(25 - logicBuilding.GetWidthInTiles() / 2 << 9, 25 - logicBuilding.GetHeightInTiles() / 2 << 9);
			logicBuilding.SetUpgradeLevel(logicBuilding.GetBuildingData().GetUpgradeLevelCount() - 1);
			gameObjectManagerAt.AddGameObject(logicBuilding, -1);
			LogicTownhallLevelData townHallLevel = LogicDataTables.GetTownHallLevel(logicBuilding.GetUpgradeLevel());
			if (logicGameObjectData_0 != null)
			{
				if (logicGameObjectData_0.GetDataType() == LogicDataType.BUILDING)
				{
					LogicBuildingData logicBuildingData = (LogicBuildingData)logicGameObjectData_0;
					if (logicBuildingData.IsAllianceCastle() || logicBuildingData.IsTownHall() || logicBuildingData.IsTownHallVillage2() || logicBuildingData.GetVillageType() == 1 || logicBuildingData.IsEnableByCalendar())
					{
						logicGameObjectData_0 = null;
					}
				}
				else if (logicGameObjectData_0.GetDataType() == LogicDataType.TRAP)
				{
					LogicTrapData logicTrapData = (LogicTrapData)logicGameObjectData_0;
					if (logicTrapData.GetVillageType() == 1 || logicTrapData.IsEnableByCalendar() || logicTrapData.GetSpawnedCharAir() != null || logicTrapData.GetSpawnedCharGround() != null)
					{
						logicGameObjectData_0 = null;
					}
				}
			}
			if (logicGameObjectData_0 == null)
			{
				LogicArrayList<LogicGameObject> logicArrayList = new LogicArrayList<LogicGameObject>();
				for (int i = 0; i < GClass8.logicArrayList_0.Size(); i++)
				{
					LogicBuildingData logicBuildingData2 = GClass8.logicArrayList_0[i];
					for (int j = townHallLevel.GetUnlockedBuildingCount(logicBuildingData2); j > 0; j--)
					{
						LogicBuilding logicBuilding2 = (LogicBuilding)GClass8.smethod_4(logicBuildingData2, level, logicBuildingData2.GetWidth(), logicBuildingData2.GetHeight(), 0);
						if (logicBuilding2 != null)
						{
							logicBuilding2.SetLocked(false);
							logicBuilding2.SetUpgradeLevel(logicBuildingData2.GetUpgradeLevelCount() - 1);
							logicArrayList.Add(logicBuilding2);
							int num = logicBuildingData2.GetUpgradeLevelCount() - 1;
							int minUpgradeLevelForGearUp = logicBuildingData2.GetMinUpgradeLevelForGearUp();
							if (minUpgradeLevelForGearUp > -1 && num >= minUpgradeLevelForGearUp && GClass8.logicRandom_0.Rand(100) >= 50)
							{
								logicBuilding2.SetGearLevel(1);
							}
							if (logicBuildingData2.GetAttackerItemData(num).GetTargetingConeAngle() != 0)
							{
								logicBuilding2.GetCombatComponent().ToggleAimAngle(logicBuildingData2.GetAimRotateStep() * GClass8.logicRandom_0.Rand(360 / logicBuildingData2.GetAimRotateStep()), 0, false);
							}
							if (logicBuildingData2.GetAttackerItemData(num).HasAlternativeAttackMode() && (minUpgradeLevelForGearUp <= -1 || logicBuilding2.GetGearLevel() == 1) && GClass8.logicRandom_0.Rand(100) >= 50)
							{
								logicBuilding2.GetCombatComponent().ToggleAttackMode(0, false);
							}
						}
					}
				}
				for (int k = 0; k < GClass8.logicArrayList_1.Size(); k++)
				{
					LogicBuildingData logicBuildingData3 = GClass8.logicArrayList_1[k];
					for (int l = townHallLevel.GetUnlockedBuildingCount(logicBuildingData3); l > 0; l--)
					{
						LogicBuilding logicBuilding3 = (LogicBuilding)GClass8.smethod_4(logicBuildingData3, level, logicBuildingData3.GetWidth(), logicBuildingData3.GetHeight(), 0);
						if (logicBuilding3 != null)
						{
							logicBuilding3.SetLocked(false);
							logicBuilding3.SetUpgradeLevel(logicBuildingData3.GetUpgradeLevelCount() - 1);
							logicArrayList.Add(logicBuilding3);
						}
					}
				}
				for (int m = 0; m < GClass8.logicArrayList_2.Size(); m++)
				{
					LogicTrapData logicTrapData2 = GClass8.logicArrayList_2[m];
					for (int n = townHallLevel.GetUnlockedTrapCount(logicTrapData2); n > 0; n--)
					{
						LogicTrap logicTrap = (LogicTrap)GClass8.smethod_4(logicTrapData2, level, logicTrapData2.GetWidth(), logicTrapData2.GetHeight(), 0);
						if (logicTrap != null)
						{
							logicTrap.SetUpgradeLevel(logicTrapData2.GetUpgradeLevelCount() - 1);
							logicArrayList.Add(logicTrap);
						}
					}
				}
				for (int num2 = 0; num2 < logicArrayList.Size(); num2++)
				{
					LogicGameObject logicGameObject = logicArrayList[num2];
					LogicData data = logicGameObject.GetData();
					int widthInTiles = logicGameObject.GetWidthInTiles();
					int heightInTiles = logicGameObject.GetHeightInTiles();
					int x = logicGameObject.GetX();
					int y = logicGameObject.GetY();
					LogicArrayList<LogicGameObject> logicArrayList2 = new LogicArrayList<LogicGameObject>();
					for (int num3 = num2 + 1; num3 < logicArrayList.Size(); num3++)
					{
						if (data != logicArrayList[num3].GetData() && logicArrayList[num3].GetWidthInTiles() == widthInTiles && logicArrayList[num3].GetHeightInTiles() == heightInTiles)
						{
							logicArrayList2.Add(logicArrayList[num3]);
						}
					}
					if (logicArrayList2.Size() != 0)
					{
						LogicGameObject logicGameObject2 = logicArrayList2[GClass8.logicRandom_0.Rand(logicArrayList2.Size())];
						logicGameObject.SetInitialPosition(logicGameObject2.GetX(), logicGameObject2.GetY());
						logicGameObject2.SetInitialPosition(x, y);
					}
				}
			}
			else
			{
				int num4 = 0;
				int int_ = 1;
				int int_2 = 1;
				LogicDataType dataType = logicGameObjectData_0.GetDataType();
				if (dataType != LogicDataType.BUILDING)
				{
					if (dataType == LogicDataType.TRAP)
					{
						LogicTrapData logicTrapData3 = (LogicTrapData)logicGameObjectData_0;
						num4 = logicTrapData3.GetUpgradeLevelCount();
						int_ = logicTrapData3.GetWidth();
						int_2 = logicTrapData3.GetHeight();
					}
				}
				else
				{
					LogicBuildingData logicBuildingData4 = (LogicBuildingData)logicGameObjectData_0;
					num4 = logicBuildingData4.GetUpgradeLevelCount();
					int_ = logicBuildingData4.GetWidth();
					int_2 = logicBuildingData4.GetHeight();
				}
				int num5 = num4 - 1;
				int int_3 = 0;
				int int_4 = 0;
				if (logicGameObjectData_0.GetDataType() == LogicDataType.BUILDING)
				{
					for (;;)
					{
						LogicBuilding logicBuilding4 = (LogicBuilding)GClass8.smethod_5(logicGameObjectData_0, level, int_, int_2, 0, int_3, int_4);
						if (logicBuilding4 == null)
						{
							break;
						}
						logicBuilding4.SetLocked(false);
						logicBuilding4.SetUpgradeLevel((num5 != -1) ? num5 : GClass8.logicRandom_0.Rand(logicBuilding4.GetUpgradeLevel()));
						int_3 = logicBuilding4.GetTileX();
						int_4 = logicBuilding4.GetTileY();
					}
				}
				else if (logicGameObjectData_0.GetDataType() == LogicDataType.TRAP)
				{
					for (;;)
					{
						LogicTrap logicTrap2 = (LogicTrap)GClass8.smethod_5(logicGameObjectData_0, level, int_, int_2, 0, int_3, int_4);
						if (logicTrap2 == null)
						{
							break;
						}
						logicTrap2.SetUpgradeLevel((num5 != -1) ? num5 : GClass8.logicRandom_0.Rand(logicTrap2.GetUpgradeLevel()));
						int_3 = logicTrap2.GetTileX();
						int_4 = logicTrap2.GetTileY();
					}
				}
			}
			for (int num6 = 0; num6 < 10; num6++)
			{
				gameObjectManagerAt.Village1CreateObstacle();
			}
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			logicGameMode.SaveToJSON(logicJSONObject);
			logicGameMode.Destruct();
			return GClass11.smethod_5(Encoding.UTF8.GetBytes(LogicJSONParser.CreateJSONString(logicJSONObject, 2048)));
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00005EDC File Offset: 0x000040DC
		private static LogicGameObject smethod_4(LogicGameObjectData logicGameObjectData_0, LogicLevel logicLevel_0, int int_0, int int_1, int int_2)
		{
			int endX = logicLevel_0.GetPlayArea().GetEndX();
			int endY = logicLevel_0.GetPlayArea().GetEndY();
			int num = endX / 2;
			int num2 = endY / 2;
			int num3 = 1;
			int num9;
			int num10;
			for (;;)
			{
				int num4 = LogicMath.Max(num - num3, 0);
				int num5 = LogicMath.Max(num2 - num3, 0);
				int num6 = LogicMath.Min(num + num3, endX);
				int num7 = LogicMath.Min(num2 + num3, endY);
				int num8 = LogicMath.Min((num6 - num4) * (num7 - num5), 20);
				for (int i = 0; i < num8; i++)
				{
					num9 = num4 + GClass8.logicRandom_0.Rand(num6 - num4);
					num10 = num5 + GClass8.logicRandom_0.Rand(num7 - num5);
					if (logicLevel_0.IsValidPlaceForBuilding(num9, num10, int_0, int_1, null))
					{
						goto IL_C9;
					}
				}
				if (num4 == 0 && num5 == 0)
				{
					break;
				}
				num3 += 2;
			}
			return null;
			IL_C9:
			LogicGameObject logicGameObject = LogicGameObjectFactory.CreateGameObject(logicGameObjectData_0, logicLevel_0, int_2);
			logicGameObject.SetInitialPosition(num9 << 9, num10 << 9);
			logicLevel_0.GetGameObjectManagerAt(int_2).AddGameObject(logicGameObject, -1);
			return logicGameObject;
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00005FE0 File Offset: 0x000041E0
		private static LogicGameObject smethod_5(LogicGameObjectData logicGameObjectData_0, LogicLevel logicLevel_0, int int_0, int int_1, int int_2, int int_3 = 0, int int_4 = 0)
		{
			int endX = logicLevel_0.GetPlayArea().GetEndX();
			int endY = logicLevel_0.GetPlayArea().GetEndY();
			if (int_3 == 0 && int_4 == 0)
			{
				int_3 = logicLevel_0.GetPlayArea().GetStartX();
				int_4 = logicLevel_0.GetPlayArea().GetStartY();
			}
			while (!logicLevel_0.IsValidPlaceForBuilding(int_3, int_4, int_0, int_1, null))
			{
				if (++int_3 + int_0 > endX)
				{
					if (++int_4 + int_1 > endY)
					{
						return null;
					}
					int_3 = logicLevel_0.GetPlayArea().GetStartX();
				}
			}
			LogicGameObject logicGameObject = LogicGameObjectFactory.CreateGameObject(logicGameObjectData_0, logicLevel_0, int_2);
			logicGameObject.SetInitialPosition(int_3 << 9, int_4 << 9);
			logicLevel_0.GetGameObjectManagerAt(int_2).AddGameObject(logicGameObject, -1);
			return logicGameObject;
		}

		// Token: 0x04000024 RID: 36
		[CompilerGenerated]
		private static LogicClientAvatar logicClientAvatar_0;

		// Token: 0x04000025 RID: 37
		private static LogicRandom logicRandom_0;

		// Token: 0x04000026 RID: 38
		private static LogicArrayList<LogicBuildingData> logicArrayList_0;

		// Token: 0x04000027 RID: 39
		private static LogicArrayList<LogicBuildingData> logicArrayList_1;

		// Token: 0x04000028 RID: 40
		private static LogicArrayList<LogicTrapData> logicArrayList_2;
	}
}
