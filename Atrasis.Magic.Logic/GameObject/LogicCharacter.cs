using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.GameObject
{
	// Token: 0x0200010E RID: 270
	public sealed class LogicCharacter : LogicGameObject
	{
		// Token: 0x06000D2E RID: 3374 RVA: 0x0002EB18 File Offset: 0x0002CD18
		public LogicCharacter(LogicGameObjectData data, LogicLevel level, int villageType) : base(data, level, villageType)
		{
			LogicCharacterData logicCharacterData = (LogicCharacterData)data;
			this.bool_0 = logicCharacterData.IsFlying();
			base.AddComponent(new LogicHitpointComponent(this, logicCharacterData.GetHitpoints(0), 0));
			base.AddComponent(new LogicCombatComponent(this));
			base.AddComponent(new LogicMovementComponent(this, logicCharacterData.GetSpeed(), logicCharacterData.IsFlying(), logicCharacterData.IsUnderground()));
			this.SetUpgradeLevel(0);
			int childTroopCount = logicCharacterData.GetChildTroopCount();
			if (childTroopCount > 0)
			{
				this.logicArrayList_1 = new LogicArrayList<LogicCharacter>(childTroopCount);
				for (int i = 0; i < childTroopCount; i++)
				{
					LogicCharacter logicCharacter = new LogicCharacter(logicCharacterData.GetChildTroop(), level, villageType);
					logicCharacter.SetTroopChild(this, i);
					logicCharacter.GetCombatComponent().SetTroopChild(true);
					this.logicArrayList_1.Add(logicCharacter);
					base.GetGameObjectManager().AddGameObject(logicCharacter, -1);
				}
			}
			this.logicVector2_0 = new LogicVector2();
			this.logicArrayList_0 = new LogicArrayList<LogicCharacter>();
			if (logicCharacterData.IsUnderground())
			{
				base.GetCombatComponent().SetUndergroundTime(3600000);
			}
		}

		// Token: 0x06000D2F RID: 3375 RVA: 0x0000974A File Offset: 0x0000794A
		public LogicCharacterData GetCharacterData()
		{
			return (LogicCharacterData)this.m_data;
		}

		// Token: 0x06000D30 RID: 3376 RVA: 0x00009757 File Offset: 0x00007957
		public LogicAttackerItemData GetAttackerItemData()
		{
			return this.GetCharacterData().GetAttackerItemData(this.int_5);
		}

		// Token: 0x06000D31 RID: 3377 RVA: 0x0000976A File Offset: 0x0000796A
		public LogicCharacterData GetSummoner()
		{
			return this.logicCharacterData_0;
		}

		// Token: 0x06000D32 RID: 3378 RVA: 0x00002B36 File Offset: 0x00000D36
		public override LogicGameObjectType GetGameObjectType()
		{
			return LogicGameObjectType.CHARACTER;
		}

		// Token: 0x06000D33 RID: 3379 RVA: 0x00009772 File Offset: 0x00007972
		public override bool IsHero()
		{
			return this.GetCharacterData().GetDataType() == LogicDataType.HERO;
		}

		// Token: 0x06000D34 RID: 3380 RVA: 0x00009783 File Offset: 0x00007983
		public override bool IsFlying()
		{
			return this.bool_0;
		}

		// Token: 0x06000D35 RID: 3381 RVA: 0x0000978B File Offset: 0x0000798B
		public int GetSecondaryTroopTeam()
		{
			return this.int_17;
		}

		// Token: 0x06000D36 RID: 3382 RVA: 0x00009793 File Offset: 0x00007993
		public void SetSecondaryTroopTeam(int value)
		{
			this.int_17 = value;
		}

		// Token: 0x06000D37 RID: 3383 RVA: 0x0000979C File Offset: 0x0000799C
		public bool GetWaitDieDamage()
		{
			return this.GetCharacterData().GetDieDamageDelay() > this.int_14;
		}

		// Token: 0x06000D38 RID: 3384 RVA: 0x000097B1 File Offset: 0x000079B1
		public int GetSpawnDelay()
		{
			return this.int_15;
		}

		// Token: 0x06000D39 RID: 3385 RVA: 0x000097B9 File Offset: 0x000079B9
		public void SetSpawnTime(int time)
		{
			this.int_15 = time;
			if (time > 0)
			{
				this.bool_6 = true;
			}
		}

		// Token: 0x06000D3A RID: 3386 RVA: 0x000097CD File Offset: 0x000079CD
		public int GetSpawnIdleTime()
		{
			return this.int_16;
		}

		// Token: 0x06000D3B RID: 3387 RVA: 0x000097D5 File Offset: 0x000079D5
		public int GetSummonTroopCount()
		{
			return this.logicArrayList_0.Size();
		}

		// Token: 0x06000D3C RID: 3388 RVA: 0x000097E2 File Offset: 0x000079E2
		public LogicArrayList<LogicCharacter> GetChildTroops()
		{
			return this.logicArrayList_1;
		}

		// Token: 0x06000D3D RID: 3389 RVA: 0x0002EC14 File Offset: 0x0002CE14
		public override void SetInitialPosition(int x, int y)
		{
			base.SetInitialPosition(x, y);
			LogicMovementComponent movementComponent = base.GetMovementComponent();
			if (movementComponent != null)
			{
				movementComponent.GetMovementSystem().Reset(x, y);
			}
			if (this.logicArrayList_1 != null)
			{
				for (int i = 0; i < this.logicArrayList_1.Size(); i++)
				{
					this.logicArrayList_1[i].SetInitialPosition(x, y);
				}
			}
		}

		// Token: 0x06000D3E RID: 3390 RVA: 0x0002EC74 File Offset: 0x0002CE74
		public override bool ShouldDestruct()
		{
			if (this.m_level.IsInCombatState())
			{
				int num = 5000;
				if (this.bool_1)
				{
					num += (this.int_13 >> 31 & -4999);
				}
				return this.int_14 > num;
			}
			return true;
		}

		// Token: 0x06000D3F RID: 3391 RVA: 0x000097EA File Offset: 0x000079EA
		public bool HasSpecialAbility()
		{
			return this.GetCharacterData().GetSpecialAbilityLevel(this.int_5) > 0;
		}

		// Token: 0x06000D40 RID: 3392 RVA: 0x00009800 File Offset: 0x00007A00
		public int GetUpgradeLevel()
		{
			return this.int_5;
		}

		// Token: 0x06000D41 RID: 3393 RVA: 0x0002ECBC File Offset: 0x0002CEBC
		public void SetUpgradeLevel(int upgLevel)
		{
			this.int_5 = upgLevel;
			LogicCharacterData characterData = this.GetCharacterData();
			LogicHitpointComponent hitpointComponent = base.GetHitpointComponent();
			LogicCombatComponent combatComponent = base.GetCombatComponent();
			int num = characterData.GetHitpoints(upgLevel);
			int num2 = 100;
			if (characterData.GetScaleByTH())
			{
				LogicAvatar logicAvatar = this.m_level.GetHomeOwnerAvatar();
				if (hitpointComponent != null && hitpointComponent.GetTeam() == 0)
				{
					logicAvatar = this.m_level.GetVisitorAvatar();
				}
				int num3 = 700 * logicAvatar.GetTownHallLevel() / (LogicDataTables.GetTownHallLevelCount() - 1);
				num2 = num3 / 10 + 30;
				num = num2 * num / 100;
				if (num2 * num < 200)
				{
					num = 1;
				}
				if (num3 < -289)
				{
					num2 = 1;
				}
			}
			hitpointComponent.SetMaxHitpoints(num);
			hitpointComponent.SetHitpoints(characterData.GetHitpoints(upgLevel));
			hitpointComponent.SetDieEffect(characterData.GetDieEffect(upgLevel), characterData.GetDieEffect2(upgLevel));
			if (combatComponent != null)
			{
				combatComponent.SetAttackValues(characterData.GetAttackerItemData(upgLevel), num2);
			}
			if (this.logicArrayList_1 != null)
			{
				for (int i = 0; i < this.logicArrayList_1.Size(); i++)
				{
					this.logicArrayList_1[i].SetUpgradeLevel(upgLevel);
				}
			}
			if (this.IsHero())
			{
				LogicHeroData logicHeroData = (LogicHeroData)this.m_data;
				LogicAvatar logicAvatar2 = this.m_level.GetHomeOwnerAvatar();
				if (hitpointComponent.GetTeam() == 0)
				{
					logicAvatar2 = this.m_level.GetVisitorAvatar();
				}
				this.bool_0 = logicHeroData.IsFlying(logicAvatar2.GetHeroMode(logicHeroData));
				base.GetMovementComponent().SetFlying(this.bool_0);
			}
			if (characterData.GetAutoMergeDistance() > 0)
			{
				this.int_19 = 2000;
			}
			int num4 = characterData.GetSpeed();
			if (characterData.GetSpecialAbilityLevel(this.int_5) > 0 && characterData.GetSpecialAbilityType() == 3)
			{
				num4 = num4 * characterData.GetSpecialAbilityAttribute(this.int_5) / 100;
			}
			base.GetMovementComponent().SetSpeed(num4);
		}

		// Token: 0x06000D42 RID: 3394 RVA: 0x00009808 File Offset: 0x00007A08
		public LogicCharacter GetParent()
		{
			return this.logicCharacter_0;
		}

		// Token: 0x06000D43 RID: 3395 RVA: 0x0002EE80 File Offset: 0x0002D080
		public void SetTroopChild(LogicCharacter character, int idx)
		{
			this.logicCharacter_0 = character;
			if (character != null)
			{
				this.int_11 = (character.GetCharacterData().GetChildTroopX(idx) << 9) / 100;
				this.int_12 = (character.GetCharacterData().GetChildTroopY(idx) << 9) / 100;
				this.bool_3 = true;
			}
		}

		// Token: 0x06000D44 RID: 3396 RVA: 0x00009810 File Offset: 0x00007A10
		public void SetDuplicate(bool clone, int lifetime)
		{
			this.bool_1 = clone;
			this.int_13 = lifetime;
		}

		// Token: 0x06000D45 RID: 3397 RVA: 0x0002EED0 File Offset: 0x0002D0D0
		public bool TileOkForTombstone(LogicTile tile)
		{
			if (tile != null && !tile.IsFullyNotPassable())
			{
				int i = 0;
				while (i < tile.GetGameObjectCount())
				{
					LogicGameObject gameObject = tile.GetGameObject(i);
					if (gameObject.GetGameObjectType() != LogicGameObjectType.BUILDING && gameObject.GetGameObjectType() != LogicGameObjectType.OBSTACLE && gameObject.GetGameObjectType() != LogicGameObjectType.TRAP)
					{
						if (gameObject.GetGameObjectType() != LogicGameObjectType.DECO)
						{
							i++;
							continue;
						}
					}
					return false;
				}
				return true;
			}
			return false;
		}

		// Token: 0x06000D46 RID: 3398 RVA: 0x0002EF2C File Offset: 0x0002D12C
		public void Eject(LogicVector2 pos)
		{
			if (!this.IsFlying())
			{
				if (pos != null)
				{
					this.logicVector2_0.Set(pos.m_x, pos.m_y);
				}
				else
				{
					this.logicVector2_0.Set(0, 0);
				}
				this.bool_5 = true;
				base.GetHitpointComponent().Kill();
			}
		}

		// Token: 0x06000D47 RID: 3399 RVA: 0x00009820 File Offset: 0x00007A20
		public void SetAllianceUnit()
		{
			this.bool_4 = true;
		}

		// Token: 0x06000D48 RID: 3400 RVA: 0x00009829 File Offset: 0x00007A29
		public int GetAbilityCooldown()
		{
			return this.int_8;
		}

		// Token: 0x06000D49 RID: 3401 RVA: 0x00009831 File Offset: 0x00007A31
		public int GetAbilityTime()
		{
			return this.int_7;
		}

		// Token: 0x06000D4A RID: 3402 RVA: 0x00009839 File Offset: 0x00007A39
		public bool IsAbilityUsed()
		{
			return this.bool_2;
		}

		// Token: 0x06000D4B RID: 3403 RVA: 0x0002EF7C File Offset: 0x0002D17C
		public void StartAbility()
		{
			if (this.IsHero())
			{
				LogicHeroData logicHeroData = (LogicHeroData)this.m_data;
				this.int_8 = 60 * logicHeroData.GetAbilityCooldown() / 4000;
				this.int_6 = 5;
				this.int_7 = 60 * logicHeroData.GetAbilityTime(this.int_5) / 20000;
				this.int_10 = 0;
				base.GetHitpointComponent().CauseDamage(-100 * logicHeroData.GetAbilityHealthIncrease(this.int_5), 0, this);
				this.int_9 = base.GetCombatComponent().GetHitCount() + logicHeroData.GetAbilityAttackCount(this.int_5);
				if (logicHeroData.GetAbilityDelay() > 0)
				{
					base.GetCombatComponent().SetAttackDelay(0, logicHeroData.GetAbilityDelay());
				}
				LogicSpellData abilitySpell = logicHeroData.GetAbilitySpell(this.int_5);
				if (abilitySpell != null)
				{
					this.logicSpell_1 = (LogicSpell)LogicGameObjectFactory.CreateGameObject(abilitySpell, this.m_level, this.m_villageType);
					this.logicSpell_1.SetUpgradeLevel(logicHeroData.GetAbilitySpellLevel(this.int_5));
					this.logicSpell_1.SetInitialPosition(base.GetX(), base.GetY());
					this.logicSpell_1.AllowDestruction(false);
					base.GetGameObjectManager().AddGameObject(this.logicSpell_1, -1);
				}
				if (logicHeroData.GetActivationTime() > 0)
				{
					this.int_22 = 1;
					this.int_23 = logicHeroData.GetActivationTime();
					base.GetMovementComponent().GetMovementSystem().SetFreezeTime(this.int_23);
					base.GetCombatComponent().SetActivationTime(this.int_23);
				}
				this.bool_2 = true;
			}
		}

		// Token: 0x06000D4C RID: 3404 RVA: 0x0002F0F8 File Offset: 0x0002D2F8
		public bool GetSpecialAbilityAvailable()
		{
			LogicCharacterData characterData = this.GetCharacterData();
			if (characterData.GetSpecialAbilityLevel(this.int_5) <= 0)
			{
				return false;
			}
			int specialAbilityType = characterData.GetSpecialAbilityType();
			if (specialAbilityType != 1)
			{
				return specialAbilityType != 6 || base.GetCombatComponent().GetHitCount() < characterData.GetSpecialAbilityAttribute(this.int_5);
			}
			return base.GetCombatComponent().GetHitCount() <= 0;
		}

		// Token: 0x06000D4D RID: 3405 RVA: 0x0002F15C File Offset: 0x0002D35C
		public bool IsWallBreaker()
		{
			LogicCombatComponent combatComponent = base.GetCombatComponent();
			return combatComponent != null && combatComponent.IsWallBreaker();
		}

		// Token: 0x06000D4E RID: 3406 RVA: 0x00009841 File Offset: 0x00007A41
		public int GetEjectTime()
		{
			if (this.bool_5)
			{
				return this.int_14 + 1;
			}
			return 0;
		}

		// Token: 0x06000D4F RID: 3407 RVA: 0x00009855 File Offset: 0x00007A55
		public override int GetHitEffectOffset()
		{
			return this.GetCharacterData().GetHitEffectOffset();
		}

		// Token: 0x06000D50 RID: 3408 RVA: 0x0002F17C File Offset: 0x0002D37C
		public override void DeathEvent()
		{
			LogicHitpointComponent hitpointComponent = base.GetHitpointComponent();
			LogicCharacterData characterData = this.GetCharacterData();
			if (hitpointComponent != null && hitpointComponent.GetTeam() == 1 && !this.IsHero() && !characterData.IsSecondaryTroop() && this.m_level.GetVillageType() == 0 && this.bool_4)
			{
				LogicAvatar homeOwnerAvatar = this.m_level.GetHomeOwnerAvatar();
				homeOwnerAvatar.RemoveAllianceUnit(characterData, this.int_5);
				homeOwnerAvatar.GetChangeListener().AllianceUnitRemoved(characterData, this.int_5);
			}
			if (characterData.GetSpecialAbilityType() == 8 && characterData.GetSpecialAbilityLevel(this.int_5) > 0)
			{
				if (!this.bool_5)
				{
					this.CheckSpawning(LogicDataTables.GetCharacterByName("MovingCannonSecondary", null), 1, characterData.GetSpecialAbilityAttribute(this.int_5), 500);
				}
			}
			else if (characterData.GetSpecialAbilityType() == 5)
			{
				if (characterData.GetSpecialAbilityLevel(this.int_5) > 0)
				{
					this.CheckSpawning(null, characterData.GetSpecialAbilityAttribute(this.int_5), 0, 0);
				}
			}
			else if (characterData.GetSecondaryTroop() != null)
			{
				this.CheckSpawning(null, 0, 0, 0);
			}
			this.AddTombstoneIfNeeded();
			if (this.logicCharacter_0 != null)
			{
				this.logicCharacter_0.RemoveChildren(this);
				this.logicCharacter_0 = null;
			}
			base.DeathEvent();
		}

		// Token: 0x06000D51 RID: 3409 RVA: 0x0002F2A0 File Offset: 0x0002D4A0
		public void RemoveChildren(LogicCharacter children)
		{
			if (this.logicArrayList_1.Size() > 0)
			{
				int num = this.logicArrayList_1.IndexOf(children);
				if (num != -1)
				{
					this.logicArrayList_1.Remove(num);
					if (this.logicArrayList_1.Size() != 0)
					{
						int num2 = this.GetCharacterData().GetChildTroopCount() - this.logicArrayList_1.Size();
						base.GetMovementComponent().GetMovementSystem().SetSpeed(this.GetCharacterData().GetSpeed() - this.GetCharacterData().GetSpeedDecreasePerChildTroopLost() * num2);
						return;
					}
					base.GetHitpointComponent().Kill();
				}
			}
		}

		// Token: 0x06000D52 RID: 3410 RVA: 0x0002F334 File Offset: 0x0002D534
		public void AddTombstoneIfNeeded()
		{
			if (!this.bool_5 && this.m_level.GetTombStoneCount() < 40)
			{
				int num = base.GetTileX();
				int num2 = base.GetTileY();
				LogicTileMap tileMap = this.m_level.GetTileMap();
				LogicTile tile = tileMap.GetTile(num, num2);
				if (!this.TileOkForTombstone(tile))
				{
					int num3 = 0;
					int num4 = -1;
					int num5 = -1;
					for (int i = -1; i < 2; i++)
					{
						int num6 = i + num << 9 | 256;
						int num7 = 256 - (num2 << 9);
						int j = -1;
						while (j < 2)
						{
							tile = tileMap.GetTile(num + i, num2 + j);
							if (this.TileOkForTombstone(tile))
							{
								int num8 = base.GetX() - num6;
								int num9 = base.GetY() + num7;
								int num10 = num8 * num8 + num9 * num9;
								if (num3 == 0 || num10 < num3)
								{
									num3 = num10;
									num4 = num + i;
									num5 = num2 + j;
								}
							}
							j++;
							num7 -= 512;
						}
					}
					if (num3 == 0)
					{
						return;
					}
					num = num4;
					num2 = num5;
				}
				LogicObstacleData tombstone = this.GetCharacterData().GetTombstone();
				if (tombstone != null)
				{
					LogicObstacle logicObstacle = (LogicObstacle)LogicGameObjectFactory.CreateGameObject(tombstone, this.m_level, this.m_villageType);
					logicObstacle.SetInitialPosition(num << 9, num2 << 9);
					base.GetGameObjectManager().AddGameObject(logicObstacle, -1);
				}
			}
		}

		// Token: 0x06000D53 RID: 3411 RVA: 0x0002F484 File Offset: 0x0002D684
		public void CheckSpawning(LogicCharacterData spawnCharacterData, int spawnCount, int spawnUpgradeLevel, int invulnerabilityTime)
		{
			LogicCharacterData characterData = this.GetCharacterData();
			if (spawnCharacterData == null)
			{
				spawnCharacterData = characterData.GetSecondaryTroop();
				if (spawnCharacterData == null)
				{
					spawnCharacterData = characterData.GetAttackerItemData(this.int_5).GetSummonTroop();
					if (spawnCharacterData == null)
					{
						return;
					}
				}
			}
			if (!spawnCharacterData.IsSecondaryTroop() && !this.IsHero())
			{
				Debugger.Warning("checkSpawning: trying to spawn normal troops!");
			}
			else
			{
				int num = spawnCount;
				int num2 = this.int_5;
				if (num2 >= spawnCharacterData.GetUpgradeLevelCount())
				{
					num2 = spawnCharacterData.GetUpgradeLevelCount() - 1;
				}
				if (this.IsHero())
				{
					if (this.int_10 >= spawnCount)
					{
						return;
					}
					num2 = spawnUpgradeLevel;
					num = LogicMath.Max(0, LogicMath.Min(3, spawnCount - this.int_10));
				}
				else if (characterData.GetSecondaryTroopCount(this.int_5) != 0)
				{
					num = characterData.GetSecondaryTroopCount(this.int_5);
				}
				else if (spawnCount == 0)
				{
					num = characterData.GetAttackerItemData(this.int_5).GetSummonTroopCount();
					if (this.logicArrayList_0.Size() + num > characterData.GetAttackerItemData(this.int_5).GetSummonLimit())
					{
						num = characterData.GetAttackerItemData(this.int_5).GetSummonLimit() - this.logicArrayList_0.Size();
					}
				}
				if (num > 0)
				{
					LogicVector2 logicVector = new LogicVector2();
					LogicRandom logicRandom = new LogicRandom(this.m_globalId);
					int team = base.GetHitpointComponent().GetTeam();
					bool randomizeSecSpawnDist = this.GetCharacterData().GetRandomizeSecSpawnDist();
					int i = 0;
					int num3 = 0;
					int num4 = 0;
					while (i < num)
					{
						int num5 = num3 / num;
						if (this.IsHero())
						{
							num5 = 360 * (i + this.int_10) / LogicMath.Max(1, LogicMath.Min(6, spawnCount));
						}
						int num6 = 59 * this.m_globalId % 360 + num5;
						if (spawnCharacterData.IsFlying())
						{
							LogicCharacterData characterData2 = this.GetCharacterData();
							logicVector.Set(base.GetX() + LogicMath.GetRotatedX(characterData2.GetSecondarySpawnOffset(), 0, num6), base.GetY() + LogicMath.GetRotatedY(characterData2.GetSecondarySpawnOffset(), 0, num6));
							goto IL_20B;
						}
						if (spawnCharacterData.GetSpeed() == 0)
						{
							logicVector.Set(base.GetX(), base.GetY());
							goto IL_20B;
						}
						if (this.m_level.GetTileMap().GetNearestPassablePosition(base.GetX(), base.GetY(), logicVector, 1536))
						{
							goto IL_20B;
						}
						IL_42C:
						i++;
						num3 += 360;
						num4 += 100;
						continue;
						IL_20B:
						LogicCharacter logicCharacter = (LogicCharacter)LogicGameObjectFactory.CreateGameObject(spawnCharacterData, this.m_level, this.m_villageType);
						if (this.GetCharacterData().GetAttackerItemData(this.int_5).GetSummonTroop() != null || this.IsHero())
						{
							this.logicArrayList_0.Add(logicCharacter);
						}
						logicCharacter.GetHitpointComponent().SetTeam(team);
						logicCharacter.SetUpgradeLevel(num2);
						logicCharacter.SetInitialPosition(logicVector.m_x, logicVector.m_y);
						if (this.bool_1)
						{
							logicCharacter.int_13 = this.int_13;
							logicCharacter.bool_1 = true;
						}
						if (!this.IsHero())
						{
							logicCharacter.logicCharacterData_0 = (LogicCharacterData)this.m_data;
						}
						if (invulnerabilityTime > 0)
						{
							logicCharacter.GetHitpointComponent().SetInvulnerabilityTime(invulnerabilityTime);
						}
						int num7 = this.IsHero() ? 768 : this.GetCharacterData().GetSecondarySpawnDistance();
						if (num7 > 0)
						{
							if (randomizeSecSpawnDist)
							{
								num7 = (int)((long)logicRandom.Rand(num7) + (long)((ulong)((uint)num7 >> 1)));
							}
							logicVector.Set(LogicMath.Cos(num6, num7), LogicMath.Sin(num6, num7));
							int num8 = logicCharacter.GetCharacterData().GetPushbackSpeed();
							if (num8 <= 0)
							{
								num8 = 1;
							}
							int num9 = 2 * num7 / (3 * num8);
							if (base.GetHitpointComponent().GetHitpoints() > 0)
							{
								if (this.GetAttackerItemData().GetSummonTroop() != null)
								{
									logicCharacter.SetSpawnTime(num9);
								}
								else if (this.IsHero())
								{
									logicCharacter.SetSpawnTime(num9 + num4);
								}
							}
							logicCharacter.GetMovementComponent().GetMovementSystem().PushTrap(logicVector, num9, 0, false, false);
						}
						if (team == 1 || logicCharacter.GetCharacterData().IsJumper())
						{
							logicCharacter.GetMovementComponent().EnableJump(3600000);
							logicCharacter.GetCombatComponent().RefreshTarget(true);
						}
						if (team == 1 && LogicDataTables.GetGlobals().AllianceTroopsPatrol())
						{
							logicCharacter.GetCombatComponent().SetSearchRadius(LogicDataTables.GetGlobals().GetClanCastleRadius() >> 9);
							if (base.GetMovementComponent().GetBaseBuilding() != null)
							{
								logicCharacter.GetMovementComponent().SetBaseBuilding(base.GetMovementComponent().GetBaseBuilding());
							}
						}
						base.GetGameObjectManager().AddGameObject(logicCharacter, -1);
						if (this.IsHero())
						{
							this.int_10++;
							goto IL_42C;
						}
						goto IL_42C;
					}
					logicVector.Destruct();
					return;
				}
			}
		}

		// Token: 0x06000D54 RID: 3412 RVA: 0x00009862 File Offset: 0x00007A62
		public override void SpawnEvent(LogicCharacterData data, int count, int upgLevel)
		{
			this.CheckSpawning(data, count, upgLevel, 0);
		}

		// Token: 0x06000D55 RID: 3413 RVA: 0x0002F8E4 File Offset: 0x0002DAE4
		public override void SubTick()
		{
			base.SubTick();
			LogicCombatComponent combatComponent = base.GetCombatComponent();
			LogicMovementComponent movementComponent = base.GetMovementComponent();
			if (combatComponent != null)
			{
				combatComponent.SubTick();
			}
			if (movementComponent != null)
			{
				movementComponent.SubTick();
				LogicVector2 position = movementComponent.GetMovementSystem().GetPosition();
				base.SetPositionXY(position.m_x, position.m_y);
			}
			else if (this.bool_3)
			{
				LogicVector2 logicVector = new LogicVector2(this.int_11, this.int_12);
				logicVector.Rotate(this.logicCharacter_0.GetDirection());
				LogicVector2 position2 = this.logicCharacter_0.GetMovementComponent().GetMovementSystem().GetPosition();
				base.SetPositionXY(logicVector.m_x + position2.m_x, logicVector.m_y + position2.m_y);
			}
			if (this.logicArrayList_1 != null)
			{
				for (int i = 0; i < this.logicArrayList_1.Size(); i++)
				{
					this.logicArrayList_1[i].SubTick();
				}
			}
			int x = base.GetX() + (this.GetWidthInTiles() << 8);
			int y = base.GetY() + (this.GetHeightInTiles() << 8);
			if (this.logicSpell_0 != null)
			{
				this.logicSpell_0.SetPositionXY(x, y);
			}
			if (this.logicSpell_1 != null)
			{
				this.logicSpell_1.SetPositionXY(x, y);
			}
			if (this.logicSpell_2 != null)
			{
				this.logicSpell_2.SetPositionXY(x, y);
			}
		}

		// Token: 0x06000D56 RID: 3414 RVA: 0x0002FA38 File Offset: 0x0002DC38
		public override void Tick()
		{
			base.Tick();
			LogicCharacterData characterData = this.GetCharacterData();
			if (!base.IsAlive())
			{
				if (!this.IsHero())
				{
					int dieDamageDelay = this.GetCharacterData().GetDieDamageDelay();
					int num = this.int_14;
					this.int_14 += 64;
					if (dieDamageDelay >= num && dieDamageDelay < this.int_14 && (!this.bool_1 || this.int_13 >= 0))
					{
						this.CheckDieDamage(characterData.GetDieDamage(this.int_5), characterData.GetDieDamageRadius());
						this.m_level.UpdateBattleStatus();
					}
				}
				this.int_15 = 0;
				this.int_16 = 0;
				if (this.logicSpell_0 != null)
				{
					base.GetGameObjectManager().RemoveGameObject(this.logicSpell_0);
					this.logicSpell_0 = null;
				}
				if (this.logicSpell_1 != null)
				{
					base.GetGameObjectManager().RemoveGameObject(this.logicSpell_1);
					this.logicSpell_1 = null;
				}
				if (this.logicSpell_2 != null)
				{
					base.GetGameObjectManager().RemoveGameObject(this.logicSpell_2);
					this.logicSpell_2 = null;
				}
			}
			else
			{
				if (characterData.GetLoseHpPerTick() > 0)
				{
					this.int_20 += 64;
					if (this.int_20 > characterData.GetLoseHpInterval())
					{
						LogicHitpointComponent hitpointComponent = base.GetHitpointComponent();
						if (hitpointComponent != null)
						{
							hitpointComponent.CauseDamage(100 * characterData.GetLoseHpPerTick(), this.m_globalId, this);
						}
						this.int_20 = 0;
					}
				}
				if (characterData.GetAttackCount(this.int_5) > 0 && base.GetCombatComponent() != null && base.GetHitpointComponent() != null && base.GetCombatComponent().GetHitCount() >= characterData.GetAttackCount(this.int_5))
				{
					base.GetHitpointComponent().Kill();
				}
				this.int_15 = LogicMath.Max(this.int_15 - 64, 0);
				this.int_16 = LogicMath.Max(this.int_16 - 64, 0);
				if (this.int_15 == 0 && this.bool_6)
				{
					this.int_16 = LogicMath.Max(10, characterData.GetSpawnIdle());
					this.bool_6 = false;
				}
				if (characterData.GetBoostedIfAlone() || (characterData.GetSpecialAbilityType() == 7 && this.GetSpecialAbilityAvailable()))
				{
					int num2 = this.int_21 + 1;
					this.int_21 = num2;
					if (num2 >= 5)
					{
						this.m_level.AreaBoostAlone(this, 6);
						this.int_21 = 0;
					}
				}
				if (this.IsHero())
				{
					LogicHeroData logicHeroData = (LogicHeroData)characterData;
					if (this.int_7 > 0)
					{
						if (logicHeroData.GetAbilityAttackCount(this.int_5) > 0 && base.GetCombatComponent().GetHitCount() >= this.int_9)
						{
							this.int_7 = 0;
							this.int_6 = 0;
							this.int_23 = 0;
						}
						else
						{
							int num2 = this.int_6 + 1;
							this.int_6 = num2;
							if (num2 >= 5)
							{
								this.int_7--;
								this.int_6 = 0;
								this.m_level.AreaAbilityBoost(this, 5);
							}
						}
					}
					if (this.int_8 > 0)
					{
						this.int_8--;
					}
					if (this.logicSpell_1 != null && this.logicSpell_1.GetHitsCompleted())
					{
						base.GetGameObjectManager().RemoveGameObject(this.logicSpell_1);
						this.logicSpell_1 = null;
					}
				}
				if (this.logicSpell_0 == null || this.logicSpell_0.GetHitsCompleted())
				{
					if (this.logicSpell_0 != null)
					{
						base.GetGameObjectManager().RemoveGameObject(this.logicSpell_0);
						this.logicSpell_0 = null;
					}
					if (characterData.GetAuraSpell(this.int_5) != null)
					{
						LogicHitpointComponent hitpointComponent2 = base.GetHitpointComponent();
						if (hitpointComponent2 != null && hitpointComponent2.GetTeam() == 0)
						{
							this.logicSpell_0 = (LogicSpell)LogicGameObjectFactory.CreateGameObject(characterData.GetAuraSpell(this.int_5), this.m_level, this.m_villageType);
							this.logicSpell_0.SetUpgradeLevel(characterData.GetAuraSpellLevel(this.int_5));
							this.logicSpell_0.SetInitialPosition(base.GetX(), base.GetY());
							this.logicSpell_0.AllowDestruction(false);
							this.logicSpell_0.SetTeam(hitpointComponent2.GetTeam());
							base.GetGameObjectManager().AddGameObject(this.logicSpell_0, -1);
						}
					}
				}
				if (!this.bool_7 && characterData.GetRetributionSpell(this.int_5) != null)
				{
					LogicHitpointComponent hitpointComponent3 = base.GetHitpointComponent();
					if (hitpointComponent3.GetHitpoints() <= hitpointComponent3.GetMaxHitpoints() * characterData.GetRetributionSpellTriggerHealth(this.int_5) / 100)
					{
						this.bool_7 = true;
						this.logicSpell_2 = (LogicSpell)LogicGameObjectFactory.CreateGameObject(characterData.GetRetributionSpell(this.int_5), this.m_level, this.m_villageType);
						this.logicSpell_2.SetUpgradeLevel(characterData.GetRetributionSpellLevel(this.int_5));
						this.logicSpell_2.SetPositionXY(base.GetX(), base.GetY());
						this.logicSpell_2.AllowDestruction(false);
						this.logicSpell_2.SetTeam(hitpointComponent3.GetTeam());
						base.GetGameObjectManager().AddGameObject(this.logicSpell_2, -1);
					}
				}
				if (this.int_22 == 2)
				{
					this.int_23 -= 64;
					if (this.int_23 < 0)
					{
						this.int_22 = 0;
						this.int_23 = 0;
					}
				}
				else if (this.int_22 == 1)
				{
					this.int_23 -= 64;
					if (this.int_23 < 0)
					{
						this.int_22 = 2;
						this.int_23 = ((LogicHeroData)this.m_data).GetActiveDuration();
					}
				}
			}
			this.CheckSummons();
			if (base.IsAlive())
			{
				if (characterData.GetAutoMergeDistance() > 0)
				{
					this.int_19 = LogicMath.Max(this.int_19 - 64, 0);
				}
				if (characterData.GetInvisibilityRadius() > 0)
				{
					this.m_level.AreaInvisibility(this.GetMidX(), this.GetMidY(), characterData.GetInvisibilityRadius(), 4, base.GetHitpointComponent().GetTeam());
				}
				if (characterData.GetHealthReductionPerSecond() > 0)
				{
					base.GetHitpointComponent().CauseDamage(100 * characterData.GetHealthReductionPerSecond() / 15, 0, this);
				}
			}
			if (this.bool_1)
			{
				int num2 = this.int_13;
				this.int_13 = num2 - 1;
				if (num2 <= 0)
				{
					LogicHitpointComponent hitpointComponent4 = base.GetHitpointComponent();
					if (hitpointComponent4 != null)
					{
						hitpointComponent4.SetHitpoints(0);
						this.m_level.UpdateBattleStatus();
					}
				}
			}
		}

		// Token: 0x06000D57 RID: 3415 RVA: 0x00030024 File Offset: 0x0002E224
		public void CheckDieDamage(int damage, int radius)
		{
			LogicCharacterData logicCharacterData = (LogicCharacterData)this.m_data;
			if (logicCharacterData.GetSpecialAbilityType() == 4 && logicCharacterData.GetSpecialAbilityLevel(this.int_5) <= 0)
			{
				return;
			}
			if (damage > 0 && radius > 0)
			{
				LogicHitpointComponent hitpointComponent = base.GetHitpointComponent();
				if (hitpointComponent != null)
				{
					this.m_level.AreaDamage(0, base.GetX(), base.GetY(), radius, damage, null, 0, null, hitpointComponent.GetTeam(), null, 1, 0, 0, true, false, 100, 0, this, 100, 0);
				}
			}
		}

		// Token: 0x06000D58 RID: 3416 RVA: 0x00030098 File Offset: 0x0002E298
		public void CheckSummons()
		{
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				LogicCharacter logicCharacter = this.logicArrayList_0[i];
				if (!logicCharacter.IsAlive())
				{
					this.logicArrayList_0.Remove(i--);
				}
				else if (logicCharacter.int_15 > 0 && !base.IsAlive())
				{
					this.logicArrayList_0.Remove(i--);
					this.bool_6 = false;
					LogicHitpointComponent hitpointComponent = logicCharacter.GetHitpointComponent();
					if (hitpointComponent != null)
					{
						hitpointComponent.SetHitpoints(0);
					}
					this.m_level.UpdateBattleStatus();
				}
			}
		}

		// Token: 0x06000D59 RID: 3417 RVA: 0x00030128 File Offset: 0x0002E328
		public void UpdateAutoMerge()
		{
			if (this.int_19 > 0)
			{
				int autoMergeGroupSize = this.GetCharacterData().GetAutoMergeGroupSize();
				int autoMergeDistance = this.GetCharacterData().GetAutoMergeDistance();
				if (autoMergeGroupSize > 0)
				{
					LogicArrayList<LogicGameObject> gameObjects = base.GetGameObjectManager().GetGameObjects(LogicGameObjectType.CHARACTER);
					LogicCharacter logicCharacter = null;
					for (int i = 0; i < gameObjects.Size(); i++)
					{
						LogicCharacter logicCharacter2 = (LogicCharacter)gameObjects[i];
						if (logicCharacter2 != this && logicCharacter2.GetData() == base.GetData() && this.int_18 == 0 && logicCharacter2.int_18 >= autoMergeGroupSize && logicCharacter2.GetHitpointComponent().GetTeam() == base.GetHitpointComponent().GetTeam() && logicCharacter2.IsAlive() && logicCharacter2.int_19 > 0 && base.GetPosition().GetDistanceSquared(logicCharacter2.GetPosition()) <= autoMergeDistance * autoMergeDistance)
						{
							logicCharacter = logicCharacter2;
						}
					}
					if (logicCharacter != null)
					{
						logicCharacter.int_18++;
						logicCharacter.GetCombatComponent().SetMergeDamage(90 * logicCharacter.int_18);
						logicCharacter.GetHitpointComponent().SetMaxHitpoints(logicCharacter.GetCharacterData().GetHitpoints(this.int_5) * (logicCharacter.int_18 + 1));
						logicCharacter.GetHitpointComponent().SetHitpoints(logicCharacter.GetCharacterData().GetHitpoints(this.int_5) * (logicCharacter.int_18 + 1));
						base.GetGameObjectManager().RemoveGameObject(this);
					}
				}
			}
		}

		// Token: 0x06000D5A RID: 3418 RVA: 0x00002465 File Offset: 0x00000665
		public override bool IsStaticObject()
		{
			return false;
		}

		// Token: 0x06000D5B RID: 3419 RVA: 0x00002B36 File Offset: 0x00000D36
		public override int GetWidthInTiles()
		{
			return 1;
		}

		// Token: 0x06000D5C RID: 3420 RVA: 0x00002B36 File Offset: 0x00000D36
		public override int GetHeightInTiles()
		{
			return 1;
		}

		// Token: 0x06000D5D RID: 3421 RVA: 0x0000986E File Offset: 0x00007A6E
		public override int GetMidX()
		{
			return base.GetX();
		}

		// Token: 0x06000D5E RID: 3422 RVA: 0x00009876 File Offset: 0x00007A76
		public override int GetMidY()
		{
			return base.GetY();
		}

		// Token: 0x06000D5F RID: 3423 RVA: 0x00030280 File Offset: 0x0002E480
		public override int GetDirection()
		{
			LogicMovementComponent movementComponent = base.GetMovementComponent();
			if (movementComponent != null)
			{
				return movementComponent.GetMovementSystem().GetDirection();
			}
			if (this.bool_3 && this.logicCharacter_0 != null)
			{
				return this.logicCharacter_0.GetDirection();
			}
			return 0;
		}

		// Token: 0x04000523 RID: 1315
		private int int_5;

		// Token: 0x04000524 RID: 1316
		private int int_6;

		// Token: 0x04000525 RID: 1317
		private int int_7;

		// Token: 0x04000526 RID: 1318
		private int int_8;

		// Token: 0x04000527 RID: 1319
		private int int_9;

		// Token: 0x04000528 RID: 1320
		private int int_10;

		// Token: 0x04000529 RID: 1321
		private int int_11;

		// Token: 0x0400052A RID: 1322
		private int int_12;

		// Token: 0x0400052B RID: 1323
		private int int_13;

		// Token: 0x0400052C RID: 1324
		private int int_14;

		// Token: 0x0400052D RID: 1325
		private int int_15;

		// Token: 0x0400052E RID: 1326
		private int int_16;

		// Token: 0x0400052F RID: 1327
		private int int_17;

		// Token: 0x04000530 RID: 1328
		private int int_18;

		// Token: 0x04000531 RID: 1329
		private int int_19;

		// Token: 0x04000532 RID: 1330
		private int int_20;

		// Token: 0x04000533 RID: 1331
		private int int_21;

		// Token: 0x04000534 RID: 1332
		private int int_22;

		// Token: 0x04000535 RID: 1333
		private int int_23;

		// Token: 0x04000536 RID: 1334
		private bool bool_0;

		// Token: 0x04000537 RID: 1335
		private bool bool_1;

		// Token: 0x04000538 RID: 1336
		private bool bool_2;

		// Token: 0x04000539 RID: 1337
		private bool bool_3;

		// Token: 0x0400053A RID: 1338
		private bool bool_4;

		// Token: 0x0400053B RID: 1339
		private bool bool_5;

		// Token: 0x0400053C RID: 1340
		private bool bool_6;

		// Token: 0x0400053D RID: 1341
		private bool bool_7;

		// Token: 0x0400053E RID: 1342
		private LogicSpell logicSpell_0;

		// Token: 0x0400053F RID: 1343
		private LogicSpell logicSpell_1;

		// Token: 0x04000540 RID: 1344
		private LogicSpell logicSpell_2;

		// Token: 0x04000541 RID: 1345
		private LogicCharacter logicCharacter_0;

		// Token: 0x04000542 RID: 1346
		private LogicCharacterData logicCharacterData_0;

		// Token: 0x04000543 RID: 1347
		private readonly LogicVector2 logicVector2_0;

		// Token: 0x04000544 RID: 1348
		private readonly LogicArrayList<LogicCharacter> logicArrayList_0;

		// Token: 0x04000545 RID: 1349
		private readonly LogicArrayList<LogicCharacter> logicArrayList_1;
	}
}
