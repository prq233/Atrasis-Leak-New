using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Time;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.GameObject
{
	// Token: 0x02000118 RID: 280
	public sealed class LogicTrap : LogicGameObject
	{
		// Token: 0x06000E70 RID: 3696 RVA: 0x00037650 File Offset: 0x00035850
		public LogicTrap(LogicGameObjectData data, LogicLevel level, int villageType) : base(data, level, villageType)
		{
			this.int_7 = -1;
			this.int_9 = -1;
			this.bool_2 = new bool[8];
			this.bool_3 = new bool[8];
			this.int_12 = new int[8];
			this.int_13 = new int[8];
			LogicTrapData logicTrapData = (LogicTrapData)data;
			base.AddComponent(new LogicTriggerComponent(this, logicTrapData.GetTriggerRadius(), logicTrapData.GetAirTrigger(), logicTrapData.GetGroundTrigger(), logicTrapData.GetHealerTrigger(), logicTrapData.GetMinTriggerHousingLimit()));
			base.AddComponent(new LogicLayoutComponent(this));
			this.int_6 = logicTrapData.GetNumSpawns(0);
			this.int_8 = logicTrapData.GetSpawnInitialDelayMS() / 64;
		}

		// Token: 0x06000E71 RID: 3697 RVA: 0x00009FF3 File Offset: 0x000081F3
		public LogicTrapData GetTrapData()
		{
			return (LogicTrapData)this.m_data;
		}

		// Token: 0x06000E72 RID: 3698 RVA: 0x0000A000 File Offset: 0x00008200
		public override void Destruct()
		{
			base.Destruct();
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
		}

		// Token: 0x06000E73 RID: 3699 RVA: 0x00037700 File Offset: 0x00035900
		public override void GetChecksum(ChecksumHelper checksum, bool includeGameObjects)
		{
			checksum.StartObject("LogicTrap");
			base.GetChecksum(checksum, includeGameObjects);
			if (this.logicTimer_0 != null)
			{
				checksum.WriteValue("remainingMS", this.logicTimer_0.GetRemainingMS(this.m_level.GetLogicTime()));
			}
			checksum.EndObject();
		}

		// Token: 0x06000E74 RID: 3700 RVA: 0x00037750 File Offset: 0x00035950
		public override bool ShouldDestruct()
		{
			if (this.int_7 >= 1000)
			{
				int gameObjectCountByData = base.GetGameObjectManager().GetGameObjectCountByData(base.GetData());
				return LogicDataTables.GetTownHallLevel(this.m_level.GetTownHallLevel(this.m_level.GetVillageType())).GetUnlockedTrapCount(this.GetTrapData()) < gameObjectCountByData;
			}
			return false;
		}

		// Token: 0x06000E75 RID: 3701 RVA: 0x000377A8 File Offset: 0x000359A8
		public void FinishConstruction(bool ignoreState)
		{
			int state = this.m_level.GetState();
			if (state == 1 || (!LogicDataTables.GetGlobals().CompleteConstructionOnlyHome() && ignoreState))
			{
				LogicAvatar homeOwnerAvatar = this.m_level.GetHomeOwnerAvatar();
				if (homeOwnerAvatar != null && homeOwnerAvatar.IsClientAvatar())
				{
					LogicTrapData trapData = this.GetTrapData();
					if (this.logicTimer_0 != null)
					{
						this.logicTimer_0.Destruct();
						this.logicTimer_0 = null;
					}
					this.m_level.GetWorkerManagerAt(this.m_data.GetVillageType()).DeallocateWorker(this);
					if (this.int_5 != 0 || this.bool_0)
					{
						if (this.int_5 >= trapData.GetUpgradeLevelCount() - 1)
						{
							Debugger.Warning("LogicTrap - Trying to upgrade to level that doesn't exist! - " + trapData.GetName());
							this.int_5 = trapData.GetUpgradeLevelCount() - 1;
						}
						else
						{
							this.int_5++;
						}
					}
					if (!ignoreState && !this.bool_1)
					{
						base.GetListener();
					}
					base.XpGainHelper(LogicGamePlayUtil.TimeToExp(trapData.GetBuildTime(this.int_5)), homeOwnerAvatar, ignoreState);
					this.int_7 = 0;
					this.bool_1 = false;
					this.bool_0 = false;
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
					Debugger.Warning("LogicTrap::finishCostruction failed - Avatar is null or not client avatar");
				}
			}
		}

		// Token: 0x06000E76 RID: 3702 RVA: 0x0000A022 File Offset: 0x00008222
		public bool IsFadingOut()
		{
			return this.int_7 > 0;
		}

		// Token: 0x06000E77 RID: 3703 RVA: 0x0000A02D File Offset: 0x0000822D
		public bool IsDisarmed()
		{
			return this.bool_1;
		}

		// Token: 0x06000E78 RID: 3704 RVA: 0x0000A035 File Offset: 0x00008235
		public void RepairTrap()
		{
			this.bool_1 = false;
			this.int_7 = 0;
		}

		// Token: 0x06000E79 RID: 3705 RVA: 0x0000A045 File Offset: 0x00008245
		public void DisarmTrap()
		{
			this.bool_1 = true;
			this.int_7 = 0;
		}

		// Token: 0x06000E7A RID: 3706 RVA: 0x000378F8 File Offset: 0x00035AF8
		public void SetUpgradeLevel(int upgLevel)
		{
			LogicTrapData trapData = this.GetTrapData();
			this.int_5 = LogicMath.Clamp(upgLevel, 0, trapData.GetUpgradeLevelCount() - 1);
			this.int_6 = trapData.GetNumSpawns(this.int_5);
		}

		// Token: 0x06000E7B RID: 3707 RVA: 0x00037934 File Offset: 0x00035B34
		public void CreateProjectile(LogicProjectileData data)
		{
			LogicTrapData trapData = this.GetTrapData();
			LogicVector2 logicVector = new LogicVector2();
			LogicArrayList<LogicGameObject> gameObjects = base.GetGameObjectManager().GetGameObjects(LogicGameObjectType.CHARACTER);
			LogicGameObject logicGameObject = null;
			int i = 0;
			int num = 0;
			while (i < gameObjects.Size())
			{
				LogicCharacter logicCharacter = (LogicCharacter)gameObjects[i];
				LogicHitpointComponent hitpointComponent = logicCharacter.GetHitpointComponent();
				if (hitpointComponent != null && hitpointComponent.GetTeam() == 0 && logicCharacter.IsFlying() && logicCharacter.IsAlive() && logicCharacter.GetCharacterData().GetHousingSpace() >= trapData.GetMinTriggerHousingLimit() && logicCharacter.GetChildTroops() == null && (trapData.GetHealerTrigger() || logicCharacter.GetCombatComponent() == null || !logicCharacter.GetCombatComponent().IsHealer()))
				{
					logicVector.m_x = logicCharacter.GetPosition().m_x - this.GetMidX();
					logicVector.m_y = logicCharacter.GetPosition().m_y - this.GetMidY();
					int lengthSquared = logicVector.GetLengthSquared();
					if (num == 0 || lengthSquared < num)
					{
						num = lengthSquared;
						logicGameObject = logicCharacter;
					}
				}
				i++;
			}
			logicVector.Destruct();
			if (logicGameObject != null)
			{
				LogicProjectile logicProjectile = (LogicProjectile)LogicGameObjectFactory.CreateGameObject(data, this.m_level, this.m_villageType);
				logicProjectile.SetInitialPosition(null, this.GetMidX(), this.GetMidY());
				logicProjectile.SetTarget(this.GetMidX(), this.GetMidY(), 0, logicGameObject, data.GetRandomHitPosition());
				logicProjectile.SetDamage(trapData.GetDamage(this.int_5));
				logicProjectile.SetDamageRadius(trapData.GetDamageRadius(this.int_5));
				logicProjectile.SetPushBack(trapData.GetPushback(), !trapData.GetDoNotScalePushByDamage());
				logicProjectile.SetMyTeam(1);
				logicProjectile.SetHitEffect(trapData.GetDamageEffect(), null);
				base.GetGameObjectManager().AddGameObject(logicProjectile, -1);
			}
		}

		// Token: 0x06000E7C RID: 3708 RVA: 0x00037AFC File Offset: 0x00035CFC
		public void EjectCharacters()
		{
			LogicArrayList<LogicComponent> components = base.GetComponentManager().GetComponents(LogicComponentType.MOVEMENT);
			int num = this.GetTrapData().GetEjectHousingLimit(this.int_5);
			int triggerRadius = this.GetTrapData().GetTriggerRadius();
			for (int i = 0; i < components.Size(); i++)
			{
				LogicGameObject parent = ((LogicMovementComponent)components[i]).GetParent();
				if (parent.GetGameObjectType() == LogicGameObjectType.CHARACTER)
				{
					LogicCharacter logicCharacter = (LogicCharacter)parent;
					if (logicCharacter.GetHitpointComponent() != null && logicCharacter.GetHitpointComponent().GetTeam() == 0 && logicCharacter.GetCharacterData().GetHousingSpace() <= num)
					{
						int num2 = logicCharacter.GetX() - this.GetMidX();
						int num3 = logicCharacter.GetY() - this.GetMidY();
						if (LogicMath.Abs(num2) <= triggerRadius && LogicMath.Abs(num3) <= triggerRadius && (logicCharacter.GetCombatComponent() == null || logicCharacter.GetCombatComponent().GetUndergroundTime() <= 0) && (long)(num2 * num2 + num3 * num3) < (long)((ulong)(triggerRadius * triggerRadius)))
						{
							logicCharacter.Eject(null);
							num -= logicCharacter.GetCharacterData().GetHousingSpace();
						}
					}
				}
			}
		}

		// Token: 0x06000E7D RID: 3709 RVA: 0x00037C18 File Offset: 0x00035E18
		public void ThrowCharacters()
		{
			LogicArrayList<LogicComponent> components = base.GetComponentManager().GetComponents(LogicComponentType.MOVEMENT);
			int ejectHousingLimit = this.GetTrapData().GetEjectHousingLimit(this.int_5);
			int triggerRadius = this.GetTrapData().GetTriggerRadius();
			for (int i = 0; i < components.Size(); i++)
			{
				LogicGameObject parent = ((LogicMovementComponent)components[i]).GetParent();
				if (parent.GetGameObjectType() == LogicGameObjectType.CHARACTER)
				{
					LogicCharacter logicCharacter = (LogicCharacter)parent;
					if (logicCharacter.GetHitpointComponent() != null && logicCharacter.GetHitpointComponent().GetTeam() == 0 && logicCharacter.GetCharacterData().GetHousingSpace() <= ejectHousingLimit)
					{
						int num = logicCharacter.GetX() - this.GetMidX();
						int num2 = logicCharacter.GetY() - this.GetMidY();
						if (LogicMath.Abs(num) <= triggerRadius && LogicMath.Abs(num2) <= triggerRadius && (logicCharacter.GetCombatComponent() == null || logicCharacter.GetCombatComponent().GetUndergroundTime() <= 0) && (long)(num * num + num2 * num2) < (long)((ulong)(triggerRadius * triggerRadius)))
						{
							int activeLayout = this.m_level.GetActiveLayout();
							int num3 = (activeLayout <= 7) ? this.int_12[activeLayout] : 0;
							int pushBackX = 0;
							int pushBackY = 0;
							switch (num3)
							{
							case 0:
								pushBackX = 256;
								break;
							case 1:
								pushBackY = 256;
								break;
							case 2:
								pushBackX = -256;
								break;
							case 3:
								pushBackY = -256;
								break;
							}
							this.m_level.AreaPushBack(this.GetMidX(), this.GetMidY(), 600, 1000, 1, 1, pushBackX, pushBackY, this.GetTrapData().GetThrowDistance(), ejectHousingLimit);
						}
					}
				}
			}
		}

		// Token: 0x06000E7E RID: 3710 RVA: 0x00037DC0 File Offset: 0x00035FC0
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
						this.FinishConstruction(true);
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
						this.FinishConstruction(true);
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

		// Token: 0x06000E7F RID: 3711 RVA: 0x00002B36 File Offset: 0x00000D36
		public override bool IsPassable()
		{
			return true;
		}

		// Token: 0x06000E80 RID: 3712 RVA: 0x00037F44 File Offset: 0x00036144
		public override void Tick()
		{
			base.Tick();
			if (this.logicTimer_0 != null)
			{
				if (this.m_level.GetRemainingClockTowerBoostTime() > 0 && this.m_data.GetVillageType() == 1)
				{
					this.logicTimer_0.SetFastForward(this.logicTimer_0.GetFastForward() + 4 * LogicDataTables.GetGlobals().GetClockTowerBoostMultiplier() - 4);
				}
				if (this.logicTimer_0.GetRemainingSeconds(this.m_level.GetLogicTime()) <= 0)
				{
					this.FinishConstruction(false);
				}
			}
			if (this.bool_1 && this.int_7 >= 0)
			{
				this.int_7 = LogicMath.Min(this.int_7 + 64, 1000);
			}
			if (base.GetTriggerComponent().IsTriggered() && !this.bool_1 && !this.bool_0)
			{
				LogicTrapData trapData = this.GetTrapData();
				if (this.int_6 > 0)
				{
					if (this.int_8 != 0)
					{
						this.int_8--;
					}
					else
					{
						this.SpawnUnit(1);
						this.int_6--;
						this.int_8 = this.GetTrapData().GetTimeBetweenSpawnsMS() / 64;
					}
				}
				if (this.int_11 >= 0)
				{
					this.int_11 += 64;
				}
				if (this.int_9 >= 0)
				{
					this.int_9 += 64;
				}
				if (this.int_11 > trapData.GetActionFrame())
				{
					this.int_9 = trapData.GetHitDelayMS();
					this.int_11 = -1;
					return;
				}
				if (this.int_9 > trapData.GetHitDelayMS())
				{
					if (trapData.GetSpell() != null)
					{
						LogicSpell logicSpell = (LogicSpell)LogicGameObjectFactory.CreateGameObject(trapData.GetSpell(), this.m_level, this.m_villageType);
						logicSpell.SetUpgradeLevel(0);
						logicSpell.SetInitialPosition(this.GetMidX(), this.GetMidY());
						logicSpell.SetTeam(1);
						base.GetGameObjectManager().AddGameObject(logicSpell, -1);
					}
					else if (trapData.GetProjectile(this.int_5) != null)
					{
						this.CreateProjectile(trapData.GetProjectile(this.int_5));
					}
					else if (trapData.GetDamageMod() != 0)
					{
						this.m_level.AreaBoost(this.GetMidX(), this.GetMidY(), trapData.GetDamageRadius(this.int_5), -trapData.GetSpeedMod(), -trapData.GetSpeedMod(), trapData.GetDamageMod(), 0, trapData.GetDurationMS() / 16, 0, false);
					}
					else if (trapData.GetEjectVictims())
					{
						if (trapData.GetThrowDistance() <= 0)
						{
							this.EjectCharacters();
						}
						else
						{
							this.ThrowCharacters();
						}
					}
					else
					{
						bool flag = true;
						if ((trapData.GetSpawnedCharAir() != null && trapData.GetSpawnedCharGround() != null) || trapData.HasAlternativeMode())
						{
							int activeLayout = this.m_level.GetActiveLayout();
							if (activeLayout <= 7)
							{
								flag = !this.bool_2[activeLayout];
							}
						}
						this.m_level.AreaDamage(0, this.GetMidX(), this.GetMidY(), trapData.GetDamageRadius(this.int_5), trapData.GetDamage(this.int_5), trapData.GetPreferredTarget(), trapData.GetPreferredTargetDamageMod(), trapData.GetDamageEffect(), 1, null, flag ? 1 : 0, 0, 100, true, false, 100, 0, this, 100, 0);
					}
					this.int_9 = 0;
					this.int_10++;
					if (this.int_10 >= trapData.GetHitCount() && this.int_6 == 0)
					{
						this.int_7 = 1;
						this.int_9 = -1;
						this.bool_1 = true;
						this.int_6 = trapData.GetNumSpawns(this.int_5);
						this.int_8 = trapData.GetSpawnInitialDelayMS() / 64;
					}
				}
			}
		}

		// Token: 0x06000E81 RID: 3713 RVA: 0x000382A8 File Offset: 0x000364A8
		public override void Save(LogicJSONObject jsonObject, int villageType)
		{
			if (this.int_5 == 0 && this.logicTimer_0 != null && !this.bool_0)
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
			if (this.bool_1 && this.GetTrapData().GetVillageType() != 1)
			{
				jsonObject.Put("needs_repair", new LogicJSONBoolean(true));
			}
			LogicTrapData trapData = this.GetTrapData();
			if (trapData.HasAlternativeMode() || (trapData.GetSpawnedCharAir() != null && trapData.GetSpawnedCharGround() != null))
			{
				LogicLayoutComponent logicLayoutComponent = (LogicLayoutComponent)base.GetComponent(LogicComponentType.LAYOUT);
				if (logicLayoutComponent != null)
				{
					for (int i = 0; i < 8; i++)
					{
						jsonObject.Put(logicLayoutComponent.GetLayoutVariableNameAirMode(i, false), new LogicJSONBoolean(this.bool_2[i]));
						jsonObject.Put(logicLayoutComponent.GetLayoutVariableNameAirMode(i, true), new LogicJSONBoolean(this.bool_3[i]));
					}
				}
			}
			if (trapData.GetDirectionCount() > 0)
			{
				LogicLayoutComponent logicLayoutComponent2 = (LogicLayoutComponent)base.GetComponent(LogicComponentType.LAYOUT);
				if (logicLayoutComponent2 != null)
				{
					for (int j = 0; j < 8; j++)
					{
						jsonObject.Put(logicLayoutComponent2.GetLayoutVariableNameTrapDirection(j, false), new LogicJSONNumber(this.int_12[j]));
						jsonObject.Put(logicLayoutComponent2.GetLayoutVariableNameTrapDirection(j, true), new LogicJSONNumber(this.int_13[j]));
					}
				}
			}
			base.Save(jsonObject, villageType);
		}

		// Token: 0x06000E82 RID: 3714 RVA: 0x0003847C File Offset: 0x0003667C
		public override void SaveToSnapshot(LogicJSONObject jsonObject, int layoutId)
		{
			if (this.int_5 == 0 && this.logicTimer_0 != null && !this.bool_0)
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
			LogicTrapData trapData = this.GetTrapData();
			if (trapData.HasAlternativeMode() || (trapData.GetSpawnedCharAir() != null && trapData.GetSpawnedCharGround() != null))
			{
				LogicLayoutComponent logicLayoutComponent = (LogicLayoutComponent)base.GetComponent(LogicComponentType.LAYOUT);
				if (logicLayoutComponent != null)
				{
					for (int i = 0; i < 8; i++)
					{
						jsonObject.Put(logicLayoutComponent.GetLayoutVariableNameAirMode(i, false), new LogicJSONBoolean(this.bool_2[i]));
					}
				}
			}
			if (trapData.GetDirectionCount() > 0)
			{
				LogicLayoutComponent logicLayoutComponent2 = (LogicLayoutComponent)base.GetComponent(LogicComponentType.LAYOUT);
				if (logicLayoutComponent2 != null)
				{
					for (int j = 0; j < 8; j++)
					{
						jsonObject.Put(logicLayoutComponent2.GetLayoutVariableNameTrapDirection(j, false), new LogicJSONNumber(this.int_12[j]));
					}
				}
			}
			base.SaveToSnapshot(jsonObject, layoutId);
		}

		// Token: 0x06000E83 RID: 3715 RVA: 0x000385A0 File Offset: 0x000367A0
		public override void Load(LogicJSONObject jsonObject)
		{
			this.LoadUpgradeLevel(jsonObject);
			LogicTrapData trapData = this.GetTrapData();
			if (trapData.HasAlternativeMode() || (trapData.GetSpawnedCharAir() != null && trapData.GetSpawnedCharGround() != null))
			{
				LogicLayoutComponent logicLayoutComponent = (LogicLayoutComponent)base.GetComponent(LogicComponentType.LAYOUT);
				if (logicLayoutComponent != null)
				{
					for (int i = 0; i < 8; i++)
					{
						LogicJSONBoolean jsonboolean = jsonObject.GetJSONBoolean(logicLayoutComponent.GetLayoutVariableNameAirMode(i, false));
						if (jsonboolean != null)
						{
							this.bool_2[i] = jsonboolean.IsTrue();
						}
						LogicJSONBoolean jsonboolean2 = jsonObject.GetJSONBoolean(logicLayoutComponent.GetLayoutVariableNameAirMode(i, true));
						if (jsonboolean2 != null)
						{
							this.bool_3[i] = jsonboolean2.IsTrue();
						}
					}
				}
				LogicTriggerComponent triggerComponent = base.GetTriggerComponent();
				int currentLayout = this.m_level.GetCurrentLayout();
				bool flag = this.bool_2[currentLayout];
				triggerComponent.SetAirTrigger(flag);
				triggerComponent.SetGroundTrigger(!flag);
			}
			if (trapData.GetDirectionCount() > 0)
			{
				LogicLayoutComponent logicLayoutComponent2 = (LogicLayoutComponent)base.GetComponent(LogicComponentType.LAYOUT);
				if (logicLayoutComponent2 != null)
				{
					for (int j = 0; j < 8; j++)
					{
						LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber(logicLayoutComponent2.GetLayoutVariableNameTrapDirection(j, false));
						if (jsonnumber != null)
						{
							this.int_12[j] = jsonnumber.GetIntValue();
						}
						LogicJSONNumber jsonnumber2 = jsonObject.GetJSONNumber(logicLayoutComponent2.GetLayoutVariableNameTrapDirection(j, true));
						if (jsonnumber2 != null)
						{
							this.int_13[j] = jsonnumber2.GetIntValue();
						}
					}
				}
			}
			this.m_level.GetWorkerManagerAt(this.m_villageType).DeallocateWorker(this);
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
			LogicJSONNumber jsonnumber3 = jsonObject.GetJSONNumber("const_t");
			if (jsonnumber3 != null)
			{
				int num = jsonnumber3.GetIntValue();
				if (!LogicDataTables.GetGlobals().ClampBuildingTimes() && this.int_5 < trapData.GetUpgradeLevelCount() - 1)
				{
					num = LogicMath.Min(num, trapData.GetBuildTime(this.int_5 + 1));
				}
				this.logicTimer_0 = new LogicTimer();
				this.logicTimer_0.StartTimer(num, this.m_level.GetLogicTime(), false, -1);
				LogicJSONNumber jsonnumber4 = jsonObject.GetJSONNumber("const_t_end");
				if (jsonnumber4 != null)
				{
					this.logicTimer_0.SetEndTimestamp(jsonnumber4.GetIntValue());
				}
				LogicJSONNumber jsonnumber5 = jsonObject.GetJSONNumber("con_ff");
				if (jsonnumber5 != null)
				{
					this.logicTimer_0.SetFastForward(jsonnumber5.GetIntValue());
				}
				this.m_level.GetWorkerManagerAt(this.m_villageType).AllocateWorker(this);
				this.bool_0 = (this.int_5 != -1);
			}
			LogicJSONBoolean jsonboolean3 = jsonObject.GetJSONBoolean("needs_repair");
			if (jsonboolean3 != null)
			{
				this.bool_1 = jsonboolean3.IsTrue();
			}
			this.SetUpgradeLevel(this.int_5);
			base.Load(jsonObject);
		}

		// Token: 0x06000E84 RID: 3716 RVA: 0x0003882C File Offset: 0x00036A2C
		public override void LoadFromSnapshot(LogicJSONObject jsonObject)
		{
			if (this.m_data.GetVillageType() == 1)
			{
				this.Load(jsonObject);
				return;
			}
			LogicTrapData trapData = this.GetTrapData();
			this.LoadUpgradeLevel(jsonObject);
			this.m_level.GetWorkerManagerAt(this.m_villageType).DeallocateWorker(this);
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
			if (trapData.HasAlternativeMode() || (trapData.GetSpawnedCharAir() != null && trapData.GetSpawnedCharGround() != null))
			{
				LogicLayoutComponent logicLayoutComponent = (LogicLayoutComponent)base.GetComponent(LogicComponentType.LAYOUT);
				if (logicLayoutComponent != null)
				{
					for (int i = 0; i < 8; i++)
					{
						LogicJSONBoolean jsonboolean = jsonObject.GetJSONBoolean(logicLayoutComponent.GetLayoutVariableNameAirMode(i, false));
						if (jsonboolean != null)
						{
							this.bool_2[i] = jsonboolean.IsTrue();
						}
					}
				}
				LogicTriggerComponent triggerComponent = base.GetTriggerComponent();
				bool flag = this.bool_2[this.m_level.GetWarLayout()];
				triggerComponent.SetAirTrigger(flag);
				triggerComponent.SetGroundTrigger(!flag);
			}
			if (trapData.GetDirectionCount() > 0)
			{
				LogicLayoutComponent logicLayoutComponent2 = (LogicLayoutComponent)base.GetComponent(LogicComponentType.LAYOUT);
				if (logicLayoutComponent2 != null)
				{
					for (int j = 0; j < 8; j++)
					{
						LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber(logicLayoutComponent2.GetLayoutVariableNameTrapDirection(j, false));
						if (jsonnumber != null)
						{
							this.int_12[j] = jsonnumber.GetIntValue();
						}
					}
				}
			}
			this.m_level.GetWorkerManagerAt(this.m_data.GetVillageType()).DeallocateWorker(this);
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
			this.SetUpgradeLevel(this.int_5);
			base.LoadFromSnapshot(jsonObject);
		}

		// Token: 0x06000E85 RID: 3717 RVA: 0x000389AC File Offset: 0x00036BAC
		public void LoadUpgradeLevel(LogicJSONObject jsonObject)
		{
			LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("lvl");
			LogicTrapData trapData = this.GetTrapData();
			if (jsonnumber != null)
			{
				this.int_5 = jsonnumber.GetIntValue();
				int upgradeLevelCount = trapData.GetUpgradeLevelCount();
				if (this.int_5 >= upgradeLevelCount)
				{
					Debugger.Warning(string.Format("LogicTrap::load() - Loaded upgrade level {0} is over max! (max = {1}) id {2} data id {3}", new object[]
					{
						jsonnumber.GetIntValue(),
						upgradeLevelCount,
						this.m_globalId,
						trapData.GetGlobalID()
					}));
					this.int_5 = upgradeLevelCount - 1;
					return;
				}
				if (this.int_5 < -1)
				{
					Debugger.Error("LogicTrap::load() - Loaded an illegal upgrade level!");
				}
			}
		}

		// Token: 0x06000E86 RID: 3718 RVA: 0x00038A54 File Offset: 0x00036C54
		public override void LoadingFinished()
		{
			base.LoadingFinished();
			if (LogicDataTables.GetGlobals().ClampBuildingTimes() && this.logicTimer_0 != null && this.int_5 < this.GetTrapData().GetUpgradeLevelCount() - 1)
			{
				int remainingSeconds = this.logicTimer_0.GetRemainingSeconds(this.m_level.GetLogicTime());
				int buildTime = this.GetTrapData().GetBuildTime(this.int_5 + 1);
				if (remainingSeconds > buildTime)
				{
					this.logicTimer_0.StartTimer(buildTime, this.m_level.GetLogicTime(), true, this.m_level.GetHomeOwnerAvatarChangeListener().GetCurrentTimestamp());
				}
			}
			if (this.m_listener != null)
			{
				this.m_listener.LoadedFromJSON();
			}
		}

		// Token: 0x06000E87 RID: 3719 RVA: 0x00002EAE File Offset: 0x000010AE
		public override LogicGameObjectType GetGameObjectType()
		{
			return LogicGameObjectType.TRAP;
		}

		// Token: 0x06000E88 RID: 3720 RVA: 0x0000A055 File Offset: 0x00008255
		public override int GetWidthInTiles()
		{
			return this.GetTrapData().GetWidth();
		}

		// Token: 0x06000E89 RID: 3721 RVA: 0x0000A062 File Offset: 0x00008262
		public override int GetHeightInTiles()
		{
			return this.GetTrapData().GetHeight();
		}

		// Token: 0x06000E8A RID: 3722 RVA: 0x0000A06F File Offset: 0x0000826F
		public int GetUpgradeLevel()
		{
			return this.int_5;
		}

		// Token: 0x06000E8B RID: 3723 RVA: 0x0000A077 File Offset: 0x00008277
		public bool IsConstructing()
		{
			return this.logicTimer_0 != null;
		}

		// Token: 0x06000E8C RID: 3724 RVA: 0x0000A082 File Offset: 0x00008282
		public bool IsUpgrading()
		{
			return this.logicTimer_0 != null && this.bool_0;
		}

		// Token: 0x06000E8D RID: 3725 RVA: 0x0000A094 File Offset: 0x00008294
		public int GetRemainingConstructionTime()
		{
			if (this.logicTimer_0 != null)
			{
				return this.logicTimer_0.GetRemainingSeconds(this.m_level.GetLogicTime());
			}
			return 0;
		}

		// Token: 0x06000E8E RID: 3726 RVA: 0x0000A0B6 File Offset: 0x000082B6
		public int GetRemainingConstructionTimeMS()
		{
			if (this.logicTimer_0 != null)
			{
				return this.logicTimer_0.GetRemainingMS(this.m_level.GetLogicTime());
			}
			return 0;
		}

		// Token: 0x06000E8F RID: 3727 RVA: 0x00038AF8 File Offset: 0x00036CF8
		public void StartUpgrading()
		{
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
			LogicTrapData trapData = this.GetTrapData();
			this.bool_0 = true;
			int buildTime = trapData.GetBuildTime(this.int_5 + 1);
			if (buildTime <= 0)
			{
				this.FinishConstruction(false);
				return;
			}
			this.m_level.GetWorkerManagerAt(trapData.GetVillageType()).AllocateWorker(this);
			this.logicTimer_0 = new LogicTimer();
			this.logicTimer_0.StartTimer(buildTime, this.m_level.GetLogicTime(), true, this.m_level.GetHomeOwnerAvatarChangeListener().GetCurrentTimestamp());
		}

		// Token: 0x06000E90 RID: 3728 RVA: 0x00038B94 File Offset: 0x00036D94
		public void CancelConstruction()
		{
			LogicAvatar homeOwnerAvatar = this.m_level.GetHomeOwnerAvatar();
			if (homeOwnerAvatar != null && homeOwnerAvatar.IsClientAvatar() && this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
				int num = this.int_5;
				if (this.bool_0)
				{
					this.SetUpgradeLevel(this.int_5);
					num++;
				}
				LogicTrapData trapData = this.GetTrapData();
				LogicResourceData buildResource = trapData.GetBuildResource();
				int buildCost = trapData.GetBuildCost(num);
				int count = LogicMath.Max(LogicDataTables.GetGlobals().GetBuildCancelMultiplier() * buildCost / 100, 0);
				homeOwnerAvatar.CommodityCountChangeHelper(0, buildResource, count);
				this.m_level.GetWorkerManagerAt(this.m_data.GetVillageType()).DeallocateWorker(this);
				if (num != 0)
				{
					if (this.m_listener != null)
					{
						this.m_listener.RefreshState();
						return;
					}
				}
				else
				{
					base.GetGameObjectManager().RemoveGameObject(this);
				}
			}
		}

		// Token: 0x06000E91 RID: 3729 RVA: 0x0000A0D8 File Offset: 0x000082D8
		public int GetRequiredTownHallLevelForUpgrade()
		{
			return this.GetTrapData().GetRequiredTownHallLevel(LogicMath.Min(this.int_5 + 1, this.GetTrapData().GetUpgradeLevelCount() - 1));
		}

		// Token: 0x06000E92 RID: 3730 RVA: 0x00038C70 File Offset: 0x00036E70
		public bool CanUpgrade(bool canCallListener)
		{
			if (this.logicTimer_0 == null && !this.IsMaxUpgradeLevel())
			{
				if (this.m_level.GetTownHallLevel(this.m_villageType) >= this.GetRequiredTownHallLevelForUpgrade())
				{
					return true;
				}
				if (canCallListener)
				{
					this.m_level.GetGameListener().TownHallLevelTooLow(this.GetRequiredTownHallLevelForUpgrade());
				}
			}
			return false;
		}

		// Token: 0x06000E93 RID: 3731 RVA: 0x00038CC4 File Offset: 0x00036EC4
		public bool IsMaxUpgradeLevel()
		{
			LogicTrapData trapData = this.GetTrapData();
			return (trapData.GetVillageType() == 1 && this.GetRequiredTownHallLevelForUpgrade() >= this.m_level.GetGameMode().GetConfiguration().GetMaxTownHallLevel()) || this.int_5 >= trapData.GetUpgradeLevelCount() - 1;
		}

		// Token: 0x06000E94 RID: 3732 RVA: 0x00038D14 File Offset: 0x00036F14
		public bool SpeedUpConstruction()
		{
			if (this.logicTimer_0 != null)
			{
				LogicClientAvatar playerAvatar = this.m_level.GetPlayerAvatar();
				int speedUpCost = LogicGamePlayUtil.GetSpeedUpCost(this.logicTimer_0.GetRemainingSeconds(this.m_level.GetLogicTime()), 0, this.m_villageType);
				if (playerAvatar.HasEnoughDiamonds(speedUpCost, true, this.m_level))
				{
					playerAvatar.UseDiamonds(speedUpCost);
					playerAvatar.GetChangeListener().DiamondPurchaseMade(4, this.m_data.GetGlobalID(), this.int_5 + (this.bool_0 ? 2 : 1), speedUpCost, this.m_level.GetVillageType());
					this.FinishConstruction(false);
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000E95 RID: 3733 RVA: 0x00038DB4 File Offset: 0x00036FB4
		public void SpawnUnit(int count)
		{
			LogicTrapData trapData = this.GetTrapData();
			LogicCharacterData logicCharacterData = this.bool_2[this.m_level.GetActiveLayout(this.m_villageType)] ? trapData.GetSpawnedCharAir() : trapData.GetSpawnedCharGround();
			if (logicCharacterData != null)
			{
				LogicVector2 logicVector = new LogicVector2();
				int i = 0;
				int num = 59;
				int num2 = 0;
				int num3 = 0;
				while (i < count)
				{
					int angle = num3 / trapData.GetNumSpawns(this.int_5) + num * this.int_6 % 360;
					int x = (int)((byte)(num2 & 128)) ^ 384;
					int x2 = this.GetMidX() + LogicMath.GetRotatedX(x, 0, angle);
					int y = this.GetMidY() + LogicMath.GetRotatedY(x, 0, angle);
					if (logicCharacterData.IsFlying())
					{
						logicVector.m_x = x2;
						logicVector.m_y = y;
						goto IL_DB;
					}
					if (this.m_level.GetTileMap().GetNearestPassablePosition(x2, y, logicVector, 1536))
					{
						goto IL_DB;
					}
					IL_13F:
					i++;
					num += 59;
					num2 += 128;
					num3 += 360;
					continue;
					IL_DB:
					LogicCharacter logicCharacter = (LogicCharacter)LogicGameObjectFactory.CreateGameObject(logicCharacterData, this.m_level, this.m_villageType);
					logicCharacter.GetHitpointComponent().SetTeam(1);
					logicCharacter.GetMovementComponent().EnableJump(3600000);
					logicCharacter.SetInitialPosition(logicVector.m_x, logicVector.m_y);
					logicCharacter.SetSpawnTime(200);
					base.GetGameObjectManager().AddGameObject(logicCharacter, -1);
					goto IL_13F;
				}
				logicVector.Destruct();
			}
		}

		// Token: 0x06000E96 RID: 3734 RVA: 0x0000A0FF File Offset: 0x000082FF
		public bool IsAirMode(int layout, bool draft)
		{
			if (draft)
			{
				return this.bool_3[layout];
			}
			return this.bool_2[layout];
		}

		// Token: 0x06000E97 RID: 3735 RVA: 0x00038F2C File Offset: 0x0003712C
		public void ToggleAirMode(int layout, bool draft)
		{
			bool[] array = this.bool_2;
			if (draft)
			{
				array = this.bool_3;
			}
			bool[] array2 = array;
			array2[layout] = !array2[layout];
		}

		// Token: 0x06000E98 RID: 3736 RVA: 0x00038F58 File Offset: 0x00037158
		public void ToggleDirection(int layout, bool draft)
		{
			int[] array = this.int_12;
			if (draft)
			{
				array = this.int_13;
			}
			int num = 0;
			if (array[layout] + 1 < this.GetTrapData().GetDirectionCount())
			{
				num = array[layout] + 1;
			}
			array[layout] = num;
		}

		// Token: 0x06000E99 RID: 3737 RVA: 0x00038F94 File Offset: 0x00037194
		public void SetDirection(int layout, bool draft, int count)
		{
			int[] array = this.int_12;
			if (draft)
			{
				array = this.int_13;
			}
			array[layout] = count;
		}

		// Token: 0x06000E9A RID: 3738 RVA: 0x0000A115 File Offset: 0x00008315
		public int GetDirection(int layout, bool draft)
		{
			if (layout > 7)
			{
				return 0;
			}
			if (draft)
			{
				return this.int_13[layout];
			}
			return this.int_12[layout];
		}

		// Token: 0x06000E9B RID: 3739 RVA: 0x00038FB8 File Offset: 0x000371B8
		public bool HasAirMode()
		{
			LogicTrapData logicTrapData = (LogicTrapData)this.m_data;
			return (logicTrapData.GetSpawnedCharAir() != null && logicTrapData.GetSpawnedCharGround() != null) || logicTrapData.HasAlternativeMode();
		}

		// Token: 0x040005CB RID: 1483
		private LogicTimer logicTimer_0;

		// Token: 0x040005CC RID: 1484
		private bool bool_0;

		// Token: 0x040005CD RID: 1485
		private bool bool_1;

		// Token: 0x040005CE RID: 1486
		private int int_5;

		// Token: 0x040005CF RID: 1487
		private int int_6;

		// Token: 0x040005D0 RID: 1488
		private int int_7;

		// Token: 0x040005D1 RID: 1489
		private int int_8;

		// Token: 0x040005D2 RID: 1490
		private int int_9;

		// Token: 0x040005D3 RID: 1491
		private int int_10;

		// Token: 0x040005D4 RID: 1492
		private int int_11;

		// Token: 0x040005D5 RID: 1493
		private readonly bool[] bool_2;

		// Token: 0x040005D6 RID: 1494
		private readonly bool[] bool_3;

		// Token: 0x040005D7 RID: 1495
		private readonly int[] int_12;

		// Token: 0x040005D8 RID: 1496
		private readonly int[] int_13;
	}
}
