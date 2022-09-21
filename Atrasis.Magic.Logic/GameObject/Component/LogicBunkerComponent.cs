using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Battle;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Time;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.GameObject.Component
{
	// Token: 0x0200011C RID: 284
	public sealed class LogicBunkerComponent : LogicUnitStorageComponent
	{
		// Token: 0x06000EC8 RID: 3784 RVA: 0x0000A20B File Offset: 0x0000840B
		public LogicBunkerComponent(LogicGameObject gameObject, int capacity) : base(gameObject, capacity)
		{
			this.int_1 = 1;
			this.logicGameObjectFilter_0 = new LogicGameObjectFilter();
			this.logicGameObjectFilter_0.AddGameObjectType(LogicGameObjectType.CHARACTER);
			this.logicGameObjectFilter_0.PassEnemyOnly(gameObject);
		}

		// Token: 0x06000EC9 RID: 3785 RVA: 0x0000A23F File Offset: 0x0000843F
		public int GetTeam()
		{
			return this.int_1;
		}

		// Token: 0x06000ECA RID: 3786 RVA: 0x0000A247 File Offset: 0x00008447
		public void SetComponentMode(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x06000ECB RID: 3787 RVA: 0x00002E32 File Offset: 0x00001032
		public override LogicComponentType GetComponentType()
		{
			return LogicComponentType.BUNKER;
		}

		// Token: 0x06000ECC RID: 3788 RVA: 0x0000A250 File Offset: 0x00008450
		public void StartRequestCooldownTime()
		{
			if (this.logicTimer_0 == null)
			{
				this.logicTimer_0 = new LogicTimer();
			}
			this.logicTimer_0.StartTimer(this.GetTotalRequestCooldownTime(), this.m_parent.GetLevel().GetLogicTime(), false, -1);
		}

		// Token: 0x06000ECD RID: 3789 RVA: 0x0000A288 File Offset: 0x00008488
		public void StartClanMailCooldownTime()
		{
			if (this.logicTimer_1 == null)
			{
				this.logicTimer_1 = new LogicTimer();
			}
			this.logicTimer_1.StartTimer(LogicDataTables.GetGlobals().GetClanMailCooldown(), this.m_parent.GetLevel().GetLogicTime(), false, -1);
		}

		// Token: 0x06000ECE RID: 3790 RVA: 0x0000A2C4 File Offset: 0x000084C4
		public void StartChallengeCooldownTime()
		{
			if (this.logicTimer_4 == null)
			{
				this.logicTimer_4 = new LogicTimer();
			}
			this.logicTimer_4.StartTimer(LogicDataTables.GetGlobals().GetChallengeCooldown(), this.m_parent.GetLevel().GetLogicTime(), false, -1);
		}

		// Token: 0x06000ECF RID: 3791 RVA: 0x0000A300 File Offset: 0x00008500
		public void StartReplayShareCooldownTime()
		{
			if (this.logicTimer_2 == null)
			{
				this.logicTimer_2 = new LogicTimer();
			}
			this.logicTimer_2.StartTimer(LogicDataTables.GetGlobals().GetReplayShareCooldown(), this.m_parent.GetLevel().GetLogicTime(), false, -1);
		}

		// Token: 0x06000ED0 RID: 3792 RVA: 0x0000A33C File Offset: 0x0000853C
		public void StartArrangedWarCooldownTime()
		{
			if (this.logicTimer_5 == null)
			{
				this.logicTimer_5 = new LogicTimer();
			}
			this.logicTimer_5.StartTimer(LogicDataTables.GetGlobals().GetArrangeWarCooldown(), this.m_parent.GetLevel().GetLogicTime(), false, -1);
		}

		// Token: 0x06000ED1 RID: 3793 RVA: 0x0000A378 File Offset: 0x00008578
		public void StopRequestCooldownTime()
		{
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
		}

		// Token: 0x06000ED2 RID: 3794 RVA: 0x0000A394 File Offset: 0x00008594
		public int GetRequestCooldownTime()
		{
			if (this.logicTimer_0 != null)
			{
				return this.logicTimer_0.GetRemainingSeconds(this.m_parent.GetLevel().GetLogicTime());
			}
			return 0;
		}

		// Token: 0x06000ED3 RID: 3795 RVA: 0x0000A3BB File Offset: 0x000085BB
		public void StartElderKickCooldownTime()
		{
			if (this.logicTimer_3 == null)
			{
				this.logicTimer_3 = new LogicTimer();
			}
			this.logicTimer_3.StartTimer(LogicDataTables.GetGlobals().GetElderKickCooldown(), this.m_parent.GetLevel().GetLogicTime(), false, -1);
		}

		// Token: 0x06000ED4 RID: 3796 RVA: 0x0000A3F7 File Offset: 0x000085F7
		public int GetElderCooldownTime()
		{
			if (this.logicTimer_3 != null)
			{
				return this.logicTimer_3.GetRemainingSeconds(this.m_parent.GetLevel().GetLogicTime());
			}
			return 0;
		}

		// Token: 0x06000ED5 RID: 3797 RVA: 0x0000A41E File Offset: 0x0000861E
		public int GetReplayShareCooldownTime()
		{
			if (this.logicTimer_2 != null)
			{
				return this.logicTimer_2.GetRemainingSeconds(this.m_parent.GetLevel().GetLogicTime());
			}
			return 0;
		}

		// Token: 0x06000ED6 RID: 3798 RVA: 0x0000A445 File Offset: 0x00008645
		public int GetArrangedWarCooldownTime()
		{
			if (this.logicTimer_5 != null)
			{
				return this.logicTimer_5.GetRemainingSeconds(this.m_parent.GetLevel().GetLogicTime());
			}
			return 0;
		}

		// Token: 0x06000ED7 RID: 3799 RVA: 0x000398FC File Offset: 0x00037AFC
		public int GetTotalRequestCooldownTime()
		{
			LogicAvatar homeOwnerAvatar = this.m_parent.GetLevel().GetHomeOwnerAvatar();
			if (homeOwnerAvatar != null)
			{
				return ((LogicClientAvatar)homeOwnerAvatar).GetTroopRequestCooldown();
			}
			return LogicDataTables.GetGlobals().GetAllianceTroopRequestCooldown();
		}

		// Token: 0x06000ED8 RID: 3800 RVA: 0x0000A46C File Offset: 0x0000866C
		public int GetClanMailCooldownTime()
		{
			if (this.logicTimer_1 != null)
			{
				return this.logicTimer_1.GetRemainingSeconds(this.m_parent.GetLevel().GetLogicTime());
			}
			return 0;
		}

		// Token: 0x06000ED9 RID: 3801 RVA: 0x0000A493 File Offset: 0x00008693
		public int GetChallengeCooldownTime()
		{
			if (this.logicTimer_4 != null)
			{
				return this.logicTimer_4.GetRemainingSeconds(this.m_parent.GetLevel().GetLogicTime());
			}
			return 0;
		}

		// Token: 0x06000EDA RID: 3802 RVA: 0x0000A4BA File Offset: 0x000086BA
		public override void LoadingFinished()
		{
			if (this.m_parent.GetLevel().IsInCombatState())
			{
				this.logicArrayList_1 = this.CreatePatrolPath();
			}
		}

		// Token: 0x06000EDB RID: 3803 RVA: 0x00039934 File Offset: 0x00037B34
		public override void Load(LogicJSONObject jsonObject)
		{
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
			if (this.logicTimer_1 != null)
			{
				this.logicTimer_1.Destruct();
				this.logicTimer_1 = null;
			}
			if (this.logicTimer_2 != null)
			{
				this.logicTimer_2.Destruct();
				this.logicTimer_2 = null;
			}
			if (this.logicTimer_3 != null)
			{
				this.logicTimer_3.Destruct();
				this.logicTimer_3 = null;
			}
			if (this.logicTimer_4 != null)
			{
				this.logicTimer_4.Destruct();
				this.logicTimer_4 = null;
			}
			if (this.logicTimer_5 != null)
			{
				this.logicTimer_5.Destruct();
				this.logicTimer_5 = null;
			}
			LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("unit_req_time");
			if (jsonnumber != null)
			{
				this.logicTimer_0 = new LogicTimer();
				this.logicTimer_0.StartTimer(LogicMath.Min(jsonnumber.GetIntValue(), this.GetTotalRequestCooldownTime()), this.m_parent.GetLevel().GetLogicTime(), false, -1);
			}
			LogicJSONNumber jsonnumber2 = jsonObject.GetJSONNumber("clan_mail_time");
			if (jsonnumber2 != null)
			{
				this.logicTimer_1 = new LogicTimer();
				this.logicTimer_1.StartTimer(LogicMath.Min(jsonnumber2.GetIntValue(), LogicDataTables.GetGlobals().GetClanMailCooldown()), this.m_parent.GetLevel().GetLogicTime(), false, -1);
			}
			LogicJSONNumber jsonnumber3 = jsonObject.GetJSONNumber("share_replay_time");
			if (jsonnumber3 != null)
			{
				this.logicTimer_2 = new LogicTimer();
				this.logicTimer_2.StartTimer(LogicMath.Min(jsonnumber3.GetIntValue(), LogicDataTables.GetGlobals().GetReplayShareCooldown()), this.m_parent.GetLevel().GetLogicTime(), false, -1);
			}
			LogicJSONNumber jsonnumber4 = jsonObject.GetJSONNumber("elder_kick_time");
			if (jsonnumber4 != null)
			{
				this.logicTimer_3 = new LogicTimer();
				this.logicTimer_3.StartTimer(LogicMath.Min(jsonnumber4.GetIntValue(), LogicDataTables.GetGlobals().GetElderKickCooldown()), this.m_parent.GetLevel().GetLogicTime(), false, -1);
			}
			LogicJSONNumber jsonnumber5 = jsonObject.GetJSONNumber("challenge_time");
			if (jsonnumber5 != null)
			{
				this.logicTimer_4 = new LogicTimer();
				this.logicTimer_4.StartTimer(LogicMath.Min(jsonnumber5.GetIntValue(), LogicDataTables.GetGlobals().GetChallengeCooldown()), this.m_parent.GetLevel().GetLogicTime(), false, -1);
			}
			LogicJSONNumber jsonnumber6 = jsonObject.GetJSONNumber("arrwar_time");
			if (jsonnumber6 != null)
			{
				this.logicTimer_5 = new LogicTimer();
				this.logicTimer_5.StartTimer(LogicMath.Min(jsonnumber6.GetIntValue(), LogicDataTables.GetGlobals().GetArrangeWarCooldown()), this.m_parent.GetLevel().GetLogicTime(), false, -1);
			}
		}

		// Token: 0x06000EDC RID: 3804 RVA: 0x00039BA8 File Offset: 0x00037DA8
		public override void Save(LogicJSONObject jsonObject, int villageType)
		{
			if (this.logicTimer_0 != null)
			{
				int remainingSeconds = this.logicTimer_0.GetRemainingSeconds(this.m_parent.GetLevel().GetLogicTime());
				if (remainingSeconds > 0)
				{
					jsonObject.Put("unit_req_time", new LogicJSONNumber(remainingSeconds));
				}
			}
			if (this.logicTimer_1 != null)
			{
				int remainingSeconds2 = this.logicTimer_1.GetRemainingSeconds(this.m_parent.GetLevel().GetLogicTime());
				if (remainingSeconds2 > 0)
				{
					jsonObject.Put("clan_mail_time", new LogicJSONNumber(remainingSeconds2));
				}
			}
			if (this.logicTimer_2 != null)
			{
				int remainingSeconds3 = this.logicTimer_2.GetRemainingSeconds(this.m_parent.GetLevel().GetLogicTime());
				if (remainingSeconds3 > 0)
				{
					jsonObject.Put("share_replay_time", new LogicJSONNumber(remainingSeconds3));
				}
			}
			if (this.logicTimer_3 != null)
			{
				int remainingSeconds4 = this.logicTimer_3.GetRemainingSeconds(this.m_parent.GetLevel().GetLogicTime());
				if (remainingSeconds4 > 0)
				{
					jsonObject.Put("elder_kick_time", new LogicJSONNumber(remainingSeconds4));
				}
			}
			if (this.logicTimer_4 != null)
			{
				int remainingSeconds5 = this.logicTimer_4.GetRemainingSeconds(this.m_parent.GetLevel().GetLogicTime());
				if (remainingSeconds5 > 0)
				{
					jsonObject.Put("challenge_time", new LogicJSONNumber(remainingSeconds5));
				}
			}
			if (this.logicTimer_5 != null)
			{
				int remainingSeconds6 = this.logicTimer_5.GetRemainingSeconds(this.m_parent.GetLevel().GetLogicTime());
				if (remainingSeconds6 > 0)
				{
					jsonObject.Put("arrwar_time", new LogicJSONNumber(remainingSeconds6));
				}
			}
		}

		// Token: 0x06000EDD RID: 3805 RVA: 0x00039D14 File Offset: 0x00037F14
		public LogicCharacter ClosestAttacker(bool flyingTroop)
		{
			LogicArrayList<LogicGameObject> gameObjects = this.m_parent.GetLevel().GetGameObjectManagerAt(0).GetGameObjects(LogicGameObjectType.CHARACTER);
			int num = int.MaxValue;
			LogicCharacter result = null;
			for (int i = 0; i < gameObjects.Size(); i++)
			{
				LogicCharacter logicCharacter = (LogicCharacter)gameObjects[i];
				LogicHitpointComponent hitpointComponent = logicCharacter.GetHitpointComponent();
				LogicCombatComponent combatComponent = logicCharacter.GetCombatComponent();
				if ((combatComponent == null || combatComponent.GetUndergroundTime() <= 0) && (LogicDataTables.GetGlobals().SkeletonOpenClanCastle() || !LogicDataTables.IsSkeleton(logicCharacter.GetCharacterData())) && hitpointComponent != null && logicCharacter.IsAlive() && logicCharacter.IsFlying() == flyingTroop && hitpointComponent.GetTeam() == 0)
				{
					int distanceSquaredTo = logicCharacter.GetPosition().GetDistanceSquaredTo(this.m_parent.GetMidX(), this.m_parent.GetMidY());
					if (distanceSquaredTo < num)
					{
						num = distanceSquaredTo;
						result = logicCharacter;
					}
				}
			}
			return result;
		}

		// Token: 0x06000EDE RID: 3806 RVA: 0x00039DF8 File Offset: 0x00037FF8
		public override void Tick()
		{
			LogicAvatar homeOwnerAvatar = this.m_parent.GetLevel().GetHomeOwnerAvatar();
			if (homeOwnerAvatar != null)
			{
				this.int_2 += 64;
				if (this.int_2 > 1000)
				{
					homeOwnerAvatar.UpdateStarBonusLimitCooldown();
					homeOwnerAvatar.UpdateLootLimitCooldown();
					this.int_2 -= 1000;
				}
			}
			if (this.m_parent.IsAlive() && !base.IsEmpty())
			{
				if (this.int_3 > 0)
				{
					this.int_3 -= 64;
					return;
				}
				bool flag = false;
				bool flag4;
				if (this.int_1 == 1)
				{
					bool flag2 = false;
					bool flag3 = false;
					int clanCastleRadius = LogicDataTables.GetGlobals().GetClanCastleRadius();
					if (LogicDataTables.GetGlobals().CastleTroopTargetFilter())
					{
						LogicCharacter logicCharacter = this.ClosestAttacker(false);
						LogicCharacter logicCharacter2 = this.ClosestAttacker(true);
						if (logicCharacter2 != null)
						{
							flag2 = (logicCharacter2.GetPosition().GetDistanceSquaredTo(this.m_parent.GetMidX(), this.m_parent.GetMidY()) < clanCastleRadius * clanCastleRadius);
						}
						if (logicCharacter != null)
						{
							flag3 = (logicCharacter.GetPosition().GetDistanceSquaredTo(this.m_parent.GetMidX(), this.m_parent.GetMidY()) < clanCastleRadius * clanCastleRadius);
						}
					}
					else
					{
						LogicCharacter logicCharacter3 = (LogicCharacter)this.m_parent.GetLevel().GetGameObjectManager().GetClosestGameObject(this.m_parent.GetMidX(), this.m_parent.GetMidY(), this.logicGameObjectFilter_0);
						if (logicCharacter3 != null)
						{
							flag3 = (flag2 = (logicCharacter3.GetPosition().GetDistanceSquaredTo(this.m_parent.GetMidX(), this.m_parent.GetMidY()) < clanCastleRadius * clanCastleRadius));
						}
					}
					flag = !flag3;
					if (!(flag4 = flag2) && flag)
					{
						this.int_3 = LogicDataTables.GetGlobals().GetBunkerSearchTime();
						return;
					}
				}
				else
				{
					flag4 = true;
				}
				LogicCharacterData logicCharacterData = null;
				int num = -1;
				for (int i = 0; i < base.GetUnitTypeCount(); i++)
				{
					LogicCombatItemData unitType = base.GetUnitType(i);
					if (unitType != null && base.GetUnitCount(i) > 0)
					{
						int unitLevel = base.GetUnitLevel(i);
						if (unitType.GetCombatItemType() == LogicCombatItemType.CHARACTER)
						{
							LogicCharacterData logicCharacterData2 = (LogicCharacterData)unitType;
							LogicAttackerItemData attackerItemData = logicCharacterData2.GetAttackerItemData(unitLevel);
							if ((!flag4 || !flag || attackerItemData.GetTrackAirTargets(false)) && (flag4 || flag || attackerItemData.GetTrackGroundTargets(false)))
							{
								base.RemoveUnitsImpl(unitType, unitLevel, 1);
								logicCharacterData = logicCharacterData2;
								num = unitLevel;
								IL_23F:
								if (logicCharacterData != null)
								{
									LogicCharacter logicCharacter4 = (LogicCharacter)LogicGameObjectFactory.CreateGameObject(logicCharacterData, this.m_parent.GetLevel(), this.m_parent.GetVillageType());
									logicCharacter4.GetHitpointComponent().SetTeam(this.int_1);
									if (logicCharacter4.GetChildTroops() != null)
									{
										LogicArrayList<LogicCharacter> childTroops = logicCharacter4.GetChildTroops();
										for (int j = 0; j < childTroops.Size(); j++)
										{
											childTroops[j].GetHitpointComponent().SetTeam(this.int_1);
										}
									}
									logicCharacter4.SetUpgradeLevel((num != -1) ? num : -1);
									logicCharacter4.SetAllianceUnit();
									if (logicCharacter4.GetCharacterData().IsJumper())
									{
										logicCharacter4.GetMovementComponent().EnableJump(3600000);
									}
									if (this.int_1 != 0)
									{
										if (LogicDataTables.GetGlobals().EnableDefendingAllianceTroopJump())
										{
											logicCharacter4.GetMovementComponent().EnableJump(3600000);
										}
										if (LogicDataTables.GetGlobals().AllianceTroopsPatrol())
										{
											logicCharacter4.GetCombatComponent().SetSearchRadius(LogicDataTables.GetGlobals().GetClanCastleRadius() >> 9);
											if (this.m_parent.GetGameObjectType() == LogicGameObjectType.BUILDING)
											{
												logicCharacter4.GetMovementComponent().SetBaseBuilding((LogicBuilding)this.m_parent);
											}
										}
									}
									else
									{
										LogicAvatar visitorAvatar = this.m_parent.GetLevel().GetVisitorAvatar();
										visitorAvatar.RemoveAllianceUnit(logicCharacterData, num);
										visitorAvatar.GetChangeListener().AllianceUnitRemoved(logicCharacterData, num);
										LogicBattleLog battleLog = this.m_parent.GetLevel().GetBattleLog();
										battleLog.IncrementDeployedAllianceUnits(logicCharacterData, 1, num);
										battleLog.SetAllianceUsed(true);
									}
									if (this.int_1 == 1)
									{
										int num2 = 0;
										int num3 = 0;
										switch (this.int_4)
										{
										case 0:
											num2 = 1;
											num3 = 0;
											break;
										case 1:
											num2 = -1;
											num3 = 0;
											break;
										case 2:
											num2 = 0;
											num3 = 1;
											break;
										case 3:
											num2 = 0;
											num3 = -1;
											break;
										}
										logicCharacter4.SetInitialPosition(this.m_parent.GetMidX() + ((this.m_parent.GetWidthInTiles() << 8) - 128) * num2, this.m_parent.GetMidY() + ((this.m_parent.GetHeightInTiles() << 8) - 128) * num3);
										int num4 = this.int_4 + 1;
										this.int_4 = num4;
										if (num4 > 3)
										{
											this.int_4 = 0;
										}
									}
									else if (LogicDataTables.GetGlobals().AllowClanCastleDeployOnObstacles())
									{
										int x = this.m_parent.GetX() + (this.m_parent.GetWidthInTiles() << 9) - 128;
										int y = this.m_parent.GetY() + (this.m_parent.GetHeightInTiles() << 8);
										int x2;
										int y2;
										if (LogicGamePlayUtil.GetNearestValidAttackPos(this.m_parent.GetLevel(), x, y, out x2, out y2))
										{
											logicCharacter4.SetInitialPosition(x2, y2);
										}
										else
										{
											logicCharacter4.SetInitialPosition(x, y);
										}
									}
									else
									{
										logicCharacter4.SetInitialPosition(this.m_parent.GetX() + (this.m_parent.GetWidthInTiles() << 9) - 128, this.m_parent.GetY() + (this.m_parent.GetHeightInTiles() << 8));
									}
									this.m_parent.GetGameObjectManager().AddGameObject(logicCharacter4, -1);
								}
								this.int_3 = LogicDataTables.GetGlobals().GetBunkerSearchTime();
								return;
							}
						}
					}
				}
				goto IL_23F;
			}
		}

		// Token: 0x06000EDF RID: 3807 RVA: 0x0003A354 File Offset: 0x00038554
		public override void FastForwardTime(int time)
		{
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.FastForward(time);
			}
			if (this.logicTimer_2 != null)
			{
				this.logicTimer_2.FastForward(time);
			}
			if (this.logicTimer_3 != null)
			{
				this.logicTimer_3.FastForward(time);
			}
			if (this.logicTimer_1 != null)
			{
				this.logicTimer_1.FastForward(time);
			}
			if (this.logicTimer_4 != null)
			{
				this.logicTimer_4.FastForward(time);
			}
			if (this.logicTimer_5 != null)
			{
				this.logicTimer_5.FastForward(time);
			}
			LogicAvatar homeOwnerAvatar = this.m_parent.GetLevel().GetHomeOwnerAvatar();
			if (homeOwnerAvatar != null)
			{
				homeOwnerAvatar.FastForwardStarBonusLimit(time);
				homeOwnerAvatar.FastForwardLootLimit(time);
			}
		}

		// Token: 0x06000EE0 RID: 3808 RVA: 0x0000A4DA File Offset: 0x000086DA
		public LogicArrayList<LogicVector2> GetPatrolPath()
		{
			return this.logicArrayList_1;
		}

		// Token: 0x06000EE1 RID: 3809 RVA: 0x0003A3FC File Offset: 0x000385FC
		public LogicArrayList<LogicVector2> CreatePatrolPath()
		{
			int num = this.m_parent.GetWidthInTiles() << 8;
			int num2 = this.m_parent.GetHeightInTiles() << 8;
			if (num * num + num2 * num2 <= 2359296)
			{
				int midX = this.m_parent.GetMidX();
				int midY = this.m_parent.GetMidY();
				LogicVector2 logicVector = new LogicVector2();
				LogicVector2 logicVector2 = new LogicVector2();
				LogicVector2 logicVector3 = new LogicVector2();
				LogicVector2 logicVector4 = new LogicVector2();
				logicVector2.Set(midX, midY);
				LogicArrayList<LogicVector2> logicArrayList = new LogicArrayList<LogicVector2>(16);
				int i = 0;
				int num3 = 360;
				while (i < 16)
				{
					logicVector.Set(midX + LogicMath.Cos(num3 >> 5, 1536), midY + LogicMath.Sin(num3 >> 5, 1536));
					LogicHeroBaseComponent.FindPoint(this.m_parent.GetLevel().GetTileMap(), logicVector3, logicVector2, logicVector, logicVector4);
					logicArrayList.Add(new LogicVector2(logicVector4.m_x, logicVector4.m_y));
					i++;
					num3 += 720;
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

		// Token: 0x040005DD RID: 1501
		public const int PATROL_PATHS = 16;

		// Token: 0x040005DE RID: 1502
		private readonly LogicGameObjectFilter logicGameObjectFilter_0;

		// Token: 0x040005DF RID: 1503
		private LogicTimer logicTimer_0;

		// Token: 0x040005E0 RID: 1504
		private LogicTimer logicTimer_1;

		// Token: 0x040005E1 RID: 1505
		private LogicTimer logicTimer_2;

		// Token: 0x040005E2 RID: 1506
		private LogicTimer logicTimer_3;

		// Token: 0x040005E3 RID: 1507
		private LogicTimer logicTimer_4;

		// Token: 0x040005E4 RID: 1508
		private LogicTimer logicTimer_5;

		// Token: 0x040005E5 RID: 1509
		private LogicArrayList<LogicVector2> logicArrayList_1;

		// Token: 0x040005E6 RID: 1510
		private int int_1;

		// Token: 0x040005E7 RID: 1511
		private int int_2;

		// Token: 0x040005E8 RID: 1512
		private int int_3;

		// Token: 0x040005E9 RID: 1513
		private int int_4;
	}
}
