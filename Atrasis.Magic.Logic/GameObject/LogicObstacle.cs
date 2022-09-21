using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Time;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.GameObject
{
	// Token: 0x02000115 RID: 277
	public sealed class LogicObstacle : LogicGameObject
	{
		// Token: 0x06000E0F RID: 3599 RVA: 0x0003400C File Offset: 0x0003220C
		public LogicObstacle(LogicGameObjectData data, LogicLevel level, int villageType) : base(data, level, villageType)
		{
			LogicObstacleData obstacleData = this.GetObstacleData();
			if (obstacleData.GetSpawnObstacle() != null)
			{
				base.AddComponent(new LogicSpawnerComponent(this, obstacleData.GetSpawnObstacle(), obstacleData.GetSpawnRadius(), obstacleData.GetSpawnIntervalSeconds(), obstacleData.GetSpawnCount(), obstacleData.GetMaxSpawned(), obstacleData.GetMaxLifetimeSpawns()));
			}
			if (obstacleData.IsLootCart())
			{
				LogicLootCartComponent logicLootCartComponent = new LogicLootCartComponent(this);
				LogicDataTable table = LogicDataTables.GetTable(LogicDataType.RESOURCE);
				LogicBuilding townHall = base.GetGameObjectManager().GetTownHall();
				LogicArrayList<int> logicArrayList = new LogicArrayList<int>();
				int i = 0;
				int item = 0;
				while (i < table.GetItemCount())
				{
					LogicResourceData logicResourceData = (LogicResourceData)table.GetItemAt(i);
					if (townHall != null && !logicResourceData.IsPremiumCurrency() && logicResourceData.GetWarResourceReferenceData() == null)
					{
						item = LogicDataTables.GetTownHallLevel(townHall.GetUpgradeLevel()).GetCartLootCap(logicResourceData);
					}
					logicArrayList.Add(item);
					i++;
					item = 0;
				}
				logicLootCartComponent.SetCapacityCount(logicArrayList);
				base.AddComponent(logicLootCartComponent);
			}
		}

		// Token: 0x06000E10 RID: 3600 RVA: 0x00009C2F File Offset: 0x00007E2F
		public LogicObstacleData GetObstacleData()
		{
			return (LogicObstacleData)this.m_data;
		}

		// Token: 0x06000E11 RID: 3601 RVA: 0x00009C3C File Offset: 0x00007E3C
		public LogicLootCartComponent GetLootCartComponent()
		{
			return (LogicLootCartComponent)base.GetComponent(LogicComponentType.LOOT_CART);
		}

		// Token: 0x06000E12 RID: 3602 RVA: 0x00009C4B File Offset: 0x00007E4B
		public override void Destruct()
		{
			base.Destruct();
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
			this.int_6 = 0;
		}

		// Token: 0x06000E13 RID: 3603 RVA: 0x00009C74 File Offset: 0x00007E74
		public override bool IsPassable()
		{
			return this.GetObstacleData().IsPassable();
		}

		// Token: 0x06000E14 RID: 3604 RVA: 0x000340F8 File Offset: 0x000322F8
		public override void FastForwardTime(int time)
		{
			base.FastForwardTime(time);
			if (this.logicTimer_0 != null)
			{
				int remainingSeconds = this.logicTimer_0.GetRemainingSeconds(this.m_level.GetLogicTime());
				if (remainingSeconds <= time)
				{
					if (LogicDataTables.GetGlobals().CompleteConstructionOnlyHome())
					{
						this.logicTimer_0.StartTimer(0, this.m_level.GetLogicTime(), false, -1);
						return;
					}
					this.ClearingFinished(true);
					return;
				}
				else
				{
					this.logicTimer_0.StartTimer(remainingSeconds - time, this.m_level.GetLogicTime(), false, -1);
				}
			}
		}

		// Token: 0x06000E15 RID: 3605 RVA: 0x00034178 File Offset: 0x00032378
		public override void Tick()
		{
			base.Tick();
			if (this.logicTimer_0 != null && this.logicTimer_0.GetRemainingSeconds(this.m_level.GetLogicTime()) > 0 && this.m_level.GetRemainingClockTowerBoostTime() > 0 && this.GetObstacleData().GetVillageType() == 1)
			{
				this.logicTimer_0.SetFastForward(this.logicTimer_0.GetFastForward() + 4 * LogicDataTables.GetGlobals().GetClockTowerBoostMultiplier() - 4);
			}
			if (this.int_6 < 1)
			{
				if (this.logicTimer_0 != null && this.logicTimer_0.GetRemainingSeconds(this.m_level.GetLogicTime()) <= 0)
				{
					this.ClearingFinished(false);
					return;
				}
			}
			else
			{
				this.int_6 = LogicMath.Min(this.int_6 + 64, this.GetFadingOutTime());
			}
		}

		// Token: 0x06000E16 RID: 3606 RVA: 0x00009C81 File Offset: 0x00007E81
		public override bool ShouldDestruct()
		{
			return this.int_6 >= this.GetFadingOutTime();
		}

		// Token: 0x06000E17 RID: 3607 RVA: 0x0003423C File Offset: 0x0003243C
		public override void Save(LogicJSONObject jsonObject, int villageType)
		{
			base.Save(jsonObject, villageType);
			if (this.logicTimer_0 != null)
			{
				jsonObject.Put("clear_t", new LogicJSONNumber(this.logicTimer_0.GetRemainingSeconds(this.m_level.GetLogicTime())));
				jsonObject.Put("clear_ff", new LogicJSONNumber(this.logicTimer_0.GetFastForward()));
			}
			if (this.int_5 != 1)
			{
				jsonObject.Put("lmv", new LogicJSONNumber(this.int_5));
			}
		}

		// Token: 0x06000E18 RID: 3608 RVA: 0x00009C94 File Offset: 0x00007E94
		public override void SaveToSnapshot(LogicJSONObject jsonObject, int layoutId)
		{
			jsonObject.Put("x", new LogicJSONNumber(base.GetTileX() & 63));
			jsonObject.Put("y", new LogicJSONNumber(base.GetTileY() & 63));
		}

		// Token: 0x06000E19 RID: 3609 RVA: 0x000342BC File Offset: 0x000324BC
		public override void Load(LogicJSONObject jsonObject)
		{
			base.Load(jsonObject);
			LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("clear_t");
			if (jsonnumber != null)
			{
				if (this.logicTimer_0 != null)
				{
					this.logicTimer_0.Destruct();
					this.logicTimer_0 = null;
				}
				this.logicTimer_0 = new LogicTimer();
				this.logicTimer_0.StartTimer(jsonnumber.GetIntValue(), this.m_level.GetLogicTime(), false, -1);
				this.m_level.GetWorkerManagerAt(this.m_villageType).AllocateWorker(this);
			}
			LogicJSONNumber jsonnumber2 = jsonObject.GetJSONNumber("clear_ff");
			if (jsonnumber2 != null && this.logicTimer_0 != null)
			{
				this.logicTimer_0.SetFastForward(jsonnumber2.GetIntValue());
			}
			LogicJSONNumber jsonnumber3 = jsonObject.GetJSONNumber("loot_multiply_ver");
			if (jsonnumber3 == null)
			{
				jsonnumber3 = jsonObject.GetJSONNumber("lmv");
				if (jsonnumber3 == null)
				{
					this.int_5 = 1;
					return;
				}
			}
			this.int_5 = jsonnumber3.GetIntValue();
		}

		// Token: 0x06000E1A RID: 3610 RVA: 0x00009CC8 File Offset: 0x00007EC8
		public override void LoadFromSnapshot(LogicJSONObject jsonObject)
		{
			base.LoadFromSnapshot(jsonObject);
		}

		// Token: 0x06000E1B RID: 3611 RVA: 0x00009413 File Offset: 0x00007613
		public override void LoadingFinished()
		{
			base.LoadingFinished();
			if (this.m_listener != null)
			{
				this.m_listener.LoadedFromJSON();
			}
		}

		// Token: 0x06000E1C RID: 3612 RVA: 0x00002C4D File Offset: 0x00000E4D
		public override LogicGameObjectType GetGameObjectType()
		{
			return LogicGameObjectType.OBSTACLE;
		}

		// Token: 0x06000E1D RID: 3613 RVA: 0x00009CD1 File Offset: 0x00007ED1
		public override bool IsUnbuildable()
		{
			return this.GetObstacleData().IsTombstone() || this.GetObstacleData().IsLootCart();
		}

		// Token: 0x06000E1E RID: 3614 RVA: 0x00009CED File Offset: 0x00007EED
		public override int GetWidthInTiles()
		{
			return this.GetObstacleData().GetWidth();
		}

		// Token: 0x06000E1F RID: 3615 RVA: 0x00009CFA File Offset: 0x00007EFA
		public override int GetHeightInTiles()
		{
			return this.GetObstacleData().GetHeight();
		}

		// Token: 0x06000E20 RID: 3616 RVA: 0x00009D07 File Offset: 0x00007F07
		public bool IsTombstone()
		{
			return this.GetObstacleData().IsTombstone();
		}

		// Token: 0x06000E21 RID: 3617 RVA: 0x00009D14 File Offset: 0x00007F14
		public int GetTombGroup()
		{
			return this.GetObstacleData().GetTombGroup();
		}

		// Token: 0x06000E22 RID: 3618 RVA: 0x00009D21 File Offset: 0x00007F21
		public int GetFadeTime()
		{
			return this.int_6;
		}

		// Token: 0x06000E23 RID: 3619 RVA: 0x00034394 File Offset: 0x00032594
		public int GetFadingOutTime()
		{
			LogicObstacleData obstacleData = this.GetObstacleData();
			if (obstacleData.IsTallGrass())
			{
				return 1000;
			}
			if (!obstacleData.IsLootCart())
			{
				return 2000;
			}
			return 4000;
		}

		// Token: 0x06000E24 RID: 3620 RVA: 0x00009D29 File Offset: 0x00007F29
		public int GetLootMultiplyVersion()
		{
			return this.int_5;
		}

		// Token: 0x06000E25 RID: 3621 RVA: 0x00009D31 File Offset: 0x00007F31
		public void SetLootMultiplyVersion(int version)
		{
			this.int_5 = version;
		}

		// Token: 0x06000E26 RID: 3622 RVA: 0x00009D3A File Offset: 0x00007F3A
		public int GetRemainingClearingTime()
		{
			if (this.logicTimer_0 != null)
			{
				return this.logicTimer_0.GetRemainingSeconds(this.m_level.GetLogicTime());
			}
			return 0;
		}

		// Token: 0x06000E27 RID: 3623 RVA: 0x00009D5C File Offset: 0x00007F5C
		public int GetRemainingClearingTimeMS()
		{
			if (this.logicTimer_0 != null)
			{
				return this.logicTimer_0.GetRemainingMS(this.m_level.GetLogicTime());
			}
			return 0;
		}

		// Token: 0x06000E28 RID: 3624 RVA: 0x00009D7E File Offset: 0x00007F7E
		public bool IsFadingOut()
		{
			return this.int_6 > 0;
		}

		// Token: 0x06000E29 RID: 3625 RVA: 0x00009D89 File Offset: 0x00007F89
		public bool CanStartClearing()
		{
			return this.logicTimer_0 == null && this.int_6 == 0;
		}

		// Token: 0x06000E2A RID: 3626 RVA: 0x00009D9E File Offset: 0x00007F9E
		public bool IsClearingOnGoing()
		{
			return this.logicTimer_0 != null;
		}

		// Token: 0x06000E2B RID: 3627 RVA: 0x000343CC File Offset: 0x000325CC
		public void StartClearing()
		{
			if (this.logicTimer_0 == null && this.int_6 == 0)
			{
				if (this.GetObstacleData().GetClearTime() != 0)
				{
					this.m_level.GetWorkerManagerAt(this.m_villageType).AllocateWorker(this);
					this.logicTimer_0 = new LogicTimer();
					this.logicTimer_0.StartTimer(this.GetObstacleData().GetClearTime(), this.m_level.GetLogicTime(), false, -1);
					return;
				}
				this.ClearingFinished(false);
			}
		}

		// Token: 0x06000E2C RID: 3628 RVA: 0x00009DA9 File Offset: 0x00007FA9
		public void CancelClearing()
		{
			this.m_level.GetWorkerManagerAt(this.m_data.GetVillageType()).DeallocateWorker(this);
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
		}

		// Token: 0x06000E2D RID: 3629 RVA: 0x00034444 File Offset: 0x00032644
		public void ClearingFinished(bool ignoreState)
		{
			int state = this.m_level.GetState();
			if ((state == 1 || (!LogicDataTables.GetGlobals().CompleteConstructionOnlyHome() && ignoreState)) && this.m_level.GetHomeOwnerAvatar().IsClientAvatar())
			{
				LogicClientAvatar logicClientAvatar = (LogicClientAvatar)this.m_level.GetHomeOwnerAvatar();
				LogicObstacleData obstacleData = this.GetObstacleData();
				LogicResourceData lootResourceData = obstacleData.GetLootResourceData();
				int lootCount = obstacleData.GetLootCount();
				if (obstacleData.IsLootCart())
				{
					LogicLootCartComponent logicLootCartComponent = (LogicLootCartComponent)base.GetComponent(LogicComponentType.LOOT_CART);
					if (logicLootCartComponent != null)
					{
						LogicDataTable table = LogicDataTables.GetTable(LogicDataType.RESOURCE);
						bool flag = true;
						for (int i = 0; i < table.GetItemCount(); i++)
						{
							LogicResourceData logicResourceData = (LogicResourceData)table.GetItemAt(i);
							if (!logicResourceData.IsPremiumCurrency() && logicResourceData.GetWarResourceReferenceData() == null)
							{
								int resourceCount = logicLootCartComponent.GetResourceCount(i);
								int num = LogicMath.Min(logicClientAvatar.GetUnusedResourceCap(logicResourceData), resourceCount);
								int num2 = resourceCount - num;
								if (num > 0)
								{
									logicClientAvatar.CommodityCountChangeHelper(0, logicResourceData, num);
									logicLootCartComponent.SetResourceCount(i, num2);
								}
								if (num2 > 0)
								{
									flag = false;
								}
							}
						}
						if (!flag)
						{
							return;
						}
					}
				}
				if (!obstacleData.IsTombstone() && !obstacleData.IsLootCart())
				{
					this.m_level.GetAchievementManager().ObstacleCleared();
				}
				this.m_level.GetWorkerManagerAt(this.m_villageType).DeallocateWorker(this);
				base.XpGainHelper(LogicGamePlayUtil.TimeToExp(obstacleData.GetClearTime()), logicClientAvatar, ignoreState || state == 1);
				if (lootResourceData != null && lootCount > 0)
				{
					if (logicClientAvatar != null)
					{
						if (lootResourceData.IsPremiumCurrency())
						{
							int num3 = 1;
							if (this.int_5 >= 2)
							{
								num3 = obstacleData.GetLootMultiplierVersion2();
							}
							int num4 = obstacleData.GetName().Equals("Bonus Gembox") ? (lootCount * num3) : this.m_level.GetGameObjectManagerAt(this.m_villageType).IncreaseObstacleClearCounter(num3);
							if (num4 > 0)
							{
								logicClientAvatar.SetDiamonds(logicClientAvatar.GetDiamonds() + num4);
								logicClientAvatar.SetFreeDiamonds(logicClientAvatar.GetFreeDiamonds() + num4);
								logicClientAvatar.GetChangeListener().FreeDiamondsAdded(num4, 6);
							}
						}
						else
						{
							int num5 = LogicMath.Min(logicClientAvatar.GetUnusedResourceCap(lootResourceData), lootCount);
							if (num5 > 0)
							{
								logicClientAvatar.CommodityCountChangeHelper(0, lootResourceData, num5);
							}
						}
					}
					else
					{
						Debugger.Error("LogicObstacle::clearingFinished - Home owner avatar is NULL!");
					}
				}
				obstacleData.IsEnabledInVillageType(this.m_level.GetVillageType());
				if (this.logicTimer_0 != null)
				{
					this.logicTimer_0.Destruct();
					this.logicTimer_0 = null;
				}
				this.int_6 = 1;
			}
		}

		// Token: 0x06000E2E RID: 3630 RVA: 0x000346A8 File Offset: 0x000328A8
		public bool SpeedUpClearing()
		{
			if (this.logicTimer_0 != null)
			{
				LogicClientAvatar playerAvatar = this.m_level.GetPlayerAvatar();
				int speedUpCost = LogicGamePlayUtil.GetSpeedUpCost(this.logicTimer_0.GetRemainingSeconds(this.m_level.GetLogicTime()), 0, this.m_villageType);
				if (playerAvatar.HasEnoughDiamonds(speedUpCost, true, this.m_level))
				{
					playerAvatar.UseDiamonds(speedUpCost);
					playerAvatar.GetChangeListener().DiamondPurchaseMade(3, this.m_data.GetGlobalID(), 0, speedUpCost, this.m_level.GetVillageType());
					this.ClearingFinished(false);
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000E2F RID: 3631 RVA: 0x00034734 File Offset: 0x00032934
		public void ReengageLootCart(int secs)
		{
			LogicObstacleData obstacleData = this.GetObstacleData();
			LogicLootCartComponent logicLootCartComponent = (LogicLootCartComponent)base.GetComponent(LogicComponentType.LOOT_CART);
			LogicBuilding townHall = this.m_level.GetGameObjectManagerAt(0).GetTownHall();
			Debugger.DoAssert(obstacleData.IsLootCart(), string.Empty);
			Debugger.DoAssert(logicLootCartComponent != null, string.Empty);
			Debugger.DoAssert(townHall != null, string.Empty);
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.RESOURCE);
			for (int i = 0; i < table.GetItemCount(); i++)
			{
				LogicResourceData data = (LogicResourceData)table.GetItemAt(i);
				LogicTownhallLevelData townHallLevel = LogicDataTables.GetTownHallLevel(townHall.GetUpgradeLevel());
				int num = secs * townHallLevel.GetCartLootReengagement(data) / 100;
				if (num > logicLootCartComponent.GetResourceCount(i))
				{
					logicLootCartComponent.SetResourceCount(i, num);
				}
			}
		}

		// Token: 0x04000587 RID: 1415
		private LogicTimer logicTimer_0;

		// Token: 0x04000588 RID: 1416
		private int int_5;

		// Token: 0x04000589 RID: 1417
		private int int_6;
	}
}
