using System;
using Atrasis.Magic.Logic.Calendar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.GameObject.Component
{
	// Token: 0x02000127 RID: 295
	public sealed class LogicMovementComponent : LogicComponent
	{
		// Token: 0x06000FC7 RID: 4039 RVA: 0x00043BFC File Offset: 0x00041DFC
		public LogicMovementComponent(LogicGameObject gameObject, int speed, bool flying, bool underground) : base(gameObject)
		{
			this.logicVector2_0 = new LogicVector2();
			this.logicMovementSystem_0 = new LogicMovementSystem();
			this.int_6 = -1;
			this.int_7 = -1;
			if (underground)
			{
				int minerSpeedRandomPercentage = LogicDataTables.GetGlobals().GetMinerSpeedRandomPercentage();
				if (minerSpeedRandomPercentage > 0)
				{
					speed = speed * (gameObject.Rand(100) % minerSpeedRandomPercentage + 100) / 100;
				}
			}
			this.logicMovementSystem_0.Init(speed, this, null);
			this.bool_6 = flying;
			this.bool_5 = underground;
		}

		// Token: 0x06000FC8 RID: 4040 RVA: 0x0000ABE1 File Offset: 0x00008DE1
		public void SetSpeed(int speed)
		{
			this.logicMovementSystem_0.SetSpeed(speed);
		}

		// Token: 0x06000FC9 RID: 4041 RVA: 0x0000ABEF File Offset: 0x00008DEF
		public void SetUnderground(bool value)
		{
			this.bool_5 = value;
		}

		// Token: 0x06000FCA RID: 4042 RVA: 0x0000ABF8 File Offset: 0x00008DF8
		public override void RemoveGameObjectReferences(LogicGameObject gameObject)
		{
			base.RemoveGameObjectReferences(gameObject);
			if (this.logicBuilding_0 == gameObject)
			{
				this.logicBuilding_0 = null;
			}
		}

		// Token: 0x06000FCB RID: 4043 RVA: 0x0000AC11 File Offset: 0x00008E11
		public LogicBuilding GetBaseBuilding()
		{
			return this.logicBuilding_0;
		}

		// Token: 0x06000FCC RID: 4044 RVA: 0x0000AC19 File Offset: 0x00008E19
		public void SetBaseBuilding(LogicBuilding building)
		{
			this.logicBuilding_0 = building;
		}

		// Token: 0x06000FCD RID: 4045 RVA: 0x00043C78 File Offset: 0x00041E78
		public int GetClosestPatrolPoint(int x, int y, LogicArrayList<LogicVector2> patrolPath)
		{
			int num = -1;
			int result = 0;
			for (int i = 0; i < patrolPath.Size(); i++)
			{
				int distanceSquaredTo = patrolPath[i].GetDistanceSquaredTo(x, y);
				if (distanceSquaredTo < num || num < 0)
				{
					result = i;
					num = distanceSquaredTo;
				}
			}
			return result;
		}

		// Token: 0x06000FCE RID: 4046 RVA: 0x00043CB8 File Offset: 0x00041EB8
		public int EvaluateTargetCost(LogicGameObject target)
		{
			LogicMovementComponent movementComponent = target.GetMovementComponent();
			bool flag = true;
			if (movementComponent == null)
			{
				flag = (target.GetGameObjectType() == LogicGameObjectType.CHARACTER && ((LogicCharacter)target).GetParent() != null);
			}
			if (this.bool_6 || this.bool_5 || !flag || movementComponent == null || !movementComponent.bool_1)
			{
				this.MoveTo(target);
				if (this.int_0 <= 0 || flag || this.m_parent.GetLevel().GetTileMap().IsPassablePathFinder(this.int_6 >> 8, this.int_7 >> 8))
				{
					this.int_1 = this.logicMovementSystem_0.GetWallCount();
					if (this.int_1 > 0 && this.m_parent.GetHitpointComponent().GetTeam() == 1 && this.int_0 <= 0)
					{
						return int.MaxValue;
					}
					int num = LogicDataTables.GetGlobals().UseWallWeightsForJumpSpell() ? 10000 : 0;
					int num2 = (this.int_0 <= num) ? (3584 * this.int_1) : 0;
					return this.logicMovementSystem_0.GetPathLength() + num2;
				}
			}
			return int.MaxValue;
		}

		// Token: 0x06000FCF RID: 4047 RVA: 0x00043DC8 File Offset: 0x00041FC8
		public bool EnableUnderground()
		{
			if (this.m_parent.GetGameObjectType() == LogicGameObjectType.CHARACTER)
			{
				LogicCharacter logicCharacter = (LogicCharacter)this.m_parent;
				if (logicCharacter.GetCharacterData().IsUnderground() && logicCharacter.GetHitpointComponent().GetTeam() == 0)
				{
					this.m_parent.GetCombatComponent().SetUndergroundTime(3600000);
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000FD0 RID: 4048 RVA: 0x00043E24 File Offset: 0x00042024
		public void EnableJump(int ms)
		{
			if ((this.m_parent.GetGameObjectType() != LogicGameObjectType.CHARACTER || !((LogicCharacter)this.m_parent).GetCharacterData().IsUnderground() || this.m_parent.GetHitpointComponent().GetTeam() != 0) && !this.bool_6)
			{
				if (this.int_0 <= 0)
				{
					this.m_parent.GetCombatComponent().ForceNewTarget();
				}
				this.int_0 = ms;
			}
		}

		// Token: 0x06000FD1 RID: 4049 RVA: 0x0000AC22 File Offset: 0x00008E22
		public bool IsFlying()
		{
			return this.bool_6;
		}

		// Token: 0x06000FD2 RID: 4050 RVA: 0x0000AC2A File Offset: 0x00008E2A
		public void SetFlying(bool value)
		{
			this.bool_6 = value;
		}

		// Token: 0x06000FD3 RID: 4051 RVA: 0x0000AC33 File Offset: 0x00008E33
		public bool IsInNotPassablePosition()
		{
			return this.bool_1;
		}

		// Token: 0x06000FD4 RID: 4052 RVA: 0x0000AC3B File Offset: 0x00008E3B
		public bool GetPatrolEnabled()
		{
			return this.bool_2;
		}

		// Token: 0x06000FD5 RID: 4053 RVA: 0x0000AC43 File Offset: 0x00008E43
		public bool IsUnderground()
		{
			return this.bool_5;
		}

		// Token: 0x06000FD6 RID: 4054 RVA: 0x0000AC4B File Offset: 0x00008E4B
		public int GetJump()
		{
			return this.int_0;
		}

		// Token: 0x06000FD7 RID: 4055 RVA: 0x0000AC53 File Offset: 0x00008E53
		public bool CanJumpWall()
		{
			return this.int_0 > (LogicDataTables.GetGlobals().UseWallWeightsForJumpSpell() ? 10000 : 0);
		}

		// Token: 0x06000FD8 RID: 4056 RVA: 0x0000AC71 File Offset: 0x00008E71
		public LogicMovementSystem GetMovementSystem()
		{
			return this.logicMovementSystem_0;
		}

		// Token: 0x06000FD9 RID: 4057 RVA: 0x00043E90 File Offset: 0x00042090
		public void UpdatePoisonAvoidance()
		{
			if (this.logicMovementSystem_0.NotMoving())
			{
				LogicHitpointComponent hitpointComponent = this.m_parent.GetHitpointComponent();
				if (hitpointComponent != null && hitpointComponent.GetPoisonRemainingMS() > 0)
				{
					this.InitRandom();
					int midX = this.m_parent.GetMidX();
					int midY = this.m_parent.GetMidY();
					LogicTileMap tileMap = this.m_parent.GetLevel().GetTileMap();
					for (int i = 0; i < 25; i++)
					{
						int num = this.logicRandom_0.Rand(i << 8);
						int angle = this.logicRandom_0.Rand(360);
						int num2 = midX + (num * LogicMath.Sin(angle) >> 10);
						int num3 = midY + (num * LogicMath.Cos(angle) >> 10);
						if (tileMap.IsPassablePathFinder(num2 >> 8, num3 >> 8))
						{
							LogicArrayList<LogicGameObject> gameObjects = this.m_parent.GetGameObjectManager().GetGameObjects(LogicGameObjectType.SPELL);
							bool flag = true;
							int j = 0;
							while (j < gameObjects.Size())
							{
								LogicSpell logicSpell = (LogicSpell)gameObjects[j];
								LogicSpellData spellData = logicSpell.GetSpellData();
								int radius = spellData.GetRadius(logicSpell.GetUpgradeLevel());
								int num4 = num2 - logicSpell.GetMidX();
								int num5 = num3 - logicSpell.GetMidY();
								if ((long)(num4 * num4 + num5 * num5) >= (long)((ulong)(radius * radius)) || spellData.GetPoisonDamage(0) <= 0)
								{
									j++;
								}
								else
								{
									flag = false;
									IL_149:
									if (!flag)
									{
										goto IL_14D;
									}
									this.MoveTo(num2, num3);
									return;
								}
							}
							goto IL_149;
						}
						IL_14D:;
					}
				}
			}
		}

		// Token: 0x06000FDA RID: 4058 RVA: 0x00044008 File Offset: 0x00042208
		public override void Tick()
		{
			LogicCombatComponent combatComponent = this.m_parent.GetCombatComponent();
			if (!combatComponent.GetUnk596() && combatComponent.GetTarget(0) == null && !this.bool_1 && !this.bool_2 && combatComponent.GetUndergroundTime() <= 0)
			{
				if (LogicDataTables.GetGlobals().UsePoisonAvoidance())
				{
					LogicHitpointComponent hitpointComponent = this.m_parent.GetHitpointComponent();
					if (hitpointComponent != null && hitpointComponent.GetPoisonRemainingMS() > 0 && hitpointComponent.GetTeam() == 1 && !this.m_parent.IsFrozen())
					{
						this.UpdatePoisonAvoidance();
					}
					else
					{
						this.bool_0 = false;
						this.logicMovementSystem_0.ClearPath();
					}
				}
				else
				{
					this.bool_0 = false;
					this.logicMovementSystem_0.ClearPath();
				}
			}
			if (this.bool_0 && this.int_3 > 0)
			{
				if (this.bool_1)
				{
					this.int_3 = LogicMath.Max(this.int_3 - 64, 1);
				}
				else
				{
					this.int_3 = LogicMath.Max(this.int_3 - 64, 0);
					if (this.int_3 <= 0)
					{
						this.NewTargetFound();
					}
				}
			}
			if (!this.logicMovementSystem_0.NotMoving())
			{
				this.CheckTriggers();
			}
			if (this.bool_2 && this.logicBuilding_0 != null && (this.logicBuilding_0.GetHeroBaseComponent() != null || this.logicBuilding_0.GetBunkerComponent() != null))
			{
				if (!this.bool_1 && this.logicMovementSystem_0.GetDistSqToEnd() <= 65535)
				{
					this.logicMovementSystem_0.ClearPath();
					if (this.bool_3)
					{
						int x = this.int_8 - this.m_parent.GetMidX();
						int y = this.int_9 - this.m_parent.GetMidY();
						this.logicMovementSystem_0.SetDirection(LogicMath.GetAngle(x, y));
						if (this.bool_4)
						{
							this.bool_4 = false;
						}
					}
					this.int_2 += 64;
				}
				if (this.int_2 > 2000)
				{
					this.int_2 = 0;
					if (!this.m_parent.IsHero())
					{
						this.int_2 = LogicMath.Clamp(30 * this.logicMovementSystem_0.GetSpeed() - 100, 0, 800) + (int)((byte)this.m_parent.GetCombatComponent().Rand(this.m_parent.GetX()));
					}
					LogicArrayList<LogicVector2> logicArrayList = (this.logicBuilding_0.GetHeroBaseComponent() != null) ? this.logicBuilding_0.GetHeroBaseComponent().GetPatrolPath() : ((this.logicBuilding_0.GetBunkerComponent() != null) ? this.logicBuilding_0.GetBunkerComponent().GetPatrolPath() : null);
					int num;
					if (this.bool_3)
					{
						num = this.GetClosestPatrolPoint(this.int_8, this.int_9, logicArrayList);
					}
					else if (this.m_parent.IsHero())
					{
						num = this.GetClosestPatrolPoint(this.m_parent.GetPosition().m_x, this.m_parent.GetPosition().m_y, logicArrayList) + 1;
					}
					else
					{
						if (this.logicRandom_0 == null)
						{
							this.logicRandom_0 = new LogicRandom();
							this.logicRandom_0.SetIteratedRandomSeed(this.m_parent.GetGlobalID());
						}
						num = this.logicRandom_0.Rand(logicArrayList.Size());
					}
					if (num < 0)
					{
						num = logicArrayList.Size() - 1;
					}
					if (num >= logicArrayList.Size())
					{
						num = 0;
					}
					for (int i = 0; i < logicArrayList.Size(); i++)
					{
						int num2 = (num + i) % logicArrayList.Size();
						if (num2 != this.int_5 && logicArrayList[num2].GetDistanceSquared(this.m_parent.GetPosition()) > 65536)
						{
							this.int_5 = num2;
							this.MoveToPoint(logicArrayList[num2]);
							return;
						}
					}
				}
			}
		}

		// Token: 0x06000FDB RID: 4059 RVA: 0x0004439C File Offset: 0x0004259C
		public override void SubTick()
		{
			LogicCombatComponent combatComponent = this.m_parent.GetCombatComponent();
			if (combatComponent.GetAttackFinished() && this.bool_0)
			{
				LogicVector2 position = this.logicMovementSystem_0.GetPosition();
				if (this.bool_6 || this.m_parent.GetLevel().GetTileMap().IsPassablePathFinder(position.m_x >> 8, position.m_y >> 8))
				{
					LogicGameObject target = combatComponent.GetTarget(0);
					if (target != null)
					{
						this.logicMovementSystem_0.SetDirection(LogicMath.GetAngle(target.GetMidX() - position.m_x, target.GetMidY() - position.m_y));
						this.logicMovementSystem_0.ClearPath();
						if (target.GetMovementComponent() == null && (target.GetGameObjectType() != LogicGameObjectType.CHARACTER || ((LogicCharacter)target).GetParent() == null))
						{
							this.bool_0 = false;
						}
						else
						{
							this.int_3 = 100;
						}
					}
					else
					{
						this.logicMovementSystem_0.ClearPath();
						this.bool_0 = false;
					}
				}
			}
			if (this.m_parent.IsAlive())
			{
				this.logicMovementSystem_0.SubTick();
				if (this.int_0 > 0)
				{
					LogicVector2 position2 = this.logicMovementSystem_0.GetPosition();
					bool flag = this.m_parent.GetLevel().GetTileMap().IsPassablePathFinder(position2.m_x >> 8, position2.m_y >> 8);
					this.int_0 = LogicMath.Max(this.int_0 - 16, 0);
					this.bool_1 = !flag;
					if (this.int_0 == 0)
					{
						if (flag)
						{
							this.m_parent.GetCombatComponent().ForceNewTarget();
							return;
						}
						this.int_0 = 1;
					}
				}
			}
		}

		// Token: 0x06000FDC RID: 4060 RVA: 0x00044528 File Offset: 0x00042728
		public void CheckTriggers()
		{
			if (this.m_parent.GetGameObjectType() == LogicGameObjectType.CHARACTER && !((LogicCharacter)this.m_parent).GetCharacterData().GetTriggersTraps())
			{
				return;
			}
			LogicVector2 position = this.logicMovementSystem_0.GetPosition();
			for (int i = -1; i < 2; i++)
			{
				for (int j = -1; j < 2; j++)
				{
					LogicTile tile = this.m_parent.GetLevel().GetTileMap().GetTile((position.m_x >> 9) + i, (position.m_y >> 9) + j);
					if (tile != null)
					{
						for (int k = 0; k < tile.GetGameObjectCount(); k++)
						{
							LogicGameObject gameObject = tile.GetGameObject(k);
							if (!this.logicMovementSystem_0.IsPushed() || !this.logicMovementSystem_0.IgnorePush())
							{
								LogicTriggerComponent triggerComponent = gameObject.GetTriggerComponent();
								if (triggerComponent != null && !triggerComponent.IsTriggeredByRadius())
								{
									triggerComponent.ObjectClose(this.m_parent);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06000FDD RID: 4061 RVA: 0x00044618 File Offset: 0x00042818
		public void NewTargetFound()
		{
			LogicGameObject target = this.m_parent.GetCombatComponent().GetTarget(0);
			if (target != null && (LogicDataTables.GetGlobals().RepathDuringFly() || !this.logicMovementSystem_0.IsPushed() || !this.logicMovementSystem_0.IgnorePush()))
			{
				if (this.m_parent.GetCombatComponent().IsInRange(target))
				{
					this.bool_0 = true;
					this.bool_2 = false;
					this.bool_3 = false;
					this.int_6 = this.m_parent.GetMidX();
					this.int_7 = this.m_parent.GetMidY();
					this.logicMovementSystem_0.AddPoint(this.int_6, this.int_7);
					this.logicMovementSystem_0.SetDirection(LogicMath.GetAngle(target.GetMidX() - this.m_parent.GetMidX(), target.GetMidY() - this.m_parent.GetMidY()));
					if (target.GetMovementComponent() != null)
					{
						this.int_3 = 1;
						return;
					}
					if (target.GetGameObjectType() == LogicGameObjectType.CHARACTER)
					{
						this.int_3 = ((((LogicCharacter)target).GetParent() != null) ? 1 : 0);
						return;
					}
				}
				else
				{
					this.MoveTo(target);
					LogicGameObject wall = this.logicMovementSystem_0.GetWall();
					if (wall != null && this.int_0 <= 0 && (!wall.IsWall() || ((LogicBuilding)wall).GetHitWallDelay() <= 0))
					{
						this.m_parent.GetCombatComponent().ObstacleToDestroy(wall);
						this.int_3 = 0;
					}
				}
			}
		}

		// Token: 0x06000FDE RID: 4062 RVA: 0x0004477C File Offset: 0x0004297C
		public void NoTargetFound()
		{
			LogicHitpointComponent hitpointComponent = this.m_parent.GetHitpointComponent();
			if (hitpointComponent == null || hitpointComponent.GetTeam() != 0)
			{
				LogicGameObject patrolPost = this.logicMovementSystem_0.GetPatrolPost();
				if (patrolPost != null)
				{
					LogicCalendarBuildingDestroyedSpawnUnit buildingDestroyedSpawnUnit = this.m_parent.GetLevel().GetCalendar().GetBuildingDestroyedSpawnUnit();
					LogicBuildingData logicBuildingData = (buildingDestroyedSpawnUnit != null) ? buildingDestroyedSpawnUnit.GetBuildingData() : null;
					if (patrolPost.GetDefenceUnitProduction() != null || patrolPost.GetData() == logicBuildingData)
					{
						this.logicMovementSystem_0.UpdatePatrolArea(this.m_parent.GetLevel());
						this.bool_2 = true;
					}
				}
				if (LogicDataTables.GetGlobals().AllianceTroopsPatrol() || this.m_parent.IsHero())
				{
					bool flag = this.bool_2;
					this.bool_2 = true;
					if (this.logicBuilding_0 != null)
					{
						LogicHeroBaseComponent heroBaseComponent = this.logicBuilding_0.GetHeroBaseComponent();
						if (heroBaseComponent != null)
						{
							LogicHeroData heroData = heroBaseComponent.GetHeroData();
							LogicAttackerItemData attackerItemData = heroData.GetAttackerItemData(((LogicCharacter)this.m_parent).GetUpgradeLevel());
							LogicArrayList<LogicGameObject> gameObjects = this.m_parent.GetGameObjectManager().GetGameObjects(LogicGameObjectType.CHARACTER);
							int num = heroData.GetAlertRadius() >> 9;
							int num2 = num * num;
							uint num3 = uint.MaxValue;
							LogicGameObject logicGameObject = null;
							for (int i = 0; i < gameObjects.Size(); i++)
							{
								LogicCharacter logicCharacter = (LogicCharacter)gameObjects[i];
								LogicHitpointComponent hitpointComponent2 = logicCharacter.GetHitpointComponent();
								if ((hitpointComponent2 == null || hitpointComponent2.GetTeam() != 1) && (attackerItemData.GetTrackAirTargets(false) || !logicCharacter.IsFlying()) && logicCharacter.IsAlive())
								{
									int num4 = logicCharacter.GetMidX() - this.logicBuilding_0.GetMidX() >> 9;
									int num5 = logicCharacter.GetMidY() - this.logicBuilding_0.GetMidY() >> 9;
									uint num6 = (uint)(num4 * num4 + num5 * num5);
									if ((ulong)num6 < (ulong)((long)num2) && num3 > num6)
									{
										num3 = num6;
										logicGameObject = logicCharacter;
									}
								}
							}
							bool flag2 = this.bool_3;
							this.bool_3 = (logicGameObject != null);
							if (logicGameObject != null && flag && !flag2)
							{
								this.bool_4 = true;
							}
							if (logicGameObject != null)
							{
								this.int_8 = logicGameObject.GetMidX();
								this.int_9 = logicGameObject.GetMidY();
							}
							if (!flag)
							{
								this.logicMovementSystem_0.ClearPath();
							}
						}
					}
				}
			}
		}

		// Token: 0x06000FDF RID: 4063 RVA: 0x00044990 File Offset: 0x00042B90
		public void MoveTo(LogicGameObject gameObject)
		{
			this.EnableUnderground();
			this.bool_0 = true;
			LogicMovementComponent movementComponent = gameObject.GetMovementComponent();
			if ((movementComponent == null && gameObject.GetGameObjectType() != LogicGameObjectType.CHARACTER) || (movementComponent == null && ((LogicCharacter)gameObject).GetParent() == null))
			{
				if (this.bool_2)
				{
					this.m_parent.GetListener().SpottedEnemy();
				}
				this.bool_3 = false;
				this.bool_2 = false;
				if (this.FindGoodAttackPosAround(gameObject, this.GetAttackDist(), false))
				{
					if (!this.bool_5 && !this.bool_6)
					{
						this.logicMovementSystem_0.MoveTo(this.int_6, this.int_7, this.m_parent.GetLevel().GetTileMap(), true);
					}
					else
					{
						this.logicMovementSystem_0.AddPoint(this.int_6, this.int_7);
					}
				}
				this.int_3 = 0;
				return;
			}
			if (this.bool_2)
			{
				this.m_parent.GetListener().SpottedEnemy();
			}
			this.bool_2 = false;
			this.bool_3 = false;
			if (this.FindGoodAttackPosAround(gameObject, this.GetAttackDist(), false))
			{
				if (!this.bool_5 && !this.bool_6)
				{
					this.logicMovementSystem_0.MoveTo(this.int_6, this.int_7, this.m_parent.GetLevel().GetTileMap(), true);
				}
				else
				{
					this.logicMovementSystem_0.AddPoint(this.int_6, this.int_7);
				}
				this.int_3 = LogicMath.Max(250 * this.logicMovementSystem_0.GetPathLength() / 512, 1);
				return;
			}
			this.int_3 = 1000;
			this.logicMovementSystem_0.ClearPath();
		}

		// Token: 0x06000FE0 RID: 4064 RVA: 0x00044B28 File Offset: 0x00042D28
		public void MoveTo(int x, int y)
		{
			this.EnableUnderground();
			this.bool_0 = true;
			if (this.bool_2)
			{
				this.m_parent.GetListener().SpottedEnemy();
			}
			this.bool_2 = false;
			this.bool_3 = false;
			if (!this.bool_5 && !this.bool_6)
			{
				LogicTileMap tileMap = this.m_parent.GetLevel().GetTileMap();
				if (tileMap.IsPassablePathFinder(x >> 8, y >> 8))
				{
					this.logicMovementSystem_0.MoveTo(x, y, tileMap, true);
				}
				else
				{
					LogicVector2 logicVector = new LogicVector2();
					if (!tileMap.GetNearestPassablePosition(x, y, logicVector, 512) && !tileMap.GetNearestPassablePosition(x, y, logicVector, 1536))
					{
						this.logicMovementSystem_0.ClearPath();
					}
					else
					{
						this.logicMovementSystem_0.MoveTo(logicVector.m_x, logicVector.m_y, tileMap, true);
					}
				}
			}
			else
			{
				this.logicMovementSystem_0.AddPoint(x, y);
			}
			this.int_3 = 0;
		}

		// Token: 0x06000FE1 RID: 4065 RVA: 0x00044C14 File Offset: 0x00042E14
		public bool FindGoodAttackPosAround(LogicGameObject target, int attackDistance, bool doNotOverride)
		{
			LogicCombatComponent combatComponent = this.m_parent.GetCombatComponent();
			if (combatComponent.IsInRange(target))
			{
				this.int_6 = this.m_parent.GetMidX();
				this.int_7 = this.m_parent.GetMidY();
				return true;
			}
			if (this.bool_6)
			{
				int midX = target.GetMidX();
				int midY = target.GetMidY();
				if (target.GetMovementComponent() != null)
				{
					this.logicVector2_0.m_x = this.m_parent.GetMidX() - midX;
					this.logicVector2_0.m_y = this.m_parent.GetMidY() - midY;
					this.logicVector2_0.Normalize(attackDistance);
				}
				else
				{
					int angleA = combatComponent.Rand(29) % 360;
					this.logicVector2_0.m_x = LogicMath.Sin(angleA, attackDistance);
					this.logicVector2_0.m_y = LogicMath.Cos(angleA, attackDistance);
				}
				this.int_6 = midX + this.logicVector2_0.m_x;
				this.int_7 = midY + this.logicVector2_0.m_y;
				return true;
			}
			this.int_4 = 7;
			if (target.IsWall())
			{
				this.int_4 = 0;
			}
			if (this.m_parent.IsHero() && !LogicDataTables.GetGlobals().HeroUsesAttackPosRandom())
			{
				this.int_4 = 0;
			}
			if (this.m_parent.GetCombatComponent().GetTotalTargets() == 0 && !LogicDataTables.GetGlobals().UseAttackPosRandomOn1stTarget())
			{
				this.int_4 = 0;
			}
			bool attackOverWalls = true;
			if (this.m_parent.GetGameObjectType() == LogicGameObjectType.CHARACTER)
			{
				LogicCharacter logicCharacter = (LogicCharacter)this.m_parent;
				if (logicCharacter.IsWallBreaker())
				{
					this.int_4 = 0;
				}
				attackOverWalls = logicCharacter.GetCharacterData().GetAttackOverWalls();
			}
			this.long_0 = long.MaxValue;
			this.int_6 = -1;
			this.int_7 = -1;
			int num = (target.GetWidthInTiles() << 8) - (target.PassableSubtilesAtEdge() << 8);
			int num2 = (target.GetHeightInTiles() << 8) - (target.PassableSubtilesAtEdge() << 8);
			bool flag = this.ProcessLine(attackDistance, 0, num2 + attackDistance, num, num2 + attackDistance, target, doNotOverride, false, attackOverWalls);
			bool flag2 = this.ProcessLine(attackDistance, num, num2, target, doNotOverride, true, attackOverWalls);
			bool flag3 = this.ProcessLine(attackDistance, num + attackDistance, num2, num + attackDistance, 0, target, doNotOverride, false, attackOverWalls);
			if (flag && flag2 && flag3)
			{
				int midX2 = target.GetMidX();
				int midY2 = target.GetMidY();
				LogicTileMap tileMap = target.GetLevel().GetTileMap();
				LogicVector2 logicVector = new LogicVector2();
				if (tileMap.GetWallInPassableLine(midX2, midY2, this.m_parent.GetMidX(), this.m_parent.GetMidY(), logicVector))
				{
					int num3 = logicVector.m_x - midX2;
					int num4 = logicVector.m_y - midY2;
					int num5 = target.GetWidthInTiles() << 8;
					int num6 = target.GetHeightInTiles() << 8;
					int num7;
					if (num3 >= num5)
					{
						num7 = num3 - num5;
					}
					else
					{
						num7 = num3 + num5;
						if (num7 > -num5)
						{
							num7 = 0;
						}
					}
					int num8;
					if (num4 >= num6)
					{
						num8 = num4 - num6;
					}
					else
					{
						num8 = num4 + num6;
						if (num8 > -num6)
						{
							num8 = 0;
						}
					}
					if ((long)(num7 * num7 + num8 * num8) > (long)((ulong)(attackDistance * attackDistance)))
					{
						LogicVector2 logicVector2 = new LogicVector2();
						logicVector2.Set(num7, num8);
						logicVector2.Normalize(attackDistance);
						logicVector.Set(logicVector2.m_x + midX2, logicVector2.m_y + midY2);
					}
					this.long_0 = (long)((logicVector.m_x - this.m_parent.GetMidX()) * (logicVector.m_x - this.m_parent.GetMidX()) + (logicVector.m_y - this.m_parent.GetMidY()) * (logicVector.m_y - this.m_parent.GetMidY()));
					if (tileMap.GetNearestPassablePosition(logicVector.m_x, logicVector.m_y, logicVector, LogicDataTables.GetGlobals().UseNewPathFinder() ? 512 : 256))
					{
						this.int_6 = logicVector.m_x;
						this.int_7 = logicVector.m_y;
					}
					else
					{
						this.int_6 = -1;
						this.int_7 = -1;
					}
				}
			}
			return this.int_6 != -1;
		}

		// Token: 0x06000FE2 RID: 4066 RVA: 0x00044FF0 File Offset: 0x000431F0
		public bool ProcessLine(int radius, int startX, int startY, int destX, int destY, LogicGameObject gameObject, bool doNotOverride, bool ignoreNearestBuildings, bool attackOverWalls)
		{
			if (doNotOverride && this.int_6 != -1)
			{
				return false;
			}
			LogicVector2 position = this.logicMovementSystem_0.GetPosition();
			LogicCombatComponent combatComponent = this.m_parent.GetCombatComponent();
			if (combatComponent.GetTargetGroupPosition() != null)
			{
				position = combatComponent.GetTargetGroupPosition();
			}
			int midX = gameObject.GetMidX();
			int midY = gameObject.GetMidY();
			int num = LogicMath.Sqrt((destX - startX) * (destX - startX) + (destY - startY) * (destY - startY));
			int num2 = LogicMath.Max(1, (int)((long)num + (long)((ulong)((uint)(num + 256 >> 31) >> 23)) + 256L) >> 9);
			LogicTileMap tileMap = this.m_parent.GetLevel().GetTileMap();
			int num3 = destX - startX;
			int num4 = destY - startY;
			bool result = true;
			for (int i = 0; i < num2; i++)
			{
				int num5 = startX + num3 / num2 / 2;
				int num6 = startY + num4 / num2 / 2;
				bool flag = this.CheckIfCloser(gameObject, radius, position, midX, midY, num5, num6, tileMap, ignoreNearestBuildings, attackOverWalls);
				bool flag2 = this.CheckIfCloser(gameObject, radius, position, midX, midY, -num5, num6, tileMap, ignoreNearestBuildings, attackOverWalls);
				bool flag3 = this.CheckIfCloser(gameObject, radius, position, midX, midY, num5, -num6, tileMap, ignoreNearestBuildings, attackOverWalls);
				bool flag4 = this.CheckIfCloser(gameObject, radius, position, midX, midY, -num5, -num6, tileMap, ignoreNearestBuildings, attackOverWalls);
				result = (flag && flag2 && flag3 && flag4);
				if (doNotOverride && this.int_6 != -1)
				{
					break;
				}
				num3 += 2 * destX - 2 * startX;
				num4 += 2 * destY - 2 * startY;
			}
			return result;
		}

		// Token: 0x06000FE3 RID: 4067 RVA: 0x0004516C File Offset: 0x0004336C
		public bool ProcessLine(int radius, int startX, int startY, LogicGameObject gameObject, bool doNotOverride, bool ignoreNearestBuildings, bool attackOverWalls)
		{
			if (doNotOverride && this.int_6 != -1)
			{
				return false;
			}
			LogicVector2 position = this.logicMovementSystem_0.GetPosition();
			LogicCombatComponent combatComponent = this.m_parent.GetCombatComponent();
			if (combatComponent.GetTargetGroupPosition() != null)
			{
				position = combatComponent.GetTargetGroupPosition();
			}
			int midX = gameObject.GetMidX();
			int midY = gameObject.GetMidY();
			int num = LogicMath.Max(1, (int)((ulong)((uint)(157 * radius / 100 + 256 >> 31) >> 23) + (ulong)((long)(157 * radius / 100)) + 256UL) >> 9);
			LogicTileMap tileMap = this.m_parent.GetLevel().GetTileMap();
			int num2 = 900 / num;
			bool result = true;
			int i = 0;
			int num3 = num2 / 2;
			while (i < num)
			{
				int num4 = startX + LogicMath.Cos(num3 / 10, radius);
				int num5 = startY + LogicMath.Sin(num3 / 10, radius);
				bool flag = this.CheckIfCloser(gameObject, radius, position, midX, midY, num4, num5, tileMap, ignoreNearestBuildings, attackOverWalls);
				bool flag2 = this.CheckIfCloser(gameObject, radius, position, midX, midY, -num4, num5, tileMap, ignoreNearestBuildings, attackOverWalls);
				bool flag3 = this.CheckIfCloser(gameObject, radius, position, midX, midY, num4, -num5, tileMap, ignoreNearestBuildings, attackOverWalls);
				bool flag4 = this.CheckIfCloser(gameObject, radius, position, midX, midY, -num4, -num5, tileMap, ignoreNearestBuildings, attackOverWalls);
				result = (flag && flag2 && flag3 && flag4);
				if (doNotOverride && this.int_6 != -1)
				{
					break;
				}
				i++;
				num3 += num2;
			}
			return result;
		}

		// Token: 0x06000FE4 RID: 4068 RVA: 0x000452D8 File Offset: 0x000434D8
		public bool CheckIfCloser(LogicGameObject gameObject, int radius, LogicVector2 position, int midX, int midY, int offsetX, int offsetY, LogicTileMap tileMap, bool ignoreNearestBuildings, bool attackOverWalls)
		{
			int num = midX + offsetX;
			int num2 = midY + offsetY;
			int num3 = num >> 8;
			int num4 = num2 >> 8;
			int num5 = tileMap.GetSizeX() * 2;
			int num6 = tileMap.GetSizeY() * 2;
			if (num3 < num5 && num4 < num6 && (num3 | num4) >= 0)
			{
				long num7 = 0L;
				if (!this.bool_6 && !this.bool_5)
				{
					int pathFinderCost = tileMap.GetPathFinderCost(num3, num4);
					if (pathFinderCost == 2147483647)
					{
						return true;
					}
					if (pathFinderCost > 0)
					{
						num7 = (long)num5;
					}
					if (LogicDataTables.GetGlobals().TargetSelectionConsidersWallsOnPath() && tileMap.GetWallInPassableLine(position.m_x, position.m_y, num, num2, new LogicVector2()))
					{
						num7 += 1000L;
					}
					if (!attackOverWalls)
					{
						LogicVector2 logicVector = new LogicVector2();
						if (tileMap.GetWallInPassableLine(midX, midY, num, num2, logicVector))
						{
							num = logicVector.m_x;
							num2 = logicVector.m_y;
							num3 = num >> 8;
							num4 = num2 >> 8;
							int pathFinderCost2 = tileMap.GetPathFinderCost(num3, num4);
							if (pathFinderCost2 == 2147483647)
							{
								return true;
							}
							if (pathFinderCost2 > 0)
							{
								num7 = (long)num5;
							}
						}
						logicVector.Destruct();
					}
					if (!tileMap.IsPassablePathFinder(num3, num4))
					{
						LogicVector2 logicVector2 = new LogicVector2();
						if (!tileMap.GetPassablePositionInLine(num, num2, midX, midY, 512, logicVector2))
						{
							return true;
						}
						num = logicVector2.m_x;
						num2 = logicVector2.m_y;
						num3 = num >> 8;
						num4 = num2 >> 8;
						int pathFinderCost3 = tileMap.GetPathFinderCost(num3, num4);
						if (pathFinderCost3 == 2147483647)
						{
							return true;
						}
						if (pathFinderCost3 > 0)
						{
							num7 = (long)num5;
						}
					}
					int blockedAttackPositionPenalty = LogicDataTables.GetGlobals().GetBlockedAttackPositionPenalty();
					if (blockedAttackPositionPenalty > 0)
					{
						LogicTile tile = tileMap.GetTile(this.m_parent.GetTileX(), this.m_parent.GetTileY());
						LogicTile tile2 = tileMap.GetTile(num >> 9, num2 >> 9);
						if (tile != null && tile2 != null && tile.GetRoomIdx() != tile2.GetRoomIdx())
						{
							num7 += (long)(2 * blockedAttackPositionPenalty);
						}
					}
				}
				LogicCombatComponent combatComponent = this.m_parent.GetCombatComponent();
				LogicGameObject target = combatComponent.GetTarget(0);
				if (combatComponent.GetAttackMultipleBuildings() && target != null && target.GetGameObjectType() == LogicGameObjectType.BUILDING)
				{
					int num8 = this.GetNearestBuildings(num, num2, combatComponent.GetAttackRange(0, false), tileMap);
					if (LogicDataTables.GetGlobals().ValkyriePrefers4Buildings())
					{
						num7 += (long)(LogicMath.Clamp(4 - num8, 0, 3) * 15);
					}
					else
					{
						if (ignoreNearestBuildings)
						{
							num8 = 1;
						}
						num7 += (long)(LogicMath.Clamp(2 - num8, 0, 1) * 20);
					}
				}
				int num9 = position.m_x - num;
				int num10 = position.m_y - num2;
				if (this.int_4 > 0)
				{
					bool movementComponent = gameObject.GetMovementComponent() != null;
					int num11 = midX - num;
					int num12 = midY - num2;
					int num13 = (!movementComponent) ? (num + num2) : (num11 + num12);
					if (LogicDataTables.GetGlobals().TighterAttackPosition())
					{
						int num14 = radius + (gameObject.GetWidthInTiles() << 8);
						int num15 = LogicMath.Abs(combatComponent.Rand(this.m_parent.GetGlobalID() + num13) % num14);
						int num16 = combatComponent.Rand(this.m_parent.GetGlobalID() + num13 + 1) % 128;
						num9 = position.m_x + num12 * num16 / num14 - (num + num11 * num15 / radius);
						num10 = position.m_y - (num11 * num16 / radius + num2 + num12 * num15 / radius);
					}
					else
					{
						num9 += (this.int_4 & combatComponent.Rand(num13 + 1)) << 8;
						num10 += (this.int_4 & combatComponent.Rand(num13)) << 8;
					}
				}
				long num17 = (long)num9 * (long)num9 + (long)(num10 * num10) + (num7 << 8) * (num7 << 8);
				if (num17 < this.long_0)
				{
					this.long_0 = num17;
					this.int_6 = num;
					this.int_7 = num2;
				}
				return false;
			}
			return true;
		}

		// Token: 0x06000FE5 RID: 4069 RVA: 0x0004567C File Offset: 0x0004387C
		public int GetNearestBuildings(int x, int y, int radius, LogicTileMap tileMap)
		{
			if (this.logicArrayList_0 == null)
			{
				this.logicArrayList_0 = new LogicArrayList<LogicGameObject>(10);
			}
			int i = x - radius >> 9;
			int num = x + radius >> 9;
			while (i <= num)
			{
				int j = y - radius >> 9;
				int num2 = y + radius >> 9;
				while (j <= num2)
				{
					LogicTile tile = tileMap.GetTile(i, j);
					if (tile != null)
					{
						for (int k = 0; k < tile.GetGameObjectCount(); k++)
						{
							LogicGameObject gameObject = tile.GetGameObject(k);
							if (gameObject.GetGameObjectType() == LogicGameObjectType.BUILDING && gameObject.IsAlive() && !gameObject.IsWall() && this.logicArrayList_0.IndexOf(gameObject) == -1 && gameObject.PassableSubtilesAtEdge() <= 1)
							{
								this.logicArrayList_0.Add(gameObject);
							}
						}
					}
					j++;
				}
				i++;
			}
			int result = this.logicArrayList_0.Size();
			this.logicArrayList_0.Clear();
			return result;
		}

		// Token: 0x06000FE6 RID: 4070 RVA: 0x0000AC79 File Offset: 0x00008E79
		public int GetAttackDist()
		{
			return LogicMath.Max(32, this.m_parent.GetCombatComponent().GetAttackRange(0, false) - 32);
		}

		// Token: 0x06000FE7 RID: 4071 RVA: 0x0004575C File Offset: 0x0004395C
		public void MoveToPoint(LogicVector2 position)
		{
			this.EnableUnderground();
			if (!this.bool_5 && !this.bool_6)
			{
				this.logicMovementSystem_0.MoveTo(position.m_x, position.m_y, this.m_parent.GetLevel().GetTileMap(), true);
				return;
			}
			this.logicMovementSystem_0.AddPoint(position.m_x, position.m_y);
		}

		// Token: 0x06000FE8 RID: 4072 RVA: 0x000457C4 File Offset: 0x000439C4
		public void InitRandom()
		{
			if (this.logicRandom_0 == null)
			{
				this.logicRandom_0 = new LogicRandom();
				this.logicRandom_0.SetIteratedRandomSeed(this.m_parent.GetLevel().GetLogicTime().GetTick() + this.m_parent.GetGlobalID());
			}
		}

		// Token: 0x06000FE9 RID: 4073 RVA: 0x0000AC97 File Offset: 0x00008E97
		public void SetPatrolFreeze()
		{
			if (this.bool_2 && this.logicMovementSystem_0.GetFreezeTime() > 300)
			{
				this.InitRandom();
				this.logicMovementSystem_0.SetFreezeTime(this.logicRandom_0.Rand(100) + 200);
			}
		}

		// Token: 0x06000FEA RID: 4074 RVA: 0x00002EAE File Offset: 0x000010AE
		public override LogicComponentType GetComponentType()
		{
			return LogicComponentType.MOVEMENT;
		}

		// Token: 0x04000675 RID: 1653
		private int int_0;

		// Token: 0x04000676 RID: 1654
		private int int_1;

		// Token: 0x04000677 RID: 1655
		private int int_2;

		// Token: 0x04000678 RID: 1656
		private int int_3;

		// Token: 0x04000679 RID: 1657
		private int int_4;

		// Token: 0x0400067A RID: 1658
		private int int_5;

		// Token: 0x0400067B RID: 1659
		private long long_0;

		// Token: 0x0400067C RID: 1660
		private int int_6;

		// Token: 0x0400067D RID: 1661
		private int int_7;

		// Token: 0x0400067E RID: 1662
		private int int_8;

		// Token: 0x0400067F RID: 1663
		private int int_9;

		// Token: 0x04000680 RID: 1664
		private bool bool_0;

		// Token: 0x04000681 RID: 1665
		private bool bool_1;

		// Token: 0x04000682 RID: 1666
		private bool bool_2;

		// Token: 0x04000683 RID: 1667
		private bool bool_3;

		// Token: 0x04000684 RID: 1668
		private bool bool_4;

		// Token: 0x04000685 RID: 1669
		private bool bool_5;

		// Token: 0x04000686 RID: 1670
		private bool bool_6;

		// Token: 0x04000687 RID: 1671
		private readonly LogicVector2 logicVector2_0;

		// Token: 0x04000688 RID: 1672
		private readonly LogicMovementSystem logicMovementSystem_0;

		// Token: 0x04000689 RID: 1673
		private LogicRandom logicRandom_0;

		// Token: 0x0400068A RID: 1674
		private LogicBuilding logicBuilding_0;

		// Token: 0x0400068B RID: 1675
		private LogicArrayList<LogicGameObject> logicArrayList_0;
	}
}
