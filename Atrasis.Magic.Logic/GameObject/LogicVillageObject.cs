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

namespace Atrasis.Magic.Logic.GameObject
{
	// Token: 0x02000119 RID: 281
	public sealed class LogicVillageObject : LogicGameObject
	{
		// Token: 0x06000E9C RID: 3740 RVA: 0x0000A131 File Offset: 0x00008331
		public LogicVillageObject(LogicGameObjectData data, LogicLevel level, int villageType) : base(data, level, villageType)
		{
		}

		// Token: 0x06000E9D RID: 3741 RVA: 0x0000A13C File Offset: 0x0000833C
		public LogicVillageObjectData GetVillageObjectData()
		{
			return (LogicVillageObjectData)this.m_data;
		}

		// Token: 0x06000E9E RID: 3742 RVA: 0x00038FEC File Offset: 0x000371EC
		public bool CanUpgrade(bool callListener)
		{
			if (!this.bool_0)
			{
				LogicVillageObjectData villageObjectData = this.GetVillageObjectData();
				if (this.int_5 < villageObjectData.GetUpgradeLevelCount() - 1)
				{
					if (this.m_level.GetTownHallLevel(this.m_level.GetVillageType()) >= this.GetRequiredTownHallLevelForUpgrade())
					{
						return true;
					}
					if (callListener)
					{
						this.m_level.GetGameListener().TownHallLevelTooLow(this.GetRequiredTownHallLevelForUpgrade());
					}
					return false;
				}
			}
			return false;
		}

		// Token: 0x06000E9F RID: 3743 RVA: 0x00039054 File Offset: 0x00037254
		public void StartUpgrading(bool ignoreListener)
		{
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
			LogicVillageObjectData villageObjectData = this.GetVillageObjectData();
			int buildTime = villageObjectData.GetBuildTime(this.GetUpgradeLevel() + 1);
			this.bool_1 = true;
			if (buildTime <= 0)
			{
				this.FinishConstruction(false, true);
				return;
			}
			if (villageObjectData.IsRequiresBuilder())
			{
				this.m_level.GetWorkerManagerAt(villageObjectData.GetVillageType()).AllocateWorker(this);
			}
			base.EnableComponent(LogicComponentType.RESOURCE_PRODUCTION, false);
			base.EnableComponent(LogicComponentType.UNIT_PRODUCTION, false);
			base.EnableComponent(LogicComponentType.UNIT_UPGRADE, false);
			this.logicTimer_0 = new LogicTimer();
			this.logicTimer_0.StartTimer(buildTime, this.m_level.GetLogicTime(), true, this.m_level.GetHomeOwnerAvatarChangeListener().GetCurrentTimestamp());
		}

		// Token: 0x06000EA0 RID: 3744 RVA: 0x00039110 File Offset: 0x00037310
		public void FinishConstruction(bool ignoreState, bool ignoreListener)
		{
			int state = this.m_level.GetState();
			if (state == 1 || (!LogicDataTables.GetGlobals().CompleteConstructionOnlyHome() && ignoreState))
			{
				if (this.m_level.GetHomeOwnerAvatar() != null && this.m_level.GetHomeOwnerAvatar().IsClientAvatar())
				{
					if (this.logicTimer_0 != null)
					{
						this.logicTimer_0.Destruct();
						this.logicTimer_0 = null;
					}
					LogicAvatar homeOwnerAvatar = this.m_level.GetHomeOwnerAvatar();
					LogicVillageObjectData villageObjectData = this.GetVillageObjectData();
					if (villageObjectData.IsRequiresBuilder())
					{
						this.m_level.GetWorkerManagerAt(villageObjectData.GetVillageType()).DeallocateWorker(this);
					}
					this.bool_0 = false;
					if (this.int_5 == 0 && !this.bool_1)
					{
						int xp = LogicMath.Sqrt(villageObjectData.GetBuildTime(0));
						base.XpGainHelper(xp, homeOwnerAvatar, ignoreState);
					}
					else
					{
						int index = this.int_5 + 1;
						if (this.int_5 >= villageObjectData.GetUpgradeLevelCount() - 1)
						{
							Debugger.Warning("LogicVillageObject - Trying to upgrade to level that doesn't exist! - " + villageObjectData.GetName());
							index = villageObjectData.GetUpgradeLevelCount() - 1;
						}
						int xp2 = LogicMath.Sqrt(villageObjectData.GetBuildTime(index));
						this.int_5 = index;
						base.XpGainHelper(xp2, homeOwnerAvatar, ignoreState);
					}
					this.bool_1 = false;
					if (this.m_listener != null)
					{
						this.m_listener.RefreshState();
					}
					if (state == 1)
					{
						this.m_level.GetAchievementManager().RefreshStatus();
						return;
					}
				}
				else
				{
					Debugger.Error("LogicVillageObject::finishCostruction failed - Avatar is null or not client avatar");
				}
			}
		}

