using System;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.CSV;
using Atrasis.Magic.Titan.Debug;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000142 RID: 322
	public class LogicCharacterData : LogicCombatItemData
	{
		// Token: 0x060011A9 RID: 4521 RVA: 0x0000BD99 File Offset: 0x00009F99
		public LogicCharacterData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x060011AA RID: 4522 RVA: 0x0004CBF4 File Offset: 0x0004ADF4
		public override void CreateReferences()
		{
			base.CreateReferences();
			int upgradeLevelCount = base.GetUpgradeLevelCount();
			this.m_attackerItemData = new LogicAttackerItemData[upgradeLevelCount];
			this.logicEffectData_1 = new LogicEffectData[upgradeLevelCount];
			this.logicSpellData_1 = new LogicSpellData[upgradeLevelCount];
			this.logicSpellData_2 = new LogicSpellData[upgradeLevelCount];
			this.logicEffectData_2 = new LogicEffectData[upgradeLevelCount];
			this.logicEffectData_3 = new LogicEffectData[upgradeLevelCount];
			this.logicEffectData_4 = new LogicEffectData[upgradeLevelCount];
			this.logicEffectData_5 = new LogicEffectData[upgradeLevelCount];
			this.logicEffectData_6 = new LogicEffectData[upgradeLevelCount];
			this.m_hitpoints = new int[upgradeLevelCount];
			this.int_37 = new int[upgradeLevelCount];
			this.m_unitsInCamp = new int[upgradeLevelCount];
			this.m_strengthWeight = new int[upgradeLevelCount];
			this.m_specialAbilityLevel = new int[upgradeLevelCount];
			this.m_specialAbilityAttribute = new int[upgradeLevelCount];
			this.m_specialAbilityAttribute2 = new int[upgradeLevelCount];
			this.m_specialAbilityAttribute3 = new int[upgradeLevelCount];
			this.int_43 = new int[upgradeLevelCount];
			this.int_40 = new int[upgradeLevelCount];
			this.int_41 = new int[upgradeLevelCount];
			this.int_42 = new int[upgradeLevelCount];
			this.int_44 = new int[upgradeLevelCount];
			this.int_45 = new int[upgradeLevelCount];
			this.int_46 = new int[upgradeLevelCount];
			this.int_38 = new int[3];
			this.int_39 = new int[3];
			for (int i = 0; i < this.m_hitpoints.Length; i++)
			{
				this.m_attackerItemData[i] = new LogicAttackerItemData();
				this.m_attackerItemData[i].CreateReferences(this.m_row, this, i);
				this.m_hitpoints[i] = base.GetClampedIntegerValue("Hitpoints", i);
				this.int_37[i] = base.GetClampedIntegerValue("SecondaryTroopCnt", i);
				this.m_unitsInCamp[i] = base.GetClampedIntegerValue("UnitsInCamp", i);
				this.m_specialAbilityLevel[i] = base.GetClampedIntegerValue("SpecialAbilityLevel", i);
				this.logicEffectData_1[i] = LogicDataTables.GetEffectByName(base.GetClampedValue("SpecialAbilityEffect", i), this);
				this.logicEffectData_2[i] = LogicDataTables.GetEffectByName(base.GetClampedValue("DeployEffect", i), this);
				this.logicEffectData_3[i] = LogicDataTables.GetEffectByName(base.GetClampedValue("DieEffect", i), this);
				this.logicEffectData_4[i] = LogicDataTables.GetEffectByName(base.GetClampedValue("DieEffect2", i), this);
				this.logicEffectData_5[i] = LogicDataTables.GetEffectByName(base.GetClampedValue("DieDamageEffect", i), this);
				this.logicEffectData_6[i] = LogicDataTables.GetEffectByName(base.GetClampedValue("MoveTrailEffect", i), this);
				this.int_40[i] = base.GetClampedIntegerValue("AttackCount", i);
				this.int_41[i] = base.GetClampedIntegerValue("AbilityAttackCount", i);
				this.int_42[i] = base.GetClampedIntegerValue("DieDamage", i);
				this.m_strengthWeight[i] = base.GetClampedIntegerValue("StrengthWeight", i);
				this.int_43[i] = base.GetClampedIntegerValue("Scale", i);
				if (this.int_43[i] == 0)
				{
					this.int_43[i] = 100;
				}
				this.logicSpellData_1[i] = LogicDataTables.GetSpellByName(base.GetClampedValue("AuraSpell", i), this);
				this.int_44[i] = base.GetClampedIntegerValue("AuraSpellLevel", i);
				this.logicSpellData_2[i] = LogicDataTables.GetSpellByName(base.GetClampedValue("RetributionSpell", i), this);
				this.int_45[i] = base.GetClampedIntegerValue("RetributionSpellLevel", i);
				this.int_46[i] = base.GetClampedIntegerValue("RetributionSpellTriggerHealth", i);
				this.m_specialAbilityAttribute[i] = base.GetClampedIntegerValue("SpecialAbilityAttribute", i);
				this.m_specialAbilityAttribute2[i] = base.GetClampedIntegerValue("SpecialAbilityAttribute2", i);
				this.m_specialAbilityAttribute3[i] = base.GetClampedIntegerValue("SpecialAbilityAttribute3", i);
			}
			this.logicEffectData_0 = LogicDataTables.GetEffectByName(base.GetValue("MoveStartsEffect", 0), this);
			this.int_14 = this.method_0();
			string value = base.GetValue("SpecialAbilitySpell", 0);
			if (value.Length > 0)
			{
				this.logicSpellData_0 = LogicDataTables.GetSpellByName(value, this);
			}
			this.string_0 = base.GetValue("SWF", 0);
			this.string_1 = base.GetValue("SpecialAbilityName", 0);
			this.string_2 = base.GetValue("SpecialAbilityInfo", 0);
			this.string_3 = base.GetValue("BigPictureSWF", 0);
			this.int_17 = (base.GetIntegerValue("DieDamageRadius", 0) << 9) / 100;
			this.int_18 = base.GetIntegerValue("DieDamageDelay", 0);
			if (this.int_18 > 4000)
			{
				Debugger.Warning("m_dieDamageDelay too big");
				this.int_18 = 4000;
			}
			this.logicCharacterData_1 = LogicDataTables.GetCharacterByName(base.GetValue("SecondaryTroop", 0), this);
			this.bool_6 = base.GetBooleanValue("IsSecondaryTroop", 0);
			this.int_19 = (base.GetIntegerValue("SecondarySpawnDist", 0) << 9) / 100;
			this.int_20 = (base.GetIntegerValue("SecondarySpawnOffset", 0) << 9) / 100;
			this.logicObstacleData_0 = LogicDataTables.GetObstacleByName(base.GetValue("TombStone", 0), this);
			this.int_21 = base.GetIntegerValue("MaxTrainingCount", 0);
			this.int_15 = base.GetIntegerValue("BarrackLevel", 0) - 1;
			this.bool_2 = base.GetBooleanValue("IsFlying", 0);
			this.bool_3 = base.GetBooleanValue("IsJumper", 0);
			this.int_22 = base.GetIntegerValue("MovementOffsetAmount", 0);
			this.int_23 = base.GetIntegerValue("MovementOffsetSpeed", 0);
			this.bool_8 = base.GetName().Equals("Balloon Goblin");
			this.int_24 = base.GetIntegerValue("SpawnIdle", 0);
			this.logicCharacterData_0 = LogicDataTables.GetCharacterByName(base.GetValue("ChildTroop", 0), this);
			this.int_16 = base.GetIntegerValue("ChildTroopCount", 0);
			for (int j = 0; j < 3; j++)
			{
				this.int_38[j] = base.GetIntegerValue(string.Format("ChildTroop{0}_X", j), 0);
				this.int_39[j] = base.GetIntegerValue(string.Format("ChildTroop{0}_Y", j), 0);
			}
			this.bool_7 = base.GetBooleanValue("AttackMultipleBuildings", 0);
			if (!this.m_attackerItemData[0].IsSelfAsAoeCenter())
			{
				this.bool_7 = false;
			}
			this.int_9 = (base.GetIntegerValue("Speed", 0) << 9) / 100;
			this.int_10 = (base.GetIntegerValue("SpeedDecreasePerChildTroopLost", 0) << 9) / 100;
			this.bool_15 = base.GetBooleanValue("PickNewTargetAfterPushback", 0);
			this.int_11 = base.GetIntegerValue("PushbackSpeed", 0);
			this.int_12 = base.GetIntegerValue("HitEffectOffset", 0);
			this.int_13 = (base.GetIntegerValue("TargetedEffectOffset", 0) << 9) / 100;
			this.bool_9 = base.GetBooleanValue("RandomizeSecSpawnDist", 0);
			this.string_4 = base.GetValue("CustonDefenderIcon", 0);
			this.int_25 = (base.GetIntegerValue("AutoMergeDistance", 0) << 9) / 100;
			this.int_26 = base.GetIntegerValue("AutoMergeGroupSize", 0);
			this.int_27 = (base.GetIntegerValue("InvisibilityRadius", 0) << 9) / 100;
			this.int_28 = base.GetIntegerValue("HealthReductionPerSecond", 0);
			this.bool_4 = base.GetBooleanValue("IsUnderground", 0);
			this.bool_10 = !base.GetBooleanValue("NoAttackOverWalls", 0);
			this.bool_11 = base.GetBooleanValue("SmoothJump", 0);
			this.string_5 = base.GetValue("AuraTID", 0);
			this.string_6 = base.GetValue("AuraDescTID", 0);
			this.string_7 = base.GetValue("AuraBigPictureExportName", 0);
			this.int_29 = base.GetIntegerValue("FriendlyGroupWeight", 0);
			this.int_30 = base.GetIntegerValue("EnemyGroupWeight", 0);
			this.bool_12 = base.GetBooleanValue("ScaleByTH", 0);
			this.bool_5 = base.GetBooleanValue("DisableDonate", 0);
			this.int_35 = base.GetIntegerValue("LoseHpPerTick", 0);
			this.int_36 = base.GetIntegerValue("LoseHpInterval", 0);
			this.bool_13 = base.GetBooleanValue("TriggersTraps", 0);
			this.int_31 = base.GetIntegerValue("ChainShootingDistance", 0);
			this.bool_14 = base.GetBooleanValue("BoostedIfAlone", 0);
			this.int_32 = (base.GetIntegerValue("BoostRadius", 0) << 9) / 100;
			this.int_33 = base.GetIntegerValue("BoostDmgPerfect", 0);
			this.int_34 = base.GetIntegerValue("BoostAttackSpeed", 0);
		}

		// Token: 0x060011AB RID: 4523 RVA: 0x0000BDA3 File Offset: 0x00009FA3
		public override void CreateReferences2()
		{
			if (this.logicObstacleData_0 != null && !this.logicObstacleData_0.IsEnabledInVillageType(base.GetVillageType()))
			{
				Debugger.Error(string.Format("invalid tombstone for unit '{0}' villageType's do not match", base.GetName()));
			}
		}

		// Token: 0x060011AC RID: 4524 RVA: 0x0004D454 File Offset: 0x0004B654
		private int method_0()
		{
			string value = base.GetValue("SpecialAbilityType", 0);
			if (string.Equals(value, "StartRage", StringComparison.InvariantCultureIgnoreCase))
			{
				return 0;
			}
			if (string.Equals(value, "BigFirstHit", StringComparison.InvariantCultureIgnoreCase))
			{
				return 1;
			}
			if (string.Equals(value, "StartCloak", StringComparison.InvariantCultureIgnoreCase))
			{
				return 2;
			}
			if (string.Equals(value, "SpeedBoost", StringComparison.InvariantCultureIgnoreCase))
			{
				return 3;
			}
			if (string.Equals(value, "DieDamage", StringComparison.InvariantCultureIgnoreCase))
			{
				return 4;
			}
			if (string.Equals(value, "SpawnUnits", StringComparison.InvariantCultureIgnoreCase))
			{
				return 5;
			}
			if (string.Equals(value, "SpecialProjectile", StringComparison.InvariantCultureIgnoreCase))
			{
				return 6;
			}
			if (string.Equals(value, "RageAlone", StringComparison.InvariantCultureIgnoreCase))
			{
				return 7;
			}
			if (string.Equals(value, "RespawnAsCannon", StringComparison.InvariantCultureIgnoreCase))
			{
				return 8;
			}
			return -1;
		}

		// Token: 0x060011AD RID: 4525 RVA: 0x0000BDD5 File Offset: 0x00009FD5
		public int GetSpecialAbilityType()
		{
			return this.int_14;
		}

		// Token: 0x060011AE RID: 4526 RVA: 0x0000BDDD File Offset: 0x00009FDD
		public override int GetRequiredProductionHouseLevel()
		{
			return this.int_15;
		}

		// Token: 0x060011AF RID: 4527 RVA: 0x0000BDE5 File Offset: 0x00009FE5
		public override bool IsDonationDisabled()
		{
			return this.bool_5;
		}

		// Token: 0x060011B0 RID: 4528 RVA: 0x0000BDED File Offset: 0x00009FED
		public override bool IsUnlockedForProductionHouseLevel(int level)
		{
			return level >= this.int_15;
		}

		// Token: 0x060011B1 RID: 4529 RVA: 0x0000BDFB File Offset: 0x00009FFB
		public override LogicBuildingData GetProductionHouseData()
		{
			return LogicDataTables.GetBuildingByName((base.GetVillageType() == 1) ? ((base.GetUnitOfType() == 1) ? "Barrack2" : "Dark Elixir Barrack2") : ((base.GetUnitOfType() == 1) ? "Barrack" : "Dark Elixir Barrack"), null);
		}

		// Token: 0x060011B2 RID: 4530 RVA: 0x0000BE38 File Offset: 0x0000A038
		public LogicAttackerItemData GetAttackerItemData(int idx)
		{
			return this.m_attackerItemData[idx];
		}

		// Token: 0x060011B3 RID: 4531 RVA: 0x0000BE42 File Offset: 0x0000A042
		public override bool IsUnderground()
		{
			return this.bool_4;
		}

		// Token: 0x060011B4 RID: 4532 RVA: 0x0000BE4A File Offset: 0x0000A04A
		public int GetHitpoints(int index)
		{
			return this.m_hitpoints[index];
		}

		// Token: 0x060011B5 RID: 4533 RVA: 0x0000BE54 File Offset: 0x0000A054
		public int GetUnitsInCamp(int index)
		{
			return this.m_unitsInCamp[index];
		}

		// Token: 0x060011B6 RID: 4534 RVA: 0x0000BE5E File Offset: 0x0000A05E
		public bool IsSecondaryTroop()
		{
			return this.bool_6;
		}

		// Token: 0x060011B7 RID: 4535 RVA: 0x0000BE66 File Offset: 0x0000A066
		public int GetSpeed()
		{
			return this.int_9;
		}

		// Token: 0x060011B8 RID: 4536 RVA: 0x0000BE6E File Offset: 0x0000A06E
		public int GetSpecialAbilityLevel(int upgLevel)
		{
			return this.m_specialAbilityLevel[upgLevel];
		}

		// Token: 0x060011B9 RID: 4537 RVA: 0x0000BE78 File Offset: 0x0000A078
		public int GetSpecialAbilityAttribute(int upgLevel)
		{
			return this.m_specialAbilityAttribute[upgLevel];
		}

		// Token: 0x060011BA RID: 4538 RVA: 0x0000BE82 File Offset: 0x0000A082
		public int GetSpecialAbilityAttribute2(int upgLevel)
		{
			return this.m_specialAbilityAttribute2[upgLevel];
		}

		// Token: 0x060011BB RID: 4539 RVA: 0x0000BE8C File Offset: 0x0000A08C
		public int GetSpecialAbilityAttribute3(int upgLevel)
		{
			return this.m_specialAbilityAttribute3[upgLevel];
		}

		// Token: 0x060011BC RID: 4540 RVA: 0x0000BE96 File Offset: 0x0000A096
		public int GetAbilityAttackCount(int upgLevel)
		{
			return this.int_41[upgLevel];
		}

		// Token: 0x060011BD RID: 4541 RVA: 0x0000BEA0 File Offset: 0x0000A0A0
		public LogicCharacterData GetChildTroop()
		{
			return this.logicCharacterData_0;
		}

		// Token: 0x060011BE RID: 4542 RVA: 0x0000BEA8 File Offset: 0x0000A0A8
		public int GetChildTroopCount()
		{
			return this.int_16;
		}

		// Token: 0x060011BF RID: 4543 RVA: 0x0000BEB0 File Offset: 0x0000A0B0
		public int GetChildTroopX(int idx)
		{
			return this.int_38[idx];
		}

		// Token: 0x060011C0 RID: 4544 RVA: 0x0000BEBA File Offset: 0x0000A0BA
		public int GetChildTroopY(int idx)
		{
			return this.int_39[idx];
		}

		// Token: 0x060011C1 RID: 4545 RVA: 0x0000BEC4 File Offset: 0x0000A0C4
		public bool GetAttackMultipleBuildings()
		{
			return this.bool_7;
		}

		// Token: 0x060011C2 RID: 4546 RVA: 0x0000BECC File Offset: 0x0000A0CC
		public LogicCharacterData GetSecondaryTroop()
		{
			return this.logicCharacterData_1;
		}

		// Token: 0x060011C3 RID: 4547 RVA: 0x0000BED4 File Offset: 0x0000A0D4
		public LogicSpellData GetSpecialAbilitySpell()
		{
			return this.logicSpellData_0;
		}

		// Token: 0x060011C4 RID: 4548 RVA: 0x0000BEDC File Offset: 0x0000A0DC
		public LogicObstacleData GetTombstone()
		{
			return this.logicObstacleData_0;
		}

		// Token: 0x060011C5 RID: 4549 RVA: 0x0000BEE4 File Offset: 0x0000A0E4
		public LogicEffectData GetMoveStartsEffect()
		{
			return this.logicEffectData_0;
		}

		// Token: 0x060011C6 RID: 4550 RVA: 0x0000BEEC File Offset: 0x0000A0EC
		public bool GetRandomizeSecSpawnDist()
		{
			return this.bool_9;
		}

		// Token: 0x060011C7 RID: 4551 RVA: 0x0000BEF4 File Offset: 0x0000A0F4
		public bool GetAttackOverWalls()
		{
			return this.bool_10;
		}

		// Token: 0x060011C8 RID: 4552 RVA: 0x0000BEFC File Offset: 0x0000A0FC
		public bool GetSmoothJump()
		{
			return this.bool_11;
		}

		// Token: 0x060011C9 RID: 4553 RVA: 0x0000BF04 File Offset: 0x0000A104
		public bool GetScaleByTH()
		{
			return this.bool_12;
		}

		// Token: 0x060011CA RID: 4554 RVA: 0x0000BF0C File Offset: 0x0000A10C
		public bool GetTriggersTraps()
		{
			return this.bool_13;
		}

		// Token: 0x060011CB RID: 4555 RVA: 0x0000BF14 File Offset: 0x0000A114
		public bool GetBoostedIfAlone()
		{
			return this.bool_14;
		}

		// Token: 0x060011CC RID: 4556 RVA: 0x0000BF1C File Offset: 0x0000A11C
		public bool GetPickNewTargetAfterPushback()
		{
			return this.bool_15;
		}

		// Token: 0x060011CD RID: 4557 RVA: 0x0000BF24 File Offset: 0x0000A124
		public int GetSpeedDecreasePerChildTroopLost()
		{
			return this.int_10;
		}

		// Token: 0x060011CE RID: 4558 RVA: 0x0000BF2C File Offset: 0x0000A12C
		public int GetPushbackSpeed()
		{
			return this.int_11;
		}

		// Token: 0x060011CF RID: 4559 RVA: 0x0000BF34 File Offset: 0x0000A134
		public int GetHitEffectOffset()
		{
			return this.int_12;
		}

		// Token: 0x060011D0 RID: 4560 RVA: 0x0000BF3C File Offset: 0x0000A13C
		public int GetTargetedEffectOffset()
		{
			return this.int_13;
		}

		// Token: 0x060011D1 RID: 4561 RVA: 0x0000BF44 File Offset: 0x0000A144
		public int GetDieDamageRadius()
		{
			return this.int_17;
		}

		// Token: 0x060011D2 RID: 4562 RVA: 0x0000BF4C File Offset: 0x0000A14C
		public int GetDieDamage(int upgLevel)
		{
			return LogicGamePlayUtil.DPSToSingleHit(this.int_42[upgLevel], 1000);
		}

		// Token: 0x060011D3 RID: 4563 RVA: 0x0000BF60 File Offset: 0x0000A160
		public int GetDieDamageDelay()
		{
			return this.int_18;
		}

		// Token: 0x060011D4 RID: 4564 RVA: 0x0000BF68 File Offset: 0x0000A168
		public LogicEffectData GetDieEffect(int upgLevel)
		{
			return this.logicEffectData_3[upgLevel];
		}

		// Token: 0x060011D5 RID: 4565 RVA: 0x0000BF72 File Offset: 0x0000A172
		public LogicEffectData GetDieEffect2(int upgLevel)
		{
			return this.logicEffectData_4[upgLevel];
		}

		// Token: 0x060011D6 RID: 4566 RVA: 0x0000BF7C File Offset: 0x0000A17C
		public LogicEffectData GetSpecialAbilityEffect(int upgLevel)
		{
			return this.logicEffectData_1[upgLevel];
		}

		// Token: 0x060011D7 RID: 4567 RVA: 0x0000BF86 File Offset: 0x0000A186
		public int GetSecondarySpawnDistance()
		{
			return this.int_19;
		}

		// Token: 0x060011D8 RID: 4568 RVA: 0x0000BF8E File Offset: 0x0000A18E
		public int GetSecondarySpawnOffset()
		{
			return this.int_20;
		}

		// Token: 0x060011D9 RID: 4569 RVA: 0x0000BF96 File Offset: 0x0000A196
		public int GetMaxTrainingCount()
		{
			return this.int_21;
		}

		// Token: 0x060011DA RID: 4570 RVA: 0x0000BF9E File Offset: 0x0000A19E
		public int GetMovementOffsetAmount()
		{
			return this.int_22;
		}

		// Token: 0x060011DB RID: 4571 RVA: 0x0000BFA6 File Offset: 0x0000A1A6
		public int GetMovementOffsetSpeed()
		{
			return this.int_23;
		}

		// Token: 0x060011DC RID: 4572 RVA: 0x0000BFAE File Offset: 0x0000A1AE
		public int GetSpawnIdle()
		{
			return this.int_24;
		}

		// Token: 0x060011DD RID: 4573 RVA: 0x0000BFB6 File Offset: 0x0000A1B6
		public int GetAutoMergeDistance()
		{
			return this.int_25;
		}

		// Token: 0x060011DE RID: 4574 RVA: 0x0000BFBE File Offset: 0x0000A1BE
		public int GetAutoMergeGroupSize()
		{
			return this.int_26;
		}

		// Token: 0x060011DF RID: 4575 RVA: 0x0000BFC6 File Offset: 0x0000A1C6
		public int GetInvisibilityRadius()
		{
			return this.int_27;
		}

		// Token: 0x060011E0 RID: 4576 RVA: 0x0000BFCE File Offset: 0x0000A1CE
		public int GetHealthReductionPerSecond()
		{
			return this.int_28;
		}

		// Token: 0x060011E1 RID: 4577 RVA: 0x0000BFD6 File Offset: 0x0000A1D6
		public int GetFriendlyGroupWeight()
		{
			return this.int_29;
		}

		// Token: 0x060011E2 RID: 4578 RVA: 0x0000BFDE File Offset: 0x0000A1DE
		public int GetEnemyGroupWeight()
		{
			return this.int_30;
		}

		// Token: 0x060011E3 RID: 4579 RVA: 0x0000BFE6 File Offset: 0x0000A1E6
		public int GetChainShootingDistance()
		{
			return this.int_31;
		}

		// Token: 0x060011E4 RID: 4580 RVA: 0x0000BFEE File Offset: 0x0000A1EE
		public int GetBoostRadius()
		{
			return this.int_32;
		}

		// Token: 0x060011E5 RID: 4581 RVA: 0x0000BFF6 File Offset: 0x0000A1F6
		public int GetBoostDamagePerfect()
		{
			return this.int_33;
		}

		// Token: 0x060011E6 RID: 4582 RVA: 0x0000BFFE File Offset: 0x0000A1FE
		public int GetBoostAttackSpeed()
		{
			return this.int_34;
		}

		// Token: 0x060011E7 RID: 4583 RVA: 0x0000C006 File Offset: 0x0000A206
		public int GetLoseHpPerTick()
		{
			return this.int_35;
		}

		// Token: 0x060011E8 RID: 4584 RVA: 0x0000C00E File Offset: 0x0000A20E
		public int GetLoseHpInterval()
		{
			return this.int_36;
		}

		// Token: 0x060011E9 RID: 4585 RVA: 0x0000C016 File Offset: 0x0000A216
		public string GetSwf()
		{
			return this.string_0;
		}

		// Token: 0x060011EA RID: 4586 RVA: 0x0000C01E File Offset: 0x0000A21E
		public string GetSpecialAbilityName()
		{
			return this.string_1;
		}

		// Token: 0x060011EB RID: 4587 RVA: 0x0000C026 File Offset: 0x0000A226
		public string GetSpecialAbilityInfo()
		{
			return this.string_2;
		}

		// Token: 0x060011EC RID: 4588 RVA: 0x0000C02E File Offset: 0x0000A22E
		public string GetBigPictureSWF()
		{
			return this.string_3;
		}

		// Token: 0x060011ED RID: 4589 RVA: 0x0000C036 File Offset: 0x0000A236
		public string GetCustomDefenderIcon()
		{
			return this.string_4;
		}

		// Token: 0x060011EE RID: 4590 RVA: 0x0000C03E File Offset: 0x0000A23E
		public string GetAuraTID()
		{
			return this.string_5;
		}

		// Token: 0x060011EF RID: 4591 RVA: 0x0000C046 File Offset: 0x0000A246
		public LogicSpellData GetAuraSpell(int upgLevel)
		{
			return this.logicSpellData_1[upgLevel];
		}

		// Token: 0x060011F0 RID: 4592 RVA: 0x0000C050 File Offset: 0x0000A250
		public int GetAuraSpellLevel(int upgLevel)
		{
			return this.int_44[upgLevel];
		}

		// Token: 0x060011F1 RID: 4593 RVA: 0x0000C05A File Offset: 0x0000A25A
		public LogicSpellData GetRetributionSpell(int upgLevel)
		{
			return this.logicSpellData_2[upgLevel];
		}

		// Token: 0x060011F2 RID: 4594 RVA: 0x0000C064 File Offset: 0x0000A264
		public int GetRetributionSpellLevel(int upgLevel)
		{
			return this.int_45[upgLevel];
		}

		// Token: 0x060011F3 RID: 4595 RVA: 0x0000C06E File Offset: 0x0000A26E
		public int GetRetributionSpellTriggerHealth(int upgLevel)
		{
			return this.int_46[upgLevel];
		}

		// Token: 0x060011F4 RID: 4596 RVA: 0x0000C078 File Offset: 0x0000A278
		public string GetAuraDescTID()
		{
			return this.string_6;
		}

		// Token: 0x060011F5 RID: 4597 RVA: 0x0000C080 File Offset: 0x0000A280
		public string GetAuraBigPictureExportName()
		{
			return this.string_7;
		}

		// Token: 0x060011F6 RID: 4598 RVA: 0x0000C088 File Offset: 0x0000A288
		public bool IsFlying()
		{
			return this.bool_2;
		}

		// Token: 0x060011F7 RID: 4599 RVA: 0x0000C090 File Offset: 0x0000A290
		public bool IsJumper()
		{
			return this.bool_3;
		}

		// Token: 0x060011F8 RID: 4600 RVA: 0x0000C098 File Offset: 0x0000A298
		public bool IsBalloonGoblin()
		{
			return this.bool_8;
		}

		// Token: 0x060011F9 RID: 4601 RVA: 0x0000C0A0 File Offset: 0x0000A2A0
		public bool IsUnlockedForBarrackLevel(int barrackLevel)
		{
			return this.int_15 != -1 && this.int_15 <= barrackLevel;
		}

		// Token: 0x060011FA RID: 4602 RVA: 0x0000C0B9 File Offset: 0x0000A2B9
		public int GetDonateXP()
		{
			return base.GetHousingSpace();
		}

		// Token: 0x060011FB RID: 4603 RVA: 0x0000C0C1 File Offset: 0x0000A2C1
		public int GetStrengthWeight(int upgLevel)
		{
			return this.m_strengthWeight[upgLevel];
		}

		// Token: 0x060011FC RID: 4604 RVA: 0x0000C0CB File Offset: 0x0000A2CB
		public int GetSecondaryTroopCount(int upgLevel)
		{
			return this.int_37[upgLevel];
		}

		// Token: 0x060011FD RID: 4605 RVA: 0x0000C0D5 File Offset: 0x0000A2D5
		public int GetAttackCount(int upgLevel)
		{
			return this.int_40[upgLevel];
		}

		// Token: 0x060011FE RID: 4606 RVA: 0x00002465 File Offset: 0x00000665
		public override LogicCombatItemType GetCombatItemType()
		{
			return LogicCombatItemType.CHARACTER;
		}

		// Token: 0x0400080A RID: 2058
		public const int SPECIAL_ABILITY_TYPE_START_RAGE = 0;

		// Token: 0x0400080B RID: 2059
		public const int SPECIAL_ABILITY_TYPE_BIG_FIRST_HIT = 1;

		// Token: 0x0400080C RID: 2060
		public const int SPECIAL_ABILITY_TYPE_START_CLOAK = 2;

		// Token: 0x0400080D RID: 2061
		public const int SPECIAL_ABILITY_TYPE_SPEED_BOOST = 3;

		// Token: 0x0400080E RID: 2062
		public const int SPECIAL_ABILITY_TYPE_DIE_DAMAGE = 4;

		// Token: 0x0400080F RID: 2063
		public const int SPECIAL_ABILITY_TYPE_SPAWN_UNITS = 5;

		// Token: 0x04000810 RID: 2064
		public const int SPECIAL_ABILITY_TYPE_SPECIAL_PROJECTILE = 6;

		// Token: 0x04000811 RID: 2065
		public const int SPECIAL_ABILITY_TYPE_RAGE_ALONE = 7;

		// Token: 0x04000812 RID: 2066
		public const int SPECIAL_ABILITY_TYPE_RESPAWN_AS_CANNON = 8;

		// Token: 0x04000813 RID: 2067
		private LogicCharacterData logicCharacterData_0;

		// Token: 0x04000814 RID: 2068
		private LogicCharacterData logicCharacterData_1;

		// Token: 0x04000815 RID: 2069
		private LogicSpellData logicSpellData_0;

		// Token: 0x04000816 RID: 2070
		private LogicObstacleData logicObstacleData_0;

		// Token: 0x04000817 RID: 2071
		private LogicEffectData logicEffectData_0;

		// Token: 0x04000818 RID: 2072
		private LogicEffectData[] logicEffectData_1;

		// Token: 0x04000819 RID: 2073
		private LogicEffectData[] logicEffectData_2;

		// Token: 0x0400081A RID: 2074
		private LogicEffectData[] logicEffectData_3;

		// Token: 0x0400081B RID: 2075
		private LogicEffectData[] logicEffectData_4;

		// Token: 0x0400081C RID: 2076
		private LogicEffectData[] logicEffectData_5;

		// Token: 0x0400081D RID: 2077
		private LogicEffectData[] logicEffectData_6;

		// Token: 0x0400081E RID: 2078
		private LogicSpellData[] logicSpellData_1;

		// Token: 0x0400081F RID: 2079
		private LogicSpellData[] logicSpellData_2;

		// Token: 0x04000820 RID: 2080
		private bool bool_2;

		// Token: 0x04000821 RID: 2081
		private bool bool_3;

		// Token: 0x04000822 RID: 2082
		private bool bool_4;

		// Token: 0x04000823 RID: 2083
		private bool bool_5;

		// Token: 0x04000824 RID: 2084
		private bool bool_6;

		// Token: 0x04000825 RID: 2085
		private bool bool_7;

		// Token: 0x04000826 RID: 2086
		private bool bool_8;

		// Token: 0x04000827 RID: 2087
		private bool bool_9;

		// Token: 0x04000828 RID: 2088
		private bool bool_10;

		// Token: 0x04000829 RID: 2089
		private bool bool_11;

		// Token: 0x0400082A RID: 2090
		private bool bool_12;

		// Token: 0x0400082B RID: 2091
		private bool bool_13;

		// Token: 0x0400082C RID: 2092
		private bool bool_14;

		// Token: 0x0400082D RID: 2093
		private bool bool_15;

		// Token: 0x0400082E RID: 2094
		private int int_9;

		// Token: 0x0400082F RID: 2095
		private int int_10;

		// Token: 0x04000830 RID: 2096
		private int int_11;

		// Token: 0x04000831 RID: 2097
		private int int_12;

		// Token: 0x04000832 RID: 2098
		private int int_13;

		// Token: 0x04000833 RID: 2099
		private int int_14;

		// Token: 0x04000834 RID: 2100
		private int int_15;

		// Token: 0x04000835 RID: 2101
		private int int_16;

		// Token: 0x04000836 RID: 2102
		private int int_17;

		// Token: 0x04000837 RID: 2103
		private int int_18;

		// Token: 0x04000838 RID: 2104
		private int int_19;

		// Token: 0x04000839 RID: 2105
		private int int_20;

		// Token: 0x0400083A RID: 2106
		private int int_21;

		// Token: 0x0400083B RID: 2107
		private int int_22;

		// Token: 0x0400083C RID: 2108
		private int int_23;

		// Token: 0x0400083D RID: 2109
		private int int_24;

		// Token: 0x0400083E RID: 2110
		private int int_25;

		// Token: 0x0400083F RID: 2111
		private int int_26;

		// Token: 0x04000840 RID: 2112
		private int int_27;

		// Token: 0x04000841 RID: 2113
		private int int_28;

		// Token: 0x04000842 RID: 2114
		private int int_29;

		// Token: 0x04000843 RID: 2115
		private int int_30;

		// Token: 0x04000844 RID: 2116
		private int int_31;

		// Token: 0x04000845 RID: 2117
		private int int_32;

		// Token: 0x04000846 RID: 2118
		private int int_33;

		// Token: 0x04000847 RID: 2119
		private int int_34;

		// Token: 0x04000848 RID: 2120
		private int int_35;

		// Token: 0x04000849 RID: 2121
		private int int_36;

		// Token: 0x0400084A RID: 2122
		protected int[] m_hitpoints;

		// Token: 0x0400084B RID: 2123
		protected int[] m_unitsInCamp;

		// Token: 0x0400084C RID: 2124
		protected int[] m_strengthWeight;

		// Token: 0x0400084D RID: 2125
		protected int[] m_specialAbilityLevel;

		// Token: 0x0400084E RID: 2126
		protected int[] m_specialAbilityAttribute;

		// Token: 0x0400084F RID: 2127
		protected int[] m_specialAbilityAttribute2;

		// Token: 0x04000850 RID: 2128
		protected int[] m_specialAbilityAttribute3;

		// Token: 0x04000851 RID: 2129
		private int[] int_37;

		// Token: 0x04000852 RID: 2130
		private int[] int_38;

		// Token: 0x04000853 RID: 2131
		private int[] int_39;

		// Token: 0x04000854 RID: 2132
		private int[] int_40;

		// Token: 0x04000855 RID: 2133
		private int[] int_41;

		// Token: 0x04000856 RID: 2134
		private int[] int_42;

		// Token: 0x04000857 RID: 2135
		private int[] int_43;

		// Token: 0x04000858 RID: 2136
		private int[] int_44;

		// Token: 0x04000859 RID: 2137
		private int[] int_45;

		// Token: 0x0400085A RID: 2138
		private int[] int_46;

		// Token: 0x0400085B RID: 2139
		private string string_0;

		// Token: 0x0400085C RID: 2140
		private string string_1;

		// Token: 0x0400085D RID: 2141
		private string string_2;

		// Token: 0x0400085E RID: 2142
		private string string_3;

		// Token: 0x0400085F RID: 2143
		private string string_4;

		// Token: 0x04000860 RID: 2144
		private string string_5;

		// Token: 0x04000861 RID: 2145
		private string string_6;

		// Token: 0x04000862 RID: 2146
		private string string_7;

		// Token: 0x04000863 RID: 2147
		protected LogicAttackerItemData[] m_attackerItemData;
	}
}
