using System;
using Atrasis.Magic.Logic.Achievement;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Avatar.Change;
using Atrasis.Magic.Logic.Battle;
using Atrasis.Magic.Logic.Calendar;
using Atrasis.Magic.Logic.Command;
using Atrasis.Magic.Logic.Cooldown;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Home;
using Atrasis.Magic.Logic.Mission;
using Atrasis.Magic.Logic.Mode;
using Atrasis.Magic.Logic.Offer;
using Atrasis.Magic.Logic.Time;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Logic.Worker;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Level
{
	// Token: 0x02000100 RID: 256
	public class LogicLevel
	{
		// Token: 0x06000BA0 RID: 2976 RVA: 0x00025C58 File Offset: 0x00023E58
		public LogicLevel(LogicGameMode gameMode)
		{
			this.logicGameMode_0 = gameMode;
			this.string_1 = string.Empty;
			this.string_0 = string.Empty;
			this.int_9 = -1;
			this.int_1 = -1;
			this.bool_14 = true;
			this.logicTime_0 = new LogicTime();
			this.logicGameListener_0 = new LogicGameListener();
			this.logicAchievementManager_0 = new LogicAchievementManager(this);
			this.logicArrayList_0 = new LogicArrayList<int>();
			this.logicArrayList_3 = new LogicArrayList<string>(4);
			this.logicGameObjectManager_0 = new LogicGameObjectManager[2];
			this.logicWorkerManager_0 = new LogicWorkerManager[2];
			this.logicTileMap_0 = new LogicTileMap(50, 50);
			for (int i = 0; i < 2; i++)
			{
				this.logicWorkerManager_0[i] = new LogicWorkerManager(this);
				this.logicGameObjectManager_0[i] = new LogicGameObjectManager(this.logicTileMap_0, this, i);
			}
			this.int_15 = 25600;
			this.int_16 = 25600;
			this.logicOfferManager_0 = new LogicOfferManager(this);
			this.logicRect_0 = new LogicRect(3, 3, 47, 47);
			this.logicCooldownManager_0 = new LogicCooldownManager();
			this.logicBattleLog_0 = new LogicBattleLog(this);
			this.logicMissionManager_0 = new LogicMissionManager(this);
			this.logicArrayList_0 = new LogicArrayList<int>(8);
			this.logicArrayList_1 = new LogicArrayList<int>(8);
			this.logicArrayList_2 = new LogicArrayList<int>(8);
			this.logicArrayList_6 = new LogicArrayList<LogicDataSlot>();
			this.logicArrayList_7 = new LogicArrayList<int>();
			this.logicArrayList_8 = new LogicArrayList<int>();
			this.logicArrayList_9 = new LogicArrayList<int>();
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.BUILDING);
			LogicDataTable table2 = LogicDataTables.GetTable(LogicDataType.TRAP);
			LogicDataTable table3 = LogicDataTables.GetTable(LogicDataType.DECO);
			this.logicArrayList_7.EnsureCapacity(table.GetItemCount());
			for (int j = 0; j < table.GetItemCount(); j++)
			{
				this.logicArrayList_7.Add(0);
			}
			this.logicArrayList_7.EnsureCapacity(table2.GetItemCount());
			for (int k = 0; k < table2.GetItemCount(); k++)
			{
				this.logicArrayList_8.Add(0);
			}
			this.logicArrayList_7.EnsureCapacity(table3.GetItemCount());
			for (int l = 0; l < table3.GetItemCount(); l++)
			{
				this.logicArrayList_9.Add(0);
			}
			if (LogicDataTables.GetGlobals().LiveReplayEnabled())
			{
				this.int_0 = LogicTime.GetSecondsInTicks(LogicDataTables.GetGlobals().GetLiveReplayUpdateFrequencySecs());
			}
			for (int m = 0; m < 8; m++)
			{
				this.logicArrayList_0.Add(0);
			}
			for (int n = 0; n < 8; n++)
			{
				this.logicArrayList_1.Add(0);
			}
			for (int num = 0; num < 8; num++)
			{
				this.logicArrayList_2.Add(0);
			}
			for (int num2 = 0; num2 < 4; num2++)
			{
				this.logicArrayList_3.Add(string.Empty);
			}
		}

		// Token: 0x06000BA1 RID: 2977 RVA: 0x000088FC File Offset: 0x00006AFC
		public LogicGameMode GetGameMode()
		{
			return this.logicGameMode_0;
		}

		// Token: 0x06000BA2 RID: 2978 RVA: 0x00008904 File Offset: 0x00006B04
		public LogicCalendar GetCalendar()
		{
			return this.logicGameMode_0.GetCalendar();
		}

		// Token: 0x06000BA3 RID: 2979 RVA: 0x00008911 File Offset: 0x00006B11
		public LogicConfiguration GetConfiguration()
		{
			return this.logicGameMode_0.GetConfiguration();
		}

		// Token: 0x06000BA4 RID: 2980 RVA: 0x0000891E File Offset: 0x00006B1E
		public LogicGameListener GetGameListener()
		{
			return this.logicGameListener_0;
		}

		// Token: 0x06000BA5 RID: 2981 RVA: 0x00008926 File Offset: 0x00006B26
		public void SetGameListener(LogicGameListener listener)
		{
			this.logicGameListener_0 = listener;
		}

		// Token: 0x06000BA6 RID: 2982 RVA: 0x0000892F File Offset: 0x00006B2F
		public bool GetInvulnerabilityEnabled()
		{
			return this.bool_10;
		}

		// Token: 0x06000BA7 RID: 2983 RVA: 0x00008937 File Offset: 0x00006B37
		public void SetInvulnerabilityEnabled(bool state)
		{
			this.bool_10 = state;
		}

		// Token: 0x06000BA8 RID: 2984 RVA: 0x00008940 File Offset: 0x00006B40
		public bool IsEditModeShown()
		{
			return this.bool_3;
		}

		// Token: 0x06000BA9 RID: 2985 RVA: 0x00008948 File Offset: 0x00006B48
		public bool GetIgnoreAttack()
		{
			return this.bool_15;
		}

		// Token: 0x06000BAA RID: 2986 RVA: 0x00008950 File Offset: 0x00006B50
		public void SetEditModeShown()
		{
			this.bool_3 = true;
		}

		// Token: 0x06000BAB RID: 2987 RVA: 0x00008959 File Offset: 0x00006B59
		public void SetShieldCostPopupShown(bool seen)
		{
			this.bool_12 = seen;
		}

		// Token: 0x06000BAC RID: 2988 RVA: 0x00008962 File Offset: 0x00006B62
		public void SetHelpOpened(bool opened)
		{
			this.bool_0 = opened;
		}

		// Token: 0x06000BAD RID: 2989 RVA: 0x00008959 File Offset: 0x00006B59
		public void SetAttackShieldCostOpened(bool opened)
		{
			this.bool_12 = opened;
		}

		// Token: 0x06000BAE RID: 2990 RVA: 0x0000896B File Offset: 0x00006B6B
		public int GetPreviousAttackStars()
		{
			return this.int_20;
		}

		// Token: 0x06000BAF RID: 2991 RVA: 0x00008973 File Offset: 0x00006B73
		public int GetState()
		{
			if (this.logicGameMode_0 != null)
			{
				return this.logicGameMode_0.GetState();
			}
			return 0;
		}

		// Token: 0x06000BB0 RID: 2992 RVA: 0x0000898A File Offset: 0x00006B8A
		public int GetMatchType()
		{
			return this.int_13;
		}

		// Token: 0x06000BB1 RID: 2993 RVA: 0x00008992 File Offset: 0x00006B92
		public void SetMatchType(int matchType, LogicLong revengeId)
		{
			this.int_13 = matchType;
			this.logicLong_0 = revengeId;
			if (matchType == 2)
			{
				this.bool_4 = true;
				this.int_15 = 22528;
				this.int_16 = 22528;
			}
		}

		// Token: 0x06000BB2 RID: 2994 RVA: 0x000089C3 File Offset: 0x00006BC3
		public string GetTroopRequestMessage()
		{
			return this.string_1;
		}

		// Token: 0x06000BB3 RID: 2995 RVA: 0x000089CB File Offset: 0x00006BCB
		public void SetTroopRequestMessage(string message)
		{
			this.string_1 = message;
		}

		// Token: 0x06000BB4 RID: 2996 RVA: 0x000089D4 File Offset: 0x00006BD4
		public void SetWarTroopRequestMessage(string message)
		{
			this.string_0 = message;
		}

		// Token: 0x06000BB5 RID: 2997 RVA: 0x000089DD File Offset: 0x00006BDD
		public int GetRemainingClockTowerBoostTime()
		{
			return this.int_14;
		}

		// Token: 0x06000BB6 RID: 2998 RVA: 0x000089E5 File Offset: 0x00006BE5
		public int GetWarLayout()
		{
			return this.int_3;
		}

		// Token: 0x06000BB7 RID: 2999 RVA: 0x000089ED File Offset: 0x00006BED
		public int GetActiveLayout(int villageType)
		{
			if (villageType != 0)
			{
				return this.int_5;
			}
			return this.int_4;
		}

		// Token: 0x06000BB8 RID: 3000 RVA: 0x000089FF File Offset: 0x00006BFF
		public int GetActiveLayout()
		{
			if (this.int_1 != -1)
			{
				if (this.int_1 != 0)
				{
					return this.int_5;
				}
				return this.int_4;
			}
			else
			{
				if (this.int_2 != 0)
				{
					return this.int_5;
				}
				return this.int_4;
			}
		}

		// Token: 0x06000BB9 RID: 3001 RVA: 0x00025F14 File Offset: 0x00024114
		public int GetCurrentLayout()
		{
			if (this.bool_9 && this.logicGameMode_0.GetVisitType() != 5 && this.bool_8)
			{
				return 7;
			}
			if (this.int_13 == 5 || this.logicGameMode_0.GetVisitType() == 4 || this.logicGameMode_0.GetVisitType() == 5 || this.logicGameMode_0.GetVisitType() == 1 || this.logicGameMode_0.GetVillageType() == 1)
			{
				return this.int_3;
			}
			if (this.int_2 == 0)
			{
				return this.int_4;
			}
			return this.int_5;
		}

		// Token: 0x06000BBA RID: 3002 RVA: 0x00008A35 File Offset: 0x00006C35
		public void SetActiveLayout(int layout, int villageType)
		{
			if (villageType == 0)
			{
				this.int_4 = layout;
				return;
			}
			this.int_5 = layout;
		}

		// Token: 0x06000BBB RID: 3003 RVA: 0x00008A49 File Offset: 0x00006C49
		public void SetActiveWarLayout(int layout)
		{
			this.int_3 = layout;
		}

		// Token: 0x06000BBC RID: 3004 RVA: 0x00008A52 File Offset: 0x00006C52
		public void SetLayoutCooldownSecs(int index, int secs)
		{
			if (((long)index & 4294967294L) != 6L && this.int_2 == 0)
			{
				this.logicArrayList_1[index] = 15 * secs;
			}
		}

		// Token: 0x06000BBD RID: 3005 RVA: 0x00008A83 File Offset: 0x00006C83
		public int GetLayoutCooldown(int index)
		{
			return this.logicArrayList_1[index];
		}

		// Token: 0x06000BBE RID: 3006 RVA: 0x00008A91 File Offset: 0x00006C91
		public int GetLayoutState(int idx, int villageType)
		{
			if (villageType == 1)
			{
				return this.logicArrayList_2[idx];
			}
			return this.logicArrayList_0[idx];
		}

		// Token: 0x06000BBF RID: 3007 RVA: 0x00008AB0 File Offset: 0x00006CB0
		public void SetLayoutState(int layoutId, int villageType, int state)
		{
			((villageType == 0) ? this.logicArrayList_0 : this.logicArrayList_2)[layoutId] = state;
		}

		// Token: 0x06000BC0 RID: 3008 RVA: 0x00025FA0 File Offset: 0x000241A0
		public int GetTownHallLevel(int villageType)
		{
			LogicBuilding townHall = this.logicGameObjectManager_0[villageType].GetTownHall();
			if (townHall != null)
			{
				return townHall.GetUpgradeLevel();
			}
			return 0;
		}

		// Token: 0x06000BC1 RID: 3009 RVA: 0x00025FC8 File Offset: 0x000241C8
		public int GetRequiredTownHallLevelForLayout(int layoutId, int villageType)
		{
			if (villageType <= -1)
			{
				villageType = this.int_2;
			}
			if (layoutId > 7)
			{
				Debugger.Warning("unknown layout in getRequiredTownHallLevelForLayout");
				return 10000;
			}
			switch (layoutId)
			{
			case 0:
			case 1:
				return 0;
			case 2:
			case 4:
				if (villageType == 1)
				{
					return LogicDataTables.GetGlobals().GetLayoutTownHallLevelVillage2Slot2();
				}
				return LogicDataTables.GetGlobals().GetLayoutTownHallLevelSlot2();
			case 3:
			case 5:
				if (villageType == 1)
				{
					return LogicDataTables.GetGlobals().GetLayoutTownHallLevelVillage2Slot3();
				}
				return LogicDataTables.GetGlobals().GetLayoutTownHallLevelSlot3();
			default:
				return 0;
			}
		}

		// Token: 0x06000BC2 RID: 3010 RVA: 0x0002604C File Offset: 0x0002424C
		public void SaveLayout(int inputLayoutId, int outputLayoutId)
		{
			int num = this.int_2;
			if (outputLayoutId == 6 || outputLayoutId == 7)
			{
				num = 0;
			}
			LogicArrayList<LogicGameObject> logicArrayList = new LogicArrayList<LogicGameObject>(500);
			LogicGameObjectFilter logicGameObjectFilter = new LogicGameObjectFilter();
			logicGameObjectFilter.AddGameObjectType(LogicGameObjectType.BUILDING);
			logicGameObjectFilter.AddGameObjectType(LogicGameObjectType.TRAP);
			logicGameObjectFilter.AddGameObjectType(LogicGameObjectType.DECO);
			this.logicGameObjectManager_0[num].GetGameObjects(logicArrayList, logicGameObjectFilter);
			for (int i = 0; i < logicArrayList.Size(); i++)
			{
				LogicGameObject logicGameObject = logicArrayList[i];
				LogicVector2 positionLayout = logicGameObject.GetPositionLayout(inputLayoutId, false);
				LogicVector2 positionLayout2 = logicGameObject.GetPositionLayout(inputLayoutId, true);
				logicGameObject.SetPositionLayoutXY(positionLayout.m_x, positionLayout.m_y, outputLayoutId, false);
				logicGameObject.SetPositionLayoutXY(positionLayout2.m_x, positionLayout2.m_y, outputLayoutId, true);
				if (logicGameObject.GetGameObjectType() == LogicGameObjectType.BUILDING)
				{
					LogicCombatComponent combatComponent = logicGameObject.GetCombatComponent(false);
					if (combatComponent != null)
					{
						if (combatComponent.HasAltAttackMode())
						{
							if (combatComponent.UseAltAttackMode(inputLayoutId, false) ^ combatComponent.UseAltAttackMode(outputLayoutId, false))
							{
								combatComponent.ToggleAttackMode(outputLayoutId, false);
							}
							if (combatComponent.UseAltAttackMode(inputLayoutId, true) ^ combatComponent.UseAltAttackMode(outputLayoutId, true))
							{
								combatComponent.ToggleAttackMode(outputLayoutId, true);
							}
						}
						if (combatComponent.GetAttackerItemData().GetTargetingConeAngle() != 0)
						{
							int aimAngle = combatComponent.GetAimAngle(inputLayoutId, false);
							int aimAngle2 = combatComponent.GetAimAngle(outputLayoutId, false);
							if (aimAngle != aimAngle2)
							{
								combatComponent.ToggleAimAngle(aimAngle - aimAngle2, outputLayoutId, false);
							}
						}
					}
				}
				else if (logicGameObject.GetGameObjectType() == LogicGameObjectType.TRAP)
				{
					LogicTrap logicTrap = (LogicTrap)logicGameObject;
					if (logicTrap.HasAirMode())
					{
						if (logicTrap.IsAirMode(inputLayoutId, false) ^ logicTrap.IsAirMode(outputLayoutId, false))
						{
							logicTrap.ToggleAirMode(outputLayoutId, false);
						}
						if (logicTrap.IsAirMode(inputLayoutId, true) ^ logicTrap.IsAirMode(outputLayoutId, true))
						{
							logicTrap.ToggleAirMode(outputLayoutId, true);
						}
					}
				}
			}
			logicArrayList.Destruct();
			logicGameObjectFilter.Destruct();
		}

		// Token: 0x06000BC3 RID: 3011 RVA: 0x00026208 File Offset: 0x00024408
		public int GetBuildingCount(bool includeDestructed, bool includeLocked)
		{
			LogicArrayList<LogicGameObject> gameObjects = this.logicGameObjectManager_0[this.int_2].GetGameObjects(LogicGameObjectType.BUILDING);
			int num = 0;
			for (int i = 0; i < gameObjects.Size(); i++)
			{
				LogicBuilding logicBuilding = (LogicBuilding)gameObjects[i];
				LogicBuildingData buildingData = logicBuilding.GetBuildingData();
				LogicHitpointComponent hitpointComponent = logicBuilding.GetHitpointComponent();
				if (!includeLocked && logicBuilding.IsLocked())
				{
					if (logicBuilding.IsConstructing() && hitpointComponent != null && !buildingData.IsWall())
					{
						if (includeDestructed)
						{
							num++;
						}
						else if (logicBuilding.GetHitpointComponent().GetHitpoints() > 0)
						{
							num++;
						}
					}
				}
				else if (hitpointComponent != null && !buildingData.IsWall())
				{
					if (includeDestructed)
					{
						num++;
					}
					else if (logicBuilding.GetHitpointComponent().GetHitpoints() > 0)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x06000BC4 RID: 3012 RVA: 0x000262C8 File Offset: 0x000244C8
		public int GetTombStoneCount()
		{
			LogicArrayList<LogicGameObject> gameObjects = this.logicGameObjectManager_0[this.int_2].GetGameObjects(LogicGameObjectType.OBSTACLE);
			int num = 0;
			for (int i = 0; i < gameObjects.Size(); i++)
			{
				if (((LogicObstacle)gameObjects[i]).GetObstacleData().IsTombstone())
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000BC5 RID: 3013 RVA: 0x0002631C File Offset: 0x0002451C
		public int GetTallGrassCount()
		{
			LogicArrayList<LogicGameObject> gameObjects = this.logicGameObjectManager_0[this.int_2].GetGameObjects(LogicGameObjectType.OBSTACLE);
			int num = 0;
			for (int i = 0; i < gameObjects.Size(); i++)
			{
				if (((LogicObstacle)gameObjects[i]).GetObstacleData().IsTallGrass())
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000BC6 RID: 3014 RVA: 0x00008ACA File Offset: 0x00006CCA
		public void DefenseStateEnded()
		{
			if (this.logicNpcAttack_0 != null)
			{
				this.logicNpcAttack_0.Destruct();
				this.logicNpcAttack_0 = null;
			}
			this.SetVisitorAvatar(null);
		}

		// Token: 0x06000BC7 RID: 3015 RVA: 0x00026370 File Offset: 0x00024570
		public void DefenseStateStarted(LogicAvatar avatar)
		{
			this.SetVisitorAvatar(avatar);
			if (this.logicNpcAttack_0 != null)
			{
				this.logicNpcAttack_0.Destruct();
				this.logicNpcAttack_0 = null;
			}
			this.logicNpcAttack_0 = new LogicNpcAttack(this);
			this.int_17 = this.GetBuildingCount(false, true);
			this.int_18 = this.GetBuildingCount(true, false);
			if (this.logicBattleLog_0 != null)
			{
				this.logicBattleLog_0.Destruct();
				this.logicBattleLog_0 = null;
			}
			this.logicBattleLog_0 = new LogicBattleLog(this);
			this.logicBattleLog_0.CalculateAvailableResources(this, this.int_13);
			this.SetOwnerInformationToBattleLog();
		}

		// Token: 0x06000BC8 RID: 3016 RVA: 0x00026404 File Offset: 0x00024604
		public int GetUpdatedClockTowerBoostTime()
		{
			LogicBuilding clockTower = this.logicGameObjectManager_0[1].GetClockTower();
			if (clockTower != null && !clockTower.IsConstructing())
			{
				return clockTower.GetRemainingBoostTime();
			}
			return 0;
		}

		// Token: 0x06000BC9 RID: 3017 RVA: 0x00026434 File Offset: 0x00024634
		public int GetUnplacedObjectCount(LogicData data)
		{
			if (this.logicArrayList_6 != null)
			{
				int num = 0;
				for (int i = 0; i < this.logicArrayList_6.Size(); i++)
				{
					if (this.logicArrayList_6[i].GetData() == data)
					{
						num++;
					}
				}
				return num;
			}
			return 0;
		}

		// Token: 0x06000BCA RID: 3018 RVA: 0x0002647C File Offset: 0x0002467C
		public int GetUnplacedObjectCount(LogicData data, int upgradeLevel)
		{
			if (this.logicArrayList_6 != null)
			{
				int num = 0;
				for (int i = 0; i < this.logicArrayList_6.Size(); i++)
				{
					if (this.logicArrayList_6[i].GetData() == data && this.logicArrayList_6[i].GetCount() == upgradeLevel)
					{
						num++;
					}
				}
				return num;
			}
			return 0;
		}

		// Token: 0x06000BCB RID: 3019 RVA: 0x000264D8 File Offset: 0x000246D8
		public bool RemoveUnplacedObject(LogicData data, int upgradeLevel)
		{
			if (this.logicArrayList_6 != null)
			{
				for (int i = 0; i < this.logicArrayList_6.Size(); i++)
				{
					LogicDataSlot logicDataSlot = this.logicArrayList_6[i];
					if (logicDataSlot.GetData() == data && logicDataSlot.GetCount() == upgradeLevel)
					{
						logicDataSlot.SetCount(logicDataSlot.GetCount() - 1);
						this.logicArrayList_6.Remove(i);
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06000BCC RID: 3020 RVA: 0x00026544 File Offset: 0x00024744
		public int GetObjectCount(LogicGameObjectData data, int villageType)
		{
			int num = 0;
			if (this.logicArrayList_6 != null)
			{
				for (int i = 0; i < this.logicArrayList_6.Size(); i++)
				{
					if (this.logicArrayList_6[i].GetData() == data)
					{
						num++;
					}
				}
			}
			return num + this.logicGameObjectManager_0[data.GetVillageType()].GetGameObjectCountByData(data);
		}

		// Token: 0x06000BCD RID: 3021 RVA: 0x00008AED File Offset: 0x00006CED
		public LogicOfferManager GetOfferManager()
		{
			return this.logicOfferManager_0;
		}

		// Token: 0x06000BCE RID: 3022 RVA: 0x00008AF5 File Offset: 0x00006CF5
		public int GetWidth()
		{
			return this.int_15;
		}

		// Token: 0x06000BCF RID: 3023 RVA: 0x00008AFD File Offset: 0x00006CFD
		public int GetHeight()
		{
			return this.int_16;
		}

		// Token: 0x06000BD0 RID: 3024 RVA: 0x00008B05 File Offset: 0x00006D05
		public int GetWidthInTiles()
		{
			return this.logicTileMap_0.GetSizeX();
		}

		// Token: 0x06000BD1 RID: 3025 RVA: 0x00008B12 File Offset: 0x00006D12
		public int GetHeightInTiles()
		{
			return this.logicTileMap_0.GetSizeY();
		}

		// Token: 0x06000BD2 RID: 3026 RVA: 0x00008B1F File Offset: 0x00006D1F
		public int GetExperienceVersion()
		{
			return this.int_11;
		}

		// Token: 0x06000BD3 RID: 3027 RVA: 0x00008B27 File Offset: 0x00006D27
		public void SetExperienceVersion(int version)
		{
			this.int_11 = version;
		}

		// Token: 0x06000BD4 RID: 3028 RVA: 0x00008B30 File Offset: 0x00006D30
		public bool GetBattleEndPending()
		{
			return this.bool_7;
		}

		// Token: 0x06000BD5 RID: 3029 RVA: 0x00008B38 File Offset: 0x00006D38
		public void EndBattle()
		{
			this.bool_7 = true;
		}

		// Token: 0x06000BD6 RID: 3030 RVA: 0x00008B41 File Offset: 0x00006D41
		public int GetVillageType()
		{
			return this.int_2;
		}

		// Token: 0x06000BD7 RID: 3031 RVA: 0x000265A0 File Offset: 0x000247A0
		public void SetVillageType(int villageType)
		{
			this.int_2 = villageType;
			this.logicBattleLog_0.SetVillageType(villageType);
			for (int i = 0; i < 2; i++)
			{
				this.logicGameObjectManager_0[i].ChangeVillageType(i == villageType);
			}
		}

		// Token: 0x06000BD8 RID: 3032 RVA: 0x00008B49 File Offset: 0x00006D49
		public void SetLoadingVillageType(int villageType)
		{
			this.int_1 = villageType;
		}

		// Token: 0x06000BD9 RID: 3033 RVA: 0x00008B52 File Offset: 0x00006D52
		public string GetArmyName(int armyId)
		{
			return this.logicArrayList_3[armyId];
		}

		// Token: 0x06000BDA RID: 3034 RVA: 0x00008B60 File Offset: 0x00006D60
		public bool IsArrangedWar()
		{
			return this.bool_9;
		}

		// Token: 0x06000BDB RID: 3035 RVA: 0x00008B68 File Offset: 0x00006D68
		public void SetArrangedWar(bool enabled)
		{
			this.bool_9 = enabled;
		}

		// Token: 0x06000BDC RID: 3036 RVA: 0x00008B71 File Offset: 0x00006D71
		public bool IsArrangedWarBase()
		{
			return this.bool_8;
		}

		// Token: 0x06000BDD RID: 3037 RVA: 0x00008B79 File Offset: 0x00006D79
		public void SetArmyName(int armyId, string name)
		{
			if (name.Length > 16)
			{
				name = name.Substring(0, 16);
			}
			this.logicArrayList_3[armyId] = name;
		}

		// Token: 0x06000BDE RID: 3038 RVA: 0x00008B9D File Offset: 0x00006D9D
		public bool IsReadyForAttack()
		{
			return this.bool_14;
		}

		// Token: 0x06000BDF RID: 3039 RVA: 0x00008BA5 File Offset: 0x00006DA5
		public LogicBattleLog GetBattleLog()
		{
			return this.logicBattleLog_0;
		}

		// Token: 0x06000BE0 RID: 3040 RVA: 0x00008BAD File Offset: 0x00006DAD
		public LogicTime GetLogicTime()
		{
			return this.logicTime_0;
		}

		// Token: 0x06000BE1 RID: 3041 RVA: 0x00008BB5 File Offset: 0x00006DB5
		public LogicRect GetPlayArea()
		{
			return this.logicRect_0;
		}

		// Token: 0x06000BE2 RID: 3042 RVA: 0x00008BBD File Offset: 0x00006DBD
		public LogicAchievementManager GetAchievementManager()
		{
			return this.logicAchievementManager_0;
		}

		// Token: 0x06000BE3 RID: 3043 RVA: 0x00008BC5 File Offset: 0x00006DC5
		public LogicMissionManager GetMissionManager()
		{
			return this.logicMissionManager_0;
		}

		// Token: 0x06000BE4 RID: 3044 RVA: 0x00008BCD File Offset: 0x00006DCD
		public LogicWorkerManager GetWorkerManager()
		{
			return this.logicWorkerManager_0[this.int_2];
		}

		// Token: 0x06000BE5 RID: 3045 RVA: 0x00008BDC File Offset: 0x00006DDC
		public LogicWorkerManager GetWorkerManagerAt(int index)
		{
			return this.logicWorkerManager_0[index];
		}

		// Token: 0x06000BE6 RID: 3046 RVA: 0x00008BE6 File Offset: 0x00006DE6
		public LogicGameObjectManager GetGameObjectManager()
		{
			return this.logicGameObjectManager_0[this.int_2];
		}

		// Token: 0x06000BE7 RID: 3047 RVA: 0x00008BF5 File Offset: 0x00006DF5
		public LogicGameObjectManager GetGameObjectManagerAt(int index)
		{
			return this.logicGameObjectManager_0[index];
		}

		// Token: 0x06000BE8 RID: 3048 RVA: 0x00008BFF File Offset: 0x00006DFF
		public LogicComponentManager GetComponentManager()
		{
			return this.logicGameObjectManager_0[(this.int_1 < 0) ? this.int_2 : this.int_1].GetComponentManager();
		}

		// Token: 0x06000BE9 RID: 3049 RVA: 0x00008C24 File Offset: 0x00006E24
		public LogicComponentManager GetComponentManagerAt(int villageType)
		{
			return this.logicGameObjectManager_0[villageType].GetComponentManager();
		}

		// Token: 0x06000BEA RID: 3050 RVA: 0x00008C33 File Offset: 0x00006E33
		public LogicCooldownManager GetCooldownManager()
		{
			return this.logicCooldownManager_0;
		}

		// Token: 0x06000BEB RID: 3051 RVA: 0x00008C3B File Offset: 0x00006E3B
		public LogicTileMap GetTileMap()
		{
			return this.logicTileMap_0;
		}

		// Token: 0x06000BEC RID: 3052 RVA: 0x00008C43 File Offset: 0x00006E43
		public LogicClientAvatar GetPlayerAvatar()
		{
			if (this.GetState() != 1 && this.GetState() != 3)
			{
				return (LogicClientAvatar)this.logicAvatar_1;
			}
			return (LogicClientAvatar)this.logicAvatar_0;
		}

		// Token: 0x06000BED RID: 3053 RVA: 0x00008C6E File Offset: 0x00006E6E
		public LogicAvatar GetHomeOwnerAvatar()
		{
			return this.logicAvatar_0;
		}

		// Token: 0x06000BEE RID: 3054 RVA: 0x00008C76 File Offset: 0x00006E76
		public LogicAvatarChangeListener GetHomeOwnerAvatarChangeListener()
		{
			return this.logicAvatar_0.GetChangeListener();
		}

		// Token: 0x06000BEF RID: 3055 RVA: 0x00008C83 File Offset: 0x00006E83
		public LogicLeagueData GetHomeLeagueData()
		{
			if (this.logicGameMode_0.GetState() == 1 && this.logicAvatar_0.IsClientAvatar())
			{
				return ((LogicClientAvatar)this.logicAvatar_0).GetLeagueTypeData();
			}
			return this.logicLeagueData_0;
		}

		// Token: 0x06000BF0 RID: 3056 RVA: 0x00008CB7 File Offset: 0x00006EB7
		public LogicAvatar GetVisitorAvatar()
		{
			return this.logicAvatar_1;
		}

		// Token: 0x06000BF1 RID: 3057 RVA: 0x00008CBF File Offset: 0x00006EBF
		public LogicClientHome GetHome()
		{
			return this.logicClientHome_0;
		}

		// Token: 0x06000BF2 RID: 3058 RVA: 0x000265E0 File Offset: 0x000247E0
		public void UpdateLastUsedArmy()
		{
			LogicClientAvatar playerAvatar = this.GetPlayerAvatar();
			if (this.int_2 == 0)
			{
				playerAvatar.SetLastUsedArmy(playerAvatar.GetUnits(), playerAvatar.GetSpells());
			}
		}

		// Token: 0x06000BF3 RID: 3059 RVA: 0x00026610 File Offset: 0x00024810
		public void SetHome(LogicClientHome home, bool androidClient)
		{
			this.logicOfferManager_0.Init();
			this.logicClientHome_0 = home;
			this.logicJSONObject_0 = (LogicJSONObject)LogicJSONParser.Parse(home.GetHomeJSON());
			LogicJSONBoolean jsonboolean = this.logicJSONObject_0.GetJSONBoolean("android_client");
			LogicJSONBoolean jsonboolean2 = this.logicJSONObject_0.GetJSONBoolean("war_base");
			if (jsonboolean2 != null)
			{
				this.bool_1 = jsonboolean2.IsTrue();
			}
			LogicJSONBoolean jsonboolean3 = this.logicJSONObject_0.GetJSONBoolean("arr_war_base");
			if (jsonboolean3 != null)
			{
				this.bool_8 = jsonboolean3.IsTrue();
			}
			LogicJSONNumber jsonnumber = this.logicJSONObject_0.GetJSONNumber("active_layout");
			if (jsonnumber != null)
			{
				this.int_4 = jsonnumber.GetIntValue();
			}
			LogicJSONNumber jsonnumber2 = this.logicJSONObject_0.GetJSONNumber("act_l2");
			if (jsonnumber2 != null)
			{
				this.int_5 = jsonnumber2.GetIntValue();
			}
			if (this.int_4 < 0)
			{
				this.int_4 = 0;
			}
			if (this.int_5 < 0)
			{
				this.int_5 = 0;
			}
			LogicJSONNumber jsonnumber3 = this.logicJSONObject_0.GetJSONNumber("war_layout");
			if (jsonnumber3 != null)
			{
				this.int_3 = jsonnumber3.GetIntValue();
			}
			else if (this.bool_1)
			{
				this.int_3 = 1;
			}
			if (this.int_3 < 0)
			{
				this.int_3 = 0;
			}
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				this.logicArrayList_0[i] = 0;
			}
			LogicJSONArray jsonarray = this.logicJSONObject_0.GetJSONArray("layout_state");
			if (jsonarray != null)
			{
				int num = jsonarray.Size();
				int num2 = 0;
				while (num2 < this.logicArrayList_0.Size() && num2 < num)
				{
					LogicJSONNumber jsonnumber4 = jsonarray.GetJSONNumber(num2);
					if (jsonnumber4 != null)
					{
						int intValue = jsonnumber4.GetIntValue();
						if (intValue > -1)
						{
							this.logicArrayList_0[num2] = intValue;
						}
					}
					num2++;
				}
			}
			for (int j = 0; j < this.logicArrayList_2.Size(); j++)
			{
				this.logicArrayList_2[j] = 0;
			}
			LogicJSONArray jsonarray2 = this.logicJSONObject_0.GetJSONArray("layout_state2");
			if (jsonarray2 != null)
			{
				int num3 = jsonarray2.Size();
				int num4 = 0;
				while (num4 < this.logicArrayList_2.Size() && num4 < num3)
				{
					LogicJSONNumber jsonnumber5 = jsonarray2.GetJSONNumber(num4);
					if (jsonnumber5 != null)
					{
						int intValue2 = jsonnumber5.GetIntValue();
						if (intValue2 > -1)
						{
							this.logicArrayList_2[num4] = intValue2;
						}
					}
					num4++;
				}
			}
			for (int k = 0; k < this.logicArrayList_1.Size(); k++)
			{
				this.logicArrayList_1[k] = 0;
			}
			LogicJSONArray jsonarray3 = this.logicJSONObject_0.GetJSONArray("layout_cooldown");
			if (jsonarray3 != null)
			{
				int num5 = jsonarray3.Size();
				int num6 = 0;
				while (num6 < this.logicArrayList_1.Size() && num6 < num5)
				{
					LogicJSONNumber jsonnumber6 = jsonarray3.GetJSONNumber(num6);
					if (jsonnumber6 != null)
					{
						int num7 = LogicMath.Min(jsonnumber6.GetIntValue(), 15 * LogicDataTables.GetGlobals().GetChallengeBaseSaveCooldown());
						if (num7 > -1)
						{
							this.logicArrayList_1[num6] = num7;
						}
					}
					num6++;
				}
			}
			if (this.logicArrayList_6 != null)
			{
				this.logicArrayList_6.Clear();
			}
			LogicJSONArray jsonarray4 = this.logicJSONObject_0.GetJSONArray("unplaced");
			if (jsonarray4 != null)
			{
				int num8 = jsonarray4.Size();
				for (int l = 0; l < num8; l++)
				{
					LogicDataSlot logicDataSlot = new LogicDataSlot(null, 0);
					logicDataSlot.ReadFromJSON(jsonarray4.GetJSONObject(l));
					this.AddUnplacedObject(logicDataSlot);
				}
			}
			this.logicGameMode_0.GetCalendar().LoadProgress(this.logicJSONObject_0);
			if (androidClient)
			{
				this.bool_5 = true;
			}
			else if (jsonboolean != null)
			{
				this.bool_5 = jsonboolean.IsTrue();
			}
			LogicJSONNumber jsonnumber7 = this.logicJSONObject_0.GetJSONNumber("wave_num");
			if (jsonnumber7 != null && this.GetState() != 1)
			{
				this.int_10 = jsonnumber7.GetIntValue();
			}
			LogicJSONBoolean jsonboolean4 = this.logicJSONObject_0.GetJSONBoolean("arrWar");
			if (jsonboolean4 != null)
			{
				this.bool_9 = jsonboolean4.IsTrue();
			}
			LogicJSONBoolean jsonboolean5 = this.logicJSONObject_0.GetJSONBoolean("war");
			if (jsonboolean5 != null)
			{
				this.bool_2 = jsonboolean5.IsTrue();
			}
			else
			{
				this.bool_2 = false;
			}
			LogicJSONBoolean jsonboolean6 = this.logicJSONObject_0.GetJSONBoolean("direct");
			LogicJSONBoolean jsonboolean7 = this.logicJSONObject_0.GetJSONBoolean("direct2");
			bool flag;
			if (!(flag = (jsonboolean6 == null || !jsonboolean6.IsTrue())) && this.bool_1)
			{
				this.int_13 = 7;
				this.logicLong_0 = null;
			}
			else if (jsonboolean7 != null && jsonboolean7.IsTrue())
			{
				this.int_13 = 8;
				this.logicLong_0 = null;
			}
			else if (this.bool_1 || !flag)
			{
				this.int_13 = (flag ? 2 : 0) + 3;
				this.logicLong_0 = null;
			}
			if (LogicDataTables.GetGlobals().LoadVillage2AsSnapshot() && ((long)this.int_13 & 4294967294L) == 8L)
			{
				this.int_1 = 0;
				int num9;
				do
				{
					this.logicGameObjectManager_0[this.int_1].LoadFromSnapshot(this.logicJSONObject_0);
					num9 = this.int_1 + 1;
					this.int_1 = num9;
				}
				while (num9 < 2);
				this.int_1 = -1;
			}
			else
			{
				if (this.int_13 != 3 && this.int_13 != 5 && this.int_13 != 7 && this.logicGameMode_0.GetVisitType() != 1 && this.logicGameMode_0.GetVisitType() != 2 && this.logicGameMode_0.GetVisitType() != 3 && this.logicGameMode_0.GetVisitType() != 4)
				{
					if (this.logicGameMode_0.GetVisitType() != 5)
					{
						this.int_1 = 0;
						int num9;
						do
						{
							this.logicGameObjectManager_0[this.int_1].Load(this.logicJSONObject_0);
							num9 = this.int_1 + 1;
							this.int_1 = num9;
						}
						while (num9 < 2);
						this.int_1 = -1;
						this.logicCooldownManager_0.Load(this.logicJSONObject_0);
						this.logicOfferManager_0.Load(this.logicJSONObject_0);
						goto IL_5F9;
					}
				}
				this.logicGameObjectManager_0[0].LoadFromSnapshot(this.logicJSONObject_0);
				if (this.int_13 == 5 && LogicDataTables.GetGlobals().ReadyForWarAttackCheck())
				{
					this.bool_14 = false;
				}
			}
			IL_5F9:
			if (!this.bool_4)
			{
				LogicJSONNumber jsonnumber8 = this.logicJSONObject_0.GetJSONNumber("exp_ver");
				if (jsonnumber8 != null)
				{
					this.int_11 = jsonnumber8.GetIntValue();
				}
				else
				{
					this.int_11 = 0;
				}
				if (this.logicGameMode_0.GetState() != 5)
				{
					while (this.int_11 < 1)
					{
						this.UpdateExperienceVersion(this.int_11);
					}
				}
			}
			this.int_17 = this.GetBuildingCount(false, true);
			this.int_18 = this.GetBuildingCount(true, false);
		}

		// Token: 0x06000BF4 RID: 3060 RVA: 0x00026C8C File Offset: 0x00024E8C
		public void SaveToJSON(LogicJSONObject jsonObject)
		{
			if (!this.bool_4)
			{
				if (this.int_10 > 0)
				{
					jsonObject.Put("wave_num", new LogicJSONNumber(this.int_10));
				}
				if (this.int_11 > 0)
				{
					jsonObject.Put("exp_ver", new LogicJSONNumber(this.int_11));
				}
				if (this.bool_5)
				{
					jsonObject.Put("android_client", new LogicJSONBoolean(true));
				}
				if (this.int_13 == 5 || this.int_13 == 7)
				{
					jsonObject.Put("war", new LogicJSONBoolean(true));
				}
				if (this.int_13 == 3 || this.int_13 == 7)
				{
					jsonObject.Put("direct", new LogicJSONBoolean(true));
				}
				if (this.int_13 == 8)
				{
					jsonObject.Put("direct2", new LogicJSONBoolean(true));
				}
				if (this.bool_9)
				{
					jsonObject.Put("arrWar", new LogicJSONBoolean(true));
				}
				jsonObject.Put("active_layout", new LogicJSONNumber(this.int_4));
				jsonObject.Put("act_l2", new LogicJSONNumber(this.int_5));
				if (this.bool_1)
				{
					LogicDataTables.GetGlobals().RevertBrokenWarLayouts();
					jsonObject.Put("war_layout", new LogicJSONNumber(this.int_3));
				}
				LogicJSONArray logicJSONArray = new LogicJSONArray();
				for (int i = 0; i < this.logicArrayList_0.Size(); i++)
				{
					logicJSONArray.Add(new LogicJSONNumber(this.logicArrayList_0[i]));
				}
				jsonObject.Put("layout_state", logicJSONArray);
				LogicJSONArray logicJSONArray2 = new LogicJSONArray();
				for (int j = 0; j < this.logicArrayList_2.Size(); j++)
				{
					logicJSONArray2.Add(new LogicJSONNumber(this.logicArrayList_2[j]));
				}
				jsonObject.Put("layout_state2", logicJSONArray2);
				LogicJSONArray logicJSONArray3 = new LogicJSONArray();
				for (int k = 0; k < this.logicArrayList_1.Size(); k++)
				{
					logicJSONArray3.Add(new LogicJSONNumber(this.logicArrayList_1[k]));
				}
				jsonObject.Put("layout_cooldown", logicJSONArray3);
			}
			for (int l = 0; l < 2; l++)
			{
				this.logicGameObjectManager_0[l].Save(jsonObject);
			}
			if (!this.bool_4)
			{
				this.logicCooldownManager_0.Save(jsonObject);
				this.method_0(jsonObject);
				jsonObject.Put("last_league_rank", new LogicJSONNumber(this.int_6));
				jsonObject.Put("last_alliance_level", new LogicJSONNumber(this.int_7));
				jsonObject.Put("last_league_shuffle", new LogicJSONNumber(this.bool_11 ? 1 : 0));
				jsonObject.Put("last_season_seen", new LogicJSONNumber(this.int_8));
				jsonObject.Put("last_news_seen", new LogicJSONNumber(this.int_9));
				if (this.string_1.Length > 0)
				{
					jsonObject.Put("troop_req_msg", new LogicJSONString(this.string_1));
				}
				if (this.string_0.Length > 0)
				{
					jsonObject.Put("war_req_msg", new LogicJSONString(this.string_0));
				}
				jsonObject.Put("war_tutorials_seen", new LogicJSONNumber(this.int_12));
				jsonObject.Put("war_base", new LogicJSONBoolean(this.bool_1));
				jsonObject.Put("arr_war_base", new LogicJSONBoolean(this.bool_8));
				LogicJSONArray logicJSONArray4 = new LogicJSONArray();
				for (int m = 0; m < this.logicArrayList_3.Size(); m++)
				{
					logicJSONArray4.Add(new LogicJSONString(this.logicArrayList_3[m]));
				}
				jsonObject.Put("army_names", logicJSONArray4);
				int num = 0;
				if (this.bool_0)
				{
					num |= 1;
				}
				if (this.bool_3)
				{
					num |= 2;
				}
				if (this.bool_12)
				{
					num |= 8;
				}
				jsonObject.Put("account_flags", new LogicJSONNumber(num));
				jsonObject.Put(this.GetPersistentBoolVariableName(0), new LogicJSONBoolean(this.bool_13));
				if (this.logicArrayList_6 != null && this.logicArrayList_6.Size() > 0)
				{
					LogicJSONArray logicJSONArray5 = new LogicJSONArray();
					for (int n = 0; n < this.logicArrayList_6.Size(); n++)
					{
						LogicJSONObject logicJSONObject = new LogicJSONObject();
						this.logicArrayList_6[n].WriteToJSON(logicJSONObject);
						logicJSONArray5.Add(logicJSONObject);
					}
					jsonObject.Put("unplaced", logicJSONArray5);
				}
				this.logicGameMode_0.GetCalendar().SaveProgress(jsonObject);
			}
		}

		// Token: 0x06000BF5 RID: 3061 RVA: 0x000270E4 File Offset: 0x000252E4
		private void method_0(LogicJSONObject logicJSONObject_1)
		{
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.BUILDING);
			LogicDataTable table2 = LogicDataTables.GetTable(LogicDataType.TRAP);
			LogicDataTable table3 = LogicDataTables.GetTable(LogicDataType.DECO);
			int village2TownHallLevel = this.logicAvatar_0.GetVillage2TownHallLevel();
			int townHallLevel = this.logicAvatar_0.GetTownHallLevel();
			int expLevel = this.logicAvatar_0.GetExpLevel();
			LogicJSONArray logicJSONArray = new LogicJSONArray();
			for (int i = 0; i < this.logicArrayList_7.Size(); i++)
			{
				LogicGameObjectData logicGameObjectData = (LogicGameObjectData)table.GetItemAt(i);
				int num = this.logicArrayList_7[i];
				int shopUnlockCount = this.GetShopUnlockCount(logicGameObjectData, (logicGameObjectData.GetVillageType() == 0) ? townHallLevel : village2TownHallLevel);
				logicJSONArray.Add(new LogicJSONNumber(shopUnlockCount - num));
			}
			logicJSONObject_1.Put("newShopBuildings", logicJSONArray);
			LogicJSONArray logicJSONArray2 = new LogicJSONArray();
			for (int j = 0; j < this.logicArrayList_8.Size(); j++)
			{
				LogicGameObjectData logicGameObjectData2 = (LogicGameObjectData)table2.GetItemAt(j);
				int num2 = this.logicArrayList_8[j];
				int shopUnlockCount2 = this.GetShopUnlockCount(logicGameObjectData2, (logicGameObjectData2.GetVillageType() == 0) ? townHallLevel : village2TownHallLevel);
				logicJSONArray2.Add(new LogicJSONNumber(shopUnlockCount2 - num2));
			}
			logicJSONObject_1.Put("newShopTraps", logicJSONArray2);
			LogicJSONArray logicJSONArray3 = new LogicJSONArray();
			for (int k = 0; k < this.logicArrayList_9.Size(); k++)
			{
				int num3 = this.logicArrayList_9[k];
				int shopUnlockCount3 = this.GetShopUnlockCount(table3.GetItemAt(k), expLevel);
				logicJSONArray3.Add(new LogicJSONNumber(shopUnlockCount3 - num3));
			}
			logicJSONObject_1.Put("newShopDecos", logicJSONArray3);
		}

		// Token: 0x06000BF6 RID: 3062 RVA: 0x00027278 File Offset: 0x00025478
		public void LoadShopNewItems()
		{
			if (this.logicJSONObject_0 != null)
			{
				for (int i = 0; i < this.logicArrayList_7.Size(); i++)
				{
					this.logicArrayList_7[i] = 0;
				}
				for (int j = 0; j < this.logicArrayList_8.Size(); j++)
				{
					this.logicArrayList_8[j] = 0;
				}
				for (int k = 0; k < this.logicArrayList_9.Size(); k++)
				{
					this.logicArrayList_9[k] = 0;
				}
				LogicDataTable table = LogicDataTables.GetTable(LogicDataType.BUILDING);
				LogicDataTable table2 = LogicDataTables.GetTable(LogicDataType.TRAP);
				LogicDataTable table3 = LogicDataTables.GetTable(LogicDataType.DECO);
				int village2TownHallLevel = this.logicAvatar_0.GetVillage2TownHallLevel();
				int townHallLevel = this.logicAvatar_0.GetTownHallLevel();
				int expLevel = this.logicAvatar_0.GetExpLevel();
				LogicJSONArray jsonarray = this.logicJSONObject_0.GetJSONArray("newShopBuildings");
				if (jsonarray != null)
				{
					for (int l = 0; l < this.logicArrayList_7.Size(); l++)
					{
						LogicGameObjectData logicGameObjectData = (LogicGameObjectData)table.GetItemAt(l);
						int num = this.GetShopUnlockCount(logicGameObjectData, (logicGameObjectData.GetVillageType() == 0) ? townHallLevel : village2TownHallLevel);
						if (l < jsonarray.Size())
						{
							num -= jsonarray.GetJSONNumber(l).GetIntValue();
							if (num < 0)
							{
								num = 0;
							}
						}
						this.logicArrayList_7[l] = num;
					}
				}
				LogicJSONArray jsonarray2 = this.logicJSONObject_0.GetJSONArray("newShopTraps");
				if (jsonarray2 != null)
				{
					for (int m = 0; m < this.logicArrayList_8.Size(); m++)
					{
						LogicGameObjectData logicGameObjectData2 = (LogicGameObjectData)table2.GetItemAt(m);
						int num2 = this.GetShopUnlockCount(logicGameObjectData2, (logicGameObjectData2.GetVillageType() == 0) ? townHallLevel : village2TownHallLevel);
						if (m < jsonarray2.Size())
						{
							num2 -= jsonarray2.GetJSONNumber(m).GetIntValue();
							if (num2 < 0)
							{
								num2 = 0;
							}
						}
						this.logicArrayList_8[m] = num2;
					}
				}
				LogicJSONArray jsonarray3 = this.logicJSONObject_0.GetJSONArray("newShopDecos");
				if (jsonarray3 != null)
				{
					for (int n = 0; n < this.logicArrayList_9.Size(); n++)
					{
						int num3 = this.GetShopUnlockCount(table3.GetItemAt(n), expLevel);
						if (n < jsonarray3.Size())
						{
							num3 -= jsonarray3.GetJSONNumber(n).GetIntValue();
							if (num3 < 0)
							{
								num3 = 0;
							}
						}
						this.logicArrayList_9[n] = num3;
					}
				}
			}
		}

		// Token: 0x06000BF7 RID: 3063 RVA: 0x000274D4 File Offset: 0x000256D4
		public bool SetUnlockedShopItemCount(LogicGameObjectData data, int index, int count, int villageType)
		{
			if (data.GetVillageType() == villageType)
			{
				LogicDataType dataType = data.GetDataType();
				if (dataType != LogicDataType.BUILDING)
				{
					if (dataType != LogicDataType.TRAP)
					{
						if (dataType != LogicDataType.DECO)
						{
							return false;
						}
						this.logicArrayList_9[index] = count;
					}
					else
					{
						this.logicArrayList_8[index] = count;
					}
				}
				else
				{
					this.logicArrayList_7[index] = count;
				}
				return true;
			}
			return false;
		}

		// Token: 0x06000BF8 RID: 3064 RVA: 0x00008CC7 File Offset: 0x00006EC7
		public int GetLastAllianceLevel()
		{
			return this.int_7;
		}

		// Token: 0x06000BF9 RID: 3065 RVA: 0x00008CCF File Offset: 0x00006ECF
		public void SetLastAllianceLevel(int value)
		{
			this.int_7 = value;
		}

		// Token: 0x06000BFA RID: 3066 RVA: 0x00008CD8 File Offset: 0x00006ED8
		public void SetLastSeenNews(int lastSeenNews)
		{
			if (this.int_9 < lastSeenNews)
			{
				this.int_9 = lastSeenNews;
			}
		}

		// Token: 0x06000BFB RID: 3067 RVA: 0x00008CEA File Offset: 0x00006EEA
		public int GetLastSeenNews()
		{
			return this.int_9;
		}

		// Token: 0x06000BFC RID: 3068 RVA: 0x00008CF2 File Offset: 0x00006EF2
		public int GetLastSeasonSeen()
		{
			return this.int_8;
		}

		// Token: 0x06000BFD RID: 3069 RVA: 0x00008CFA File Offset: 0x00006EFA
		public void SetLastSeasonSeen(int value)
		{
			this.int_8 = value;
		}

		// Token: 0x06000BFE RID: 3070 RVA: 0x00008D03 File Offset: 0x00006F03
		public int GetLastLeagueRank()
		{
			return this.int_6;
		}

		// Token: 0x06000BFF RID: 3071 RVA: 0x00008D0B File Offset: 0x00006F0B
		public void SetLastLeagueRank(int value)
		{
			this.int_6 = value;
		}

		// Token: 0x06000C00 RID: 3072 RVA: 0x00008D14 File Offset: 0x00006F14
		public bool IsLastLeagueShuffle()
		{
			return this.bool_11;
		}

		// Token: 0x06000C01 RID: 3073 RVA: 0x00008D1C File Offset: 0x00006F1C
		public void SetLastLeagueShuffle(bool state)
		{
			this.bool_11 = state;
		}

		// Token: 0x06000C02 RID: 3074 RVA: 0x00027530 File Offset: 0x00025730
		public void RefreshNewShopUnlocksExp()
		{
			int expLevel = this.logicAvatar_0.GetExpLevel();
			if (this.logicAvatar_0.GetExpLevel() > 0)
			{
				LogicDataTable table = LogicDataTables.GetTable(LogicDataType.DECO);
				for (int i = 0; i < this.logicArrayList_9.Size(); i++)
				{
					LogicData itemAt = table.GetItemAt(i);
					int num = this.GetShopUnlockCount(itemAt, expLevel) - this.GetShopUnlockCount(itemAt, expLevel - 1);
					if (num > 0)
					{
						LogicArrayList<int> logicArrayList = this.logicArrayList_9;
						int index = i;
						logicArrayList[index] += num;
					}
				}
			}
		}

		// Token: 0x06000C03 RID: 3075 RVA: 0x00008D25 File Offset: 0x00006F25
		public void RefreshNewShopUnlocksTH(int villageType)
		{
			this.RefreshNewShopUnlocks(villageType);
		}

		// Token: 0x06000C04 RID: 3076 RVA: 0x000275B8 File Offset: 0x000257B8
		public void RefreshNewShopUnlocks(int villageType)
		{
			LogicBuilding townHall = this.logicGameObjectManager_0[villageType].GetTownHall();
			if (townHall != null)
			{
				int upgradeLevel = townHall.GetUpgradeLevel();
				if (upgradeLevel > 0)
				{
					LogicDataTable table = LogicDataTables.GetTable(LogicDataType.BUILDING);
					for (int i = 0; i < this.logicArrayList_7.Size(); i++)
					{
						LogicGameObjectData logicGameObjectData = (LogicGameObjectData)table.GetItemAt(i);
						if (logicGameObjectData.IsEnabledInVillageType(villageType))
						{
							int shopUnlockCount = this.GetShopUnlockCount(logicGameObjectData, upgradeLevel);
							int shopUnlockCount2 = this.GetShopUnlockCount(logicGameObjectData, upgradeLevel - 1);
							if (shopUnlockCount > shopUnlockCount2)
							{
								LogicArrayList<int> logicArrayList = this.logicArrayList_7;
								int index = i;
								logicArrayList[index] += shopUnlockCount - shopUnlockCount2;
							}
						}
					}
					LogicDataTable table2 = LogicDataTables.GetTable(LogicDataType.TRAP);
					for (int j = 0; j < this.logicArrayList_8.Size(); j++)
					{
						LogicGameObjectData logicGameObjectData2 = (LogicGameObjectData)table2.GetItemAt(j);
						if (logicGameObjectData2.IsEnabledInVillageType(villageType))
						{
							int shopUnlockCount3 = this.GetShopUnlockCount(logicGameObjectData2, upgradeLevel);
							int shopUnlockCount4 = this.GetShopUnlockCount(logicGameObjectData2, upgradeLevel - 1);
							if (shopUnlockCount3 > shopUnlockCount4)
							{
								LogicArrayList<int> logicArrayList = this.logicArrayList_8;
								int index = j;
								logicArrayList[index] += shopUnlockCount3 - shopUnlockCount4;
							}
						}
					}
				}
			}
		}

		// Token: 0x06000C05 RID: 3077 RVA: 0x000276E0 File Offset: 0x000258E0
		public void RefreshResourceCaps()
		{
			if (this.logicAvatar_0 != null && this.logicAvatar_0.IsClientAvatar())
			{
				LogicClientAvatar logicClientAvatar = (LogicClientAvatar)this.logicAvatar_0;
				LogicDataTable table = LogicDataTables.GetTable(LogicDataType.RESOURCE);
				int i = 0;
				int num = 0;
				while (i < table.GetItemCount())
				{
					LogicResourceData logicResourceData = (LogicResourceData)table.GetItemAt(i);
					for (int j = 0; j < 2; j++)
					{
						if (logicResourceData.GetWarResourceReferenceData() != null)
						{
							LogicArrayList<LogicComponent> components = this.logicGameObjectManager_0[j].GetComponentManager().GetComponents(LogicComponentType.WAR_RESOURCE_STORAGE);
							for (int k = 0; k < components.Size(); k++)
							{
								LogicWarResourceStorageComponent logicWarResourceStorageComponent = (LogicWarResourceStorageComponent)components[k];
								if (logicWarResourceStorageComponent.IsEnabled())
								{
									num += logicWarResourceStorageComponent.GetMax(i);
								}
							}
						}
						else
						{
							LogicArrayList<LogicComponent> components2 = this.logicGameObjectManager_0[j].GetComponentManager().GetComponents(LogicComponentType.RESOURCE_STORAGE);
							for (int l = 0; l < components2.Size(); l++)
							{
								LogicResourceStorageComponent logicResourceStorageComponent = (LogicResourceStorageComponent)components2[l];
								if (logicResourceStorageComponent.IsEnabled())
								{
									num += logicResourceStorageComponent.GetMax(i);
								}
							}
						}
					}
					if (!logicResourceData.IsPremiumCurrency())
					{
						logicClientAvatar.SetResourceCap(logicResourceData, num);
						logicClientAvatar.GetChangeListener().CommodityCountChanged(1, logicResourceData, num);
					}
					i++;
					num = 0;
				}
			}
		}

		// Token: 0x06000C06 RID: 3078 RVA: 0x00027828 File Offset: 0x00025A28
		public void SetHomeOwnerAvatar(LogicAvatar avatar)
		{
			this.logicAvatar_0 = avatar;
			if (avatar != null)
			{
				avatar.SetLevel(this);
				if (avatar.IsClientAvatar())
				{
					this.int_6 = ((LogicClientAvatar)avatar).GetLeagueType();
				}
				if (this.logicBattleLog_0 != null && avatar.GetName() != null)
				{
					this.logicBattleLog_0.SetDefenderName(avatar.GetName());
				}
				this.logicGameObjectManager_0[0].GetComponentManager().DivideAvatarUnitsToStorages(0);
				this.logicGameObjectManager_0[1].GetComponentManager().DivideAvatarUnitsToStorages(1);
				if (this.int_13 == 5)
				{
					throw new NotImplementedException();
				}
				this.logicGameObjectManager_0[0].GetComponentManager().AddAvatarAllianceUnitsToCastle();
			}
		}

		// Token: 0x06000C07 RID: 3079 RVA: 0x000278CC File Offset: 0x00025ACC
		public void SetVisitorAvatar(LogicAvatar avatar)
		{
			if (this.logicAvatar_1 != avatar && this.logicAvatar_1 != null)
			{
				this.logicAvatar_1.Destruct();
				this.logicAvatar_1 = null;
			}
			this.logicAvatar_1 = avatar;
			if (avatar != null)
			{
				avatar.SetLevel(this);
				if (this.logicBattleLog_0 != null && avatar.IsClientAvatar())
				{
					LogicClientAvatar logicClientAvatar = (LogicClientAvatar)this.logicAvatar_1;
					this.logicLeagueData_1 = logicClientAvatar.GetLeagueTypeData();
					this.logicBattleLog_0.SetAttackerStars(logicClientAvatar.GetStarBonusCounter());
					this.logicBattleLog_0.SetAttackerHomeId(logicClientAvatar.GetCurrentHomeId());
					this.logicBattleLog_0.SetAttackerName(logicClientAvatar.GetName());
					if (avatar.IsInAlliance())
					{
						this.logicBattleLog_0.SetAttackerAllianceId(logicClientAvatar.GetAllianceId());
						this.logicBattleLog_0.SetAttackerAllianceBadge(logicClientAvatar.GetAllianceBadgeId());
						this.logicBattleLog_0.SetAttackerAllianceLevel(logicClientAvatar.GetAllianceLevel());
						string allianceName = logicClientAvatar.GetAllianceName();
						if (allianceName != null)
						{
							this.logicBattleLog_0.SetAttackerAllianceName(allianceName);
							return;
						}
					}
					else
					{
						this.logicBattleLog_0.SetAttackerAllianceBadge(-1);
					}
				}
			}
		}

		// Token: 0x06000C08 RID: 3080 RVA: 0x000279D0 File Offset: 0x00025BD0
		public void SetOwnerInformationToBattleLog()
		{
			if (this.logicAvatar_0.IsClientAvatar())
			{
				LogicClientAvatar logicClientAvatar = (LogicClientAvatar)this.logicAvatar_0;
				if (logicClientAvatar.IsInAlliance())
				{
					this.logicBattleLog_0.SetDefenderAllianceId(logicClientAvatar.GetAllianceId());
					string allianceName = logicClientAvatar.GetAllianceName();
					if (allianceName != null)
					{
						this.logicBattleLog_0.SetDefenderAllianceName(allianceName);
					}
					this.logicBattleLog_0.SetDefenderAllianceBadge(logicClientAvatar.GetAllianceBadgeId());
					this.logicBattleLog_0.SetDefenderAllianceLevel(logicClientAvatar.GetAllianceLevel());
				}
				else
				{
					this.logicBattleLog_0.SetDefenderAllianceBadge(-1);
				}
				this.logicBattleLog_0.SetDefenderHomeId(logicClientAvatar.GetCurrentHomeId());
			}
		}

		// Token: 0x06000C09 RID: 3081 RVA: 0x00008D2E File Offset: 0x00006F2E
		public void SetPersistentBool(int idx, bool value)
		{
			if (idx == 0)
			{
				this.bool_13 = value;
				return;
			}
			Debugger.Warning("setPersistentBool() index out of bounds");
		}

		// Token: 0x06000C0A RID: 3082 RVA: 0x00008D45 File Offset: 0x00006F45
		public string GetPersistentBoolVariableName(int idx)
		{
			if (idx == 0)
			{
				return "bool_layout_edit_shown_erase";
			}
			Debugger.Error("Boolean index out of bounds");
			return null;
		}

		// Token: 0x06000C0B RID: 3083 RVA: 0x00008D5B File Offset: 0x00006F5B
		public void AddUnplacedObject(LogicDataSlot obj)
		{
			if (this.logicArrayList_6 == null)
			{
				this.logicArrayList_6 = new LogicArrayList<LogicDataSlot>();
			}
			this.logicArrayList_6.Add(obj);
		}

		// Token: 0x06000C0C RID: 3084 RVA: 0x00027A68 File Offset: 0x00025C68
		public int GetShopUnlockCount(LogicData data, int arg)
		{
			int num = 0;
			LogicDataType dataType = data.GetDataType();
			if (dataType != LogicDataType.BUILDING)
			{
				if (dataType != LogicDataType.TRAP)
				{
					if (dataType == LogicDataType.DECO)
					{
						LogicDecoData logicDecoData = (LogicDecoData)data;
						if (logicDecoData.GetRequiredExpLevel() <= arg && logicDecoData.IsInShop())
						{
							num = logicDecoData.GetMaxCount();
						}
					}
				}
				else
				{
					num = LogicDataTables.GetTownHallLevel(arg).GetUnlockedTrapCount((LogicTrapData)data);
				}
			}
			else
			{
				LogicBuildingData logicBuildingData = (LogicBuildingData)data;
				if (!logicBuildingData.IsLocked())
				{
					num = LogicDataTables.GetTownHallLevel(arg).GetUnlockedBuildingCount(logicBuildingData) - logicBuildingData.GetStartingHomeCount();
					if (num < 0)
					{
						num = 0;
					}
				}
			}
			return num;
		}

		// Token: 0x06000C0D RID: 3085 RVA: 0x00027AEC File Offset: 0x00025CEC
		public void BattleStarted()
		{
			this.bool_6 = true;
			if (this.int_13 == 4 && !LogicDataTables.GetGlobals().RemoveRevengeWhenBattleIsLoaded())
			{
				this.GetPlayerAvatar().GetChangeListener().RevengeUsed(this.logicLong_0);
			}
			if (this.GetState() != 5 && this.int_13 <= 8)
			{
				if (this.int_13 != 1 && this.int_13 != 3 && this.int_13 != 4)
				{
					if (this.int_13 != 7)
					{
						if (this.int_13 != 5 && this.int_13 != 8)
						{
							return;
						}
						LogicAvatarChangeListener changeListener = this.GetPlayerAvatar().GetChangeListener();
						if (changeListener != null)
						{
							changeListener.BattleFeedback(4, 0);
							return;
						}
						return;
					}
				}
				this.bool_14 = true;
				this.logicAvatar_0.GetChangeListener().AttackStarted();
				this.GetPlayerAvatar().GetChangeListener().AttackStarted();
				return;
			}
		}

		// Token: 0x06000C0E RID: 3086 RVA: 0x00027BBC File Offset: 0x00025DBC
		public bool IsClockTowerBoostPaused()
		{
			LogicBuilding clockTower = this.logicGameObjectManager_0[1].GetClockTower();
			return clockTower != null && clockTower.IsBoostPaused();
		}

		// Token: 0x06000C0F RID: 3087 RVA: 0x00027BE4 File Offset: 0x00025DE4
		public bool IsInCombatState()
		{
			int state = this.GetState();
			return state == 2 || state == 3 || state == 5;
		}

		// Token: 0x06000C10 RID: 3088 RVA: 0x00008D7C File Offset: 0x00006F7C
		public bool IsWarBase()
		{
			return this.bool_1;
		}

		// Token: 0x06000C11 RID: 3089 RVA: 0x00008D84 File Offset: 0x00006F84
		public void SetWarBase(bool enabled)
		{
			this.bool_1 = enabled;
		}

		// Token: 0x06000C12 RID: 3090 RVA: 0x00008D8D File Offset: 0x00006F8D
		public bool IsNpcVillage()
		{
			return this.bool_4;
		}

		// Token: 0x06000C13 RID: 3091 RVA: 0x00008D95 File Offset: 0x00006F95
		public void SetNpcVillage(bool enabled)
		{
			this.bool_4 = enabled;
		}

		// Token: 0x06000C14 RID: 3092 RVA: 0x00027C08 File Offset: 0x00025E08
		public bool IsBuildingGearUpCapReached(LogicBuildingData data, bool canCallListener)
		{
			int levelIndex = 0;
			if (this.logicGameObjectManager_0[this.int_2].GetTownHall() != null)
			{
				levelIndex = this.logicGameObjectManager_0[this.int_2].GetTownHall().GetUpgradeLevel();
			}
			int unlockedBuildingGearupCount = LogicDataTables.GetTownHallLevel(levelIndex).GetUnlockedBuildingGearupCount(data);
			int gearUpBuildingCount = this.logicGameObjectManager_0[this.int_2].GetGearUpBuildingCount(data);
			if (unlockedBuildingGearupCount <= gearUpBuildingCount)
			{
				if (canCallListener)
				{
					this.logicGameListener_0.BuildingCapReached(data);
				}
				return true;
			}
			return false;
		}

		// Token: 0x06000C15 RID: 3093 RVA: 0x00027C78 File Offset: 0x00025E78
		public bool IsBuildingCapReached(LogicBuildingData data, bool canCallListener)
		{
			int levelIndex = 0;
			if (this.logicGameObjectManager_0[this.int_2].GetTownHall() != null)
			{
				levelIndex = this.logicGameObjectManager_0[this.int_2].GetTownHall().GetUpgradeLevel();
			}
			bool flag = this.logicGameObjectManager_0[this.int_2].GetGameObjectCountByData(data) >= LogicDataTables.GetTownHallLevel(levelIndex).GetUnlockedBuildingCount(data);
			if (!flag && canCallListener)
			{
				this.logicGameListener_0.BuildingCapReached(data);
			}
			return flag;
		}

		// Token: 0x06000C16 RID: 3094 RVA: 0x00027CEC File Offset: 0x00025EEC
		public bool IsTrapCapReached(LogicTrapData data, bool canCallListener)
		{
			int levelIndex = 0;
			if (this.logicGameObjectManager_0[this.int_2].GetTownHall() != null)
			{
				levelIndex = this.logicGameObjectManager_0[this.int_2].GetTownHall().GetUpgradeLevel();
			}
			bool flag = this.logicGameObjectManager_0[this.int_2].GetGameObjectCountByData(data) >= LogicDataTables.GetTownHallLevel(levelIndex).GetUnlockedTrapCount(data);
			if (!flag && canCallListener)
			{
				this.logicGameListener_0.TrapCapReached(data);
			}
			return flag;
		}

		// Token: 0x06000C17 RID: 3095 RVA: 0x00027D60 File Offset: 0x00025F60
		public bool IsDecoCapReached(LogicDecoData data, bool canCallListener)
		{
			if (this.logicGameObjectManager_0[this.int_2].GetTownHall() != null)
			{
				this.logicGameObjectManager_0[this.int_2].GetTownHall().GetUpgradeLevel();
			}
			bool flag = true;
			if (this.logicAvatar_0.GetExpLevel() >= data.GetRequiredExpLevel())
			{
				flag = (this.logicGameObjectManager_0[this.int_2].GetGameObjectCountByData(data) >= data.GetMaxCount());
			}
			if (!flag && canCallListener)
			{
				this.logicGameListener_0.DecoCapReached(data);
			}
			return flag;
		}

		// Token: 0x06000C18 RID: 3096 RVA: 0x00027DE4 File Offset: 0x00025FE4
		public bool IsValidPlaceForBuilding(int x, int y, int width, int height, LogicGameObject gameObject)
		{
			if (this.logicRect_0.m_startX <= x && x + width <= this.logicRect_0.m_endX && this.logicRect_0.m_startY <= y && y + height <= this.logicRect_0.m_endY)
			{
				for (int i = 0; i < width; i++)
				{
					for (int j = 0; j < height; j++)
					{
						if (!this.logicTileMap_0.GetTile(x + i, y + j).IsBuildable(gameObject))
						{
							return false;
						}
					}
				}
				return true;
			}
			return false;
		}

		// Token: 0x06000C19 RID: 3097 RVA: 0x00027E68 File Offset: 0x00026068
		public bool IsValidPlaceForObstacle(int x, int y, int width, int height, bool edge, bool ignoreTallGrass)
		{
			if (x >= 0 && y >= 0 && width + x <= 50 && height + y <= 50)
			{
				if (edge)
				{
					x--;
					y--;
					width += 2;
					height += 2;
				}
				for (int i = 0; i < width; i++)
				{
					for (int j = 0; j < height; j++)
					{
						LogicTile tile = this.logicTileMap_0.GetTile(x + i, y + j);
						if (tile != null)
						{
							if (!ignoreTallGrass && tile.GetTallGrass() != null)
							{
								return false;
							}
							if (!tile.IsBuildable(null))
							{
								return false;
							}
						}
					}
				}
				return true;
			}
			return false;
		}

		// Token: 0x06000C1A RID: 3098 RVA: 0x00027EF0 File Offset: 0x000260F0
		public bool IsValidPlaceForBuildingWithIgnoreList(int x, int y, int width, int height, LogicGameObject[] gameObjects, int count)
		{
			if (this.logicRect_0.m_startX <= x && x + width <= this.logicRect_0.m_endX && this.logicRect_0.m_startY <= y && y + height <= this.logicRect_0.m_endY)
			{
				for (int i = 0; i < width; i++)
				{
					for (int j = 0; j < height; j++)
					{
						if (!this.logicTileMap_0.GetTile(x + i, y + j).IsBuildableWithIgnoreList(gameObjects, count))
						{
							return false;
						}
					}
				}
				return true;
			}
			return false;
		}

		// Token: 0x06000C1B RID: 3099 RVA: 0x00027F74 File Offset: 0x00026174
		public bool IsAttackerHeroPlaced(LogicHeroData data)
		{
			if (this.logicArrayList_4 != null)
			{
				for (int i = 0; i < this.logicArrayList_4.Size(); i++)
				{
					if (this.logicArrayList_4[i] == data)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06000C1C RID: 3100 RVA: 0x00027FB8 File Offset: 0x000261B8
		public void SetAttackerHeroPlaced(LogicHeroData data, LogicCharacter hero)
		{
			if (this.logicArrayList_4 == null)
			{
				this.logicArrayList_4 = new LogicArrayList<LogicHeroData>();
				this.logicArrayList_5 = new LogicArrayList<LogicCharacter>();
			}
			if (this.logicArrayList_4.IndexOf(data) == -1)
			{
				this.logicArrayList_5.Add(hero);
				this.logicArrayList_4.Add(data);
				return;
			}
			Debugger.Warning("setAttackerHeroPlaced called twice for same hero");
		}

		// Token: 0x06000C1D RID: 3101 RVA: 0x00008D9E File Offset: 0x00006F9E
		public int GetTotalAttackerHeroPlaced()
		{
			if (this.logicArrayList_4 != null)
			{
				return this.logicArrayList_4.Size();
			}
			return 0;
		}

		// Token: 0x06000C1E RID: 3102 RVA: 0x00028018 File Offset: 0x00026218
		public bool IsUnitsTrainedVillage2()
		{
			LogicArrayList<LogicComponent> components = this.logicGameObjectManager_0[1].GetComponentManager().GetComponents(LogicComponentType.VILLAGE2_UNIT);
			for (int i = 0; i < components.Size(); i++)
			{
				LogicVillage2UnitComponent logicVillage2UnitComponent = (LogicVillage2UnitComponent)components[i];
				if (logicVillage2UnitComponent.IsEnabled() && (logicVillage2UnitComponent.GetUnitData() == null || logicVillage2UnitComponent.GetUnitCount() == 0 || logicVillage2UnitComponent.GetUnitCount() < logicVillage2UnitComponent.GetMaxUnitsInCamp(logicVillage2UnitComponent.GetUnitData())))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000C1F RID: 3103 RVA: 0x00028088 File Offset: 0x00026288
		public bool GetAreaShield(int midX, int midY, LogicVector2 output)
		{
			LogicArrayList<LogicGameObject> gameObjects = this.logicGameObjectManager_0[this.int_2].GetGameObjects(LogicGameObjectType.SPELL);
			int num = int.MaxValue;
			int y = 100;
			for (int i = 0; i < gameObjects.Size(); i++)
			{
				LogicSpell logicSpell = (LogicSpell)gameObjects[i];
				if (logicSpell.IsDeployed() && !logicSpell.GetHitsCompleted())
				{
					LogicSpellData spellData = logicSpell.GetSpellData();
					if (spellData.GetShieldProjectileSpeed(logicSpell.GetUpgradeLevel()) != 0)
					{
						int radius = spellData.GetRadius(spellData.GetRadius(logicSpell.GetUpgradeLevel()));
						int num2 = logicSpell.GetMidX() - midX;
						int num3 = logicSpell.GetMidY() - midY;
						if (LogicMath.Abs(num2) <= radius && LogicMath.Abs(num3) <= radius && (long)(num2 * num2 + num3 * num3) < (long)((ulong)(radius * radius)))
						{
							num = LogicMath.Min(num, spellData.GetShieldProjectileSpeed(logicSpell.GetUpgradeLevel()));
							y = 100 - spellData.GetShieldProjectileDamageMod(logicSpell.GetUpgradeLevel());
						}
					}
				}
			}
			if (this.logicArrayList_5 != null)
			{
				for (int j = 0; j < this.logicArrayList_5.Size(); j++)
				{
					LogicCharacter logicCharacter = this.logicArrayList_5[j];
					if (logicCharacter.GetAbilityTime() > 0 && logicCharacter.IsAlive())
					{
						LogicHeroData logicHeroData = this.logicArrayList_4[j];
						int upgradeLevel = logicCharacter.GetUpgradeLevel();
						int abilityShieldProjectileSpeed = logicHeroData.GetAbilityShieldProjectileSpeed(upgradeLevel);
						if (abilityShieldProjectileSpeed != 0)
						{
							int abilityRadius = logicHeroData.GetAbilityRadius();
							int num4 = logicCharacter.GetMidX() - midX;
							int num5 = logicCharacter.GetMidY() - midY;
							if (LogicMath.Abs(num4) <= abilityRadius && LogicMath.Abs(num5) <= abilityRadius && abilityShieldProjectileSpeed < num && (long)(num4 * num4 + num5 * num5) < (long)((ulong)(abilityRadius * abilityRadius)))
							{
								num = abilityShieldProjectileSpeed;
								y = 100 - logicHeroData.GetAbilityShieldProjectileDamageMod(upgradeLevel);
							}
						}
					}
				}
			}
			output.m_x = num;
			output.m_y = y;
			return num != int.MaxValue;
		}

		// Token: 0x06000C20 RID: 3104 RVA: 0x00028278 File Offset: 0x00026478
		public void AreaPoison(int gameObjectId, int x, int y, int radius, int damage, LogicData preferredTarget, int preferredTargetDamagePecent, LogicEffectData hitEffect, int team, LogicVector2 unk2, int targetType, int damageType, int unk3, bool healing, int heroDamageMultiplier, bool increaseSlowly)
		{
			int num = this.int_1;
			if (num < 0)
			{
				num = this.int_2;
			}
			LogicArrayList<LogicComponent> components = this.GetComponentManagerAt(num).GetComponents(LogicComponentType.HITPOINT);
			LogicVector2 logicVector = new LogicVector2();
			for (int i = 0; i < components.Size(); i++)
			{
				LogicHitpointComponent logicHitpointComponent = (LogicHitpointComponent)components[i];
				LogicGameObject parent = logicHitpointComponent.GetParent();
				if (!parent.IsHidden() && logicHitpointComponent.GetHitpoints() > 0)
				{
					if (logicHitpointComponent.GetTeam() == team)
					{
						if (damage > 0)
						{
							goto IL_21B;
						}
						if (damage < 0 && parent.IsPreventsHealing())
						{
							goto IL_21B;
						}
					}
					else if (damage < 0)
					{
						goto IL_21B;
					}
					if (damageType != 2 || parent.GetGameObjectType() == LogicGameObjectType.CHARACTER)
					{
						LogicMovementComponent movementComponent = parent.GetMovementComponent();
						int num2;
						int num3;
						if (movementComponent == null && !parent.IsFlying())
						{
							int x2 = parent.GetX();
							int y2 = parent.GetY();
							num2 = LogicMath.Clamp(x, x2, x2 + (parent.GetWidthInTiles() << 9));
							num3 = LogicMath.Clamp(y, y2, y2 + (parent.GetHeightInTiles() << 9));
						}
						else
						{
							if (parent.IsFlying())
							{
								if (targetType == 1)
								{
									goto IL_21B;
								}
							}
							else if (targetType == 0)
							{
								goto IL_21B;
							}
							num2 = parent.GetMidX();
							num3 = parent.GetMidY();
						}
						int num4 = x - num2;
						int num5 = y - num3;
						if ((long)(num4 * num4 + num5 * num5) < (long)((ulong)(radius * radius)))
						{
							if (damageType == 1 && parent.GetGameObjectType() == LogicGameObjectType.BUILDING)
							{
								LogicBuilding logicBuilding = (LogicBuilding)parent;
								if (logicBuilding.GetResourceStorageComponentComponent() != null && !logicBuilding.GetBuildingData().IsTownHall() && !logicBuilding.GetBuildingData().IsTownHallVillage2())
								{
									parent.SetDamageTime(10);
									goto IL_21B;
								}
							}
							int num6 = LogicCombatComponent.IsPreferredTarget(preferredTarget, parent) ? (damage * preferredTargetDamagePecent / 100) : damage;
							if (parent.IsHero())
							{
								num6 = ((num6 < 0) ? LogicDataTables.GetGlobals().GetHeroHealMultiplier() : heroDamageMultiplier) * damage / 100;
							}
							logicHitpointComponent.SetPoisonDamage(num6, increaseSlowly);
							if ((num4 | num4) == 0)
							{
								num4 = 1;
							}
							logicVector.m_x = -num4;
							logicVector.m_y = -num5;
							logicVector.Normalize(512);
							if (unk3 > 0 && movementComponent != null)
							{
								movementComponent.GetMovementSystem().PushBack(logicVector, damage, unk3, 0, false, true);
							}
						}
					}
				}
				IL_21B:;
			}
		}

		// Token: 0x06000C21 RID: 3105 RVA: 0x000284B0 File Offset: 0x000266B0
		public void AreaDamage(int gameObjectId, int x, int y, int radius, int damage, LogicData preferredTarget, int preferredTargetDamagePecent, LogicEffectData hitEffect, int team, LogicVector2 unk2, int targetType, int damageType, int unk3, bool gravity, bool healing, int heroDamageMultiplier, int maxUnitsHit, LogicGameObject gameObject, int damageTHPercent, int pauseCombatComponentsMs)
		{
			int num = this.int_1;
			if (num < 0)
			{
				num = this.int_2;
			}
			LogicArrayList<LogicComponent> components = this.GetComponentManagerAt(num).GetComponents(LogicComponentType.HITPOINT);
			LogicVector2 logicVector = new LogicVector2();
			int time = pauseCombatComponentsMs >> 6;
			int num2 = (maxUnitsHit > 0) ? maxUnitsHit : int.MaxValue;
			int num3 = 0;
			int num4 = 0;
			while (num3 < components.Size() && num4 < num2)
			{
				LogicHitpointComponent logicHitpointComponent = (LogicHitpointComponent)components[num3];
				LogicGameObject parent = logicHitpointComponent.GetParent();
				if (!parent.IsHidden() && logicHitpointComponent.GetHitpoints() > 0)
				{
					if (logicHitpointComponent.GetTeam() == team)
					{
						if (damage > 0)
						{
							goto IL_30A;
						}
						if (damage < 0 && parent.IsPreventsHealing())
						{
							goto IL_30A;
						}
					}
					else if (damage < 0)
					{
						goto IL_30A;
					}
					if (damageType != 2 || parent.GetGameObjectType() == LogicGameObjectType.CHARACTER)
					{
						LogicMovementComponent movementComponent = parent.GetMovementComponent();
						int num5;
						int num6;
						if (movementComponent == null && !parent.IsFlying())
						{
							int x2 = parent.GetX();
							int y2 = parent.GetY();
							num5 = LogicMath.Clamp(x, x2, x2 + (parent.GetWidthInTiles() << 9));
							num6 = LogicMath.Clamp(y, y2, y2 + (parent.GetHeightInTiles() << 9));
						}
						else
						{
							if (parent.IsFlying())
							{
								if (targetType == 1)
								{
									goto IL_30A;
								}
							}
							else if (targetType == 0)
							{
								goto IL_30A;
							}
							num5 = parent.GetMidX();
							num6 = parent.GetMidY();
						}
						int num7 = x - num5;
						int num8 = y - num6;
						if (LogicMath.Abs(num7) <= radius && LogicMath.Abs(num8) <= radius && (long)(num7 * num7 + num8 * num8) < (long)((ulong)(radius * radius)))
						{
							if (damageType == 1 && parent.GetGameObjectType() == LogicGameObjectType.BUILDING)
							{
								LogicBuilding logicBuilding = (LogicBuilding)parent;
								if (logicBuilding.GetResourceStorageComponentComponent() != null && !logicBuilding.GetBuildingData().IsTownHall() && !logicBuilding.GetBuildingData().IsTownHallVillage2())
								{
									parent.SetDamageTime(10);
									goto IL_30A;
								}
							}
							int num9 = LogicCombatComponent.IsPreferredTarget(preferredTarget, parent) ? (damage * preferredTargetDamagePecent / 100) : damage;
							if (parent.GetGameObjectType() == LogicGameObjectType.BUILDING && parent.GetData() == LogicDataTables.GetTownHallData())
							{
								num9 = damageTHPercent * num9 / 100;
							}
							if (parent.IsHero())
							{
								num9 = ((num9 < 0) ? LogicDataTables.GetGlobals().GetHeroHealMultiplier() : heroDamageMultiplier) * damage / 100;
							}
							logicHitpointComponent.CauseDamage(num9, gameObjectId, gameObject);
							if (pauseCombatComponentsMs > 0)
							{
								if (parent.GetCombatComponent() != null)
								{
									parent.Freeze(time, 0);
								}
								if (parent.GetMovementComponent() != null)
								{
									parent.Freeze(time, 0);
								}
							}
							if ((num7 | num8) == 0)
							{
								num7 = 1;
								if (unk2 != null && (unk2.m_x | unk2.m_y) != 0)
								{
									num7 = -unk2.m_x;
									num8 = -unk2.m_y;
								}
							}
							num4++;
							logicVector.m_x = -num7;
							logicVector.m_y = -num8;
							logicVector.Normalize(512);
							if (unk3 > 0 && movementComponent != null && !this.bool_10)
							{
								movementComponent.GetMovementSystem().PushBack(logicVector, damage, unk3, 0, false, gravity);
								if (parent.GetGameObjectType() == LogicGameObjectType.BUILDING)
								{
									LogicBuilding logicBuilding2 = (LogicBuilding)parent;
									if (logicBuilding2.GetCombatComponent() != null)
									{
										logicBuilding2.GetCombatComponent().GetAttackerItemData().IsSelfAsAoeCenter();
									}
								}
							}
						}
					}
				}
				IL_30A:
				num3++;
			}
		}

		// Token: 0x06000C22 RID: 3106 RVA: 0x000287DC File Offset: 0x000269DC
		public void AreaFreeze(int x, int y, int radius, int time, int team)
		{
			for (int i = 0; i < 9; i++)
			{
				LogicArrayList<LogicGameObject> gameObjects = this.logicGameObjectManager_0[this.int_2].GetGameObjects((LogicGameObjectType)i);
				for (int j = 0; j < gameObjects.Size(); j++)
				{
					LogicGameObject logicGameObject = gameObjects[j];
					LogicCombatComponent combatComponent = logicGameObject.GetCombatComponent();
					if (combatComponent == null || combatComponent.GetUndergroundTime() <= 0)
					{
						LogicHitpointComponent hitpointComponent = logicGameObject.GetHitpointComponent();
						if (hitpointComponent == null || hitpointComponent.GetTeam() != team)
						{
							int num = x - logicGameObject.GetMidX();
							int num2 = y - logicGameObject.GetMidY();
							if (LogicMath.Abs(num) <= radius && LogicMath.Abs(num2) <= radius && (long)(num * num + num2 * num2) < (long)((ulong)(radius * radius)))
							{
								int time2 = LogicMath.Max(0, time / 4 - (int)((long)(num * num + num2 * num2) / 250000L & 65534L));
								int delay = (int)((long)(num * num + num2 * num2) / 2000000L);
								logicGameObject.Freeze(time2, delay);
							}
						}
					}
				}
			}
		}

		// Token: 0x06000C23 RID: 3107 RVA: 0x000288F0 File Offset: 0x00026AF0
		public void AreaShield(int x, int y, int radius, int time, int team)
		{
			LogicArrayList<LogicComponent> components = this.logicGameObjectManager_0[(this.int_1 < 0) ? this.int_2 : this.int_1].GetComponentManager().GetComponents(LogicComponentType.MOVEMENT);
			for (int i = 0; i < components.Size(); i++)
			{
				LogicGameObject parent = ((LogicMovementComponent)components[i]).GetParent();
				LogicHitpointComponent hitpointComponent = parent.GetHitpointComponent();
				LogicCombatComponent combatComponent = parent.GetCombatComponent();
				if (hitpointComponent != null && combatComponent != null && hitpointComponent.GetTeam() == team)
				{
					int num = x - parent.GetMidX();
					int num2 = y - parent.GetMidY();
					if (LogicMath.Abs(num) <= radius && LogicMath.Abs(num2) <= radius && (long)(num * num + num2 * num2) < (long)((ulong)(radius * radius)))
					{
						hitpointComponent.SetInvulnerabilityTime(time);
						parent.SetPreventsHealingTime(0);
						if (parent.GetGameObjectType() == LogicGameObjectType.CHARACTER)
						{
							LogicArrayList<LogicCharacter> childTroops = ((LogicCharacter)parent).GetChildTroops();
							if (childTroops != null)
							{
								for (int j = 0; j < childTroops.Size(); j++)
								{
									LogicCharacter logicCharacter = childTroops[j];
									logicCharacter.GetHitpointComponent().SetInvulnerabilityTime(time);
									logicCharacter.SetPreventsHealingTime(0);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06000C24 RID: 3108 RVA: 0x00028A10 File Offset: 0x00026C10
		public void AreaShrink(int x, int y, int radius, int speedBoostRatio, int hpRatio, int time, int team)
		{
			for (int i = 0; i < 9; i++)
			{
				LogicArrayList<LogicGameObject> gameObjects = this.logicGameObjectManager_0[this.int_2].GetGameObjects((LogicGameObjectType)i);
				for (int j = 0; j < gameObjects.Size(); j++)
				{
					LogicGameObject logicGameObject = gameObjects[j];
					LogicCombatComponent combatComponent = logicGameObject.GetCombatComponent();
					if (combatComponent == null || combatComponent.GetUndergroundTime() <= 0)
					{
						LogicHitpointComponent hitpointComponent = logicGameObject.GetHitpointComponent();
						if (hitpointComponent == null || hitpointComponent.GetTeam() != team)
						{
							int num = x - logicGameObject.GetMidX();
							int num2 = y - logicGameObject.GetMidY();
							if (LogicMath.Abs(num) <= radius && LogicMath.Abs(num2) <= radius && (long)(num * num + num2 * num2) < (long)((ulong)(radius * radius)))
							{
								logicGameObject.Shrink(time, speedBoostRatio);
								if (hitpointComponent != null && hitpointComponent.GetOriginalHitpoints() == hitpointComponent.GetMaxHitpoints())
								{
									hitpointComponent.SetShrinkHitpoints(time, hpRatio);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06000C25 RID: 3109 RVA: 0x00028AF4 File Offset: 0x00026CF4
		public void AreaInvisibility(int x, int y, int radius, int time, int team)
		{
			for (int i = 0; i < 9; i++)
			{
				LogicArrayList<LogicGameObject> gameObjects = this.logicGameObjectManager_0[this.int_2].GetGameObjects((LogicGameObjectType)i);
				for (int j = 0; j < gameObjects.Size(); j++)
				{
					LogicGameObject logicGameObject = gameObjects[j];
					LogicHitpointComponent hitpointComponent = logicGameObject.GetHitpointComponent();
					LogicCombatComponent combatComponent = logicGameObject.GetCombatComponent();
					if (hitpointComponent != null && combatComponent != null && hitpointComponent.GetTeam() == team)
					{
						int num = x - logicGameObject.GetMidX();
						int num2 = y - logicGameObject.GetMidY();
						if (LogicMath.Abs(num) <= radius && LogicMath.Abs(num2) <= radius && (long)(num * num + num2 * num2) < (long)((ulong)(radius * radius)))
						{
							combatComponent.SetUndergroundTime(time / 4);
						}
					}
				}
			}
		}

		// Token: 0x06000C26 RID: 3110 RVA: 0x00028BAC File Offset: 0x00026DAC
		public void BoostGameObject(LogicGameObject gameObject, int speedBoost, int speedBoost2, int damageBoostPercentage, int attackSpeedBoost, int boostTime, bool boostLinkedToPoison)
		{
			LogicMovementComponent movementComponent = gameObject.GetMovementComponent();
			LogicHitpointComponent hitpointComponent = gameObject.GetHitpointComponent();
			LogicCombatComponent combatComponent = gameObject.GetCombatComponent();
			if (hitpointComponent != null && combatComponent != null)
			{
				int num = damageBoostPercentage;
				if (boostLinkedToPoison)
				{
					int poisonRemainingMS = hitpointComponent.GetPoisonRemainingMS();
					if (60 * poisonRemainingMS / 1000 >= boostTime)
					{
						boostTime = 60 * poisonRemainingMS / 1000;
					}
				}
				if (gameObject.IsHero())
				{
					num = num * LogicDataTables.GetGlobals().GetHeroRageMultiplier() / 100;
				}
				combatComponent.Boost(num, attackSpeedBoost, boostTime / 4);
				if (gameObject.GetGameObjectType() == LogicGameObjectType.CHARACTER)
				{
					LogicArrayList<LogicCharacter> childTroops = ((LogicCharacter)gameObject).GetChildTroops();
					if (childTroops != null)
					{
						for (int i = 0; i < childTroops.Size(); i++)
						{
							childTroops[i].GetCombatComponent().Boost(damageBoostPercentage, attackSpeedBoost, boostTime / 4);
						}
					}
				}
				if (gameObject.GetData().GetDataType() == LogicDataType.CHARACTER && ((LogicCharacter)gameObject).GetAttackerItemData().GetPreferredTargetData() != null)
				{
					if (movementComponent != null)
					{
						movementComponent.GetMovementSystem().Boost(speedBoost2, boostTime);
						return;
					}
				}
				else
				{
					if (gameObject.IsHero())
					{
						speedBoost = (int)((long)(speedBoost * LogicDataTables.GetGlobals().GetHeroRageSpeedMultiplier()) / 100L);
					}
					if (movementComponent != null)
					{
						movementComponent.GetMovementSystem().Boost(speedBoost, boostTime);
					}
				}
			}
		}

		// Token: 0x06000C27 RID: 3111 RVA: 0x00028CDC File Offset: 0x00026EDC
		public void AreaBoost(int x, int y, int radius, int speedBoost, int speedBoost2, int damageBoostPercentage, int attackSpeedBoost, int damageTime, int team, bool boostLinkedToPoison)
		{
			LogicArrayList<LogicComponent> components = this.GetComponentManagerAt((this.int_1 < 0) ? this.int_2 : this.int_1).GetComponents(LogicComponentType.MOVEMENT);
			for (int i = 0; i < components.Size(); i++)
			{
				LogicGameObject parent = ((LogicMovementComponent)components[i]).GetParent();
				LogicHitpointComponent hitpointComponent = parent.GetHitpointComponent();
				LogicCombatComponent combatComponent = parent.GetCombatComponent();
				if (hitpointComponent != null && combatComponent != null && hitpointComponent.GetTeam() == team && hitpointComponent.GetHitpoints() > 0)
				{
					int num = x - parent.GetMidX();
					int num2 = y - parent.GetMidY();
					if (LogicMath.Abs(num) <= radius && LogicMath.Abs(num2) <= radius && (long)(num * num + num2 * num2) < (long)((ulong)(radius * radius)))
					{
						this.BoostGameObject(parent, speedBoost, speedBoost2, damageBoostPercentage, attackSpeedBoost, damageTime, boostLinkedToPoison);
					}
				}
			}
		}

		// Token: 0x06000C28 RID: 3112 RVA: 0x00028DAC File Offset: 0x00026FAC
		public void AreaBoost(int x, int y, int radius, int damageBoostPercentage, int attackSpeedBoost, int damageTime)
		{
			LogicArrayList<LogicComponent> components = this.GetComponentManagerAt((this.int_1 < 0) ? this.int_2 : this.int_1).GetComponents(LogicComponentType.COMBAT);
			for (int i = 0; i < components.Size(); i++)
			{
				LogicCombatComponent logicCombatComponent = (LogicCombatComponent)components[i];
				LogicGameObject parent = logicCombatComponent.GetParent();
				if (parent.GetGameObjectType() == LogicGameObjectType.BUILDING)
				{
					LogicHitpointComponent hitpointComponent = parent.GetHitpointComponent();
					if (hitpointComponent != null && hitpointComponent.GetHitpoints() > 0)
					{
						int num = x - parent.GetMidX();
						int num2 = y - parent.GetMidY();
						if (LogicMath.Abs(num) <= radius && LogicMath.Abs(num2) <= radius && (long)(num * num + num2 * num2) < (long)((ulong)(radius * radius)))
						{
							logicCombatComponent.Boost(damageBoostPercentage, attackSpeedBoost, damageTime);
						}
					}
				}
			}
		}

		// Token: 0x06000C29 RID: 3113 RVA: 0x00028E6C File Offset: 0x0002706C
		public void AreaAbilityBoost(LogicCharacter hero, int time)
		{
			if (hero.IsHero())
			{
				LogicArrayList<LogicComponent> components = this.GetComponentManagerAt((this.int_1 < 0) ? this.int_2 : this.int_1).GetComponents(LogicComponentType.MOVEMENT);
				LogicHeroData logicHeroData = (LogicHeroData)hero.GetData();
				int upgradeLevel = hero.GetUpgradeLevel();
				int x = hero.GetX();
				int y = hero.GetY();
				LogicCharacterData abilityAffectsCharacter = logicHeroData.GetAbilityAffectsCharacter();
				LogicCharacter logicCharacter = logicHeroData.GetAbilityAffectsHero() ? hero : null;
				LogicCharacterData abilitySummonTroop = logicHeroData.GetAbilitySummonTroop();
				int abilitySpeedBoost = logicHeroData.GetAbilitySpeedBoost(upgradeLevel);
				int abilitySpeedBoost2 = logicHeroData.GetAbilitySpeedBoost2(upgradeLevel);
				int abilityDamageBoostPercent = logicHeroData.GetAbilityDamageBoostPercent(upgradeLevel);
				int abilityDamageBoost = logicHeroData.GetAbilityDamageBoost(upgradeLevel);
				int abilitySummonTroopCount = logicHeroData.GetAbilitySummonTroopCount(upgradeLevel);
				int abilityRadius = logicHeroData.GetAbilityRadius();
				int time2 = time * 4;
				for (int i = 0; i < components.Size(); i++)
				{
					LogicMovementComponent logicMovementComponent = (LogicMovementComponent)components[i];
					LogicGameObject parent = logicMovementComponent.GetParent();
					LogicHitpointComponent hitpointComponent = parent.GetHitpointComponent();
					LogicCombatComponent combatComponent = parent.GetCombatComponent();
					if (hitpointComponent != null && combatComponent != null && hitpointComponent.GetTeam() == 0 && hitpointComponent.GetHitpoints() > 0 && parent.GetGameObjectType() == LogicGameObjectType.CHARACTER)
					{
						LogicCharacter logicCharacter2 = (LogicCharacter)parent;
						LogicCharacterData characterData = logicCharacter2.GetCharacterData();
						if ((abilityAffectsCharacter == null || logicCharacter == null || abilityAffectsCharacter == characterData || logicCharacter == parent) && (logicCharacter != null || !logicCharacter2.IsHero()) && (abilityAffectsCharacter != null || characterData.GetDataType() == LogicDataType.HERO) && (characterData == logicHeroData || !logicCharacter2.IsHero()))
						{
							int num = x - logicCharacter2.GetMidX();
							int num2 = y - logicCharacter2.GetMidY();
							if (LogicMath.Abs(num) <= abilityRadius && LogicMath.Abs(num2) <= abilityRadius && (long)(num * num + num2 * num2) < (long)((ulong)(abilityRadius * abilityRadius)))
							{
								if (abilitySpeedBoost > 0 && abilitySpeedBoost2 > 0 && abilityDamageBoostPercent > 0)
								{
									if (logicCharacter2.IsHero())
									{
										if (abilityDamageBoost != 0)
										{
											combatComponent.Boost(abilityDamageBoost, 0, time);
										}
									}
									else
									{
										combatComponent.Boost(abilityDamageBoostPercent, 0, time);
									}
									if (characterData.GetDataType() == LogicDataType.CHARACTER && logicCharacter2.GetAttackerItemData().GetPreferredTargetData() != null)
									{
										logicMovementComponent.GetMovementSystem().Boost(abilitySpeedBoost2, time2);
									}
									else
									{
										logicMovementComponent.GetMovementSystem().Boost(abilitySpeedBoost, time2);
									}
								}
								else if (logicHeroData.GetAbilityStealth())
								{
									if (logicCharacter2.IsHero() && abilityDamageBoost != 0)
									{
										combatComponent.Boost(abilityDamageBoost, 0, time);
									}
									logicCharacter2.SetStealthTime(time);
								}
								if (abilitySummonTroopCount > 0 && logicCharacter2.IsHero())
								{
									logicCharacter2.SpawnEvent(abilitySummonTroop, abilitySummonTroopCount, this.logicAvatar_1.GetUnitUpgradeLevel(abilitySummonTroop));
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06000C2A RID: 3114 RVA: 0x00029100 File Offset: 0x00027300
		public void AreaBoostAlone(LogicCharacter character, int time)
		{
			LogicArrayList<LogicComponent> components = this.GetComponentManagerAt((this.int_1 < 0) ? this.int_2 : this.int_1).GetComponents(LogicComponentType.MOVEMENT);
			LogicCharacterData characterData = character.GetCharacterData();
			int x = character.GetX();
			int y = character.GetY();
			int boostRadius = characterData.GetBoostRadius();
			int damage = characterData.GetBoostDamagePerfect();
			int attackSpeedBoost = characterData.GetBoostAttackSpeed();
			if (characterData.GetSpecialAbilityType() == 7 && character.GetSpecialAbilityAvailable())
			{
				damage = characterData.GetSpecialAbilityAttribute(character.GetUpgradeLevel());
				attackSpeedBoost = characterData.GetSpecialAbilityAttribute2(character.GetUpgradeLevel());
			}
			int num = (character.GetHitpointComponent() != null) ? character.GetHitpointComponent().GetTeam() : -1;
			int num2 = boostRadius * boostRadius;
			bool flag = character.IsFlying();
			bool flag2 = true;
			for (int i = 0; i < components.Size(); i++)
			{
				LogicGameObject parent = ((LogicMovementComponent)components[i]).GetParent();
				LogicHitpointComponent hitpointComponent = parent.GetHitpointComponent();
				LogicCombatComponent combatComponent = parent.GetCombatComponent();
				if (hitpointComponent != null && combatComponent != null && hitpointComponent.GetTeam() == num && hitpointComponent.GetHitpoints() > 0 && parent.GetGameObjectType() == LogicGameObjectType.CHARACTER && parent != character && !(flag ^ parent.IsFlying()))
				{
					int num3 = x - parent.GetMidX();
					int num4 = y - parent.GetMidY();
					if (num3 * num3 + num4 * num4 < num2)
					{
						flag2 = false;
					}
				}
			}
			if (flag2)
			{
				LogicCombatComponent combatComponent2 = character.GetCombatComponent();
				if (combatComponent2 != null)
				{
					combatComponent2.Boost(damage, attackSpeedBoost, time);
				}
			}
		}

		// Token: 0x06000C2B RID: 3115 RVA: 0x00029270 File Offset: 0x00027470
		public void AreaJump(int x, int y, int radius, int time, int housingSpaceLimit, int team)
		{
			LogicArrayList<LogicComponent> components = this.GetComponentManagerAt((this.int_1 < 0) ? this.int_2 : this.int_1).GetComponents(LogicComponentType.MOVEMENT);
			for (int i = 0; i < components.Size(); i++)
			{
				LogicMovementComponent logicMovementComponent = (LogicMovementComponent)components[i];
				LogicGameObject parent = logicMovementComponent.GetParent();
				LogicHitpointComponent hitpointComponent = parent.GetHitpointComponent();
				LogicCombatComponent combatComponent = parent.GetCombatComponent();
				if (hitpointComponent != null && combatComponent != null && hitpointComponent.GetTeam() == team && hitpointComponent.GetHitpoints() > 0)
				{
					if (parent.GetGameObjectType() == LogicGameObjectType.CHARACTER)
					{
						LogicCharacterData characterData = ((LogicCharacter)parent).GetCharacterData();
						if (characterData.GetHousingSpace() > housingSpaceLimit || characterData.IsJumper())
						{
							goto IL_DE;
						}
					}
					int num = x - parent.GetMidX();
					int num2 = y - parent.GetMidY();
					if (LogicMath.Abs(num) <= radius && LogicMath.Abs(num2) <= radius && (long)(num * num + num2 * num2) < (long)((ulong)(radius * radius)))
					{
						logicMovementComponent.EnableJump(time);
					}
				}
				IL_DE:;
			}
		}

		// Token: 0x06000C2C RID: 3116 RVA: 0x0002936C File Offset: 0x0002756C
		public void AreaPushBack(int x, int y, int radius, int time, int team, int targetType, int pushBackX, int pushBackY, int distance, int housingSpaceLimit)
		{
			LogicArrayList<LogicComponent> components = this.GetComponentManagerAt((this.int_1 < 0) ? this.int_2 : this.int_1).GetComponents(LogicComponentType.HITPOINT);
			LogicVector2 logicVector = new LogicVector2();
			for (int i = 0; i < components.Size(); i++)
			{
				LogicHitpointComponent logicHitpointComponent = (LogicHitpointComponent)components[i];
				LogicGameObject parent = logicHitpointComponent.GetParent();
				if (!parent.IsHidden() && logicHitpointComponent.GetHitpoints() != 0 && logicHitpointComponent.GetTeam() != team)
				{
					LogicCombatItemData logicCombatItemData = (LogicCombatItemData)parent.GetData();
					if (housingSpaceLimit >= logicCombatItemData.GetHousingSpace())
					{
						LogicMovementComponent movementComponent = parent.GetMovementComponent();
						int num;
						int num2;
						if (movementComponent == null && !parent.IsFlying())
						{
							num = LogicMath.Clamp(x, parent.GetX(), parent.GetX() + (parent.GetWidthInTiles() << 9));
							num2 = LogicMath.Clamp(y, parent.GetY(), parent.GetY() + (parent.GetHeightInTiles() << 9));
						}
						else
						{
							if (parent.IsFlying())
							{
								if (targetType == 1)
								{
									goto IL_1AB;
								}
							}
							else if (targetType == 0)
							{
								goto IL_1AB;
							}
							num = parent.GetMidX();
							num2 = parent.GetMidY();
						}
						int num3 = x - num;
						int num4 = y - num2;
						if (LogicMath.Abs(num3) <= radius && LogicMath.Abs(num4) <= radius && (long)(num3 * num3 + num4 * num4) < (long)((ulong)(radius * radius)) && time > 0 && movementComponent != null && !this.bool_10)
						{
							logicVector.m_x = (int)((long)(2 * distance * pushBackX) & 4294966784L) / 100;
							logicVector.m_y = (int)((long)(2 * distance * pushBackY) & 4294966784L) / 100;
							movementComponent.GetMovementSystem().PushTrap(logicVector, 1000, 0, true, true);
							housingSpaceLimit -= logicCombatItemData.GetHousingSpace();
						}
					}
				}
				IL_1AB:;
			}
		}

		// Token: 0x06000C2D RID: 3117 RVA: 0x00008DB5 File Offset: 0x00006FB5
		public bool HasFreeWorkers(LogicCommand command, int villageType)
		{
			if (villageType == -1)
			{
				villageType = this.int_2;
			}
			bool flag = this.logicWorkerManager_0[villageType].GetFreeWorkers() > 0;
			if (!flag)
			{
				this.logicGameListener_0.NotEnoughWorkers(command, villageType);
			}
			return flag;
		}

		// Token: 0x06000C2E RID: 3118 RVA: 0x00029534 File Offset: 0x00027734
		public void LoadingFinished()
		{
			for (int i = 0; i < 2; i++)
			{
				this.logicGameObjectManager_0[i].GetComponentManager().DivideAvatarResourcesToStorages();
			}
			this.RefreshResourceCaps();
			for (int j = 0; j < 2; j++)
			{
				this.logicGameObjectManager_0[j].GetComponentManager().CalculateLoot(true);
			}
			if (this.logicBattleLog_0 != null)
			{
				this.logicBattleLog_0.CalculateAvailableResources(this, this.int_13);
				this.SetOwnerInformationToBattleLog();
			}
			if (this.logicGameMode_0.GetState() == 2)
			{
				if (this.int_13 == 1)
				{
					this.logicAvatar_1.CommodityCountChangeHelper(0, LogicDataTables.GetGlobals().GetAttackResource(), -LogicDataTables.GetTownHallLevel(this.logicAvatar_1.GetTownHallLevel()).GetAttackCost());
				}
				else if (this.int_13 == 8)
				{
					this.logicAvatar_1.CommodityCountChangeHelper(0, LogicDataTables.GetGlobals().GetAttackResource(), -LogicDataTables.GetTownHallLevel(this.logicAvatar_1.GetTownHallLevel()).GetAttackCostVillage2());
				}
			}
			for (int k = 0; k < 2; k++)
			{
				this.logicGameObjectManager_0[k].LoadingFinished();
			}
			this.logicMissionManager_0.LoadingFinished();
			this.LoadShopNewItems();
			if (this.logicJSONObject_0 != null)
			{
				this.int_6 = 0;
				this.int_7 = 1;
				LogicJSONNumber jsonnumber = this.logicJSONObject_0.GetJSONNumber("account_flags");
				if (jsonnumber != null)
				{
					int intValue = jsonnumber.GetIntValue();
					this.bool_0 = ((intValue & 1) != 0);
					this.bool_3 = ((intValue >> 1 & 1) != 0);
					this.bool_12 = ((intValue >> 3 & 1) != 0);
				}
				LogicJSONNumber jsonnumber2 = this.logicJSONObject_0.GetJSONNumber("last_league_rank");
				if (jsonnumber2 != null)
				{
					this.int_6 = jsonnumber2.GetIntValue();
				}
				LogicJSONNumber jsonnumber3 = this.logicJSONObject_0.GetJSONNumber("last_alliance_level");
				if (jsonnumber3 != null)
				{
					this.int_7 = jsonnumber3.GetIntValue();
				}
				LogicJSONNumber jsonnumber4 = this.logicJSONObject_0.GetJSONNumber("last_league_shuffle");
				if (jsonnumber4 != null)
				{
					this.bool_11 = (jsonnumber4.GetIntValue() != 0);
				}
				LogicJSONNumber jsonnumber5 = this.logicJSONObject_0.GetJSONNumber("last_season_seen");
				if (jsonnumber5 != null)
				{
					this.int_8 = jsonnumber5.GetIntValue();
				}
				LogicJSONNumber jsonnumber6 = this.logicJSONObject_0.GetJSONNumber("last_news_seen");
				if (jsonnumber6 != null)
				{
					this.int_9 = jsonnumber6.GetIntValue();
				}
				LogicJSONBoolean jsonboolean = this.logicJSONObject_0.GetJSONBoolean("edit_mode_shown");
				if (jsonboolean != null)
				{
					this.bool_3 = jsonboolean.IsTrue();
				}
				LogicJSONString jsonstring = this.logicJSONObject_0.GetJSONString("troop_req_msg");
				if (jsonstring != null)
				{
					this.string_1 = jsonstring.GetStringValue();
				}
				LogicJSONString jsonstring2 = this.logicJSONObject_0.GetJSONString("war_req_msg");
				if (jsonstring2 != null)
				{
					this.string_0 = jsonstring2.GetStringValue();
				}
				LogicJSONNumber jsonnumber7 = this.logicJSONObject_0.GetJSONNumber("war_tutorials_seen");
				if (jsonnumber7 != null)
				{
					this.int_12 = jsonnumber7.GetIntValue();
				}
				LogicJSONArray jsonarray = this.logicJSONObject_0.GetJSONArray("army_names");
				if (jsonarray != null)
				{
					int num = LogicMath.Min(jsonarray.Size(), this.logicArrayList_3.Size());
					for (int l = 0; l < num; l++)
					{
						this.logicArrayList_3[l] = jsonarray.GetJSONString(l).GetStringValue();
					}
				}
				LogicJSONBoolean jsonboolean2 = this.logicJSONObject_0.GetJSONBoolean("help_opened");
				if (jsonboolean2 != null)
				{
					this.bool_0 = jsonboolean2.IsTrue();
				}
				LogicJSONBoolean jsonboolean3 = this.logicJSONObject_0.GetJSONBoolean(this.GetPersistentBoolVariableName(0));
				if (jsonboolean3 != null)
				{
					this.bool_13 = jsonboolean3.IsTrue();
				}
			}
			this.logicAchievementManager_0.RefreshStatus();
			if (LogicDataTables.GetGlobals().ValidateTroopUpgradeLevels())
			{
				for (int m = 0; m < 2; m++)
				{
					this.logicGameObjectManager_0[m].GetComponentManager().ValidateTroopUpgradeLevels();
				}
			}
			if (this.logicGameMode_0.GetState() == 2 && this.int_13 == 4 && LogicDataTables.GetGlobals().RemoveRevengeWhenBattleIsLoaded())
			{
				this.GetPlayerAvatar().GetChangeListener().RevengeUsed(this.logicLong_0);
			}
			this.logicGameMode_0.GetCalendar().UpdateUseTroopEvent(this.logicAvatar_0, this);
			this.logicJSONObject_0 = null;
		}

		// Token: 0x06000C2F RID: 3119 RVA: 0x0002991C File Offset: 0x00027B1C
		public void LoadVillageObjects()
		{
			for (int i = 0; i < 2; i++)
			{
				this.logicGameObjectManager_0[i].LoadVillageObjects();
			}
		}

		// Token: 0x06000C30 RID: 3120 RVA: 0x00029944 File Offset: 0x00027B44
		public void FastForwardTime(int totalSecs)
		{
			for (int i = 0; i < 2; i++)
			{
				this.logicGameObjectManager_0[i].FastForwardTime(totalSecs);
			}
			this.logicOfferManager_0.FastForward(totalSecs);
			this.logicCooldownManager_0.FastForwardTime(totalSecs);
			for (int j = 0; j < this.logicArrayList_1.Size(); j++)
			{
				if (this.logicArrayList_1[j] > 0)
				{
					this.logicArrayList_1[j] = LogicMath.Max(0, this.logicArrayList_1[j] - 15 * totalSecs);
				}
			}
		}

		// Token: 0x06000C31 RID: 3121 RVA: 0x000299CC File Offset: 0x00027BCC
		public void SubTick()
		{
			int num = 0;
			if (this.logicGameObjectManager_0[1].GetClockTower() != null)
			{
				LogicBuilding clockTower = this.logicGameObjectManager_0[1].GetClockTower();
				if (!clockTower.IsBoostPaused() && !clockTower.IsConstructing())
				{
					num = clockTower.GetRemainingBoostTime();
				}
			}
			this.int_14 = num;
			for (int i = 0; i < 2; i++)
			{
				this.logicGameObjectManager_0[i].SubTick();
			}
		}

		// Token: 0x06000C32 RID: 3122 RVA: 0x00029A30 File Offset: 0x00027C30
		public void Tick()
		{
			int state = this.GetState();
			if (state == 2 && !this.bool_6 && this.logicBattleLog_0.GetBattleStarted())
			{
				this.BattleStarted();
			}
			if (state <= 1)
			{
				for (int i = 0; i < 2; i++)
				{
					this.logicGameObjectManager_0[i].Tick();
				}
			}
			else
			{
				this.logicGameObjectManager_0[this.int_2].Tick();
			}
			this.logicMissionManager_0.Tick();
			this.logicAchievementManager_0.Tick();
			this.logicOfferManager_0.Tick();
			if (this.logicNpcAttack_0 != null)
			{
				this.logicNpcAttack_0.Tick();
			}
			this.logicCooldownManager_0.Tick();
			this.UpdateBattleShieldStatus(true);
			for (int j = 0; j < this.logicArrayList_1.Size(); j++)
			{
				int num = this.logicArrayList_1[j];
				if (num > 0)
				{
					this.logicArrayList_1[j] = num - 1;
				}
			}
		}

		// Token: 0x06000C33 RID: 3123 RVA: 0x00029B10 File Offset: 0x00027D10
		public void UpdateExperienceVersion(int prevVersion)
		{
			if (prevVersion == 0)
			{
				LogicGameObjectManager logicGameObjectManager = this.logicGameObjectManager_0[0];
				int i = 0;
				int numGameObjects = logicGameObjectManager.GetNumGameObjects();
				while (i < numGameObjects)
				{
					LogicGameObject gameObjectByIndex = logicGameObjectManager.GetGameObjectByIndex(i);
					int widthInTiles = gameObjectByIndex.GetWidthInTiles();
					int heightInTiles = gameObjectByIndex.GetHeightInTiles();
					for (int j = 0; j < 8; j++)
					{
						int k = 0;
						while (k < 2)
						{
							int num;
							int num2;
							if (k != 0 && j == this.int_4)
							{
								LogicVector2 position = gameObjectByIndex.GetPosition();
								if ((position.m_x & position.m_y) >> 9 != -1)
								{
									num = position.m_x >> 9;
									num2 = position.m_y >> 9;
									goto IL_C5;
								}
							}
							else if (gameObjectByIndex.GetLayoutComponent() != null)
							{
								LogicVector2 positionLayout = gameObjectByIndex.GetPositionLayout(j, k == 0);
								num = positionLayout.m_x;
								num2 = positionLayout.m_y;
								if ((num & num2) != -1)
								{
									goto IL_C5;
								}
							}
							IL_153:
							k++;
							continue;
							IL_C5:
							int num3 = num + 3;
							int num4 = num2 + 3;
							if (gameObjectByIndex.GetGameObjectType() == LogicGameObjectType.OBSTACLE)
							{
								int num5 = 0;
								int num6 = 0;
								if (num < 3)
								{
									num5 -= 3;
								}
								if (num2 < 3)
								{
									num6 -= 3;
								}
								if (num + widthInTiles > 44)
								{
									num5 += 3;
								}
								if (num2 + heightInTiles > 44)
								{
									num6 += 3;
								}
								num3 += num5;
								num4 += num6;
							}
							if (k != 0 && this.int_4 == j)
							{
								gameObjectByIndex.SetPositionXY(num3 << 9, num4 << 9);
								goto IL_153;
							}
							gameObjectByIndex.SetPositionLayoutXY(num3, num4, j, k == 0);
							goto IL_153;
						}
					}
					i++;
				}
				this.int_11 = 1;
			}
		}

		// Token: 0x06000C34 RID: 3124 RVA: 0x00029CA0 File Offset: 0x00027EA0
		public void UpdateBattleShieldStatus(bool unk)
		{
			if (this.logicAvatar_0.IsClientAvatar() && this.logicGameMode_0.GetState() != 5 && (this.int_13 > 7 || (this.int_13 != 3 && this.int_13 != 5 && this.int_13 != 7)))
			{
				LogicGlobals globals = LogicDataTables.GetGlobals();
				int destructionPercentage = this.logicBattleLog_0.GetDestructionPercentage();
				int num = 0;
				if (destructionPercentage >= globals.GetShieldTriggerPercentageHousingSpace())
				{
					num = globals.GetDestructionToShield(destructionPercentage);
				}
				if (num > 0 && !unk)
				{
					LogicClientAvatar logicClientAvatar = (LogicClientAvatar)this.logicAvatar_0;
					LogicLeagueData logicLeagueData = logicClientAvatar.GetLeagueTypeData();
					if (logicLeagueData == null)
					{
						logicLeagueData = (LogicLeagueData)LogicDataTables.GetTable(LogicDataType.LEAGUE).GetItemAt(0);
					}
					int villageGuardInMins = logicLeagueData.GetVillageGuardInMins();
					if (logicClientAvatar.GetAttackShieldReduceCounter() != 0)
					{
						logicClientAvatar.SetAttackShieldReduceCounter(0);
						logicClientAvatar.GetChangeListener().AttackShieldReduceCounterChanged(0);
					}
					if (logicClientAvatar.GetDefenseVillageGuardCounter() != 0)
					{
						logicClientAvatar.SetDefenseVillageGuardCounter(0);
						logicClientAvatar.GetChangeListener().DefenseVillageGuardCounterChanged(0);
					}
					this.logicClientHome_0.GetChangeListener().ShieldActivated(num * 3600, villageGuardInMins * 60);
				}
				if (num > this.int_19)
				{
					this.logicGameListener_0.ShieldActivated(num);
					this.int_19 = num;
				}
			}
		}

		// Token: 0x06000C35 RID: 3125 RVA: 0x00008DE3 File Offset: 0x00006FE3
		public int GetDefenseShieldActivatedHours()
		{
			return this.int_19;
		}

		// Token: 0x06000C36 RID: 3126 RVA: 0x00029DD0 File Offset: 0x00027FD0
		public void UpdateBattleStatus()
		{
			int state = this.logicGameMode_0.GetState();
			Debugger.DoAssert(state == 2 || state == 3 || state == 5, "updateBattleStatus in non combat state.");
			int buildingCount = this.GetBuildingCount(false, true);
			if ((state == 2 || state == 5) && buildingCount < this.int_17)
			{
				this.logicBattleLog_0.SetDestructionPercentage(100 - 100 * buildingCount / this.int_18);
			}
			this.int_17 = buildingCount;
			LogicArrayList<LogicGameObject> gameObjects = this.logicGameObjectManager_0[this.int_2].GetGameObjects(LogicGameObjectType.CHARACTER);
			bool battleWaitForDieDamage = this.logicGameMode_0.GetConfiguration().GetBattleWaitForDieDamage();
			int num = 0;
			for (int i = 0; i < gameObjects.Size(); i++)
			{
				LogicCharacter logicCharacter = (LogicCharacter)gameObjects[i];
				LogicHitpointComponent hitpointComponent = logicCharacter.GetHitpointComponent();
				if (hitpointComponent != null && hitpointComponent.GetTeam() == 0 && logicCharacter.GetAttackerItemData().GetDamage(0, false) > 0 && (hitpointComponent.GetHitpoints() > 0 || (battleWaitForDieDamage && logicCharacter.GetWaitDieDamage())))
				{
					num++;
				}
			}
			bool flag = false;
			bool flag2 = false;
			int num2;
			if (this.int_2 == 1)
			{
				num2 = this.logicAvatar_1.GetUnitsTotalVillage2();
				LogicDataTable table = LogicDataTables.GetTable(LogicDataType.HERO);
				for (int j = 0; j < table.GetItemCount(); j++)
				{
					LogicHeroData logicHeroData = (LogicHeroData)table.GetItemAt(j);
					if (logicHeroData.GetVillageType() == this.int_2 && this.logicAvatar_1.GetHeroState(logicHeroData) != 0 && (this.logicArrayList_4 == null || this.logicArrayList_4.IndexOf(logicHeroData) == -1))
					{
						num2++;
					}
				}
			}
			else
			{
				num2 = this.logicAvatar_1.GetUnitsTotal() + this.logicAvatar_1.GetDamagingSpellsTotal();
				if (LogicDataTables.GetGlobals().FixClanPortalBattleNotEnding() && this.logicGameObjectManager_0[0].GetAlliancePortal() != null)
				{
					num2 += this.logicGameObjectManager_0[0].GetAlliancePortal().GetBunkerComponent().GetUsedCapacity();
				}
				else
				{
					num2 += this.logicAvatar_1.GetAllianceCastleUsedCapacity();
				}
				LogicDataTable table2 = LogicDataTables.GetTable(LogicDataType.HERO);
				for (int k = 0; k < table2.GetItemCount(); k++)
				{
					LogicHeroData logicHeroData2 = (LogicHeroData)table2.GetItemAt(k);
					if (logicHeroData2.GetVillageType() == this.int_2 && this.logicAvatar_1.GetHeroState(logicHeroData2) != 0 && (this.logicArrayList_4 == null || this.logicArrayList_4.IndexOf(logicHeroData2) == -1))
					{
						num2++;
					}
				}
				LogicArrayList<LogicGameObject> gameObjects2 = this.logicGameObjectManager_0[this.int_2].GetGameObjects(LogicGameObjectType.SPELL);
				for (int l = 0; l < gameObjects2.Size(); l++)
				{
					LogicSpell logicSpell = (LogicSpell)gameObjects2[l];
					if (!logicSpell.GetHitsCompleted() && (logicSpell.GetSpellData().IsDamageSpell() || logicSpell.GetSpellData().GetSummonTroop() != null))
					{
						flag = true;
					}
				}
				LogicArrayList<LogicGameObject> gameObjects3 = this.logicGameObjectManager_0[this.int_2].GetGameObjects(LogicGameObjectType.ALLIANCE_PORTAL);
				for (int m = 0; m < gameObjects3.Size(); m++)
				{
					LogicAlliancePortal logicAlliancePortal = (LogicAlliancePortal)gameObjects3[m];
					if (logicAlliancePortal.GetBunkerComponent().GetTeam() == 0 && !logicAlliancePortal.GetBunkerComponent().IsEmpty())
					{
						flag2 = true;
					}
				}
			}
			if ((this.int_13 == 5 || this.int_13 == 8) && this.logicGameMode_0.GetState() != 5)
			{
				this.UpdateBattleFeedback();
			}
			if (buildingCount == 0 || (!flag && !flag2 && (num | num2) == 0 && (this.logicGameObjectManager_0[this.int_2].GetGameObjects(LogicGameObjectType.PROJECTILE).Size() == 0 || !this.logicGameMode_0.GetConfiguration().GetBattleWaitForProjectileDestruction()) && this.int_13 != 6))
			{
				this.bool_7 = true;
			}
		}

		// Token: 0x06000C37 RID: 3127 RVA: 0x0002A158 File Offset: 0x00028358
		public void UpdateBattleFeedback()
		{
			LogicAvatarChangeListener changeListener = this.GetPlayerAvatar().GetChangeListener();
			if (changeListener != null)
			{
				if (!this.bool_16 && this.logicBattleLog_0.GetTownHallDestroyed())
				{
					this.bool_16 = true;
					changeListener.BattleFeedback(3, this.logicBattleLog_0.GetStars());
				}
				if (!this.bool_17 && this.logicBattleLog_0.GetDestructionPercentage() >= 25)
				{
					this.bool_17 = true;
					changeListener.BattleFeedback(0, this.logicBattleLog_0.GetStars());
				}
				if (!this.bool_18 && this.logicBattleLog_0.GetDestructionPercentage() >= 50)
				{
					this.bool_18 = true;
					changeListener.BattleFeedback(1, this.logicBattleLog_0.GetStars());
				}
				if (!this.bool_19 && this.logicBattleLog_0.GetDestructionPercentage() >= 75)
				{
					this.bool_19 = true;
					changeListener.BattleFeedback(2, this.logicBattleLog_0.GetStars());
				}
			}
		}

		// Token: 0x06000C38 RID: 3128 RVA: 0x0002A238 File Offset: 0x00028438
		public void ReengageLootCart(int secs)
		{
			if (this.GetState() == 1)
			{
				LogicGlobals globals = LogicDataTables.GetGlobals();
				if (globals.GetLootCartReengagementMinSeconds() < secs)
				{
					if (globals.GetLootCartReengagementMaxSeconds() <= secs)
					{
						secs = globals.GetLootCartReengagementMaxSeconds();
					}
					int num = globals.GetLootCartReengagementMaxSeconds() - globals.GetLootCartReengagementMinSeconds();
					int num2 = 100 * (secs - globals.GetLootCartReengagementMinSeconds()) / num;
					if (num2 > 0 && this.logicAvatar_0 != null && this.logicAvatar_0.GetTownHallLevel() > 0)
					{
						LogicGameObjectManager logicGameObjectManager = this.logicGameObjectManager_0[0];
						if (logicGameObjectManager.GetLootCart() == null)
						{
							logicGameObjectManager.AddLootCart();
						}
						logicGameObjectManager.GetLootCart().ReengageLootCart(num2);
					}
				}
			}
		}

		// Token: 0x06000C39 RID: 3129 RVA: 0x00008DEB File Offset: 0x00006FEB
		public void DebugResetWarTutorials()
		{
			this.int_12 = 0;
			this.logicMissionManager_0.DebugResetWarTutorials();
		}

		// Token: 0x06000C3A RID: 3130 RVA: 0x0002A2C8 File Offset: 0x000284C8
		public void Destruct()
		{
			for (int i = 0; i < 2; i++)
			{
				if (this.logicGameObjectManager_0[i] != null)
				{
					this.logicGameObjectManager_0[i].Destruct();
					this.logicGameObjectManager_0[i] = null;
				}
				if (this.logicWorkerManager_0[i] != null)
				{
					this.logicWorkerManager_0[i].Destruct();
					this.logicWorkerManager_0[i] = null;
				}
			}
			if (this.logicArrayList_5 != null)
			{
				this.logicArrayList_5.Destruct();
				this.logicArrayList_5 = null;
				this.logicArrayList_4 = null;
			}
			if (this.logicTileMap_0 != null)
			{
				this.logicTileMap_0.Destruct();
				this.logicTileMap_0 = null;
			}
			if (this.logicOfferManager_0 != null)
			{
				this.logicOfferManager_0.Destruct();
				this.logicOfferManager_0 = null;
			}
			if (this.logicAchievementManager_0 != null)
			{
				this.logicAchievementManager_0.Destruct();
				this.logicAchievementManager_0 = null;
			}
			if (this.logicCooldownManager_0 != null)
			{
				this.logicCooldownManager_0.Destruct();
				this.logicCooldownManager_0 = null;
			}
			if (this.logicMissionManager_0 != null)
			{
				this.logicMissionManager_0.Destruct();
				this.logicMissionManager_0 = null;
			}
			if (this.logicBattleLog_0 != null)
			{
				this.logicBattleLog_0.Destruct();
				this.logicBattleLog_0 = null;
			}
			if (this.logicGameListener_0 != null)
			{
				this.logicGameListener_0.Destruct();
				this.logicGameListener_0 = null;
			}
			if (this.logicArrayList_7 != null)
			{
				this.logicArrayList_7.Destruct();
				this.logicArrayList_7 = null;
			}
			if (this.logicArrayList_8 != null)
			{
				this.logicArrayList_8.Destruct();
				this.logicArrayList_8 = null;
			}
			if (this.logicArrayList_9 != null)
			{
				this.logicArrayList_9.Destruct();
				this.logicArrayList_9 = null;
			}
			this.logicArrayList_0.Destruct();
			this.logicArrayList_2.Destruct();
			this.logicArrayList_1.Destruct();
			this.logicArrayList_3.Destruct();
			if (this.logicArrayList_6 != null)
			{
				for (int j = this.logicArrayList_6.Size() - 1; j >= 0; j--)
				{
					this.logicArrayList_6[j].Destruct();
					this.logicArrayList_6.Remove(j);
				}
				this.logicArrayList_6 = null;
			}
			if (this.logicAvatar_0 != null)
			{
				this.logicAvatar_0.SetLevel(null);
				this.logicAvatar_0 = null;
			}
			this.logicJSONObject_0 = null;
			this.logicGameMode_0 = null;
			this.logicClientHome_0 = null;
			this.logicAvatar_1 = null;
			this.logicLong_0 = null;
		}

		// Token: 0x04000498 RID: 1176
		public const int VILLAGE_COUNT = 2;

		// Token: 0x04000499 RID: 1177
		public const int EXPERIENCE_VERSION = 1;

		// Token: 0x0400049A RID: 1178
		public const int LEVEL_WIDTH = 25600;

		// Token: 0x0400049B RID: 1179
		public const int LEVEL_HEIGHT = 25600;

		// Token: 0x0400049C RID: 1180
		public const int NPC_LEVEL_WIDTH = 22528;

		// Token: 0x0400049D RID: 1181
		public const int NPC_LEVEL_HEIGHT = 22528;

		// Token: 0x0400049E RID: 1182
		public const int TILEMAP_SIZE_X = 50;

		// Token: 0x0400049F RID: 1183
		public const int TILEMAP_SIZE_Y = 50;

		// Token: 0x040004A0 RID: 1184
		private readonly LogicTime logicTime_0;

		// Token: 0x040004A1 RID: 1185
		private LogicGameMode logicGameMode_0;

		// Token: 0x040004A2 RID: 1186
		private LogicClientHome logicClientHome_0;

		// Token: 0x040004A3 RID: 1187
		private LogicAvatar logicAvatar_0;

		// Token: 0x040004A4 RID: 1188
		private LogicAvatar logicAvatar_1;

		// Token: 0x040004A5 RID: 1189
		private LogicTileMap logicTileMap_0;

		// Token: 0x040004A6 RID: 1190
		private LogicNpcAttack logicNpcAttack_0;

		// Token: 0x040004A7 RID: 1191
		private LogicRect logicRect_0;

		// Token: 0x040004A8 RID: 1192
		private LogicLeagueData logicLeagueData_0;

		// Token: 0x040004A9 RID: 1193
		private LogicLeagueData logicLeagueData_1;

		// Token: 0x040004AA RID: 1194
		private LogicLong logicLong_0;

		// Token: 0x040004AB RID: 1195
		private readonly LogicGameObjectManager[] logicGameObjectManager_0;

		// Token: 0x040004AC RID: 1196
		private readonly LogicWorkerManager[] logicWorkerManager_0;

		// Token: 0x040004AD RID: 1197
		private LogicOfferManager logicOfferManager_0;

		// Token: 0x040004AE RID: 1198
		private LogicAchievementManager logicAchievementManager_0;

		// Token: 0x040004AF RID: 1199
		private LogicCooldownManager logicCooldownManager_0;

		// Token: 0x040004B0 RID: 1200
		private LogicMissionManager logicMissionManager_0;

		// Token: 0x040004B1 RID: 1201
		private LogicBattleLog logicBattleLog_0;

		// Token: 0x040004B2 RID: 1202
		private LogicGameListener logicGameListener_0;

		// Token: 0x040004B3 RID: 1203
		private LogicJSONObject logicJSONObject_0;

		// Token: 0x040004B4 RID: 1204
		private readonly LogicArrayList<int> logicArrayList_0;

		// Token: 0x040004B5 RID: 1205
		private readonly LogicArrayList<int> logicArrayList_1;

		// Token: 0x040004B6 RID: 1206
		private readonly LogicArrayList<int> logicArrayList_2;

		// Token: 0x040004B7 RID: 1207
		private readonly LogicArrayList<string> logicArrayList_3;

		// Token: 0x040004B8 RID: 1208
		private LogicArrayList<LogicHeroData> logicArrayList_4;

		// Token: 0x040004B9 RID: 1209
		private LogicArrayList<LogicCharacter> logicArrayList_5;

		// Token: 0x040004BA RID: 1210
		private LogicArrayList<LogicDataSlot> logicArrayList_6;

		// Token: 0x040004BB RID: 1211
		private LogicArrayList<int> logicArrayList_7;

		// Token: 0x040004BC RID: 1212
		private LogicArrayList<int> logicArrayList_8;

		// Token: 0x040004BD RID: 1213
		private LogicArrayList<int> logicArrayList_9;

		// Token: 0x040004BE RID: 1214
		private int int_0;

		// Token: 0x040004BF RID: 1215
		private int int_1;

		// Token: 0x040004C0 RID: 1216
		private int int_2;

		// Token: 0x040004C1 RID: 1217
		private int int_3;

		// Token: 0x040004C2 RID: 1218
		private int int_4;

		// Token: 0x040004C3 RID: 1219
		private int int_5;

		// Token: 0x040004C4 RID: 1220
		private int int_6;

		// Token: 0x040004C5 RID: 1221
		private int int_7;

		// Token: 0x040004C6 RID: 1222
		private int int_8;

		// Token: 0x040004C7 RID: 1223
		private int int_9;

		// Token: 0x040004C8 RID: 1224
		private int int_10;

		// Token: 0x040004C9 RID: 1225
		private int int_11;

		// Token: 0x040004CA RID: 1226
		private int int_12;

		// Token: 0x040004CB RID: 1227
		private int int_13;

		// Token: 0x040004CC RID: 1228
		private int int_14;

		// Token: 0x040004CD RID: 1229
		private int int_15;

		// Token: 0x040004CE RID: 1230
		private int int_16;

		// Token: 0x040004CF RID: 1231
		private int int_17;

		// Token: 0x040004D0 RID: 1232
		private int int_18;

		// Token: 0x040004D1 RID: 1233
		private int int_19;

		// Token: 0x040004D2 RID: 1234
		private int int_20;

		// Token: 0x040004D3 RID: 1235
		private bool bool_0;

		// Token: 0x040004D4 RID: 1236
		private bool bool_1;

		// Token: 0x040004D5 RID: 1237
		private bool bool_2;

		// Token: 0x040004D6 RID: 1238
		private bool bool_3;

		// Token: 0x040004D7 RID: 1239
		private bool bool_4;

		// Token: 0x040004D8 RID: 1240
		private bool bool_5;

		// Token: 0x040004D9 RID: 1241
		private bool bool_6;

		// Token: 0x040004DA RID: 1242
		private bool bool_7;

		// Token: 0x040004DB RID: 1243
		private bool bool_8;

		// Token: 0x040004DC RID: 1244
		private bool bool_9;

		// Token: 0x040004DD RID: 1245
		private bool bool_10;

		// Token: 0x040004DE RID: 1246
		private bool bool_11;

		// Token: 0x040004DF RID: 1247
		private bool bool_12;

		// Token: 0x040004E0 RID: 1248
		private bool bool_13;

		// Token: 0x040004E1 RID: 1249
		private bool bool_14;

		// Token: 0x040004E2 RID: 1250
		private bool bool_15;

		// Token: 0x040004E3 RID: 1251
		private bool bool_16;

		// Token: 0x040004E4 RID: 1252
		private bool bool_17;

		// Token: 0x040004E5 RID: 1253
		private bool bool_18;

		// Token: 0x040004E6 RID: 1254
		private bool bool_19;

		// Token: 0x040004E7 RID: 1255
		private string string_0;

		// Token: 0x040004E8 RID: 1256
		private string string_1;
	}
}
