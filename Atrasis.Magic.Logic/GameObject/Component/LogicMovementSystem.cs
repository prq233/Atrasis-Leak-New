using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.GameObject.Component
{
	// Token: 0x02000128 RID: 296
	public class LogicMovementSystem
	{
		// Token: 0x06000FEB RID: 4075 RVA: 0x00045810 File Offset: 0x00043A10
		public LogicMovementSystem()
		{
			this.logicVector2_0 = new LogicVector2();
			this.logicVector2_1 = new LogicVector2();
			this.logicVector2_2 = new LogicVector2();
			this.logicVector2_3 = new LogicVector2();
			this.logicVector2_4 = new LogicVector2();
			this.logicVector2_5 = new LogicVector2();
			this.logicVector2_6 = new LogicVector2();
			this.logicArrayList_0 = new LogicArrayList<LogicVector2>();
			this.logicArrayList_1 = new LogicArrayList<LogicVector2>();
			this.int_12 = new int[3];
			this.int_13 = new int[3];
			this.int_10 = new int[2];
			this.int_11 = new int[2];
			this.int_8 = 500;
		}

		// Token: 0x06000FEC RID: 4076 RVA: 0x0000ACD7 File Offset: 0x00008ED7
		public void Init(int speed, LogicMovementComponent parent, LogicPathFinder pathFinder)
		{
			this.logicMovementComponent_0 = parent;
			this.logicPathFinder_0 = pathFinder;
			if (parent != null && pathFinder != null)
			{
				Debugger.Error("LogicMovementSystem: both m_pParent and m_pPathFinder cant be used");
			}
			this.SetSpeed(speed);
		}

		// Token: 0x06000FED RID: 4077 RVA: 0x000458C4 File Offset: 0x00043AC4
		public void Destruct()
		{
			this.ClearPath();
			this.ClearPatrolArea();
			this.logicVector2_0.Destruct();
			this.logicVector2_1.Destruct();
			this.logicVector2_3.Destruct();
			this.logicVector2_2.Destruct();
			this.logicVector2_4.Destruct();
			this.logicVector2_5.Destruct();
			this.logicVector2_6.Destruct();
			this.int_2 = 0;
		}

		// Token: 0x06000FEE RID: 4078 RVA: 0x00045934 File Offset: 0x00043B34
		public int GetSpeed()
		{
			int num = this.int_0;
			if (this.int_10[0] > 0)
			{
				num += this.int_11[0];
			}
			if (this.int_3 > 0)
			{
				num = (int)((long)num * (long)(this.int_4 + 100) / 100L);
			}
			if (this.logicMovementComponent_0 != null && this.logicMovementComponent_0.GetParent().IsFrozen())
			{
				num = 0;
			}
			return LogicMath.Max(0, num);
		}

		// Token: 0x06000FEF RID: 4079 RVA: 0x0000ACFE File Offset: 0x00008EFE
		public void SetSpeed(int speed)
		{
			this.int_0 = 16 * speed / 1000;
		}

		// Token: 0x06000FF0 RID: 4080 RVA: 0x0000AD10 File Offset: 0x00008F10
		public int GetDirection()
		{
			return this.int_1;
		}

		// Token: 0x06000FF1 RID: 4081 RVA: 0x0000AD18 File Offset: 0x00008F18
		public void SetDirection(int angle)
		{
			this.int_1 = angle;
		}

		// Token: 0x06000FF2 RID: 4082 RVA: 0x0000AD21 File Offset: 0x00008F21
		public bool IgnorePush()
		{
			return this.bool_0;
		}

		// Token: 0x06000FF3 RID: 4083 RVA: 0x0000AD29 File Offset: 0x00008F29
		public LogicVector2 GetPosition()
		{
			return this.logicVector2_2;
		}

		// Token: 0x06000FF4 RID: 4084 RVA: 0x0000AD31 File Offset: 0x00008F31
		public LogicVector2 GetPathEndPosition()
		{
			return this.logicVector2_6;
		}

		// Token: 0x06000FF5 RID: 4085 RVA: 0x0000AD39 File Offset: 0x00008F39
		public int GetPathLength()
		{
			return this.int_2;
		}

		// Token: 0x06000FF6 RID: 4086 RVA: 0x000459A4 File Offset: 0x00043BA4
		public void ClearPath()
		{
			this.logicGameObject_0 = null;
			this.int_5 = 0;
			for (int i = this.logicArrayList_1.Size() - 1; i >= 0; i--)
			{
				this.logicArrayList_1[i].Destruct();
				this.logicArrayList_1.Remove(i);
			}
			this.int_2 = 0;
		}

		// Token: 0x06000FF7 RID: 4087 RVA: 0x0000AD41 File Offset: 0x00008F41
		public int GetWallCount()
		{
			return this.int_5;
		}

		// Token: 0x06000FF8 RID: 4088 RVA: 0x0000AD49 File Offset: 0x00008F49
		public bool NotMoving()
		{
			return this.logicArrayList_1.Size() == 0;
		}

		// Token: 0x06000FF9 RID: 4089 RVA: 0x0000AD59 File Offset: 0x00008F59
		public void Reset(int x, int y)
		{
			this.logicVector2_2.Set(x, y);
			if (this.logicMovementComponent_0 != null)
			{
				this.ValidatePos();
			}
		}

		// Token: 0x06000FFA RID: 4090 RVA: 0x00002463 File Offset: 0x00000663
		public void ValidatePos()
		{
		}

		// Token: 0x06000FFB RID: 4091 RVA: 0x000459FC File Offset: 0x00043BFC
		public void CalculatePathLength()
		{
			this.int_2 = 0;
			if (this.logicArrayList_1.Size() > 0)
			{
				this.int_2 += this.logicVector2_2.GetDistance(this.logicArrayList_1[this.logicArrayList_1.Size() - 1]);
				for (int i = 0; i < this.logicArrayList_1.Size() - 1; i++)
				{
					this.int_2 += this.logicArrayList_1[i].GetDistance(this.logicArrayList_1[i + 1]);
				}
			}
		}

		// Token: 0x06000FFC RID: 4092 RVA: 0x00045A94 File Offset: 0x00043C94
		public void CalculateDirection(LogicVector2 pos)
		{
			LogicVector2 logicVector = this.logicArrayList_1[this.logicArrayList_1.Size() - 1];
			pos.m_x = logicVector.m_x - this.logicVector2_2.m_x;
			pos.m_y = logicVector.m_y - this.logicVector2_2.m_y;
			this.int_1 = pos.GetAngle();
		}

		// Token: 0x06000FFD RID: 4093 RVA: 0x00045AF8 File Offset: 0x00043CF8
		public void ClearPatrolArea()
		{
			if (this.logicArrayList_0 != null)
			{
				while (this.logicArrayList_0.Size() > 0)
				{
					LogicVector2 logicVector = this.logicArrayList_0[this.logicArrayList_0.Size() - 1];
					if (logicVector == null)
					{
						Debugger.Error("LogicMovementSystem::calculatePatrolArea: removed waypoint is NULL");
					}
					logicVector.Destruct();
					this.logicArrayList_0.Remove(this.logicArrayList_0.Size() - 1);
				}
			}
			this.logicArrayList_0 = null;
		}

		// Token: 0x06000FFE RID: 4094 RVA: 0x0000AD76 File Offset: 0x00008F76
		public int GetDistSqToEnd()
		{
			if (this.logicArrayList_1.Size() > 0)
			{
				return this.logicVector2_2.GetDistanceSquared(this.logicArrayList_1[0]);
			}
			return 0;
		}

		// Token: 0x06000FFF RID: 4095 RVA: 0x0000AD9F File Offset: 0x00008F9F
		public void AddPoint(int x, int y)
		{
			this.ClearPath();
			this.logicArrayList_1.Add(new LogicVector2(x, y));
			this.CalculatePathLength();
			this.CalculateDirection(this.logicVector2_4);
		}

		// Token: 0x06001000 RID: 4096 RVA: 0x00045B68 File Offset: 0x00043D68
		public void PopTarget()
		{
			int index = this.logicArrayList_1.Size() - 1;
			this.logicArrayList_1[index].Destruct();
			this.logicArrayList_1.Remove(index);
		}

		// Token: 0x06001001 RID: 4097 RVA: 0x0000ADCB File Offset: 0x00008FCB
		public void SubTick()
		{
			this.UpdateMovement(this.logicMovementComponent_0.GetParent().GetLevel());
		}

		// Token: 0x06001002 RID: 4098 RVA: 0x0000ADE3 File Offset: 0x00008FE3
		public LogicGameObject GetWall()
		{
			return this.logicGameObject_0;
		}

		// Token: 0x06001003 RID: 4099 RVA: 0x00045BA0 File Offset: 0x00043DA0
		public void UpdateMovement(LogicLevel level)
		{
			if (this.int_10[0] > 0)
			{
				this.int_10[0]--;
				if (this.int_10[0] == 0)
				{
					this.int_10[0] = this.int_10[1];
					this.int_11[0] = this.int_11[1];
					this.int_10[1] = 0;
					this.int_11[1] = 0;
				}
			}
			if (this.int_3 > 0)
			{
				this.int_3--;
				if (this.int_3 == 0)
				{
					this.int_4 = 0;
				}
			}
			if (this.int_6 <= 0)
			{
				if (this.int_7 <= 0)
				{
					if (this.logicArrayList_1.Size() != 0)
					{
						for (int i = this.GetSpeed(); i > 0; i -= this.logicVector2_3.GetLength())
						{
							if (this.logicArrayList_1.Size() == 0)
							{
								break;
							}
							LogicVector2 logicVector = this.logicArrayList_1[this.logicArrayList_1.Size() - 1];
							int num = logicVector.m_x - this.logicVector2_2.m_x;
							int num2 = logicVector.m_y - this.logicVector2_2.m_y;
							this.logicVector2_3.m_x = num;
							this.logicVector2_3.m_y = num2;
							int num3 = this.logicVector2_3.Normalize(i);
							if (num3 > i)
							{
								if (num != 0 && this.logicVector2_3.m_x == 0)
								{
									this.logicVector2_3.m_x = ((num <= 0) ? -1 : 1);
								}
								if (num2 != 0 && this.logicVector2_3.m_y == 0)
								{
									this.logicVector2_3.m_y = ((num2 <= 0) ? -1 : 1);
								}
								this.SetPosition(this.logicVector2_2.m_x + this.logicVector2_3.m_x, this.logicVector2_2.m_y + this.logicVector2_3.m_y);
								this.int_2 += this.logicVector2_2.GetDistance(logicVector) - num3;
								this.ValidatePos();
								break;
							}
							this.SetPosition(logicVector.m_x, logicVector.m_y);
							this.int_2 += this.logicVector2_2.GetDistance(logicVector) - num3;
							this.ValidatePos();
							this.PopTarget();
							if (this.logicArrayList_1.Size() == 0)
							{
								this.int_2 = 0;
								this.UpdatePatrolArea(level);
								break;
							}
							this.CalculateDirection(this.logicVector2_3);
						}
					}
				}
				else
				{
					this.UpdatePushBack();
				}
				this.ValidatePos();
				if (this.logicMovementComponent_0 != null && this.logicMovementComponent_0.GetParent().IsFrozen() && this.logicArrayList_1.Size() != 0)
				{
					this.ValidatePos();
					this.ClearPath();
				}
				for (int j = 0; j < 3; j++)
				{
					if (this.int_13[j] > 0)
					{
						this.int_13[j] -= 16;
						if (this.int_13[j] <= 0)
						{
							this.int_13[j] = 0;
							this.int_12[j] = 0;
						}
					}
				}
				return;
			}
			this.int_6 = LogicMath.Max(this.int_6 - 16, 0);
		}

		// Token: 0x06001004 RID: 4100 RVA: 0x00045E9C File Offset: 0x0004409C
		public void UpdatePatrolArea(LogicLevel level)
		{
			if (this.logicArrayList_0 != null)
			{
				int num = this.logicArrayList_0.Size();
				if (num > 0 && this.int_2 == 0)
				{
					for (int i = num - 1; i >= 0; i--)
					{
						this.int_9 = (this.int_9 + 1) % num;
						if (this.MoveTo(this.logicArrayList_0[this.int_9].m_x, this.logicArrayList_0[this.int_9].m_y, level.GetTileMap(), true))
						{
							break;
						}
					}
					if (this.logicGameObject_1 != null && this.logicGameObject_1.GetDefenceUnitProduction() != null)
					{
						this.int_6 = (level.IsInCombatState() ? 100 : 5000) + level.GetLogicTime().GetTick() % (level.IsInCombatState() ? 200 : 3000);
					}
				}
			}
		}

		// Token: 0x06001005 RID: 4101 RVA: 0x00045F78 File Offset: 0x00044178
		public void UpdatePushBack()
		{
			int num = this.int_7 * this.int_7 / this.int_8;
			int num2 = this.int_8 - num;
			int num3 = (num * this.logicVector2_0.m_x + num2 * this.logicVector2_1.m_x) / this.int_8;
			int num4 = (num * this.logicVector2_0.m_y + num2 * this.logicVector2_1.m_y) / this.int_8;
			if (this.logicMovementComponent_0 != null && !this.logicMovementComponent_0.IsFlying() && !this.logicMovementComponent_0.GetParent().GetLevel().GetTileMap().IsPassablePathFinder(num3 >> 8, num4 >> 8) && !this.bool_0)
			{
				this.logicVector2_0.m_x = this.logicVector2_2.m_x;
				this.logicVector2_0.m_y = this.logicVector2_2.m_y;
				this.logicVector2_1.m_x = this.logicVector2_2.m_x;
				this.logicVector2_1.m_y = this.logicVector2_2.m_y;
			}
			else
			{
				this.SetPosition(num3, num4);
			}
			this.int_7 = LogicMath.Max(this.int_7 - 16, 0);
			if (this.int_7 == 0)
			{
				LogicGameObject parent = this.logicMovementComponent_0.GetParent();
				LogicCombatComponent combatComponent = parent.GetCombatComponent();
				if (parent.GetGameObjectType() == LogicGameObjectType.CHARACTER && (((LogicCharacter)parent).GetCharacterData().GetPickNewTargetAfterPushback() || this.bool_0) && combatComponent != null)
				{
					combatComponent.ForceNewTarget();
				}
				this.logicMovementComponent_0.NewTargetFound();
				if (combatComponent != null)
				{
					combatComponent.StopAttack();
				}
				this.bool_0 = false;
			}
		}

		// Token: 0x06001006 RID: 4102 RVA: 0x00046110 File Offset: 0x00044310
		public void SetPosition(int x, int y)
		{
			if (this.logicMovementComponent_0 != null && !this.logicMovementComponent_0.IsFlying() && !this.logicMovementComponent_0.IsUnderground() && this.logicMovementComponent_0.GetJump() <= 0 && !this.bool_0)
			{
				this.ValidatePos();
				if (this.logicVector2_2.m_x >> 8 != x >> 8 || ((long)this.logicVector2_2.m_y ^ (long)((ulong)y)) >= 256L)
				{
					LogicTileMap tileMap = this.logicMovementComponent_0.GetParent().GetLevel().GetTileMap();
					int num = x >> 8;
					int num2 = y >> 8;
					if (!tileMap.IsPassablePathFinder(num, num2))
					{
						LogicTile tile = tileMap.GetTile(num / 2, num2 / 2);
						if (LogicDataTables.GetGlobals().JumpWhenHitJumpable())
						{
							bool flag = false;
							for (int i = 0; i < tile.GetGameObjectCount(); i++)
							{
								LogicGameObject gameObject = tile.GetGameObject(i);
								if (gameObject.GetGameObjectType() == LogicGameObjectType.BUILDING && ((LogicBuilding)gameObject).GetHitWallDelay() > 0)
								{
									flag = true;
								}
							}
							if (flag)
							{
								this.logicVector2_2.m_x = x;
								this.logicVector2_2.m_y = y;
								this.logicMovementComponent_0.EnableJump(128);
								return;
							}
						}
						if (LogicDataTables.GetGlobals().SlideAlongObstacles())
						{
							throw new NotImplementedException();
						}
						x = LogicMath.Clamp(x, (int)((long)this.logicVector2_2.m_x & 4294967040L), this.logicVector2_2.m_x | 255);
						y = LogicMath.Clamp(y, (int)((long)this.logicVector2_2.m_y & 4294967040L), this.logicVector2_2.m_y | 255);
						this.logicVector2_2.m_x = x;
						this.logicVector2_2.m_y = y;
						this.ValidatePos();
						return;
					}
				}
			}
			this.logicVector2_2.m_x = x;
			this.logicVector2_2.m_y = y;
		}

		// Token: 0x06001007 RID: 4103 RVA: 0x0000ADEB File Offset: 0x00008FEB
		public bool IsPushed()
		{
			return this.int_7 > 0;
		}

		// Token: 0x06001008 RID: 4104 RVA: 0x000462F0 File Offset: 0x000444F0
		public bool MoveTo(int x, int y, LogicTileMap tileMap, bool defaultEndPoint)
		{
			this.ClearPath();
			if (this.logicMovementComponent_0 != null && this.logicMovementComponent_0.GetParent().IsFrozen())
			{
				return false;
			}
			this.logicGameObject_0 = null;
			this.int_5 = 0;
			this.logicVector2_5.m_x = this.logicVector2_2.m_x >> 8;
			this.logicVector2_5.m_y = this.logicVector2_2.m_y >> 8;
			this.logicVector2_6.m_x = x >> 8;
			this.logicVector2_6.m_y = y >> 8;
			this.logicVector2_5.m_x = LogicMath.Clamp(this.logicVector2_5.m_x, 0, 99);
			this.logicVector2_5.m_y = LogicMath.Clamp(this.logicVector2_5.m_y, 0, 99);
			this.logicVector2_6.m_x = LogicMath.Clamp(this.logicVector2_6.m_x, 0, 99);
			this.logicVector2_6.m_y = LogicMath.Clamp(this.logicVector2_6.m_y, 0, 99);
			if (this.logicMovementComponent_0 == null)
			{
				LogicPathFinder pathFinder = this.logicPathFinder_0;
				pathFinder.ResetCostStrategyToDefault();
			}
			else
			{
				bool flag = true;
				int quality = 256;
				LogicGameObject parent = this.logicMovementComponent_0.GetParent();
				LogicHitpointComponent hitpointComponent = parent.GetHitpointComponent();
				if (hitpointComponent != null && hitpointComponent.GetTeam() == 1)
				{
					flag = false;
					quality = 768;
				}
				if (this.logicMovementComponent_0.CanJumpWall())
				{
					flag = false;
					quality = 16;
				}
				if (parent.GetGameObjectType() == LogicGameObjectType.CHARACTER && ((LogicCharacter)parent).IsWallBreaker())
				{
					flag = false;
					quality = 128;
				}
				LogicPathFinder pathFinder = tileMap.GetPathFinder();
				if (flag)
				{
					pathFinder.ResetCostStrategyToDefault();
				}
				else
				{
					pathFinder.SetCostStrategy(true, quality);
				}
				pathFinder.FindPath(this.logicVector2_5, this.logicVector2_6, true);
				pathFinder.GetPathLength();
				int pathLength = pathFinder.GetPathLength();
				this.logicArrayList_1.EnsureCapacity(pathLength + 1);
				if (pathLength != 0 && defaultEndPoint)
				{
					LogicVector2 logicVector = new LogicVector2(x, y);
					this.CheckWall(logicVector);
					this.logicArrayList_1.Add(logicVector);
				}
				if (LogicDataTables.GetGlobals().UseNewPathFinder())
				{
					LogicTileMap tileMap2 = pathFinder.GetTileMap();
					int num = 2 * tileMap2.GetSizeX();
					int num2 = 2 * tileMap2.GetSizeY();
					int num3 = this.logicVector2_5.m_x + num * this.logicVector2_5.m_y;
					int num4 = this.logicVector2_6.m_x + num * this.logicVector2_6.m_y;
					if (!defaultEndPoint)
					{
						LogicVector2 logicVector2 = new LogicVector2(num4 % num << 8, num4 / num2 << 8);
						this.CheckWall(logicVector2);
						this.logicArrayList_1.Add(logicVector2);
					}
					if (pathLength > 0 && !pathFinder.IsLineOfSightClear())
					{
						int num5 = 0;
						while (num4 != num3)
						{
							if (num4 == -1)
							{
								break;
							}
							num4 = pathFinder.GetParent(num4);
							if (num4 != num3 && num4 != -1)
							{
								LogicVector2 logicVector3 = new LogicVector2(num4 % num << 8, num4 / num2 << 8);
								logicVector3.m_x += 128;
								logicVector3.m_y += 128;
								this.CheckWall(logicVector3);
								this.logicArrayList_1.Add(logicVector3);
								if (num5 >= 100000)
								{
									Debugger.Warning("LMSystem: iteration count > 100000");
									break;
								}
							}
							num5++;
						}
					}
				}
				else
				{
					int num6 = -pathLength;
					int num7 = 0;
					while (num7 + num6 != 0)
					{
						LogicVector2 logicVector4 = new LogicVector2();
						pathFinder.GetPathPoint(logicVector4, num6 + num7);
						if (num6 + num7 == -1 && this.logicVector2_5.Equals(logicVector4))
						{
							logicVector4.Destruct();
						}
						else
						{
							if (num7 == 0 && this.logicVector2_5.Equals(logicVector4))
							{
								logicVector4.m_x = x;
								logicVector4.m_y = y;
							}
							else
							{
								logicVector4.m_x = (logicVector4.m_x << 8 | 128);
								logicVector4.m_y = (logicVector4.m_y << 8 | 128);
							}
							this.CheckWall(logicVector4);
							this.logicArrayList_1.Add(logicVector4);
						}
						num7++;
					}
				}
			}
			this.CalculatePathLength();
			if (this.logicArrayList_1.Size() > 0)
			{
				this.CalculateDirection(this.logicVector2_4);
				return true;
			}
			return false;
		}

		// Token: 0x06001009 RID: 4105 RVA: 0x00046704 File Offset: 0x00044904
		public void CheckWall(LogicVector2 position)
		{
			if (this.logicMovementComponent_0 != null)
			{
				LogicTile tile = this.logicMovementComponent_0.GetParent().GetLevel().GetTileMap().GetTile(position.m_x >> 9, position.m_y >> 9);
				if (tile != null)
				{
					for (int i = 0; i < tile.GetGameObjectCount(); i++)
					{
						LogicGameObject gameObject = tile.GetGameObject(i);
						if (gameObject.IsWall() && gameObject.IsAlive())
						{
							this.logicGameObject_0 = gameObject;
							if (((LogicBuilding)gameObject).GetHitWallDelay() <= 0)
							{
								this.int_5++;
							}
						}
					}
				}
			}
		}

		// Token: 0x0600100A RID: 4106 RVA: 0x00046798 File Offset: 0x00044998
		public void PushBack(LogicVector2 position, int speed, int unk1, int id, bool ignoreWeight, bool gravity)
		{
			if (speed > 0 && this.int_7 <= 0 && this.logicMovementComponent_0 != null && this.logicMovementComponent_0.GetJump() <= 0 && !this.logicMovementComponent_0.GetParent().IsHero())
			{
				if (id != 0)
				{
					int num = -1;
					for (int i = 0; i < 3; i++)
					{
						if (this.int_12[i] == id)
						{
							return;
						}
						if (this.int_13[i] == 0)
						{
							num = i;
						}
					}
					if (num == -1)
					{
						return;
					}
					this.int_12[num] = id;
					this.int_13[num] = 1500;
				}
				LogicGameObject parent = this.logicMovementComponent_0.GetParent();
				LogicGameObjectData data = parent.GetData();
				int num2 = 1;
				if (data.GetDataType() == LogicDataType.CHARACTER)
				{
					num2 = ((LogicCombatItemData)data).GetHousingSpace();
					if (num2 >= 4 && !ignoreWeight)
					{
						return;
					}
				}
				int num3 = 256;
				if (100 / unk1 != 0)
				{
					num3 = 256 / (100 / unk1);
				}
				if (gravity)
				{
					num3 = (LogicMath.Min(speed, 5000) << 8) / 5000 / num2;
				}
				int num4 = parent.Rand(100) & 127;
				int num5 = parent.Rand(200) & 127;
				int num6 = num4 + position.m_x - 63;
				int num7 = num5 + position.m_y - 63;
				int num8 = 1000 * num3 >> 8;
				this.int_7 = num8;
				this.int_8 = num8;
				this.bool_0 = false;
				this.logicVector2_0.m_x = this.logicVector2_2.m_x;
				this.logicVector2_0.m_y = this.logicVector2_2.m_y;
				num3 *= 2;
				this.logicVector2_1.m_x = this.logicVector2_2.m_x + (num3 * num6 >> 8);
				this.logicVector2_1.m_y = this.logicVector2_2.m_y + (num3 * num7 >> 8);
				int angle = position.GetAngle();
				int num9 = (angle <= 180) ? 180 : -180;
				this.int_1 = num9 + angle;
			}
		}

		// Token: 0x0600100B RID: 4107 RVA: 0x00046990 File Offset: 0x00044B90
		public bool ManualPushBack(LogicVector2 position, int speed, int time, int id)
		{
			if (speed > 0 && this.logicMovementComponent_0 != null && this.logicMovementComponent_0.GetJump() <= 0)
			{
				if (id != 0)
				{
					int num = -1;
					for (int i = 0; i < 3; i++)
					{
						if (this.int_12[i] == id)
						{
							return false;
						}
						if (this.int_13[i] == 0)
						{
							num = i;
						}
					}
					if (num == -1)
					{
						return false;
					}
					this.int_12[num] = id;
					this.int_13[num] = 1500;
				}
				LogicGameObject parent = this.logicMovementComponent_0.GetParent();
				int num2 = parent.Rand(100) & 127;
				int num3 = parent.Rand(200) & 127;
				int num4 = num2 + position.m_x - 63;
				int num5 = num3 + position.m_y - 63;
				LogicVector2 logicVector = new LogicVector2(2 * speed * num4 >> 8, 2 * speed * num5 >> 8);
				int num6 = this.int_7;
				if (num6 <= 0)
				{
					this.int_7 = time - 16;
					this.int_8 = time;
					this.bool_0 = false;
					this.logicVector2_0.m_x = this.logicVector2_2.m_x;
					this.logicVector2_0.m_y = this.logicVector2_2.m_y;
					this.logicVector2_1.m_x = this.logicVector2_2.m_x + logicVector.m_x;
					this.logicVector2_1.m_y = this.logicVector2_2.m_y + logicVector.m_y;
				}
				else
				{
					LogicVector2 logicVector2 = new LogicVector2(this.logicVector2_1.m_x - this.logicVector2_2.m_x, this.logicVector2_1.m_y - this.logicVector2_2.m_y);
					this.int_7 = num6 + time - 16;
					this.int_8 = num6 + time;
					this.bool_0 = false;
					logicVector.Add(logicVector2);
					this.logicVector2_0.m_x = this.logicVector2_2.m_x;
					this.logicVector2_0.m_y = this.logicVector2_2.m_y;
					this.logicVector2_1.m_x = this.logicVector2_2.m_x + logicVector.m_x;
					this.logicVector2_1.m_y = this.logicVector2_2.m_y + logicVector.m_y;
					logicVector2.Destruct();
				}
				return true;
			}
			return false;
		}

		// Token: 0x0600100C RID: 4108 RVA: 0x00046BC8 File Offset: 0x00044DC8
		public void PushTrap(LogicVector2 position, int time, int id, bool ignorePrevPush, bool verifyPushPosition)
		{
			if ((this.int_7 <= 0 || ignorePrevPush) && this.logicMovementComponent_0 != null && this.logicMovementComponent_0.GetJump() <= 0 && !this.logicMovementComponent_0.GetParent().IsHero())
			{
				LogicGameObject parent = this.logicMovementComponent_0.GetParent();
				if (!parent.IsHero())
				{
					if (id != 0 && !ignorePrevPush)
					{
						int num = -1;
						for (int i = 0; i < 3; i++)
						{
							if (this.int_12[i] == id)
							{
								return;
							}
							if (this.int_13[i] == 0)
							{
								num = i;
							}
						}
						if (num == -1)
						{
							return;
						}
						this.int_12[num] = id;
						this.int_13[num] = 1500;
					}
					this.int_7 = time;
					this.int_8 = time;
					this.logicVector2_0.m_x = this.logicVector2_2.m_x;
					this.logicVector2_0.m_y = this.logicVector2_2.m_y;
					this.logicVector2_1.m_x = this.logicVector2_2.m_x + position.m_x;
					this.logicVector2_1.m_y = this.logicVector2_2.m_y + position.m_y;
					if (verifyPushPosition)
					{
						int x = this.logicVector2_1.m_x;
						int y = this.logicVector2_1.m_y;
						if (LogicMath.Max(LogicMath.Abs(position.m_x), LogicMath.Abs(position.m_y)) != 0)
						{
							LogicTileMap tileMap = parent.GetLevel().GetTileMap();
							if (!tileMap.IsPassablePathFinder(x >> 8, y >> 8))
							{
								LogicVector2 logicVector = new LogicVector2();
								LogicRandom logicRandom = new LogicRandom(x + y);
								tileMap.GetNearestPassablePosition(x + logicRandom.Rand(512) - 256, y + logicRandom.Rand(512) - 256, logicVector, 2048);
								x = logicVector.m_x;
								y = logicVector.m_y;
							}
							if (!tileMap.IsPassablePathFinder(x >> 8, y >> 8))
							{
								Debugger.Warning("PushTrap->ended on inmovable");
							}
						}
						this.logicVector2_1.m_x = x;
						this.logicVector2_1.m_y = y;
					}
					this.bool_0 = verifyPushPosition;
					int angle = position.GetAngle();
					this.int_1 = angle + ((angle <= 180) ? 180 : -180);
				}
			}
		}

		// Token: 0x0600100D RID: 4109 RVA: 0x00046E10 File Offset: 0x00045010
		public bool ManualPushTrap(LogicVector2 position, int time, int id)
		{
			if (this.logicMovementComponent_0 != null && this.logicMovementComponent_0.GetJump() <= 0 && !this.logicMovementComponent_0.GetParent().IsHero())
			{
				if (id != 0)
				{
					int num = -1;
					for (int i = 0; i < 3; i++)
					{
						if (this.int_12[i] == id)
						{
							return false;
						}
						if (this.int_13[i] == 0)
						{
							num = i;
						}
					}
					if (num == -1)
					{
						return false;
					}
					this.int_12[num] = id;
					this.int_13[num] = 1500;
				}
				LogicVector2 logicVector = new LogicVector2(time * position.m_x / 32, time * position.m_y / 32);
				this.int_7 = time - 16;
				this.int_8 = time;
				this.bool_0 = false;
				this.logicVector2_0.m_x = this.logicVector2_2.m_x;
				this.logicVector2_0.m_y = this.logicVector2_2.m_y;
				this.logicVector2_1.m_x = this.logicVector2_2.m_x + logicVector.m_x;
				this.logicVector2_1.m_y = this.logicVector2_2.m_y + logicVector.m_y;
				return true;
			}
			return false;
		}

		// Token: 0x0600100E RID: 4110 RVA: 0x00046F38 File Offset: 0x00045138
		public void Boost(int speed, int time)
		{
			if (speed < 0)
			{
				this.int_4 = LogicMath.Min(LogicMath.Max(-100, speed), this.int_4);
				this.int_3 = time;
				return;
			}
			int num = (this.int_11[0] != 0) ? 1 : 0;
			this.int_11[num] = LogicMath.Max(speed, this.int_11[num]);
			this.int_10[num] = time;
		}

		// Token: 0x0600100F RID: 4111 RVA: 0x0000ADF6 File Offset: 0x00008FF6
		public bool IsBoosted()
		{
			return this.int_10[0] > 0;
		}

		// Token: 0x06001010 RID: 4112 RVA: 0x0000AE03 File Offset: 0x00009003
		public bool IsSlowed()
		{
			return this.int_3 > 0;
		}

		// Token: 0x06001011 RID: 4113 RVA: 0x0000AE0E File Offset: 0x0000900E
		public LogicGameObject GetPatrolPost()
		{
			return this.logicGameObject_1;
		}

		// Token: 0x06001012 RID: 4114 RVA: 0x0000AE16 File Offset: 0x00009016
		public void SetPatrolPost(LogicGameObject gameObject)
		{
			this.logicGameObject_1 = gameObject;
		}

		// Token: 0x06001013 RID: 4115 RVA: 0x0000AE1F File Offset: 0x0000901F
		public int GetFreezeTime()
		{
			return this.int_6;
		}

		// Token: 0x06001014 RID: 4116 RVA: 0x0000AE27 File Offset: 0x00009027
		public void SetFreezeTime(int value)
		{
			this.int_6 = value;
		}

		// Token: 0x06001015 RID: 4117 RVA: 0x00046F98 File Offset: 0x00045198
		public void CreatePatrolArea(LogicGameObject patrolPost, LogicLevel level, bool unk, int idx)
		{
			LogicArrayList<LogicVector2> logicArrayList = new LogicArrayList<LogicVector2>(8);
			if (this.logicGameObject_1 == null)
			{
				this.logicGameObject_1 = patrolPost;
			}
			int x = 0;
			int y = 0;
			int x2 = 0;
			int y2 = 0;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			if (patrolPost != null)
			{
				x = patrolPost.GetX() - 128;
				y = patrolPost.GetY() - 128;
				x2 = patrolPost.GetX() + (patrolPost.GetWidthInTiles() << 9) + 128;
				y2 = patrolPost.GetY() + (patrolPost.GetHeightInTiles() << 9) + 128;
				num = patrolPost.GetMidX();
				num2 = patrolPost.GetMidY();
				num3 = patrolPost.GetWidthInTiles() << 8;
				num4 = patrolPost.GetHeightInTiles() << 8;
				num5 = 1536;
			}
			if ((long)(num5 * num5) >= (long)((ulong)(num3 * num3 + num4 * num4)))
			{
				LogicVector2 logicVector = new LogicVector2();
				LogicVector2 logicVector2 = new LogicVector2();
				LogicVector2 logicVector3 = new LogicVector2();
				LogicVector2 logicVector4 = new LogicVector2();
				logicVector2.Set(num, num2);
				int num6 = patrolPost.GetLevel().GetLogicTime().GetTick() + idx;
				num = num + 127 * num6 % 1024 - 512;
				num2 = num2 + 271 * num6 % 1024 - 512;
				int i = 0;
				int num7 = 45;
				while (i < 4)
				{
					logicVector.Set(num + LogicMath.Cos(num7, num5), num2 + LogicMath.Sin(num7, num5));
					LogicHeroBaseComponent.FindPoint(patrolPost.GetLevel().GetTileMap(), logicVector3, logicVector2, logicVector, logicVector4);
					logicArrayList.Add(new LogicVector2(logicVector4.m_x, logicVector4.m_y));
					i++;
					num7 += 90;
				}
				logicVector.Destruct();
				logicVector2.Destruct();
				logicVector3.Destruct();
				logicVector4.Destruct();
			}
			else
			{
				logicArrayList.Add(new LogicVector2(x2, y2));
				logicArrayList.Add(new LogicVector2(x, y2));
				logicArrayList.Add(new LogicVector2(x, y));
				logicArrayList.Add(new LogicVector2(x2, y));
			}
			this.ClearPatrolArea();
			this.logicArrayList_0 = logicArrayList;
			this.int_9 = 0;
			if (this.logicArrayList_0.Size() > 1)
			{
				int num8 = int.MaxValue;
				int j = 1;
				int num9 = this.logicArrayList_0.Size();
				while (j < num9)
				{
					LogicVector2 logicVector5 = this.logicArrayList_0[j];
					int num10 = (logicVector5.m_x - (this.logicVector2_2.m_x >> 16)) * (logicVector5.m_x - (this.logicVector2_2.m_x >> 16)) + (logicVector5.m_y - (this.logicVector2_2.m_y >> 16)) * (logicVector5.m_y - (this.logicVector2_2.m_y >> 16));
					if (num10 < num8)
					{
						this.int_9 = j;
						num8 = num10;
					}
					j++;
				}
			}
			this.MoveTo(this.logicArrayList_0[this.int_9].m_x, this.logicArrayList_0[this.int_9].m_y, level.GetTileMap(), true);
		}

		// Token: 0x0400068C RID: 1676
		private LogicMovementComponent logicMovementComponent_0;

		// Token: 0x0400068D RID: 1677
		private LogicPathFinder logicPathFinder_0;

		// Token: 0x0400068E RID: 1678
		private readonly LogicVector2 logicVector2_0;

		// Token: 0x0400068F RID: 1679
		private readonly LogicVector2 logicVector2_1;

		// Token: 0x04000690 RID: 1680
		private readonly LogicVector2 logicVector2_2;

		// Token: 0x04000691 RID: 1681
		private readonly LogicVector2 logicVector2_3;

		// Token: 0x04000692 RID: 1682
		private readonly LogicVector2 logicVector2_4;

		// Token: 0x04000693 RID: 1683
		private readonly LogicVector2 logicVector2_5;

		// Token: 0x04000694 RID: 1684
		private readonly LogicVector2 logicVector2_6;

		// Token: 0x04000695 RID: 1685
		private LogicArrayList<LogicVector2> logicArrayList_0;

		// Token: 0x04000696 RID: 1686
		private readonly LogicArrayList<LogicVector2> logicArrayList_1;

		// Token: 0x04000697 RID: 1687
		private LogicGameObject logicGameObject_0;

		// Token: 0x04000698 RID: 1688
		private LogicGameObject logicGameObject_1;

		// Token: 0x04000699 RID: 1689
		private bool bool_0;

		// Token: 0x0400069A RID: 1690
		private int int_0;

		// Token: 0x0400069B RID: 1691
		private int int_1;

		// Token: 0x0400069C RID: 1692
		private int int_2;

		// Token: 0x0400069D RID: 1693
		private int int_3;

		// Token: 0x0400069E RID: 1694
		private int int_4;

		// Token: 0x0400069F RID: 1695
		private int int_5;

		// Token: 0x040006A0 RID: 1696
		private int int_6;

		// Token: 0x040006A1 RID: 1697
		private int int_7;

		// Token: 0x040006A2 RID: 1698
		private int int_8;

		// Token: 0x040006A3 RID: 1699
		private int int_9;

		// Token: 0x040006A4 RID: 1700
		private readonly int[] int_10;

		// Token: 0x040006A5 RID: 1701
		private readonly int[] int_11;

		// Token: 0x040006A6 RID: 1702
		private readonly int[] int_12;

		// Token: 0x040006A7 RID: 1703
		private readonly int[] int_13;
	}
}
