using System;
using Atrasis.Magic.Titan.CSV;
using Atrasis.Magic.Titan.Debug;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x0200014A RID: 330
	public class LogicDataTables
	{
		// Token: 0x06001246 RID: 4678 RVA: 0x0000C3B9 File Offset: 0x0000A5B9
		public static void Init()
		{
			LogicDataTables.logicDataTable_0 = new LogicDataTable[44];
		}

		// Token: 0x06001247 RID: 4679 RVA: 0x0004DED8 File Offset: 0x0004C0D8
		public static void DeInit()
		{
			if (LogicDataTables.logicDataTable_0 != null)
			{
				for (int i = 0; i < LogicDataTables.logicDataTable_0.Length; i++)
				{
					if (LogicDataTables.logicDataTable_0[i] != null)
					{
						LogicDataTables.logicDataTable_0[i].Destruct();
						LogicDataTables.logicDataTable_0[i] = null;
					}
				}
				LogicDataTables.logicCombatItemData_0 = null;
				LogicDataTables.logicCombatItemData_1 = null;
				LogicDataTables.logicResourceData_0 = null;
				LogicDataTables.logicResourceData_1 = null;
				LogicDataTables.logicResourceData_2 = null;
				LogicDataTables.logicResourceData_3 = null;
				LogicDataTables.logicResourceData_4 = null;
				LogicDataTables.logicResourceData_5 = null;
				LogicDataTables.logicResourceData_6 = null;
				LogicDataTables.logicResourceData_7 = null;
				LogicDataTables.logicResourceData_8 = null;
				LogicDataTables.logicBuildingData_0 = null;
				LogicDataTables.logicBuildingData_1 = null;
				LogicDataTables.logicBuildingData_2 = null;
				LogicDataTables.logicBuildingData_3 = null;
				LogicDataTables.logicBuildingData_4 = null;
				LogicDataTables.logicBuildingData_5 = null;
				LogicDataTables.logicBuildingData_6 = null;
				LogicDataTables.logicBuildingData_7 = null;
			}
		}

		// Token: 0x06001248 RID: 4680 RVA: 0x0004DF90 File Offset: 0x0004C190
		public static void InitDataTable(CSVNode node, LogicDataType index)
		{
			if (index == LogicDataType.ANIMATION)
			{
				if (LogicDataTables.logicAnimationTable_0 != null)
				{
					LogicDataTables.logicAnimationTable_0.SetTable(node);
					return;
				}
				LogicDataTables.logicAnimationTable_0 = new LogicAnimationTable(node, index);
				return;
			}
			else
			{
				if (LogicDataTables.logicDataTable_0[(int)index] != null)
				{
					LogicDataTables.logicDataTable_0[(int)index].SetTable(node.GetTable());
					return;
				}
				if (index == LogicDataType.GLOBAL)
				{
					LogicDataTables.logicDataTable_0[(int)index] = new LogicGlobals(node.GetTable(), index);
					return;
				}
				if (index != LogicDataType.CLIENT_GLOBAL)
				{
					LogicDataTables.logicDataTable_0[(int)index] = new LogicDataTable(node.GetTable(), index);
					return;
				}
				LogicDataTables.logicDataTable_0[(int)index] = new LogicClientGlobals(node.GetTable(), index);
				return;
			}
		}

		// Token: 0x06001249 RID: 4681 RVA: 0x0004E024 File Offset: 0x0004C224
		public static void CreateReferences()
		{
			LogicDataTables.logicDataTable_0[9].CreateReferences();
			for (int i = 0; i < LogicDataTables.logicDataTable_0.Length; i++)
			{
				if (i != 9 && LogicDataTables.logicDataTable_0[i] != null)
				{
					LogicDataTables.logicDataTable_0[i].CreateReferences();
				}
			}
			for (int j = 0; j < LogicDataTables.logicDataTable_0.Length; j++)
			{
				if (LogicDataTables.logicDataTable_0[j] != null)
				{
					LogicDataTables.logicDataTable_0[j].CreateReferences2();
				}
			}
			LogicDataTable logicDataTable = LogicDataTables.logicDataTable_0[0];
			for (int k = 0; k < logicDataTable.GetItemCount(); k++)
			{
				LogicBuildingData logicBuildingData = (LogicBuildingData)logicDataTable.GetItemAt(k);
				if (logicBuildingData.IsAllianceCastle())
				{
					LogicDataTables.logicBuildingData_2 = logicBuildingData;
				}
				if (logicBuildingData.IsTownHall() && LogicDataTables.logicBuildingData_0 == null)
				{
					LogicDataTables.logicBuildingData_0 = logicBuildingData;
				}
				if (logicBuildingData.IsTownHallVillage2() && LogicDataTables.logicBuildingData_1 == null)
				{
					LogicDataTables.logicBuildingData_1 = logicBuildingData;
				}
			}
			LogicDataTables.logicBuildingData_3 = LogicDataTables.GetBuildingByName("Bow", null);
			LogicDataTables.logicBuildingData_4 = LogicDataTables.GetBuildingByName("Dark Tower", null);
			LogicDataTables.logicBuildingData_5 = LogicDataTables.GetBuildingByName("Ancient Artillery", null);
			LogicDataTables.logicBuildingData_6 = LogicDataTables.GetBuildingByName("Worker Building", null);
			LogicDataTables.logicBuildingData_7 = LogicDataTables.GetBuildingByName("Laboratory2", null);
			LogicDataTables.logicResourceData_0 = LogicDataTables.GetResourceByName("Diamonds", null);
			LogicDataTables.logicResourceData_1 = LogicDataTables.GetResourceByName("Gold", null);
			LogicDataTables.logicResourceData_2 = LogicDataTables.GetResourceByName("Elixir", null);
			LogicDataTables.logicResourceData_3 = LogicDataTables.GetResourceByName("DarkElixir", null);
			LogicDataTables.logicResourceData_4 = LogicDataTables.GetResourceByName("Gold2", null);
			LogicDataTables.logicResourceData_5 = LogicDataTables.GetResourceByName("Elixir2", null);
			LogicDataTables.logicResourceData_6 = LogicDataTables.GetResourceByName("WarGold", null);
			LogicDataTables.logicResourceData_7 = LogicDataTables.GetResourceByName("WarElixir", null);
			LogicDataTables.logicResourceData_8 = LogicDataTables.GetResourceByName("WarDarkElixir", null);
			LogicDataTables.logicCombatItemData_0 = LogicDataTables.GetCharacterByName("Skeleton", null);
			LogicDataTables.logicCombatItemData_1 = LogicDataTables.GetCharacterByName("Balloon Skeleton", null);
		}

		// Token: 0x0600124A RID: 4682 RVA: 0x0000C3C7 File Offset: 0x0000A5C7
		public int GetTableCount()
		{
			return 44;
		}

		// Token: 0x0600124B RID: 4683 RVA: 0x00002B36 File Offset: 0x00000D36
		public static bool CanReloadTable(LogicDataTable table)
		{
			return true;
		}

		// Token: 0x0600124C RID: 4684 RVA: 0x0000C3CB File Offset: 0x0000A5CB
		public static bool IsSkeleton(LogicCharacterData data)
		{
			return data == LogicDataTables.logicCombatItemData_0 || data == LogicDataTables.logicCombatItemData_1;
		}

		// Token: 0x0600124D RID: 4685 RVA: 0x0000C3DF File Offset: 0x0000A5DF
		public static LogicDataTable GetTable(LogicDataType tableIndex)
		{
			return LogicDataTables.logicDataTable_0[(int)tableIndex];
		}

		// Token: 0x0600124E RID: 4686 RVA: 0x0004E1F8 File Offset: 0x0004C3F8
		public static LogicData GetDataById(int globalId)
		{
			int num = GlobalID.GetClassID(globalId) - 1;
			if (num >= 0 && num < 44 && LogicDataTables.logicDataTable_0[num] != null)
			{
				return LogicDataTables.logicDataTable_0[num].GetItemById(globalId);
			}
			return null;
		}

		// Token: 0x0600124F RID: 4687 RVA: 0x0004E230 File Offset: 0x0004C430
		public static LogicData GetDataById(int globalId, LogicDataType dataType)
		{
			LogicData dataById = LogicDataTables.GetDataById(globalId);
			if (dataById.GetDataType() != dataType)
			{
				return null;
			}
			return dataById;
		}

		// Token: 0x06001250 RID: 4688 RVA: 0x0000C3E8 File Offset: 0x0000A5E8
		public static LogicBuildingData GetBuildingByName(string name, LogicData data)
		{
			return (LogicBuildingData)LogicDataTables.logicDataTable_0[0].GetDataByName(name, data);
		}

		// Token: 0x06001251 RID: 4689 RVA: 0x0000C3FD File Offset: 0x0000A5FD
		public static LogicLocaleData GetLocaleByName(string name, LogicData data)
		{
			return (LogicLocaleData)LogicDataTables.logicDataTable_0[1].GetDataByName(name, data);
		}

		// Token: 0x06001252 RID: 4690 RVA: 0x0000C412 File Offset: 0x0000A612
		public static LogicDecoData GetDecoByName(string name, LogicData data)
		{
			return (LogicDecoData)LogicDataTables.logicDataTable_0[17].GetDataByName(name, data);
		}

		// Token: 0x06001253 RID: 4691 RVA: 0x0000C428 File Offset: 0x0000A628
		public static LogicBillingPackageData GetBillingPackageByName(string name, LogicData data)
		{
			return (LogicBillingPackageData)LogicDataTables.logicDataTable_0[21].GetDataByName(name, data);
		}

		// Token: 0x06001254 RID: 4692 RVA: 0x0000C43E File Offset: 0x0000A63E
		public static LogicVillageObjectData GetVillageObjectByName(string name, LogicData data)
		{
			return (LogicVillageObjectData)LogicDataTables.logicDataTable_0[38].GetDataByName(name, data);
		}

		// Token: 0x06001255 RID: 4693 RVA: 0x0000C454 File Offset: 0x0000A654
		public static LogicData GetVariableByName(string name, LogicData data)
		{
			return LogicDataTables.logicDataTable_0[36].GetDataByName(name, data);
		}

		// Token: 0x06001256 RID: 4694 RVA: 0x0000C465 File Offset: 0x0000A665
		public static LogicObstacleData GetObstacleByName(string name, LogicData data)
		{
			return (LogicObstacleData)LogicDataTables.logicDataTable_0[7].GetDataByName(name, data);
		}

		// Token: 0x06001257 RID: 4695 RVA: 0x0000C47A File Offset: 0x0000A67A
		public static LogicHeroData GetHeroByName(string name, LogicData data)
		{
			return (LogicHeroData)LogicDataTables.logicDataTable_0[27].GetDataByName(name, data);
		}

		// Token: 0x06001258 RID: 4696 RVA: 0x0000C490 File Offset: 0x0000A690
		public static LogicCharacterData GetCharacterByName(string name, LogicData data)
		{
			return (LogicCharacterData)LogicDataTables.logicDataTable_0[3].GetDataByName(name, data);
		}

		// Token: 0x06001259 RID: 4697 RVA: 0x0000C4A5 File Offset: 0x0000A6A5
		public static LogicSpellData GetSpellByName(string name, LogicData data)
		{
			return (LogicSpellData)LogicDataTables.logicDataTable_0[25].GetDataByName(name, data);
		}

		// Token: 0x0600125A RID: 4698 RVA: 0x0000C4BB File Offset: 0x0000A6BB
		public static LogicEffectData GetEffectByName(string name, LogicData data)
		{
			return (LogicEffectData)LogicDataTables.logicDataTable_0[8].GetDataByName(name, data);
		}

		// Token: 0x0600125B RID: 4699 RVA: 0x0000C4D0 File Offset: 0x0000A6D0
		public static LogicParticleEmitterData GetParticleEmitterByName(string name, LogicData data)
		{
			return (LogicParticleEmitterData)LogicDataTables.logicDataTable_0[9].GetDataByName(name, data);
		}

		// Token: 0x0600125C RID: 4700 RVA: 0x0000C4E6 File Offset: 0x0000A6E6
		public static LogicProjectileData GetProjectileByName(string name, LogicData data)
		{
			return (LogicProjectileData)LogicDataTables.logicDataTable_0[5].GetDataByName(name, data);
		}

		// Token: 0x0600125D RID: 4701 RVA: 0x0000C4FB File Offset: 0x0000A6FB
		public static LogicRegionData GetRegionByName(string name, LogicData data)
		{
			return (LogicRegionData)LogicDataTables.logicDataTable_0[31].GetDataByName(name, data);
		}

		// Token: 0x0600125E RID: 4702 RVA: 0x0000C511 File Offset: 0x0000A711
		public static LogicCalendarEventFunctionData GetCalendarEventFunctionByName(string name, LogicData data)
		{
			return (LogicCalendarEventFunctionData)LogicDataTables.logicDataTable_0[39].GetDataByName(name, data);
		}

		// Token: 0x0600125F RID: 4703 RVA: 0x0000C527 File Offset: 0x0000A727
		public static LogicEventEntryData GetEventEntryByName(string name, LogicData data)
		{
			return (LogicEventEntryData)LogicDataTables.logicDataTable_0[41].GetDataByName(name, data);
		}

		// Token: 0x06001260 RID: 4704 RVA: 0x0000C53D File Offset: 0x0000A73D
		public static LogicData GetDataByName(string name, int tableIdx, LogicData caller)
		{
			if (LogicDataTables.logicDataTable_0[tableIdx] != null)
			{
				return LogicDataTables.logicDataTable_0[tableIdx].GetDataByName(name, caller);
			}
			return null;
		}

		// Token: 0x06001261 RID: 4705 RVA: 0x0000C558 File Offset: 0x0000A758
		public static LogicExperienceLevelData GetExperienceLevel(int level)
		{
			if (level > 0 && level - 1 < LogicDataTables.logicDataTable_0[10].GetItemCount())
			{
				return (LogicExperienceLevelData)LogicDataTables.logicDataTable_0[10].GetItemAt(level - 1);
			}
			Debugger.Error("LogicDataTables::getExperienceLevel parameter out of bounds");
			return null;
		}

		// Token: 0x06001262 RID: 4706 RVA: 0x0000C591 File Offset: 0x0000A791
		public static LogicAllianceLevelData GetAllianceLevel(int level)
		{
			return (LogicAllianceLevelData)LogicDataTables.logicDataTable_0[34].GetItemAt(level - 1);
		}

		// Token: 0x06001263 RID: 4707 RVA: 0x0000C5A8 File Offset: 0x0000A7A8
		public static int GetExperienceLevelCount()
		{
			return LogicDataTables.logicDataTable_0[10].GetItemCount();
		}

		// Token: 0x06001264 RID: 4708 RVA: 0x0000C5B7 File Offset: 0x0000A7B7
		public static int GetAllianceLevelCount()
		{
			return LogicDataTables.logicDataTable_0[34].GetItemCount();
		}

		// Token: 0x06001265 RID: 4709 RVA: 0x0000C5C6 File Offset: 0x0000A7C6
		public static int GetTownHallLevelCount()
		{
			return LogicDataTables.logicDataTable_0[14].GetItemCount();
		}

		// Token: 0x06001266 RID: 4710 RVA: 0x0000C5D5 File Offset: 0x0000A7D5
		public static LogicTownhallLevelData GetTownHallLevel(int levelIndex)
		{
			if (levelIndex > -1 && levelIndex < LogicDataTables.logicDataTable_0[14].GetItemCount())
			{
				return (LogicTownhallLevelData)LogicDataTables.logicDataTable_0[14].GetItemAt(levelIndex);
			}
			Debugger.Error("LogicDataTables::getTownHallLevel parameter out of bounds");
			return null;
		}

		// Token: 0x06001267 RID: 4711 RVA: 0x0000C60A File Offset: 0x0000A80A
		public static LogicNpcData GetNpcByName(string name, LogicData data)
		{
			return (LogicNpcData)LogicDataTables.logicDataTable_0[16].GetDataByName(name, data);
		}

		// Token: 0x06001268 RID: 4712 RVA: 0x0000C620 File Offset: 0x0000A820
		public static LogicMissionData GetMissionByName(string name, LogicData data)
		{
			return (LogicMissionData)LogicDataTables.logicDataTable_0[20].GetDataByName(name, data);
		}

		// Token: 0x06001269 RID: 4713 RVA: 0x0000C636 File Offset: 0x0000A836
		public static LogicResourceData GetResourceByName(string name, LogicData data)
		{
			return (LogicResourceData)LogicDataTables.logicDataTable_0[2].GetDataByName(name, data);
		}

		// Token: 0x0600126A RID: 4714 RVA: 0x0000C64B File Offset: 0x0000A84B
		public static LogicGlobalData GetClientGlobalByName(string name, LogicData data)
		{
			return (LogicGlobalData)LogicDataTables.logicDataTable_0[32].GetDataByName(name, data);
		}

		// Token: 0x0600126B RID: 4715 RVA: 0x0000C661 File Offset: 0x0000A861
		public static LogicGlobalData GetGlobalByName(string name, LogicData data)
		{
			return (LogicGlobalData)LogicDataTables.logicDataTable_0[13].GetDataByName(name, data);
		}

		// Token: 0x0600126C RID: 4716 RVA: 0x0000C677 File Offset: 0x0000A877
		public static LogicBuildingClassData GetBuildingClassByName(string name, LogicData data)
		{
			return (LogicBuildingClassData)LogicDataTables.logicDataTable_0[6].GetDataByName(name, data);
		}

		// Token: 0x0600126D RID: 4717 RVA: 0x0000C68C File Offset: 0x0000A88C
		public static LogicClientGlobals GetClientGlobals()
		{
			return (LogicClientGlobals)LogicDataTables.logicDataTable_0[32];
		}

		// Token: 0x0600126E RID: 4718 RVA: 0x0000C69B File Offset: 0x0000A89B
		public static LogicGlobals GetGlobals()
		{
			return (LogicGlobals)LogicDataTables.logicDataTable_0[13];
		}

		// Token: 0x0600126F RID: 4719 RVA: 0x0000C6AA File Offset: 0x0000A8AA
		public static LogicBuildingData GetAllianceCastleData()
		{
			return LogicDataTables.logicBuildingData_2;
		}

		// Token: 0x06001270 RID: 4720 RVA: 0x0000C6B1 File Offset: 0x0000A8B1
		public static LogicBuildingData GetWorkerData()
		{
			return LogicDataTables.logicBuildingData_6;
		}

		// Token: 0x06001271 RID: 4721 RVA: 0x0000C6B8 File Offset: 0x0000A8B8
		public static LogicBuildingData GetTownHallData()
		{
			return LogicDataTables.logicBuildingData_0;
		}

		// Token: 0x06001272 RID: 4722 RVA: 0x0000C6BF File Offset: 0x0000A8BF
		public static LogicBuildingData GetTownHallVillage2Data()
		{
			return LogicDataTables.logicBuildingData_1;
		}

		// Token: 0x06001273 RID: 4723 RVA: 0x0000C6C6 File Offset: 0x0000A8C6
		public static LogicResourceData GetDiamondsData()
		{
			return LogicDataTables.logicResourceData_0;
		}

		// Token: 0x06001274 RID: 4724 RVA: 0x0000C6CD File Offset: 0x0000A8CD
		public static LogicResourceData GetGoldData()
		{
			return LogicDataTables.logicResourceData_1;
		}

		// Token: 0x06001275 RID: 4725 RVA: 0x0000C6D4 File Offset: 0x0000A8D4
		public static LogicResourceData GetElixirData()
		{
			return LogicDataTables.logicResourceData_2;
		}

		// Token: 0x06001276 RID: 4726 RVA: 0x0000C6DB File Offset: 0x0000A8DB
		public static LogicResourceData GetDarkElixirData()
		{
			return LogicDataTables.logicResourceData_3;
		}

		// Token: 0x06001277 RID: 4727 RVA: 0x0000C6E2 File Offset: 0x0000A8E2
		public static LogicResourceData GetGold2Data()
		{
			return LogicDataTables.logicResourceData_4;
		}

		// Token: 0x06001278 RID: 4728 RVA: 0x0000C6E9 File Offset: 0x0000A8E9
		public static LogicResourceData GetElixir2Data()
		{
			return LogicDataTables.logicResourceData_5;
		}

		// Token: 0x06001279 RID: 4729 RVA: 0x0000C6F0 File Offset: 0x0000A8F0
		public static LogicResourceData GetWarGoldData()
		{
			return LogicDataTables.logicResourceData_6;
		}

		// Token: 0x0600127A RID: 4730 RVA: 0x0000C6F7 File Offset: 0x0000A8F7
		public static LogicResourceData GetWarElixirData()
		{
			return LogicDataTables.logicResourceData_7;
		}

		// Token: 0x0600127B RID: 4731 RVA: 0x0000C6FE File Offset: 0x0000A8FE
		public static LogicResourceData GetWarDarkElixirData()
		{
			return LogicDataTables.logicResourceData_8;
		}

		// Token: 0x040008B5 RID: 2229
		public const int TABLE_COUNT = 44;

		// Token: 0x040008B6 RID: 2230
		private static LogicDataTable[] logicDataTable_0;

		// Token: 0x040008B7 RID: 2231
		private static LogicAnimationTable logicAnimationTable_0;

		// Token: 0x040008B8 RID: 2232
		private static LogicCombatItemData logicCombatItemData_0;

		// Token: 0x040008B9 RID: 2233
		private static LogicCombatItemData logicCombatItemData_1;

		// Token: 0x040008BA RID: 2234
		private static LogicResourceData logicResourceData_0;

		// Token: 0x040008BB RID: 2235
		private static LogicResourceData logicResourceData_1;

		// Token: 0x040008BC RID: 2236
		private static LogicResourceData logicResourceData_2;

		// Token: 0x040008BD RID: 2237
		private static LogicResourceData logicResourceData_3;

		// Token: 0x040008BE RID: 2238
		private static LogicResourceData logicResourceData_4;

		// Token: 0x040008BF RID: 2239
		private static LogicResourceData logicResourceData_5;

		// Token: 0x040008C0 RID: 2240
		private static LogicResourceData logicResourceData_6;

		// Token: 0x040008C1 RID: 2241
		private static LogicResourceData logicResourceData_7;

		// Token: 0x040008C2 RID: 2242
		private static LogicResourceData logicResourceData_8;

		// Token: 0x040008C3 RID: 2243
		private static LogicBuildingData logicBuildingData_0;

		// Token: 0x040008C4 RID: 2244
		private static LogicBuildingData logicBuildingData_1;

		// Token: 0x040008C5 RID: 2245
		private static LogicBuildingData logicBuildingData_2;

		// Token: 0x040008C6 RID: 2246
		private static LogicBuildingData logicBuildingData_3;

		// Token: 0x040008C7 RID: 2247
		private static LogicBuildingData logicBuildingData_4;

		// Token: 0x040008C8 RID: 2248
		private static LogicBuildingData logicBuildingData_5;

		// Token: 0x040008C9 RID: 2249
		private static LogicBuildingData logicBuildingData_6;

		// Token: 0x040008CA RID: 2250
		private static LogicBuildingData logicBuildingData_7;
	}
}
