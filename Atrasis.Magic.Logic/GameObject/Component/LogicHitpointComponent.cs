using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.GameObject.Component
{
	// Token: 0x02000124 RID: 292
	public sealed class LogicHitpointComponent : LogicComponent
	{
		// Token: 0x06000F8C RID: 3980 RVA: 0x00042818 File Offset: 0x00040A18
		public LogicHitpointComponent(LogicGameObject gameObject, int hp, int team) : base(gameObject)
		{
			this.int_0 = team;
			this.int_14 = new int[8];
			this.int_15 = new int[8];
			this.int_5 = 60;
			this.int_1 = 100 * hp;
			this.int_2 = 100 * hp;
			this.int_3 = 100 * hp;
		}

		// Token: 0x06000F8D RID: 3981 RVA: 0x0000A96D File Offset: 0x00008B6D
		public void SetMaxRegenerationTime(int time)
		{
			this.int_4 = time;
		}

		// Token: 0x06000F8E RID: 3982 RVA: 0x0000A976 File Offset: 0x00008B76
		public void EnableRegeneration(bool state)
		{
			this.bool_0 = state;
		}

		// Token: 0x06000F8F RID: 3983 RVA: 0x00042874 File Offset: 0x00040A74
		public void SetPoisonDamage(int damage, bool increaseSlowly)
		{
			int num = 8;
			if (this.int_11 >= 80)
			{
				num = 24;
				if (this.int_11 >= 320)
				{
					num = 136;
					if (this.int_11 >= 1000)
					{
						num = 0;
					}
				}
			}
			if (this.int_10 != 0)
			{
				if (this.int_10 >= damage)
				{
					if (this.int_10 > damage)
					{
						num = damage * num / this.int_10;
					}
				}
				else
				{
					this.int_11 = this.int_10 * this.int_11 / damage;
					this.int_10 = damage;
				}
			}
			else
			{
				this.int_10 = damage;
			}
			this.int_11 = (increaseSlowly ? LogicMath.Min(num + this.int_11, 1000) : 1000);
			this.int_9 = 640;
		}

		// Token: 0x06000F90 RID: 3984 RVA: 0x0004292C File Offset: 0x00040B2C
		public void CauseDamage(int damage, int gameObjectId, LogicGameObject gameObject)
		{
			if (damage >= 0 || this.int_1 != 0)
			{
				if (this.m_parent == null)
				{
					if (damage > 0 && this.int_12 > 0)
					{
						return;
					}
				}
				else
				{
					LogicCombatComponent combatComponent = this.m_parent.GetCombatComponent();
					if (combatComponent != null && combatComponent.GetUndergroundTime() > 0 && damage > 0)
					{
						damage = 0;
					}
					if (!this.m_parent.GetLevel().GetInvulnerabilityEnabled())
					{
						if (damage > 0 && this.int_12 > 0)
						{
							return;
						}
					}
					else
					{
						damage = 0;
					}
					if (this.m_parent.GetGameObjectType() == LogicGameObjectType.CHARACTER)
					{
						LogicCharacter logicCharacter = (LogicCharacter)this.m_parent;
						LogicArrayList<LogicCharacter> childTroops = logicCharacter.GetChildTroops();
						if ((childTroops != null && childTroops.Size() > 0) || logicCharacter.GetSpawnDelay() > 0)
						{
							return;
						}
					}
				}
				if (gameObjectId != 0 && damage < 0)
				{
					int num = -1;
					int num2 = -1;
					for (int i = 0; i < 8; i++)
					{
						if (this.int_15[i] == gameObjectId)
						{
							num = i;
						}
						else if (num2 == -1)
						{
							num2 = i;
							if (this.int_14[i] > 0)
							{
								num2 = -1;
							}
						}
					}
					if (num2 < num && num != -1 && num2 != -1)
					{
						this.int_15[num2] = gameObjectId;
						this.int_14[num2] = 1000;
						this.int_15[num] = 0;
						this.int_14[num] = 0;
					}
					else if (num == -1)
					{
						if (num2 != -1)
						{
							this.int_15[num2] = gameObjectId;
							this.int_14[num2] = 1000;
						}
						else
						{
							num2 = 8;
						}
					}
					else
					{
						num2 = num;
						this.int_14[num] = 1000;
					}
					damage = damage * LogicDataTables.GetGlobals().GetHealStackPercent(num2) / 100;
				}
				int num3 = (this.int_1 + 99) / 100;
				int num4 = this.int_1;
				this.int_1 = LogicMath.Clamp(this.int_1 - damage, 0, this.int_2);
				int num5 = (this.int_1 + 99) / 100;
				if (num3 > num5)
				{
					LogicResourceStorageComponent logicResourceStorageComponent = (LogicResourceStorageComponent)this.m_parent.GetComponent(LogicComponentType.RESOURCE_STORAGE);
					LogicResourceProductionComponent logicResourceProductionComponent = (LogicResourceProductionComponent)this.m_parent.GetComponent(LogicComponentType.RESOURCE_PRODUCTION);
					LogicWarResourceStorageComponent logicWarResourceStorageComponent = (LogicWarResourceStorageComponent)this.m_parent.GetComponent(LogicComponentType.WAR_RESOURCE_STORAGE);
					if (this.m_parent.GetGameObjectType() == LogicGameObjectType.BUILDING && (!((LogicBuilding)this.m_parent).GetBuildingData().IsLootOnDestruction() || (num4 > 0 && (this.int_1 == 0 || this.int_1 >= -198))))
					{
						if (logicResourceStorageComponent != null)
						{
							logicResourceStorageComponent.ResourcesStolen(num3 - num5, num3);
						}
						if (logicResourceProductionComponent != null)
						{
							logicResourceProductionComponent.ResourcesStolen(num3 - num5, num3);
						}
						if (logicWarResourceStorageComponent != null)
						{
							logicWarResourceStorageComponent.ResourcesStolen(num3 - num5, num3);
						}
					}
					if (this.m_parent.IsWall())
					{
						this.m_parent.RefreshPassable();
					}
					this.int_5 = 0;
				}
				this.UpdateHeroHealthToAvatar(num5);
				if (damage <= 0)
				{
					if (damage < 0)
					{
					}
				}
				else if (this.m_parent.GetMovementComponent() != null)
				{
					this.m_parent.GetMovementComponent().SetPatrolFreeze();
				}
				if (num4 > 0 && this.int_1 == 0)
				{
					this.m_parent.DeathEvent();
					this.m_parent.GetLevel().UpdateBattleStatus();
					if (this.m_parent.IsWall())
					{
						this.WallRemoved();
					}
				}
			}
		}

		// Token: 0x06000F91 RID: 3985 RVA: 0x0000A97F File Offset: 0x00008B7F
		public void Kill()
		{
			this.int_12 = 0;
			this.CauseDamage(this.int_2, 0, null);
		}

		// Token: 0x06000F92 RID: 3986 RVA: 0x0000A996 File Offset: 0x00008B96
		public void CauseDamagePermil(int hp)
		{
			this.CauseDamage(hp, 0, null);
			this.int_13++;
		}

		// Token: 0x06000F93 RID: 3987 RVA: 0x0000A9AF File Offset: 0x00008BAF
		public int GetDamagePermilCount()
		{
			return this.int_13;
		}

		// Token: 0x06000F94 RID: 3988 RVA: 0x00042C2C File Offset: 0x00040E2C
		public void UpdateHeroHealthToAvatar(int hitpoint)
		{
			LogicAvatar logicAvatar = (this.int_0 == 1) ? this.m_parent.GetLevel().GetHomeOwnerAvatar() : this.m_parent.GetLevel().GetVisitorAvatar();
			LogicHeroData logicHeroData = null;
			int upgLevel = 0;
			if (this.m_parent.IsHero())
			{
				LogicCharacter logicCharacter = (LogicCharacter)this.m_parent;
				logicHeroData = (LogicHeroData)logicCharacter.GetCharacterData();
				upgLevel = logicCharacter.GetUpgradeLevel();
			}
			else if (this.m_parent.GetGameObjectType() == LogicGameObjectType.BUILDING)
			{
				LogicBuilding logicBuilding = (LogicBuilding)this.m_parent;
				if (logicBuilding.GetHeroBaseComponent() == null)
				{
					return;
				}
				LogicBuildingData buildingData = logicBuilding.GetBuildingData();
				if (!buildingData.GetShareHeroCombatData())
				{
					return;
				}
				LogicCombatComponent combatComponent = logicBuilding.GetCombatComponent();
				if (combatComponent == null || !combatComponent.IsEnabled())
				{
					return;
				}
				logicHeroData = buildingData.GetHeroData();
				upgLevel = logicAvatar.GetUnitUpgradeLevel(logicHeroData);
			}
			if (logicHeroData != null)
			{
				int count = LogicMath.Min(logicHeroData.GetSecondsToFullHealth(hitpoint, upgLevel), logicHeroData.GetFullRegenerationTimeSec(upgLevel));
				if (logicAvatar != null)
				{
					logicAvatar.GetChangeListener().CommodityCountChanged(0, logicHeroData, count);
					logicAvatar.SetHeroHealth(logicHeroData, count);
				}
			}
		}

		// Token: 0x06000F95 RID: 3989 RVA: 0x00042D28 File Offset: 0x00040F28
		public void WallRemoved()
		{
			LogicArrayList<LogicComponent> components = this.m_parent.GetComponentManager().GetComponents(LogicComponentType.MOVEMENT);
			for (int i = 0; i < components.Size(); i++)
			{
				LogicCombatComponent combatComponent = components[i].GetParent().GetCombatComponent();
				if (combatComponent != null && combatComponent.GetTarget(0) != null && combatComponent.GetTarget(0).IsWall())
				{
					combatComponent.ForceNewTarget();
				}
			}
		}

		// Token: 0x06000F96 RID: 3990 RVA: 0x0000A9B7 File Offset: 0x00008BB7
		public void SetMaxHitpoints(int maxHp)
		{
			this.int_2 = 100 * maxHp;
			this.int_1 = LogicMath.Clamp(this.int_1, 0, this.int_2);
			this.int_3 = this.int_2;
		}

		// Token: 0x06000F97 RID: 3991 RVA: 0x0000A9E7 File Offset: 0x00008BE7
		public void SetHitpoints(int hp)
		{
			this.int_1 = LogicMath.Clamp(100 * hp, 0, this.int_2);
		}

		// Token: 0x06000F98 RID: 3992 RVA: 0x00042D8C File Offset: 0x00040F8C
		public bool IsEnemy(LogicGameObject gameObject)
		{
			LogicHitpointComponent logicHitpointComponent = (LogicHitpointComponent)gameObject.GetComponent(LogicComponentType.HITPOINT);
			return logicHitpointComponent != null && logicHitpointComponent.GetTeam() != this.int_0 && this.int_1 > 0;
		}

		// Token: 0x06000F99 RID: 3993 RVA: 0x0000A9FF File Offset: 0x00008BFF
		public bool IsEnemyForTeam(int team)
		{
			return this.int_0 != team && this.int_1 > 0;
		}

		// Token: 0x06000F9A RID: 3994 RVA: 0x0000AA15 File Offset: 0x00008C15
		public int GetTeam()
		{
			return this.int_0;
		}

		// Token: 0x06000F9B RID: 3995 RVA: 0x00042DC4 File Offset: 0x00040FC4
		public void SetTeam(int team)
		{
			this.int_0 = team;
			if (team != 0 && this.m_parent.GetGameObjectType() == LogicGameObjectType.CHARACTER)
			{
				LogicCharacter logicCharacter = (LogicCharacter)this.m_parent;
				LogicCombatComponent combatComponent = logicCharacter.GetCombatComponent();
				if (combatComponent != null)
				{
					if (logicCharacter.GetCharacterData().IsUnderground())
					{
						combatComponent.SetUndergroundTime(0);
					}
					LogicMovementComponent movementComponent = logicCharacter.GetMovementComponent();
					if (movementComponent != null)
					{
						movementComponent.SetUnderground(false);
					}
				}
			}
		}

		// Token: 0x06000F9C RID: 3996 RVA: 0x0000AA1D File Offset: 0x00008C1D
		public int GetInvulnerabilityTime()
		{
			return this.int_12;
		}

		// Token: 0x06000F9D RID: 3997 RVA: 0x0000AA25 File Offset: 0x00008C25
		public void SetInvulnerabilityTime(int ms)
		{
			this.int_12 = ms;
		}

		// Token: 0x06000F9E RID: 3998 RVA: 0x0000AA2E File Offset: 0x00008C2E
		public bool HasFullHitpoints()
		{
			return this.int_1 == this.int_2;
		}

		// Token: 0x06000F9F RID: 3999 RVA: 0x0000AA3E File Offset: 0x00008C3E
		public void SetDieEffect(LogicEffectData data1, LogicEffectData data2)
		{
			this.logicEffectData_0 = data1;
			this.logicEffectData_0 = data2;
		}

		// Token: 0x06000FA0 RID: 4000 RVA: 0x0000AA4E File Offset: 0x00008C4E
		public bool IsDamagedRecently()
		{
			return this.int_5 < 30;
		}

		// Token: 0x06000FA1 RID: 4001 RVA: 0x00042E24 File Offset: 0x00041024
		public override void Tick()
		{
			if (this.int_1 < this.int_2 && this.bool_0)
			{
				int num = this.int_2 / 5;
				int num2 = this.int_1;
				if (this.int_4 <= 0)
				{
					this.int_1 = this.int_2;
					this.int_6 = 0;
				}
				else
				{
					this.int_6 += 64;
					int num3 = LogicMath.Max(1000 * this.int_4 / (this.int_2 / 100), 1);
					this.int_1 += 100 * (this.int_6 / num3);
					if (this.int_1 >= this.int_2)
					{
						this.int_1 = this.int_2;
						this.int_6 = 0;
					}
					else
					{
						this.int_6 %= num3;
					}
				}
				if (num2 < num && this.int_1 >= num)
				{
					base.GetParentListener();
				}
			}
			if (this.int_8 > 0)
			{
				this.int_8 -= 64;
				if (this.int_8 <= 0)
				{
					this.int_8 = 0;
					if (this.int_1 > 0)
					{
						if (this.int_3 != this.int_2)
						{
							this.int_1 = (int)((long)this.int_3 * (long)this.int_1 / (long)this.int_2);
							this.int_2 = this.int_3;
						}
						this.int_8 = -1;
					}
				}
			}
			if (this.int_9 <= 0)
			{
				if (this.int_11 > 0)
				{
					this.int_11 -= 10;
					if (this.int_11 <= 0)
					{
						this.int_11 = 0;
						this.int_10 = 0;
					}
				}
			}
			else
			{
				this.int_9 = LogicMath.Max(this.int_9 - 64, 0);
			}
			if (this.int_11 > 0)
			{
				this.CauseDamage((int)((long)(this.int_10 * this.int_11) / 1000L * 64L / 1000L), 0, null);
			}
			this.int_12 = LogicMath.Max(this.int_12 - 64, 0);
			for (int i = 0; i < 8; i++)
			{
				this.int_14[i] -= 64;
				if (this.int_14[i] <= 0)
				{
					this.int_14[i] = 0;
					this.int_15[i] = 0;
				}
			}
			this.int_5++;
			if (this.int_7 > 0)
			{
				this.int_7--;
				if (this.int_7 == 0)
				{
					this.int_1 = LogicMath.Min(this.int_3 * (100 * this.int_1 / this.int_2) / 100, this.int_3);
					this.int_2 = this.int_3;
				}
			}
		}

		// Token: 0x06000FA2 RID: 4002 RVA: 0x000430B4 File Offset: 0x000412B4
		public override void FastForwardTime(int time)
		{
			if (this.bool_0)
			{
				this.int_6 += 64;
				if (this.int_4 <= time)
				{
					this.int_1 = this.int_2;
					return;
				}
				this.int_1 += this.int_2 * time / this.int_4;
				if (this.int_1 > this.int_2)
				{
					this.int_1 = this.int_2;
				}
			}
		}

		// Token: 0x06000FA3 RID: 4003 RVA: 0x00002B56 File Offset: 0x00000D56
		public override LogicComponentType GetComponentType()
		{
			return LogicComponentType.HITPOINT;
		}

		// Token: 0x06000FA4 RID: 4004 RVA: 0x0000AA5A File Offset: 0x00008C5A
		public override void Load(LogicJSONObject jsonObject)
		{
			this.LoadHitpoint(jsonObject);
		}

		// Token: 0x06000FA5 RID: 4005 RVA: 0x0000AA63 File Offset: 0x00008C63
		public override void LoadFromSnapshot(LogicJSONObject jsonObject)
		{
			this.LoadHitpoint(jsonObject);
			this.int_1 = this.int_2;
			this.bool_0 = false;
		}

		// Token: 0x06000FA6 RID: 4006 RVA: 0x00043124 File Offset: 0x00041324
		public void LoadHitpoint(LogicJSONObject jsonObject)
		{
			LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("hp");
			LogicJSONBoolean jsonboolean = jsonObject.GetJSONBoolean("reg");
			if (jsonnumber != null)
			{
				this.int_1 = ((this.m_parent.GetLevel().GetState() != 2) ? LogicMath.Clamp(jsonnumber.GetIntValue(), 0, this.int_2) : this.int_2);
			}
			else
			{
				this.int_1 = this.int_2;
			}
			this.bool_0 = (jsonboolean != null && jsonboolean.IsTrue());
		}

		// Token: 0x06000FA7 RID: 4007 RVA: 0x0000AA7F File Offset: 0x00008C7F
		public override void Save(LogicJSONObject jsonObject, int villageType)
		{
			if (this.int_1 < this.int_2)
			{
				jsonObject.Put("hp", new LogicJSONNumber(this.int_1));
				jsonObject.Put("reg", new LogicJSONBoolean(this.bool_0));
			}
		}

		// Token: 0x06000FA8 RID: 4008 RVA: 0x0000AA7F File Offset: 0x00008C7F
		public override void SaveToSnapshot(LogicJSONObject jsonObject, int layoutId)
		{
			if (this.int_1 < this.int_2)
			{
				jsonObject.Put("hp", new LogicJSONNumber(this.int_1));
				jsonObject.Put("reg", new LogicJSONBoolean(this.bool_0));
			}
		}

		// Token: 0x06000FA9 RID: 4009 RVA: 0x0000AABB File Offset: 0x00008CBB
		public int GetHitpoints()
		{
			return this.int_1;
		}

		// Token: 0x06000FAA RID: 4010 RVA: 0x0000AAC3 File Offset: 0x00008CC3
		public int GetMaxHitpoints()
		{
			return this.int_2;
		}

		// Token: 0x06000FAB RID: 4011 RVA: 0x0000AACB File Offset: 0x00008CCB
		public int GetOriginalHitpoints()
		{
			return this.int_3;
		}

		// Token: 0x06000FAC RID: 4012 RVA: 0x000431A0 File Offset: 0x000413A0
		public void SetExtraHealth(int hp, int time)
		{
			if (this.int_1 > 0 && (time == -1 || this.int_2 <= hp))
			{
				if (this.int_2 != hp)
				{
					this.int_1 = (int)((long)hp * (long)this.int_1 / (long)this.int_2);
					this.int_2 = hp;
				}
				this.int_8 = time;
			}
		}

		// Token: 0x06000FAD RID: 4013 RVA: 0x0000AAD3 File Offset: 0x00008CD3
		public void SetShrinkHitpoints(int time, int hp)
		{
			this.int_7 = time;
			this.int_2 = hp * this.int_3 / 100;
			this.int_1 = LogicMath.Min(this.int_1, this.int_2);
		}

		// Token: 0x06000FAE RID: 4014 RVA: 0x0000AB04 File Offset: 0x00008D04
		public int GetPoisonRemainingMS()
		{
			return this.int_9 + (this.int_11 << 6) / 10;
		}

		// Token: 0x0400065E RID: 1630
		private bool bool_0;

		// Token: 0x0400065F RID: 1631
		private int int_0;

		// Token: 0x04000660 RID: 1632
		private int int_1;

		// Token: 0x04000661 RID: 1633
		private int int_2;

		// Token: 0x04000662 RID: 1634
		private int int_3;

		// Token: 0x04000663 RID: 1635
		private int int_4;

		// Token: 0x04000664 RID: 1636
		private int int_5;

		// Token: 0x04000665 RID: 1637
		private int int_6;

		// Token: 0x04000666 RID: 1638
		private int int_7;

		// Token: 0x04000667 RID: 1639
		private int int_8;

		// Token: 0x04000668 RID: 1640
		private int int_9;

		// Token: 0x04000669 RID: 1641
		private int int_10;

		// Token: 0x0400066A RID: 1642
		private int int_11;

		// Token: 0x0400066B RID: 1643
		private int int_12;

		// Token: 0x0400066C RID: 1644
		private int int_13;

		// Token: 0x0400066D RID: 1645
		private readonly int[] int_14;

		// Token: 0x0400066E RID: 1646
		private readonly int[] int_15;

		// Token: 0x0400066F RID: 1647
		private LogicEffectData logicEffectData_0;

		// Token: 0x04000670 RID: 1648
		private LogicEffectData logicEffectData_1;
	}
}
