using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.GameObject.Component
{
	// Token: 0x0200011D RID: 285
	public sealed class LogicCombatComponent : LogicComponent
	{
		// Token: 0x06000EE2 RID: 3810 RVA: 0x0003A5C4 File Offset: 0x000387C4
		public LogicCombatComponent(LogicGameObject gameObject) : base(gameObject)
		{
			this.int_23 = 1;
			this.logicGameObject_2 = new LogicGameObject[8];
			this.int_1 = new int[2];
			this.int_2 = new int[2];
			this.bool_15 = new bool[8];
			this.int_3 = new int[8];
			this.int_4 = new int[8];
			this.int_5 = new int[8];
			this.int_6 = new int[8];
			this.int_7 = new int[8];
			this.int_8 = new int[8];
			this.int_9 = new int[8];
			this.int_10 = new int[8];
			this.int_11 = new int[8];
			for (int i = 0; i < 8; i++)
			{
				this.int_10[i] = -1;
				this.int_11[i] = -1;
			}
			this.int_12 = new int[8];
			this.int_13 = new int[8];
			this.bool_16 = new bool[8];
			this.bool_17 = new bool[8];
			this.bool_12 = true;
			this.logicVector2_0 = new LogicVector2();
			this.logicVector2_1 = new LogicVector2(-1, -1);
			this.logicVector2_2 = new LogicVector2(-1, -1);
			this.logicVector2_3 = new LogicVector2(-1, -1);
			this.logicTargetList_0 = new LogicTargetList();
			this.logicTargetList_1 = new LogicTargetList();
			this.logicComponentFilter_0 = new LogicComponentFilter();
			this.logicComponentFilter_1 = new LogicComponentFilter();
			this.logicRandom_0 = new LogicRandom();
			this.logicArrayList_1 = new LogicArrayList<LogicGameObject>();
			this.logicArrayList_2 = new LogicArrayList<LogicGameObject>();
			this.logicArrayList_3 = new LogicArrayList<int>();
			this.logicArrayList_4 = new LogicArrayList<int>();
			this.logicArrayList_5 = new LogicArrayList<int>();
			this.logicComponentFilter_0.SetComponentType(LogicComponentType.HITPOINT);
			this.logicComponentFilter_1.SetComponentType(LogicComponentType.HITPOINT);
			if (gameObject.GetHitpointComponent() == null)
			{
				Debugger.Error("LogicCombatComponent::constructor - Enemy filter works only if Hitpoint component is initialized!");
			}
			this.logicComponentFilter_0.PassEnemyOnly(gameObject);
			this.logicArrayList_0 = new LogicArrayList<LogicGameObject>(20);
			if (this.m_parent.GetData().GetDataType() == LogicDataType.CHARACTER)
			{
				LogicCharacterData logicCharacterData = (LogicCharacterData)this.m_parent.GetData();
				if (logicCharacterData.IsSecondaryTroop())
				{
					this.int_28 = 1;
				}
				this.bool_1 = logicCharacterData.GetAttackMultipleBuildings();
			}
			this.int_18 = 100;
			this.logicRandom_0.SetIteratedRandomSeed(5512);
		}

		// Token: 0x06000EE3 RID: 3811 RVA: 0x0003A80C File Offset: 0x00038A0C
		public override void RemoveGameObjectReferences(LogicGameObject gameObject)
		{
			base.RemoveGameObjectReferences(gameObject);
			for (int i = 0; i < this.int_23; i++)
			{
				if (this.logicGameObject_2[0] == gameObject || this.logicGameObject_0 == gameObject)
				{
					this.logicGameObject_2[i] = null;
					this.int_4[i] = 0;
					if (this.int_5[i] != 0)
					{
						this.int_7[i] = this.logicAttackerItemData_0.GetAttackCooldownOverride();
					}
					this.int_5[i] = 0;
					this.logicGameObject_0 = null;
					if (this.m_parent.GetGameObjectType() == LogicGameObjectType.CHARACTER && ((LogicCharacter)this.m_parent).GetCharacterData().IsUnderground())
					{
						this.int_8[0] = LogicDataTables.GetGlobals().GetMinerHideTime() + this.m_parent.Rand(0) % LogicDataTables.GetGlobals().GetMinerHideTimeRandom();
					}
				}
			}
			for (int j = 0; j < this.logicArrayList_0.Size(); j++)
			{
				if (this.logicArrayList_0[j] == gameObject)
				{
					this.logicArrayList_0.Remove(j--);
				}
			}
			for (int k = 0; k < this.logicArrayList_1.Size(); k++)
			{
				if (this.logicArrayList_1[k] == gameObject)
				{
					this.logicArrayList_1.Remove(k--);
				}
			}
			if (this.logicGameObject_1 == gameObject)
			{
				this.logicGameObject_1 = null;
			}
		}

		// Token: 0x06000EE4 RID: 3812 RVA: 0x0000A4E2 File Offset: 0x000086E2
		public void SetPreferredTarget(LogicData data, int preferredTargetDamageMod, bool preferredTargetNotTargeting)
		{
			this.logicData_0 = data;
			this.int_18 = preferredTargetDamageMod;
			this.bool_6 = preferredTargetNotTargeting;
		}

		// Token: 0x06000EE5 RID: 3813 RVA: 0x0003A958 File Offset: 0x00038B58
		public void SetAttackValues(LogicAttackerItemData data, int damagePercentage)
		{
			this.logicAttackerItemData_0 = data;
			this.int_17 = data.GetPrepareSpeed();
			this.int_15 = damagePercentage * data.GetDamage(0, data.GetMultiTargets(false)) / 100;
			this.logicData_0 = data.GetPreferredTargetData();
			this.int_18 = 100 * data.GetPreferredTargetDamageMod();
			this.bool_6 = data.GetPreferredTargetNoTargeting();
			this.bool_12 = true;
			this.int_27 = data.GetSummonCooldown() / 4;
			this.int_19 = data.GetWakeUpSpeed();
			this.bool_7 = data.GetSpawnOnAttack();
			if (this.logicAttackerItemData_0.GetAttackSpeed() < 64)
			{
				Debugger.Error(this.m_parent.GetData().GetName() + " has too fast attack speed!");
			}
			if (this.logicAttackerItemData_0.GetFightWithGroups() && this.m_parent.GetGameObjectType() == LogicGameObjectType.CHARACTER)
			{
				this.bool_3 = true;
				this.int_16 = this.logicAttackerItemData_0.GetTargetGroupsRadius();
				this.bool_4 = true;
			}
			if (this.logicAttackerItemData_0.HasAlternativeAttackMode())
			{
				this.bool_2 = true;
				this.bool_5 = this.logicAttackerItemData_0.GetMultiTargets(true);
				this.int_23 = (this.bool_5 ? this.logicAttackerItemData_0.GetAltNumMultiTargets() : 1);
			}
			if (this.logicAttackerItemData_0.GetAmmoCount() > 0)
			{
				int num = this.logicAttackerItemData_0.GetAttackSpeed();
				int num2 = 1;
				if (this.bool_16[this.m_parent.GetLevel().GetCurrentLayout()])
				{
					num = this.logicAttackerItemData_0.GetAltAttackSpeed();
				}
				if (num >= 64)
				{
					num2 = num / 64;
				}
				this.int_29 = num2;
				this.int_30 = num2;
			}
			if (this.int_15 > 0 || this.logicAttackerItemData_0.GetShockwavePushStrength() != 0)
			{
				this.logicComponentFilter_0.PassEnemyOnly(this.m_parent);
				return;
			}
			if (this.logicAttackerItemData_0.GetDamage2() > 0)
			{
				this.logicComponentFilter_0.PassEnemyOnly(this.m_parent);
				return;
			}
			this.logicComponentFilter_0.PassFriendlyOnly(this.m_parent);
		}

		// Token: 0x06000EE6 RID: 3814 RVA: 0x0000A4F9 File Offset: 0x000086F9
		public void SetAttackDelay(int idx, int time)
		{
			this.int_3[idx] = time;
			this.logicGameObject_2[idx] = null;
			this.logicGameObject_0 = null;
		}

		// Token: 0x06000EE7 RID: 3815 RVA: 0x0000A514 File Offset: 0x00008714
		public LogicData GetPreferredTarget()
		{
			return this.logicData_0;
		}

		// Token: 0x06000EE8 RID: 3816 RVA: 0x0000A51C File Offset: 0x0000871C
		public void SetActivationTime(int value)
		{
			this.int_22 = value;
		}

		// Token: 0x06000EE9 RID: 3817 RVA: 0x0000A525 File Offset: 0x00008725
		public void SetTroopChild(bool child)
		{
			this.bool_8 = child;
		}

		// Token: 0x06000EEA RID: 3818 RVA: 0x0000A52E File Offset: 0x0000872E
		public void SetSearchRadius(int radius)
		{
			this.int_24 = radius;
		}

		// Token: 0x06000EEB RID: 3819 RVA: 0x0000A537 File Offset: 0x00008737
		public int Rand(int rnd)
		{
			return this.m_parent.Rand(rnd);
		}

		// Token: 0x06000EEC RID: 3820 RVA: 0x0000A545 File Offset: 0x00008745
		public LogicGameObject GetTarget(int idx)
		{
			return this.logicGameObject_2[idx];
		}

		// Token: 0x06000EED RID: 3821 RVA: 0x0003AB44 File Offset: 0x00038D44
		public bool IsTargetValid(LogicGameObject gameObject)
		{
			if (gameObject != null)
			{
				LogicCombatComponent combatComponent = gameObject.GetCombatComponent();
				if (combatComponent != null && combatComponent.int_20 > 0 && (this.int_15 > 0 || this.logicAttackerItemData_0.GetDamage2() > 0 || this.logicAttackerItemData_0.GetShockwavePushStrength() != 0))
				{
					return false;
				}
				LogicHitpointComponent hitpointComponent = gameObject.GetHitpointComponent();
				if (this.int_15 <= 0 && this.logicAttackerItemData_0.GetDamage2() <= 0 && this.logicAttackerItemData_0.GetShockwavePushStrength() == 0)
				{
					if (hitpointComponent != null && hitpointComponent.GetTeam() == this.m_parent.GetHitpointComponent().GetTeam())
					{
						return gameObject.IsAlive();
					}
				}
				else if (hitpointComponent != null && hitpointComponent.IsEnemy(this.m_parent))
				{
					return this.m_parent.GetMovementComponent() != null || this.IsInRange(gameObject);
				}
			}
			return false;
		}

		// Token: 0x06000EEE RID: 3822 RVA: 0x0000A54F File Offset: 0x0000874F
		public LogicAttackerItemData GetAttackerItemData()
		{
			return this.logicAttackerItemData_0;
		}

		// Token: 0x06000EEF RID: 3823 RVA: 0x0000A557 File Offset: 0x00008757
		public bool HasAltAttackMode()
		{
			return this.bool_2;
		}

		// Token: 0x06000EF0 RID: 3824 RVA: 0x0000A55F File Offset: 0x0000875F
		public bool UseAltAttackMode(int layoutId, bool draft)
		{
			if (draft)
			{
				return this.bool_17[layoutId];
			}
			return this.bool_16[layoutId];
		}

		// Token: 0x06000EF1 RID: 3825 RVA: 0x0003AC08 File Offset: 0x00038E08
		public bool IsInRange(LogicGameObject gameObject)
		{
			int currentLayout = this.m_parent.GetLevel().GetCurrentLayout();
			int angle = 0;
			if (this.logicAttackerItemData_0.GetTargetingConeAngle() != 0)
			{
				angle = this.int_12[currentLayout];
			}
			this.CalculateDistance(gameObject, this.logicVector2_0);
			int x = this.logicVector2_0.m_x;
			int y = this.logicVector2_0.m_y;
			if (!this.m_parent.IsFlying())
			{
				if (gameObject.GetGameObjectType() != LogicGameObjectType.CHARACTER)
				{
					int attackRange = this.GetAttackRange(currentLayout, false);
					if (x >= attackRange * attackRange)
					{
						return false;
					}
					goto IL_B1;
				}
			}
			int minAttackRange = this.logicAttackerItemData_0.GetMinAttackRange();
			if (x < minAttackRange * minAttackRange)
			{
				return false;
			}
			int attackRange2 = this.GetAttackRange(currentLayout, false);
			if (x > (attackRange2 + 256) * (attackRange2 + 256))
			{
				return false;
			}
			IL_B1:
			return this.logicAttackerItemData_0.GetTargetingConeAngle() <= 0 || LogicMath.GetAngleBetween(y, LogicMath.NormalizeAngle180(angle)) <= this.logicAttackerItemData_0.GetTargetingConeAngle() / 2;
		}

		// Token: 0x06000EF2 RID: 3826 RVA: 0x0003ACF4 File Offset: 0x00038EF4
		public bool IsInLine(LogicGameObject gameObject)
		{
			if (gameObject != null)
			{
				if (!gameObject.IsWall())
				{
					if (this.m_parent.GetGameObjectType() == LogicGameObjectType.CHARACTER)
					{
						if (!((LogicCharacter)this.m_parent).GetCharacterData().GetAttackOverWalls())
						{
							return !this.m_parent.GetLevel().GetTileMap().GetWallInPassableLine(this.m_parent.GetMidX(), this.m_parent.GetMidY(), gameObject.GetMidX(), gameObject.GetMidY(), new LogicVector2());
						}
						return true;
					}
				}
				return true;
			}
			return true;
		}

		// Token: 0x06000EF3 RID: 3827 RVA: 0x0003AD78 File Offset: 0x00038F78
		public void CalculateDistance(LogicGameObject gameObject, LogicVector2 position)
		{
			int midX = this.m_parent.GetMidX();
			int midY = this.m_parent.GetMidY();
			int y = 0;
			int x2;
			if (!this.m_parent.IsFlying())
			{
				if (gameObject.GetGameObjectType() != LogicGameObjectType.CHARACTER)
				{
					int num = gameObject.PassableSubtilesAtEdge() << 8;
					int x = gameObject.GetX();
					int y2 = gameObject.GetY();
					int num2 = LogicMath.Clamp(midX, x + num, x + (gameObject.GetWidthInTiles() << 9) - num);
					int num3 = LogicMath.Clamp(midY, y2 + num, y2 + (gameObject.GetHeightInTiles() << 9) - num);
					x2 = (num2 - midX) * (num2 - midX) + (num3 - midY) * (num3 - midY);
					if (this.logicAttackerItemData_0.GetTargetingConeAngle() > 0)
					{
						y = LogicMath.NormalizeAngle180(LogicMath.GetAngle(num2 - midX, num3 - midY));
						goto IL_F7;
					}
					goto IL_F7;
				}
			}
			x2 = this.m_parent.GetDistanceSquaredTo(gameObject);
			if (this.logicAttackerItemData_0.GetTargetingConeAngle() > 0)
			{
				y = LogicMath.NormalizeAngle180(LogicMath.GetAngle(gameObject.GetMidX() - midX, gameObject.GetMidY() - midY));
			}
			IL_F7:
			position.m_x = x2;
			position.m_y = y;
		}

		// Token: 0x06000EF4 RID: 3828 RVA: 0x0003AE8C File Offset: 0x0003908C
		public int GetAttackRange(int layout, bool draft)
		{
			if (draft)
			{
				if (this.bool_17[layout])
				{
					return this.logicAttackerItemData_0.GetAttackRange(true);
				}
			}
			else if (this.bool_16[layout])
			{
				return this.logicAttackerItemData_0.GetAttackRange(true);
			}
			int num = this.logicAttackerItemData_0.GetAttackRange(false);
			if (this.m_parent.GetGameObjectType() == LogicGameObjectType.CHARACTER)
			{
				LogicCharacter logicCharacter = (LogicCharacter)this.m_parent;
				LogicCharacterData characterData = logicCharacter.GetCharacterData();
				if (logicCharacter.GetSpecialAbilityAvailable() && characterData.GetSpecialAbilityType() == 6)
				{
					num += characterData.GetSpecialAbilityAttribute2(logicCharacter.GetUpgradeLevel()) * this.logicAttackerItemData_0.GetAttackRange(false) / 100;
				}
			}
			return num;
		}

		// Token: 0x06000EF5 RID: 3829 RVA: 0x0000A575 File Offset: 0x00008775
		public bool IsWallBreaker()
		{
			return !this.bool_6 && this.logicData_0 != null && this.logicData_0.GetDataType() == LogicDataType.BUILDING_CLASS && ((LogicBuildingClassData)this.logicData_0).IsWall();
		}

		// Token: 0x06000EF6 RID: 3830 RVA: 0x0003AF2C File Offset: 0x0003912C
		public void SearchTarget(int idx, LogicGameObject prevTarget)
		{
			if (this.bool_3 && this.SearchTargetWithGroups(idx, prevTarget))
			{
				return;
			}
			if (this.bool_13)
			{
				this.SelectTarget(((LogicCharacter)this.m_parent).GetParent().GetCombatComponent().logicGameObject_2[idx], idx);
				return;
			}
			if (this.int_15 <= 0 && this.logicAttackerItemData_0.GetShockwavePushStrength() == 0 && this.logicAttackerItemData_0.GetDamage2() <= 0 && (LogicDataTables.GetGlobals().UseSmarterHealer() || LogicDataTables.GetGlobals().UseStickToClosestUnitHealer()))
			{
				LogicGameObject logicGameObject = LogicDataTables.GetGlobals().UseSmarterHealer() ? this.SearchSmartHealerTarget() : this.SearchHealerTargetUsingStick();
				if (logicGameObject != null && this.IsTargetValid(logicGameObject))
				{
					this.SelectTarget(logicGameObject, idx);
				}
				return;
			}
			if (this.logicAttackerItemData_0.GetPreferredTargetNoTargeting())
			{
				LogicGameObject logicGameObject2 = this.SearchTargetNoTargeting();
				if (logicGameObject2 != null && this.IsTargetValid(logicGameObject2))
				{
					this.SelectTarget(logicGameObject2, idx);
					return;
				}
			}
			bool flag = false;
			if (this.IsWallBreaker())
			{
				LogicGameObject logicGameObject3 = this.SelectWall();
				if (logicGameObject3 != null && this.IsTargetValid(logicGameObject3))
				{
					this.SelectTarget(logicGameObject3, idx);
					return;
				}
				flag = true;
			}
			this.logicTargetList_1.Clear();
			this.logicTargetList_0.Clear();
			this.logicArrayList_0.Clear();
			this.m_parent.GetGameObjectManager().GetGameObjects(this.logicArrayList_0, this.logicComponentFilter_0);
			LogicArrayList<LogicGameObject> logicArrayList = new LogicArrayList<LogicGameObject>();
			LogicMovementComponent movementComponent = this.m_parent.GetMovementComponent();
			int i = 0;
			int num = this.logicArrayList_0.Size();
			while (i < num)
			{
				LogicGameObject logicGameObject4 = this.logicArrayList_0[i];
				if (!logicGameObject4.IsHidden() && (!logicGameObject4.IsStealthy() || (this.int_15 <= 0 && this.logicAttackerItemData_0.GetShockwavePushStrength() == 0 && this.logicAttackerItemData_0.GetDamage2() <= 0)) && this.CanAttackHeightCheck(logicGameObject4))
				{
					if (logicGameObject4.GetGameObjectType() == LogicGameObjectType.CHARACTER)
					{
						LogicCharacter logicCharacter = (LogicCharacter)logicGameObject4;
						LogicCombatComponent combatComponent;
						if (logicCharacter.GetSpawnDelay() > 0 || logicCharacter.GetSpawnIdleTime() > 0 || ((combatComponent = logicCharacter.GetCombatComponent()) != null && combatComponent.int_20 > 0) || logicCharacter.GetChildTroops() != null)
						{
							goto IL_507;
						}
					}
					bool flag2 = false;
					for (int j = 0; j < this.int_23; j++)
					{
						if (idx != j && this.logicGameObject_2[j] == logicGameObject4)
						{
							flag2 = true;
						}
					}
					if (!flag2)
					{
						int num2;
						if (LogicDataTables.GetGlobals().MorePreciseTargetSelection() && (!LogicDataTables.GetGlobals().MovingUnitsUseSimpleSelect() || movementComponent == null))
						{
							this.CalculateDistance(logicGameObject4, this.logicVector2_0);
							num2 = this.logicVector2_0.m_x;
						}
						else
						{
							int num3 = logicGameObject4.GetMidX() - this.m_parent.GetMidX() >> 9;
							int num4 = logicGameObject4.GetMidY() - this.m_parent.GetMidY() >> 9;
							num2 = num3 * num3 + num4 * num4;
						}
						if (LogicDataTables.GetGlobals().GetMinerTargetRandomPercentage() > 0 && this.m_parent.GetGameObjectType() == LogicGameObjectType.CHARACTER && ((LogicCharacter)logicGameObject4).GetCharacterData().IsUnderground() && this.int_21 > 0)
						{
							num2 -= num2 / 100 * this.logicRandom_0.Rand(LogicDataTables.GetGlobals().GetMinerTargetRandomPercentage());
						}
						if (this.int_24 > 0 && movementComponent != null)
						{
							LogicBuilding baseBuilding = movementComponent.GetBaseBuilding();
							if (baseBuilding != null)
							{
								this.logicVector2_0.m_x = logicGameObject4.GetMidX() - baseBuilding.GetMidX();
								this.logicVector2_0.m_y = logicGameObject4.GetMidY() - baseBuilding.GetMidY();
								if (this.logicVector2_0.GetLengthSquared() > (this.int_24 << 9) * (this.int_24 << 9))
								{
									goto IL_507;
								}
							}
							if (!this.m_parent.IsHero())
							{
								this.logicVector2_0.m_x = logicGameObject4.GetMidX() - this.m_parent.GetMidX();
								this.logicVector2_0.m_y = logicGameObject4.GetMidY() - this.m_parent.GetMidY();
								int clanDefenderSearchRadius = LogicDataTables.GetGlobals().GetClanDefenderSearchRadius();
								if (this.logicVector2_0.GetLengthSquared() > (clanDefenderSearchRadius << 9) * (clanDefenderSearchRadius << 9))
								{
									goto IL_507;
								}
							}
						}
						if ((this.logicAttackerItemData_0.GetMinAttackRange() <= 0 && this.logicAttackerItemData_0.GetTargetingConeAngle() <= 0) || this.IsInRange(logicGameObject4))
						{
							if (this.int_15 <= 0 && this.logicAttackerItemData_0.GetShockwavePushStrength() == 0 && this.logicAttackerItemData_0.GetDamage2() <= 0)
							{
								if (logicGameObject4 != this.m_parent && logicGameObject4.IsAlive() && (flag || !this.IsWall(logicGameObject4)))
								{
									LogicHitpointComponent hitpointComponent = logicGameObject4.GetHitpointComponent();
									if (hitpointComponent != null && (!hitpointComponent.HasFullHitpoints() || hitpointComponent.IsDamagedRecently()))
									{
										this.logicTargetList_0.AddCandidate(logicGameObject4, num2);
									}
									else
									{
										this.logicTargetList_1.AddCandidate(logicGameObject4, num2);
									}
								}
							}
							else if (flag || !this.IsWall(logicGameObject4))
							{
								if (this.bool_8)
								{
									if (this.IsTargetValid(logicGameObject4))
									{
										logicArrayList.Add(logicGameObject4);
									}
								}
								else if (this.IsPreferredTargetForMe(logicGameObject4, num2))
								{
									this.logicTargetList_0.AddCandidate(logicGameObject4, num2);
								}
								else
								{
									this.logicTargetList_1.AddCandidate(logicGameObject4, num2);
								}
							}
						}
					}
				}
				IL_507:
				i++;
			}
			LogicGameObject logicGameObject5 = this.logicTargetList_0.EvaluateTargets(movementComponent);
			if (logicGameObject5 != null && movementComponent == null && !this.IsInRange(logicGameObject5))
			{
				logicGameObject5 = null;
			}
			if (logicArrayList.Size() <= 0)
			{
				if (logicGameObject5 == null)
				{
					if (this.logicData_0 != null && this.logicData_0.GetDataType() == LogicDataType.BUILDING)
					{
						this.logicData_0 = ((LogicBuildingData)this.logicData_0).GetBuildingClass();
						return;
					}
					logicGameObject5 = this.logicTargetList_1.EvaluateTargets(movementComponent);
				}
			}
			else
			{
				logicGameObject5 = logicArrayList[this.logicRandom_0.Rand(logicArrayList.Size())];
			}
			this.SelectTarget(logicGameObject5, idx);
		}

		// Token: 0x06000EF7 RID: 3831 RVA: 0x0003B4DC File Offset: 0x000396DC
		public LogicGameObject SearchTargetNoTargeting()
		{
			this.logicTargetList_1.Clear();
			this.logicTargetList_0.Clear();
			this.logicArrayList_0.Clear();
			this.m_parent.GetGameObjectManager().GetGameObjects(this.logicArrayList_0, this.logicComponentFilter_0);
			LogicMovementComponent movementComponent = this.m_parent.GetMovementComponent();
			LogicGameObject logicGameObject = null;
			int i = 0;
			int num = 0;
			while (i < this.logicArrayList_0.Size())
			{
				LogicGameObject logicGameObject2 = this.logicArrayList_0[i];
				if (!logicGameObject2.IsHidden() && (!logicGameObject2.IsStealthy() || (this.int_15 <= 0 && this.logicAttackerItemData_0.GetShockwavePushStrength() == 0 && this.logicAttackerItemData_0.GetDamage2() <= 0)) && this.CanAttackHeightCheck(logicGameObject2))
				{
					int num2;
					if (LogicDataTables.GetGlobals().MorePreciseTargetSelection() && (!LogicDataTables.GetGlobals().MovingUnitsUseSimpleSelect() || movementComponent == null))
					{
						this.CalculateDistance(logicGameObject2, this.logicVector2_0);
						num2 = this.logicVector2_0.m_x;
					}
					else
					{
						int num3 = logicGameObject2.GetMidX() - this.m_parent.GetMidX() >> 9;
						int num4 = logicGameObject2.GetMidY() - this.m_parent.GetMidY() >> 9;
						num2 = num3 * num3 + num4 * num4;
					}
					if (num2 < num || logicGameObject == null)
					{
						num = num2;
						logicGameObject = logicGameObject2;
					}
				}
				i++;
			}
			return logicGameObject;
		}

		// Token: 0x06000EF8 RID: 3832 RVA: 0x0003B62C File Offset: 0x0003982C
		public bool SearchTargetWithGroups(int idx, LogicGameObject prevTarget)
		{
			if (this.int_38 == 0)
			{
				this.RefreshTargetGroups(true);
				this.int_38 = LogicDataTables.GetGlobals().GetForgetTargetTime();
			}
			this.logicArrayList_2.Clear();
			this.logicArrayList_4.Clear();
			this.logicArrayList_2.EnsureCapacity(this.logicArrayList_0.Size());
			this.logicArrayList_4.EnsureCapacity(this.logicArrayList_0.Size());
			int attackRange = this.GetAttackRange(this.m_parent.GetLevel().GetCurrentLayout(), false);
			int num = attackRange * attackRange;
			int num2 = (attackRange - 512) * (attackRange - 512);
			int num3 = 0;
			LogicGameObject logicGameObject = null;
			for (int i = 0; i < this.logicArrayList_1.Size(); i++)
			{
				LogicGameObject logicGameObject2 = this.logicArrayList_1[i];
				LogicCombatComponent combatComponent = logicGameObject2.GetCombatComponent();
				if (combatComponent != null)
				{
					int num4 = 1;
					if (logicGameObject2.GetGameObjectType() == LogicGameObjectType.CHARACTER)
					{
						LogicCharacter logicCharacter = (LogicCharacter)logicGameObject2;
						num4 = (this.bool_3 ? logicCharacter.GetCharacterData().GetFriendlyGroupWeight() : logicCharacter.GetCharacterData().GetEnemyGroupWeight());
					}
					LogicGameObject logicGameObject3 = combatComponent.logicGameObject_2[0];
					if (logicGameObject3 != null && (!logicGameObject3.IsWall() || ((logicGameObject3 = combatComponent.logicGameObject_0) != null && (logicGameObject3.GetDistanceSquaredTo(combatComponent.logicGameObject_2[0]) <= num2 || logicGameObject3.GetDistanceSquaredTo(this.m_parent) <= num))))
					{
						int num5 = this.logicArrayList_2.IndexOf(logicGameObject3);
						if (num5 == -1)
						{
							this.logicArrayList_2.Add(logicGameObject3);
							this.logicArrayList_4.Add(num4);
						}
						else
						{
							num4 += this.logicArrayList_4[num5];
							this.logicArrayList_4[num5] = num4;
						}
						if (num4 > num3)
						{
							num3 = num4;
							logicGameObject = logicGameObject3;
						}
					}
				}
			}
			if (logicGameObject == null)
			{
				for (int j = 0; j < this.logicArrayList_1.Size(); j++)
				{
					LogicGameObject logicGameObject4 = this.logicArrayList_1[j];
					LogicCombatComponent combatComponent2 = logicGameObject4.GetCombatComponent();
					if (combatComponent2 != null)
					{
						int num6 = 1;
						if (logicGameObject4.GetGameObjectType() == LogicGameObjectType.CHARACTER)
						{
							LogicCharacter logicCharacter2 = (LogicCharacter)logicGameObject4;
							num6 = (this.bool_3 ? logicCharacter2.GetCharacterData().GetFriendlyGroupWeight() : logicCharacter2.GetCharacterData().GetEnemyGroupWeight());
						}
						LogicGameObject logicGameObject5 = combatComponent2.logicGameObject_2[0];
						if (logicGameObject5 != null)
						{
							int num7 = this.logicArrayList_2.IndexOf(logicGameObject5);
							if (num7 == -1)
							{
								this.logicArrayList_2.Add(logicGameObject5);
								this.logicArrayList_4.Add(num6);
							}
							else
							{
								num6 += this.logicArrayList_4[num7];
								this.logicArrayList_4[num7] = num6;
							}
							if (num6 > num3)
							{
								num3 = num6;
								logicGameObject = logicGameObject5;
							}
						}
					}
				}
				if (logicGameObject == null && prevTarget != null && this.int_37 <= 0 && prevTarget.IsAlive() && this.IsInRange(prevTarget))
				{
					logicGameObject = prevTarget;
				}
			}
			if (logicGameObject != null)
			{
				this.SelectTarget(logicGameObject, idx);
				return true;
			}
			return false;
		}

		// Token: 0x06000EF9 RID: 3833 RVA: 0x0003B910 File Offset: 0x00039B10
		public LogicGameObject SearchSmartHealerTarget()
		{
			if (this.int_0 == null)
			{
				this.int_0 = new int[625];
			}
			Array.Clear(this.int_0, 0, 625);
			this.logicArrayList_0.Clear();
			this.m_parent.GetGameObjectManager().GetGameObjects(this.logicArrayList_0, this.logicComponentFilter_0);
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				LogicGameObject logicGameObject = this.logicArrayList_0[i];
				if (logicGameObject.IsAlive() && logicGameObject.GetData() != this.m_parent.GetData() && this.CanAttackHeightCheck(logicGameObject))
				{
					int num = logicGameObject.GetMidX() >> 10;
					uint num2 = (uint)(logicGameObject.GetMidY() >> 10);
					int num3 = num + (int)(25U * num2);
					if (num >= 25 || num2 >= 25U)
					{
						num3 = -1;
					}
					if (num3 >= 0)
					{
						int num4 = 0;
						if (logicGameObject.GetGameObjectType() == LogicGameObjectType.CHARACTER)
						{
							num4 = ((LogicCharacter)logicGameObject).GetCharacterData().GetHousingSpace() / 2 + 1;
						}
						int num5 = this.int_0[num3] + (num4 << 16);
						LogicHitpointComponent hitpointComponent = logicGameObject.GetHitpointComponent();
						if (hitpointComponent != null && (!hitpointComponent.HasFullHitpoints() || hitpointComponent.IsDamagedRecently()))
						{
							num5 += num4;
						}
						this.int_0[num3] = num5;
					}
				}
			}
			int num6 = -1;
			LogicGameObject logicGameObject2 = this.logicGameObject_2[0];
			LogicGameObject logicGameObject3 = logicGameObject2;
			if (logicGameObject2 != null)
			{
				int num7 = logicGameObject2.GetMidX() >> 10;
				uint num8 = (uint)(logicGameObject2.GetMidY() >> 10);
				num6 = num7 + (int)(25U * num8);
				if (num7 >= 25 || num8 >= 25U)
				{
					num6 = -1;
				}
			}
			int num9 = LogicMath.Max(0, LogicMath.GetRadius(-7168, 512) - this.logicAttackerItemData_0.GetAttackRange(false));
			if (num6 < 0)
			{
				num9 = -(int)((long)(num9 >> 9) + (long)((ulong)((uint)((num9 >> 9) * (num9 >> 9)) >> 2)));
			}
			else
			{
				num9 = this.GetHealerTargetCost(num6) - LogicCombatComponent.GetHealerAttackRange(this.m_parent.GetMidX(), this.m_parent.GetMidY(), this.logicAttackerItemData_0.GetAttackRange(false), num6);
			}
			int num10 = LogicMath.Max(0, LogicMath.GetRadius(-25088, 512) - this.logicAttackerItemData_0.GetAttackRange(false));
			num10 = -(int)((long)(num10 >> 9) + (long)((ulong)((uint)((num10 >> 9) * (num10 >> 9)) >> 2)));
			num9 += ((num9 > 0) ? (num9 / 2 + 1) : 1);
			int num11 = -1;
			int num12 = -1;
			int j = 0;
			int midX = this.m_parent.GetMidX();
			int midY = this.m_parent.GetMidY();
			while (j < 625)
			{
				int healerAttackRange = LogicCombatComponent.GetHealerAttackRange(midX, midY, this.logicAttackerItemData_0.GetAttackRange(false), j);
				int healerTargetCost = this.GetHealerTargetCost(j);
				int num13 = LogicMath.Min(this.int_0[j] >> 16, 20);
				if (healerTargetCost > 0)
				{
					int num14 = healerTargetCost - healerAttackRange;
					if (num14 > num9)
					{
						num11 = j;
						num9 = num14;
					}
				}
				if (num13 > 1)
				{
					int num15 = num13 - healerAttackRange;
					if (num15 > num10)
					{
						num12 = j;
						num10 = num15;
					}
				}
				j++;
			}
			if (num11 < 0)
			{
				if (logicGameObject3 != null)
				{
					return logicGameObject3;
				}
				if (num12 < 0)
				{
					return null;
				}
				num11 = num12;
			}
			int num16 = int.MaxValue;
			int k = 0;
			int num17 = num11 % 25 << 10 | 512;
			int num18 = num11 / 25 << 10 | 512;
			while (k < this.logicArrayList_0.Size())
			{
				LogicGameObject logicGameObject4 = this.logicArrayList_0[k];
				if (logicGameObject4.IsAlive() && this.CanAttackHeightCheck(logicGameObject4) && logicGameObject4.GetGameObjectType() == LogicGameObjectType.CHARACTER)
				{
					this.logicVector2_0.m_x = num17 - logicGameObject4.GetMidX();
					this.logicVector2_0.m_y = num18 - logicGameObject4.GetMidY();
					int lengthSquared = this.logicVector2_0.GetLengthSquared();
					if (lengthSquared < num16)
					{
						num16 = lengthSquared;
						logicGameObject3 = logicGameObject4;
					}
				}
				k++;
			}
			return logicGameObject3;
		}

		// Token: 0x06000EFA RID: 3834 RVA: 0x0003BCC0 File Offset: 0x00039EC0
		public int GetHealerTargetCost(int weights)
		{
			int num = weights % 25;
			int num2 = weights / 25;
			uint num3 = (uint)num;
			uint num4 = (uint)((num2 << 10) - 1024 >> 10);
			int num5 = (int)(num3 + 25U * num4);
			if (num3 >= 25U || num4 >= 25U)
			{
				num5 = -1;
			}
			int num6 = num;
			uint num7 = (uint)((num2 << 10) + 1024 >> 10);
			int num8 = num6 + (int)(25U * num7);
			if (num6 >= 25 || num7 >= 25U)
			{
				num8 = -1;
			}
			int num9 = (num << 10) - 1024 >> 10;
			uint num10 = (uint)num2;
			int num11 = num9 + (int)(25U * num10);
			if (num9 >= 25 || num10 >= 25U)
			{
				num11 = -1;
			}
			int num12 = (num << 10) + 1024 >> 10;
			uint num13 = (uint)num2;
			int num14 = num12 + (int)(25U * num13);
			if (num12 >= 25 || num13 >= 25U)
			{
				num14 = -1;
			}
			int num15 = (int)((ushort)this.int_0[weights]);
			if (num5 >= 0)
			{
				num15 += (ushort)this.int_0[num5] >> 2;
			}
			if (num8 >= 0)
			{
				num15 += (this.int_0[num8] >> 2 & 16383);
			}
			if (num11 >= 0)
			{
				num15 += (this.int_0[num11] >> 2 & 16383);
			}
			if (num14 >= 0)
			{
				num15 += (this.int_0[num14] >> 2 & 16383);
			}
			return LogicMath.Min(num15 / 2, 20);
		}

		// Token: 0x06000EFB RID: 3835 RVA: 0x0003BDEC File Offset: 0x00039FEC
		public static int GetHealerAttackRange(int x, int y, int attackRange, int currentTargetWeights)
		{
			int radius = LogicMath.GetRadius((currentTargetWeights % 25 << 10 | 512) - x, (currentTargetWeights / 25 << 10 | 512) - y);
			int num = LogicMath.Max(0, radius - attackRange);
			return (int)((long)(num >> 9) + (long)((ulong)((uint)((num >> 9) * (num >> 9)) >> 2)));
		}

		// Token: 0x06000EFC RID: 3836 RVA: 0x0003BE3C File Offset: 0x0003A03C
		public LogicGameObject SearchHealerTargetUsingStick()
		{
			this.logicArrayList_0.Clear();
			this.m_parent.GetGameObjectManager().GetGameObjects(this.logicArrayList_0, this.logicComponentFilter_0);
			LogicGameObject result = null;
			int i = 0;
			int num = int.MaxValue;
			while (i < this.logicArrayList_0.Size())
			{
				LogicGameObject logicGameObject = this.logicArrayList_0[i];
				if (logicGameObject.GetGameObjectType() == LogicGameObjectType.CHARACTER && logicGameObject.IsAlive() && this.CanAttackHeightCheck(logicGameObject) && logicGameObject.GetData() != this.m_parent.GetData() && this.IsTargetValid(logicGameObject) && logicGameObject.GetHitpointComponent() != null)
				{
					this.logicVector2_0.m_x = this.m_parent.GetMidX() - logicGameObject.GetMidX();
					this.logicVector2_0.m_y = this.m_parent.GetMidY() - logicGameObject.GetMidY();
					int lengthSquared = this.logicVector2_0.GetLengthSquared();
					if (lengthSquared < num)
					{
						num = lengthSquared;
						result = logicGameObject;
					}
				}
				i++;
			}
			return result;
		}

		// Token: 0x06000EFD RID: 3837 RVA: 0x0003BF34 File Offset: 0x0003A134
		public void SelectTarget(LogicGameObject gameObject, int idx)
		{
			if (LogicDataTables.GetGlobals().ClearAlertStateIfNoTargetFound() && idx == 0 && this.int_37 > 0 && (gameObject == null || gameObject.GetGameObjectType() != LogicGameObjectType.CHARACTER))
			{
				this.int_37 = 0;
			}
			this.logicGameObject_2[idx] = gameObject;
			this.logicGameObject_0 = null;
			this.int_25 = 0;
			if (this.bool_12)
			{
				this.int_26 = 0;
			}
			this.int_6[idx] = LogicDataTables.GetGlobals().GetForgetTargetTime();
		}

		// Token: 0x06000EFE RID: 3838 RVA: 0x0003BFA4 File Offset: 0x0003A1A4
		public bool IsPreferredTargetForMe(LogicGameObject gameObject, int distance)
		{
			if (this.logicData_0 != null)
			{
				return LogicCombatComponent.IsPreferredTarget(this.logicData_0, gameObject);
			}
			if (this.int_37 > 0)
			{
				if (gameObject.GetGameObjectType() == LogicGameObjectType.CHARACTER)
				{
					int num = (!LogicDataTables.GetGlobals().MorePreciseTargetSelection() || (LogicDataTables.GetGlobals().MovingUnitsUseSimpleSelect() && this.m_parent.GetMovementComponent() != null)) ? (LogicDataTables.GetGlobals().GetCharVersusCharRadiusForAttacker() / 512) : LogicDataTables.GetGlobals().GetCharVersusCharRadiusForAttacker();
					LogicMovementComponent movementComponent = gameObject.GetMovementComponent();
					return movementComponent != null && num * num > distance && !movementComponent.GetPatrolEnabled();
				}
			}
			return false;
		}

		// Token: 0x06000EFF RID: 3839 RVA: 0x0000A5A7 File Offset: 0x000087A7
		public bool GetTrackAirTargets(int layout, bool draft)
		{
			return this.logicAttackerItemData_0.GetTrackAirTargets(draft ? this.bool_17[layout] : this.bool_16[layout]);
		}

		// Token: 0x06000F00 RID: 3840 RVA: 0x0000A5C9 File Offset: 0x000087C9
		public bool GetTrackGroundTargets(int layout, bool draft)
		{
			return this.logicAttackerItemData_0.GetTrackGroundTargets(draft ? this.bool_17[layout] : this.bool_16[layout]);
		}

		// Token: 0x06000F01 RID: 3841 RVA: 0x0000A5EB File Offset: 0x000087EB
		public int GetTotalTargets()
		{
			return this.int_28;
		}

		// Token: 0x06000F02 RID: 3842 RVA: 0x0000A5F3 File Offset: 0x000087F3
		public int GetHitCount()
		{
			return this.int_21;
		}

		// Token: 0x06000F03 RID: 3843 RVA: 0x0000A5FB File Offset: 0x000087FB
		public bool GetAttackMultipleBuildings()
		{
			return this.bool_1;
		}

		// Token: 0x06000F04 RID: 3844 RVA: 0x0000A603 File Offset: 0x00008803
		public int GetMaxAmmo()
		{
			return this.logicAttackerItemData_0.GetAmmoCount();
		}

		// Token: 0x06000F05 RID: 3845 RVA: 0x0000A610 File Offset: 0x00008810
		public void SetUndergroundTime(int ms)
		{
			this.int_20 = ms;
		}

		// Token: 0x06000F06 RID: 3846 RVA: 0x0000A619 File Offset: 0x00008819
		public int GetUndergroundTime()
		{
			return this.int_20;
		}

		// Token: 0x06000F07 RID: 3847 RVA: 0x0000A621 File Offset: 0x00008821
		public int GetAmmoCount()
		{
			return this.int_14;
		}

		// Token: 0x06000F08 RID: 3848 RVA: 0x0000A629 File Offset: 0x00008829
		public bool UseAmmo()
		{
			return this.logicAttackerItemData_0.GetAmmoCount() > 0;
		}

		// Token: 0x06000F09 RID: 3849 RVA: 0x0003C03C File Offset: 0x0003A23C
		public void LoadAmmo()
		{
			int ammoCount = this.logicAttackerItemData_0.GetAmmoCount();
			if (ammoCount > 0)
			{
				this.int_14 = ammoCount;
			}
		}

		// Token: 0x06000F0A RID: 3850 RVA: 0x0000A639 File Offset: 0x00008839
		public void RemoveAmmo()
		{
			this.int_14 = 0;
		}

		// Token: 0x06000F0B RID: 3851 RVA: 0x0003C060 File Offset: 0x0003A260
		public void ToggleAttackMode(int layout, bool draft)
		{
			if (this.bool_2)
			{
				bool[] array = this.bool_16;
				if (draft)
				{
					array = this.bool_17;
				}
				bool[] array2 = array;
				array2[layout] = !array2[layout];
			}
		}

		// Token: 0x06000F0C RID: 3852 RVA: 0x0003C094 File Offset: 0x0003A294
		public void ToggleAimAngle(int count, int layout, bool draft)
		{
			if (this.logicAttackerItemData_0.GetTargetingConeAngle() != 0)
			{
				int[] array = this.int_12;
				if (draft)
				{
					array = this.int_13;
				}
				int num = array[layout] + count;
				if (num >= 360)
				{
					num -= 360;
				}
				if (num < 0)
				{
					num += 360;
				}
				array[layout] = num;
			}
		}

		// Token: 0x06000F0D RID: 3853 RVA: 0x0000A642 File Offset: 0x00008842
		public int GetAimAngle(int layout, bool draft)
		{
			if (this.logicAttackerItemData_0.GetTargetingConeAngle() == 0)
			{
				return 0;
			}
			if (draft)
			{
				return this.int_13[layout];
			}
			return this.int_12[layout];
		}

		// Token: 0x06000F0E RID: 3854 RVA: 0x0000A667 File Offset: 0x00008867
		public void ForceNewTarget()
		{
			if (this.logicData_0 == null || this.logicData_0.GetDataType() != LogicDataType.BUILDING_CLASS || !((LogicBuildingClassData)this.logicData_0).IsWall())
			{
				this.bool_15[0] = true;
			}
		}

		// Token: 0x06000F0F RID: 3855 RVA: 0x0003C0E8 File Offset: 0x0003A2E8
		public void UpdateSelectedTargetGroup()
		{
			if (this.m_parent.GetMovementComponent() != null)
			{
				if (this.logicVector2_3.m_x == -1 && this.logicVector2_3.m_y == -1)
				{
					this.logicVector2_3.m_x = this.m_parent.GetX();
					this.logicVector2_3.m_y = this.m_parent.GetY();
				}
				long num = 0L;
				long num2 = 0L;
				long num3 = 0L;
				for (int i = 0; i < this.logicArrayList_1.Size(); i++)
				{
					LogicGameObject logicGameObject = this.logicArrayList_1[i];
					int num4;
					if (logicGameObject.GetGameObjectType() == LogicGameObjectType.CHARACTER)
					{
						LogicCharacter logicCharacter = (LogicCharacter)logicGameObject;
						num4 = (this.bool_3 ? logicCharacter.GetCharacterData().GetFriendlyGroupWeight() : logicCharacter.GetCharacterData().GetEnemyGroupWeight());
					}
					else
					{
						num4 = 1;
					}
					num2 += (long)(num4 * logicGameObject.GetMidX());
					num3 += (long)(num4 * logicGameObject.GetMidY());
					num += (long)num4;
				}
				if (num > 0L)
				{
					int x = (int)(num2 / num);
					int y = (int)(num3 / num);
					this.logicVector2_1.Set(x, y);
					this.logicVector2_2.Set(x, y);
					LogicVector2 logicVector = new LogicVector2(this.logicVector2_3.m_x - this.logicVector2_1.m_x, this.logicVector2_3.m_y - this.logicVector2_1.m_y);
					logicVector.Normalize(3072);
					this.logicVector2_2.Add(logicVector);
					this.logicVector2_2.Set((this.logicVector2_2.m_x + this.m_parent.GetMidX()) / 2, (this.logicVector2_2.m_y + this.m_parent.GetMidY()) / 2);
					if (this.bool_14)
					{
						num2 = 0L;
						num3 = 0L;
						num = 0L;
						for (int j = 0; j < this.logicArrayList_1.Size(); j++)
						{
							LogicGameObject logicGameObject2 = this.logicArrayList_1[j];
							int num5;
							if (logicGameObject2.GetGameObjectType() == LogicGameObjectType.CHARACTER)
							{
								LogicCharacter logicCharacter2 = (LogicCharacter)logicGameObject2;
								num5 = (this.bool_3 ? logicCharacter2.GetCharacterData().GetFriendlyGroupWeight() : logicCharacter2.GetCharacterData().GetEnemyGroupWeight());
							}
							else
							{
								num5 = 1;
							}
							LogicCombatComponent combatComponent = logicGameObject2.GetCombatComponent();
							if (combatComponent != null)
							{
								LogicGameObject logicGameObject3 = combatComponent.logicGameObject_2[0];
								if (logicGameObject3 != null)
								{
									logicVector.Set(logicGameObject3.GetMidX() - logicGameObject2.GetMidX(), logicGameObject3.GetMidY() - logicGameObject2.GetMidY());
									logicVector.Normalize(512);
									num2 += (long)(num5 * logicVector.m_x);
									num3 += (long)(num5 * logicVector.m_y);
									num += (long)num5;
								}
							}
						}
						if (num > 0L)
						{
							x = (int)(num2 / num);
							y = (int)(num3 / num);
							logicVector.Set(x, y);
							logicVector.Normalize(512);
							this.logicVector2_1.Substract(logicVector);
							return;
						}
					}
				}
			}
			else
			{
				int num6 = this.bool_16[this.m_parent.GetLevel().GetCurrentLayout()] ? this.logicAttackerItemData_0.GetAltAttackSpeed() : this.logicAttackerItemData_0.GetAttackSpeed();
				if (this.int_4[0] <= num6)
				{
					int midX = this.m_parent.GetMidX();
					int midY = this.m_parent.GetMidY();
					LogicGameObject logicGameObject4 = null;
					int k = 0;
					int num7 = 0;
					int num8 = 0;
					while (k < this.logicArrayList_1.Size())
					{
						LogicGameObject logicGameObject5 = this.logicArrayList_1[k];
						if (logicGameObject5.GetGameObjectType() == LogicGameObjectType.CHARACTER)
						{
							LogicCharacter logicCharacter3 = (LogicCharacter)logicGameObject5;
							int num9 = this.bool_3 ? logicCharacter3.GetCharacterData().GetFriendlyGroupWeight() : logicCharacter3.GetCharacterData().GetEnemyGroupWeight();
							int num10 = logicCharacter3.GetMidX() - midX;
							int num11 = logicCharacter3.GetMidY() - midY;
							int num12 = num10 * num10 + num11 * num11;
							if (num9 <= num7)
							{
								if (num12 < num8 && num9 == num7)
								{
									num8 = num12;
									logicGameObject4 = logicCharacter3;
								}
							}
							else
							{
								logicGameObject4 = logicCharacter3;
								num8 = num12;
								num7 = num9;
							}
						}
						k++;
					}
					if (logicGameObject4 != null)
					{
						this.logicGameObject_1 = logicGameObject4;
						int x2 = logicGameObject4.GetX() + (logicGameObject4.GetWidthInTiles() << 8);
						int y2 = logicGameObject4.GetY() + (logicGameObject4.GetWidthInTiles() << 8);
						this.logicVector2_1.Set(x2, y2);
						this.logicVector2_2.Set(this.m_parent.GetMidX(), this.m_parent.GetMidY());
						return;
					}
				}
				else if (this.logicGameObject_1 != null)
				{
					this.logicVector2_1.m_x = this.logicGameObject_1.GetX() + (this.logicGameObject_1.GetWidthInTiles() << 8);
					this.logicVector2_1.m_y = this.logicGameObject_1.GetY() + (this.logicGameObject_1.GetWidthInTiles() << 8);
				}
			}
		}

		// Token: 0x06000F10 RID: 3856 RVA: 0x0000A69A File Offset: 0x0000889A
		public bool GetAttackFinished()
		{
			return this.bool_0;
		}

		// Token: 0x06000F11 RID: 3857 RVA: 0x0003C5C0 File Offset: 0x0003A7C0
		public void StopAttack()
		{
			for (int i = 0; i < this.int_23; i++)
			{
				this.int_4[i] = 0;
				if (this.int_5[i] != 0)
				{
					this.int_7[i] = this.logicAttackerItemData_0.GetAttackCooldownOverride();
				}
				this.int_5[i] = 0;
			}
			this.bool_0 = false;
			this.bool_11 = false;
		}

		// Token: 0x06000F12 RID: 3858 RVA: 0x0003C61C File Offset: 0x0003A81C
		public void RefreshTarget(bool destructTarget)
		{
			if (LogicDataTables.GetGlobals().UseStickToClosestUnitHealer())
			{
				if (this.int_15 > 0)
				{
					this.logicComponentFilter_0.PassEnemyOnly(this.m_parent);
					goto IL_A6;
				}
				if (this.logicAttackerItemData_0.GetShockwavePushStrength() == 0 && this.logicAttackerItemData_0.GetDamage2() <= 0 && this.logicGameObject_2[0] != null && this.IsTargetValid(this.logicGameObject_2[0]))
				{
					return;
				}
			}
			if (this.int_15 <= 0 && this.logicAttackerItemData_0.GetShockwavePushStrength() == 0 && this.logicAttackerItemData_0.GetDamage2() <= 0)
			{
				this.logicComponentFilter_0.PassFriendlyOnly(this.m_parent);
			}
			else
			{
				this.logicComponentFilter_0.PassEnemyOnly(this.m_parent);
			}
			IL_A6:
			if (this.bool_14)
			{
				this.RefreshTargetGroups(this.bool_4);
				return;
			}
			if (!this.logicAttackerItemData_0.GetTargetGroups())
			{
				int i = 0;
				while (i < this.int_23)
				{
					if (this.m_parent.GetGameObjectType() != LogicGameObjectType.CHARACTER)
					{
						goto IL_117;
					}
					LogicCharacter logicCharacter = (LogicCharacter)this.m_parent;
					if (logicCharacter.GetSpawnDelay() <= 0 && logicCharacter.GetSpawnIdleTime() <= 0)
					{
						goto IL_117;
					}
					this.logicGameObject_2[i] = null;
					this.logicGameObject_0 = null;
					IL_570:
					i++;
					continue;
					IL_117:
					bool flag = false;
					bool flag2 = false;
					if (LogicDataTables.GetGlobals().UseStickToClosestUnitHealer())
					{
						if (this.logicGameObject_2[i] != null && this.int_6[i] == 0 && this.m_parent.GetMovementComponent() != null && !this.IsWallBreaker())
						{
							flag = (this.int_15 > 0 || this.logicAttackerItemData_0.GetShockwavePushStrength() != 0 || this.logicAttackerItemData_0.GetDamage2() > 0);
						}
					}
					else if (this.logicGameObject_2[i] != null && this.int_6[i] == 0 && this.m_parent.GetMovementComponent() != null && !this.IsWallBreaker())
					{
						flag = true;
					}
					LogicMovementComponent movementComponent = this.m_parent.GetMovementComponent();
					if (movementComponent != null)
					{
						flag2 = movementComponent.IsInNotPassablePosition();
					}
					LogicGameObject prevTarget = this.logicGameObject_0 ?? this.logicGameObject_2[i];
					if (!flag2 && this.bool_3)
					{
						if (this.logicGameObject_2[i] != null && this.int_38 == 0 && this.int_4[i] <= 64)
						{
							this.method_0(i, true);
						}
						else if (this.logicArrayList_1.Size() != 0 && this.int_4[i] <= 64)
						{
							bool flag3 = false;
							for (int j = 0; j < this.logicArrayList_1.Size(); j++)
							{
								LogicCombatComponent combatComponent = this.logicArrayList_1[j].GetCombatComponent();
								if (combatComponent != null)
								{
									if (combatComponent.logicGameObject_2[0] != this.logicGameObject_2[i])
									{
										if (combatComponent.logicGameObject_0 != this.logicGameObject_2[i])
										{
											goto IL_26D;
										}
									}
									flag3 = true;
									IL_287:
									if (!flag3)
									{
										flag |= (this.int_4[i] <= 64);
										goto IL_29D;
									}
									goto IL_29D;
								}
								IL_26D:;
							}
							goto IL_287;
						}
					}
					IL_29D:
					if (flag || destructTarget)
					{
						this.method_0(i, true);
					}
					if (this.bool_15[i])
					{
						this.method_0(i, false);
					}
					if (this.logicGameObject_2[i] != null)
					{
						bool flag4 = true;
						if (this.IsTargetValid(this.logicGameObject_2[i]))
						{
							if (this.logicGameObject_2[i].IsStealthy())
							{
								if (this.int_15 <= 0 && this.logicAttackerItemData_0.GetShockwavePushStrength() <= 0 && this.logicAttackerItemData_0.GetDamage2() <= 0)
								{
									flag4 = false;
								}
							}
							else
							{
								flag4 = false;
							}
						}
						if ((this.logicGameObject_0 != null && !this.IsTargetValid(this.logicGameObject_0)) || flag4)
						{
							this.logicGameObject_2[i] = null;
							this.logicGameObject_0 = null;
							if (this.m_parent.GetGameObjectType() == LogicGameObjectType.CHARACTER)
							{
								LogicCharacter logicCharacter2 = (LogicCharacter)this.m_parent;
								if (logicCharacter2.GetCharacterData().IsUnderground())
								{
									this.int_8[i] = LogicDataTables.GetGlobals().GetMinerHideTime() + this.m_parent.Rand(0) % LogicDataTables.GetGlobals().GetMinerHideTimeRandom();
								}
								if ((this.int_15 > 0 || this.logicAttackerItemData_0.GetShockwavePushStrength() != 0 || this.logicAttackerItemData_0.GetDamage2() > 0) && !logicCharacter2.IsHero())
								{
									this.int_3[i] = LogicMath.Abs(this.m_parent.Rand(0)) % 800 + 200;
								}
							}
						}
					}
					if (!LogicDataTables.GetGlobals().UseStickToClosestUnitHealer())
					{
						if (this.int_8[i] != 0)
						{
							goto IL_570;
						}
						if (this.logicGameObject_2[i] != null)
						{
							if (this.int_15 > 0 || this.logicAttackerItemData_0.GetShockwavePushStrength() != 0)
							{
								goto IL_570;
							}
							if (this.logicAttackerItemData_0.GetDamage2() > 0)
							{
								goto IL_570;
							}
						}
					}
					else if (this.int_8[i] != 0 || this.logicGameObject_2[i] != null)
					{
						goto IL_570;
					}
					if (this.int_3[i] != 0)
					{
						if (!this.bool_8 || flag2)
						{
							goto IL_570;
						}
					}
					else if (flag2)
					{
						goto IL_570;
					}
					if (LogicDataTables.GetGlobals().RestartAttackTimerOnAreaDamageTurrets() || this.logicAttackerItemData_0.GetDamageRadius() == 0 || movementComponent != null)
					{
						this.int_4[i] = 0;
						if (this.int_5[i] != 0)
						{
							this.int_7[i] = this.logicAttackerItemData_0.GetAttackCooldownOverride();
						}
						this.int_5[i] = 0;
					}
					this.logicGameObject_0 = null;
					this.SearchTarget(i, prevTarget);
					if (this.logicGameObject_2[i] != null)
					{
						if (this.IsTargetValid(this.logicGameObject_2[i]))
						{
							if (movementComponent != null)
							{
								movementComponent.NewTargetFound();
							}
							this.int_28++;
						}
						else
						{
							this.logicGameObject_2[i] = null;
						}
					}
					if (movementComponent != null && this.logicGameObject_2[0] == null)
					{
						movementComponent.NoTargetFound();
					}
					if (this.logicGameObject_2[0] == null)
					{
						this.int_4[i] = 0;
						if (this.int_5[i] != 0)
						{
							this.int_7[i] = this.logicAttackerItemData_0.GetAttackCooldownOverride();
						}
						this.int_5[i] = 0;
					}
					this.int_3[i] = 500;
					goto IL_570;
				}
				return;
			}
			if (this.int_5[0] == 0 && ((this.logicArrayList_1.Size() <= 0 && this.int_7[0] <= 0 && this.int_3[0] == 0) || this.bool_15[0]))
			{
				this.RefreshTargetGroups(this.int_15 <= 0 && this.logicAttackerItemData_0.GetShockwavePushStrength() == 0 && this.logicAttackerItemData_0.GetDamage2() <= 0);
				this.bool_15[0] = false;
				this.int_3[0] = 500;
				this.int_4[0] = 0;
				this.bool_0 = false;
				if (this.int_5[0] != 0)
				{
					this.int_7[0] = this.logicAttackerItemData_0.GetAttackCooldownOverride();
				}
				this.int_5[0] = 0;
			}
		}

		// Token: 0x06000F13 RID: 3859 RVA: 0x0003CC64 File Offset: 0x0003AE64
		private void method_0(int int_39, bool bool_18)
		{
			if (bool_18)
			{
				this.bool_15[int_39] = true;
			}
			this.bool_15[int_39] = false;
			this.logicGameObject_2[int_39] = null;
			this.logicGameObject_0 = null;
			this.logicGameObject_1 = null;
			if (bool_18)
			{
				this.int_3[int_39] = 0;
				return;
			}
			this.int_3[int_39] = LogicMath.Abs(this.m_parent.Rand(0));
			this.int_3[int_39] = this.int_3[int_39] % 800;
		}

		// Token: 0x06000F14 RID: 3860 RVA: 0x0000A6A2 File Offset: 0x000088A2
		public LogicVector2 GetTargetGroupPosition()
		{
			if (this.logicArrayList_1.Size() <= 0 && this.int_5[0] <= 0)
			{
				return null;
			}
			return this.logicVector2_2;
		}

		// Token: 0x06000F15 RID: 3861 RVA: 0x0000A6C5 File Offset: 0x000088C5
		public bool GetUnk596()
		{
			return this.bool_14;
		}

		// Token: 0x06000F16 RID: 3862 RVA: 0x0003CCDC File Offset: 0x0003AEDC
		public bool RefreshTargetGroups(bool noDamage)
		{
			int num = (this.bool_14 || this.bool_3) ? this.int_16 : this.logicAttackerItemData_0.GetTargetGroupsRadius();
			int num2 = 2 * num / 5;
			if (num2 <= 0)
			{
				num2 = 1;
			}
			int num3 = 2 * num / num2;
			int num4 = 25600 / num2;
			if (25600L % (long)num2 > (long)num2 / 3L)
			{
				num4++;
			}
			int num5 = num4 * num4;
			this.logicArrayList_3.Clear();
			this.logicArrayList_3.EnsureCapacity(num5);
			for (int i = 0; i < num5; i++)
			{
				this.logicArrayList_3.Add(0);
			}
			this.logicArrayList_1.Clear();
			this.logicArrayList_1.EnsureCapacity(20);
			if (noDamage)
			{
				this.logicComponentFilter_1.PassFriendlyOnly(this.m_parent);
			}
			else
			{
				this.logicComponentFilter_1.PassEnemyOnly(this.m_parent);
			}
			this.logicArrayList_2.Clear();
			this.m_parent.GetGameObjectManager().GetGameObjects(this.logicArrayList_2, this.logicComponentFilter_1);
			int num6 = 0;
			int num7 = this.logicAttackerItemData_0.GetTargetGroupsRange() * this.logicAttackerItemData_0.GetTargetGroupsRange();
			if (this.logicArrayList_2.Size() <= 0)
			{
				return false;
			}
			for (int j = 0; j < this.logicArrayList_2.Size(); j++)
			{
				LogicGameObject logicGameObject = this.logicArrayList_2[j];
				if (logicGameObject != this.m_parent && !logicGameObject.IsHidden() && (!logicGameObject.IsStealthy() || noDamage) && logicGameObject.IsAlive() && this.CanAttackHeightCheck(logicGameObject))
				{
					if (noDamage)
					{
						LogicCombatComponent combatComponent = logicGameObject.GetCombatComponent();
						if (combatComponent != null && combatComponent.int_15 <= 0 && combatComponent.logicAttackerItemData_0.GetShockwavePushStrength() == 0 && combatComponent.logicAttackerItemData_0.GetDamage2() <= 0)
						{
							goto IL_2CA;
						}
					}
					int num8 = 1;
					if (logicGameObject.GetGameObjectType() == LogicGameObjectType.CHARACTER)
					{
						LogicCharacter logicCharacter = (LogicCharacter)logicGameObject;
						if (logicCharacter.GetSpawnDelay() > 0 || logicCharacter.GetSpawnIdleTime() > 0 || logicCharacter.GetChildTroops() != null)
						{
							goto IL_2CA;
						}
						num8 = (this.bool_3 ? logicCharacter.GetCharacterData().GetFriendlyGroupWeight() : logicCharacter.GetCharacterData().GetEnemyGroupWeight());
					}
					if (this.m_parent.GetMovementComponent() != null || this.IsInRange(logicGameObject))
					{
						int midX = logicGameObject.GetMidX();
						int midY = logicGameObject.GetMidY();
						if ((midX | midY) >= 0)
						{
							if (num7 != 0)
							{
								int midX2 = this.m_parent.GetMidX();
								int midY2 = this.m_parent.GetMidY();
								int num9 = midX2 - midX;
								int num10 = midY2 - midY;
								if (num9 * num9 + num10 * num10 > num7)
								{
									goto IL_2CA;
								}
							}
							int num11 = midX / num2;
							int num12 = midY / num2;
							if (num11 < num4 && num12 < num4)
							{
								int index = num11 + num4 * num12;
								int num13 = this.logicArrayList_3[index] + num8;
								this.logicArrayList_3[index] = num13;
								if (num13 > num6)
								{
									num6 = num13;
								}
							}
						}
					}
				}
				IL_2CA:;
			}
			if (num6 == 0)
			{
				return false;
			}
			int num14 = num3 * num2 / -2;
			int num15 = num14 + (num2 >> 1);
			if (this.logicArrayList_5.Size() == 0)
			{
				this.logicArrayList_5.EnsureCapacity(num3 * num3);
				if (this.m_parent.GetMovementComponent() != null)
				{
					int k = 0;
					int num16 = 0;
					while (k < num3)
					{
						int num17 = num15 + num2 * k;
						int num18 = num17 * num17;
						int l = 0;
						int num19 = num15;
						while (l < num3)
						{
							int num20 = LogicMath.Sqrt(num18 + num19 * num19);
							int num21 = LogicMath.Clamp(num - num20, -(num2 >> 1), num2 >> 1);
							this.logicArrayList_5.Add(num16 + l, 100 * ((num2 >> 1) + num21) / (num2 & 2147483646));
							num19 += num2;
							l++;
						}
						num16 += num3;
						k++;
					}
				}
				else
				{
					int m = 0;
					int num22 = 0;
					while (m < num3)
					{
						int num23 = num15 + m * num2;
						int num24 = num23;
						if (num23 != 0)
						{
							num24 = num23 - (num2 >> 1);
						}
						if (num23 < 0)
						{
							num24 = num23 + (num2 >> 1);
						}
						int num25 = num24 * num24;
						int n = 0;
						int num26 = num14;
						while (n < num3)
						{
							int num27 = num26 + (num2 >> 1);
							if (num27 < 0)
							{
								num27 = 2 * (num2 >> 1) + num26;
							}
							else if (num27 != 0)
							{
								num27 = num26;
							}
							int num28 = num - LogicMath.Sqrt(num25 + num27 * num27);
							if (num28 < 0)
							{
								num28 = 0;
							}
							this.logicArrayList_5.Add(num22 + n, 100 * num28 / num);
							num26 += num2;
							n++;
						}
						num22 += num3;
						m++;
					}
				}
			}
			int num29 = 0;
			int num30 = 0;
			int num31 = num4 - num3;
			long num32 = 0L;
			for (int num33 = 0; num33 <= num31; num33++)
			{
				int num34 = num14 - num33 * num2;
				for (int num35 = 0; num35 <= num31; num35++)
				{
					long num36 = 0L;
					long num37 = 0L;
					int num38 = 0;
					int num39 = 0;
					while (num38 < num3)
					{
						int num40 = num35 + (num33 + num38) * num4;
						for (int num41 = 0; num41 < num3; num41++)
						{
							int num42 = this.logicArrayList_3[num40 + num41];
							int num43 = this.logicArrayList_5[num39 + num41];
							num37 += (long)(num42 * num43);
							num36 += (long)num42;
						}
						num39 += num3;
						num38++;
					}
					if (num36 >= (long)this.logicAttackerItemData_0.GetTargetGroupsMinWeight())
					{
						if (num32 < num37 * 1000L)
						{
							int midX3 = this.m_parent.GetMidX();
							int midY3 = this.m_parent.GetMidY();
							int num44 = num14 - num35 * num2;
							int num45 = LogicMath.Sqrt((num44 + midX3) * (num44 + midX3) + (num34 + midY3) * (num34 + midY3)) >> 8;
							int num46 = LogicMath.Sqrt(20000);
							uint num47 = (uint)((long)(1000 * (num46 - num45) / num46 * (1000 * (num46 - num45) / num46)) / 1000L);
							num37 *= (long)((ulong)num47);
							if (num37 < 1L)
							{
								num37 = 1L;
							}
						}
						if (num32 < num37)
						{
							num32 = num37;
							num29 = num35;
							num30 = num33;
						}
					}
				}
			}
			int num48 = num29 * num2;
			int num49 = num29 * num2 + num3 * num2;
			int num50 = num30 * num2;
			int num51 = num30 * num2 + num3 * num2;
			int num52 = 0;
			for (int num53 = 0; num53 < this.logicArrayList_2.Size(); num53++)
			{
				LogicGameObject logicGameObject2 = this.logicArrayList_2[num53];
				if (logicGameObject2 != this.m_parent && !logicGameObject2.IsHidden() && (!logicGameObject2.IsStealthy() || noDamage) && logicGameObject2.IsAlive() && this.CanAttackHeightCheck(logicGameObject2))
				{
					if (noDamage)
					{
						LogicCombatComponent combatComponent2 = logicGameObject2.GetCombatComponent();
						if (combatComponent2 != null && combatComponent2.int_15 <= 0 && combatComponent2.logicAttackerItemData_0.GetShockwavePushStrength() <= 0 && combatComponent2.logicAttackerItemData_0.GetDamage2() <= 0)
						{
							goto IL_76B;
						}
					}
					int num54 = 1;
					if (logicGameObject2.GetGameObjectType() == LogicGameObjectType.CHARACTER)
					{
						LogicCharacter logicCharacter2 = (LogicCharacter)logicGameObject2;
						if (logicCharacter2.GetSpawnDelay() > 0 || logicCharacter2.GetSpawnIdleTime() > 0 || logicCharacter2.GetChildTroops() != null)
						{
							goto IL_76B;
						}
						num54 = (this.bool_3 ? logicCharacter2.GetCharacterData().GetFriendlyGroupWeight() : logicCharacter2.GetCharacterData().GetEnemyGroupWeight());
					}
					int midX4 = logicGameObject2.GetMidX();
					int midY4 = logicGameObject2.GetMidY();
					if (midX4 >= num48 && midX4 <= num49 && midY4 >= num50 && midY4 <= num51 && (this.m_parent.GetMovementComponent() != null || this.IsInRange(logicGameObject2)))
					{
						this.logicArrayList_1.Add(logicGameObject2);
						num52 += num54;
					}
				}
				IL_76B:;
			}
			if (num52 < this.logicAttackerItemData_0.GetTargetGroupsMinWeight())
			{
				this.logicArrayList_1.Clear();
				return false;
			}
			this.UpdateSelectedTargetGroup();
			return this.logicArrayList_1.Size() != 0;
		}

		// Token: 0x06000F17 RID: 3863 RVA: 0x0003D49C File Offset: 0x0003B69C
		public LogicGameObject SelectWall()
		{
			if (this.m_parent.GetHitpointComponent().GetTeam() != 1)
			{
				LogicArrayList<LogicGameObject> gameObjects = this.m_parent.GetGameObjectManager().GetGameObjects(LogicGameObjectType.BUILDING);
				LogicGameObject logicGameObject = this.GetBestWallToBreak(gameObjects);
				if (logicGameObject == null)
				{
					LogicGameObject logicGameObject2 = null;
					int i = 0;
					int num = 0;
					while (i < gameObjects.Size())
					{
						LogicBuilding logicBuilding = (LogicBuilding)gameObjects[i];
						if (logicBuilding.IsWall())
						{
							this.logicVector2_0.m_x = logicBuilding.GetMidX() - this.m_parent.GetMidX();
							this.logicVector2_0.m_y = logicBuilding.GetMidY() - this.m_parent.GetMidY();
							int lengthSquared = this.logicVector2_0.GetLengthSquared();
							if ((logicGameObject2 == null || lengthSquared < num) && logicBuilding.IsConnectedWall())
							{
								num = lengthSquared;
								logicGameObject2 = logicBuilding;
							}
						}
						i++;
					}
					logicGameObject = logicGameObject2;
				}
				if (logicGameObject != null)
				{
					if (logicGameObject.IsAlive())
					{
						return logicGameObject;
					}
					int tileX = logicGameObject.GetTileX();
					int tileY = logicGameObject.GetTileY();
					int num2 = tileX - this.m_parent.GetTileX();
					int num3 = tileY - this.m_parent.GetTileY();
					if ((num2 | num3) != 0)
					{
						this.logicVector2_0.m_x = num2;
						this.logicVector2_0.m_y = num3;
						this.logicVector2_0.Normalize(10);
						return this.FindNextWallInLine(tileX, tileY, tileX + this.logicVector2_0.m_x, tileY + this.logicVector2_0.m_y);
					}
				}
			}
			return null;
		}

		// Token: 0x06000F18 RID: 3864 RVA: 0x0003D60C File Offset: 0x0003B80C
		public bool IsWall(LogicGameObject gameObject)
		{
			if (gameObject != null)
			{
				LogicGameObjectData data = gameObject.GetData();
				if (data.GetDataType() == LogicDataType.BUILDING)
				{
					return ((LogicBuildingData)data).IsWall();
				}
			}
			return false;
		}

		// Token: 0x06000F19 RID: 3865 RVA: 0x0000A6CD File Offset: 0x000088CD
		public bool IsHealer()
		{
			return this.int_15 >> 31 != 0;
		}

		// Token: 0x06000F1A RID: 3866 RVA: 0x0003D638 File Offset: 0x0003B838
		public bool CanAttackHeightCheck(LogicGameObject gameObject)
		{
			int currentLayout = this.m_parent.GetLevel().GetCurrentLayout();
			bool flag = gameObject.IsFlying();
			return (this.bool_16[currentLayout] && this.bool_5) || ((this.GetTrackAirTargets(currentLayout, false) || !flag) && (flag || this.GetTrackGroundTargets(currentLayout, false)));
		}

		// Token: 0x06000F1B RID: 3867 RVA: 0x0000A6DB File Offset: 0x000088DB
		public bool IsAlerted()
		{
			return this.int_37 > 0;
		}

		// Token: 0x06000F1C RID: 3868 RVA: 0x0003D690 File Offset: 0x0003B890
		public void StartAllianceAlert(LogicGameObject gameObject, LogicGameObject target)
		{
			if (this.logicData_0 == null && (!LogicDataTables.GetGlobals().UseStickToClosestUnitHealer() || this.int_15 > 0 || this.logicAttackerItemData_0.GetShockwavePushStrength() != 0 || this.logicAttackerItemData_0.GetDamage2() > 0) && (this.m_parent == target || this.int_37 <= 0) && (!LogicDataTables.GetGlobals().IgnoreAllianceAlertForNonValidTargets() || (this.IsTargetValid(gameObject) && this.CanAttackHeightCheck(gameObject))))
			{
				for (int i = 0; i < this.int_23; i++)
				{
					LogicGameObject logicGameObject = this.logicGameObject_2[i];
					if (logicGameObject != null && logicGameObject.GetGameObjectType() == LogicGameObjectType.CHARACTER)
					{
						return;
					}
				}
				this.int_37 = 1000;
				this.bool_10 = true;
			}
		}

		// Token: 0x06000F1D RID: 3869 RVA: 0x0003D748 File Offset: 0x0003B948
		public void ObstacleToDestroy(LogicGameObject obstacle)
		{
			if (this.logicGameObject_2[0] == null || !this.IsInRange(this.logicGameObject_2[0]) || !this.IsInLine(this.logicGameObject_2[0]))
			{
				if (this.IsTargetValid(obstacle))
				{
					if (LogicDataTables.GetGlobals().RememberOriginalTarget() && this.logicGameObject_0 == null)
					{
						this.logicGameObject_0 = this.logicGameObject_2[0];
					}
					this.logicGameObject_2[0] = obstacle;
					if (obstacle.GetGameObjectType() == LogicGameObjectType.BUILDING)
					{
						((LogicBuilding)obstacle).StartSelectedWallTime();
						return;
					}
				}
				else
				{
					this.int_3[0] = 2500;
					this.logicGameObject_2[0] = null;
				}
			}
		}

		// Token: 0x06000F1E RID: 3870 RVA: 0x0003D7E0 File Offset: 0x0003B9E0
		public LogicGameObject GetBestWallToBreak(LogicArrayList<LogicGameObject> gameObjects)
		{
			if (LogicDataTables.GetGlobals().GetWallBreakerSmartCountLimit() != 0 && this.int_28 < LogicDataTables.GetGlobals().GetWallBreakerSmartRetargetLimit())
			{
				LogicArrayList<LogicGameObject> gameObjects2 = this.m_parent.GetGameObjectManager().GetGameObjects(LogicGameObjectType.CHARACTER);
				int num = 0;
				for (int i = 0; i < gameObjects2.Size(); i++)
				{
					LogicCharacter logicCharacter = (LogicCharacter)gameObjects2[i];
					LogicCombatComponent combatComponent = logicCharacter.GetCombatComponent();
					if (combatComponent != null && combatComponent.logicData_0 != null && combatComponent.logicData_0.GetDataType() == LogicDataType.BUILDING_CLASS && ((LogicBuildingClassData)combatComponent.logicData_0).IsWall() && logicCharacter.IsAlive())
					{
						num++;
					}
				}
				if (num <= LogicDataTables.GetGlobals().GetWallBreakerSmartCountLimit())
				{
					int wallBreakerSmartRadius = LogicDataTables.GetGlobals().GetWallBreakerSmartRadius();
					int num2 = wallBreakerSmartRadius * wallBreakerSmartRadius;
					LogicArrayList<int> logicArrayList = new LogicArrayList<int>(50);
					LogicArrayList<int> logicArrayList2 = new LogicArrayList<int>(50);
					for (int j = 0; j < gameObjects.Size(); j++)
					{
						LogicGameObject logicGameObject = gameObjects[j];
						if (!logicGameObject.IsWall() && !logicGameObject.IsHidden() && logicGameObject.IsAlive())
						{
							this.logicVector2_0.m_x = logicGameObject.GetMidX() - this.m_parent.GetMidX();
							this.logicVector2_0.m_y = logicGameObject.GetMidY() - this.m_parent.GetMidY();
							int lengthSquared = this.logicVector2_0.GetLengthSquared();
							if (lengthSquared <= num2 && logicGameObject.GetGameObjectType() == LogicGameObjectType.BUILDING)
							{
								if (logicArrayList.Size() >= 50)
								{
									logicArrayList.Remove(49);
									logicArrayList2.Remove(49);
								}
								bool flag = false;
								int k = 0;
								while (k < logicArrayList.Size())
								{
									if (logicArrayList[k] <= lengthSquared)
									{
										k++;
									}
									else
									{
										logicArrayList.Add(k, lengthSquared);
										logicArrayList2.Add(k, j);
										flag = true;
										IL_1B5:
										if (!flag)
										{
											logicArrayList.Add(lengthSquared);
											logicArrayList2.Add(j);
											goto IL_1CB;
										}
										goto IL_1CB;
									}
								}
								goto IL_1B5;
							}
						}
						IL_1CB:;
					}
					if (LogicDataTables.GetGlobals().WallBreakerUseRooms())
					{
						LogicTileMap tileMap = this.m_parent.GetLevel().GetTileMap();
						LogicTile tile = tileMap.GetTile(this.m_parent.GetTileX(), this.m_parent.GetTileY());
						int num3 = (int)((tile != null) ? tile.GetRoomIdx() : -1);
						for (int l = 0; l < logicArrayList2.Size(); l++)
						{
							LogicGameObject logicGameObject2 = gameObjects[logicArrayList2[l]];
							if (logicGameObject2.GetGameObjectType() == LogicGameObjectType.BUILDING)
							{
								LogicTile tile2 = tileMap.GetTile(logicGameObject2.GetTileX(), logicGameObject2.GetTileY());
								if ((int)((tile2 != null) ? tile2.GetRoomIdx() : -1) != num3)
								{
									LogicMovementComponent movementComponent = this.m_parent.GetMovementComponent();
									LogicMovementSystem movementSystem = movementComponent.GetMovementSystem();
									movementComponent.MoveTo(logicGameObject2);
									LogicGameObject wall = movementSystem.GetWall();
									if (wall != null)
									{
										return wall;
									}
								}
							}
						}
					}
					else
					{
						for (int m = 0; m < logicArrayList2.Size(); m++)
						{
							LogicGameObject logicGameObject3 = gameObjects[logicArrayList2[m]];
							if (logicGameObject3.GetGameObjectType() == LogicGameObjectType.BUILDING)
							{
								LogicMovementComponent movementComponent2 = this.m_parent.GetMovementComponent();
								LogicMovementSystem movementSystem2 = movementComponent2.GetMovementSystem();
								movementComponent2.MoveTo(logicGameObject3);
								LogicGameObject wall2 = movementSystem2.GetWall();
								if (wall2 != null)
								{
									return wall2;
								}
							}
						}
					}
				}
			}
			return null;
		}

		// Token: 0x06000F1F RID: 3871 RVA: 0x0003DAF8 File Offset: 0x0003BCF8
		public LogicGameObject FindNextWallInLine(int startX, int startY, int endX, int endY)
		{
			int num = (endX > startX) ? 1 : -1;
			int num2 = (endY > startY) ? 1 : -1;
			int num3 = LogicMath.Abs(endX - startX);
			int num4 = LogicMath.Abs(endY - startY);
			int num5 = num3 - num4;
			int num6 = num3 * 2;
			int num7 = num4 * 2;
			LogicTileMap tileMap = this.m_parent.GetLevel().GetTileMap();
			int i = num3 + num4;
			int num8 = startX;
			int num9 = startY;
			while (i >= 0)
			{
				LogicTile tile = tileMap.GetTile(num8, num9);
				if (tile == null)
				{
					IL_C1:
					return null;
				}
				for (int j = 0; j < tile.GetGameObjectCount(); j++)
				{
					LogicGameObject gameObject = tile.GetGameObject(j);
					if (gameObject.IsWall() && gameObject.IsAlive())
					{
						return gameObject;
					}
				}
				if (num5 > 0)
				{
					num5 -= num7;
					num8 += num;
				}
				else
				{
					num5 += num6;
					num9 += num2;
				}
				i--;
			}
			goto IL_C1;
		}

		// Token: 0x06000F20 RID: 3872 RVA: 0x0003DBC8 File Offset: 0x0003BDC8
		public void Boost(int damage, int attackSpeedBoost, int time)
		{
			if (damage < 0)
			{
				this.int_34 = LogicMath.Min(damage, this.int_34);
				this.int_33 = time;
			}
			else
			{
				int num = (this.int_1[0] != 0) ? 1 : 0;
				this.int_2[num] = LogicMath.Max(damage, this.int_2[num]);
				this.int_1[num] = time;
			}
			this.int_35 = attackSpeedBoost;
			this.int_36 = time;
		}

		// Token: 0x06000F21 RID: 3873 RVA: 0x0000A6E6 File Offset: 0x000088E6
		public bool IsBoosted()
		{
			return this.int_1[0] > 0;
		}

		// Token: 0x06000F22 RID: 3874 RVA: 0x0000A6F3 File Offset: 0x000088F3
		public bool IsSlowed()
		{
			return this.int_33 > 0;
		}

		// Token: 0x06000F23 RID: 3875 RVA: 0x0003DC30 File Offset: 0x0003BE30
		public override void SubTick()
		{
			if (this.int_22 <= 0)
			{
				if (this.logicAttackerItemData_0.GetTargetGroups() || this.bool_14 || this.bool_3)
				{
					LogicVector2 logicVector = new LogicVector2();
					logicVector.Set(this.logicVector2_1.m_x, this.logicVector2_1.m_y);
					this.UpdateSelectedTargetGroup();
					if (this.logicArrayList_1.Size() > 0)
					{
						int num = (this.bool_14 || this.bool_3) ? this.int_16 : this.logicAttackerItemData_0.GetTargetGroupsRadius();
						if (this.m_parent.GetMovementComponent() == null)
						{
							LogicVector2 logicVector2 = new LogicVector2();
							logicVector2.Set(this.logicVector2_1.m_x, this.logicVector2_1.m_y);
							logicVector2.Substract(logicVector);
							int num2 = logicVector2.Normalize(30);
							if (num2 <= 2 * num && num2 > 30)
							{
								this.logicVector2_1.Set(logicVector.m_x, logicVector.m_y);
								this.logicVector2_1.Add(logicVector2);
							}
						}
						if (this.bool_14)
						{
							LogicMovementComponent movementComponent = this.m_parent.GetMovementComponent();
							if ((movementComponent == null || !movementComponent.IsInNotPassablePosition()) && movementComponent != null)
							{
								LogicMovementSystem movementSystem = movementComponent.GetMovementSystem();
								if (new LogicVector2(movementSystem.GetPathEndPosition().m_x, movementSystem.GetPathEndPosition().m_y).GetDistanceSquaredTo(this.logicVector2_1.m_x, this.logicVector2_1.m_y) > 65536 && this.m_parent.GetLevel().GetTileMap().GetNearestPassablePosition(this.logicVector2_1.m_x, this.logicVector2_1.m_y, this.logicVector2_1, 512))
								{
									movementComponent.MoveTo(this.logicVector2_1.m_x, this.logicVector2_1.m_y);
									return;
								}
							}
						}
					}
				}
			}
			else
			{
				this.int_22 -= 16;
			}
		}

		// Token: 0x06000F24 RID: 3876 RVA: 0x0003DE10 File Offset: 0x0003C010
		public override void Tick()
		{
			if (this.int_22 <= 0)
			{
				if (this.bool_5)
				{
					this.int_23 = (this.bool_16[this.m_parent.GetLevel().GetCurrentLayout()] ? this.logicAttackerItemData_0.GetAltNumMultiTargets() : 1);
				}
				if (!this.m_parent.IsAlive() || this.m_parent.IsHidden() || (this.logicAttackerItemData_0.GetAmmoCount() > 0 && this.int_14 == 0) || this.m_parent.IsFrozen())
				{
					for (int i = 0; i < this.int_23; i++)
					{
						this.logicGameObject_2[i] = null;
						this.int_4[i] = 0;
						this.int_5[i] = 0;
						this.int_9[i] = 0;
						if (this.m_parent.GetGameObjectType() == LogicGameObjectType.CHARACTER && ((LogicCharacter)this.m_parent).GetCharacterData().IsUnderground())
						{
							this.int_8[i] = LogicDataTables.GetGlobals().GetMinerHideTime() + this.m_parent.Rand(0) % LogicDataTables.GetGlobals().GetMinerHideTimeRandom();
						}
					}
					this.logicGameObject_0 = null;
					this.int_17 = this.logicAttackerItemData_0.GetPrepareSpeed();
					this.logicArrayList_1.Clear();
					this.logicVector2_1.Set(0, 0);
					this.logicVector2_2.Set(0, 0);
					this.logicGameObject_1 = null;
					return;
				}
				if (this.m_parent.GetGameObjectType() == LogicGameObjectType.BUILDING && this.logicAttackerItemData_0.GetWakeUpSpace() > 0)
				{
					this.int_32 = this.m_parent.GetLevel().GetBattleLog().GetDeployedHousingSpace();
					if (this.int_32 < this.logicAttackerItemData_0.GetWakeUpSpace())
					{
						return;
					}
					this.logicAttackerItemData_0.GetWakeUpSpace();
					this.int_19 = LogicMath.Max(this.int_19 - 64, 0);
					if (this.int_19 > 0)
					{
						return;
					}
				}
				this.RefreshTarget(false);
				int num = ((this.int_35 << 6) + 6400) / 100;
				this.int_25 += 64;
				this.int_37 = LogicMath.Max(this.int_37 - 64, 0);
				this.int_27 = LogicMath.Max(this.int_27 - num, 0);
				this.int_38 = LogicMath.Max(this.int_38 - 64, 0);
				int num2 = 0;
				for (int j = 0; j < this.int_23; j++)
				{
					this.int_6[j] = LogicMath.Max(this.int_6[j] - 64, 0);
					this.int_3[j] = LogicMath.Max(this.int_3[j] - 64, 0);
					this.int_7[j] = LogicMath.Max(this.int_7[j] - num, 0);
					this.int_9[j] = LogicMath.Max(this.int_9[j] - num, 0);
					if (this.logicGameObject_2[j] != null)
					{
						num2++;
					}
				}
				for (int k = 0; k < this.logicArrayList_1.Size(); k++)
				{
					LogicGameObject logicGameObject = this.logicArrayList_1[k];
					if (!logicGameObject.IsAlive() || logicGameObject.IsHidden() || ((this.int_15 > 0 || this.logicAttackerItemData_0.GetShockwavePushStrength() != 0 || this.logicAttackerItemData_0.GetDamage2() > 0) && !this.bool_3 && logicGameObject.IsStealthy()) || (this.m_parent.GetMovementComponent() == null && !this.IsInRange(logicGameObject)))
					{
						this.logicArrayList_1.Remove(k--);
						if (logicGameObject == this.logicGameObject_1)
						{
							this.logicGameObject_1 = null;
						}
					}
				}
				if ((num2 == 0 && !this.logicAttackerItemData_0.GetTargetGroups()) || (this.logicAttackerItemData_0.GetTargetGroups() && this.logicArrayList_1.Size() <= 0 && this.int_5[0] <= 0))
				{
					this.int_17 = LogicMath.Min(this.int_17 + 64, this.logicAttackerItemData_0.GetPrepareSpeed());
				}
				else
				{
					this.int_17 = LogicMath.Max(this.int_17 - 64, 0);
				}
				bool flag = this.bool_0;
				this.bool_0 = false;
				if (this.logicAttackerItemData_0.GetAmmoCount() > 0 && this.int_30 > 0)
				{
					this.int_30--;
				}
				bool flag2 = true;
				for (int l = 0; l < this.int_23; l++)
				{
					if (this.int_8[l] > 0)
					{
						this.int_8[l] -= 64;
						if (this.int_8[l] < 0)
						{
							this.int_8[l] = 0;
						}
					}
					if (this.logicGameObject_2[l] != null)
					{
						bool flag3 = false;
						LogicGameObject logicGameObject2 = this.logicGameObject_2[l];
						if (this.IsInRange(logicGameObject2))
						{
							flag3 = true;
							if (this.m_parent.GetGameObjectType() == LogicGameObjectType.BUILDING)
							{
								flag3 = ((LogicBuilding)this.m_parent).IsValidTarget(logicGameObject2);
							}
						}
						if (this.bool_1 && !logicGameObject2.IsWall() && logicGameObject2.GetGameObjectType() == LogicGameObjectType.BUILDING)
						{
							LogicMovementComponent movementComponent = this.m_parent.GetMovementComponent();
							if (movementComponent != null)
							{
								flag3 = (movementComponent.GetMovementSystem().NotMoving() && flag3);
							}
						}
						bool flag4 = false;
						if (flag3)
						{
							flag4 = this.IsInLine(logicGameObject2);
							if (!flag && flag4)
							{
								this.int_4[l] = this.logicAttackerItemData_0.GetNewTargetAttackDelay();
							}
						}
						if (!flag4 && this.int_4[l] <= 0)
						{
							this.int_4[l] = 0;
							if (this.int_5[l] != 0)
							{
								this.int_7[l] = this.logicAttackerItemData_0.GetAttackCooldownOverride();
							}
							this.int_5[l] = 0;
						}
						else
						{
							this.int_6[l] = LogicDataTables.GetGlobals().GetForgetTargetTime();
							this.bool_0 = true;
							if (this.int_17 == 0 && this.int_7[l] == 0)
							{
								this.logicAttackerItemData_0.GetPreAttackEffect();
								this.int_4[l] += num;
								int num3 = this.logicAttackerItemData_0.GetAttackSpeed();
								if (this.bool_16[this.m_parent.GetLevel().GetCurrentLayout()])
								{
									num3 = this.logicAttackerItemData_0.GetAltAttackSpeed();
								}
								if (this.int_4[l] < num3)
								{
									flag2 = false;
								}
								else
								{
									int num4 = this.logicAttackerItemData_0.GetBurstCount();
									int num5 = this.logicAttackerItemData_0.GetBurstDelay();
									if (this.bool_16[this.m_parent.GetLevel().GetCurrentLayout()])
									{
										num4 = this.logicAttackerItemData_0.GetAltBurstCount();
										num5 = this.logicAttackerItemData_0.GetAltBurstDelay();
									}
									if (num4 > 0 && num5 > 0)
									{
										this.int_4[l] = num3;
										int num6 = (num5 + this.int_5[l] - 1) / num5 % (num4 + 1);
										this.int_5[l] += num;
										int num7 = (num5 + this.int_5[l] - 1) / num5 % (num4 + 1);
										if (num7 <= num6)
										{
											goto IL_8E6;
										}
										this.Hit(l);
										if (num7 != num4)
										{
											goto IL_8E6;
										}
									}
									else
									{
										this.Hit(l);
									}
									this.int_7[l] = this.logicAttackerItemData_0.GetAttackCooldownOverride();
									this.int_4[l] = (flag4 ? LogicMath.Min(this.int_4[l] - num3, num3) : 0);
								}
							}
							else
							{
								flag2 = false;
							}
						}
					}
					else if (!this.logicAttackerItemData_0.GetTargetGroups())
					{
						this.int_4[l] = 0;
						if (this.int_5[l] != 0)
						{
							this.int_7[l] = this.logicAttackerItemData_0.GetAttackCooldownOverride();
						}
						this.int_5[l] = 0;
					}
					else if (this.logicArrayList_1.Size() <= 0 && this.int_5[0] <= 0 && this.int_4[l] < this.logicAttackerItemData_0.GetAttackSpeed())
					{
						this.int_4[l] = 0;
						if (this.int_5[l] != 0)
						{
							this.int_7[l] = this.logicAttackerItemData_0.GetAttackCooldownOverride();
						}
						this.int_5[l] = 0;
						this.logicVector2_1.Set(-1, -1);
						this.logicVector2_2.Set(-1, -1);
					}
					else
					{
						this.int_6[l] = LogicDataTables.GetGlobals().GetForgetTargetTime();
						this.bool_0 = true;
						if (this.int_17 == 0 && this.int_7[l] == 0)
						{
							if (this.logicAttackerItemData_0.GetPreAttackEffect() == null)
							{
							}
							this.int_4[l] += num;
							if (this.int_4[l] < this.logicAttackerItemData_0.GetAttackSpeed())
							{
								flag2 = false;
							}
							else
							{
								int num8 = this.logicAttackerItemData_0.GetBurstCount();
								int num9 = this.logicAttackerItemData_0.GetBurstDelay();
								if (this.bool_16[this.m_parent.GetLevel().GetCurrentLayout()])
								{
									num8 = this.logicAttackerItemData_0.GetAltBurstCount();
									num9 = this.logicAttackerItemData_0.GetAltBurstDelay();
								}
								if (num8 <= 0)
								{
									this.Hit(l);
								}
								else
								{
									int num10 = this.logicAttackerItemData_0.GetAttackSpeed();
									if (this.bool_16[this.m_parent.GetLevel().GetCurrentLayout()])
									{
										num10 = this.logicAttackerItemData_0.GetAltAttackSpeed();
									}
									this.int_4[l] = num10;
									int num11 = (num9 + this.int_5[l] - 1) / num9;
									this.int_5[l] += num;
									int num12 = (num9 + this.int_5[l] - 1) / num9;
									if (num12 <= num11)
									{
										goto IL_8E6;
									}
									this.Hit(l);
									if (num12 != num8)
									{
										goto IL_8E6;
									}
								}
								this.int_7[l] = this.logicAttackerItemData_0.GetAttackCooldownOverride();
								int num13 = this.logicAttackerItemData_0.GetAttackSpeed();
								if (this.bool_16[this.m_parent.GetLevel().GetCurrentLayout()])
								{
									num13 = this.logicAttackerItemData_0.GetAltAttackSpeed();
								}
								this.int_4[l] = LogicMath.Min(this.int_4[l] - num13, num13);
								this.int_5[l] = 0;
								this.logicArrayList_1.Clear();
								this.logicVector2_1.Set(-1, -1);
								this.logicVector2_2.Set(-1, -1);
								this.logicGameObject_1 = null;
							}
						}
					}
					IL_8E6:
					if (this.int_9[l] == 0 && this.int_10[l] >= 0 && this.logicAttackerItemData_0.GetDamage2Radius() > 0)
					{
						int targetType = this.GetTrackAirTargets(this.m_parent.GetLevel().GetCurrentLayout(), false) ? (this.GetTrackGroundTargets(this.m_parent.GetLevel().GetCurrentLayout(), false) ? 2 : 0) : 1;
						if (this.logicAttackerItemData_0.GetDamage2Min() <= 0 || this.logicAttackerItemData_0.GetDamage2Min() == this.logicAttackerItemData_0.GetDamage2())
						{
							this.m_parent.GetLevel().AreaDamage(this.m_parent.GetGlobalID(), this.int_10[l], this.int_11[l], this.logicAttackerItemData_0.GetDamage2Radius(), this.logicAttackerItemData_0.GetDamage2(), this.logicData_0, this.int_18, null, this.m_parent.GetHitpointComponent().GetTeam(), null, targetType, 0, this.logicAttackerItemData_0.GetPushBack(), true, false, 100, 0, this.m_parent, 100, 0);
						}
					}
				}
				if (flag2 && this.bool_10)
				{
					this.logicGameObject_2[0] = null;
					this.logicGameObject_0 = null;
					this.int_3[0] = 0;
					this.bool_10 = false;
				}
				if (this.logicAttackerItemData_0.GetSummonTroop() != null && !this.logicAttackerItemData_0.GetSpawnOnAttack())
				{
					int summonCooldown = this.logicAttackerItemData_0.GetSummonCooldown();
					if (this.int_27 == 0)
					{
						this.int_27 = summonCooldown;
						this.bool_11 = false;
					}
					if (this.int_27 < summonCooldown / 8 && this.logicGameObject_2[0] != null)
					{
						if (((LogicCharacter)this.m_parent).GetSummonTroopCount() >= this.logicAttackerItemData_0.GetSummonLimit())
						{
							this.int_27 = 0;
						}
						else
						{
							this.int_3[0] = summonCooldown / 6;
							this.logicGameObject_2[0] = null;
							this.logicGameObject_0 = null;
							this.bool_11 = true;
							this.m_parent.SpawnEvent(null, 0, 0);
						}
					}
				}
				if (this.int_1[0] > 0)
				{
					this.int_1[0]--;
					if (this.int_1[0] == 0)
					{
						this.int_1[0] = this.int_1[1];
						this.int_2[0] = this.int_2[1];
						this.int_1[1] = 0;
						this.int_2[1] = 0;
					}
				}
				if (this.int_33 > 0)
				{
					this.int_33--;
					if (this.int_33 == 0)
					{
						this.int_34 = 0;
					}
				}
				if (this.int_36 > 0)
				{
					this.int_36--;
					if (this.int_36 == 0)
					{
						this.int_35 = 0;
					}
				}
				if (this.int_20 > 0)
				{
					this.int_20--;
					LogicMovementComponent movementComponent2 = this.m_parent.GetMovementComponent();
					if (movementComponent2 != null && movementComponent2.GetMovementSystem().NotMoving())
					{
						this.int_20 = 0;
						movementComponent2.CheckTriggers();
					}
				}
			}
		}

		// Token: 0x06000F25 RID: 3877 RVA: 0x0003EAC0 File Offset: 0x0003CCC0
		public void AttackedBy(LogicGameObject gameObject)
		{
			if (this.m_parent.GetHitpointComponent().GetTeam() != 1 && this.int_37 <= 0 && this.GetComponentType() == LogicComponentType.COMBAT && gameObject.GetGameObjectType() == LogicGameObjectType.CHARACTER)
			{
				LogicArrayList<LogicGameObject> gameObjects = this.m_parent.GetGameObjectManager().GetGameObjects(LogicGameObjectType.CHARACTER);
				this.logicVector2_0.m_x = this.m_parent.GetMidX();
				this.logicVector2_0.m_y = this.m_parent.GetMidY();
				int num = LogicDataTables.GetGlobals().GetAllianceAlertRadius() * LogicDataTables.GetGlobals().GetAllianceAlertRadius();
				for (int i = 0; i < gameObjects.Size(); i++)
				{
					LogicCharacter logicCharacter = (LogicCharacter)gameObjects[i];
					if (this.logicVector2_0.GetDistanceSquared(logicCharacter.GetPosition()) < num)
					{
						LogicHitpointComponent hitpointComponent = logicCharacter.GetHitpointComponent();
						if (hitpointComponent != null && hitpointComponent.GetTeam() == 0)
						{
							LogicCombatComponent combatComponent = logicCharacter.GetCombatComponent();
							if (combatComponent != null)
							{
								combatComponent.StartAllianceAlert(gameObject, this.m_parent);
							}
						}
					}
				}
			}
		}

		// Token: 0x06000F26 RID: 3878 RVA: 0x0003EBBC File Offset: 0x0003CDBC
		public void Hit(int idx)
		{
			if (this.logicAttackerItemData_0.GetAmmoCount() > 0 && this.int_14 <= 0)
			{
				return;
			}
			LogicGameObject logicGameObject = this.logicGameObject_2[idx];
			if (this.logicAttackerItemData_0.GetTargetGroups() && this.m_parent.GetMovementComponent() == null && this.logicGameObject_1 != null)
			{
				logicGameObject = this.logicGameObject_1;
			}
			if (this.bool_7)
			{
				this.m_parent.SpawnEvent(null, 0, 0);
				this.HitCompleted();
				return;
			}
			bool alt = this.bool_16[this.m_parent.GetLevel().GetCurrentLayout()];
			bool flag = logicGameObject != null && logicGameObject.IsFlying();
			int num = this.GetDamage();
			if (this.m_parent.GetGameObjectType() == LogicGameObjectType.CHARACTER)
			{
				LogicCharacter logicCharacter = (LogicCharacter)this.m_parent;
				if (logicCharacter.GetSpecialAbilityAvailable())
				{
					LogicCharacterData characterData = logicCharacter.GetCharacterData();
					if (characterData.GetSpecialAbilityType() == 6)
					{
						alt = true;
					}
					if (characterData.GetSpecialAbilityType() == 1)
					{
						num = num * characterData.GetSpecialAbilityAttribute(logicCharacter.GetUpgradeLevel()) / 100;
					}
				}
			}
			if (this.logicAttackerItemData_0.GetProjectile(alt) == null)
			{
				if (num >= 0 || !this.m_parent.IsPreventsHealing())
				{
					if (this.m_parent.GetGameObjectType() == LogicGameObjectType.BUILDING)
					{
						LogicVector2 logicVector = new LogicVector2(logicGameObject.GetMidX(), logicGameObject.GetMidY());
						if (this.m_parent.GetLevel().GetAreaShield(logicGameObject.GetMidX(), logicGameObject.GetMidY(), logicVector))
						{
							num = logicVector.m_y * num / 100;
						}
					}
					if (this.logicAttackerItemData_0.GetDamageRadius() > 0)
					{
						logicGameObject.GetListener().PlayEffect(this.logicAttackerItemData_0.GetHitEffect2());
						int midX;
						int midY;
						if (this.logicAttackerItemData_0.IsSelfAsAoeCenter())
						{
							midX = this.m_parent.GetMidX();
							midY = this.m_parent.GetMidY();
						}
						else
						{
							midX = logicGameObject.GetMidX();
							midY = logicGameObject.GetMidY();
						}
						this.m_parent.GetLevel().AreaDamage(this.m_parent.GetGlobalID(), midX, midY, this.logicAttackerItemData_0.GetDamageRadius(), num, this.logicData_0, this.int_18, null, this.m_parent.GetHitpointComponent().GetTeam(), null, flag ? 0 : 1, 0, this.logicAttackerItemData_0.GetPushBack(), true, false, 100, 0, this.m_parent, 100, 0);
					}
					else
					{
						if (LogicCombatComponent.IsPreferredTarget(this.logicData_0, logicGameObject))
						{
							num = this.int_18 * num / 100;
						}
						if (num < 0 && logicGameObject.GetData().GetDataType() == LogicDataType.HERO)
						{
							num = LogicDataTables.GetGlobals().GetHeroHealMultiplier() * num / 100;
						}
						if (this.bool_9)
						{
							LogicGameObjectData data = logicGameObject.GetData();
							if (data.GetDataType() == LogicDataType.BUILDING)
							{
								LogicBuildingData logicBuildingData = (LogicBuildingData)data;
								if (logicBuildingData.GetMaxStoredGold(0) > 0 || logicBuildingData.GetMaxStoredElixir(0) > 0 || logicBuildingData.GetMaxStoredDarkElixir(0) > 0 || logicBuildingData.IsTownHall() || logicBuildingData.IsTownHallVillage2())
								{
									num = LogicDataTables.GetGlobals().GetSkeletonSpellStorageMultipler() * num / 100;
								}
							}
						}
						LogicHitpointComponent hitpointComponent = logicGameObject.GetHitpointComponent();
						hitpointComponent.CauseDamage(num, this.m_parent.GetGlobalID(), this.m_parent);
						if (this.bool_16[this.m_parent.GetLevel().GetCurrentLayout()] && this.bool_5 && hitpointComponent.GetHitpoints() == 0)
						{
							this.int_8[idx] = this.logicAttackerItemData_0.GetAlternatePickNewTargetDelay();
						}
						if (hitpointComponent.GetHitpoints() == 0 && this.m_parent.GetGameObjectType() == LogicGameObjectType.CHARACTER && ((LogicCharacter)this.m_parent).GetCharacterData().IsUnderground())
						{
							this.int_8[idx] = LogicDataTables.GetGlobals().GetMinerHideTime() + this.m_parent.Rand(0) % LogicDataTables.GetGlobals().GetMinerHideTimeRandom();
						}
						if (this.logicAttackerItemData_0.GetPreventsHealing() && hitpointComponent.GetInvulnerabilityTime() <= 0)
						{
							logicGameObject.SetPreventsHealingTime(30);
						}
						if (this.logicAttackerItemData_0.GetChainAttackDistance() > 0)
						{
							this.logicGameObject_2[1] = null;
							this.logicGameObject_2[2] = null;
							this.logicGameObject_2[3] = null;
							this.logicGameObject_2[4] = null;
							LogicGameObject chainAttackTarget = this.GetChainAttackTarget(logicGameObject.GetX(), logicGameObject.GetY(), this.logicAttackerItemData_0.GetChainAttackDistance());
							if (chainAttackTarget != null)
							{
								this.logicGameObject_2[1] = chainAttackTarget;
								chainAttackTarget.GetHitpointComponent().CauseDamage(num, this.m_parent.GetGlobalID(), this.m_parent);
							}
						}
					}
				}
				if (this.logicAttackerItemData_0.GetDamage2() != 0)
				{
					this.int_9[idx] = this.logicAttackerItemData_0.GetDamage2Delay();
					this.int_10[idx] = logicGameObject.GetMidX();
					this.int_11[idx] = logicGameObject.GetMidY();
				}
			}
			else
			{
				LogicProjectileData logicProjectileData = this.logicAttackerItemData_0.GetProjectile(alt);
				if (this.logicAttackerItemData_0.GetRageProjectile() != null)
				{
					if (this.m_parent.IsHero())
					{
						if (this.m_parent.IsStealthy())
						{
							logicProjectileData = this.logicAttackerItemData_0.GetRageProjectile();
						}
					}
					else if (this.int_1[0] > 0)
					{
						logicProjectileData = this.logicAttackerItemData_0.GetRageProjectile();
					}
				}
				int num2 = 1;
				if (this.logicAttackerItemData_0.GetBurstCount() > 0 && this.logicAttackerItemData_0.GetBurstDelay() == 0)
				{
					num2 = this.logicAttackerItemData_0.GetBurstCount();
				}
				if (this.bool_16[this.m_parent.GetLevel().GetCurrentLayout()])
				{
					num2 = 1;
					if (this.logicAttackerItemData_0.GetAltBurstCount() > 0 && this.logicAttackerItemData_0.GetAltBurstDelay() == 0)
					{
						num2 = this.logicAttackerItemData_0.GetAltBurstCount();
					}
				}
				for (int i = 0; i < num2; i++)
				{
					LogicProjectile logicProjectile = (LogicProjectile)LogicGameObjectFactory.CreateGameObject(logicProjectileData, this.m_parent.GetLevel(), this.m_parent.GetVillageType());
					logicProjectile.SetInitialPosition(this.m_parent, this.m_parent.GetMidX(), this.m_parent.GetMidY());
					logicProjectile.SetBounceCount(this.logicAttackerItemData_0.GetProjectileBounces());
					if (i >= num2 - this.logicAttackerItemData_0.GetDummyProjectileCount())
					{
						logicProjectile.SetDummyProjectile(true);
					}
					LogicHitpointComponent hitpointComponent2 = this.m_parent.GetHitpointComponent();
					int num3 = (hitpointComponent2 != null) ? hitpointComponent2.GetTeam() : -1;
					if (logicGameObject == null && (this.logicArrayList_1.Size() > 0 || this.int_5[0] > 0))
					{
						logicProjectile.SetTargetPos(this.logicVector2_1.m_x, this.logicVector2_1.m_y, num3, flag);
					}
					else if (this.logicAttackerItemData_0.GetShockwavePushStrength() == 0 && !this.logicAttackerItemData_0.IsPenetratingProjectile())
					{
						if (logicProjectileData.GetTrackTarget())
						{
							logicProjectile.SetTarget(this.m_parent.GetMidX(), this.m_parent.GetMidY(), this.int_21, logicGameObject, logicProjectileData.GetRandomHitPosition());
						}
						else
						{
							int num4 = logicGameObject.GetMidX();
							int num5 = logicGameObject.GetMidY();
							if (logicProjectileData.GetTargetPosRandomRadius() != 0)
							{
								int num6 = logicProjectileData.GetTargetPosRandomRadius();
								if (this.logicAttackerItemData_0.GetDummyProjectileCount() > 0 && i == 0)
								{
									num6 = 0;
								}
								num4 += this.logicRandom_0.Rand(2 * num6) - num6;
								num5 += this.logicRandom_0.Rand(2 * num6) - num6;
							}
							logicProjectile.SetTargetPos(num4, num5, num3, flag);
						}
					}
					else
					{
						int num7 = this.GetAttackRange(this.m_parent.GetLevel().GetCurrentLayout(), false) + this.logicAttackerItemData_0.GetPenetratingExtraRange() + 256;
						LogicVector2 logicVector2 = new LogicVector2(num7, 0);
						logicVector2.Rotate(this.m_parent.GetDirection());
						if (this.logicAttackerItemData_0.GetShockwavePushStrength() != 0)
						{
							logicProjectile.SetTargetPos(this.m_parent.GetMidX(), this.m_parent.GetMidY(), this.m_parent.GetMidX() + logicVector2.m_x, this.m_parent.GetMidY() + logicVector2.m_y, this.logicAttackerItemData_0.GetMinAttackRange(), num7 + 256, this.m_parent.GetDirection(), this.logicAttackerItemData_0.GetShockwavePushStrength(), this.logicAttackerItemData_0.GetShockwaveArcLength(), this.logicAttackerItemData_0.GetShockwaveExpandRadius(), num3, flag);
						}
						else if (this.logicAttackerItemData_0.IsPenetratingProjectile())
						{
							logicProjectile.SetTargetPos(this.m_parent.GetMidX() + logicVector2.m_x, this.m_parent.GetMidY() + logicVector2.m_y, num3, flag);
							logicProjectile.SetPenetratingRadius(this.logicAttackerItemData_0.GetPenetratingRadius());
						}
					}
					logicProjectile.SetInitialPosition(this.m_parent, this.m_parent.GetMidX(), this.m_parent.GetMidY());
					if (logicGameObject != null && num < 0 && logicGameObject.IsPreventsHealing())
					{
						num = 0;
					}
					bool flag2 = false;
					if (this.m_parent.GetGameObjectType() == LogicGameObjectType.CHARACTER)
					{
						LogicCharacter logicCharacter2 = (LogicCharacter)this.m_parent;
						LogicCharacterData characterData2 = logicCharacter2.GetCharacterData();
						if (characterData2.GetSpecialAbilityType() == 6 && logicCharacter2.GetSpecialAbilityAvailable())
						{
							num = num * characterData2.GetSpecialAbilityAttribute3(logicCharacter2.GetUpgradeLevel()) / 100;
							logicProjectile.SetHitEffect(characterData2.GetSpecialAbilityEffect(logicCharacter2.GetUpgradeLevel()), null);
							flag2 = true;
						}
					}
					logicProjectile.SetDamage(num);
					logicProjectile.SetPreferredTargetDamageMod(this.logicData_0, this.int_18);
					logicProjectile.SetDamageRadius(this.logicAttackerItemData_0.GetDamageRadius());
					logicProjectile.SetPushBack(this.logicAttackerItemData_0.GetPushBack(), true);
					if (!flag2 || logicProjectile.GetHitEffect() == null)
					{
						logicProjectile.SetHitEffect(this.logicAttackerItemData_0.GetHitEffect(), this.logicAttackerItemData_0.GetHitEffect2());
					}
					logicProjectile.SetSpeedMod(this.logicAttackerItemData_0.GetSpeedMod());
					logicProjectile.SetStatusEffectTime(this.logicAttackerItemData_0.GetStatusEffectTime());
					logicProjectile.SetMyTeam(num3);
					this.m_parent.GetGameObjectManager().AddGameObject(logicProjectile, -1);
					if (logicGameObject != null && this.m_parent.GetGameObjectType() == LogicGameObjectType.CHARACTER)
					{
						int chainShootingDistance = ((LogicCharacter)this.m_parent).GetCharacterData().GetChainShootingDistance();
						int num8 = logicGameObject.GetMidX() - this.m_parent.GetMidX();
						int num9 = logicGameObject.GetMidY() - this.m_parent.GetMidY();
						int num10 = LogicMath.Sqrt(num8 * num8 + num9 * num9);
						if (chainShootingDistance > 0 && num10 > 0)
						{
							int chainedProjectileBounceCount = LogicDataTables.GetGlobals().GetChainedProjectileBounceCount();
							int num11 = (chainShootingDistance << 9) / 100;
							if (chainedProjectileBounceCount > 1)
							{
								num8 = 255 * num8 / num10;
								num9 = 255 * num9 / num10;
								int num12 = num11 * num8 / 255;
								int num13 = num11 * num9 / 255;
								int num14 = logicGameObject.GetMidX() + num12;
								int num15 = logicGameObject.GetMidY() + num13;
								for (int j = 0; j < chainedProjectileBounceCount - 1; j++)
								{
									logicProjectile.SetBouncePosition(new LogicVector2(num14, num15));
									num14 += num12;
									num15 += num13;
								}
							}
						}
					}
				}
			}
			if (this.logicAttackerItemData_0.GetHitSpell() != null)
			{
				LogicSpell logicSpell = (LogicSpell)LogicGameObjectFactory.CreateGameObject(this.logicAttackerItemData_0.GetHitSpell(), this.m_parent.GetLevel(), this.m_parent.GetVillageType());
				logicSpell.SetUpgradeLevel(this.logicAttackerItemData_0.GetHitSpellLevel());
				logicSpell.SetInitialPosition(logicGameObject.GetMidX(), logicGameObject.GetMidY());
				logicSpell.SetTeam(this.m_parent.GetHitpointComponent().GetTeam());
				this.m_parent.GetGameObjectManager().AddGameObject(logicSpell, -1);
			}
			if (this.logicAttackerItemData_0.GetAmmoCount() > 0 && this.int_30 <= 0)
			{
				this.int_14--;
				this.int_30 = this.int_29;
			}
			if (logicGameObject != null)
			{
				LogicCombatComponent combatComponent = logicGameObject.GetCombatComponent();
				if (combatComponent != null)
				{
					combatComponent.AttackedBy(this.m_parent);
				}
			}
			this.HitCompleted();
			if (this.bool_8)
			{
				this.ForceNewTarget();
			}
			if (!this.bool_12 && this.m_parent.GetGameObjectType() == LogicGameObjectType.CHARACTER)
			{
				LogicCharacter logicCharacter3 = (LogicCharacter)this.m_parent;
				if (logicCharacter3.GetParent() != null)
				{
					logicCharacter3.GetParent().GetCombatComponent().HitCompleted();
				}
			}
		}

		// Token: 0x06000F27 RID: 3879 RVA: 0x0003F754 File Offset: 0x0003D954
		public void HitCompleted()
		{
			this.int_21++;
			if (this.m_parent.GetGameObjectType() == LogicGameObjectType.CHARACTER && ((LogicCharacter)this.m_parent).GetCharacterData().GetSpecialAbilityType() == 6 && this.logicGameObject_2[0] != null && !this.IsInRange(this.logicGameObject_2[0]))
			{
				this.StopAttack();
				this.RefreshTarget(true);
			}
		}

		// Token: 0x06000F28 RID: 3880 RVA: 0x0003F7BC File Offset: 0x0003D9BC
		public LogicGameObject GetChainAttackTarget(int midX, int midY, int attackDistance)
		{
			this.logicArrayList_0.Clear();
			this.m_parent.GetGameObjectManager().GetGameObjects(this.logicArrayList_0, this.logicComponentFilter_0);
			int num = int.MaxValue;
			LogicGameObject result = null;
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				LogicGameObject logicGameObject = this.logicArrayList_0[i];
				if (!logicGameObject.IsHidden() && this.CanAttackHeightCheck(logicGameObject))
				{
					if (logicGameObject.GetGameObjectType() == LogicGameObjectType.CHARACTER)
					{
						LogicCharacter logicCharacter = (LogicCharacter)logicGameObject;
						if (logicCharacter.GetSpawnDelay() > 0 || logicCharacter.GetSpawnIdleTime() > 0)
						{
							goto IL_F2;
						}
						LogicCombatComponent combatComponent = logicCharacter.GetCombatComponent();
						if ((combatComponent != null && combatComponent.GetUndergroundTime() > 0) || logicCharacter.GetChildTroops() != null)
						{
							goto IL_F2;
						}
					}
					bool flag = false;
					for (int j = 0; j < 5; j++)
					{
						if (logicGameObject == this.logicGameObject_2[j])
						{
							flag = true;
						}
					}
					if (!flag)
					{
						int num2 = logicGameObject.GetMidX() - midX >> 9;
						int num3 = logicGameObject.GetMidY() - midY >> 9;
						int num4 = num2 * num2 + num3 * num3;
						if (num4 < num)
						{
							num = num4;
							result = logicGameObject;
						}
					}
				}
				IL_F2:;
			}
			if (num < attackDistance * attackDistance)
			{
				return result;
			}
			return null;
		}

		// Token: 0x06000F29 RID: 3881 RVA: 0x0003F8DC File Offset: 0x0003DADC
		public int GetDamage()
		{
			int num = this.int_15;
			if (this.bool_5)
			{
				if (this.bool_16[this.m_parent.GetLevel().GetCurrentLayout()])
				{
					num = this.logicAttackerItemData_0.GetDamage(0, this.logicAttackerItemData_0.GetMultiTargets(true));
					goto IL_9F;
				}
			}
			else if (this.bool_16[this.m_parent.GetLevel().GetCurrentLayout()])
			{
				num = this.logicAttackerItemData_0.GetAltDamage(0, this.logicAttackerItemData_0.GetMultiTargets(true));
				goto IL_9F;
			}
			if (this.logicAttackerItemData_0.IsIncreasingDamage())
			{
				int damageLevel = this.GetDamageLevel();
				if (damageLevel != 0)
				{
					num = this.logicAttackerItemData_0.GetDamage(damageLevel, false);
				}
			}
			IL_9F:
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			if (this.int_1[0] > 0)
			{
				num3 = (int)((long)this.int_2[0] * (long)num / 100L);
			}
			if (this.int_33 > 0)
			{
				num2 = (int)((long)this.int_34 * (long)num / 100L);
			}
			if (this.int_31 > 0)
			{
				num4 = (int)((long)this.int_31 * (long)num / 100L);
			}
			return num + num3 + num2 + num4;
		}

		// Token: 0x06000F2A RID: 3882 RVA: 0x0003F9F8 File Offset: 0x0003DBF8
		public int GetDamageLevel()
		{
			int num = 0;
			if (this.bool_12)
			{
				num = this.int_25;
			}
			else if (this.m_parent.GetGameObjectType() == LogicGameObjectType.CHARACTER)
			{
				LogicCharacter logicCharacter = (LogicCharacter)this.m_parent;
				num = ((logicCharacter.GetParent() == null) ? this.m_parent : logicCharacter.GetParent()).GetCombatComponent().int_21;
			}
			if (this.logicAttackerItemData_0.IsIncreasingDamage() && (!this.bool_5 || !this.bool_16[this.m_parent.GetLevel().GetCurrentLayout()]))
			{
				int result = 0;
				if (num >= this.logicAttackerItemData_0.GetSwitchTimeLv2())
				{
					result = 1;
				}
				if (num >= this.logicAttackerItemData_0.GetSwitchTimeLv3())
				{
					result = 2;
				}
				return result;
			}
			return 0;
		}

		// Token: 0x06000F2B RID: 3883 RVA: 0x0000A6FE File Offset: 0x000088FE
		public void SetSkeletonSpell()
		{
			this.bool_9 = true;
		}

		// Token: 0x06000F2C RID: 3884 RVA: 0x0000A707 File Offset: 0x00008907
		public int GetWakeUpTime()
		{
			return this.int_19;
		}

		// Token: 0x06000F2D RID: 3885 RVA: 0x0000A70F File Offset: 0x0000890F
		public int GetDeployedHousingSpace()
		{
			return this.int_32;
		}

		// Token: 0x06000F2E RID: 3886 RVA: 0x0000A717 File Offset: 0x00008917
		public void SetMergeDamage(int damage)
		{
			this.int_31 = damage;
		}

		// Token: 0x06000F2F RID: 3887 RVA: 0x00002B36 File Offset: 0x00000D36
		public override LogicComponentType GetComponentType()
		{
			return LogicComponentType.COMBAT;
		}

		// Token: 0x06000F30 RID: 3888 RVA: 0x0003FAA8 File Offset: 0x0003DCA8
		public override void Load(LogicJSONObject jsonObject)
		{
			if (this.bool_2)
			{
				for (int i = 0; i < 8; i++)
				{
					LogicJSONBoolean jsonboolean = jsonObject.GetJSONBoolean(this.GetLayoutVariableNameAttackMode(i, false));
					if (jsonboolean != null)
					{
						this.bool_16[i] = jsonboolean.IsTrue();
					}
					LogicJSONBoolean jsonboolean2 = jsonObject.GetJSONBoolean(this.GetLayoutVariableNameAttackMode(i, true));
					if (jsonboolean2 != null)
					{
						this.bool_17[i] = jsonboolean2.IsTrue();
					}
				}
			}
			if (this.logicAttackerItemData_0.GetAmmoCount() > 0)
			{
				LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("ammo");
				this.int_14 = ((jsonnumber != null) ? jsonnumber.GetIntValue() : 0);
			}
			if (this.logicAttackerItemData_0.GetTargetingConeAngle() > 0)
			{
				for (int j = 0; j < 8; j++)
				{
					LogicJSONNumber jsonnumber2 = jsonObject.GetJSONNumber(this.GetLayoutVariableNameAimAngle(j, false));
					if (jsonnumber2 != null)
					{
						this.int_12[j] = jsonnumber2.GetIntValue();
					}
					LogicJSONNumber jsonnumber3 = jsonObject.GetJSONNumber(this.GetLayoutVariableNameAimAngle(j, true));
					if (jsonnumber3 != null)
					{
						this.int_13[j] = jsonnumber3.GetIntValue();
					}
				}
			}
		}

		// Token: 0x06000F31 RID: 3889 RVA: 0x0003FBA0 File Offset: 0x0003DDA0
		public override void LoadFromSnapshot(LogicJSONObject jsonObject)
		{
			if (this.bool_2)
			{
				for (int i = 0; i < 8; i++)
				{
					LogicJSONBoolean jsonboolean = jsonObject.GetJSONBoolean(this.GetLayoutVariableNameAttackMode(i, false));
					if (jsonboolean != null)
					{
						this.bool_16[i] = jsonboolean.IsTrue();
					}
				}
			}
			if (this.logicAttackerItemData_0.GetAmmoCount() > 0)
			{
				this.int_14 = this.logicAttackerItemData_0.GetAmmoCount();
			}
			if (this.logicAttackerItemData_0.GetTargetingConeAngle() > 0)
			{
				for (int j = 0; j < 8; j++)
				{
					LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber(this.GetLayoutVariableNameAimAngle(j, false));
					if (jsonnumber != null)
					{
						this.int_12[j] = jsonnumber.GetIntValue();
					}
				}
			}
		}

		// Token: 0x06000F32 RID: 3890 RVA: 0x0003FC3C File Offset: 0x0003DE3C
		public override void Save(LogicJSONObject jsonObject, int villageType)
		{
			if (this.bool_2)
			{
				for (int i = 0; i < 8; i++)
				{
					jsonObject.Put(this.GetLayoutVariableNameAttackMode(i, false), new LogicJSONBoolean(this.bool_16[i]));
					jsonObject.Put(this.GetLayoutVariableNameAttackMode(i, true), new LogicJSONBoolean(this.bool_17[i]));
				}
			}
			if (this.int_14 > 0)
			{
				jsonObject.Put("ammo", new LogicJSONNumber(this.int_14));
			}
			if (this.logicAttackerItemData_0.GetTargetingConeAngle() > 0)
			{
				for (int j = 0; j < 8; j++)
				{
					jsonObject.Put(this.GetLayoutVariableNameAimAngle(j, false), new LogicJSONNumber(this.int_12[j]));
					jsonObject.Put(this.GetLayoutVariableNameAimAngle(j, true), new LogicJSONNumber(this.int_13[j]));
				}
			}
		}

		// Token: 0x06000F33 RID: 3891 RVA: 0x0003FD04 File Offset: 0x0003DF04
		public override void SaveToSnapshot(LogicJSONObject jsonObject, int layoutId)
		{
			if (this.bool_2)
			{
				for (int i = 0; i < 8; i++)
				{
					jsonObject.Put(this.GetLayoutVariableNameAttackMode(i, false), new LogicJSONBoolean(this.bool_16[layoutId]));
				}
			}
			if (this.int_14 > 0)
			{
				jsonObject.Put("ammo", new LogicJSONNumber(this.int_14));
			}
			if (this.logicAttackerItemData_0.GetTargetingConeAngle() > 0)
			{
				for (int j = 0; j < 8; j++)
				{
					jsonObject.Put(this.GetLayoutVariableNameAimAngle(j, false), new LogicJSONNumber(this.int_12[layoutId]));
				}
			}
		}

		// Token: 0x06000F34 RID: 3892 RVA: 0x0003FD94 File Offset: 0x0003DF94
		public string GetLayoutVariableNameAttackMode(int idx, bool draftMode)
		{
			if (draftMode)
			{
				switch (idx)
				{
				case 0:
					return "attack_mode_draft";
				case 1:
					return "attack_mode_d1";
				case 2:
					return "attack_mode_d2";
				case 3:
					return "attack_mode_d3";
				case 4:
					return "attack_mode_d4";
				case 5:
					return "attack_mode_d5";
				case 6:
					return "attack_mode_dchal";
				case 7:
					return "attack_mode_draft_arrw";
				default:
					Debugger.Error("Layout index out of bounds");
					return "attack_mode_draft";
				}
			}
			else
			{
				switch (idx)
				{
				case 0:
					return "attack_mode";
				case 1:
					return "attack_mode1";
				case 2:
					return "attack_mode2";
				case 3:
					return "attack_mode3";
				case 4:
					return "attack_mode4";
				case 5:
					return "attack_mode5";
				case 6:
					return "attack_mode_chal";
				case 7:
					return "attack_mode_arrw";
				default:
					Debugger.Error("Layout index out of bounds");
					return "attack_mode";
				}
			}
		}

		// Token: 0x06000F35 RID: 3893 RVA: 0x0003FE70 File Offset: 0x0003E070
		public string GetLayoutVariableNameAimAngle(int idx, bool draftMode)
		{
			if (draftMode)
			{
				switch (idx)
				{
				case 0:
					return "aim_angle_draft";
				case 1:
					return "aim_angle_d1";
				case 2:
					return "aim_angle_d2";
				case 3:
					return "aim_angle_d3";
				case 4:
					return "aim_angle_d4";
				case 5:
					return "aim_angle_d5";
				case 6:
					return "aim_angle_dchal";
				case 7:
					return "aim_angle_draft_arrw";
				default:
					Debugger.Error("Layout index out of bounds");
					return "aim_angle_draft";
				}
			}
			else
			{
				switch (idx)
				{
				case 0:
					return "aim_angle";
				case 1:
					return "aim_angle1";
				case 2:
					return "aim_angle2";
				case 3:
					return "aim_angle3";
				case 4:
					return "aim_angle4";
				case 5:
					return "aim_angle5";
				case 6:
					return "aim_angle5_chal";
				case 7:
					return "aim_angle_arrw";
				default:
					Debugger.Error("Layout index out of bounds");
					return "aim_angle";
				}
			}
		}

		// Token: 0x06000F36 RID: 3894 RVA: 0x0003FF4C File Offset: 0x0003E14C
		public static bool IsPreferredTarget(LogicData target, LogicGameObject gameObject)
		{
			if (target != null && gameObject != null)
			{
				LogicGameObjectData data = gameObject.GetData();
				if (target.GetDataType() != LogicDataType.BUILDING_CLASS || data.GetDataType() != LogicDataType.BUILDING)
				{
					if (target.GetDataType() == LogicDataType.CHARACTER)
					{
						if (data.GetDataType() == LogicDataType.CHARACTER)
						{
							LogicCharacterData logicCharacterData = (LogicCharacterData)data;
							LogicCharacter logicCharacter = (LogicCharacter)gameObject;
							if (logicCharacterData.IsSecondaryTroop() && logicCharacter.GetSummoner() != null)
							{
								return logicCharacter.GetSummoner() == target || data == target;
							}
							return data == target;
						}
					}
					return data == target;
				}
				LogicBuildingData logicBuildingData = (LogicBuildingData)data;
				if (logicBuildingData.GetBuildingClass() == target)
				{
					return true;
				}
				if (logicBuildingData.GetSecondaryTargetingClass() != null)
				{
					return logicBuildingData.GetSecondaryTargetingClass() == target;
				}
			}
			return false;
		}

		// Token: 0x040005EA RID: 1514
		private LogicAttackerItemData logicAttackerItemData_0;

		// Token: 0x040005EB RID: 1515
		private readonly LogicComponentFilter logicComponentFilter_0;

		// Token: 0x040005EC RID: 1516
		private readonly LogicComponentFilter logicComponentFilter_1;

		// Token: 0x040005ED RID: 1517
		private LogicGameObject logicGameObject_0;

		// Token: 0x040005EE RID: 1518
		private readonly LogicArrayList<LogicGameObject> logicArrayList_0;

		// Token: 0x040005EF RID: 1519
		private readonly LogicRandom logicRandom_0;

		// Token: 0x040005F0 RID: 1520
		private LogicData logicData_0;

		// Token: 0x040005F1 RID: 1521
		private readonly LogicVector2 logicVector2_0;

		// Token: 0x040005F2 RID: 1522
		private readonly LogicVector2 logicVector2_1;

		// Token: 0x040005F3 RID: 1523
		private readonly LogicVector2 logicVector2_2;

		// Token: 0x040005F4 RID: 1524
		private readonly LogicVector2 logicVector2_3;

		// Token: 0x040005F5 RID: 1525
		private readonly LogicTargetList logicTargetList_0;

		// Token: 0x040005F6 RID: 1526
		private readonly LogicTargetList logicTargetList_1;

		// Token: 0x040005F7 RID: 1527
		private LogicGameObject logicGameObject_1;

		// Token: 0x040005F8 RID: 1528
		private readonly LogicArrayList<LogicGameObject> logicArrayList_1;

		// Token: 0x040005F9 RID: 1529
		private readonly LogicArrayList<LogicGameObject> logicArrayList_2;

		// Token: 0x040005FA RID: 1530
		private readonly LogicArrayList<int> logicArrayList_3;

		// Token: 0x040005FB RID: 1531
		private readonly LogicArrayList<int> logicArrayList_4;

		// Token: 0x040005FC RID: 1532
		private readonly LogicArrayList<int> logicArrayList_5;

		// Token: 0x040005FD RID: 1533
		private int[] int_0;

		// Token: 0x040005FE RID: 1534
		private bool bool_0;

		// Token: 0x040005FF RID: 1535
		private readonly bool bool_1;

		// Token: 0x04000600 RID: 1536
		private bool bool_2;

		// Token: 0x04000601 RID: 1537
		private bool bool_3;

		// Token: 0x04000602 RID: 1538
		private bool bool_4;

		// Token: 0x04000603 RID: 1539
		private bool bool_5;

		// Token: 0x04000604 RID: 1540
		private bool bool_6;

		// Token: 0x04000605 RID: 1541
		private bool bool_7;

		// Token: 0x04000606 RID: 1542
		private bool bool_8;

		// Token: 0x04000607 RID: 1543
		private bool bool_9;

		// Token: 0x04000608 RID: 1544
		private bool bool_10;

		// Token: 0x04000609 RID: 1545
		private bool bool_11;

		// Token: 0x0400060A RID: 1546
		private bool bool_12;

		// Token: 0x0400060B RID: 1547
		private bool bool_13;

		// Token: 0x0400060C RID: 1548
		private bool bool_14;

		// Token: 0x0400060D RID: 1549
		private readonly bool[] bool_15;

		// Token: 0x0400060E RID: 1550
		private readonly bool[] bool_16;

		// Token: 0x0400060F RID: 1551
		private readonly bool[] bool_17;

		// Token: 0x04000610 RID: 1552
		private readonly int[] int_1;

		// Token: 0x04000611 RID: 1553
		private readonly int[] int_2;

		// Token: 0x04000612 RID: 1554
		private readonly int[] int_3;

		// Token: 0x04000613 RID: 1555
		private readonly int[] int_4;

		// Token: 0x04000614 RID: 1556
		private readonly int[] int_5;

		// Token: 0x04000615 RID: 1557
		private readonly int[] int_6;

		// Token: 0x04000616 RID: 1558
		private readonly int[] int_7;

		// Token: 0x04000617 RID: 1559
		private readonly int[] int_8;

		// Token: 0x04000618 RID: 1560
		private readonly int[] int_9;

		// Token: 0x04000619 RID: 1561
		private readonly int[] int_10;

		// Token: 0x0400061A RID: 1562
		private readonly int[] int_11;

		// Token: 0x0400061B RID: 1563
		private readonly int[] int_12;

		// Token: 0x0400061C RID: 1564
		private readonly int[] int_13;

		// Token: 0x0400061D RID: 1565
		private readonly LogicGameObject[] logicGameObject_2;

		// Token: 0x0400061E RID: 1566
		private int int_14;

		// Token: 0x0400061F RID: 1567
		private int int_15;

		// Token: 0x04000620 RID: 1568
		private int int_16;

		// Token: 0x04000621 RID: 1569
		private int int_17;

		// Token: 0x04000622 RID: 1570
		private int int_18;

		// Token: 0x04000623 RID: 1571
		private int int_19;

		// Token: 0x04000624 RID: 1572
		private int int_20;

		// Token: 0x04000625 RID: 1573
		private int int_21;

		// Token: 0x04000626 RID: 1574
		private int int_22;

		// Token: 0x04000627 RID: 1575
		private int int_23;

		// Token: 0x04000628 RID: 1576
		private int int_24;

		// Token: 0x04000629 RID: 1577
		private int int_25;

		// Token: 0x0400062A RID: 1578
		private int int_26;

		// Token: 0x0400062B RID: 1579
		private int int_27;

		// Token: 0x0400062C RID: 1580
		private int int_28;

		// Token: 0x0400062D RID: 1581
		private int int_29;

		// Token: 0x0400062E RID: 1582
		private int int_30;

		// Token: 0x0400062F RID: 1583
		private int int_31;

		// Token: 0x04000630 RID: 1584
		private int int_32;

		// Token: 0x04000631 RID: 1585
		private int int_33;

		// Token: 0x04000632 RID: 1586
		private int int_34;

		// Token: 0x04000633 RID: 1587
		private int int_35;

		// Token: 0x04000634 RID: 1588
		private int int_36;

		// Token: 0x04000635 RID: 1589
		private int int_37;

		// Token: 0x04000636 RID: 1590
		private int int_38;
	}
}
