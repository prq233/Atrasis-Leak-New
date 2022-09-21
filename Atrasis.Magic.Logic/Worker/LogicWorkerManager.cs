using System;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Worker
{
	// Token: 0x02000006 RID: 6
	public class LogicWorkerManager
	{
		// Token: 0x0600001B RID: 27 RVA: 0x00002143 File Offset: 0x00000343
		public LogicWorkerManager(LogicLevel level)
		{
			this.logicLevel_0 = level;
			this.logicArrayList_0 = new LogicArrayList<LogicGameObject>();
		}

		// Token: 0x0600001C RID: 28 RVA: 0x0000215D File Offset: 0x0000035D
		public void Destruct()
		{
			if (this.logicArrayList_0 != null)
			{
				this.logicArrayList_0.Destruct();
				this.logicArrayList_0 = null;
			}
			this.logicLevel_0 = null;
			this.int_0 = 0;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002187 File Offset: 0x00000387
		public int GetFreeWorkers()
		{
			return this.int_0 - this.logicArrayList_0.Size();
		}

		// Token: 0x0600001E RID: 30 RVA: 0x0000219B File Offset: 0x0000039B
		public int GetTotalWorkers()
		{
			return this.int_0;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x000021A3 File Offset: 0x000003A3
		public void AllocateWorker(LogicGameObject gameObject)
		{
			if (this.logicArrayList_0.IndexOf(gameObject) != -1)
			{
				Debugger.Warning("LogicWorkerManager::allocateWorker called twice for same target!");
				return;
			}
			this.logicArrayList_0.Add(gameObject);
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00012264 File Offset: 0x00010464
		public void DeallocateWorker(LogicGameObject gameObject)
		{
			int num = this.logicArrayList_0.IndexOf(gameObject);
			if (num != -1)
			{
				this.logicArrayList_0.Remove(num);
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000021CB File Offset: 0x000003CB
		public void RemoveGameObjectReference(LogicGameObject gameObject)
		{
			this.DeallocateWorker(gameObject);
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000021D4 File Offset: 0x000003D4
		public void IncreaseWorkerCount()
		{
			this.int_0++;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00012290 File Offset: 0x00010490
		public void DecreaseWorkerCount()
		{
			int num = this.int_0;
			this.int_0 = num - 1;
			if (num <= 0)
			{
				Debugger.Error("LogicWorkerManager - Total worker count below 0");
			}
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000122BC File Offset: 0x000104BC
		public LogicGameObject GetShortestTaskGO()
		{
			LogicGameObject logicGameObject = null;
			int i = 0;
			int num = -1;
			int num2 = 0;
			while (i < this.logicArrayList_0.Size())
			{
				LogicGameObject logicGameObject2 = this.logicArrayList_0[i];
				LogicGameObjectType gameObjectType = this.logicArrayList_0[i].GetGameObjectType();
				switch (gameObjectType)
				{
				case LogicGameObjectType.BUILDING:
				{
					LogicBuilding logicBuilding = (LogicBuilding)logicGameObject2;
					if (logicBuilding.IsConstructing())
					{
						num2 = logicBuilding.GetRemainingConstructionTime();
					}
					else
					{
						LogicHeroBaseComponent heroBaseComponent = logicBuilding.GetHeroBaseComponent();
						if (heroBaseComponent == null)
						{
							Debugger.Warning("LogicWorkerManager - Worker allocated to building with remaining construction time 0");
						}
						else if (heroBaseComponent.IsUpgrading())
						{
							num2 = heroBaseComponent.GetRemainingUpgradeSeconds();
						}
						else
						{
							Debugger.Warning("LogicWorkerManager - Worker allocated to altar/herobase without hero upgrading");
						}
					}
					break;
				}
				case LogicGameObjectType.CHARACTER:
				case LogicGameObjectType.PROJECTILE:
					break;
				case LogicGameObjectType.OBSTACLE:
				{
					LogicObstacle logicObstacle = (LogicObstacle)logicGameObject2;
					if (logicObstacle.IsClearingOnGoing())
					{
						num2 = logicObstacle.GetRemainingClearingTime();
					}
					else
					{
						Debugger.Warning("LogicWorkerManager - Worker allocated to obstacle with remaining clearing time 0");
					}
					break;
				}
				case LogicGameObjectType.TRAP:
				{
					LogicTrap logicTrap = (LogicTrap)logicGameObject2;
					if (logicTrap.IsConstructing())
					{
						num2 = logicTrap.GetRemainingConstructionTime();
					}
					else
					{
						Debugger.Warning("LogicWorkerManager - Worker allocated to trap with remaining construction time 0");
					}
					break;
				}
				default:
					if (gameObjectType == LogicGameObjectType.VILLAGE_OBJECT)
					{
						LogicVillageObject logicVillageObject = (LogicVillageObject)logicGameObject2;
						if (logicVillageObject.IsConstructing())
						{
							num2 = logicVillageObject.GetRemainingConstructionTime();
						}
						else
						{
							Debugger.Error("LogicWorkerManager - Worker allocated to building with remaining construction time 0 (vilobj)");
						}
					}
					break;
				}
				if (logicGameObject == null || num > num2)
				{
					logicGameObject = logicGameObject2;
					num = num2;
				}
				i++;
				num2 = 0;
			}
			return logicGameObject;
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00012414 File Offset: 0x00010614
		public bool FinishTaskOfOneWorker()
		{
			LogicGameObject shortestTaskGO = this.GetShortestTaskGO();
			if (shortestTaskGO != null)
			{
				LogicGameObjectType gameObjectType = shortestTaskGO.GetGameObjectType();
				switch (gameObjectType)
				{
				case LogicGameObjectType.BUILDING:
				{
					LogicBuilding logicBuilding = (LogicBuilding)shortestTaskGO;
					if (logicBuilding.IsConstructing())
					{
						return logicBuilding.SpeedUpConstruction();
					}
					if (logicBuilding.GetHeroBaseComponent() != null)
					{
						return logicBuilding.GetHeroBaseComponent().SpeedUp();
					}
					break;
				}
				case LogicGameObjectType.CHARACTER:
				case LogicGameObjectType.PROJECTILE:
					break;
				case LogicGameObjectType.OBSTACLE:
				{
					LogicObstacle logicObstacle = (LogicObstacle)shortestTaskGO;
					if (logicObstacle.IsClearingOnGoing())
					{
						return logicObstacle.SpeedUpClearing();
					}
					break;
				}
				case LogicGameObjectType.TRAP:
				{
					LogicTrap logicTrap = (LogicTrap)shortestTaskGO;
					if (logicTrap.IsConstructing())
					{
						return logicTrap.SpeedUpConstruction();
					}
					break;
				}
				default:
					if (gameObjectType == LogicGameObjectType.VILLAGE_OBJECT)
					{
						LogicVillageObject logicVillageObject = (LogicVillageObject)shortestTaskGO;
						if (logicVillageObject.IsConstructing())
						{
							return logicVillageObject.SpeedUpCostruction();
						}
					}
					break;
				}
			}
			return false;
		}

		// Token: 0x0400001F RID: 31
		private LogicLevel logicLevel_0;

		// Token: 0x04000020 RID: 32
		private LogicArrayList<LogicGameObject> logicArrayList_0;

		// Token: 0x04000021 RID: 33
		private int int_0;
	}
}
