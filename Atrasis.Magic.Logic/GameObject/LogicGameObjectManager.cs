using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.GameObject.Listener;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Mode;
using Atrasis.Magic.Logic.Time;
using Atrasis.Magic.Logic.Unit;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.GameObject
{
	// Token: 0x02000114 RID: 276
	public sealed class LogicGameObjectManager
	{
		// Token: 0x06000DC7 RID: 3527 RVA: 0x00030CCC File Offset: 0x0002EECC
		public LogicGameObjectManager(LogicTileMap tileMap, LogicLevel level, int villageType)
		{
			this.logicLevel_0 = level;
			this.logicTileMap_0 = tileMap;
			this.int_0 = villageType;
			this.int_1 = new int[9];
			this.logicArrayList_0 = new LogicArrayList<LogicGameObject>[9];
			for (int i = 0; i < 9; i++)
			{
				this.logicArrayList_0[i] = new LogicArrayList<LogicGameObject>(32);
			}
			this.logicArrayList_3 = new LogicArrayList<int>(20);
			this.logicArrayList_4 = new LogicArrayList<int>(20);
			for (int j = 0; j < 20; j++)
			{
				this.logicArrayList_3.Add(0);
				this.logicArrayList_4.Add(0);
			}
			this.logicArrayList_3[1] = 3;
			this.logicArrayList_3[3] = 1;
			this.logicArrayList_3[4] = 2;
			this.logicArrayList_3[6] = 1;
			this.logicArrayList_3[7] = 1;
			this.logicArrayList_3[10] = 3;
			this.logicArrayList_3[11] = 1;
			this.logicArrayList_3[13] = 2;
			this.logicArrayList_3[14] = 2;
			this.logicArrayList_3[17] = 3;
			this.logicArrayList_3[19] = 1;
			this.logicArrayList_4[17] = -1;
			this.logicArrayList_4[10] = -1;
			this.logicArrayList_4[11] = -1;
			this.logicArrayList_4[3] = 2;
			this.logicArrayList_4[4] = 1;
			this.logicArrayList_4[5] = 1;
			this.logicArrayList_4[6] = 1;
			this.logicArrayList_4[13] = -1;
			this.logicArrayList_4[19] = -1;
			this.logicArrayList_1 = new LogicArrayList<LogicBuilding>();
			this.logicArrayList_2 = new LogicArrayList<LogicBuilding>();
			this.logicObstacleData_1 = LogicDataTables.GetObstacleByName("Bonus Gembox", null);
			this.logicObstacleData_0 = LogicDataTables.GetObstacleByName("LootCart", null);
			this.logicComponentManager_0 = new LogicComponentManager(level);
			this.logicGameObjectManagerListener_0 = new LogicGameObjectManagerListener();
			this.logicRandom_0 = new LogicRandom();
			this.logicRandom_1 = new LogicRandom();
			if (LogicDataTables.GetGlobals().UseNewTraining())
			{
				this.logicUnitProduction_0 = new LogicUnitProduction(level, LogicDataType.CHARACTER, this.int_0);
				this.logicUnitProduction_1 = new LogicUnitProduction(level, LogicDataType.SPELL, this.int_0);
			}
		}

		// Token: 0x06000DC8 RID: 3528 RVA: 0x00030F10 File Offset: 0x0002F110
		public void Destruct()
		{
			for (int i = 0; i < 9; i++)
			{
				LogicArrayList<LogicGameObject> logicArrayList = this.logicArrayList_0[i];
				if (logicArrayList != null)
				{
					for (int j = logicArrayList.Size() - 1; j >= 0; j--)
					{
						logicArrayList[j].Destruct();
						logicArrayList.Remove(j);
					}
					this.logicArrayList_0[i] = null;
				}
			}
			this.logicArrayList_1.Clear();
			this.logicArrayList_2.Clear();
			if (this.logicUnitProduction_0 != null)
			{
				this.logicUnitProduction_0.Destruct();
				this.logicUnitProduction_0 = null;
			}
			if (this.logicUnitProduction_1 != null)
			{
				this.logicUnitProduction_1.Destruct();
				this.logicUnitProduction_1 = null;
			}
			this.logicGameObjectManagerListener_0 = null;
			this.logicRandom_0 = null;
			this.logicRandom_1 = null;
			this.logicLevel_0 = null;
			this.logicTileMap_0 = null;
			this.logicBuilding_0 = null;
			this.logicBuilding_1 = null;
			this.logicBuilding_2 = null;
			this.logicBuilding_3 = null;
			this.logicBuilding_4 = null;
			this.logicBuilding_5 = null;
			this.logicObstacle_0 = null;
			this.logicVillageObject_0 = null;
			this.logicVillageObject_1 = null;
			this.logicVillageObject_2 = null;
			this.logicObstacleData_1 = null;
			this.logicObstacleData_2 = null;
		}

		// Token: 0x06000DC9 RID: 3529 RVA: 0x00002463 File Offset: 0x00000663
		public void Init(LogicLevel level, int villageType)
		{
		}

		// Token: 0x06000DCA RID: 3530 RVA: 0x00031028 File Offset: 0x0002F228
		public void AddGameObject(LogicGameObject gameObject, int globalId)
		{
			LogicGameObjectType gameObjectType = gameObject.GetGameObjectType();
			if (!gameObject.GetData().IsEnabledInVillageType(this.int_0))
			{
				Debugger.Error(string.Format("Invalid item in level for villageType {0} DataId: {1}", this.int_0, gameObject.GetData().GetGlobalID()));
			}
			if (globalId == -1)
			{
				globalId = this.GenerateGameObjectGlobalID(gameObject);
			}
			else
			{
				int classID = GlobalID.GetClassID(globalId);
				int instanceID = GlobalID.GetInstanceID(globalId);
				if (classID - 500 != (int)gameObjectType)
				{
					Debugger.Error(string.Format("LogicGameObjectManager::addGameObject with global ID {0}, doesn't have right index", globalId));
				}
				if (this.GetGameObjectByID(globalId) != null)
				{
					Debugger.Error(string.Format("LogicGameObjectManager::addGameObject with global ID {0}, global ID already taken", globalId));
				}
				if (this.int_1[(int)gameObjectType] <= instanceID)
				{
					this.int_1[(int)gameObjectType] = instanceID + 1;
				}
			}
			gameObject.SetGlobalID(globalId);
			LogicRandom logicRandom = new LogicRandom(this.logicLevel_0.GetGameMode().GetStartTime() + globalId);
			logicRandom.Rand(int.MaxValue);
			logicRandom.Rand(int.MaxValue);
			logicRandom.Rand(int.MaxValue);
			gameObject.SetSeed(logicRandom.Rand(int.MaxValue));
			if (gameObjectType == LogicGameObjectType.BUILDING)
			{
				LogicBuilding logicBuilding = (LogicBuilding)gameObject;
				LogicBuildingData buildingData = logicBuilding.GetBuildingData();
				if (buildingData.IsAllianceCastle())
				{
					this.logicBuilding_0 = logicBuilding;
				}
				if (buildingData.GetUnitProduction(0) >= 1 && !buildingData.IsForgesSpells())
				{
					if (buildingData.GetProducesUnitsOfType() == 1)
					{
						this.logicArrayList_1.Add(logicBuilding);
					}
					else if (buildingData.GetProducesUnitsOfType() == 2)
					{
						this.logicArrayList_2.Add(logicBuilding);
					}
				}
				if (buildingData.IsClockTower())
				{
					this.logicBuilding_1 = logicBuilding;
				}
				if (buildingData.IsTownHall() || buildingData.IsTownHallVillage2())
				{
					this.logicBuilding_2 = logicBuilding;
				}
				if (buildingData.IsWorkerBuilding() || buildingData.IsTownHallVillage2())
				{
					this.logicLevel_0.GetWorkerManagerAt(this.int_0).IncreaseWorkerCount();
				}
				if (buildingData.IsLaboratory())
				{
					this.logicBuilding_3 = logicBuilding;
				}
				if (buildingData.GetUnitProduction(0) >= 1)
				{
					this.int_9++;
				}
				if (buildingData.IsForgesSpells())
				{
					if (buildingData.GetProducesUnitsOfType() == 1)
					{
						this.logicBuilding_5 = logicBuilding;
					}
					else
					{
						this.logicBuilding_4 = logicBuilding;
					}
				}
			}
			else if (gameObjectType == LogicGameObjectType.OBSTACLE)
			{
				LogicObstacle logicObstacle = (LogicObstacle)gameObject;
				if (logicObstacle.GetObstacleData().IsLootCart())
				{
					this.logicObstacle_0 = logicObstacle;
				}
			}
			else if (gameObjectType == LogicGameObjectType.BUILDING)
			{
				this.logicAlliancePortal_0 = (LogicAlliancePortal)gameObject;
			}
			else if (gameObjectType == LogicGameObjectType.VILLAGE_OBJECT)
			{
				LogicVillageObject logicVillageObject = (LogicVillageObject)gameObject;
				LogicVillageObjectData villageObjectData = logicVillageObject.GetVillageObjectData();
				if (villageObjectData.IsShipyard())
				{
					this.logicVillageObject_0 = logicVillageObject;
				}
				if (villageObjectData.IsRowBoat())
				{
					this.logicVillageObject_1 = logicVillageObject;
				}
				if (villageObjectData.IsClanGate())
				{
					this.logicVillageObject_2 = logicVillageObject;
				}
			}
			this.logicArrayList_0[(int)gameObject.GetGameObjectType()].Add(gameObject);
			if (this.logicLevel_0.GetVillageType() == this.int_0)
			{
				this.logicTileMap_0.AddGameObject(gameObject);
				bool flag = true;
				if (LogicDataTables.GetGlobals().UseTeslaTriggerCommand() && gameObject.GetGameObjectType() == LogicGameObjectType.BUILDING && gameObject.IsHidden() && this.logicLevel_0.GetState() != 1 && this.logicLevel_0.GetState() != 4)
				{
					flag = false;
				}
				if (LogicDataTables.GetGlobals().UseTrapTriggerCommand() && gameObject.GetGameObjectType() == LogicGameObjectType.TRAP && this.logicLevel_0.GetState() != 1 && this.logicLevel_0.GetState() != 4)
				{
					flag = false;
				}
				if (flag)
				{
					this.logicGameObjectManagerListener_0.AddGameObject(gameObject);
				}
			}
		}

		// Token: 0x06000DCB RID: 3531 RVA: 0x00031378 File Offset: 0x0002F578
		public void AddLootCart()
		{
			if (this.logicObstacleData_0 != null)
			{
				if (this.CreateSpecialObstacle(this.logicObstacleData_0, true))
				{
					LogicArrayList<LogicGameObject> logicArrayList = this.logicArrayList_0[3];
					for (int i = 0; i < logicArrayList.Size(); i++)
					{
						LogicObstacle logicObstacle = (LogicObstacle)logicArrayList[i];
						if (logicObstacle.GetData() == this.logicObstacleData_0)
						{
							this.logicObstacle_0 = logicObstacle;
						}
					}
					return;
				}
				Debugger.Warning("LogicGameObjectManager::addLootCart failed");
			}
		}

		// Token: 0x06000DCC RID: 3532 RVA: 0x000313E4 File Offset: 0x0002F5E4
		public void RemoveGameObject(LogicGameObject gameObject)
		{
			int index = -1;
			LogicGameObjectType gameObjectType = gameObject.GetGameObjectType();
			LogicArrayList<LogicGameObject> logicArrayList = this.logicArrayList_0[(int)gameObjectType];
			for (int i = 0; i < logicArrayList.Size(); i++)
			{
				if (logicArrayList[i].GetGlobalID() == gameObject.GetGlobalID())
				{
					index = i;
					IL_3D:
					logicArrayList.Remove(index);
					this.logicLevel_0.GetTileMap().RemoveGameObject(gameObject);
					this.logicGameObjectManagerListener_0.RemoveGameObject(gameObject);
					if (this.logicBuilding_2 == gameObject)
					{
						this.logicBuilding_2 = null;
					}
					if (this.logicBuilding_1 == gameObject)
					{
						this.logicBuilding_1 = null;
					}
					if (gameObjectType == LogicGameObjectType.BUILDING)
					{
						LogicBuildingData buildingData = ((LogicBuilding)gameObject).GetBuildingData();
						if (buildingData.IsWorkerBuilding() || buildingData.IsTownHallVillage2())
						{
							this.logicLevel_0.GetWorkerManagerAt(this.int_0).DecreaseWorkerCount();
						}
						if (buildingData.GetUnitProduction(0) > 0)
						{
							this.int_9--;
							if (!buildingData.IsForgesSpells())
							{
								if (buildingData.GetProducesUnitsOfType() == 1)
								{
									for (int j = 0; j < this.logicArrayList_1.Size(); j++)
									{
										if (this.logicArrayList_1[j] == gameObject)
										{
											this.logicArrayList_1.Remove(j);
											break;
										}
									}
								}
								else if (buildingData.GetProducesUnitsOfType() == 2)
								{
									for (int k = 0; k < this.logicArrayList_2.Size(); k++)
									{
										if (this.logicArrayList_2[k] == gameObject)
										{
											this.logicArrayList_2.Remove(k);
											break;
										}
									}
								}
							}
						}
					}
					if (this.logicBuilding_0 == gameObject)
					{
						this.logicBuilding_0 = null;
					}
					if (this.logicBuilding_3 == gameObject)
					{
						this.logicBuilding_3 = null;
					}
					if (this.logicBuilding_4 == gameObject)
					{
						this.logicBuilding_4 = null;
					}
					if (this.logicBuilding_5 == gameObject)
					{
						this.logicBuilding_5 = null;
					}
					gameObject.Destruct();
					this.method_0(gameObject);
					return;
				}
			}
			goto IL_3D;
		}

		// Token: 0x06000DCD RID: 3533 RVA: 0x000315B0 File Offset: 0x0002F7B0
		private void method_0(LogicGameObject logicGameObject_0)
		{
			for (int i = 0; i < 9; i++)
			{
				LogicArrayList<LogicGameObject> logicArrayList = this.logicArrayList_0[i];
				for (int j = 0; j < logicArrayList.Size(); j++)
				{
					logicArrayList[j].RemoveGameObjectReferences(logicGameObject_0);
				}
			}
			for (int k = 0; k < 2; k++)
			{
				this.logicLevel_0.GetWorkerManagerAt(k).RemoveGameObjectReference(logicGameObject_0);
			}
			this.logicComponentManager_0.RemoveGameObjectReferences(logicGameObject_0);
			if (this.logicObstacle_0 == logicGameObject_0)
			{
				this.logicObstacle_0 = null;
			}
		}

		// Token: 0x06000DCE RID: 3534 RVA: 0x0003162C File Offset: 0x0002F82C
		public int GenerateGameObjectGlobalID(LogicGameObject gameObject)
		{
			LogicGameObjectType gameObjectType = gameObject.GetGameObjectType();
			if (gameObjectType >= (LogicGameObjectType)9)
			{
				Debugger.Error("LogicGameObjectManager::generateGameObjectGlobalID(). Index is out of bounds.");
			}
			int classId = (int)(gameObjectType + 500);
			int[] array = this.int_1;
			LogicGameObjectType logicGameObjectType = gameObjectType;
			int num = array[(int)logicGameObjectType];
			array[(int)logicGameObjectType] = num + 1;
			return GlobalID.CreateGlobalID(classId, num);
		}

		// Token: 0x06000DCF RID: 3535 RVA: 0x00009B65 File Offset: 0x00007D65
		public LogicArrayList<LogicGameObject> GetGameObjects(LogicGameObjectType index)
		{
			return this.logicArrayList_0[(int)index];
		}

		// Token: 0x06000DD0 RID: 3536 RVA: 0x00031670 File Offset: 0x0002F870
		public LogicGameObject GetGameObjectByID(int globalId)
		{
			LogicArrayList<LogicGameObject> logicArrayList = this.logicArrayList_0[GlobalID.GetClassID(globalId) - 500];
			int i = 0;
			int num = logicArrayList.Size();
			while (i < num)
			{
				LogicGameObject logicGameObject = logicArrayList[i];
				if (logicGameObject.GetGlobalID() == globalId)
				{
					return logicGameObject;
				}
				i++;
			}
			return null;
		}

		// Token: 0x06000DD1 RID: 3537 RVA: 0x000316BC File Offset: 0x0002F8BC
		public LogicGameObject GetGameObjectByIndex(int idx)
		{
			int i = 0;
			int num = 0;
			while (i < 9)
			{
				LogicArrayList<LogicGameObject> logicArrayList = this.logicArrayList_0[i];
				if (num + logicArrayList.Size() > idx)
				{
					return logicArrayList[idx - num];
				}
				num += logicArrayList.Size();
				i++;
			}
			return null;
		}

		// Token: 0x06000DD2 RID: 3538 RVA: 0x00031700 File Offset: 0x0002F900
		public int GetNumGameObjects()
		{
			int num = 0;
			for (int i = 0; i < 9; i++)
			{
				num += this.logicArrayList_0[i].Size();
			}
			return num;
		}

		// Token: 0x06000DD3 RID: 3539 RVA: 0x00031730 File Offset: 0x0002F930
		public int GetGameObjectCountByData(LogicData data)
		{
			int num = 0;
			for (int i = 0; i < 9; i++)
			{
				LogicArrayList<LogicGameObject> logicArrayList = this.logicArrayList_0[i];
				if (logicArrayList.Size() > 0 && logicArrayList[0].GetData().GetDataType() == data.GetDataType())
				{
					for (int j = 0; j < logicArrayList.Size(); j++)
					{
						if (logicArrayList[j].GetData() == data)
						{
							num++;
						}
					}
				}
			}
			return num;
		}

		// Token: 0x06000DD4 RID: 3540 RVA: 0x0003179C File Offset: 0x0002F99C
		public int GetGearUpBuildingCount()
		{
			LogicArrayList<LogicGameObject> logicArrayList = this.logicArrayList_0[0];
			int num = 0;
			for (int i = 0; i < logicArrayList.Size(); i++)
			{
				num += ((((LogicBuilding)logicArrayList[i]).GetGearLevel() > 0) ? 1 : 0);
			}
			return num;
		}

		// Token: 0x06000DD5 RID: 3541 RVA: 0x000317E4 File Offset: 0x0002F9E4
		public int GetGearUpBuildingCount(LogicBuildingData data)
		{
			LogicArrayList<LogicGameObject> logicArrayList = this.logicArrayList_0[0];
			int num = 0;
			for (int i = 0; i < logicArrayList.Size(); i++)
			{
				LogicBuilding logicBuilding = (LogicBuilding)logicArrayList[i];
				if (logicBuilding.GetData() == data && (logicBuilding.GetGearLevel() > 0 || logicBuilding.IsGearing()))
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000DD6 RID: 3542 RVA: 0x0003183C File Offset: 0x0002FA3C
		public int GetTallGrassCount()
		{
			LogicArrayList<LogicGameObject> logicArrayList = this.logicArrayList_0[3];
			int num = 0;
			for (int i = 0; i < logicArrayList.Size(); i++)
			{
				if (((LogicObstacle)logicArrayList[i]).GetObstacleData().IsTallGrass())
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000DD7 RID: 3543 RVA: 0x00031884 File Offset: 0x0002FA84
		public int GetHighestWallIndex(LogicBuildingData data)
		{
			int num = 1;
			LogicArrayList<LogicGameObject> logicArrayList = this.logicArrayList_0[0];
			for (int i = 0; i < logicArrayList.Size(); i++)
			{
				num += ((logicArrayList[i].GetData() == data) ? 1 : 0);
			}
			for (int j = 0; j < logicArrayList.Size(); j++)
			{
				if (((LogicBuilding)logicArrayList[j]).GetWallIndex() == num)
				{
					num++;
					j = -1;
				}
			}
			return num;
		}

		// Token: 0x06000DD8 RID: 3544 RVA: 0x00009B6F File Offset: 0x00007D6F
		public int GetHighestBuildingLevel(LogicBuildingData data)
		{
			return this.GetHighestBuildingLevel(data, true);
		}

		// Token: 0x06000DD9 RID: 3545 RVA: 0x00009B79 File Offset: 0x00007D79
		public int GetBarrackCount()
		{
			if (this.logicArrayList_1 != null)
			{
				return this.logicArrayList_1.Size();
			}
			return 0;
		}

		// Token: 0x06000DDA RID: 3546 RVA: 0x00009B90 File Offset: 0x00007D90
		public int GetDarkBarrackCount()
		{
			if (this.logicArrayList_2 != null)
			{
				return this.logicArrayList_2.Size();
			}
			return 0;
		}

		// Token: 0x06000DDB RID: 3547 RVA: 0x00009BA7 File Offset: 0x00007DA7
		public LogicGameObject GetBarrack(int idx)
		{
			return this.logicArrayList_1[idx];
		}

		// Token: 0x06000DDC RID: 3548 RVA: 0x00009BB5 File Offset: 0x00007DB5
		public LogicGameObject GetDarkBarrack(int idx)
		{
			return this.logicArrayList_2[idx];
		}

		// Token: 0x06000DDD RID: 3549 RVA: 0x000318F0 File Offset: 0x0002FAF0
		public int GetHighestBuildingLevel(LogicBuildingData data, bool completeProduction)
		{
			LogicArrayList<LogicGameObject> logicArrayList = this.logicArrayList_0[0];
			int num = -1;
			for (int i = 0; i < logicArrayList.Size(); i++)
			{
				if (logicArrayList[i].GetData() == data)
				{
					LogicBuilding logicBuilding = (LogicBuilding)logicArrayList[i];
					if ((!logicBuilding.IsConstructing() || logicBuilding.IsUpgrading()) && !logicBuilding.IsLocked())
					{
						int num2 = logicBuilding.GetUpgradeLevel();
						if (completeProduction && logicBuilding.IsConstructing())
						{
							num2++;
						}
						num = LogicMath.Max(num, num2);
					}
				}
			}
			return num;
		}

		// Token: 0x06000DDE RID: 3550 RVA: 0x00031970 File Offset: 0x0002FB70
		public LogicBuilding GetHighestBuilding(LogicBuildingData data)
		{
			LogicArrayList<LogicGameObject> logicArrayList = this.logicArrayList_0[0];
			LogicBuilding logicBuilding = null;
			for (int i = 0; i < logicArrayList.Size(); i++)
			{
				if (logicArrayList[i].GetData() == data)
				{
					LogicBuilding logicBuilding2 = (LogicBuilding)logicArrayList[i];
					if ((!logicBuilding2.IsConstructing() || logicBuilding2.IsUpgrading()) && !logicBuilding2.IsLocked())
					{
						int upgradeLevel = logicBuilding2.GetUpgradeLevel();
						if (logicBuilding != null)
						{
							if (upgradeLevel > logicBuilding.GetUpgradeLevel())
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
			return logicBuilding;
		}

		// Token: 0x06000DDF RID: 3551 RVA: 0x00009BC3 File Offset: 0x00007DC3
		public LogicComponentManager GetComponentManager()
		{
			return this.logicComponentManager_0;
		}

		// Token: 0x06000DE0 RID: 3552 RVA: 0x00009BCB File Offset: 0x00007DCB
		public LogicBuilding GetTownHall()
		{
			return this.logicBuilding_2;
		}

		// Token: 0x06000DE1 RID: 3553 RVA: 0x00009BD3 File Offset: 0x00007DD3
		public LogicUnitProduction GetSpellProduction()
		{
			return this.logicUnitProduction_1;
		}

		// Token: 0x06000DE2 RID: 3554 RVA: 0x00009BDB File Offset: 0x00007DDB
		public LogicUnitProduction GetUnitProduction()
		{
			return this.logicUnitProduction_0;
		}

		// Token: 0x06000DE3 RID: 3555 RVA: 0x00009BE3 File Offset: 0x00007DE3
		public LogicObstacle GetLootCart()
		{
			return this.logicObstacle_0;
		}

		// Token: 0x06000DE4 RID: 3556 RVA: 0x000319EC File Offset: 0x0002FBEC
		public void GetChecksum(ChecksumHelper checksum, bool includeGameObjects)
		{
			checksum.StartObject("LogicGameObjectManager");
			checksum.WriteValue("numGameObjects", this.GetNumGameObjects());
			if (includeGameObjects)
			{
				for (int i = 0; i < 9; i++)
				{
					checksum.StartArray("type" + i);
					for (int j = 0; j < this.logicArrayList_0[i].Size(); j++)
					{
						this.logicArrayList_0[i][j].GetChecksum(checksum, true);
					}
					checksum.EndArray();
				}
			}
			else
			{
				checksum.StartArray("type0");
				LogicArrayList<LogicGameObject> logicArrayList = this.logicArrayList_0[0];
				for (int k = 0; k < logicArrayList.Size(); k++)
				{
					logicArrayList[k].GetChecksum(checksum, false);
				}
				checksum.EndArray();
			}
			checksum.EndObject();
		}

		// Token: 0x06000DE5 RID: 3557 RVA: 0x00009BEB File Offset: 0x00007DEB
		public LogicGameObjectManagerListener GetListener()
		{
			return this.logicGameObjectManagerListener_0;
		}

		// Token: 0x06000DE6 RID: 3558 RVA: 0x00009BF3 File Offset: 0x00007DF3
		public void SetListener(LogicGameObjectManagerListener listener)
		{
			this.logicGameObjectManagerListener_0 = listener;
		}

		// Token: 0x06000DE7 RID: 3559 RVA: 0x00031AB0 File Offset: 0x0002FCB0
		public void Village2TownHallFixed()
		{
			LogicArrayList<LogicGameObject> logicArrayList = this.logicArrayList_0[0];
			for (int i = 0; i < logicArrayList.Size(); i++)
			{
				LogicBuilding logicBuilding = (LogicBuilding)logicArrayList[i];
				if (logicBuilding.IsLocked() && logicBuilding.GetBuildingData().GetRequiredTownHallLevel(0) <= 1)
				{
					logicBuilding.FinishConstruction(true, true);
					LogicVillage2UnitComponent village2UnitComponent = logicBuilding.GetVillage2UnitComponent();
					if (village2UnitComponent != null)
					{
						village2UnitComponent.TrainUnit(LogicDataTables.GetGlobals().GetVillage2StartUnitData());
						village2UnitComponent.ProductionCompleted();
					}
				}
			}
		}

		// Token: 0x06000DE8 RID: 3560 RVA: 0x00031B24 File Offset: 0x0002FD24
		public void LoadVillageObjects()
		{
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.VILLAGE_OBJECT);
			for (int i = 0; i < table.GetItemCount(); i++)
			{
				LogicVillageObjectData logicVillageObjectData = (LogicVillageObjectData)table.GetItemAt(i);
				if (logicVillageObjectData.IsEnabledInVillageType(this.int_0) && !logicVillageObjectData.IsDisabled() && this.GetGameObjectCountByData(logicVillageObjectData) == 0)
				{
					LogicVillageObject logicVillageObject = (LogicVillageObject)LogicGameObjectFactory.CreateGameObject(logicVillageObjectData, this.logicLevel_0, this.int_0);
					logicVillageObject.SetInitialPosition((logicVillageObjectData.GetTileX100() << 9) / 100, (logicVillageObjectData.GetTileY100() << 9) / 100);
					this.AddGameObject(logicVillageObject, -1);
				}
			}
		}

		// Token: 0x06000DE9 RID: 3561 RVA: 0x00031BB4 File Offset: 0x0002FDB4
		public void LoadingFinished()
		{
			this.RespawnObstacles();
			LogicArrayList<LogicGameObject> logicArrayList = this.logicArrayList_0[0];
			for (int i = 0; i < logicArrayList.Size(); i++)
			{
				logicArrayList[i].LoadingFinished();
			}
			LogicArrayList<LogicGameObject> logicArrayList2 = this.logicArrayList_0[3];
			for (int j = 0; j < logicArrayList2.Size(); j++)
			{
				logicArrayList2[j].LoadingFinished();
			}
			LogicArrayList<LogicGameObject> logicArrayList3 = this.logicArrayList_0[4];
			for (int k = 0; k < logicArrayList3.Size(); k++)
			{
				logicArrayList3[k].LoadingFinished();
			}
			LogicArrayList<LogicGameObject> logicArrayList4 = this.logicArrayList_0[6];
			for (int l = 0; l < logicArrayList4.Size(); l++)
			{
				logicArrayList4[l].LoadingFinished();
			}
			LogicArrayList<LogicGameObject> logicArrayList5 = this.logicArrayList_0[8];
			for (int m = 0; m < logicArrayList5.Size(); m++)
			{
				logicArrayList5[m].LoadingFinished();
			}
			if (LogicDataTables.GetGlobals().UseNewTraining())
			{
				this.logicUnitProduction_0.LoadingFinished();
				this.logicUnitProduction_1.LoadingFinished();
			}
		}

		// Token: 0x06000DEA RID: 3562 RVA: 0x00031CC4 File Offset: 0x0002FEC4
		public void FastForwardTime(int secs)
		{
			this.int_2 += secs;
			this.int_3 += secs;
			this.int_7 -= secs;
			this.int_4 -= secs;
			if (secs > 0)
			{
				int secondsSinceLastMaintenance = this.logicLevel_0.GetGameMode().GetSecondsSinceLastMaintenance();
				int num = -1;
				if (secondsSinceLastMaintenance > 0)
				{
					num = secs - secondsSinceLastMaintenance;
				}
				int num2 = 0;
				do
				{
					int num3 = secs;
					int num4 = 1;
					if (num2 == 999)
					{
						Debugger.Warning("LogicGameObjectManager::fastForwardTime - Pass limit reached");
					}
					else
					{
						for (int i = 0; i < 9; i++)
						{
							LogicArrayList<LogicGameObject> logicArrayList = this.logicArrayList_0[i];
							for (int j = 0; j < logicArrayList.Size(); j++)
							{
								int maxFastForwardTime = logicArrayList[j].GetMaxFastForwardTime();
								if (maxFastForwardTime >= 0)
								{
									num3 = LogicMath.Min(num3, maxFastForwardTime);
								}
							}
						}
					}
					bool flag;
					if (num < 1)
					{
						flag = false;
						if (num == 0)
						{
							flag = true;
							num = -1;
						}
					}
					else
					{
						num3 = LogicMath.Min(num3, num);
						num -= num3;
						flag = false;
					}
					if (num3 > 0)
					{
						num4 = num3;
					}
					if (num4 > secs)
					{
						num4 = secs;
					}
					for (int k = 0; k < 9; k++)
					{
						LogicArrayList<LogicGameObject> logicArrayList2 = this.logicArrayList_0[k];
						for (int l = 0; l < logicArrayList2.Size(); l++)
						{
							LogicGameObject logicGameObject = logicArrayList2[l];
							if (flag)
							{
								logicGameObject.StopBoost();
							}
							logicArrayList2[l].FastForwardTime(num4);
						}
					}
					LogicArrayList<LogicGameObject> logicArrayList3 = this.logicArrayList_0[0];
					for (int m = 0; m < logicArrayList3.Size(); m++)
					{
						logicArrayList3[m].FastForwardBoost(num4);
					}
					if (LogicDataTables.GetGlobals().UseNewTraining())
					{
						if (flag)
						{
							this.logicUnitProduction_0.StopBoost();
							this.logicUnitProduction_1.StopBoost();
						}
						this.logicUnitProduction_0.FastForwardTime(num4);
						this.logicUnitProduction_1.FastForwardTime(num4);
					}
					if (num2++ > 998)
					{
						break;
					}
					secs -= num4;
				}
				while (secs > 0);
			}
			this.RespawnObstacles();
		}

		// Token: 0x06000DEB RID: 3563 RVA: 0x00031EBC File Offset: 0x000300BC
		public int IncreaseObstacleClearCounter(int lootMultiplier)
		{
			this.int_6 = (this.int_6 + 1) % this.logicArrayList_3.Size();
			int num = this.logicArrayList_3[this.int_6];
			if (lootMultiplier >= 2)
			{
				num = this.logicArrayList_4[this.int_6] + lootMultiplier * num;
			}
			return num;
		}

		// Token: 0x06000DEC RID: 3564 RVA: 0x00031F10 File Offset: 0x00030110
		public void GenerateNextGemboxDropTime(bool clamp)
		{
			int num = this.logicRandom_0.Rand(this.logicObstacleData_1.GetAppearancePeriodHours());
			int num2 = this.int_8 + 3600 * num;
			if (clamp)
			{
				int num3 = 3600 * this.logicObstacleData_1.GetMinRespawnTimeHours();
				if (num2 < num3)
				{
					num2 = num3;
				}
			}
			this.int_7 = num2;
			this.int_8 = 3600 * (this.logicObstacleData_1.GetAppearancePeriodHours() - num);
		}

		// Token: 0x06000DED RID: 3565 RVA: 0x00031F80 File Offset: 0x00030180
		public void RespawnObstacles()
		{
			int villageType = this.logicLevel_0.GetVillageType();
			int matchType = this.logicLevel_0.GetMatchType();
			if (villageType == this.int_0 && matchType != 3 && matchType != 7)
			{
				if (villageType == 0 && matchType == 0)
				{
					if (this.logicLevel_0.GetMatchType() == 0)
					{
						this.Village1RespawnObstacle();
						if (this.logicObstacleData_1 != null && this.int_7 <= 0 && this.logicObstacleData_1.GetLootCount() > 0)
						{
							this.CreateSpecialObstacle(this.logicObstacleData_1, true);
							this.GenerateNextGemboxDropTime(true);
						}
						if (this.logicObstacleData_2 != null && this.int_4 <= 0 && this.logicObstacleData_2.GetLootCount() > 0)
						{
							this.CreateSpecialObstacle(this.logicObstacleData_2, false);
							int num = this.logicRandom_0.Rand(this.logicObstacleData_2.GetAppearancePeriodHours());
							this.int_4 = 3600 * num + this.int_5;
							this.int_5 = 3600 * (this.logicObstacleData_2.GetAppearancePeriodHours() - num);
							return;
						}
					}
				}
				else if (villageType == 1 && matchType != 5)
				{
					this.Village2RespawnObstacles();
				}
			}
		}

		// Token: 0x06000DEE RID: 3566 RVA: 0x00032098 File Offset: 0x00030298
		public void Village1RespawnObstacle()
		{
			if (this.int_0 == 0 && this.logicLevel_0.GetVillageType() == 0)
			{
				int obstacleRespawnSecs = LogicDataTables.GetGlobals().GetObstacleRespawnSecs();
				int obstacleMaxCount = LogicDataTables.GetGlobals().GetObstacleMaxCount();
				int tombStoneCount = this.logicLevel_0.GetTombStoneCount();
				int tallGrassCount = this.logicLevel_0.GetTallGrassCount();
				if (this.int_2 > obstacleRespawnSecs)
				{
					int num = tombStoneCount + tallGrassCount;
					while (this.logicArrayList_0[3].Size() - num < obstacleMaxCount)
					{
						this.Village1CreateObstacle();
						this.int_2 -= obstacleRespawnSecs;
						if (this.int_2 <= obstacleRespawnSecs)
						{
							return;
						}
					}
					this.int_2 = 0;
					return;
				}
			}
		}

		// Token: 0x06000DEF RID: 3567 RVA: 0x00032134 File Offset: 0x00030334
		public void Village2RespawnObstacles()
		{
			if (this.int_0 == 1 && this.logicLevel_0.GetVillageType() == 1)
			{
				int obstacleRespawnSecs = LogicDataTables.GetGlobals().GetObstacleRespawnSecs();
				while (this.int_2 > obstacleRespawnSecs)
				{
					this.Village2CreateObstacle();
					this.int_2 -= obstacleRespawnSecs;
				}
				this.RespawnTallGrass();
			}
		}

		// Token: 0x06000DF0 RID: 3568 RVA: 0x00032188 File Offset: 0x00030388
		public void RespawnTallGrass()
		{
			int num = (this.GetGameObjectCountByData(LogicDataTables.GetDecoByName("Old Barbarian Statue", null)) > 0) ? 50 : 25;
			int tallGrassRespawnSecs = LogicDataTables.GetGlobals().GetTallGrassRespawnSecs();
			while (this.int_3 > tallGrassRespawnSecs)
			{
				if (this.GetTallGrassCount() >= num)
				{
					this.int_3 = 0;
					return;
				}
				this.CreateTallGrass();
				this.int_3 -= tallGrassRespawnSecs;
			}
		}

		// Token: 0x06000DF1 RID: 3569 RVA: 0x000321EC File Offset: 0x000303EC
		public bool CreateSpecialObstacle(LogicObstacleData data, bool oneOnly)
		{
			if (oneOnly)
			{
				LogicArrayList<LogicGameObject> logicArrayList = this.logicArrayList_0[3];
				for (int i = 0; i < logicArrayList.Size(); i++)
				{
					if (logicArrayList[i].GetData() == data)
					{
						return false;
					}
				}
			}
			return this.RandomlyPlaceObstacle(data) ?? this.CreateObstacleIfAnyPlaceExists(data, data.GetWidth(), data.GetHeight());
		}

		// Token: 0x06000DF2 RID: 3570 RVA: 0x0003224C File Offset: 0x0003044C
		public bool PlaceGameObjectIfAnyFreeSpaceExists(LogicGameObject gameObject, int width, int height)
		{
			int widthInTiles = this.logicLevel_0.GetWidthInTiles();
			int heightInTiles = this.logicLevel_0.GetHeightInTiles();
			int num = widthInTiles * heightInTiles;
			int num2 = widthInTiles / 2;
			int num3 = heightInTiles / 2;
			if (num > 0)
			{
				while (!this.logicLevel_0.IsValidPlaceForBuilding(num2, num3, width, height, null))
				{
					if (++num2 + width > widthInTiles)
					{
						if (++num3 + height > heightInTiles)
						{
							num3 = 0;
						}
						num2 = 0;
					}
					if (--num <= 0)
					{
						return false;
					}
				}
				gameObject.SetInitialPosition(num2 << 9, num3 << 9);
				return true;
			}
			return false;
		}

		// Token: 0x06000DF3 RID: 3571 RVA: 0x000322CC File Offset: 0x000304CC
		public void Village1CreateObstacle()
		{
			if (this.int_0 != 0)
			{
				Debugger.Warning("invalid village type home!");
			}
			if (this.logicLevel_0.GetVillageType() != 0)
			{
				Debugger.Warning("invalid village type home (2)!");
			}
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.OBSTACLE);
			int num = 0;
			for (int i = 0; i < table.GetItemCount(); i++)
			{
				LogicObstacleData logicObstacleData = (LogicObstacleData)table.GetItemAt(i);
				if (logicObstacleData.IsEnabledInVillageType(this.int_0))
				{
					num += logicObstacleData.GetRespawnWeight();
				}
			}
			int num2 = this.logicRandom_0.Rand(num);
			LogicObstacleData logicObstacleData2 = null;
			int j = 0;
			int num3 = 0;
			while (j < table.GetItemCount())
			{
				LogicObstacleData logicObstacleData3 = (LogicObstacleData)table.GetItemAt(j);
				if (logicObstacleData3.IsEnabledInVillageType(this.int_0))
				{
					num3 += logicObstacleData3.GetRespawnWeight();
					if (num3 > num2)
					{
						logicObstacleData2 = logicObstacleData3;
						IL_CA:
						if (logicObstacleData2 != null && logicObstacleData2.IsEnabledInVillageType(this.int_0))
						{
							this.RandomlyPlaceObstacle(logicObstacleData2);
						}
						return;
					}
				}
				j++;
			}
			goto IL_CA;
		}

		// Token: 0x06000DF4 RID: 3572 RVA: 0x000323BC File Offset: 0x000305BC
		public void Village2CreateObstacle()
		{
			if (this.int_0 != 1)
			{
				Debugger.Warning("invalid village type home!");
			}
			if (this.logicLevel_0.GetVillageType() != 1)
			{
				Debugger.Warning("invalid village type home (2)!");
			}
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.OBSTACLE);
			int num = 0;
			for (int i = 0; i < table.GetItemCount(); i++)
			{
				LogicObstacleData logicObstacleData = (LogicObstacleData)table.GetItemAt(i);
				if (logicObstacleData.IsEnabledInVillageType(this.int_0) && logicObstacleData.GetVillage2RespawnCount() > this.GetGameObjectCountByData(logicObstacleData))
				{
					num += logicObstacleData.GetRespawnWeight();
				}
			}
			if (num > 0)
			{
				int num2 = this.logicRandom_0.Rand(num);
				LogicObstacleData logicObstacleData2 = null;
				int j = 0;
				int num3 = 0;
				while (j < table.GetItemCount())
				{
					LogicObstacleData logicObstacleData3 = (LogicObstacleData)table.GetItemAt(j);
					if (logicObstacleData3.IsEnabledInVillageType(this.int_0) && logicObstacleData3.GetVillage2RespawnCount() > this.GetGameObjectCountByData(logicObstacleData3))
					{
						num3 += logicObstacleData3.GetRespawnWeight();
						if (num3 > num2)
						{
							logicObstacleData2 = logicObstacleData3;
							IL_EF:
							if (logicObstacleData2 != null && logicObstacleData2.IsEnabledInVillageType(this.int_0))
							{
								this.RandomlyPlaceObstacle(logicObstacleData2);
								return;
							}
							return;
						}
					}
					j++;
				}
				goto IL_EF;
			}
		}

		// Token: 0x06000DF5 RID: 3573 RVA: 0x000324D4 File Offset: 0x000306D4
		public void CreateTallGrass()
		{
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.OBSTACLE);
			int num = 0;
			for (int i = 0; i < table.GetItemCount(); i++)
			{
				LogicObstacleData logicObstacleData = (LogicObstacleData)table.GetItemAt(i);
				if (logicObstacleData.IsTallGrass())
				{
					num += logicObstacleData.GetRespawnWeight();
				}
			}
			int num2 = this.logicRandom_0.Rand(num);
			LogicObstacleData data = null;
			int j = 0;
			int num3 = 0;
			while (j < table.GetItemCount())
			{
				LogicObstacleData logicObstacleData2 = (LogicObstacleData)table.GetItemAt(j);
				if (logicObstacleData2.IsTallGrass())
				{
					num3 += logicObstacleData2.GetRespawnWeight();
					if (num3 > num2)
					{
						data = logicObstacleData2;
						IL_95:
						if (this.GetTallGrassCount() == 0 || this.logicRandom_1.Rand(100) <= 80)
						{
							LogicArrayList<int> logicArrayList = new LogicArrayList<int>();
							LogicArrayList<int> logicArrayList2 = new LogicArrayList<int>();
							LogicDecoData decoByName = LogicDataTables.GetDecoByName("Old Barbarian Statue", null);
							if (this.GetGameObjectCountByData(decoByName) > 0)
							{
								LogicArrayList<LogicGameObject> logicArrayList3 = this.logicArrayList_0[6];
								for (int k = 0; k < logicArrayList3.Size(); k++)
								{
									LogicDeco logicDeco = (LogicDeco)logicArrayList3[k];
									if (logicDeco.GetData() == decoByName)
									{
										int tileX = logicDeco.GetTileX();
										int tileY = logicDeco.GetTileY();
										int widthInTiles = logicDeco.GetWidthInTiles();
										int heightInTiles = logicDeco.GetHeightInTiles();
										for (int l = 0; l < 2; l++)
										{
											for (int m = 0; m < widthInTiles; m++)
											{
												int num4 = tileX + m;
												int num5 = tileY - 1;
												if (this.logicLevel_0.IsValidPlaceForObstacle(num4, num5, 1, 1, false, false))
												{
													logicArrayList.Add(num4);
													logicArrayList2.Add(num5);
												}
												num5 = tileY + heightInTiles;
												if (this.logicLevel_0.IsValidPlaceForObstacle(num4, num5, 1, 1, false, false))
												{
													logicArrayList.Add(num4);
													logicArrayList2.Add(num5);
												}
											}
											for (int n = 0; n < heightInTiles; n++)
											{
												int num6 = tileX - 1;
												int num7 = tileY + n;
												if (this.logicLevel_0.IsValidPlaceForObstacle(num6, num7, 1, 1, false, false))
												{
													logicArrayList.Add(num6);
													logicArrayList2.Add(num7);
												}
												num6 = tileX + widthInTiles;
												if (this.logicLevel_0.IsValidPlaceForObstacle(num6, num7, 1, 1, false, false))
												{
													logicArrayList.Add(num6);
													logicArrayList2.Add(num7);
												}
											}
										}
									}
								}
							}
							LogicArrayList<LogicGameObject> logicArrayList4 = this.logicArrayList_0[3];
							for (int num8 = 0; num8 < logicArrayList4.Size(); num8++)
							{
								LogicObstacle logicObstacle = (LogicObstacle)logicArrayList4[num8];
								if (logicObstacle.GetObstacleData().IsTallGrassSpawnPoint())
								{
									int tileX2 = logicObstacle.GetTileX();
									int tileY2 = logicObstacle.GetTileY();
									int widthInTiles2 = logicObstacle.GetWidthInTiles();
									int heightInTiles2 = logicObstacle.GetHeightInTiles();
									for (int num9 = 0; num9 < widthInTiles2; num9++)
									{
										int num10 = tileX2 + num9;
										int num11 = tileY2 - 1;
										if (this.logicLevel_0.IsValidPlaceForObstacle(num10, num11, 1, 1, false, false))
										{
											logicArrayList.Add(num10);
											logicArrayList2.Add(num11);
										}
										num11 = tileY2 + heightInTiles2;
										if (this.logicLevel_0.IsValidPlaceForObstacle(num10, num11, 1, 1, false, false))
										{
											logicArrayList.Add(num10);
											logicArrayList2.Add(num11);
										}
									}
									for (int num12 = 0; num12 < heightInTiles2; num12++)
									{
										int num13 = tileX2 - 1;
										int num14 = tileY2 + num12;
										if (this.logicLevel_0.IsValidPlaceForObstacle(num13, num14, 1, 1, false, false))
										{
											logicArrayList.Add(num13);
											logicArrayList2.Add(num14);
										}
										num13 = tileX2 + widthInTiles2;
										if (this.logicLevel_0.IsValidPlaceForObstacle(num13, num14, 1, 1, false, false))
										{
											logicArrayList.Add(num13);
											logicArrayList2.Add(num14);
										}
									}
								}
							}
							if (logicArrayList.Size() > 0)
							{
								int index = this.logicRandom_1.Rand(logicArrayList.Size());
								int num15 = logicArrayList[index];
								int num16 = logicArrayList2[index];
								if (!this.logicLevel_0.IsValidPlaceForObstacle(num15, num16, 1, 1, false, true))
								{
									Debugger.Warning("Trying to spawn units on non empty area");
								}
								LogicObstacle logicObstacle2 = (LogicObstacle)LogicGameObjectFactory.CreateGameObject(data, this.logicLevel_0, this.int_0);
								logicObstacle2.SetInitialPosition(num15 << 9, num16 << 9);
								this.AddGameObject(logicObstacle2, -1);
							}
						}
						return;
					}
				}
				j++;
			}
			goto IL_95;
		}

		// Token: 0x06000DF6 RID: 3574 RVA: 0x000328F8 File Offset: 0x00030AF8
		public bool RandomlyPlaceObstacle(LogicObstacleData data)
		{
			if (data.IsEnabledInVillageType(this.int_0))
			{
				if (this.logicLevel_0.GetVillageType() != this.int_0 && data.GetLootDefensePercentage() == 0)
				{
					Debugger.Warning("invalid village type for randomlyPlaceObstacle");
				}
				for (int i = 0; i <= 20; i++)
				{
					int widthInTiles = this.logicLevel_0.GetWidthInTiles();
					int heightInTiles = this.logicLevel_0.GetHeightInTiles();
					int num = this.logicRandom_0.Rand(widthInTiles - data.GetWidth() + 1);
					int num2 = this.logicRandom_0.Rand(heightInTiles - data.GetHeight() + 1);
					if (this.logicLevel_0.IsValidPlaceForObstacle(num, num2, data.GetWidth(), data.GetHeight(), true, true))
					{
						LogicObstacle logicObstacle = (LogicObstacle)LogicGameObjectFactory.CreateGameObject(data, this.logicLevel_0, this.int_0);
						if (data.GetLootCount() > 0)
						{
							logicObstacle.SetLootMultiplyVersion(2);
						}
						logicObstacle.SetInitialPosition(num << 9, num2 << 9);
						this.AddGameObject(logicObstacle, -1);
						return true;
					}
				}
			}
			else
			{
				Debugger.Warning("randomlyPlaceObstacle; trying to place obstacle in wrong village");
			}
			return false;
		}

		// Token: 0x06000DF7 RID: 3575 RVA: 0x00032A00 File Offset: 0x00030C00
		public bool CreateObstacleIfAnyPlaceExists(LogicObstacleData data, int width, int height)
		{
			int widthInTiles = this.logicLevel_0.GetWidthInTiles();
			int heightInTiles = this.logicLevel_0.GetHeightInTiles();
			int num = widthInTiles * heightInTiles;
			int num2 = this.logicRandom_0.Rand(heightInTiles);
			int num3 = this.logicRandom_0.Rand(widthInTiles);
			while (num-- > 0)
			{
				if (this.logicLevel_0.IsValidPlaceForObstacle(num3, num2, width, height, false, true))
				{
					LogicObstacle logicObstacle = (LogicObstacle)LogicGameObjectFactory.CreateGameObject(data, this.logicLevel_0, this.int_0);
					logicObstacle.SetInitialPosition(num3 << 9, num2 << 9);
					this.AddGameObject(logicObstacle, -1);
					return true;
				}
				if (++num3 + width > widthInTiles)
				{
					if (++num2 + height > heightInTiles)
					{
						num2 = 0;
					}
					num3 = 0;
				}
			}
			return false;
		}

		// Token: 0x06000DF8 RID: 3576 RVA: 0x00032AB4 File Offset: 0x00030CB4
		public void RefreshArmyCampSize()
		{
			LogicArrayList<LogicComponent> components = this.logicComponentManager_0.GetComponents(LogicComponentType.VILLAGE2_UNIT);
			for (int i = 0; i < components.Size(); i++)
			{
				((LogicVillage2UnitComponent)components[i]).RefreshArmyCampSize(true);
			}
		}

		// Token: 0x06000DF9 RID: 3577 RVA: 0x00032AF4 File Offset: 0x00030CF4
		public LogicGameObject GetClosestGameObject(int x, int y, LogicGameObjectFilter filter)
		{
			if (!filter.IsComponentFilter())
			{
				LogicGameObject logicGameObject = null;
				int num = 0;
				for (int i = 0; i < 8; i++)
				{
					if (filter.ContainsGameObjectType(i))
					{
						LogicArrayList<LogicGameObject> logicArrayList = this.logicArrayList_0[i];
						for (int j = 0; j < logicArrayList.Size(); j++)
						{
							LogicGameObject logicGameObject2 = logicArrayList[j];
							if (filter.TestGameObject(logicGameObject2))
							{
								int distanceSquaredTo = logicGameObject2.GetPosition().GetDistanceSquaredTo(x, y);
								if (logicGameObject == null || distanceSquaredTo < num)
								{
									logicGameObject = logicGameObject2;
									num = distanceSquaredTo;
								}
							}
						}
					}
				}
				return logicGameObject;
			}
			LogicComponent closestComponent = this.logicComponentManager_0.GetClosestComponent(x, y, (LogicComponentFilter)filter);
			if (closestComponent == null)
			{
				return null;
			}
			return closestComponent.GetParent();
		}

		// Token: 0x06000DFA RID: 3578 RVA: 0x00032B94 File Offset: 0x00030D94
		public void GetGameObjects(LogicArrayList<LogicGameObject> output, LogicGameObjectFilter filter)
		{
			output.Clear();
			if (filter.IsComponentFilter())
			{
				LogicComponentFilter logicComponentFilter = (LogicComponentFilter)filter;
				LogicArrayList<LogicComponent> components = this.logicComponentManager_0.GetComponents(logicComponentFilter.GetComponentType());
				int i = 0;
				int num = components.Size();
				while (i < num)
				{
					LogicGameObject parent = components[i].GetParent();
					if (logicComponentFilter.TestGameObject(parent))
					{
						output.Add(parent);
					}
					i++;
				}
				return;
			}
			for (int j = 0; j < 9; j++)
			{
				LogicArrayList<LogicGameObject> logicArrayList = this.logicArrayList_0[j];
				int k = 0;
				int num2 = logicArrayList.Size();
				while (k < num2)
				{
					LogicGameObject logicGameObject = logicArrayList[k];
					if (filter.TestGameObject(logicGameObject))
					{
						output.Add(logicGameObject);
					}
					k++;
				}
			}
		}

		// Token: 0x06000DFB RID: 3579 RVA: 0x00032C50 File Offset: 0x00030E50
		public int GetAvailableBuildingUpgradeCount(LogicBuilding gameObject)
		{
			LogicBuildingData buildingData = gameObject.GetBuildingData();
			int num = gameObject.GetUpgradeLevel() + 1;
			if (buildingData.GetUpgradeLevelCount() <= num)
			{
				return 0;
			}
			int amountCanBeUpgraded = buildingData.GetAmountCanBeUpgraded(num);
			if (amountCanBeUpgraded != 0)
			{
				int num2 = 0;
				LogicArrayList<LogicGameObject> logicArrayList = this.logicArrayList_0[0];
				for (int i = 0; i < logicArrayList.Size(); i++)
				{
					LogicBuilding logicBuilding = (LogicBuilding)logicArrayList[i];
					if (logicBuilding.GetData() == buildingData && logicBuilding.GetUpgradeLevel() > gameObject.GetUpgradeLevel())
					{
						num2++;
					}
				}
				return amountCanBeUpgraded - num2;
			}
			return 1;
		}

		// Token: 0x06000DFC RID: 3580 RVA: 0x00032CD8 File Offset: 0x00030ED8
		public void ChangeVillageType(bool enabled)
		{
			for (int i = 0; i < 9; i++)
			{
				LogicArrayList<LogicGameObject> logicArrayList = this.logicArrayList_0[i];
				for (int j = 0; j < logicArrayList.Size(); j++)
				{
					LogicGameObject logicGameObject = logicArrayList[j];
					if (enabled)
					{
						this.logicTileMap_0.AddGameObject(logicGameObject);
						bool flag = true;
						if (LogicDataTables.GetGlobals().UseTeslaTriggerCommand() && logicGameObject.GetGameObjectType() == LogicGameObjectType.BUILDING && logicGameObject.IsHidden() && this.logicLevel_0.GetState() != 1 && this.logicLevel_0.GetState() != 4)
						{
							flag = false;
						}
						if (LogicDataTables.GetGlobals().UseTrapTriggerCommand() && logicGameObject.GetGameObjectType() == LogicGameObjectType.TRAP && this.logicLevel_0.GetState() != 1 && this.logicLevel_0.GetState() != 4)
						{
							flag = false;
						}
						if (flag)
						{
							this.logicGameObjectManagerListener_0.AddGameObject(logicGameObject);
						}
					}
					else
					{
						this.logicTileMap_0.RemoveGameObject(logicGameObject);
						this.logicGameObjectManagerListener_0.RemoveGameObject(logicGameObject);
					}
				}
			}
		}

		// Token: 0x06000DFD RID: 3581 RVA: 0x00032DD0 File Offset: 0x00030FD0
		public void DoDestucting()
		{
			bool flag = false;
			for (int i = 0; i < 9; i++)
			{
				LogicArrayList<LogicGameObject> logicArrayList = this.logicArrayList_0[i];
				for (int j = 0; j < logicArrayList.Size(); j++)
				{
					LogicGameObject logicGameObject = logicArrayList[j];
					if (logicGameObject.ShouldDestruct())
					{
						logicArrayList.Remove(j--);
						this.method_0(logicGameObject);
						this.logicGameObjectManagerListener_0.RemoveGameObject(logicGameObject);
						logicGameObject.Destruct();
						if (i == 2)
						{
							flag = true;
						}
					}
				}
			}
			if (flag && this.logicLevel_0.GetConfiguration().GetBattleWaitForProjectileDestruction() && this.logicArrayList_0[2].Size() == 0)
			{
				this.logicLevel_0.UpdateBattleStatus();
			}
		}

		// Token: 0x06000DFE RID: 3582 RVA: 0x00032E74 File Offset: 0x00031074
		public void SubTick()
		{
			this.logicComponentManager_0.SubTick();
			if (LogicDataTables.GetGlobals().UseNewTraining())
			{
				this.logicUnitProduction_0.SubTick();
				this.logicUnitProduction_1.SubTick();
			}
			LogicArrayList<LogicGameObject> logicArrayList = this.logicArrayList_0[0];
			LogicArrayList<LogicGameObject> logicArrayList2 = this.logicArrayList_0[1];
			LogicArrayList<LogicGameObject> logicArrayList3 = this.logicArrayList_0[2];
			LogicArrayList<LogicGameObject> logicArrayList4 = this.logicArrayList_0[7];
			LogicArrayList<LogicGameObject> logicArrayList5 = this.logicArrayList_0[8];
			int i = 0;
			int num = logicArrayList2.Size();
			while (i < num)
			{
				logicArrayList2[i].SubTick();
				i++;
			}
			int j = 0;
			int num2 = logicArrayList4.Size();
			while (j < num2)
			{
				logicArrayList4[j].SubTick();
				j++;
			}
			int k = 0;
			int num3 = logicArrayList.Size();
			while (k < num3)
			{
				logicArrayList[k].SubTick();
				k++;
			}
			int l = 0;
			int num4 = logicArrayList3.Size();
			while (l < num4)
			{
				logicArrayList3[l].SubTick();
				l++;
			}
			int m = 0;
			int num5 = logicArrayList5.Size();
			while (m < num5)
			{
				logicArrayList5[m].SubTick();
				m++;
			}
		}

		// Token: 0x06000DFF RID: 3583 RVA: 0x00032F9C File Offset: 0x0003119C
		public void Tick()
		{
			this.DoDestucting();
			if (LogicDataTables.GetGlobals().UseNewTraining())
			{
				this.logicUnitProduction_0.Tick();
				this.logicUnitProduction_1.Tick();
			}
			this.logicComponentManager_0.Tick();
			for (int i = 0; i < 9; i++)
			{
				LogicArrayList<LogicGameObject> logicArrayList = this.logicArrayList_0[i];
				int j = 0;
				int num = logicArrayList.Size();
				while (j < num)
				{
					logicArrayList[j].Tick();
					j++;
				}
			}
		}

		// Token: 0x06000E00 RID: 3584 RVA: 0x00009BFC File Offset: 0x00007DFC
		public void Load(LogicJSONObject jsonObject)
		{
			this.Load(jsonObject, false, true);
		}

		// Token: 0x06000E01 RID: 3585 RVA: 0x00033014 File Offset: 0x00031214
		public void LoadFromSnapshot(LogicJSONObject jsonObject)
		{
			LogicGameMode gameMode = this.logicLevel_0.GetGameMode();
			if (gameMode.GetVisitType() != 1 && gameMode.GetVisitType() != 4 && gameMode.GetVisitType() != 5)
			{
				this.Load(jsonObject, true, true);
				return;
			}
			this.Load(jsonObject, true, false);
			int num = 7;
			if ((gameMode.GetVisitType() != 4 && !this.logicLevel_0.IsArrangedWar()) || !this.logicLevel_0.IsArrangedWar())
			{
				int warLayout = this.logicLevel_0.GetWarLayout();
				if (warLayout >= 0 && this.logicLevel_0.IsWarBase())
				{
					num = warLayout;
				}
				else
				{
					num = this.logicLevel_0.GetActiveLayout();
				}
			}
			bool flag = false;
			for (int i = 0; i < 9; i++)
			{
				LogicArrayList<LogicGameObject> logicArrayList = this.logicArrayList_0[i];
				for (int j = 0; j < logicArrayList.Size(); j++)
				{
					LogicGameObject logicGameObject = logicArrayList[j];
					if (logicGameObject.GetComponent(LogicComponentType.LAYOUT) != null && logicGameObject.GetPositionLayout(num, true).m_x != -1)
					{
						flag = true;
					}
				}
			}
			if (flag)
			{
				for (int k = 0; k < 9; k++)
				{
					LogicArrayList<LogicGameObject> logicArrayList2 = this.logicArrayList_0[k];
					for (int l = 0; l < logicArrayList2.Size(); l++)
					{
						LogicGameObject logicGameObject2 = logicArrayList2[l];
						if (logicGameObject2.GetComponent(LogicComponentType.LAYOUT) != null)
						{
							LogicVector2 positionLayout = logicGameObject2.GetPositionLayout(num, true);
							if (positionLayout.m_x != -1)
							{
								if (positionLayout.m_y != -1)
								{
									logicGameObject2.SetInitialPosition(positionLayout.m_x << 9, positionLayout.m_y << 9);
									logicGameObject2.SetPositionLayoutXY(positionLayout.m_x, positionLayout.m_y, num, false);
									goto IL_17D;
								}
							}
							logicGameObject2.SetPositionLayoutXY(-1, -1, num, false);
						}
						IL_17D:;
					}
				}
			}
		}

		// Token: 0x06000E02 RID: 3586 RVA: 0x000331C4 File Offset: 0x000313C4
		public void Load(LogicJSONObject jsonObject, bool snapshot, bool loadObstacle)
		{
			this.logicObstacleData_2 = this.logicLevel_0.GetGameMode().GetConfiguration().GetSpecialObstacleData();
			if (this.GetNumGameObjects() != 0)
			{
				Debugger.Error("LogicGameObjectManager::load - numGameObjects is non zero!");
				return;
			}
			if (this.int_0 == 1)
			{
				LogicJSONArray jsonarray = jsonObject.GetJSONArray("buildings2");
				LogicJSONArray jsonarray2 = jsonObject.GetJSONArray("traps2");
				LogicJSONArray jsonarray3 = jsonObject.GetJSONArray("decos2");
				if (jsonarray != null)
				{
					this.LoadGameObjectsJsonArray(jsonarray, snapshot);
				}
				if (loadObstacle)
				{
					LogicJSONArray jsonarray4 = jsonObject.GetJSONArray("vobjs2");
					LogicJSONArray jsonarray5 = jsonObject.GetJSONArray("obstacles2");
					if (jsonarray5 != null)
					{
						this.LoadGameObjectsJsonArray(jsonarray5, snapshot);
					}
					if (jsonarray4 != null)
					{
						this.LoadGameObjectsJsonArray(jsonarray4, snapshot);
					}
				}
				if (jsonarray2 != null)
				{
					this.LoadGameObjectsJsonArray(jsonarray2, snapshot);
				}
				if (jsonarray3 != null)
				{
					this.LoadGameObjectsJsonArray(jsonarray3, snapshot);
				}
				if (!snapshot)
				{
					LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("v2rs");
					if (jsonnumber != null)
					{
						this.int_2 = jsonnumber.GetIntValue();
					}
					LogicJSONNumber jsonnumber2 = jsonObject.GetJSONNumber("v2rseed");
					if (jsonnumber2 != null)
					{
						this.logicRandom_0.SetIteratedRandomSeed(jsonnumber2.GetIntValue());
					}
					else
					{
						this.logicRandom_0.SetIteratedRandomSeed(112);
					}
					LogicJSONNumber jsonnumber3 = jsonObject.GetJSONNumber("v2ccounter");
					if (jsonnumber3 != null)
					{
						this.int_6 = jsonnumber3.GetIntValue();
					}
					LogicJSONNumber jsonnumber4 = jsonObject.GetJSONNumber("tgsec");
					if (jsonnumber4 != null)
					{
						this.int_3 = jsonnumber4.GetIntValue();
					}
					LogicJSONNumber jsonnumber5 = jsonObject.GetJSONNumber("tgseed");
					if (jsonnumber5 != null)
					{
						this.logicRandom_1.SetIteratedRandomSeed(jsonnumber5.GetIntValue());
					}
				}
			}
			else
			{
				LogicJSONArray jsonarray6 = jsonObject.GetJSONArray("buildings");
				LogicJSONArray jsonarray7 = jsonObject.GetJSONArray("traps");
				LogicJSONArray jsonarray8 = jsonObject.GetJSONArray("decos");
				if (jsonarray6 == null)
				{
					Debugger.Error("LogicGameObjectManager::load - Building array is NULL!");
					return;
				}
				this.LoadGameObjectsJsonArray(jsonarray6, snapshot);
				if (loadObstacle)
				{
					LogicJSONArray jsonarray9 = jsonObject.GetJSONArray("obstacles");
					LogicJSONArray jsonarray10 = jsonObject.GetJSONArray("vobjs");
					if (jsonarray9 != null)
					{
						this.LoadGameObjectsJsonArray(jsonarray9, snapshot);
					}
					if (jsonarray10 != null)
					{
						this.LoadGameObjectsJsonArray(jsonarray10, snapshot);
					}
				}
				if (jsonarray7 != null)
				{
					this.LoadGameObjectsJsonArray(jsonarray7, snapshot);
				}
				if (jsonarray8 != null)
				{
					this.LoadGameObjectsJsonArray(jsonarray8, snapshot);
				}
				if (!snapshot)
				{
					LogicJSONObject jsonobject = jsonObject.GetJSONObject("respawnVars");
					if (jsonobject != null)
					{
						this.int_2 = jsonobject.GetJSONNumber("secondsFromLastRespawn").GetIntValue();
						this.logicRandom_0.SetIteratedRandomSeed(jsonobject.GetJSONNumber("respawnSeed").GetIntValue());
						this.int_6 = jsonobject.GetJSONNumber("obstacleClearCounter").GetIntValue();
						LogicJSONNumber jsonnumber6 = jsonobject.GetJSONNumber("time_to_gembox_drop");
						if (jsonnumber6 != null)
						{
							this.int_7 = jsonnumber6.GetIntValue();
						}
						else if (this.logicObstacleData_1 != null)
						{
							int num = this.logicRandom_0.Rand(this.logicObstacleData_1.GetAppearancePeriodHours());
							this.int_7 = 3600 * num + this.int_8;
							this.int_8 = 3600 * (this.logicObstacleData_1.GetAppearancePeriodHours() - num);
						}
						LogicJSONNumber jsonnumber7 = jsonobject.GetJSONNumber("time_in_gembox_period");
						if (jsonnumber7 != null)
						{
							this.int_8 = jsonnumber7.GetIntValue();
						}
						if (this.logicObstacleData_2 != null)
						{
							LogicJSONNumber jsonnumber8 = jsonobject.GetJSONNumber("time_to_special_drop");
							if (jsonnumber8 != null)
							{
								this.int_4 = jsonnumber8.GetIntValue();
							}
							else
							{
								this.int_5 = 0;
								int num2 = this.logicRandom_0.Rand(this.logicObstacleData_2.GetAppearancePeriodHours());
								this.int_4 = 3600 * num2 + this.int_5;
								this.int_5 = 3600 * (this.logicObstacleData_2.GetAppearancePeriodHours() - num2);
							}
							LogicJSONNumber jsonnumber9 = jsonobject.GetJSONNumber("time_to_special_period");
							if (jsonnumber9 != null)
							{
								this.int_5 = jsonnumber9.GetIntValue();
							}
						}
					}
					else
					{
						Debugger.Warning("Can't find respawn variables");
						this.logicRandom_0.SetIteratedRandomSeed(112);
						this.int_7 = 604800;
						this.int_4 = 604800;
						this.int_5 = 0;
						if (this.logicObstacleData_1 != null)
						{
							this.int_7 = 3600 * this.logicObstacleData_1.GetAppearancePeriodHours();
						}
						if (this.logicObstacleData_2 != null)
						{
							this.int_4 = 3600 * this.logicObstacleData_2.GetAppearancePeriodHours();
						}
					}
				}
				if (LogicDataTables.GetGlobals().UseNewTraining())
				{
					LogicJSONObject jsonobject2 = jsonObject.GetJSONObject("units");
					LogicJSONObject jsonobject3 = jsonObject.GetJSONObject("spells");
					if (jsonobject2 != null)
					{
						this.logicUnitProduction_0.Load(jsonobject2);
					}
					if (jsonobject3 != null)
					{
						this.logicUnitProduction_1.Load(jsonobject3);
					}
				}
			}
			this.logicTileMap_0.EnableRoomIndices(true);
		}

		// Token: 0x06000E03 RID: 3587 RVA: 0x0003362C File Offset: 0x0003182C
		public void LoadGameObjectsJsonArray(LogicJSONArray jsonArray, bool snapshot)
		{
			int i = 0;
			int num = jsonArray.Size();
			while (i < num)
			{
				LogicJSONObject logicJSONObject = (LogicJSONObject)jsonArray.Get(i);
				if (logicJSONObject == null)
				{
					Debugger.Error("LogicGameObjectManager::load - Building is NULL!");
				}
				else
				{
					LogicJSONNumber jsonnumber = logicJSONObject.GetJSONNumber("data");
					if (jsonnumber == null)
					{
						Debugger.Error("LogicGameObjectManager::load - Data id was not found!");
					}
					else
					{
						LogicGameObjectData logicGameObjectData = (LogicGameObjectData)LogicDataTables.GetDataById(jsonnumber.GetIntValue());
						if (logicGameObjectData == null)
						{
							Debugger.Error("LogicGameObjectManager::load - Data is NULL!");
						}
						else
						{
							LogicDataType dataType = logicGameObjectData.GetDataType();
							if (dataType == LogicDataType.BUILDING || dataType == LogicDataType.OBSTACLE || dataType == LogicDataType.TRAP || dataType == LogicDataType.DECO || dataType == LogicDataType.VILLAGE_OBJECT)
							{
								LogicGameObject logicGameObject = LogicGameObjectFactory.CreateGameObject(logicGameObjectData, this.logicLevel_0, this.int_0);
								if (logicGameObject != null)
								{
									LogicJSONNumber jsonnumber2 = logicJSONObject.GetJSONNumber("id");
									int globalId = -1;
									if (jsonnumber2 != null)
									{
										globalId = jsonnumber2.GetIntValue();
									}
									if (snapshot)
									{
										logicGameObject.LoadFromSnapshot(logicJSONObject);
									}
									else
									{
										logicGameObject.Load(logicJSONObject);
									}
									bool flag = false;
									if (logicGameObjectData.IsEnableByCalendar())
									{
										int matchType = this.logicLevel_0.GetMatchType();
										if ((matchType > 7 || (matchType != 3 && matchType != 5 && matchType != 7)) && this.logicLevel_0.GetGameMode().GetVisitType() != 1)
										{
											flag = !this.logicLevel_0.GetGameMode().GetCalendar().IsEnabled(logicGameObjectData);
										}
									}
									if (dataType == LogicDataType.OBSTACLE)
									{
										if (((LogicObstacleData)logicGameObjectData).GetLootDefensePercentage() > 0 && this.logicBuilding_2 != null && LogicDataTables.GetGlobals().GetLootCartEnabledTownHall() > this.logicBuilding_2.GetUpgradeLevel())
										{
											flag = true;
										}
									}
									else if (dataType == LogicDataType.VILLAGE_OBJECT && ((LogicVillageObjectData)logicGameObjectData).IsDisabled())
									{
										flag = true;
									}
									if (snapshot && logicGameObject.GetTileX() == -1 && logicGameObject.GetTileY() == -1)
									{
										flag = true;
									}
									if (flag)
									{
										logicGameObject.Destruct();
									}
									else
									{
										this.AddGameObject(logicGameObject, globalId);
									}
								}
							}
						}
					}
				}
				i++;
			}
		}

		// Token: 0x06000E04 RID: 3588 RVA: 0x00033808 File Offset: 0x00031A08
		public void Save(LogicJSONObject jsonObject)
		{
			if (this.int_0 == 1)
			{
				jsonObject.Put("buildings2", this.SaveGameObjects(LogicGameObjectType.BUILDING));
				jsonObject.Put("obstacles2", this.SaveObstacles());
				jsonObject.Put("traps2", this.SaveGameObjects(LogicGameObjectType.TRAP));
				jsonObject.Put("decos2", this.SaveGameObjects(LogicGameObjectType.DECO));
				if (!this.logicLevel_0.IsNpcVillage())
				{
					if (LogicDataTables.GetGlobals().SaveVillageObjects())
					{
						jsonObject.Put("vobjs2", this.SaveGameObjects(LogicGameObjectType.VILLAGE_OBJECT));
					}
					int ticksInSeconds = LogicTime.GetTicksInSeconds(this.logicLevel_0.GetLogicTime().GetTick());
					jsonObject.Put("v2rs", new LogicJSONNumber(ticksInSeconds + this.int_2));
					jsonObject.Put("v2rseed", new LogicJSONNumber(this.logicRandom_0.GetIteratedRandomSeed()));
					jsonObject.Put("v2ccounter", new LogicJSONNumber(this.int_6));
					jsonObject.Put("tgsec", new LogicJSONNumber(this.int_3));
					jsonObject.Put("tgseed", new LogicJSONNumber(this.logicRandom_1.GetIteratedRandomSeed()));
					return;
				}
			}
			else
			{
				jsonObject.Put("buildings", this.SaveGameObjects(LogicGameObjectType.BUILDING));
				jsonObject.Put("obstacles", this.SaveObstacles());
				jsonObject.Put("traps", this.SaveGameObjects(LogicGameObjectType.TRAP));
				jsonObject.Put("decos", this.SaveGameObjects(LogicGameObjectType.DECO));
				if (!this.logicLevel_0.IsNpcVillage())
				{
					if (LogicDataTables.GetGlobals().SaveVillageObjects())
					{
						jsonObject.Put("vobjs", this.SaveGameObjects(LogicGameObjectType.VILLAGE_OBJECT));
					}
					LogicJSONObject logicJSONObject = new LogicJSONObject();
					int ticksInSeconds2 = LogicTime.GetTicksInSeconds(this.logicLevel_0.GetLogicTime().GetTick());
					logicJSONObject.Put("secondsFromLastRespawn", new LogicJSONNumber(ticksInSeconds2 + this.int_2));
					logicJSONObject.Put("respawnSeed", new LogicJSONNumber(this.logicRandom_0.GetIteratedRandomSeed()));
					logicJSONObject.Put("obstacleClearCounter", new LogicJSONNumber(this.int_6));
					int num = (this.logicObstacleData_1 != null) ? (7200 * this.logicObstacleData_1.GetAppearancePeriodHours()) : 1209600;
					if (this.int_7 > num)
					{
						this.int_7 = 0;
						this.int_8 = 0;
					}
					logicJSONObject.Put("time_to_gembox_drop", new LogicJSONNumber(this.int_7 - ticksInSeconds2));
					logicJSONObject.Put("time_in_gembox_period", new LogicJSONNumber(this.int_8 - ticksInSeconds2));
					if (this.logicObstacleData_2 != null)
					{
						logicJSONObject.Put("time_to_special_drop", new LogicJSONNumber(this.int_4 - ticksInSeconds2));
						logicJSONObject.Put("time_to_special_period", new LogicJSONNumber(this.int_5 - ticksInSeconds2));
					}
					jsonObject.Put("respawnVars", logicJSONObject);
					if (LogicDataTables.GetGlobals().UseNewTraining())
					{
						LogicJSONObject logicJSONObject2 = new LogicJSONObject();
						LogicJSONObject logicJSONObject3 = new LogicJSONObject();
						this.logicUnitProduction_0.Save(logicJSONObject2);
						this.logicUnitProduction_1.Save(logicJSONObject3);
						jsonObject.Put("units", logicJSONObject2);
						jsonObject.Put("spells", logicJSONObject3);
					}
				}
			}
		}

		// Token: 0x06000E05 RID: 3589 RVA: 0x00033AFC File Offset: 0x00031CFC
		public void SaveToSnapshot(LogicJSONObject jsonObject, int layoutId)
		{
			if (this.int_0 == 1)
			{
				jsonObject.Put("buildings2", this.SaveGameObjects(LogicGameObjectType.BUILDING, layoutId));
				jsonObject.Put("obstacles2", this.SaveObstacles(layoutId));
				jsonObject.Put("traps2", this.SaveGameObjects(LogicGameObjectType.TRAP, layoutId));
				jsonObject.Put("decos2", this.SaveGameObjects(LogicGameObjectType.DECO, layoutId));
				if (!this.logicLevel_0.IsNpcVillage())
				{
					if (LogicDataTables.GetGlobals().SaveVillageObjects())
					{
						jsonObject.Put("vobjs2", this.SaveGameObjects(LogicGameObjectType.VILLAGE_OBJECT, layoutId));
					}
					int ticksInSeconds = LogicTime.GetTicksInSeconds(this.logicLevel_0.GetLogicTime().GetTick());
					jsonObject.Put("v2rs", new LogicJSONNumber(ticksInSeconds + this.int_2));
					jsonObject.Put("v2rseed", new LogicJSONNumber(this.logicRandom_0.GetIteratedRandomSeed()));
					jsonObject.Put("v2ccounter", new LogicJSONNumber(this.int_6));
					jsonObject.Put("tgsec", new LogicJSONNumber(this.int_3));
					jsonObject.Put("tgseed", new LogicJSONNumber(this.logicRandom_1.GetIteratedRandomSeed()));
					return;
				}
			}
			else
			{
				jsonObject.Put("buildings", this.SaveGameObjects(LogicGameObjectType.BUILDING, layoutId));
				jsonObject.Put("obstacles", this.SaveObstacles(layoutId));
				jsonObject.Put("traps", this.SaveGameObjects(LogicGameObjectType.TRAP, layoutId));
				jsonObject.Put("decos", this.SaveGameObjects(LogicGameObjectType.DECO, layoutId));
				if (!this.logicLevel_0.IsNpcVillage())
				{
					if (LogicDataTables.GetGlobals().SaveVillageObjects())
					{
						jsonObject.Put("vobjs", this.SaveGameObjects(LogicGameObjectType.VILLAGE_OBJECT, layoutId));
					}
					LogicJSONObject logicJSONObject = new LogicJSONObject();
					int ticksInSeconds2 = LogicTime.GetTicksInSeconds(this.logicLevel_0.GetLogicTime().GetTick());
					logicJSONObject.Put("secondsFromLastRespawn", new LogicJSONNumber(ticksInSeconds2 + this.int_2));
					logicJSONObject.Put("respawnSeed", new LogicJSONNumber(this.logicRandom_0.GetIteratedRandomSeed()));
					logicJSONObject.Put("obstacleClearCounter", new LogicJSONNumber(this.int_6));
					int num = (this.logicObstacleData_1 != null) ? (7200 * this.logicObstacleData_1.GetAppearancePeriodHours()) : 1209600;
					if (this.int_7 > num)
					{
						this.int_7 = 0;
						this.int_8 = 0;
					}
					logicJSONObject.Put("time_to_gembox_drop", new LogicJSONNumber(this.int_7 - ticksInSeconds2));
					logicJSONObject.Put("time_in_gembox_period", new LogicJSONNumber(this.int_8 - ticksInSeconds2));
					if (this.logicObstacleData_2 != null)
					{
						logicJSONObject.Put("time_to_special_drop", new LogicJSONNumber(this.int_4 - ticksInSeconds2));
						logicJSONObject.Put("time_to_special_period", new LogicJSONNumber(this.int_5 - ticksInSeconds2));
					}
					jsonObject.Put("respawnVars", logicJSONObject);
				}
			}
		}

		// Token: 0x06000E06 RID: 3590 RVA: 0x00033DAC File Offset: 0x00031FAC
		public LogicJSONArray SaveGameObjects(LogicGameObjectType gameObjectType)
		{
			LogicArrayList<LogicGameObject> logicArrayList = this.logicArrayList_0[(int)gameObjectType];
			LogicJSONArray logicJSONArray = new LogicJSONArray(logicArrayList.Size());
			int i = 0;
			int num = logicArrayList.Size();
			while (i < num)
			{
				LogicGameObject logicGameObject = logicArrayList[i];
				LogicJSONObject logicJSONObject = new LogicJSONObject();
				logicJSONObject.Put("data", new LogicJSONNumber(logicGameObject.GetData().GetGlobalID()));
				logicJSONObject.Put("id", new LogicJSONNumber(logicGameObject.GetGlobalID()));
				logicGameObject.Save(logicJSONObject, this.int_0);
				logicJSONArray.Add(logicJSONObject);
				i++;
			}
			return logicJSONArray;
		}

		// Token: 0x06000E07 RID: 3591 RVA: 0x00033E40 File Offset: 0x00032040
		public LogicJSONArray SaveObstacles()
		{
			LogicArrayList<LogicGameObject> logicArrayList = this.logicArrayList_0[3];
			LogicJSONArray logicJSONArray = new LogicJSONArray(logicArrayList.Size());
			int i = 0;
			int num = logicArrayList.Size();
			while (i < num)
			{
				LogicObstacle logicObstacle = (LogicObstacle)logicArrayList[i];
				if (!logicObstacle.IsFadingOut())
				{
					LogicJSONObject logicJSONObject = new LogicJSONObject();
					logicJSONObject.Put("data", new LogicJSONNumber(logicObstacle.GetData().GetGlobalID()));
					logicJSONObject.Put("id", new LogicJSONNumber(logicObstacle.GetGlobalID()));
					logicObstacle.Save(logicJSONObject, this.int_0);
					logicJSONArray.Add(logicJSONObject);
				}
				i++;
			}
			return logicJSONArray;
		}

		// Token: 0x06000E08 RID: 3592 RVA: 0x00033EE0 File Offset: 0x000320E0
		public LogicJSONArray SaveGameObjects(LogicGameObjectType gameObjectType, int layoutId)
		{
			LogicArrayList<LogicGameObject> logicArrayList = this.logicArrayList_0[(int)gameObjectType];
			LogicJSONArray logicJSONArray = new LogicJSONArray(logicArrayList.Size());
			int i = 0;
			int num = logicArrayList.Size();
			while (i < num)
			{
				LogicGameObject logicGameObject = logicArrayList[i];
				LogicJSONObject logicJSONObject = new LogicJSONObject();
				logicJSONObject.Put("data", new LogicJSONNumber(logicGameObject.GetData().GetGlobalID()));
				logicJSONObject.Put("id", new LogicJSONNumber(logicGameObject.GetGlobalID()));
				logicGameObject.SaveToSnapshot(logicJSONObject, layoutId);
				logicJSONArray.Add(logicJSONObject);
				i++;
			}
			return logicJSONArray;
		}

		// Token: 0x06000E09 RID: 3593 RVA: 0x00033F70 File Offset: 0x00032170
		public LogicJSONArray SaveObstacles(int layoutId)
		{
			LogicArrayList<LogicGameObject> logicArrayList = this.logicArrayList_0[3];
			LogicJSONArray logicJSONArray = new LogicJSONArray(logicArrayList.Size());
			int i = 0;
			int num = logicArrayList.Size();
			while (i < num)
			{
				LogicObstacle logicObstacle = (LogicObstacle)logicArrayList[i];
				if (!logicObstacle.IsFadingOut())
				{
					LogicJSONObject logicJSONObject = new LogicJSONObject();
					logicJSONObject.Put("data", new LogicJSONNumber(logicObstacle.GetData().GetGlobalID()));
					logicJSONObject.Put("id", new LogicJSONNumber(logicObstacle.GetGlobalID()));
					logicObstacle.SaveToSnapshot(logicJSONObject, layoutId);
					logicJSONArray.Add(logicJSONObject);
				}
				i++;
			}
			return logicJSONArray;
		}

		// Token: 0x06000E0A RID: 3594 RVA: 0x00009C07 File Offset: 0x00007E07
		public LogicBuilding GetClockTower()
		{
			return this.logicBuilding_1;
		}

		// Token: 0x06000E0B RID: 3595 RVA: 0x00009C0F File Offset: 0x00007E0F
		public LogicBuilding GetAllianceCastle()
		{
			return this.logicBuilding_0;
		}

		// Token: 0x06000E0C RID: 3596 RVA: 0x00009C17 File Offset: 0x00007E17
		public LogicAlliancePortal GetAlliancePortal()
		{
			return this.logicAlliancePortal_0;
		}

		// Token: 0x06000E0D RID: 3597 RVA: 0x00009C1F File Offset: 0x00007E1F
		public LogicVillageObject GetShipyard()
		{
			return this.logicVillageObject_0;
		}

		// Token: 0x06000E0E RID: 3598 RVA: 0x00009C27 File Offset: 0x00007E27
		public LogicBuilding GetLaboratory()
		{
			return this.logicBuilding_3;
		}

		// Token: 0x04000562 RID: 1378
		private readonly int int_0;

		// Token: 0x04000563 RID: 1379
		private readonly int[] int_1;

		// Token: 0x04000564 RID: 1380
		private LogicLevel logicLevel_0;

		// Token: 0x04000565 RID: 1381
		private LogicTileMap logicTileMap_0;

		// Token: 0x04000566 RID: 1382
		private LogicUnitProduction logicUnitProduction_0;

		// Token: 0x04000567 RID: 1383
		private LogicUnitProduction logicUnitProduction_1;

		// Token: 0x04000568 RID: 1384
		private LogicGameObjectManagerListener logicGameObjectManagerListener_0;

		// Token: 0x04000569 RID: 1385
		private LogicRandom logicRandom_0;

		// Token: 0x0400056A RID: 1386
		private LogicRandom logicRandom_1;

		// Token: 0x0400056B RID: 1387
		private readonly LogicComponentManager logicComponentManager_0;

		// Token: 0x0400056C RID: 1388
		private readonly LogicArrayList<LogicGameObject>[] logicArrayList_0;

		// Token: 0x0400056D RID: 1389
		private readonly LogicArrayList<LogicBuilding> logicArrayList_1;

		// Token: 0x0400056E RID: 1390
		private readonly LogicArrayList<LogicBuilding> logicArrayList_2;

		// Token: 0x0400056F RID: 1391
		private readonly LogicArrayList<int> logicArrayList_3;

		// Token: 0x04000570 RID: 1392
		private readonly LogicArrayList<int> logicArrayList_4;

		// Token: 0x04000571 RID: 1393
		private LogicBuilding logicBuilding_0;

		// Token: 0x04000572 RID: 1394
		private LogicBuilding logicBuilding_1;

		// Token: 0x04000573 RID: 1395
		private LogicBuilding logicBuilding_2;

		// Token: 0x04000574 RID: 1396
		private LogicBuilding logicBuilding_3;

		// Token: 0x04000575 RID: 1397
		private LogicBuilding logicBuilding_4;

		// Token: 0x04000576 RID: 1398
		private LogicBuilding logicBuilding_5;

		// Token: 0x04000577 RID: 1399
		private LogicAlliancePortal logicAlliancePortal_0;

		// Token: 0x04000578 RID: 1400
		private LogicObstacle logicObstacle_0;

		// Token: 0x04000579 RID: 1401
		private LogicVillageObject logicVillageObject_0;

		// Token: 0x0400057A RID: 1402
		private LogicVillageObject logicVillageObject_1;

		// Token: 0x0400057B RID: 1403
		private LogicVillageObject logicVillageObject_2;

		// Token: 0x0400057C RID: 1404
		private readonly LogicObstacleData logicObstacleData_0;

		// Token: 0x0400057D RID: 1405
		private LogicObstacleData logicObstacleData_1;

		// Token: 0x0400057E RID: 1406
		private LogicObstacleData logicObstacleData_2;

		// Token: 0x0400057F RID: 1407
		private int int_2;

		// Token: 0x04000580 RID: 1408
		private int int_3;

		// Token: 0x04000581 RID: 1409
		private int int_4;

		// Token: 0x04000582 RID: 1410
		private int int_5;

		// Token: 0x04000583 RID: 1411
		private int int_6;

		// Token: 0x04000584 RID: 1412
		private int int_7;

		// Token: 0x04000585 RID: 1413
		private int int_8;

		// Token: 0x04000586 RID: 1414
		private int int_9;
	}
}
