using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.GameObject
{
	// Token: 0x02000116 RID: 278
	public sealed class LogicProjectile : LogicGameObject
	{
		// Token: 0x06000E30 RID: 3632 RVA: 0x000347EC File Offset: 0x000329EC
		public LogicProjectile(LogicGameObjectData data, LogicLevel level, int villageType) : base(data, level, villageType)
		{
			this.int_17 = -1;
			this.logicVector2_1 = new LogicVector2();
			this.logicVector2_2 = new LogicVector2();
			this.logicVector2_3 = new LogicVector2();
			this.logicVector2_4 = new LogicVector2();
			this.logicVector2_5 = new LogicVector2();
			this.logicVector2_6 = new LogicVector2();
			this.logicVector2_7 = new LogicVector2();
			this.logicGameObject_2 = new LogicGameObject[4];
			this.logicVector2_0 = new LogicVector2[4];
		}

		// Token: 0x06000E31 RID: 3633 RVA: 0x00009DE1 File Offset: 0x00007FE1
		public LogicProjectileData GetProjectileData()
		{
			return (LogicProjectileData)this.m_data;
		}

		// Token: 0x06000E32 RID: 3634 RVA: 0x00002B56 File Offset: 0x00000D56
		public override LogicGameObjectType GetGameObjectType()
		{
			return LogicGameObjectType.PROJECTILE;
		}

		// Token: 0x06000E33 RID: 3635 RVA: 0x00034870 File Offset: 0x00032A70
		public override void Destruct()
		{
			base.Destruct();
			for (int i = 0; i < 4; i++)
			{
				LogicVector2 logicVector = this.logicVector2_0[i];
				if (logicVector != null)
				{
					logicVector.Destruct();
				}
				this.logicVector2_0[i] = null;
			}
			this.logicVector2_1.Destruct();
			this.logicVector2_2.Destruct();
			this.logicVector2_3.Destruct();
			this.logicVector2_4.Destruct();
			this.logicVector2_5.Destruct();
			this.logicVector2_6.Destruct();
			this.logicVector2_7.Destruct();
		}

		// Token: 0x06000E34 RID: 3636 RVA: 0x00009DEE File Offset: 0x00007FEE
		public override void RemoveGameObjectReferences(LogicGameObject gameObject)
		{
			if (this.logicGameObject_1 == gameObject)
			{
				this.logicGameObject_1 = null;
			}
			if (this.logicGameObject_0 == gameObject)
			{
				this.logicGameObject_0 = null;
				if (this.bool_2)
				{
					this.logicGameObject_1 = null;
					this.bool_2 = false;
				}
			}
		}

		// Token: 0x06000E35 RID: 3637 RVA: 0x00002465 File Offset: 0x00000665
		public override int GetWidthInTiles()
		{
			return 0;
		}

		// Token: 0x06000E36 RID: 3638 RVA: 0x00002465 File Offset: 0x00000665
		public override int GetHeightInTiles()
		{
			return 0;
		}

		// Token: 0x06000E37 RID: 3639 RVA: 0x00009E26 File Offset: 0x00008026
		public override bool ShouldDestruct()
		{
			return this.bool_6 && this.int_9 == int.MinValue;
		}

		// Token: 0x06000E38 RID: 3640 RVA: 0x00002B36 File Offset: 0x00000D36
		public override bool IsUnbuildable()
		{
			return true;
		}

		// Token: 0x06000E39 RID: 3641 RVA: 0x00009E3F File Offset: 0x0000803F
		public bool IsDummyProjectile()
		{
			return this.bool_5;
		}

		// Token: 0x06000E3A RID: 3642 RVA: 0x00009E47 File Offset: 0x00008047
		public void SetDummyProjectile(bool dummy)
		{
			this.bool_5 = dummy;
		}

		// Token: 0x06000E3B RID: 3643 RVA: 0x00009E50 File Offset: 0x00008050
		public LogicEffectData GetHitEffect()
		{
			return this.logicEffectData_0;
		}

		// Token: 0x06000E3C RID: 3644 RVA: 0x00009E58 File Offset: 0x00008058
		public void SetHitEffect(LogicEffectData hitEffect, LogicEffectData hitEffect2)
		{
			this.logicEffectData_0 = hitEffect;
			this.logicEffectData_1 = hitEffect2;
		}

		// Token: 0x06000E3D RID: 3645 RVA: 0x00009E68 File Offset: 0x00008068
		public void SetDamage(int damage)
		{
			this.int_8 = damage;
		}

		// Token: 0x06000E3E RID: 3646 RVA: 0x00009E71 File Offset: 0x00008071
		public void SetPushBack(int force, bool enabled)
		{
			this.int_20 = force;
			this.bool_0 = enabled;
		}

		// Token: 0x06000E3F RID: 3647 RVA: 0x00009E81 File Offset: 0x00008081
		public void SetSpeedMod(int speed)
		{
			this.int_21 = speed;
		}

		// Token: 0x06000E40 RID: 3648 RVA: 0x00009E8A File Offset: 0x0000808A
		public void SetStatusEffectTime(int time)
		{
			this.int_22 = time;
		}

		// Token: 0x06000E41 RID: 3649 RVA: 0x00009E93 File Offset: 0x00008093
		public void SetBounceCount(int value)
		{
			this.int_7 = value;
			if (value > 4)
			{
				Debugger.Warning("LogicProjectile::setBounceCount() called with too high value, clamping to MAX_BOUNCES");
				this.int_7 = 4;
			}
		}

		// Token: 0x06000E42 RID: 3650 RVA: 0x000348F8 File Offset: 0x00032AF8
		public void SetInitialPosition(LogicGameObject groups, int x, int y)
		{
			this.logicGameObject_0 = groups;
			this.int_11 = ((groups != null) ? groups.GetGlobalID() : 0);
			this.logicVector2_2.m_x = this.logicVector2_1.m_x - 8 * x;
			this.logicVector2_2.m_y = this.logicVector2_1.m_y - 8 * y;
			this.logicVector2_2.Normalize((this.GetProjectileData().GetStartOffset() << 9) / 100);
			this.SetInitialPosition(this.logicVector2_2.m_x + x, this.logicVector2_2.m_y + y);
			this.logicVector2_4.m_x = 0;
			this.logicVector2_4.m_y = 0;
			this.logicVector2_6.m_x = base.GetX();
			this.logicVector2_6.m_y = base.GetY();
			this.logicVector2_7.m_x = base.GetX() * 8;
			this.logicVector2_7.m_y = base.GetY() * 8;
			this.logicVector2_3.m_x = this.logicVector2_1.m_x - this.logicVector2_7.m_x;
			this.logicVector2_3.m_y = this.logicVector2_1.m_y - this.logicVector2_7.m_y;
			this.bool_2 = false;
			if (this.logicGameObject_0 != null && this.logicGameObject_0.GetGameObjectType() == LogicGameObjectType.BUILDING)
			{
				LogicCombatComponent combatComponent = this.logicGameObject_0.GetCombatComponent();
				if (combatComponent != null && combatComponent.GetAttackerItemData().GetTargetGroups())
				{
					this.bool_2 = true;
				}
			}
		}

		// Token: 0x06000E43 RID: 3651 RVA: 0x00034A74 File Offset: 0x00032C74
		public void SetTarget(int x, int y, int randomHitRange, LogicGameObject target, bool randomHitPosition)
		{
			this.logicGameObject_1 = target;
			this.logicVector2_1.m_x = target.GetMidX() * 8;
			this.logicVector2_1.m_y = target.GetMidY() * 8;
			if (target.GetGameObjectType() == LogicGameObjectType.CHARACTER)
			{
				if (((LogicCharacter)target).IsFlying())
				{
					LogicCombatComponent combatComponent = target.GetCombatComponent();
					this.int_12 = ((combatComponent == null || !combatComponent.IsHealer()) ? 1000 : 200);
					this.bool_3 = true;
				}
				if (randomHitPosition)
				{
					LogicVector2 logicVector = new LogicVector2(this.logicVector2_1.m_x >> 3, this.logicVector2_1.m_y >> 3);
					int distance = logicVector.GetDistance(base.GetPosition());
					this.logicVector2_5.m_x = this.logicVector2_1.m_x - 8 * this.GetMidX();
					this.logicVector2_5.m_y = this.logicVector2_1.m_y - 8 * this.GetMidY();
					this.logicVector2_5.Rotate(90);
					this.logicVector2_5.Normalize(64);
					int num = (distance / 10 & base.Rand(randomHitRange)) - distance / 20;
					this.logicVector2_5.m_x = this.logicVector2_5.m_x * num / 64;
					this.logicVector2_5.m_y = this.logicVector2_5.m_y * num / 64;
					logicVector.Destruct();
					return;
				}
			}
			else
			{
				int num2 = target.IsWall() ? 1016 : 2040;
				this.logicVector2_5.m_x = 8 * x - this.logicVector2_1.m_x;
				this.logicVector2_5.m_y = 8 * y - this.logicVector2_1.m_y;
				this.logicVector2_5.Normalize((target.GetWidthInTiles() - target.PassableSubtilesAtEdge() << 12) / 3);
				this.logicVector2_5.m_x += (num2 & base.Rand(randomHitRange)) * (2 * (base.Rand(randomHitRange + 1) & 1) - 1);
				this.logicVector2_5.m_y += (num2 & base.Rand(randomHitRange + 2)) * (2 * (base.Rand(randomHitRange + 3) & 1) - 1);
				this.logicVector2_1.Add(this.logicVector2_5);
				this.int_12 = 150;
			}
		}

		// Token: 0x06000E44 RID: 3652 RVA: 0x00009EB1 File Offset: 0x000080B1
		public void SetTargetPos(int x, int y, int team, bool flyingTarget)
		{
			this.logicVector2_1.m_x = x * 8;
			this.logicVector2_1.m_y = y * 8;
			this.int_17 = team;
			this.int_12 = (flyingTarget ? 1000 : 0);
			this.bool_3 = flyingTarget;
		}

		// Token: 0x06000E45 RID: 3653 RVA: 0x00034CB0 File Offset: 0x00032EB0
		public void SetTargetPos(int startX, int startY, int x, int y, int minAttackRange, int maxAttackRange, int shockwaveAngle, int shockwavePushStrength, int shockwaveArcLength, int shockwaveExpandRadius, int team, bool flyingTarget)
		{
			this.logicVector2_1.m_x = x * 8;
			this.logicVector2_1.m_y = y * 8;
			this.int_17 = team;
			this.int_12 = (flyingTarget ? 1000 : 0);
			this.bool_3 = flyingTarget;
			this.logicVector2_6.m_x = startX;
			this.logicVector2_6.m_y = startY;
			this.int_13 = shockwaveAngle;
			this.int_15 = shockwaveArcLength;
			this.int_16 = shockwaveExpandRadius;
			this.int_14 = shockwavePushStrength;
			this.int_5 = minAttackRange;
			this.int_6 = maxAttackRange;
		}

		// Token: 0x06000E46 RID: 3654 RVA: 0x00009EF0 File Offset: 0x000080F0
		public void SetMyTeam(int team)
		{
			this.int_17 = team;
		}

		// Token: 0x06000E47 RID: 3655 RVA: 0x00009EF9 File Offset: 0x000080F9
		public void SetPenetratingRadius(int radius)
		{
			this.bool_4 = true;
			this.int_18 = radius;
		}

		// Token: 0x06000E48 RID: 3656 RVA: 0x00009F09 File Offset: 0x00008109
		public void SetDamageRadius(int radius)
		{
			this.int_10 = radius;
		}

		// Token: 0x06000E49 RID: 3657 RVA: 0x00009F12 File Offset: 0x00008112
		public void SetPreferredTargetDamageMod(LogicData data, int preferredTargetDamageMod)
		{
			this.logicData_0 = data;
			this.int_19 = preferredTargetDamageMod;
		}

		// Token: 0x06000E4A RID: 3658 RVA: 0x00009F22 File Offset: 0x00008122
		public int GetTargetX()
		{
			return this.logicVector2_1.m_x >> 3;
		}

		// Token: 0x06000E4B RID: 3659 RVA: 0x00009F31 File Offset: 0x00008131
		public int GetTargetY()
		{
			return this.logicVector2_1.m_y >> 3;
		}

		// Token: 0x06000E4C RID: 3660 RVA: 0x00034D44 File Offset: 0x00032F44
		public void SetBouncePosition(LogicVector2 pos)
		{
			this.bool_1 = true;
			for (int i = 0; i < this.logicVector2_0.Length; i++)
			{
				if (this.logicVector2_0[i] == null)
				{
					this.logicVector2_0[i] = pos;
					return;
				}
			}
		}

		// Token: 0x06000E4D RID: 3661 RVA: 0x00034D80 File Offset: 0x00032F80
		public int GetShockwaveArcLength()
		{
			int length = new LogicVector2(this.GetMidX() - (this.logicVector2_1.m_x >> 3), this.GetMidY() - (this.logicVector2_1.m_y >> 3)).GetLength();
			int num = this.int_6 - length;
			if (num < this.int_5)
			{
				return 0;
			}
			int num2 = (this.int_15 << 9) / 100;
			int num3 = LogicMath.Clamp(num * num2 / ((this.int_16 << 9) / 100), 0, num2);
			if (num3 < 0)
			{
				num3 = num2;
			}
			if (num3 > num2)
			{
				num3 = num2;
			}
			int num4 = 18000 * num3 / (314 * num);
			if (num4 < 180)
			{
				return num4;
			}
			return 180;
		}

		// Token: 0x06000E4E RID: 3662 RVA: 0x00034E28 File Offset: 0x00033028
		public void UpdateDamage(int percentage)
		{
			this.int_9 -= 16;
			if (this.int_9 <= 0)
			{
				this.int_9 = int.MinValue;
				int damage = this.int_8 * percentage / 100;
				if (this.logicGameObject_1 != null && this.logicGameObject_1.GetHitpointComponent() != null)
				{
					this.UpdateTargetDamage(this.logicGameObject_1, damage);
				}
				if (this.logicGameObject_1 == null && !this.bool_4 && this.int_10 > 0 && this.int_14 == 0)
				{
					this.m_level.AreaDamage(this.int_11, this.logicVector2_1.m_x >> 3, this.logicVector2_1.m_y >> 3, this.int_10, damage, this.logicData_0, this.int_19, this.logicEffectData_0, this.int_17, this.logicVector2_4, this.bool_3 ? 0 : 1, 0, this.int_20, this.bool_0, false, 100, 0, this.logicGameObject_0, 100, 0);
					if (this.int_21 != 0 && this.int_22 > 0)
					{
						this.m_level.AreaBoost(this.logicVector2_1.m_x >> 3, this.logicVector2_1.m_y >> 3, this.int_10, this.int_21, this.int_21, 0, 0, this.int_22 >> 4, 0, false);
					}
					if (this.GetProjectileData().GetSlowdownDefensePercent() > 0)
					{
						this.m_level.AreaBoost(this.logicVector2_1.m_x >> 3, this.logicVector2_1.m_y >> 3, this.int_10, 0, -this.GetProjectileData().GetSlowdownDefensePercent(), 120);
					}
				}
			}
		}

		// Token: 0x06000E4F RID: 3663 RVA: 0x00034FC8 File Offset: 0x000331C8
		public void UpdateTargetDamage(LogicGameObject target, int damage)
		{
			if (target != null && !this.bool_5 && target.GetHitpointComponent() != null)
			{
				int num = damage;
				if (LogicCombatComponent.IsPreferredTarget(this.logicData_0, target))
				{
					num = damage * this.int_19 / 100;
				}
				if (num >= 0 || (target.GetData().GetDataType() == LogicDataType.HERO && (num = num * LogicDataTables.GetGlobals().GetHeroHealMultiplier() / 100) > 0) || !target.IsPreventsHealing())
				{
					if (this.int_10 <= 0)
					{
						target.GetHitpointComponent().CauseDamage(num, this.int_11, this.logicGameObject_0);
					}
					else
					{
						this.m_level.AreaDamage(this.int_11, target.GetMidX(), target.GetMidY(), this.int_10, damage, this.logicData_0, this.int_19, this.logicEffectData_0, this.int_17, this.logicVector2_4, this.bool_3 ? 0 : 1, 0, this.int_20, this.bool_0, false, 100, 0, this.logicGameObject_0, 100, 0);
					}
				}
				int slowdownDefensePercent = this.GetProjectileData().GetSlowdownDefensePercent();
				if (slowdownDefensePercent > 0 && target.GetGameObjectType() == LogicGameObjectType.BUILDING)
				{
					LogicCombatComponent combatComponent = target.GetCombatComponent();
					if (combatComponent != null)
					{
						combatComponent.Boost(100, -slowdownDefensePercent, 120);
					}
				}
			}
		}

		// Token: 0x06000E50 RID: 3664 RVA: 0x000350F8 File Offset: 0x000332F8
		public void UpdateBounces()
		{
			LogicArrayList<LogicGameObject> gameObjects = base.GetGameObjectManager().GetGameObjects(LogicGameObjectType.BUILDING);
			int num = int.MaxValue;
			int num2 = int.MaxValue;
			LogicBuilding logicBuilding = null;
			LogicBuilding logicBuilding2 = null;
			for (int i = 0; i < gameObjects.Size(); i++)
			{
				LogicBuilding logicBuilding3 = (LogicBuilding)gameObjects[i];
				if (logicBuilding3 != this.logicGameObject_1 && logicBuilding3.IsAlive())
				{
					LogicHitpointComponent hitpointComponent = logicBuilding3.GetHitpointComponent();
					if (hitpointComponent != null && hitpointComponent.IsEnemyForTeam(this.int_17) && !logicBuilding3.IsHidden() && !logicBuilding3.IsWall())
					{
						int distanceSquaredTo = base.GetDistanceSquaredTo(logicBuilding3);
						if (distanceSquaredTo <= 26214400 && distanceSquaredTo < (logicBuilding3.IsWall() ? num2 : num))
						{
							int num3 = -1;
							int j = this.int_7;
							while (j < 4)
							{
								if (this.logicGameObject_2[j] == logicBuilding3)
								{
									num3 = j;
									IL_DC:
									if (num3 != -1 || !this.m_level.GetTileMap().GetWallInPassableLine(this.GetMidX(), this.GetMidY(), logicBuilding3.GetMidX(), logicBuilding3.GetMidY(), new LogicVector2()))
									{
										goto IL_12A;
									}
									if (logicBuilding3.IsWall())
									{
										num2 = distanceSquaredTo;
										logicBuilding2 = logicBuilding3;
										goto IL_12A;
									}
									num = distanceSquaredTo;
									logicBuilding = logicBuilding3;
									goto IL_12A;
								}
								else
								{
									j++;
								}
							}
							goto IL_DC;
						}
					}
				}
				IL_12A:;
			}
			LogicBuilding logicBuilding4 = logicBuilding ?? logicBuilding2;
			if (logicBuilding4 != null)
			{
				this.int_7--;
				this.bool_6 = false;
				this.int_8 /= 2;
				this.SetTarget(this.GetMidX(), this.GetMidY(), this.int_7, logicBuilding4, false);
				this.SetInitialPosition(this.logicGameObject_0, this.GetMidX(), this.GetMidY());
			}
		}

		// Token: 0x06000E51 RID: 3665 RVA: 0x000352A8 File Offset: 0x000334A8
		public void UpdateShockwavePush(int team, int targetType)
		{
			int length = new LogicVector2(this.GetMidX() - this.logicVector2_6.m_x, this.GetMidY() - this.logicVector2_6.m_y).GetLength();
			if (length >= this.int_5)
			{
				int num = length - this.int_6;
				int num2 = length;
				int num3 = length - 512;
				if (num3 < this.int_5)
				{
					num3 = this.int_5;
				}
				uint num4 = (uint)(num3 * num3);
				uint num5 = (uint)(num2 * num2);
				int num6 = this.int_21 * num / this.int_6;
				int time = this.int_22 * num / (16 * this.int_6);
				int shockwaveArcLength = this.GetShockwaveArcLength();
				LogicArrayList<LogicComponent> components = base.GetComponentManager().GetComponents(LogicComponentType.MOVEMENT);
				LogicVector2 logicVector = new LogicVector2();
				for (int i = 0; i < components.Size(); i++)
				{
					LogicMovementComponent logicMovementComponent = (LogicMovementComponent)components[i];
					LogicGameObject parent = logicMovementComponent.GetParent();
					LogicHitpointComponent hitpointComponent = parent.GetHitpointComponent();
					if (!parent.IsHidden() && (hitpointComponent == null || hitpointComponent.GetTeam() != team))
					{
						if (hitpointComponent != null && hitpointComponent.GetParent().IsFlying())
						{
							if (targetType == 1)
							{
								goto IL_220;
							}
						}
						else if (targetType == 0)
						{
							goto IL_220;
						}
						int num7 = parent.GetMidX() - this.logicVector2_6.m_x;
						int num8 = parent.GetMidY() - this.logicVector2_6.m_y;
						if (LogicMath.Abs(num7) <= num2 && LogicMath.Abs(num8) <= num2)
						{
							int num9 = num7 * num7 + num8 * num8;
							if ((long)num9 <= (long)((ulong)num5) && (long)num9 >= (long)((ulong)num4))
							{
								if ((num7 | num8) == 0)
								{
									num7 = 1;
								}
								logicVector.Set(num7, num8);
								int num10 = logicVector.Normalize(512);
								if (LogicMath.Abs(LogicMath.NormalizeAngle180(LogicMath.NormalizeAngle180(logicVector.GetAngle()) - LogicMath.NormalizeAngle180(this.int_13))) < shockwaveArcLength / 2)
								{
									int num11 = 100 * (this.int_6 + 256 - num10) / 512;
									if (num11 > this.int_14)
									{
										num11 = this.int_14;
									}
									logicMovementComponent.GetMovementSystem().ManualPushBack(logicVector, num11, 750, this.m_globalId);
									if (num6 != 0)
									{
										logicMovementComponent.GetMovementSystem().Boost(num6, time);
									}
								}
							}
						}
					}
					IL_220:;
				}
			}
		}

		// Token: 0x06000E52 RID: 3666 RVA: 0x000354EC File Offset: 0x000336EC
		public void UpdatePenetrating(int damageMultiplier)
		{
			LogicVector2 logicVector = new LogicVector2((this.logicVector2_1.m_x >> 3) - this.logicVector2_6.m_x, (this.logicVector2_1.m_y >> 3) - this.logicVector2_6.m_y);
			logicVector.Normalize(512);
			LogicVector2 logicVector2 = new LogicVector2(-logicVector.m_y, logicVector.m_x);
			int value = (200 - this.int_25) * (8 * this.GetSpeed() - 8 * this.int_24) / 200 + 8 * this.int_24 >> 3;
			LogicArrayList<LogicComponent> components = base.GetComponentManager().GetComponents(LogicComponentType.MOVEMENT);
			int i = 0;
			int num = damageMultiplier * this.int_8 / 100;
			while (i < components.Size())
			{
				LogicMovementComponent logicMovementComponent = (LogicMovementComponent)components[i];
				LogicGameObject parent = logicMovementComponent.GetParent();
				LogicHitpointComponent hitpointComponent = parent.GetHitpointComponent();
				if (!parent.IsHidden() && hitpointComponent.GetTeam() != this.int_17 && hitpointComponent.GetHitpoints() > 0)
				{
					int num2 = parent.GetMidX() - this.GetMidX();
					int num3 = parent.GetMidY() - this.GetMidY();
					if (parent.GetGameObjectType() == LogicGameObjectType.CHARACTER)
					{
						num2 += parent.GetWidthInTiles() << 8;
						num3 += parent.GetHeightInTiles() << 8;
					}
					if ((!logicMovementComponent.IsFlying() || this.bool_3) && LogicMath.Abs(num2) <= this.int_18 && LogicMath.Abs(num3) <= this.int_18 && (long)(num2 * num2 + num3 * num3) <= (long)((ulong)(this.int_18 * this.int_18)))
					{
						LogicVector2 logicVector3 = new LogicVector2();
						if (parent.GetGameObjectType() == LogicGameObjectType.CHARACTER && hitpointComponent.GetMaxHitpoints() <= num)
						{
							int num4 = (int)((byte)base.Rand(parent.GetGlobalID()));
							if ((long)num4 > 170L)
							{
								logicVector3.Set((logicVector.m_x >> 2) + logicVector2.m_x, (logicVector.m_y >> 2) + logicVector2.m_y);
							}
							else if (num4 > 85)
							{
								logicVector3.Set(logicVector.m_x, logicVector.m_y);
							}
							else
							{
								logicVector3.Set((logicVector.m_x >> 2) - logicVector2.m_x, (logicVector.m_y >> 2) - logicVector2.m_y);
							}
							if (hitpointComponent.GetInvulnerabilityTime() <= 0)
							{
								((LogicCharacter)parent).Eject(logicVector3);
							}
							logicVector3.Destruct();
						}
						else
						{
							logicVector3.Set(logicVector.m_x, logicVector.m_y);
							logicVector3.Normalize(value);
							if (parent.GetMovementComponent().GetMovementSystem().ManualPushTrap(logicVector3, 150, this.m_globalId) || parent.IsHero())
							{
								this.UpdateTargetDamage(parent, num);
							}
						}
					}
				}
				i++;
			}
			logicVector.Destruct();
			logicVector2.Destruct();
		}

		// Token: 0x06000E53 RID: 3667 RVA: 0x000357C4 File Offset: 0x000339C4
		public override void SubTick()
		{
			base.SubTick();
			this.int_24 = 0;
			bool flag = false;
			int num = 100;
			if (this.int_17 == 1)
			{
				LogicVector2 logicVector = new LogicVector2();
				if (this.m_level.GetAreaShield(this.GetMidX(), this.GetMidY(), logicVector))
				{
					this.int_24 = logicVector.m_x;
					flag = true;
					num = 0;
				}
			}
			if (this.bool_6)
			{
				if (this.int_9 > 0)
				{
					this.UpdateDamage(num);
					return;
				}
			}
			else
			{
				if (this.bool_2 && this.logicGameObject_1 != null && this.logicGameObject_0 != null)
				{
					LogicCombatComponent combatComponent = this.logicGameObject_0.GetCombatComponent();
					if (combatComponent != null && !combatComponent.IsInRange(this.logicGameObject_1))
					{
						this.logicGameObject_1 = null;
					}
				}
				if (flag)
				{
					this.int_25 = LogicMath.Min(this.int_25 + 16, 200);
				}
				else if (this.int_25 > 0)
				{
					this.int_25 = LogicMath.Max(this.int_25 - 4, 0);
				}
				if (this.int_25 == 0)
				{
					if (this.logicGameObject_1 != null && this.logicGameObject_1.GetMovementComponent() != null)
					{
						this.logicVector2_1.Set(this.logicGameObject_1.GetMidX() * 8, this.logicGameObject_1.GetMidY() * 8);
						this.logicVector2_1.Add(this.logicVector2_5);
					}
				}
				else if (this.logicGameObject_1 != null && this.logicGameObject_1.GetMovementComponent() != null)
				{
					int num2 = this.logicVector2_5.m_x + this.logicGameObject_1.GetMidX() * 8;
					int num3 = this.logicVector2_5.m_y + this.logicGameObject_1.GetMidY() * 8;
					LogicVector2 logicVector2 = new LogicVector2(num2 - this.logicVector2_7.m_x, num3 - this.logicVector2_7.m_y);
					LogicVector2 logicVector3 = new LogicVector2(this.logicVector2_3.m_x, this.logicVector2_3.m_y);
					int num4 = logicVector2.Normalize(512);
					logicVector3.Normalize(512);
					int angle = logicVector2.GetAngle();
					int angle2 = logicVector3.GetAngle();
					if (LogicMath.Abs(LogicMath.NormalizeAngle180(angle - angle2)) <= 30)
					{
						this.logicVector2_1.m_x += LogicMath.Clamp(num2 - this.logicVector2_1.m_x, num4 / -500, num4 / 500);
						this.logicVector2_1.m_y += LogicMath.Clamp(num3 - this.logicVector2_1.m_y, num4 / -500, num4 / 500);
					}
					else
					{
						this.logicGameObject_1 = null;
					}
				}
				this.logicVector2_2.m_x = this.logicVector2_1.m_x - this.logicVector2_7.m_x;
				this.logicVector2_2.m_y = this.logicVector2_1.m_y - this.logicVector2_7.m_y;
				int num5 = (200 - this.int_25) * (8 * this.GetSpeed() - 8 * this.int_24) / 200 + 8 * this.int_24;
				if (num5 * num5 >= this.logicVector2_2.GetDistanceSquaredTo(0, 0))
				{
					this.TargetReached(num);
				}
				else
				{
					this.logicVector2_3.m_x = this.logicVector2_2.m_x;
					this.logicVector2_3.m_y = this.logicVector2_2.m_y;
					this.logicVector2_2.Normalize(num5);
					this.logicVector2_7.m_x += this.logicVector2_2.m_x;
					this.logicVector2_7.m_y += this.logicVector2_2.m_y;
					base.SetPositionXY(this.logicVector2_7.m_x >> 3, this.logicVector2_7.m_y >> 3);
					this.logicVector2_4.m_x = this.logicVector2_2.m_x >> 3;
					this.logicVector2_4.m_y = this.logicVector2_2.m_y >> 3;
				}
				if (this.int_14 > 0)
				{
					this.UpdateShockwavePush(this.int_17, this.bool_3 ? 0 : 1);
				}
				if (this.bool_4)
				{
					this.UpdatePenetrating(num);
				}
				this.int_23 += 16;
			}
		}

		// Token: 0x06000E54 RID: 3668 RVA: 0x00035BE4 File Offset: 0x00033DE4
		public void TargetReached(int damagePercent)
		{
			this.int_9 = this.GetProjectileData().GetDamageDelay();
			this.UpdateDamage(damagePercent);
			this.bool_6 = true;
			if (!this.bool_5)
			{
				if (this.logicEffectData_0 != null)
				{
					if (this.logicGameObject_1 != null)
					{
						if (this.logicGameObject_1.GetHitpointComponent() != null && !this.bool_1)
						{
						}
					}
					else if (this.bool_4)
					{
					}
				}
				if (this.logicEffectData_1 != null)
				{
					if (this.logicGameObject_1 != null)
					{
						if (this.logicGameObject_1.GetHitpointComponent() != null && !this.bool_1)
						{
						}
					}
					else if (this.bool_4)
					{
					}
				}
				if (this.logicGameObject_1 != null && this.int_7 > 0)
				{
					this.logicGameObject_2[this.int_7 - 1] = this.logicGameObject_1;
					this.UpdateBounces();
				}
				LogicSpellData hitSpell = this.GetProjectileData().GetHitSpell();
				if (hitSpell != null)
				{
					LogicSpell logicSpell = (LogicSpell)LogicGameObjectFactory.CreateGameObject(hitSpell, this.m_level, this.m_villageType);
					logicSpell.SetUpgradeLevel(this.GetProjectileData().GetHitSpellLevel());
					logicSpell.SetInitialPosition(this.GetMidX(), this.GetMidY());
					logicSpell.SetTeam(1);
					base.GetGameObjectManager().AddGameObject(logicSpell, -1);
				}
				if (this.bool_1)
				{
					int num = -1;
					int i = 0;
					while (i < 4)
					{
						if (this.logicVector2_0[i] == null)
						{
							i++;
						}
						else
						{
							num = i;
							IL_139:
							if (num != -1)
							{
								LogicVector2 logicVector = this.logicVector2_0[num];
								this.logicVector2_0[num] = null;
								this.logicGameObject_1 = null;
								LogicEffectData bounceEffect = this.GetProjectileData().GetBounceEffect();
								if (bounceEffect != null)
								{
									this.m_listener.PlayEffect(bounceEffect);
								}
								this.logicVector2_1.m_x = 8 * logicVector.m_x;
								this.logicVector2_1.m_y = 8 * logicVector.m_y;
								this.int_12 = (this.bool_3 ? 1000 : 0);
								this.bool_6 = false;
								this.int_23 = 0;
								logicVector.Destruct();
								goto IL_1D4;
							}
							this.logicGameObject_1 = null;
							goto IL_1D4;
						}
					}
					goto IL_139;
				}
				IL_1D4:
				if (this.bool_6)
				{
					this.GetProjectileData().GetDestroyedEffect();
				}
			}
		}

		// Token: 0x06000E55 RID: 3669 RVA: 0x00035DDC File Offset: 0x00033FDC
		public int GetSpeed()
		{
			LogicProjectileData projectileData = this.GetProjectileData();
			if (projectileData.GetFixedTravelTime() != 0)
			{
				LogicVector2 logicVector = new LogicVector2();
				logicVector.m_x = this.logicVector2_1.m_x - this.logicVector2_7.m_x >> 3;
				logicVector.m_y = this.logicVector2_1.m_y - this.logicVector2_7.m_y >> 3;
				int num = projectileData.GetFixedTravelTime() - this.int_23;
				int num2 = logicVector.GetLength();
				if (num <= 0)
				{
					num = 1000;
					num2 = projectileData.GetSpeed();
				}
				return 16 * num2 / num;
			}
			return (int)(16L * (long)projectileData.GetSpeed() / 1000L);
		}

		// Token: 0x0400058A RID: 1418
		public const int MAX_BOUNCES = 4;

		// Token: 0x0400058B RID: 1419
		private int int_5;

		// Token: 0x0400058C RID: 1420
		private int int_6;

		// Token: 0x0400058D RID: 1421
		private int int_7;

		// Token: 0x0400058E RID: 1422
		private int int_8;

		// Token: 0x0400058F RID: 1423
		private int int_9;

		// Token: 0x04000590 RID: 1424
		private int int_10;

		// Token: 0x04000591 RID: 1425
		private int int_11;

		// Token: 0x04000592 RID: 1426
		private int int_12;

		// Token: 0x04000593 RID: 1427
		private int int_13;

		// Token: 0x04000594 RID: 1428
		private int int_14;

		// Token: 0x04000595 RID: 1429
		private int int_15;

		// Token: 0x04000596 RID: 1430
		private int int_16;

		// Token: 0x04000597 RID: 1431
		private int int_17;

		// Token: 0x04000598 RID: 1432
		private int int_18;

		// Token: 0x04000599 RID: 1433
		private int int_19;

		// Token: 0x0400059A RID: 1434
		private int int_20;

		// Token: 0x0400059B RID: 1435
		private int int_21;

		// Token: 0x0400059C RID: 1436
		private int int_22;

		// Token: 0x0400059D RID: 1437
		private int int_23;

		// Token: 0x0400059E RID: 1438
		private int int_24;

		// Token: 0x0400059F RID: 1439
		private int int_25;

		// Token: 0x040005A0 RID: 1440
		private bool bool_0;

		// Token: 0x040005A1 RID: 1441
		private bool bool_1;

		// Token: 0x040005A2 RID: 1442
		private bool bool_2;

		// Token: 0x040005A3 RID: 1443
		private bool bool_3;

		// Token: 0x040005A4 RID: 1444
		private bool bool_4;

		// Token: 0x040005A5 RID: 1445
		private bool bool_5;

		// Token: 0x040005A6 RID: 1446
		private bool bool_6;

		// Token: 0x040005A7 RID: 1447
		private LogicGameObject logicGameObject_0;

		// Token: 0x040005A8 RID: 1448
		private LogicGameObject logicGameObject_1;

		// Token: 0x040005A9 RID: 1449
		private LogicData logicData_0;

		// Token: 0x040005AA RID: 1450
		private LogicEffectData logicEffectData_0;

		// Token: 0x040005AB RID: 1451
		private LogicEffectData logicEffectData_1;

		// Token: 0x040005AC RID: 1452
		private readonly LogicGameObject[] logicGameObject_2;

		// Token: 0x040005AD RID: 1453
		private readonly LogicVector2[] logicVector2_0;

		// Token: 0x040005AE RID: 1454
		private readonly LogicVector2 logicVector2_1;

		// Token: 0x040005AF RID: 1455
		private readonly LogicVector2 logicVector2_2;

		// Token: 0x040005B0 RID: 1456
		private readonly LogicVector2 logicVector2_3;

		// Token: 0x040005B1 RID: 1457
		private readonly LogicVector2 logicVector2_4;

		// Token: 0x040005B2 RID: 1458
		private readonly LogicVector2 logicVector2_5;

		// Token: 0x040005B3 RID: 1459
		private readonly LogicVector2 logicVector2_6;

		// Token: 0x040005B4 RID: 1460
		private readonly LogicVector2 logicVector2_7;
	}
}