		// Token: 0x06000EA1 RID: 3745 RVA: 0x00039274 File Offset: 0x00037474
		public bool SpeedUpCostruction()
		{
			if (this.logicTimer_0 != null)
			{
				LogicClientAvatar playerAvatar = this.m_level.GetPlayerAvatar();
				int speedUpCost = LogicGamePlayUtil.GetSpeedUpCost(this.logicTimer_0.GetRemainingSeconds(this.m_level.GetLogicTime()), 0, this.m_villageType);
				if (playerAvatar.HasEnoughDiamonds(speedUpCost, true, this.m_level))
				{
					playerAvatar.UseDiamonds(speedUpCost);
					playerAvatar.GetChangeListener().DiamondPurchaseMade(0, this.m_data.GetGlobalID(), this.int_5 + (this.bool_1 ? 2 : 1), speedUpCost, this.m_level.GetVillageType());
					this.FinishConstruction(false, true);
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000EA2 RID: 3746 RVA: 0x0000A149 File Offset: 0x00008349
		public int GetRequiredTownHallLevelForUpgrade()
		{
			return this.GetVillageObjectData().GetRequiredTownHallLevel(LogicMath.Min(this.int_5 + 1, this.GetVillageObjectData().GetUpgradeLevelCount() - 1));
		}

		// Token: 0x06000EA3 RID: 3747 RVA: 0x0000A170 File Offset: 0x00008370
		public int GetRemainingConstructionTime()
		{
			if (this.logicTimer_0 != null)
			{
				return this.logicTimer_0.GetRemainingSeconds(this.m_level.GetLogicTime());
			}
			return 0;
		}

		// Token: 0x06000EA4 RID: 3748 RVA: 0x0000A192 File Offset: 0x00008392
		public override void Destruct()
		{
			base.Destruct();
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
		}

		// Token: 0x06000EA5 RID: 3749 RVA: 0x00039314 File Offset: 0x00037514
		public override void FastForwardTime(int secs)
		{
			if (this.logicTimer_0 != null)
			{
				if (this.logicTimer_0.GetEndTimestamp() == -1)
				{
					int remainingSeconds = this.logicTimer_0.GetRemainingSeconds(this.m_level.GetLogicTime());
					if (remainingSeconds > secs)
					{
						base.FastForwardTime(secs);
						this.logicTimer_0.StartTimer(remainingSeconds - secs, this.m_level.GetLogicTime(), false, -1);
					}
					else
					{
						if (LogicDataTables.GetGlobals().CompleteConstructionOnlyHome())
						{
							base.FastForwardTime(secs);
							this.logicTimer_0.StartTimer(0, this.m_level.GetLogicTime(), false, -1);
							return;
						}
						base.FastForwardTime(remainingSeconds);
						this.FinishConstruction(true, true);
						base.FastForwardTime(secs - remainingSeconds);
						return;
					}
				}
				else
				{
					this.logicTimer_0.AdjustEndSubtick(this.m_level);
					if (this.logicTimer_0.GetRemainingSeconds(this.m_level.GetLogicTime()) == 0)
					{
						if (LogicDataTables.GetGlobals().CompleteConstructionOnlyHome())
						{
							base.FastForwardTime(secs);
							this.logicTimer_0.StartTimer(0, this.m_level.GetLogicTime(), false, -1);
							return;
						}
						base.FastForwardTime(0);
						this.FinishConstruction(true, true);
						base.FastForwardTime(secs);
						return;
					}
					else
					{
						base.FastForwardTime(secs);
					}
				}
				int updatedClockTowerBoostTime = this.m_level.GetUpdatedClockTowerBoostTime();
				if (updatedClockTowerBoostTime > 0 && !this.m_level.IsClockTowerBoostPaused() && this.m_data.GetVillageType() == 1)
				{
					this.logicTimer_0.SetFastForward(this.logicTimer_0.GetFastForward() + 60 * LogicMath.Min(secs, updatedClockTowerBoostTime) * (LogicDataTables.GetGlobals().GetClockTowerBoostMultiplier() - 1));
					return;
				}
			}
			else
			{
				base.FastForwardTime(secs);
			}
		}

		// Token: 0x06000EA6 RID: 3750 RVA: 0x0003949C File Offset: 0x0003769C
		public override void SubTick()
		{
			LogicCombatComponent combatComponent = base.GetCombatComponent(false);
			if (combatComponent != null)
			{
				combatComponent.SubTick();
			}
			if (this.logicTimer_0 != null && this.logicTimer_0.GetRemainingSeconds(this.m_level.GetLogicTime()) <= 0)
			{
				this.FinishConstruction(false, true);
			}
		}

		// Token: 0x06000EA7 RID: 3751 RVA: 0x000394E4 File Offset: 0x000376E4
		public override void Save(LogicJSONObject jsonObject, int villageType)
		{
			if (this.int_5 == 0 && this.logicTimer_0 != null && !this.bool_1)
			{
				jsonObject.Put("lvl", new LogicJSONNumber(-1));
			}
			else
			{
				jsonObject.Put("lvl", new LogicJSONNumber(this.int_5));
			}
			if (this.logicTimer_0 != null)
			{
				jsonObject.Put("const_t", new LogicJSONNumber(this.logicTimer_0.GetRemainingSeconds(this.m_level.GetLogicTime())));
				if (this.logicTimer_0.GetEndTimestamp() != -1)
				{
					jsonObject.Put("const_t_end", new LogicJSONNumber(this.logicTimer_0.GetEndTimestamp()));
				}
				if (this.logicTimer_0.GetFastForward() != -1)
				{
					jsonObject.Put("con_ff", new LogicJSONNumber(this.logicTimer_0.GetFastForward()));
				}
			}
			if (this.bool_0)
			{
				jsonObject.Put("locked", new LogicJSONBoolean(true));
			}
			base.Save(jsonObject, villageType);
		}

		// Token: 0x06000EA8 RID: 3752 RVA: 0x000395D4 File Offset: 0x000377D4
		public override void SaveToSnapshot(LogicJSONObject jsonObject, int layoutId)
		{
			jsonObject.Put("x", new LogicJSONNumber(base.GetTileX() & 63));
			jsonObject.Put("y", new LogicJSONNumber(base.GetTileY() & 63));
			if (this.int_5 == 0 && this.logicTimer_0 != null && !this.bool_1)
			{
				jsonObject.Put("lvl", new LogicJSONNumber(-1));
			}
			else
			{
				jsonObject.Put("lvl", new LogicJSONNumber(this.int_5));
			}
			if (this.logicTimer_0 != null)
			{
				jsonObject.Put("const_t", new LogicJSONNumber(this.logicTimer_0.GetRemainingSeconds(this.m_level.GetLogicTime())));
			}
			base.SaveToSnapshot(jsonObject, layoutId);
		}

		// Token: 0x06000EA9 RID: 3753 RVA: 0x0003968C File Offset: 0x0003788C
		public override void Load(LogicJSONObject jsonObject)
		{
			this.LoadUpgradeLevel(jsonObject);
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
			LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("const_t");
			if (jsonnumber != null)
			{
				int num = jsonnumber.GetIntValue();
				if (!LogicDataTables.GetGlobals().ClampBuildingTimes() && this.int_5 < this.GetVillageObjectData().GetUpgradeLevelCount() - 1)
				{
					num = LogicMath.Min(num, this.GetVillageObjectData().GetBuildTime(this.int_5 + 1));
				}
				this.logicTimer_0 = new LogicTimer();
				this.logicTimer_0.StartTimer(num, this.m_level.GetLogicTime(), false, -1);
				LogicJSONNumber jsonnumber2 = jsonObject.GetJSONNumber("const_t_end");
				if (jsonnumber2 != null)
				{
					this.logicTimer_0.SetEndTimestamp(jsonnumber2.GetIntValue());
				}
				LogicJSONNumber jsonnumber3 = jsonObject.GetJSONNumber("con_ff");
				if (jsonnumber3 != null)
				{
					this.logicTimer_0.SetFastForward(jsonnumber3.GetIntValue());
				}
				LogicVillageObjectData villageObjectData = this.GetVillageObjectData();
				if (villageObjectData.IsRequiresBuilder() && !villageObjectData.IsAutomaticUpgrades())
				{
					this.m_level.GetWorkerManagerAt(this.m_villageType).AllocateWorker(this);
				}
				this.bool_1 = (this.int_5 != -1);
			}
			this.int_5 = LogicMath.Clamp(this.int_5, 0, this.GetVillageObjectData().GetUpgradeLevelCount() - 1);
			base.Load(jsonObject);
			base.SetPositionXY((this.GetVillageObjectData().GetTileX100() << 9) / 100, (this.GetVillageObjectData().GetTileY100() << 9) / 100);
		}

		// Token: 0x06000EAA RID: 3754 RVA: 0x0000A1B4 File Offset: 0x000083B4
		public override void LoadFromSnapshot(LogicJSONObject jsonObject)
		{
			this.LoadUpgradeLevel(jsonObject);
			base.LoadFromSnapshot(jsonObject);
			base.SetPositionXY((this.GetVillageObjectData().GetTileX100() << 9) / 100, (this.GetVillageObjectData().GetTileY100() << 9) / 100);
		}

		// Token: 0x06000EAB RID: 3755 RVA: 0x00039804 File Offset: 0x00037A04
		public void LoadUpgradeLevel(LogicJSONObject jsonObject)
		{
			LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("lvl");
			if (jsonnumber != null)
			{
				this.int_5 = jsonnumber.GetIntValue();
				int upgradeLevelCount = this.GetVillageObjectData().GetUpgradeLevelCount();
				if (this.int_5 >= upgradeLevelCount)
				{
					Debugger.Warning(string.Format("LogicVillageObject::load() - Loaded upgrade level {0} is over max! (max = {1}) id {2} data id {3}", new object[]
					{
						jsonnumber.GetIntValue(),
						upgradeLevelCount,
						this.m_globalId,
						this.m_data.GetGlobalID()
					}));
					this.int_5 = upgradeLevelCount - 1;
				}
				else if (this.int_5 < -1)
				{
					Debugger.Error("LogicVillageObject::load() - Loaded an illegal upgrade level!");
				}
			}
			else
			{
				Debugger.Error("LogicVillageObject::load - Upgrade level was not found!");
			}
			if (this.GetVillageObjectData().IsRequiresBuilder())
			{
				this.m_level.GetWorkerManagerAt(this.m_villageType).DeallocateWorker(this);
			}
			LogicJSONBoolean jsonboolean = jsonObject.GetJSONBoolean("locked");
			if (jsonboolean != null)
			{
				this.bool_0 = jsonboolean.IsTrue();
			}
		}

		// Token: 0x06000EAC RID: 3756 RVA: 0x00009413 File Offset: 0x00007613
		public override void LoadingFinished()
		{
			base.LoadingFinished();
			if (this.m_listener != null)
			{
				this.m_listener.LoadedFromJSON();
			}
		}

		// Token: 0x06000EAD RID: 3757 RVA: 0x0000A1EC File Offset: 0x000083EC
		public override LogicGameObjectType GetGameObjectType()
		{
			return LogicGameObjectType.VILLAGE_OBJECT;
		}

		// Token: 0x06000EAE RID: 3758 RVA: 0x00002465 File Offset: 0x00000665
		public override int GetWidthInTiles()
		{
			return 0;
		}

		// Token: 0x06000EAF RID: 3759 RVA: 0x00002465 File Offset: 0x00000665
		public override int GetHeightInTiles()
		{
			return 0;
		}

		// Token: 0x06000EB0 RID: 3760 RVA: 0x0000A1EF File Offset: 0x000083EF
		public int GetUpgradeLevel()
		{
			return this.int_5;
		}

		// Token: 0x06000EB1 RID: 3761 RVA: 0x0000A1F7 File Offset: 0x000083F7
		public void SetUpgradeLevel(int upgLevel)
		{
			this.int_5 = upgLevel;
		}

		// Token: 0x06000EB2 RID: 3762 RVA: 0x0000A200 File Offset: 0x00008400
		public bool IsConstructing()
		{
			return this.logicTimer_0 != null;
		}

		// Token: 0x040005D9 RID: 1497
		private LogicTimer logicTimer_0;

		// Token: 0x040005DA RID: 1498
		private bool bool_0;

		// Token: 0x040005DB RID: 1499
		private bool bool_1;

		// Token: 0x040005DC RID: 1500
		private int int_5;
	}
}
