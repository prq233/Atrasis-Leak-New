using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Time;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.GameObject.Component
{
	// Token: 0x02000123 RID: 291
	public sealed class LogicHeroBaseComponent : LogicComponent
	{
		// Token: 0x06000F6D RID: 3949 RVA: 0x0000A837 File Offset: 0x00008A37
		public LogicHeroBaseComponent(LogicGameObject gameObject, LogicHeroData data) : base(gameObject)
		{
			this.logicHeroData_0 = data;
		}

		// Token: 0x06000F6E RID: 3950 RVA: 0x0000A847 File Offset: 0x00008A47
		public override void Destruct()
		{
			base.Destruct();
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
		}

		// Token: 0x06000F6F RID: 3951 RVA: 0x00041710 File Offset: 0x0003F910
		public override void Tick()
		{
			this.int_0 += 64;
			int num = 1000;
			if (this.m_parent.GetRemainingBoostTime() > 0 && !this.m_parent.IsBoostPaused())
			{
				num /= LogicDataTables.GetGlobals().GetHeroRestBoostMultiplier();
			}
			if (this.m_parent.GetLevel().GetRemainingClockTowerBoostTime() > 0)
			{
				LogicGameObjectData data = this.m_parent.GetData();
				if (data.GetDataType() == LogicDataType.BUILDING && data.GetVillageType() == 1)
				{
					num /= LogicDataTables.GetGlobals().GetClockTowerBoostMultiplier();
					if (this.logicTimer_0 != null)
					{
						this.logicTimer_0.SetFastForward(this.logicTimer_0.GetFastForward() + 4 * LogicDataTables.GetGlobals().GetClockTowerBoostMultiplier() - 4);
					}
				}
			}
			if (this.int_0 > num)
			{
				if (this.m_parent.GetLevel().GetPlayerAvatar().FastForwardHeroHealth(this.logicHeroData_0, 1))
				{
					base.GetParentListener();
				}
				this.int_0 -= num;
			}
			if (this.logicTimer_0 != null && this.logicTimer_0.GetRemainingSeconds(this.m_parent.GetLevel().GetLogicTime()) == 0)
			{
				this.FinishUpgrading(true);
			}
		}

		// Token: 0x06000F70 RID: 3952 RVA: 0x00003D3D File Offset: 0x00001F3D
		public override LogicComponentType GetComponentType()
		{
			return LogicComponentType.HERO_BASE;
		}

		// Token: 0x06000F71 RID: 3953 RVA: 0x0004182C File Offset: 0x0003FA2C
		public void FinishUpgrading(bool tick)
		{
			if (this.logicTimer_0 != null)
			{
				LogicAvatar homeOwnerAvatar = this.m_parent.GetLevel().GetHomeOwnerAvatar();
				if (homeOwnerAvatar.GetUnitUpgradeLevel(this.logicHeroData_0) < this.int_1 || this.int_1 == 0)
				{
					homeOwnerAvatar.CommodityCountChangeHelper(1, this.logicHeroData_0, 1);
				}
				this.m_parent.GetLevel().GetWorkerManagerAt(this.m_parent.GetData().GetVillageType()).DeallocateWorker(this.m_parent);
				homeOwnerAvatar.SetHeroState(this.logicHeroData_0, 3);
				homeOwnerAvatar.GetChangeListener().CommodityCountChanged(2, this.logicHeroData_0, 3);
				this.SetFullHealth();
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
				return;
			}
			Debugger.Warning("LogicHeroBaseComponent::finishUpgrading called and m_pHero is NULL");
		}

		// Token: 0x06000F72 RID: 3954 RVA: 0x0000A869 File Offset: 0x00008A69
		public bool IsUpgrading()
		{
			return this.logicTimer_0 != null;
		}

		// Token: 0x06000F73 RID: 3955 RVA: 0x0000A874 File Offset: 0x00008A74
		public void SetFullHealth()
		{
			LogicAvatar homeOwnerAvatar = this.m_parent.GetLevel().GetHomeOwnerAvatar();
			homeOwnerAvatar.SetHeroHealth(this.logicHeroData_0, 0);
			homeOwnerAvatar.GetChangeListener().CommodityCountChanged(0, this.logicHeroData_0, 0);
		}

		// Token: 0x06000F74 RID: 3956 RVA: 0x0000A8A5 File Offset: 0x00008AA5
		public int GetRemainingUpgradeSeconds()
		{
			if (this.logicTimer_0 != null)
			{
				return this.logicTimer_0.GetRemainingSeconds(this.m_parent.GetLevel().GetLogicTime());
			}
			return 0;
		}

		// Token: 0x06000F75 RID: 3957 RVA: 0x0000A8CC File Offset: 0x00008ACC
		public int GetRemainingMS()
		{
			if (this.logicTimer_0 != null)
			{
				return this.logicTimer_0.GetRemainingMS(this.m_parent.GetLevel().GetLogicTime());
			}
			return 0;
		}

		// Token: 0x06000F76 RID: 3958 RVA: 0x0000A8F3 File Offset: 0x00008AF3
		public int GetTotalSeconds()
		{
			if (this.logicTimer_0 != null)
			{
				return this.logicHeroData_0.GetUpgradeTime(this.m_parent.GetLevel().GetHomeOwnerAvatar().GetUnitUpgradeLevel(this.logicHeroData_0));
			}
			return 0;
		}

		// Token: 0x06000F77 RID: 3959 RVA: 0x0000A925 File Offset: 0x00008B25
		public LogicHeroData GetHeroData()
		{
			return this.logicHeroData_0;
		}

		// Token: 0x06000F78 RID: 3960 RVA: 0x0000A92D File Offset: 0x00008B2D
		public void SetSharedHeroCombatData(bool value)
		{
			this.bool_0 = value;
		}

		// Token: 0x06000F79 RID: 3961 RVA: 0x000418F0 File Offset: 0x0003FAF0
		public override void Save(LogicJSONObject root, int villageType)
		{
			if (this.logicTimer_0 != null && this.logicHeroData_0 != null)
			{
				LogicJSONObject logicJSONObject = new LogicJSONObject();
				logicJSONObject.Put("level", new LogicJSONNumber(this.int_1));
				logicJSONObject.Put("t", new LogicJSONNumber(this.logicTimer_0.GetRemainingSeconds(this.m_parent.GetLevel().GetLogicTime())));
				if (this.logicTimer_0.GetEndTimestamp() != -1)
				{
					logicJSONObject.Put("t_end", new LogicJSONNumber(this.logicTimer_0.GetEndTimestamp()));
				}
				if (this.logicTimer_0.GetFastForward() > 0)
				{
					logicJSONObject.Put("t_ff", new LogicJSONNumber(this.logicTimer_0.GetFastForward()));
				}
				root.Put("hero_upg", logicJSONObject);
			}
		}

		// Token: 0x06000F7A RID: 3962 RVA: 0x000419B8 File Offset: 0x0003FBB8
		public override void SaveToSnapshot(LogicJSONObject root, int layoutId)
		{
			if (this.logicTimer_0 != null && this.logicHeroData_0 != null)
			{
				LogicJSONObject logicJSONObject = new LogicJSONObject();
				logicJSONObject.Put("level", new LogicJSONNumber(this.int_1));
				logicJSONObject.Put("t", new LogicJSONNumber(this.logicTimer_0.GetRemainingSeconds(this.m_parent.GetLevel().GetLogicTime())));
				root.Put("hero_upg", logicJSONObject);
			}
		}

		// Token: 0x06000F7B RID: 3963 RVA: 0x00041A28 File Offset: 0x0003FC28
		public override void Load(LogicJSONObject root)
		{
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
			LogicJSONObject jsonobject = root.GetJSONObject("hero_upg");
			if (jsonobject != null)
			{
				LogicJSONNumber jsonnumber = jsonobject.GetJSONNumber("level");
				LogicJSONNumber jsonnumber2 = jsonobject.GetJSONNumber("t");
				LogicJSONNumber jsonnumber3 = jsonobject.GetJSONNumber("t_end");
				LogicJSONNumber jsonnumber4 = jsonobject.GetJSONNumber("t_ff");
				if (jsonnumber != null)
				{
					this.int_1 = jsonnumber.GetIntValue();
				}
				if (jsonnumber2 != null)
				{
					this.logicTimer_0 = new LogicTimer();
					this.logicTimer_0.StartTimer(jsonnumber2.GetIntValue(), this.m_parent.GetLevel().GetLogicTime(), false, -1);
					if (jsonnumber3 != null)
					{
						this.logicTimer_0.SetEndTimestamp(jsonnumber3.GetIntValue());
					}
					if (jsonnumber4 != null)
					{
						this.logicTimer_0.SetFastForward(jsonnumber4.GetIntValue());
					}
					this.m_parent.GetLevel().GetWorkerManagerAt(this.m_parent.GetVillageType()).AllocateWorker(this.m_parent);
				}
			}
		}

		// Token: 0x06000F7C RID: 3964 RVA: 0x00041B24 File Offset: 0x0003FD24
		public override void LoadFromSnapshot(LogicJSONObject root)
		{
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
			LogicJSONObject jsonobject = root.GetJSONObject("hero_upg");
			if (jsonobject != null)
			{
				LogicJSONNumber jsonnumber = jsonobject.GetJSONNumber("level");
				if (jsonnumber != null)
				{
					this.int_1 = jsonnumber.GetIntValue();
				}
			}
		}

		// Token: 0x06000F7D RID: 3965 RVA: 0x00041B78 File Offset: 0x0003FD78
		public override void LoadingFinished()
		{
			if (this.m_parent.GetLevel().IsInCombatState() && this.m_parent.GetVillageType() == this.m_parent.GetLevel().GetVillageType() && this.m_parent.GetLevel().GetVillageType() == this.m_parent.GetVillageType())
			{
				this.logicArrayList_0 = this.CreatePatrolPath();
			}
			LogicAvatar homeOwnerAvatar = this.m_parent.GetLevel().GetHomeOwnerAvatar();
			LogicBuilding logicBuilding = (LogicBuilding)this.m_parent;
			if (!logicBuilding.IsLocked() && homeOwnerAvatar.GetHeroState(this.logicHeroData_0) == 0)
			{
				homeOwnerAvatar.SetHeroState(this.logicHeroData_0, 3);
				homeOwnerAvatar.GetChangeListener().CommodityCountChanged(2, this.logicHeroData_0, 3);
			}
			if (this.logicTimer_0 != null)
			{
				int remainingSeconds = this.logicTimer_0.GetRemainingSeconds(this.m_parent.GetLevel().GetLogicTime());
				int totalSeconds = this.GetTotalSeconds();
				if (LogicDataTables.GetGlobals().ClampUpgradeTimes())
				{
					if (remainingSeconds > totalSeconds)
					{
						this.logicTimer_0.StartTimer(totalSeconds, this.m_parent.GetLevel().GetLogicTime(), true, this.m_parent.GetLevel().GetHomeOwnerAvatarChangeListener().GetCurrentTimestamp());
					}
				}
				else
				{
					this.logicTimer_0.StartTimer(LogicMath.Min(remainingSeconds, totalSeconds), this.m_parent.GetLevel().GetLogicTime(), false, -1);
				}
				if (!logicBuilding.IsLocked() && homeOwnerAvatar.GetHeroState(this.logicHeroData_0) != 1)
				{
					homeOwnerAvatar.SetHeroState(this.logicHeroData_0, 1);
					homeOwnerAvatar.GetChangeListener().CommodityCountChanged(2, this.logicHeroData_0, 1);
				}
			}
			else if (!logicBuilding.IsLocked() && homeOwnerAvatar.GetHeroState(this.logicHeroData_0) == 1)
			{
				homeOwnerAvatar.SetHeroState(this.logicHeroData_0, 3);
				homeOwnerAvatar.GetChangeListener().CommodityCountChanged(2, this.logicHeroData_0, 3);
			}
			if (this.logicHeroData_0.HasNoDefence() && !this.m_parent.GetLevel().IsInCombatState() && homeOwnerAvatar.GetHeroState(this.logicHeroData_0) == 3)
			{
				homeOwnerAvatar.SetHeroState(this.logicHeroData_0, 2);
				homeOwnerAvatar.GetChangeListener().CommodityCountChanged(2, this.logicHeroData_0, 2);
			}
			if (homeOwnerAvatar.GetHeroState(this.logicHeroData_0) == 3 && this.m_parent.GetLevel().IsInCombatState() && !this.bool_0 && !this.logicHeroData_0.HasNoDefence() && this.m_parent.GetVillageType() == this.m_parent.GetLevel().GetVillageType())
			{
				this.AddDefendingHero();
			}
			int heroHealth = homeOwnerAvatar.GetHeroHealth(this.logicHeroData_0);
			int fullRegenerationTimeSec = this.logicHeroData_0.GetFullRegenerationTimeSec(homeOwnerAvatar.GetUnitUpgradeLevel(this.logicHeroData_0));
			if (fullRegenerationTimeSec < heroHealth)
			{
				homeOwnerAvatar.GetChangeListener().CommodityCountChanged(0, this.logicHeroData_0, fullRegenerationTimeSec);
				homeOwnerAvatar.SetHeroHealth(this.logicHeroData_0, fullRegenerationTimeSec);
			}
		}

		// Token: 0x06000F7E RID: 3966 RVA: 0x00041E30 File Offset: 0x00040030
		public override void FastForwardTime(int time)
		{
			int num = time;
			int num2 = 0;
			int remainingBoostTime = this.m_parent.GetRemainingBoostTime();
			if (remainingBoostTime > 0 && !this.m_parent.IsBoostPaused())
			{
				num += LogicMath.Min(remainingBoostTime, time) * (LogicDataTables.GetGlobals().GetHeroRestBoostMultiplier() - 1);
			}
			int updatedClockTowerBoostTime = this.m_parent.GetLevel().GetUpdatedClockTowerBoostTime();
			if (updatedClockTowerBoostTime > 0 && this.m_parent.GetLevel().IsClockTowerBoostPaused())
			{
				LogicGameObjectData data = this.m_parent.GetData();
				if (data.GetDataType() == LogicDataType.BUILDING && data.GetVillageType() == 1)
				{
					int num3 = LogicMath.Min(updatedClockTowerBoostTime, time) * (LogicDataTables.GetGlobals().GetClockTowerBoostMultiplier() - 1);
					num += num3;
					num2 += num3;
				}
			}
			this.m_parent.GetLevel().GetHomeOwnerAvatar().FastForwardHeroHealth(this.logicHeroData_0, num);
			if (this.logicTimer_0 != null)
			{
				if (this.logicTimer_0.GetEndTimestamp() == -1)
				{
					this.logicTimer_0.StartTimer(this.logicTimer_0.GetRemainingSeconds(this.m_parent.GetLevel().GetLogicTime()) - time, this.m_parent.GetLevel().GetLogicTime(), false, -1);
				}
				else
				{
					this.logicTimer_0.AdjustEndSubtick(this.m_parent.GetLevel());
				}
				if (num2 > 0)
				{
					this.logicTimer_0.SetFastForward(this.logicTimer_0.GetFastForward() + 60 * num2);
				}
			}
		}

		// Token: 0x06000F7F RID: 3967 RVA: 0x0000A936 File Offset: 0x00008B36
		public LogicArrayList<LogicVector2> GetPatrolPath()
		{
			return this.logicArrayList_0;
		}

		// Token: 0x06000F80 RID: 3968 RVA: 0x00041F80 File Offset: 0x00040180
		public LogicArrayList<LogicVector2> CreatePatrolPath()
		{
			int num = this.m_parent.GetWidthInTiles() << 8;
			int num2 = this.m_parent.GetHeightInTiles() << 8;
			int patrolRadius = this.logicHeroData_0.GetPatrolRadius();
			if (patrolRadius * patrolRadius >= num * num + num2 * num2)
			{
				LogicVector2 logicVector = new LogicVector2();
				LogicVector2 logicVector2 = new LogicVector2();
				LogicVector2 logicVector3 = new LogicVector2();
				LogicVector2 logicVector4 = new LogicVector2();
				int midX = this.m_parent.GetMidX();
				int midY = this.m_parent.GetMidY();
				logicVector2.Set(midX, midY);
				LogicArrayList<LogicVector2> logicArrayList = new LogicArrayList<LogicVector2>(8);
				int i = 0;
				int num3 = 22;
				while (i < 8)
				{
					logicVector.Set(midX + LogicMath.Cos(num3, patrolRadius), midY + LogicMath.Sin(num3, patrolRadius));
					LogicHeroBaseComponent.FindPoint(this.m_parent.GetLevel().GetTileMap(), logicVector3, logicVector2, logicVector, logicVector4);
					logicArrayList.Add(new LogicVector2(logicVector4.m_x, logicVector4.m_y));
					i++;
					num3 += 45;
				}
				logicVector.Destruct();
				logicVector2.Destruct();
				logicVector3.Destruct();
				logicVector4.Destruct();
				return logicArrayList;
			}
			int x = this.m_parent.GetX() + (this.m_parent.GetWidthInTiles() << 9) - 128;
			int y = this.m_parent.GetY() + (this.m_parent.GetWidthInTiles() << 9) - 128;
			int x2 = this.m_parent.GetX() + 128;
			int y2 = this.m_parent.GetY() + 128;
			LogicArrayList<LogicVector2> logicArrayList2 = new LogicArrayList<LogicVector2>(4);
			logicArrayList2.Add(new LogicVector2(x, y));
			logicArrayList2.Add(new LogicVector2(x2, y));
			logicArrayList2.Add(new LogicVector2(x2, y2));
			logicArrayList2.Add(new LogicVector2(x, y2));
			return logicArrayList2;
		}

		// Token: 0x06000F81 RID: 3969 RVA: 0x00042144 File Offset: 0x00040344
		public void AddDefendingHero()
		{
			LogicAvatar visitorAvatar = this.m_parent.GetLevel().GetVisitorAvatar();
			LogicAvatar homeOwnerAvatar = this.m_parent.GetLevel().GetHomeOwnerAvatar();
			int index = (visitorAvatar != null) ? ((int)(((long)(visitorAvatar.GetResourceCount(LogicDataTables.GetGoldData()) + 10 * this.logicHeroData_0.GetGlobalID()) & 2147483647L) % (long)this.logicArrayList_0.Size())) : 0;
			int unitUpgradeLevel = homeOwnerAvatar.GetUnitUpgradeLevel(this.logicHeroData_0);
			int heroHitpoints = this.logicHeroData_0.GetHeroHitpoints(homeOwnerAvatar.GetHeroHealth(this.logicHeroData_0), unitUpgradeLevel);
			if (this.logicHeroData_0.HasEnoughHealthForAttack(heroHitpoints, unitUpgradeLevel))
			{
				LogicVector2 logicVector = this.logicArrayList_0[index];
				LogicCharacter logicCharacter = (LogicCharacter)LogicGameObjectFactory.CreateGameObject(this.logicHeroData_0, this.m_parent.GetLevel(), this.m_parent.GetVillageType());
				logicCharacter.GetMovementComponent().SetBaseBuilding((LogicBuilding)this.m_parent);
				logicCharacter.GetHitpointComponent().SetTeam(1);
				logicCharacter.SetUpgradeLevel(unitUpgradeLevel);
				logicCharacter.GetHitpointComponent().SetHitpoints(heroHitpoints);
				logicCharacter.SetInitialPosition(logicVector.m_x, logicVector.m_y);
				this.m_parent.GetGameObjectManager().AddGameObject(logicCharacter, -1);
				logicCharacter.GetCombatComponent().SetSearchRadius(this.logicHeroData_0.GetMaxSearchRadiusForDefender() / 512);
				if (LogicDataTables.GetGlobals().EnableDefendingAllianceTroopJump())
				{
					logicCharacter.GetMovementComponent().EnableJump(3600000);
				}
			}
		}

		// Token: 0x06000F82 RID: 3970 RVA: 0x000422BC File Offset: 0x000404BC
		public bool SpeedUp()
		{
			if (this.logicTimer_0 != null)
			{
				int speedUpCost = LogicGamePlayUtil.GetSpeedUpCost(this.logicTimer_0.GetRemainingSeconds(this.m_parent.GetLevel().GetLogicTime()), 0, this.m_parent.GetVillageType());
				LogicAvatar homeOwnerAvatar = this.m_parent.GetLevel().GetHomeOwnerAvatar();
				if (homeOwnerAvatar.IsClientAvatar())
				{
					LogicClientAvatar logicClientAvatar = (LogicClientAvatar)homeOwnerAvatar;
					if (logicClientAvatar.HasEnoughDiamonds(speedUpCost, true, this.m_parent.GetLevel()))
					{
						logicClientAvatar.UseDiamonds(speedUpCost);
						logicClientAvatar.GetChangeListener().DiamondPurchaseMade(10, this.logicHeroData_0.GetGlobalID(), logicClientAvatar.GetUnitUpgradeLevel(this.logicHeroData_0) + 1, speedUpCost, this.m_parent.GetLevel().GetVillageType());
						this.FinishUpgrading(true);
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06000F83 RID: 3971 RVA: 0x00042380 File Offset: 0x00040580
		public void CancelUpgrade()
		{
			if (this.logicTimer_0 != null)
			{
				LogicAvatar homeOwnerAvatar = this.m_parent.GetLevel().GetHomeOwnerAvatar();
				int unitUpgradeLevel = homeOwnerAvatar.GetUnitUpgradeLevel(this.logicHeroData_0);
				int upgradeCost = this.logicHeroData_0.GetUpgradeCost(unitUpgradeLevel);
				LogicResourceData upgradeResource = this.logicHeroData_0.GetUpgradeResource(unitUpgradeLevel);
				homeOwnerAvatar.CommodityCountChangeHelper(0, upgradeResource, LogicDataTables.GetGlobals().GetHeroUpgradeCancelMultiplier() * upgradeCost / 100);
				this.m_parent.GetLevel().GetWorkerManagerAt(this.m_parent.GetData().GetVillageType()).DeallocateWorker(this.m_parent);
				homeOwnerAvatar.SetHeroState(this.logicHeroData_0, 3);
				homeOwnerAvatar.GetChangeListener().CommodityCountChanged(2, this.logicHeroData_0, 3);
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
				return;
			}
			Debugger.Warning("LogicHeroBaseComponent::cancelUpgrade called even upgrade is not on going!");
		}

		// Token: 0x06000F84 RID: 3972 RVA: 0x00042450 File Offset: 0x00040650
		public bool CanStartUpgrading(bool callListener)
		{
			if (this.logicTimer_0 == null && !this.IsMaxLevel())
			{
				LogicAvatar homeOwnerAvatar = this.m_parent.GetLevel().GetHomeOwnerAvatar();
				int requiredTownHallLevel = this.logicHeroData_0.GetRequiredTownHallLevel(homeOwnerAvatar.GetUnitUpgradeLevel(this.logicHeroData_0) + 1);
				if (this.m_parent.GetLevel().GetTownHallLevel(this.m_parent.GetLevel().GetVillageType()) >= requiredTownHallLevel)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000F85 RID: 3973 RVA: 0x000424C0 File Offset: 0x000406C0
		public void StartUpgrading()
		{
			if (this.CanStartUpgrading(true))
			{
				((LogicBuilding)this.m_parent).DestructBoost();
				if (this.logicTimer_0 != null)
				{
					this.logicTimer_0.Destruct();
					this.logicTimer_0 = null;
				}
				LogicAvatar homeOwnerAvatar = this.m_parent.GetLevel().GetHomeOwnerAvatar();
				this.m_parent.GetLevel().GetWorkerManagerAt(this.m_parent.GetData().GetVillageType()).AllocateWorker(this.m_parent);
				this.logicTimer_0 = new LogicTimer();
				this.logicTimer_0.StartTimer(this.GetTotalSeconds(), this.m_parent.GetLevel().GetLogicTime(), true, this.m_parent.GetLevel().GetHomeOwnerAvatarChangeListener().GetCurrentTimestamp());
				this.int_1 = homeOwnerAvatar.GetUnitUpgradeLevel(this.logicHeroData_0) + 1;
				homeOwnerAvatar.SetHeroState(this.logicHeroData_0, 1);
				homeOwnerAvatar.GetChangeListener().CommodityCountChanged(2, this.logicHeroData_0, 1);
			}
		}

		// Token: 0x06000F86 RID: 3974 RVA: 0x0000A93E File Offset: 0x00008B3E
		public bool IsMaxLevel()
		{
			return this.m_parent.GetLevel().GetHomeOwnerAvatar().GetUnitUpgradeLevel(this.logicHeroData_0) >= this.logicHeroData_0.GetUpgradeLevelCount() - 1;
		}

		// Token: 0x06000F87 RID: 3975 RVA: 0x000425B8 File Offset: 0x000407B8
		public int GetSpeedUpHealthCost()
		{
			LogicAvatar homeOwnerAvatar = this.m_parent.GetLevel().GetHomeOwnerAvatar();
			if (homeOwnerAvatar.IsClientAvatar())
			{
				return homeOwnerAvatar.GetHeroHealCost(this.logicHeroData_0);
			}
			return 0;
		}

		// Token: 0x06000F88 RID: 3976 RVA: 0x000425EC File Offset: 0x000407EC
		public bool SpeedUpHealth()
		{
			LogicAvatar homeOwnerAvatar = this.m_parent.GetLevel().GetHomeOwnerAvatar();
			if (homeOwnerAvatar.IsClientAvatar())
			{
				LogicClientAvatar logicClientAvatar = (LogicClientAvatar)homeOwnerAvatar;
				int speedUpHealthCost = this.GetSpeedUpHealthCost();
				if (logicClientAvatar.HasEnoughDiamonds(speedUpHealthCost, true, this.m_parent.GetLevel()))
				{
					logicClientAvatar.UseDiamonds(speedUpHealthCost);
					logicClientAvatar.GetChangeListener().DiamondPurchaseMade(9, this.logicHeroData_0.GetGlobalID(), logicClientAvatar.GetUnitUpgradeLevel(this.logicHeroData_0) + 1, speedUpHealthCost, this.m_parent.GetLevel().GetVillageType());
					this.SetFullHealth();
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000F89 RID: 3977 RVA: 0x0004267C File Offset: 0x0004087C
		public bool SetSleep(bool enabled)
		{
			LogicAvatar homeOwnerAvatar = this.m_parent.GetLevel().GetHomeOwnerAvatar();
			int heroState = homeOwnerAvatar.GetHeroState(this.logicHeroData_0);
			if (heroState != 0)
			{
				int num = enabled ? 2 : 3;
				if (heroState != num)
				{
					homeOwnerAvatar.SetHeroState(this.logicHeroData_0, num);
					homeOwnerAvatar.GetChangeListener().CommodityCountChanged(2, this.logicHeroData_0, num);
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000F8A RID: 3978 RVA: 0x000426DC File Offset: 0x000408DC
		public bool SetHeroMode(int mode)
		{
			LogicAvatar homeOwnerAvatar = this.m_parent.GetLevel().GetHomeOwnerAvatar();
			if (homeOwnerAvatar.GetHeroMode(this.logicHeroData_0) == mode)
			{
				return false;
			}
			homeOwnerAvatar.SetHeroMode(this.logicHeroData_0, mode);
			homeOwnerAvatar.GetChangeListener().CommodityCountChanged(3, this.logicHeroData_0, mode);
			return true;
		}

		// Token: 0x06000F8B RID: 3979 RVA: 0x0004272C File Offset: 0x0004092C
		public static bool FindPoint(LogicTileMap tileMap, LogicVector2 pos1, LogicVector2 pos2, LogicVector2 pos3, LogicVector2 pos4)
		{
			pos1.Set(pos2.m_x, pos2.m_y);
			pos1.Substract(pos3);
			int length = pos1.GetLength();
			pos1.m_x = (pos1.m_x << 7) / length;
			pos1.m_y = (pos1.m_y << 7) / length;
			pos4.Set(pos3.m_x, pos3.m_y);
			int num = LogicMath.Clamp(length / 128, 10, 25);
			for (int i = 0; i < num; i++)
			{
				if (tileMap.IsPassablePathFinder(pos4.m_x >> 8, pos4.m_y >> 8))
				{
					pos4.m_x = (int)(((long)pos4.m_x & 4294967040L) | 128L);
					pos4.m_y = (int)(((long)pos4.m_y & 4294967040L) | 128L);
					return true;
				}
				pos4.Add(pos1);
			}
			return false;
		}

		// Token: 0x04000657 RID: 1623
		public const int PATROL_PATHS = 8;

		// Token: 0x04000658 RID: 1624
		private LogicTimer logicTimer_0;

		// Token: 0x04000659 RID: 1625
		private LogicArrayList<LogicVector2> logicArrayList_0;

		// Token: 0x0400065A RID: 1626
		private readonly LogicHeroData logicHeroData_0;

		// Token: 0x0400065B RID: 1627
		private int int_0;

		// Token: 0x0400065C RID: 1628
		private int int_1;

		// Token: 0x0400065D RID: 1629
		private bool bool_0;
	}
}
