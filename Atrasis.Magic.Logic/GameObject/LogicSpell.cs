using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.GameObject
{
	// Token: 0x02000117 RID: 279
	public sealed class LogicSpell : LogicGameObject
	{
		// Token: 0x06000E56 RID: 3670 RVA: 0x00009F40 File Offset: 0x00008140
		public LogicSpell(LogicGameObjectData data, LogicLevel level, int villageType) : base(data, level, villageType)
		{
			this.bool_3 = true;
			this.logicVector2_0 = new LogicVector2();
			this.int_15 = -1;
			this.int_7 = 100;
			this.int_8 = 100;
		}

		// Token: 0x06000E57 RID: 3671 RVA: 0x00035E84 File Offset: 0x00034084
		public override void RemoveGameObjectReferences(LogicGameObject gameObject)
		{
			if (this.logicArrayList_1 != null)
			{
				int num = this.logicArrayList_1.IndexOf(gameObject);
				if (num != -1)
				{
					this.logicArrayList_1.Remove(num);
				}
			}
		}

		// Token: 0x06000E58 RID: 3672 RVA: 0x00009F74 File Offset: 0x00008174
		public LogicSpellData GetSpellData()
		{
			return (LogicSpellData)this.m_data;
		}

		// Token: 0x06000E59 RID: 3673 RVA: 0x00009F81 File Offset: 0x00008181
		public void AllowDestruction(bool value)
		{
			this.bool_3 = value;
		}

		// Token: 0x06000E5A RID: 3674 RVA: 0x00002E32 File Offset: 0x00001032
		public override LogicGameObjectType GetGameObjectType()
		{
			return LogicGameObjectType.SPELL;
		}

		// Token: 0x06000E5B RID: 3675 RVA: 0x00009F8A File Offset: 0x0000818A
		public int GetUpgradeLevel()
		{
			return this.int_5;
		}

		// Token: 0x06000E5C RID: 3676 RVA: 0x00009F92 File Offset: 0x00008192
		public void SetUpgradeLevel(int upgLevel)
		{
			this.int_5 = upgLevel;
		}

		// Token: 0x06000E5D RID: 3677 RVA: 0x00035EB8 File Offset: 0x000340B8
		public void CalculateRandomOffset(int randCount)
		{
			this.logicVector2_0.m_x = 0;
			this.logicVector2_0.m_y = 0;
			int randomRadius = this.GetSpellData().GetRandomRadius(this.int_5);
			if (randomRadius > 0)
			{
				for (int i = 0; i < randCount; i++)
				{
					int x = this.logicVector2_0.m_x;
					int y = this.logicVector2_0.m_y;
					int num = 7 * randCount + 9;
					int num2 = 5 * randCount + 3;
					int num3 = 11 * randCount + 32;
					for (int j = 0; j < 100; j++)
					{
						this.logicVector2_0.m_x = base.Rand(randCount + j) % randomRadius * (2 * (base.Rand(num2) & 1) - 1);
						this.logicVector2_0.m_y = base.Rand(num) % randomRadius * (2 * (base.Rand(num3) & 1) - 1);
						if (LogicMath.Abs(y - x + this.logicVector2_0.m_x - this.logicVector2_0.m_y) > (int)((long)randomRadius / 3L))
						{
							break;
						}
						num += 7;
						num2 += 4;
						num3 += 15;
					}
				}
			}
		}

		// Token: 0x06000E5E RID: 3678 RVA: 0x00035FDC File Offset: 0x000341DC
		public void SpawnObstacle(int x, int y, int radius)
		{
			int num = x >> 9;
			int num2 = y >> 9;
			if (!this.TileOkForSpawn(this.m_level.GetTileMap().GetTile(num, num2)))
			{
				int num3 = 0;
				int num4 = -1;
				int num5 = -1;
				for (int i = -radius; i <= radius; i++)
				{
					int num6 = num + i;
					int num7 = num6 << 9 | 256;
					int num8 = (radius << 9) - 256 - (y >> 9 << 9);
					for (int j = -radius; j <= radius; j++)
					{
						int num9 = num2 + j;
						if (this.TileOkForSpawn(this.m_level.GetTileMap().GetTile(num6, num9)))
						{
							int x2 = base.GetX();
							int y2 = base.GetY();
							int num10 = (x2 - num7) * (x2 - num7) + (y2 + num8) * (y2 + num8);
							if (num3 == 0 || num10 < num3)
							{
								num3 = num10;
								num4 = num6;
								num5 = num9;
							}
						}
						num8 -= 512;
					}
				}
				if (num3 == 0)
				{
					return;
				}
				num = num4;
				num2 = num5;
			}
			LogicObstacleData spawnObstacle = this.GetSpellData().GetSpawnObstacle();
			if (spawnObstacle != null)
			{
				LogicGameObject logicGameObject = LogicGameObjectFactory.CreateGameObject(spawnObstacle, this.m_level, base.GetVillageType());
				logicGameObject.SetInitialPosition(num << 9, num2 << 9);
				base.GetGameObjectManager().AddGameObject(logicGameObject, -1);
			}
		}

		// Token: 0x06000E5F RID: 3679 RVA: 0x0003611C File Offset: 0x0003431C
		public bool TileOkForSpawn(LogicTile tile)
		{
			if (tile != null && !tile.IsFullyNotPassable())
			{
				int i = 0;
				while (i < tile.GetGameObjectCount())
				{
					LogicGameObjectType gameObjectType = tile.GetGameObject(i).GetGameObjectType();
					if (gameObjectType != LogicGameObjectType.BUILDING && gameObjectType != LogicGameObjectType.OBSTACLE && gameObjectType != LogicGameObjectType.TRAP)
					{
						if (gameObjectType != LogicGameObjectType.DECO)
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

		// Token: 0x06000E60 RID: 3680 RVA: 0x00009F9B File Offset: 0x0000819B
		public bool GetHitsCompleted()
		{
			return this.bool_0;
		}

		// Token: 0x06000E61 RID: 3681 RVA: 0x00009FA3 File Offset: 0x000081A3
		public bool IsDeployed()
		{
			return this.bool_1;
		}

		// Token: 0x06000E62 RID: 3682 RVA: 0x00009FAB File Offset: 0x000081AB
		public void SetTeam(int team)
		{
			this.int_14 = team;
		}

		// Token: 0x06000E63 RID: 3683 RVA: 0x00036168 File Offset: 0x00034368
		public void SelectDuplicableCharacters()
		{
			if (this.logicArrayList_1 == null)
			{
				this.logicArrayList_1 = new LogicArrayList<LogicGameObject>(20);
			}
			if (this.logicArrayList_0 == null)
			{
				this.logicArrayList_0 = new LogicArrayList<LogicGameObject>(20);
			}
			int radius = this.GetSpellData().GetRadius(this.int_5);
			LogicArrayList<LogicComponent> components = base.GetComponentManager().GetComponents(LogicComponentType.MOVEMENT);
			for (int i = 0; i < components.Size(); i++)
			{
				LogicGameObject parent = ((LogicMovementComponent)components[i]).GetParent();
				if (parent.GetGameObjectType() == LogicGameObjectType.CHARACTER)
				{
					LogicCharacter logicCharacter = (LogicCharacter)parent;
					LogicCharacterData characterData = logicCharacter.GetCharacterData();
					LogicHitpointComponent hitpointComponent = logicCharacter.GetHitpointComponent();
					if (hitpointComponent != null && hitpointComponent.GetTeam() == 0 && logicCharacter.IsAlive() && !logicCharacter.IsHero() && characterData.GetHousingSpace() <= this.int_15)
					{
						int num = logicCharacter.GetPosition().m_x - this.GetMidX();
						int num2 = logicCharacter.GetPosition().m_y - this.GetMidY();
						if (LogicMath.Abs(num) <= radius && LogicMath.Abs(num2) <= radius && (long)(num * num + num2 * num2) < (long)((ulong)(radius * radius)))
						{
							int num3 = -1;
							int j = 0;
							int num4 = this.logicArrayList_1.Size();
							while (j < num4)
							{
								if (this.logicArrayList_1[j] == logicCharacter)
								{
									num3 = j;
									IL_14F:
									if (num3 == -1)
									{
										this.logicCharacterData_0 = characterData;
										this.int_18 = logicCharacter.GetUpgradeLevel();
										this.logicArrayList_1.Add(logicCharacter);
										goto IL_176;
									}
									goto IL_176;
								}
								else
								{
									j++;
								}
							}
							goto IL_14F;
						}
					}
				}
				IL_176:;
			}
		}

		// Token: 0x06000E64 RID: 3684 RVA: 0x000362FC File Offset: 0x000344FC
		public LogicCharacter CreateDuplicateCharacter(LogicCharacterData data, int upgLevel, int x, int y)
		{
			LogicCharacter logicCharacter = (LogicCharacter)LogicGameObjectFactory.CreateGameObject(data, this.m_level, this.m_villageType);
			logicCharacter.SetUpgradeLevel(upgLevel);
			logicCharacter.SetDuplicate(true, this.GetSpellData().GetDuplicateLifetime(this.int_5) / 64 + 1);
			logicCharacter.SetInitialPosition(x, y);
			if (data.IsJumper())
			{
				logicCharacter.GetMovementComponent().EnableJump(3600000);
				logicCharacter.GetCombatComponent().RefreshTarget(true);
			}
			if (data.IsUnderground())
			{
				LogicCombatComponent combatComponent = logicCharacter.GetCombatComponent();
				combatComponent.SetUndergroundTime(3600000);
				combatComponent.RefreshTarget(true);
			}
			if (LogicDataTables.IsSkeleton(data))
			{
				LogicCombatComponent combatComponent2 = logicCharacter.GetCombatComponent();
				if (combatComponent2 != null)
				{
					combatComponent2.SetSkeletonSpell();
				}
			}
			base.GetGameObjectManager().AddGameObject(logicCharacter, -1);
			return logicCharacter;
		}

		// Token: 0x06000E65 RID: 3685 RVA: 0x000363B8 File Offset: 0x000345B8
		public bool DuplicateCharacter()
		{
			if (this.int_15 < 0)
			{
				this.int_15 = this.GetSpellData().GetDuplicateHousing(this.int_5);
			}
			if (this.logicArrayList_1 == null)
			{
				return this.logicCharacterData_0 != null && this.DuplicateCharacter(this.logicCharacterData_0, this.int_18);
			}
			if (this.logicArrayList_1.Size() > 0)
			{
				int num = ((LogicCharacter)this.logicArrayList_1[0]).GetCharacterData().GetHousingSpace();
				for (int i = 0; i < this.logicArrayList_1.Size(); i++)
				{
					LogicCharacter logicCharacter = (LogicCharacter)this.logicArrayList_1[(i + this.int_16) % this.logicArrayList_1.Size()];
					LogicCharacterData characterData = logicCharacter.GetCharacterData();
					int housingSpace = characterData.GetHousingSpace();
					if (num > housingSpace)
					{
						num = housingSpace;
					}
					if (this.DuplicateCharacter(characterData, logicCharacter.GetUpgradeLevel()))
					{
						return true;
					}
				}
				return false;
			}
			return this.DuplicateCharacter(this.logicCharacterData_0, this.int_18);
		}

		// Token: 0x06000E66 RID: 3686 RVA: 0x000364B4 File Offset: 0x000346B4
		public bool DuplicateCharacter(LogicCharacterData data, int upgLevel)
		{
			if (data != null)
			{
				int tick = this.m_level.GetLogicTime().GetTick();
				int num = 75 * this.GetSpellData().GetRadius(this.int_5) / 100 * (tick % 100) / 100;
				int x = base.GetX() + (num * LogicMath.Sin(tick * 21 + 7 * this.int_17) >> 10);
				int y = base.GetY() + (num * LogicMath.Cos(tick * 21 + 7 * this.int_17) >> 10);
				bool flag = false;
				if (!data.IsFlying())
				{
					int num2;
					int num3;
					flag = !LogicGamePlayUtil.FindGoodDuplicatePosAround(this.m_level, x, y, out num2, out num3, 10);
					x = num2;
					y = num3;
				}
				if (!flag && this.int_15 >= data.GetHousingSpace())
				{
					this.int_15 -= data.GetHousingSpace();
					this.logicArrayList_0.Add(this.CreateDuplicateCharacter(data, upgLevel, x, y));
					this.int_16++;
					this.int_17++;
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000E67 RID: 3687 RVA: 0x000365B8 File Offset: 0x000347B8
		public void SpawnSummon(int x, int y)
		{
			LogicSpellData spellData = this.GetSpellData();
			LogicCharacterData summonTroop = spellData.GetSummonTroop();
			LogicVector2 logicVector = new LogicVector2();
			int unitsToSpawn = spellData.GetUnitsToSpawn(this.int_5);
			int spawnDuration = spellData.GetSpawnDuration(this.int_5);
			int num = -(spawnDuration * spellData.GetSpawnFirstGroupSize());
			int i = 0;
			int num2 = 0;
			int num3 = y + 7 * x;
			while (i < unitsToSpawn)
			{
				if (!summonTroop.IsFlying())
				{
					if (!this.m_level.GetTileMap().GetNearestPassablePosition(base.GetX(), base.GetY(), logicVector, 1536))
					{
						return;
					}
				}
				else
				{
					logicVector.m_x = x + LogicMath.GetRotatedX(summonTroop.GetSecondarySpawnOffset(), 0, num3);
					logicVector.m_y = y + LogicMath.GetRotatedY(summonTroop.GetSecondarySpawnOffset(), 0, num3);
				}
				LogicCharacter logicCharacter = (LogicCharacter)LogicGameObjectFactory.CreateGameObject(summonTroop, this.m_level, this.m_villageType);
				logicCharacter.GetHitpointComponent().SetTeam(0);
				logicCharacter.SetInitialPosition(logicVector.m_x, logicVector.m_y);
				int num4 = ((new LogicRandom(num2 + this.m_globalId).Rand(150) << 9) + 38400) / 100;
				logicVector.Set(LogicMath.Cos(num3, num4), LogicMath.Sin(num3, num4));
				int num5 = (summonTroop.GetPushbackSpeed() > 0) ? summonTroop.GetPushbackSpeed() : 1;
				int num6 = 2 * num4 / (3 * num5);
				int num7 = num6 + num / unitsToSpawn;
				if (spellData.GetSpawnFirstGroupSize() > 0)
				{
					num7 = LogicMath.Max(200, num7);
				}
				logicCharacter.SetSpawnTime(num7);
				logicCharacter.GetMovementComponent().GetMovementSystem().PushTrap(logicVector, num6, 0, false, false);
				if (logicCharacter.GetCharacterData().IsJumper())
				{
					logicCharacter.GetMovementComponent().EnableJump(3600000);
					logicCharacter.GetCombatComponent().RefreshTarget(true);
				}
				LogicCombatComponent combatComponent = logicCharacter.GetCombatComponent();
				if (combatComponent != null)
				{
					combatComponent.SetSkeletonSpell();
				}
				base.GetGameObjectManager().AddGameObject(logicCharacter, -1);
				i++;
				num2 += 7;
				num3 += 150;
				num += spawnDuration;
			}
		}

		// Token: 0x06000E68 RID: 3688 RVA: 0x000367BC File Offset: 0x000349BC
		public void ApplyDamagePermil(int x, int y, int unk1, int team, int unk2, int targetType, int damageType, int unk3, bool healing)
		{
			LogicSpellData spellData = this.GetSpellData();
			int radius = spellData.GetRadius(this.int_5);
			int troopDamagePermil = spellData.GetTroopDamagePermil(this.int_5);
			int buildingDamagePermil = spellData.GetBuildingDamagePermil(this.int_5);
			int executeHealthPermil = spellData.GetExecuteHealthPermil(this.int_5);
			int damagePermilMin = spellData.GetDamagePermilMin(this.int_5);
			int preferredTargetDamageMod = spellData.GetPreferredTargetDamageMod();
			int preferredDamagePermilMin = spellData.GetPreferredDamagePermilMin(this.int_5);
			LogicData preferredTarget = spellData.GetPreferredTarget();
			LogicVector2 logicVector = new LogicVector2();
			LogicArrayList<LogicComponent> components = base.GetComponentManager().GetComponents(LogicComponentType.HITPOINT);
			int num = troopDamagePermil + 2 * buildingDamagePermil;
			for (int i = 0; i < components.Size(); i++)
			{
				LogicHitpointComponent logicHitpointComponent = (LogicHitpointComponent)components[i];
				LogicGameObject parent = logicHitpointComponent.GetParent();
				if (!parent.IsHidden() && logicHitpointComponent.GetHitpoints() != 0)
				{
					if (logicHitpointComponent.GetTeam() == team)
					{
						if (num > 0)
						{
							goto IL_36B;
						}
						if (num < 0 && parent.IsPreventsHealing())
						{
							goto IL_36B;
						}
					}
					else if (num < 0)
					{
						goto IL_36B;
					}
					if (damageType != 2 || parent.GetGameObjectType() == LogicGameObjectType.CHARACTER)
					{
						LogicMovementComponent movementComponent = parent.GetMovementComponent();
						int num2;
						int num3;
						if (movementComponent == null && !parent.IsFlying())
						{
							int x2 = parent.GetX();
							int y2 = parent.GetY();
							num2 = LogicMath.Clamp(x, x2, x2 + (parent.GetWidthInTiles() << 9));
							num3 = LogicMath.Clamp(y, y2, y2 + (parent.GetHeightInTiles() << 9));
						}
						else
						{
							if (parent.IsFlying())
							{
								if (targetType == 1)
								{
									goto IL_36B;
								}
							}
							else if (targetType == 0)
							{
								goto IL_36B;
							}
							num2 = parent.GetMidX();
							num3 = parent.GetMidY();
						}
						int num4 = x - num2;
						int num5 = y - num3;
						if (LogicMath.Abs(num4) <= radius && LogicMath.Abs(num5) <= radius && (long)(num4 * num4 + num5 * num5) < (long)((ulong)(radius * radius)))
						{
							if (damageType == 1 && parent.GetGameObjectType() == LogicGameObjectType.BUILDING)
							{
								LogicBuilding logicBuilding = (LogicBuilding)parent;
								if (logicBuilding.GetResourceStorageComponentComponent() != null && !logicBuilding.GetBuildingData().IsTownHall() && !logicBuilding.GetBuildingData().IsTownHallVillage2())
								{
									parent.SetDamageTime(10);
									goto IL_36B;
								}
							}
							if (parent.GetGameObjectType() == LogicGameObjectType.BUILDING || parent.GetGameObjectType() == LogicGameObjectType.CHARACTER)
							{
								int num6 = (parent.GetGameObjectType() == LogicGameObjectType.BUILDING) ? buildingDamagePermil : troopDamagePermil;
								if (num6 != 0)
								{
									int num7 = 10 * logicHitpointComponent.GetMaxHitpoints() * num6 / 10000;
									if (10 * logicHitpointComponent.GetMaxHitpoints() * num6 <= -10000 && parent.IsHero())
									{
										num7 = LogicDataTables.GetGlobals().GetHeroHealMultiplier() * num7 / 100;
									}
									bool flag = LogicCombatComponent.IsPreferredTarget(preferredTarget, parent);
									int numberOfHits = spellData.GetNumberOfHits(this.int_5);
									int num8 = logicHitpointComponent.GetDamagePermilCount() / spellData.GetNumberOfHits(this.int_5);
									int num9 = flag ? (num7 / (num8 + 1) + preferredTargetDamageMod * logicHitpointComponent.GetMaxHitpoints() / (100 * numberOfHits) * num8 * num8) : (num7 / (2 * num8 + 1));
									int num10 = flag ? preferredDamagePermilMin : damagePermilMin;
									int num11 = logicHitpointComponent.GetMaxHitpoints() * num10 / 10000;
									if (num9 >= num11)
									{
										num11 = num9;
									}
									if (executeHealthPermil > 0 && 1000 * (logicHitpointComponent.GetHitpoints() - num11) <= executeHealthPermil)
									{
										num11 = logicHitpointComponent.GetHitpoints();
									}
									logicHitpointComponent.CauseDamagePermil(num11);
									if ((num4 | num4) == 0)
									{
										num4 = 1;
									}
									logicVector.m_x = -num4;
									logicVector.m_y = -num5;
									logicVector.Normalize(512);
									if (unk3 > 0 && movementComponent != null)
									{
										movementComponent.GetMovementSystem().PushBack(logicVector, num11, unk3, 0, false, true);
									}
								}
							}
						}
					}
				}
				IL_36B:;
			}
		}

		// Token: 0x06000E69 RID: 3689 RVA: 0x00036B48 File Offset: 0x00034D48
		public void ApplyExtraHealthPermil(int x, int y, int radius, int team, int extraHealthPermil, int extraHealthMin, int extraHealthMax, int time, int targetType)
		{
			LogicArrayList<LogicComponent> components = base.GetComponentManager().GetComponents(LogicComponentType.HITPOINT);
			for (int i = 0; i < components.Size(); i++)
			{
				LogicHitpointComponent logicHitpointComponent = (LogicHitpointComponent)components[i];
				LogicGameObject parent = logicHitpointComponent.GetParent();
				if (!parent.IsHidden() && logicHitpointComponent.GetHitpoints() != 0 && logicHitpointComponent.GetTeam() == team && parent.GetMovementComponent() != null)
				{
					if (parent.GetGameObjectType() == LogicGameObjectType.CHARACTER)
					{
						LogicCharacter logicCharacter = (LogicCharacter)parent;
						if (logicCharacter.GetCharacterData().GetAuraSpell(logicCharacter.GetUpgradeLevel()) == this.m_data)
						{
							goto IL_10D;
						}
					}
					if (parent.IsFlying())
					{
						if (targetType == 1)
						{
							goto IL_10D;
						}
					}
					else if (targetType == 0)
					{
						goto IL_10D;
					}
					int num = x - parent.GetMidX();
					int num2 = y - parent.GetMidY();
					if (LogicMath.Abs(num) <= radius && LogicMath.Abs(num2) <= radius && (long)(num * num + num2 * num2) < (long)((ulong)(radius * radius)))
					{
						int num3 = logicHitpointComponent.GetOriginalHitpoints() + LogicMath.Clamp(extraHealthPermil * logicHitpointComponent.GetOriginalHitpoints() / 1000, 100 * extraHealthMin, 100 * extraHealthMax);
						if (num3 >= logicHitpointComponent.GetMaxHitpoints())
						{
							logicHitpointComponent.SetExtraHealth(num3, time);
						}
					}
				}
				IL_10D:;
			}
		}

		// Token: 0x06000E6A RID: 3690 RVA: 0x00036C74 File Offset: 0x00034E74
		public override void Tick()
		{
			base.Tick();
			if (this.int_6 > 0)
			{
				this.int_6 -= 64;
				if (this.int_6 <= 0)
				{
					base.GetListener().PlayEffect(this.GetSpellData().GetDeployEffect2(this.int_5), this.int_7, this.int_8);
					this.int_6 = 0;
				}
			}
		}

		// Token: 0x06000E6B RID: 3691 RVA: 0x00036CD8 File Offset: 0x00034ED8
		public override void SubTick()
		{
			base.SubTick();
			LogicSpellData spellData = this.GetSpellData();
			if (!this.bool_2)
			{
				base.GetListener().PlayEffect(spellData.GetPreDeployEffect(this.int_5));
				this.bool_2 = true;
			}
			int num = this.int_9 + 1;
			this.int_9 = num;
			if (num >= spellData.GetDeployTimeMS() * 60 / 1000)
			{
				if (!this.bool_1)
				{
					base.GetListener().PlayEffect((this.int_14 == 0 || spellData.GetEnemyDeployEffect(this.int_5) == null) ? spellData.GetDeployEffect(this.int_5) : spellData.GetEnemyDeployEffect(this.int_5), this.int_7, this.int_8);
					this.int_6 = spellData.GetDeployEffect2Delay();
					if (this.int_6 <= 0)
					{
						base.GetListener().PlayEffect(spellData.GetDeployEffect2(this.int_5), this.int_7, this.int_8);
						this.int_6 = 0;
					}
					this.bool_1 = true;
				}
				num = this.int_10 + 1;
				this.int_10 = num;
				if (num >= spellData.GetChargingTimeMS() * 60 / 1000 + this.int_12 * (spellData.GetTimeBetweenHitsMS(this.int_5) * 60 / 1000) && this.int_12 < spellData.GetNumberOfHits(this.int_5))
				{
					this.CalculateRandomOffset(this.int_12);
					base.GetListener().PlayTargetedEffect(spellData.GetChargingEffect(this.int_5), this, this.logicVector2_0);
					this.int_12++;
				}
				num = this.int_11 + 1;
				this.int_11 = num;
				if (num >= spellData.GetHitTimeMS() * 60 / 1000 + this.int_13 * (spellData.GetTimeBetweenHitsMS(this.int_5) * 60 / 1000) && this.int_13 < spellData.GetNumberOfHits(this.int_5))
				{
					this.CalculateRandomOffset(this.int_13);
					base.GetListener().PlayTargetedEffect(spellData.GetHitEffect(this.int_5), this, this.logicVector2_0);
					int num2 = 0;
					int num3 = 0;
					if (!spellData.GetRandomRadiusAffectsOnlyGfx())
					{
						num2 = this.logicVector2_0.m_x;
						num3 = this.logicVector2_0.m_y;
					}
					int num4 = spellData.GetDamage(this.int_5);
					if (num4 != 0 && spellData.IsScaleByTownHall())
					{
						int num5 = num4 * (700 * this.m_level.GetPlayerAvatar().GetTownHallLevel() / (LogicDataTables.GetTownHallLevelCount() - 1) / 10 + 30) / 100;
						num4 = 1;
						if (num5 > 0)
						{
							num4 = num5;
						}
					}
					if (num4 != 0 && spellData.GetRadius(this.int_5) > 0)
					{
						int x = num2 + this.GetMidX();
						int y = num3 + this.GetMidY();
						int preferredTargetDamagePecent = 100 * spellData.GetPreferredTargetDamageMod();
						if (spellData.GetTroopsOnly())
						{
							this.m_level.AreaDamage(0, x, y, spellData.GetRadius(this.int_5), num4, spellData.GetPreferredTarget(), preferredTargetDamagePecent, null, this.int_14, null, 2, 2, 0, true, num4 < 0, spellData.GetHeroDamageMultiplier(), spellData.GetMaxUnitsHit(this.int_5), null, spellData.GetDamageTHPercent(), spellData.GetPauseCombatComponentMs());
						}
						else
						{
							this.m_level.AreaDamage(0, x, y, spellData.GetRadius(this.int_5), num4, spellData.GetPreferredTarget(), preferredTargetDamagePecent, null, this.int_14, null, 2, 1, 0, true, num4 < 0, spellData.GetHeroDamageMultiplier(), spellData.GetMaxUnitsHit(this.int_5), null, spellData.GetDamageTHPercent(), spellData.GetPauseCombatComponentMs());
						}
					}
					if (spellData.GetDuplicateHousing(this.int_5) != 0 && spellData.GetRadius(this.int_5) > 0)
					{
						this.SelectDuplicableCharacters();
						this.DuplicateCharacter();
					}
					if ((spellData.GetBuildingDamagePermil(this.int_5) != 0 || spellData.GetTroopDamagePermil(this.int_5) != 0) && spellData.GetRadius(this.int_5) > 0)
					{
						this.ApplyDamagePermil(num2 + this.GetMidX(), num3 + this.GetMidY(), 0, this.int_14, 0, 2, 1, 0, spellData.GetTroopDamagePermil(this.int_5) < 0);
					}
					if (spellData.GetPoisonDamage(this.int_5) != 0 && spellData.GetRadius(this.int_5) > 0)
					{
						int x2 = num2 + this.GetMidX();
						int y2 = num3 + this.GetMidY();
						int poisonDamage = spellData.GetPoisonDamage(this.int_5);
						if (spellData.GetTroopsOnly())
						{
							this.m_level.AreaPoison(0, x2, y2, spellData.GetRadius(this.int_5), spellData.GetPoisonDamage(this.int_5), null, 0, null, this.int_14, null, spellData.GetPoisonAffectAir() ? 2 : 1, 2, 0, poisonDamage < 0, spellData.GetHeroDamageMultiplier(), spellData.GetPoisonIncreaseSlowly());
						}
						else
						{
							this.m_level.AreaPoison(0, x2, y2, spellData.GetRadius(this.int_5), spellData.GetPoisonDamage(this.int_5), null, 0, null, this.int_14, null, spellData.GetPoisonAffectAir() ? 2 : 1, 1, 0, poisonDamage < 0, spellData.GetHeroDamageMultiplier(), spellData.GetPoisonIncreaseSlowly());
						}
					}
					if (spellData.GetSpeedBoost(this.int_5) != 0 || spellData.GetAttackSpeedBoost(this.int_5) != 0)
					{
						this.m_level.AreaBoost(num2 + this.GetMidX(), num3 + this.GetMidY(), spellData.GetRadius(this.int_5), spellData.GetSpeedBoost(this.int_5), spellData.GetSpeedBoost2(this.int_5), spellData.GetDamageBoostPercent(this.int_5), spellData.GetAttackSpeedBoost(this.int_5), 60 * spellData.GetBoostTimeMS(this.int_5) / 1000, spellData.GetBoostDefenders() ? ((this.int_14 != 1) ? 1 : 0) : this.int_14, spellData.GetBoostLinkedToPoison());
					}
					if (spellData.GetJumpBoostMS(this.int_5) != 0 && this.int_14 == 0)
					{
						this.m_level.AreaJump(num2 + this.GetMidX(), num3 + this.GetMidY(), spellData.GetRadius(this.int_5), spellData.GetJumpBoostMS(this.int_5), spellData.GetJumpHousingLimit(this.int_5), this.int_14);
						if (this.int_13 == 0 && LogicDataTables.GetGlobals().UseWallWeightsForJumpSpell())
						{
							int numberOfHits = spellData.GetNumberOfHits(this.int_5);
							int timeBetweenHitsMS = spellData.GetTimeBetweenHitsMS(this.int_5);
							int radius = spellData.GetRadius(this.int_5);
							int hitWallDelay = numberOfHits * timeBetweenHitsMS - LogicDataTables.GetGlobals().GetForgetTargetTime();
							LogicArrayList<LogicGameObject> gameObjects = base.GetGameObjectManager().GetGameObjects(LogicGameObjectType.BUILDING);
							for (int i = 0; i < gameObjects.Size(); i++)
							{
								LogicBuilding logicBuilding = (LogicBuilding)gameObjects[i];
								if (logicBuilding.IsWall() && logicBuilding.IsAlive())
								{
									int num6 = this.GetMidX() - logicBuilding.GetMidX();
									int num7 = this.GetMidY() - logicBuilding.GetMidY();
									if (LogicMath.Abs(num6) < radius && LogicMath.Abs(num7) < radius && (long)(num6 * num6 + num7 * num7) < (long)((ulong)(radius * radius)))
									{
										logicBuilding.SetHitWallDelay(hitWallDelay);
									}
								}
							}
							this.m_level.GetTileMap().GetPathFinder().InvalidateCache();
							LogicArrayList<LogicComponent> components = base.GetComponentManager().GetComponents(LogicComponentType.MOVEMENT);
							for (int j = 0; j < components.Size(); j++)
							{
								LogicCombatComponent combatComponent = ((LogicMovementComponent)components[j]).GetParent().GetCombatComponent();
								if (combatComponent != null && combatComponent.GetTarget(0) != null && combatComponent.GetTarget(0).IsWall())
								{
									combatComponent.ForceNewTarget();
								}
							}
						}
					}
					if (spellData.GetShrinkReduceSpeedRatio() != 0 || spellData.GetShrinkHitpointsRatio() != 0)
					{
						this.m_level.AreaShrink(num2 + this.GetMidX(), num3 + this.GetMidY(), spellData.GetRadius(this.int_5), spellData.GetShrinkReduceSpeedRatio(), spellData.GetShrinkHitpointsRatio(), 1000 * LogicDataTables.GetGlobals().GetShrinkSpellDurationSeconds() / 64, this.int_14);
					}
					if (spellData.GetFreezeTimeMS(this.int_5) != 0)
					{
						this.m_level.AreaFreeze(num2 + this.GetMidX(), num3 + this.GetMidY(), spellData.GetRadius(this.int_5), 60 * spellData.GetFreezeTimeMS(this.int_5) / 1000, this.int_14);
					}
					if (spellData.GetBuildingDamageBoostPercent(this.int_5) != 0)
					{
						this.m_level.AreaBoost(num2 + this.GetMidX(), num3 + this.GetMidY(), spellData.GetRadius(this.int_5), spellData.GetBuildingDamageBoostPercent(this.int_5), 0, 60 * spellData.GetBoostTimeMS(this.int_5) / 1000);
					}
					if (spellData.GetSummonTroop() != null)
					{
						this.SpawnSummon(num2 + this.GetMidX(), num3 + this.GetMidY());
					}
					if (spellData.GetSpawnObstacle() != null)
					{
						this.SpawnObstacle(num2 + this.GetMidX(), num3 + this.GetMidY(), 5);
					}
					if (spellData.GetExtraHealthPermil(this.int_5) != 0)
					{
						this.ApplyExtraHealthPermil(num2 + this.GetMidX(), num3 + this.GetMidY(), spellData.GetRadius(this.int_5), this.int_14, spellData.GetExtraHealthPermil(this.int_5), spellData.GetExtraHealthMin(this.int_5), spellData.GetExtraHealthMax(this.int_5), spellData.GetHitTimeMS() + 64, 2);
					}
					if (spellData.GetInvulnerabilityTime(this.int_5) != 0)
					{
						this.m_level.AreaShield(num2 + this.GetMidX(), num3 + this.GetMidY(), spellData.GetRadius(this.int_5), spellData.GetInvulnerabilityTime(this.int_5), this.int_14);
					}
					num = this.int_13 + 1;
					this.int_13 = num;
					if (num >= spellData.GetNumberOfHits(this.int_5))
					{
						this.bool_0 = true;
						this.m_level.UpdateBattleStatus();
					}
				}
			}
		}

		// Token: 0x06000E6C RID: 3692 RVA: 0x00009FB4 File Offset: 0x000081B4
		public override bool ShouldDestruct()
		{
			return this.bool_3 && (this.int_15 == 0 || !this.m_level.IsInCombatState() || this.int_13 >= this.GetSpellData().GetNumberOfHits(this.int_5));
		}

		// Token: 0x06000E6D RID: 3693 RVA: 0x0000986E File Offset: 0x00007A6E
		public override int GetMidX()
		{
			return base.GetX();
		}

		// Token: 0x06000E6E RID: 3694 RVA: 0x00009876 File Offset: 0x00007A76
		public override int GetMidY()
		{
			return base.GetY();
		}

		// Token: 0x06000E6F RID: 3695 RVA: 0x00002465 File Offset: 0x00000665
		public override bool IsStaticObject()
		{
			return false;
		}

		// Token: 0x040005B5 RID: 1461
		private int int_5;

		// Token: 0x040005B6 RID: 1462
		private int int_6;

		// Token: 0x040005B7 RID: 1463
		private readonly int int_7;

		// Token: 0x040005B8 RID: 1464
		private readonly int int_8;

		// Token: 0x040005B9 RID: 1465
		private int int_9;

		// Token: 0x040005BA RID: 1466
		private int int_10;

		// Token: 0x040005BB RID: 1467
		private int int_11;

		// Token: 0x040005BC RID: 1468
		private int int_12;

		// Token: 0x040005BD RID: 1469
		private int int_13;

		// Token: 0x040005BE RID: 1470
		private int int_14;

		// Token: 0x040005BF RID: 1471
		private int int_15;

		// Token: 0x040005C0 RID: 1472
		private int int_16;

		// Token: 0x040005C1 RID: 1473
		private int int_17;

		// Token: 0x040005C2 RID: 1474
		private int int_18;

		// Token: 0x040005C3 RID: 1475
		private readonly LogicVector2 logicVector2_0;

		// Token: 0x040005C4 RID: 1476
		private LogicCharacterData logicCharacterData_0;

		// Token: 0x040005C5 RID: 1477
		private LogicArrayList<LogicGameObject> logicArrayList_0;

		// Token: 0x040005C6 RID: 1478
		private LogicArrayList<LogicGameObject> logicArrayList_1;

		// Token: 0x040005C7 RID: 1479
		private bool bool_0;

		// Token: 0x040005C8 RID: 1480
		private bool bool_1;

		// Token: 0x040005C9 RID: 1481
		private bool bool_2;

		// Token: 0x040005CA RID: 1482
		private bool bool_3;
	}
}
