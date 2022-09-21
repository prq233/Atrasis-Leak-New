using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Mission
{
	// Token: 0x02000026 RID: 38
	public class LogicMission
	{
		// Token: 0x060001B3 RID: 435 RVA: 0x00018E04 File Offset: 0x00017004
		public LogicMission(LogicMissionData data, LogicLevel level)
		{
			if (data == null)
			{
				Debugger.Error("LogicMission::constructor - pData is NULL!");
			}
			this.logicMissionData_0 = data;
			this.logicLevel_0 = level;
			this.int_1 = 1;
			int missionType = data.GetMissionType();
			switch (missionType)
			{
			case 0:
			case 5:
				this.int_1 = data.GetBuildBuildingCount();
				goto IL_77;
			case 1:
				break;
			case 2:
			case 3:
				goto IL_77;
			case 4:
				this.int_1 = data.GetTrainTroopCount();
				goto IL_77;
			default:
				if (missionType - 16 > 3)
				{
					goto IL_77;
				}
				break;
			}
			this.int_1 = 2;
			IL_77:
			if (data.GetMissionCategory() == 1)
			{
				this.int_1 = 0;
			}
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x000031AD File Offset: 0x000013AD
		public void Destruct()
		{
			this.logicMissionData_0 = null;
			this.logicLevel_0 = null;
			this.int_0 = 0;
			this.int_1 = 0;
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x000031CB File Offset: 0x000013CB
		public int GetMissionType()
		{
			return this.logicMissionData_0.GetMissionType();
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x000031D8 File Offset: 0x000013D8
		public LogicMissionData GetMissionData()
		{
			return this.logicMissionData_0;
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x000031E0 File Offset: 0x000013E0
		public int GetProgress()
		{
			return this.int_0;
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x00018E98 File Offset: 0x00017098
		public void RefreshProgress()
		{
			LogicGameObjectManager gameObjectManager = this.logicLevel_0.GetGameObjectManager();
			int missionType = this.logicMissionData_0.GetMissionType();
			switch (missionType)
			{
			case 0:
			case 5:
				this.int_0 = 0;
				if (this.logicLevel_0.GetState() == 1)
				{
					LogicArrayList<LogicGameObject> gameObjects = gameObjectManager.GetGameObjects(LogicGameObjectType.BUILDING);
					for (int i = 0; i < gameObjects.Size(); i++)
					{
						LogicBuilding logicBuilding = (LogicBuilding)gameObjects[i];
						if (logicBuilding.GetBuildingData() == this.logicMissionData_0.GetBuildBuildingData() && (!logicBuilding.IsConstructing() || logicBuilding.IsUpgrading()) && logicBuilding.GetUpgradeLevel() >= this.logicMissionData_0.GetBuildBuildingLevel())
						{
							this.int_0++;
						}
					}
				}
				break;
			case 1:
			case 2:
			case 3:
				break;
			case 4:
				this.int_0 = this.logicLevel_0.GetPlayerAvatar().GetUnitsTotalCapacity();
				break;
			case 6:
				if (this.logicLevel_0.GetPlayerAvatar().GetNameSetByUser())
				{
					this.int_0 = 1;
				}
				break;
			default:
				switch (missionType)
				{
				case 13:
					this.int_0 = 0;
					if (this.logicLevel_0.GetState() == 1)
					{
						LogicArrayList<LogicGameObject> gameObjects2 = gameObjectManager.GetGameObjects(LogicGameObjectType.VILLAGE_OBJECT);
						for (int j = 0; j < gameObjects2.Size(); j++)
						{
							LogicVillageObject logicVillageObject = (LogicVillageObject)gameObjects2[j];
							if (logicVillageObject.GetVillageObjectData() == this.logicMissionData_0.GetFixVillageObjectData() && logicVillageObject.GetUpgradeLevel() >= this.logicMissionData_0.GetBuildBuildingLevel())
							{
								this.int_0++;
							}
						}
					}
					break;
				case 14:
					this.int_0 = 0;
					if (this.logicLevel_0.GetState() == 1 && this.logicLevel_0.GetVillageType() == 1)
					{
						this.int_0++;
					}
					break;
				case 15:
					this.int_0 = 0;
					if (this.logicLevel_0.GetState() == 1)
					{
						LogicArrayList<LogicGameObject> gameObjects3 = gameObjectManager.GetGameObjects(LogicGameObjectType.BUILDING);
						for (int k = 0; k < gameObjects3.Size(); k++)
						{
							LogicBuilding logicBuilding2 = (LogicBuilding)gameObjects3[k];
							if (logicBuilding2.GetBuildingData() == this.logicMissionData_0.GetBuildBuildingData() && !logicBuilding2.IsLocked())
							{
								this.int_0++;
							}
						}
					}
					break;
				case 17:
					this.int_0 = 0;
					if (this.logicLevel_0.GetState() == 1 && this.logicLevel_0.GetVillageType() == 1 && this.logicLevel_0.GetPlayerAvatar().GetUnitUpgradeLevel(this.logicMissionData_0.GetCharacterData()) > 0)
					{
						this.int_0 = 2;
					}
					break;
				}
				break;
			}
			if (this.int_0 >= this.int_1)
			{
				this.int_0 = this.int_1;
				this.Finished();
			}
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x0001916C File Offset: 0x0001736C
		public void StateChangeConfirmed()
		{
			int missionType = this.logicMissionData_0.GetMissionType();
			if (missionType != 1)
			{
				if (missionType - 7 > 4)
				{
					switch (missionType)
					{
					case 16:
						this.int_0++;
						return;
					case 17:
					case 18:
						return;
					case 19:
						if (this.int_0 == 1)
						{
							LogicClientAvatar playerAvatar = this.logicLevel_0.GetPlayerAvatar();
							int village2FirstVictoryTrophies = LogicDataTables.GetGlobals().GetVillage2FirstVictoryTrophies();
							playerAvatar.AddDuelReward(LogicDataTables.GetGlobals().GetVillage2FirstVictoryGold(), LogicDataTables.GetGlobals().GetVillage2FirstVictoryElixir(), 0, 0, null);
							playerAvatar.SetDuelScore(playerAvatar.GetDuelScore() + LogicDataTables.GetGlobals().GetVillage2FirstVictoryTrophies());
							playerAvatar.GetChangeListener().DuelScoreChanged(playerAvatar.GetAllianceId(), village2FirstVictoryTrophies, -1, false);
							this.int_0 = 2;
							this.Finished();
							return;
						}
						return;
					case 20:
					case 21:
						break;
					default:
						return;
					}
				}
				this.int_0 = 1;
				this.Finished();
				return;
			}
			if (this.int_0 == 0)
			{
				this.logicLevel_0.GetGameMode().StartDefendState(LogicNpcAvatar.GetNpcAvatar(this.logicMissionData_0.GetDefendNpcData()));
				this.int_0 = 1;
				return;
			}
		}

		// Token: 0x060001BA RID: 442 RVA: 0x00019280 File Offset: 0x00017480
		public void Finished()
		{
			LogicClientAvatar playerAvatar = this.logicLevel_0.GetPlayerAvatar();
			if (!playerAvatar.IsMissionCompleted(this.logicMissionData_0))
			{
				playerAvatar.SetMissionCompleted(this.logicMissionData_0, true);
				playerAvatar.GetChangeListener().CommodityCountChanged(0, this.logicMissionData_0, 1);
				this.AddRewardUnits();
				LogicResourceData rewardResourceData = this.logicMissionData_0.GetRewardResourceData();
				if (rewardResourceData != null)
				{
					playerAvatar.AddMissionResourceReward(rewardResourceData, this.logicMissionData_0.GetRewardResourceCount());
				}
				int rewardXp = this.logicMissionData_0.GetRewardXp();
				if (rewardXp > 0)
				{
					playerAvatar.XpGainHelper(rewardXp);
				}
			}
			this.bool_0 = true;
		}

		// Token: 0x060001BB RID: 443 RVA: 0x0001930C File Offset: 0x0001750C
		public bool IsOpenTutorialMission()
		{
			if (this.logicMissionData_0.GetVillageType() != this.logicLevel_0.GetVillageType())
			{
				return false;
			}
			if (this.logicMissionData_0.GetMissionCategory() != 2)
			{
				return this.logicMissionData_0.GetMissionCategory() != 1;
			}
			LogicAvatar homeOwnerAvatar = this.logicLevel_0.GetHomeOwnerAvatar();
			if (homeOwnerAvatar != null && homeOwnerAvatar.IsNpcAvatar())
			{
				if (this.logicLevel_0.GetVillageType() == 1)
				{
					return true;
				}
			}
			LogicGameObjectManager gameObjectManagerAt = this.logicLevel_0.GetGameObjectManagerAt(0);
			LogicVillageObject shipyard = gameObjectManagerAt.GetShipyard();
			if (shipyard != null && shipyard.GetUpgradeLevel() == 0)
			{
				return false;
			}
			int missionType = this.logicMissionData_0.GetMissionType();
			return ((missionType != 16 && missionType != 14) || this.logicLevel_0.GetState() != 1 || this.logicLevel_0.GetVillageType() != 0 || !gameObjectManagerAt.GetShipyard().IsConstructing()) && this.logicMissionData_0.GetMissionCategory() != 1;
		}

		// Token: 0x060001BC RID: 444 RVA: 0x000193F4 File Offset: 0x000175F4
		public void Tick()
		{
			int missionType = this.logicMissionData_0.GetMissionType();
			if (missionType <= 2)
			{
				if (missionType != 1)
				{
					if (missionType != 2)
					{
						return;
					}
					if (this.logicLevel_0.GetHomeOwnerAvatar().IsNpcAvatar() && this.logicLevel_0.GetState() == 2)
					{
						this.Finished();
						this.logicLevel_0.GetGameListener().ShowTroopPlacementTutorial(this.logicMissionData_0.GetCustomData());
						return;
					}
				}
				else if (this.logicLevel_0.GetState() == 1 && this.int_0 == 1)
				{
					this.Finished();
					return;
				}
			}
			else if (missionType != 18)
			{
				if (missionType != 19)
				{
					return;
				}
				if (this.logicLevel_0.GetState() == 1 && this.int_0 == 0)
				{
					this.int_0 = 1;
				}
			}
			else if (this.int_0 == 0)
			{
				if (this.logicLevel_0.GetHomeOwnerAvatar().IsNpcAvatar() && this.logicLevel_0.GetState() == 2)
				{
					this.int_0 = 1;
					this.logicLevel_0.GetGameListener().ShowTroopPlacementTutorial(this.logicMissionData_0.GetCustomData());
					return;
				}
			}
			else if (this.int_0 == 1 && this.logicLevel_0.GetHomeOwnerAvatar().IsNpcAvatar() && this.logicLevel_0.GetState() == 2 && this.logicLevel_0.GetBattleLog().GetBattleEnded())
			{
				this.int_0 = 2;
				this.Finished();
				return;
			}
		}

		// Token: 0x060001BD RID: 445 RVA: 0x000031E8 File Offset: 0x000013E8
		public bool IsFinished()
		{
			return this.bool_0;
		}

		// Token: 0x060001BE RID: 446 RVA: 0x00019550 File Offset: 0x00017750
		public void AddRewardUnits()
		{
			LogicCharacterData rewardCharacterData = this.logicMissionData_0.GetRewardCharacterData();
			if (rewardCharacterData != null)
			{
				int rewardCharacterCount = this.logicMissionData_0.GetRewardCharacterCount();
				if (rewardCharacterCount > 0)
				{
					LogicClientAvatar playerAvatar = this.logicLevel_0.GetPlayerAvatar();
					LogicComponentFilter logicComponentFilter = new LogicComponentFilter();
					int i = 0;
					while (i < rewardCharacterCount)
					{
						logicComponentFilter.RemoveAllIgnoreObjects();
						LogicUnitStorageComponent logicUnitStorageComponent;
						for (;;)
						{
							logicUnitStorageComponent = (LogicUnitStorageComponent)this.logicLevel_0.GetComponentManagerAt(this.logicLevel_0.GetVillageType()).GetClosestComponent(0, 0, logicComponentFilter);
							if (logicUnitStorageComponent == null)
							{
								break;
							}
							if (logicUnitStorageComponent.CanAddUnit(rewardCharacterData))
							{
								goto IL_89;
							}
							logicComponentFilter.AddIgnoreObject(logicUnitStorageComponent.GetParent());
						}
						IL_CD:
						i++;
						continue;
						IL_89:
						playerAvatar.CommodityCountChangeHelper(0, rewardCharacterData, 1);
						logicUnitStorageComponent.AddUnit(rewardCharacterData);
						if ((this.logicLevel_0.GetState() == 1 || this.logicLevel_0.GetState() == 3) && logicUnitStorageComponent.GetParentListener() != null)
						{
							logicUnitStorageComponent.GetParentListener().ExtraCharacterAdded(rewardCharacterData, null);
							goto IL_CD;
						}
						goto IL_CD;
					}
				}
			}
		}

		// Token: 0x0400009C RID: 156
		private LogicLevel logicLevel_0;

		// Token: 0x0400009D RID: 157
		private LogicMissionData logicMissionData_0;

		// Token: 0x0400009E RID: 158
		private int int_0;

		// Token: 0x0400009F RID: 159
		private int int_1;

		// Token: 0x040000A0 RID: 160
		private bool bool_0;
	}
}
