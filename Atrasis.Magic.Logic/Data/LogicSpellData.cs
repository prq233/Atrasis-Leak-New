using System;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.CSV;
using Atrasis.Magic.Titan.Debug;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000165 RID: 357
	public class LogicSpellData : LogicCombatItemData
	{
		// Token: 0x060014EE RID: 5358 RVA: 0x0000BD99 File Offset: 0x00009F99
		public LogicSpellData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x060014EF RID: 5359 RVA: 0x000524C8 File Offset: 0x000506C8
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.int_9 = new int[this.m_upgradeLevelCount];
			this.int_10 = new int[this.m_upgradeLevelCount];
			this.int_11 = new int[this.m_upgradeLevelCount];
			this.int_13 = new int[this.m_upgradeLevelCount];
			this.int_14 = new int[this.m_upgradeLevelCount];
			this.int_16 = new int[this.m_upgradeLevelCount];
			this.int_17 = new int[this.m_upgradeLevelCount];
			this.int_18 = new int[this.m_upgradeLevelCount];
			this.int_19 = new int[this.m_upgradeLevelCount];
			this.int_15 = new int[this.m_upgradeLevelCount];
			this.int_20 = new int[this.m_upgradeLevelCount];
			this.int_24 = new int[this.m_upgradeLevelCount];
			this.int_27 = new int[this.m_upgradeLevelCount];
			this.int_39 = new int[this.m_upgradeLevelCount];
			this.int_28 = new int[this.m_upgradeLevelCount];
			this.int_29 = new int[this.m_upgradeLevelCount];
			this.int_21 = new int[this.m_upgradeLevelCount];
			this.int_22 = new int[this.m_upgradeLevelCount];
			this.int_23 = new int[this.m_upgradeLevelCount];
			this.int_26 = new int[this.m_upgradeLevelCount];
			this.int_30 = new int[this.m_upgradeLevelCount];
			this.int_31 = new int[this.m_upgradeLevelCount];
			this.int_32 = new int[this.m_upgradeLevelCount];
			this.int_33 = new int[this.m_upgradeLevelCount];
			this.int_34 = new int[this.m_upgradeLevelCount];
			this.int_35 = new int[this.m_upgradeLevelCount];
			this.int_12 = new int[this.m_upgradeLevelCount];
			this.int_36 = new int[this.m_upgradeLevelCount];
			this.int_37 = new int[this.m_upgradeLevelCount];
			this.int_38 = new int[this.m_upgradeLevelCount];
			this.int_25 = new int[this.m_upgradeLevelCount];
			this.int_40 = new int[this.m_upgradeLevelCount];
			this.logicEffectData_0 = new LogicEffectData[this.m_upgradeLevelCount];
			this.logicEffectData_1 = new LogicEffectData[this.m_upgradeLevelCount];
			this.logicEffectData_2 = new LogicEffectData[this.m_upgradeLevelCount];
			this.logicEffectData_3 = new LogicEffectData[this.m_upgradeLevelCount];
			this.logicEffectData_4 = new LogicEffectData[this.m_upgradeLevelCount];
			this.logicEffectData_5 = new LogicEffectData[this.m_upgradeLevelCount];
			for (int i = 0; i < this.m_upgradeLevelCount; i++)
			{
				this.int_9[i] = LogicGamePlayUtil.DPSToSingleHit(base.GetClampedIntegerValue("Damage", i), 1000);
				this.int_10[i] = base.GetClampedIntegerValue("TroopDamagePermil", i);
				this.int_11[i] = base.GetClampedIntegerValue("BuildingDamagePermil", i);
				this.int_13[i] = base.GetClampedIntegerValue("ExecuteHealthPermil", i);
				this.int_14[i] = base.GetClampedIntegerValue("DamagePermilMin", i);
				this.int_16[i] = base.GetClampedIntegerValue("PreferredDamagePermilMin", i);
				this.int_17[i] = base.GetClampedIntegerValue("BoostTimeMS", i);
				this.int_18[i] = base.GetClampedIntegerValue("SpeedBoost", i);
				this.int_19[i] = base.GetClampedIntegerValue("SpeedBoost2", i);
				this.int_15[i] = base.GetClampedIntegerValue("DamageBoostPercent", i);
				this.int_20[i] = base.GetClampedIntegerValue("DuplicateLifetime", i);
				this.int_24[i] = base.GetClampedIntegerValue("DuplicateHousing", i);
				this.int_27[i] = (base.GetClampedIntegerValue("Radius", i) << 9) / 100;
				this.int_39[i] = base.GetClampedIntegerValue("NumberOfHits", i);
				this.int_28[i] = (base.GetClampedIntegerValue("RandomRadius", i) << 9) / 100;
				this.int_29[i] = base.GetClampedIntegerValue("TimeBetweenHitsMS", i);
				this.int_21[i] = base.GetClampedIntegerValue("JumpBoostMS", i);
				this.int_22[i] = base.GetClampedIntegerValue("JumpHousingLimit", i);
				this.logicEffectData_5[i] = LogicDataTables.GetEffectByName(base.GetClampedValue("HitEffect", i), this);
				this.logicEffectData_4[i] = LogicDataTables.GetEffectByName(base.GetClampedValue("ChargingEffect", i), this);
				this.logicEffectData_0[i] = LogicDataTables.GetEffectByName(base.GetClampedValue("PreDeployEffect", i), this);
				this.logicEffectData_1[i] = LogicDataTables.GetEffectByName(base.GetClampedValue("DeployEffect", i), this);
				this.logicEffectData_3[i] = LogicDataTables.GetEffectByName(base.GetClampedValue("EnemyDeployEffect", i), this);
				this.logicEffectData_2[i] = LogicDataTables.GetEffectByName(base.GetClampedValue("DeployEffect2", i), this);
				this.int_23[i] = base.GetClampedIntegerValue("FreezeTimeMS", i);
				this.int_26[i] = base.GetClampedIntegerValue("StrengthWeight", i);
				this.int_30[i] = base.GetClampedIntegerValue("BuildingDamageBoostPercent", i);
				this.int_31[i] = base.GetClampedIntegerValue("ShieldProjectileSpeed", i);
				this.int_32[i] = base.GetClampedIntegerValue("ShieldProjectileDamageMod", i);
				this.int_33[i] = base.GetClampedIntegerValue("ExtraHealthPermil", i);
				this.int_34[i] = base.GetClampedIntegerValue("ExtraHealthMin", i);
				this.int_35[i] = base.GetClampedIntegerValue("ExtraHealthMax", i);
				this.int_12[i] = LogicGamePlayUtil.DPSToSingleHit(base.GetClampedIntegerValue("PoisonDPS", i), 1000);
				this.int_36[i] = base.GetClampedIntegerValue("AttackSpeedBoost", i);
				this.int_37[i] = base.GetClampedIntegerValue("InvulnerabilityTime", i);
				this.int_38[i] = base.GetClampedIntegerValue("MaxUnitsHit", i);
				this.int_25[i] = base.GetClampedIntegerValue("UnitsToSpawn", i);
				this.int_40[i] = base.GetClampedIntegerValue("SpawnDuration", i);
			}
			this.bool_3 = base.GetBooleanValue("PoisonIncreaseSlowly", 0);
			this.bool_4 = base.GetBooleanValue("PoisonAffectAir", 0);
			this.int_41 = base.GetIntegerValue("SpawnFirstGroupSize", 0);
			this.bool_5 = base.GetBooleanValue("ScaleByTH", 0);
			this.int_42 = base.GetIntegerValue("PauseCombatComponentsMs", 0);
			this.int_43 = base.GetIntegerValue("DamageTHPercent", 0);
			if (this.int_43 <= 0)
			{
				this.int_43 = 100;
			}
			this.int_44 = base.GetIntegerValue("ShrinkReduceSpeedRatio", 0);
			this.int_45 = base.GetIntegerValue("ShrinkHitpointsRatio", 0);
			this.int_46 = base.GetIntegerValue("DeployEffect2Delay", 0);
			this.int_47 = base.GetIntegerValue("HitTimeMS", 0);
			this.int_48 = base.GetIntegerValue("DeployTimeMS", 0);
			this.int_49 = base.GetIntegerValue("ChargingTimeMS", 0);
			this.int_50 = base.GetIntegerValue("SpellForgeLevel", 0) - 1;
			this.bool_2 = base.GetBooleanValue("RandomRadiusAffectsOnlyGfx", 0);
			this.logicObstacleData_0 = LogicDataTables.GetObstacleByName(base.GetValue("SpawnObstacle", 0), this);
			this.int_51 = base.GetIntegerValue("NumObstacles", 0);
			this.bool_6 = base.GetBooleanValue("TroopsOnly", 0);
			this.string_0 = base.GetValue("TargetInfoString", 0);
			string value = base.GetValue("PreferredTarget", 0);
			if (value.Length != 0)
			{
				this.logicData_0 = LogicDataTables.GetBuildingClassByName(value, null);
				if (this.logicData_0 == null)
				{
					this.logicData_0 = LogicDataTables.GetBuildingByName(value, null);
					if (this.logicData_0 == null)
					{
						this.logicData_0 = LogicDataTables.GetCharacterByName(value, null);
						if (this.logicData_0 == null)
						{
							Debugger.Warning(string.Format("CSV row ({0}) has an invalid reference ({1})", base.GetName(), value));
						}
					}
				}
			}
			this.int_52 = base.GetIntegerValue("PreferredTargetDamageMod", 0);
			if (this.int_52 == 0)
			{
				this.int_52 = 100;
			}
			this.int_53 = base.GetIntegerValue("HeroDamageMultiplier", 0);
			if (this.int_53 == 0)
			{
				this.int_53 = 100;
			}
			this.bool_7 = base.GetBooleanValue("SnapToGrid", 0);
			this.bool_8 = base.GetBooleanValue("BoostDefenders", 0);
			this.bool_9 = base.GetBooleanValue("BoostLinkedToPoison", 0);
			this.bool_10 = base.GetBooleanValue("ScaleDeployEffects", 0);
			this.logicCharacterData_0 = LogicDataTables.GetCharacterByName(base.GetValue("SummonTroop", 0), null);
		}

		// Token: 0x060014F0 RID: 5360 RVA: 0x0000DA93 File Offset: 0x0000BC93
		public override int GetRequiredProductionHouseLevel()
		{
			return this.int_50;
		}

		// Token: 0x060014F1 RID: 5361 RVA: 0x0000DA9B File Offset: 0x0000BC9B
		public override bool IsUnlockedForProductionHouseLevel(int level)
		{
			return level >= this.int_50;
		}

		// Token: 0x060014F2 RID: 5362 RVA: 0x0000DAA9 File Offset: 0x0000BCA9
		public override LogicBuildingData GetProductionHouseData()
		{
			return LogicDataTables.GetBuildingByName((base.GetUnitOfType() == 1) ? "Spell Forge" : "Mini Spell Factory", null);
		}

		// Token: 0x060014F3 RID: 5363 RVA: 0x0000DAC6 File Offset: 0x0000BCC6
		public bool IsDamageSpell()
		{
			return this.int_9[0] > 0 || this.int_11[0] > 0 || this.int_10[0] > 0 || this.int_12[0] > 0;
		}

		// Token: 0x060014F4 RID: 5364 RVA: 0x0000DAF6 File Offset: 0x0000BCF6
		public bool IsBuildingDamageSpell()
		{
			return this.int_9[0] > 0 || this.int_11[0] > 0;
		}

		// Token: 0x060014F5 RID: 5365 RVA: 0x0000DB10 File Offset: 0x0000BD10
		public bool GetRandomRadiusAffectsOnlyGfx()
		{
			return this.bool_2;
		}

		// Token: 0x060014F6 RID: 5366 RVA: 0x0000DB18 File Offset: 0x0000BD18
		public bool GetPoisonIncreaseSlowly()
		{
			return this.bool_3;
		}

		// Token: 0x060014F7 RID: 5367 RVA: 0x0000DB20 File Offset: 0x0000BD20
		public bool GetPoisonAffectAir()
		{
			return this.bool_4;
		}

		// Token: 0x060014F8 RID: 5368 RVA: 0x0000DB28 File Offset: 0x0000BD28
		public bool IsScaleByTownHall()
		{
			return this.bool_5;
		}

		// Token: 0x060014F9 RID: 5369 RVA: 0x0000DB30 File Offset: 0x0000BD30
		public bool GetTroopsOnly()
		{
			return this.bool_6;
		}

		// Token: 0x060014FA RID: 5370 RVA: 0x0000DB38 File Offset: 0x0000BD38
		public bool GetSnapToGrid()
		{
			return this.bool_7;
		}

		// Token: 0x060014FB RID: 5371 RVA: 0x0000DB40 File Offset: 0x0000BD40
		public bool GetBoostDefenders()
		{
			return this.bool_8;
		}

		// Token: 0x060014FC RID: 5372 RVA: 0x0000DB48 File Offset: 0x0000BD48
		public bool GetBoostLinkedToPoison()
		{
			return this.bool_9;
		}

		// Token: 0x060014FD RID: 5373 RVA: 0x0000DB50 File Offset: 0x0000BD50
		public bool GetScaleDeployEffects()
		{
			return this.bool_10;
		}

		// Token: 0x060014FE RID: 5374 RVA: 0x0000DB58 File Offset: 0x0000BD58
		public int GetDamage(int upgLevel)
		{
			return this.int_9[upgLevel];
		}

		// Token: 0x060014FF RID: 5375 RVA: 0x0000DB62 File Offset: 0x0000BD62
		public int GetSpawnFirstGroupSize()
		{
			return this.int_41;
		}

		// Token: 0x06001500 RID: 5376 RVA: 0x0000DB6A File Offset: 0x0000BD6A
		public int GetPauseCombatComponentMs()
		{
			return this.int_42;
		}

		// Token: 0x06001501 RID: 5377 RVA: 0x0000DB72 File Offset: 0x0000BD72
		public int GetDamageTHPercent()
		{
			return this.int_43;
		}

		// Token: 0x06001502 RID: 5378 RVA: 0x0000DB7A File Offset: 0x0000BD7A
		public int GetShrinkReduceSpeedRatio()
		{
			return this.int_44;
		}

		// Token: 0x06001503 RID: 5379 RVA: 0x0000DB82 File Offset: 0x0000BD82
		public int GetShrinkHitpointsRatio()
		{
			return this.int_45;
		}

		// Token: 0x06001504 RID: 5380 RVA: 0x0000DB8A File Offset: 0x0000BD8A
		public int GetDeployEffect2Delay()
		{
			return this.int_46;
		}

		// Token: 0x06001505 RID: 5381 RVA: 0x0000DB92 File Offset: 0x0000BD92
		public int GetHitTimeMS()
		{
			return this.int_47;
		}

		// Token: 0x06001506 RID: 5382 RVA: 0x0000DB9A File Offset: 0x0000BD9A
		public int GetDeployTimeMS()
		{
			return this.int_48;
		}

		// Token: 0x06001507 RID: 5383 RVA: 0x0000DBA2 File Offset: 0x0000BDA2
		public int GetChargingTimeMS()
		{
			return this.int_49;
		}

		// Token: 0x06001508 RID: 5384 RVA: 0x0000DA93 File Offset: 0x0000BC93
		public int GetSpellForgeLevel()
		{
			return this.int_50;
		}

		// Token: 0x06001509 RID: 5385 RVA: 0x0000DBAA File Offset: 0x0000BDAA
		public int GetNumObstacles()
		{
			return this.int_51;
		}

		// Token: 0x0600150A RID: 5386 RVA: 0x0000DBB2 File Offset: 0x0000BDB2
		public int GetPreferredTargetDamageMod()
		{
			return this.int_52;
		}

		// Token: 0x0600150B RID: 5387 RVA: 0x0000DBBA File Offset: 0x0000BDBA
		public int GetHeroDamageMultiplier()
		{
			return this.int_53;
		}

		// Token: 0x0600150C RID: 5388 RVA: 0x0000DBC2 File Offset: 0x0000BDC2
		public string GetTargetInfoString()
		{
			return this.string_0;
		}

		// Token: 0x0600150D RID: 5389 RVA: 0x0000DBCA File Offset: 0x0000BDCA
		public int GetBuildingDamagePermil(int upgLevel)
		{
			return this.int_11[upgLevel];
		}

		// Token: 0x0600150E RID: 5390 RVA: 0x0000DBD4 File Offset: 0x0000BDD4
		public int GetTroopDamagePermil(int upgLevel)
		{
			return this.int_10[upgLevel];
		}

		// Token: 0x0600150F RID: 5391 RVA: 0x0000DBDE File Offset: 0x0000BDDE
		public int GetExecuteHealthPermil(int upgLevel)
		{
			return this.int_13[upgLevel];
		}

		// Token: 0x06001510 RID: 5392 RVA: 0x0000DBE8 File Offset: 0x0000BDE8
		public int GetDamagePermilMin(int upgLevel)
		{
			return this.int_14[upgLevel];
		}

		// Token: 0x06001511 RID: 5393 RVA: 0x0000DBF2 File Offset: 0x0000BDF2
		public int GetPreferredDamagePermilMin(int upgLevel)
		{
			return this.int_16[upgLevel];
		}

		// Token: 0x06001512 RID: 5394 RVA: 0x0000DBFC File Offset: 0x0000BDFC
		public int GetPoisonDamage(int upgLevel)
		{
			return this.int_12[upgLevel];
		}

		// Token: 0x06001513 RID: 5395 RVA: 0x0000DC06 File Offset: 0x0000BE06
		public int GetDamageBoostPercent(int upgLevel)
		{
			return this.int_15[upgLevel];
		}

		// Token: 0x06001514 RID: 5396 RVA: 0x0000DC10 File Offset: 0x0000BE10
		public int GetBuildingDamageBoostPercent(int upgLevel)
		{
			return this.int_30[upgLevel];
		}

		// Token: 0x06001515 RID: 5397 RVA: 0x0000DC1A File Offset: 0x0000BE1A
		public int GetSpeedBoost(int upgLevel)
		{
			return this.int_18[upgLevel];
		}

		// Token: 0x06001516 RID: 5398 RVA: 0x0000DC24 File Offset: 0x0000BE24
		public int GetSpeedBoost2(int upgLevel)
		{
			return this.int_19[upgLevel];
		}

		// Token: 0x06001517 RID: 5399 RVA: 0x0000DC2E File Offset: 0x0000BE2E
		public int GetJumpBoostMS(int upgLevel)
		{
			return this.int_21[upgLevel];
		}

		// Token: 0x06001518 RID: 5400 RVA: 0x0000DC38 File Offset: 0x0000BE38
		public int GetJumpHousingLimit(int upgLevel)
		{
			return this.int_22[upgLevel];
		}

		// Token: 0x06001519 RID: 5401 RVA: 0x0000DC42 File Offset: 0x0000BE42
		public int GetFreezeTimeMS(int upgLevel)
		{
			return this.int_23[upgLevel];
		}

		// Token: 0x0600151A RID: 5402 RVA: 0x0000DC4C File Offset: 0x0000BE4C
		public int GetDuplicateHousing(int upgLevel)
		{
			return this.int_24[upgLevel];
		}

		// Token: 0x0600151B RID: 5403 RVA: 0x0000DC56 File Offset: 0x0000BE56
		public int GetDuplicateLifetime(int upgLevel)
		{
			return this.int_20[upgLevel];
		}

		// Token: 0x0600151C RID: 5404 RVA: 0x0000DC60 File Offset: 0x0000BE60
		public int GetUnitsToSpawn(int upgLevel)
		{
			return this.int_25[upgLevel];
		}

		// Token: 0x0600151D RID: 5405 RVA: 0x0000DC6A File Offset: 0x0000BE6A
		public int GetSpawnDuration(int upgLevel)
		{
			return this.int_40[upgLevel];
		}

		// Token: 0x0600151E RID: 5406 RVA: 0x0000DC74 File Offset: 0x0000BE74
		public int GetStrengthWeight(int upgLevel)
		{
			return this.int_26[upgLevel];
		}

		// Token: 0x0600151F RID: 5407 RVA: 0x0000DC7E File Offset: 0x0000BE7E
		public int GetRandomRadius(int upgLevel)
		{
			return this.int_28[upgLevel];
		}

		// Token: 0x06001520 RID: 5408 RVA: 0x0000DC88 File Offset: 0x0000BE88
		public int GetRadius(int upgLevel)
		{
			return this.int_27[upgLevel];
		}

		// Token: 0x06001521 RID: 5409 RVA: 0x0000DC92 File Offset: 0x0000BE92
		public int GetTimeBetweenHitsMS(int upgLevel)
		{
			return this.int_29[upgLevel];
		}

		// Token: 0x06001522 RID: 5410 RVA: 0x0000DC9C File Offset: 0x0000BE9C
		public int GetMaxUnitsHit(int upgLevel)
		{
			return this.int_38[upgLevel];
		}

		// Token: 0x06001523 RID: 5411 RVA: 0x0000DCA6 File Offset: 0x0000BEA6
		public int GetNumberOfHits(int upgLevel)
		{
			return this.int_39[upgLevel];
		}

		// Token: 0x06001524 RID: 5412 RVA: 0x0000DCB0 File Offset: 0x0000BEB0
		public int GetExtraHealthPermil(int upgLevel)
		{
			return this.int_33[upgLevel];
		}

		// Token: 0x06001525 RID: 5413 RVA: 0x0000DCBA File Offset: 0x0000BEBA
		public int GetExtraHealthMin(int upgLevel)
		{
			return this.int_34[upgLevel];
		}

		// Token: 0x06001526 RID: 5414 RVA: 0x0000DCC4 File Offset: 0x0000BEC4
		public int GetExtraHealthMax(int upgLevel)
		{
			return this.int_35[upgLevel];
		}

		// Token: 0x06001527 RID: 5415 RVA: 0x0000DCCE File Offset: 0x0000BECE
		public int GetInvulnerabilityTime(int upgLevel)
		{
			return this.int_37[upgLevel];
		}

		// Token: 0x06001528 RID: 5416 RVA: 0x0000DCD8 File Offset: 0x0000BED8
		public int GetShieldProjectileSpeed(int upgLevel)
		{
			return this.int_31[upgLevel];
		}

		// Token: 0x06001529 RID: 5417 RVA: 0x0000DCE2 File Offset: 0x0000BEE2
		public int GetShieldProjectileDamageMod(int upgLevel)
		{
			return this.int_32[upgLevel];
		}

		// Token: 0x0600152A RID: 5418 RVA: 0x0000DCEC File Offset: 0x0000BEEC
		public int GetAttackSpeedBoost(int upgLevel)
		{
			return this.int_36[upgLevel];
		}

		// Token: 0x0600152B RID: 5419 RVA: 0x0000DCF6 File Offset: 0x0000BEF6
		public int GetBoostTimeMS(int upgLevel)
		{
			return this.int_17[upgLevel];
		}

		// Token: 0x0600152C RID: 5420 RVA: 0x0000DD00 File Offset: 0x0000BF00
		public LogicObstacleData GetSpawnObstacle()
		{
			return this.logicObstacleData_0;
		}

		// Token: 0x0600152D RID: 5421 RVA: 0x0000DD08 File Offset: 0x0000BF08
		public LogicEffectData GetPreDeployEffect(int upgLevel)
		{
			return this.logicEffectData_0[upgLevel];
		}

		// Token: 0x0600152E RID: 5422 RVA: 0x0000DD12 File Offset: 0x0000BF12
		public LogicEffectData GetDeployEffect(int upgLevel)
		{
			return this.logicEffectData_1[upgLevel];
		}

		// Token: 0x0600152F RID: 5423 RVA: 0x0000DD1C File Offset: 0x0000BF1C
		public LogicEffectData GetEnemyDeployEffect(int upgLevel)
		{
			return this.logicEffectData_3[upgLevel];
		}

		// Token: 0x06001530 RID: 5424 RVA: 0x0000DD26 File Offset: 0x0000BF26
		public LogicEffectData GetDeployEffect2(int upgLevel)
		{
			return this.logicEffectData_2[upgLevel];
		}

		// Token: 0x06001531 RID: 5425 RVA: 0x0000DD30 File Offset: 0x0000BF30
		public LogicEffectData GetChargingEffect(int upgLevel)
		{
			return this.logicEffectData_4[upgLevel];
		}

		// Token: 0x06001532 RID: 5426 RVA: 0x0000DD3A File Offset: 0x0000BF3A
		public LogicEffectData GetHitEffect(int upgLevel)
		{
			return this.logicEffectData_5[upgLevel];
		}

		// Token: 0x06001533 RID: 5427 RVA: 0x0000DD44 File Offset: 0x0000BF44
		public LogicData GetPreferredTarget()
		{
			return this.logicData_0;
		}

		// Token: 0x06001534 RID: 5428 RVA: 0x0000DD4C File Offset: 0x0000BF4C
		public LogicCharacterData GetSummonTroop()
		{
			return this.logicCharacterData_0;
		}

		// Token: 0x06001535 RID: 5429 RVA: 0x00002B36 File Offset: 0x00000D36
		public override LogicCombatItemType GetCombatItemType()
		{
			return LogicCombatItemType.SPELL;
		}

		// Token: 0x04000B2A RID: 2858
		private int[] int_9;

		// Token: 0x04000B2B RID: 2859
		private int[] int_10;

		// Token: 0x04000B2C RID: 2860
		private int[] int_11;

		// Token: 0x04000B2D RID: 2861
		private int[] int_12;

		// Token: 0x04000B2E RID: 2862
		private int[] int_13;

		// Token: 0x04000B2F RID: 2863
		private int[] int_14;

		// Token: 0x04000B30 RID: 2864
		private int[] int_15;

		// Token: 0x04000B31 RID: 2865
		private int[] int_16;

		// Token: 0x04000B32 RID: 2866
		private int[] int_17;

		// Token: 0x04000B33 RID: 2867
		private int[] int_18;

		// Token: 0x04000B34 RID: 2868
		private int[] int_19;

		// Token: 0x04000B35 RID: 2869
		private int[] int_20;

		// Token: 0x04000B36 RID: 2870
		private int[] int_21;

		// Token: 0x04000B37 RID: 2871
		private int[] int_22;

		// Token: 0x04000B38 RID: 2872
		private int[] int_23;

		// Token: 0x04000B39 RID: 2873
		private int[] int_24;

		// Token: 0x04000B3A RID: 2874
		private int[] int_25;

		// Token: 0x04000B3B RID: 2875
		private int[] int_26;

		// Token: 0x04000B3C RID: 2876
		private int[] int_27;

		// Token: 0x04000B3D RID: 2877
		private int[] int_28;

		// Token: 0x04000B3E RID: 2878
		private int[] int_29;

		// Token: 0x04000B3F RID: 2879
		private int[] int_30;

		// Token: 0x04000B40 RID: 2880
		private int[] int_31;

		// Token: 0x04000B41 RID: 2881
		private int[] int_32;

		// Token: 0x04000B42 RID: 2882
		private int[] int_33;

		// Token: 0x04000B43 RID: 2883
		private int[] int_34;

		// Token: 0x04000B44 RID: 2884
		private int[] int_35;

		// Token: 0x04000B45 RID: 2885
		private int[] int_36;

		// Token: 0x04000B46 RID: 2886
		private int[] int_37;

		// Token: 0x04000B47 RID: 2887
		private int[] int_38;

		// Token: 0x04000B48 RID: 2888
		private int[] int_39;

		// Token: 0x04000B49 RID: 2889
		private int[] int_40;

		// Token: 0x04000B4A RID: 2890
		private bool bool_2;

		// Token: 0x04000B4B RID: 2891
		private bool bool_3;

		// Token: 0x04000B4C RID: 2892
		private bool bool_4;

		// Token: 0x04000B4D RID: 2893
		private bool bool_5;

		// Token: 0x04000B4E RID: 2894
		private bool bool_6;

		// Token: 0x04000B4F RID: 2895
		private bool bool_7;

		// Token: 0x04000B50 RID: 2896
		private bool bool_8;

		// Token: 0x04000B51 RID: 2897
		private bool bool_9;

		// Token: 0x04000B52 RID: 2898
		private bool bool_10;

		// Token: 0x04000B53 RID: 2899
		private int int_41;

		// Token: 0x04000B54 RID: 2900
		private int int_42;

		// Token: 0x04000B55 RID: 2901
		private int int_43;

		// Token: 0x04000B56 RID: 2902
		private int int_44;

		// Token: 0x04000B57 RID: 2903
		private int int_45;

		// Token: 0x04000B58 RID: 2904
		private int int_46;

		// Token: 0x04000B59 RID: 2905
		private int int_47;

		// Token: 0x04000B5A RID: 2906
		private int int_48;

		// Token: 0x04000B5B RID: 2907
		private int int_49;

		// Token: 0x04000B5C RID: 2908
		private int int_50;

		// Token: 0x04000B5D RID: 2909
		private int int_51;

		// Token: 0x04000B5E RID: 2910
		private int int_52;

		// Token: 0x04000B5F RID: 2911
		private int int_53;

		// Token: 0x04000B60 RID: 2912
		private string string_0;

		// Token: 0x04000B61 RID: 2913
		private LogicObstacleData logicObstacleData_0;

		// Token: 0x04000B62 RID: 2914
		private LogicData logicData_0;

		// Token: 0x04000B63 RID: 2915
		private LogicCharacterData logicCharacterData_0;

		// Token: 0x04000B64 RID: 2916
		private LogicEffectData[] logicEffectData_0;

		// Token: 0x04000B65 RID: 2917
		private LogicEffectData[] logicEffectData_1;

		// Token: 0x04000B66 RID: 2918
		private LogicEffectData[] logicEffectData_2;

		// Token: 0x04000B67 RID: 2919
		private LogicEffectData[] logicEffectData_3;

		// Token: 0x04000B68 RID: 2920
		private LogicEffectData[] logicEffectData_4;

		// Token: 0x04000B69 RID: 2921
		private LogicEffectData[] logicEffectData_5;
	}
}
