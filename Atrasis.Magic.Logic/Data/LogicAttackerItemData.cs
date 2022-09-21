using System;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.CSV;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x0200013C RID: 316
	public class LogicAttackerItemData
	{
		// Token: 0x060010C4 RID: 4292 RVA: 0x0004AC80 File Offset: 0x00048E80
		public void CreateReferences(CSVRow row, LogicData data, int idx)
		{
			this.csvrow_0 = row;
			this.logicData_0 = data;
			this.int_0 = idx;
			this.int_1 = row.GetClampedIntegerValue("PushBack", idx);
			this.bool_0 = row.GetClampedBooleanValue("AirTargets", idx);
			this.bool_1 = row.GetClampedBooleanValue("GroundTargets", idx);
			this.bool_2 = row.GetClampedBooleanValue("AltAttackMode", idx);
			this.int_2 = 100 * row.GetClampedIntegerValue("Damage", idx);
			int clampedIntegerValue = row.GetClampedIntegerValue("DPS", idx);
			int clampedIntegerValue2 = row.GetClampedIntegerValue("AttackSpeed", idx);
			int num = row.GetClampedIntegerValue("AltDPS", idx);
			int num2 = row.GetClampedIntegerValue("AltAttackSpeed", idx);
			if (this.bool_2 && num2 == 0)
			{
				num2 = clampedIntegerValue2;
			}
			int num3 = row.GetClampedIntegerValue("CoolDownOverride", idx);
			if (num3 == 0)
			{
				int num4 = (int)((long)((clampedIntegerValue | this.int_2) >> 31) & 4294965996L) + 1500;
				if (clampedIntegerValue2 > num4)
				{
					num3 = clampedIntegerValue2 - num4;
				}
			}
			this.int_6 = row.GetClampedIntegerValue("PrepareSpeed", idx);
			this.int_3 = clampedIntegerValue2 - num3;
			this.int_4 = num2 - num3;
			this.int_5 = num3;
			this.int_7 = 100 * row.GetClampedIntegerValue("DamageMulti", idx);
			this.int_8 = 100 * row.GetClampedIntegerValue("DamageLv2", idx);
			this.int_9 = 100 * row.GetClampedIntegerValue("DamageLv3", idx);
			this.int_10 = this.int_2;
			if (clampedIntegerValue != 0)
			{
				if (num == 0)
				{
					num = clampedIntegerValue;
				}
				this.int_2 = LogicGamePlayUtil.DPSToSingleHit(clampedIntegerValue, this.int_3 + this.int_5);
				this.int_10 = LogicGamePlayUtil.DPSToSingleHit(num, this.int_4 + this.int_5);
				this.int_7 = LogicGamePlayUtil.DPSToSingleHit(row.GetClampedIntegerValue("DPSMulti", idx), this.int_3 + this.int_5);
				this.int_8 = LogicGamePlayUtil.DPSToSingleHit(row.GetClampedIntegerValue("DPSLv2", idx), this.int_3 + this.int_5);
				this.int_9 = LogicGamePlayUtil.DPSToSingleHit(row.GetClampedIntegerValue("DPSLv3", idx), this.int_3 + this.int_5);
			}
			this.logicEffectData_0 = LogicDataTables.GetEffectByName(row.GetClampedValue("HitEffect", idx), data);
			this.logicEffectData_1 = LogicDataTables.GetEffectByName(row.GetClampedValue("HitEffect2", idx), data);
			this.logicEffectData_2 = LogicDataTables.GetEffectByName(row.GetClampedValue("HitEffectActive", idx), data);
			this.int_11 = (row.GetClampedIntegerValue("AttackRange", idx) << 9) / 100;
			this.int_12 = (row.GetClampedIntegerValue("DamageRadius", idx) << 9) / 100;
			this.logicEffectData_3 = LogicDataTables.GetEffectByName(row.GetClampedValue("AttackEffect", idx), data);
			this.logicEffectData_5 = LogicDataTables.GetEffectByName(row.GetClampedValue("AttackEffectAlt", idx), data);
			this.int_13 = row.GetClampedIntegerValue("AmmoCount", idx);
			this.logicEffectData_4 = LogicDataTables.GetEffectByName(row.GetClampedValue("AttackEffect2", idx), data);
			this.logicEffectData_6 = LogicDataTables.GetEffectByName(row.GetClampedValue("AttackEffectLv2", idx), data);
			this.logicEffectData_7 = LogicDataTables.GetEffectByName(row.GetClampedValue("AttackEffectLv3", idx), data);
			this.logicEffectData_8 = LogicDataTables.GetEffectByName(row.GetClampedValue("TransitionEffectLv2", idx), data);
			this.logicEffectData_9 = LogicDataTables.GetEffectByName(row.GetClampedValue("TransitionEffectLv3", idx), data);
			this.int_14 = row.GetClampedIntegerValue("AltNumMultiTargets", idx);
			this.int_15 = row.GetClampedIntegerValue("Lv2SwitchTime", idx);
			this.int_16 = row.GetClampedIntegerValue("Lv3SwitchTime", idx);
			this.int_17 = row.GetClampedIntegerValue("StatusEffectTime", idx);
			this.int_18 = row.GetClampedIntegerValue("SpeedMod", idx);
			this.int_19 = (row.GetClampedIntegerValue("AltAttackRange", idx) << 9) / 100;
			this.logicProjectileData_0 = LogicDataTables.GetProjectileByName(row.GetClampedValue("Projectile", idx), data);
			this.logicProjectileData_1 = LogicDataTables.GetProjectileByName(row.GetClampedValue("AltProjectile", idx), data);
			this.int_20 = row.GetClampedIntegerValue("ShockwavePushStrength", idx);
			this.logicSpellData_0 = LogicDataTables.GetSpellByName(row.GetClampedValue("HitSpell", idx), data);
			this.int_21 = row.GetClampedIntegerValue("HitSpellLevel", idx);
			this.int_22 = 100 * row.GetClampedIntegerValue("Damage2", idx);
			this.int_23 = (row.GetClampedIntegerValue("Damage2Radius", idx) << 9) / 100;
			this.int_24 = row.GetClampedIntegerValue("Damage2Delay", idx);
			this.int_25 = 100 * row.GetClampedIntegerValue("Damage2Min", idx);
			this.int_26 = (row.GetClampedIntegerValue("Damage2FalloffStart", idx) << 9) / 100;
			this.int_27 = (row.GetClampedIntegerValue("Damage2FalloffStart", idx) << 9) / 100;
			if (this.int_27 < this.int_26)
			{
				Debugger.Error("Building " + row.GetName() + " has falloff end less than falloff start!");
			}
			if (this.int_27 > this.int_23)
			{
				Debugger.Error("Building " + row.GetName() + " has falloff end greater than the damage radius!");
			}
			this.logicEffectData_10 = LogicDataTables.GetEffectByName(row.GetClampedValue("PreAttackEffect", idx), data);
			this.logicEffectData_11 = LogicDataTables.GetEffectByName(row.GetClampedValue("BecomesTargetableEffect", idx), data);
			this.bool_4 = row.GetClampedBooleanValue("IncreasingDamage", idx);
			this.bool_5 = row.GetClampedBooleanValue("PreventsHealing", idx);
			this.int_28 = row.GetClampedIntegerValue("AlternatePickNewTargetDelay", idx);
			this.int_29 = row.GetClampedIntegerValue("ShockwaveArcLength", idx);
			this.int_30 = row.GetClampedIntegerValue("ShockwaveExpandRadius", idx);
			this.int_31 = row.GetClampedIntegerValue("TargetingConeAngle", idx);
			this.bool_6 = row.GetClampedBooleanValue("PenetratingProjectile", idx);
			this.int_32 = (row.GetClampedIntegerValue("PenetratingRadius", idx) << 9) / 100;
			this.int_33 = (row.GetClampedIntegerValue("PenetratingExtraRange", idx) << 9) / 100;
			this.bool_7 = row.GetClampedBooleanValue("TargetGroups", idx);
			this.bool_8 = row.GetClampedBooleanValue("FightWithGroups", idx);
			this.int_34 = (row.GetClampedIntegerValue("TargetGroupsRadius", idx) << 9) / 100;
			this.int_35 = (row.GetClampedIntegerValue("TargetGroupsRange", idx) << 9) / 100;
			this.int_36 = row.GetClampedIntegerValue("TargetGroupsMinWeight", idx);
			this.int_37 = row.GetClampedIntegerValue("WakeUpSpace", idx);
			this.int_38 = row.GetClampedIntegerValue("WakeUpSpeed", idx);
			this.logicData_1 = LogicDataTables.GetCharacterByName(row.GetClampedValue("PreferredTarget", idx), data);
			this.int_39 = row.GetClampedIntegerValue("PreferredTargetDamageMod", idx);
			this.bool_9 = row.GetClampedBooleanValue("PreferredTargetNoTargeting", idx);
			this.bool_10 = row.GetClampedBooleanValue("AltAirTargets", idx);
			this.bool_11 = row.GetClampedBooleanValue("AltGroundTargets", idx);
			this.bool_12 = row.GetClampedBooleanValue("AltMultiTargets", idx);
			this.int_40 = (row.GetClampedIntegerValue("MinAttackRange", idx) << 9) / 100;
			if (this.logicData_1 == null)
			{
				this.logicData_1 = LogicDataTables.GetBuildingClassByName(row.GetClampedValue("PreferedTargetBuildingClass", idx), data);
				if (this.logicData_1 == null)
				{
					this.logicData_1 = LogicDataTables.GetBuildingByName(row.GetClampedValue("PreferedTargetBuilding", idx), data);
				}
				this.int_39 = row.GetClampedIntegerValue("PreferedTargetDamageMod", idx);
				if (this.int_39 == 0)
				{
					this.int_39 = 100;
				}
			}
			this.int_41 = row.GetClampedIntegerValue("SummonTroopCount", idx);
			this.int_42 = row.GetClampedIntegerValue("SummonCooldown", idx);
			this.logicEffectData_13 = LogicDataTables.GetEffectByName(row.GetClampedValue("SummonEffect", idx), data);
			this.int_43 = row.GetClampedIntegerValue("SummonLimit", idx);
			this.logicCharacterData_0 = LogicDataTables.GetCharacterByName(row.GetClampedValue("SummonTroop", idx), data);
			this.bool_13 = row.GetClampedBooleanValue("SpawnOnAttack", idx);
			this.logicEffectData_12 = LogicDataTables.GetEffectByName(row.GetClampedValue("HideEffect", idx), data);
			this.logicProjectileData_2 = LogicDataTables.GetProjectileByName(row.GetClampedValue("RageProjectile", idx), data);
			this.int_44 = row.GetClampedIntegerValue("ProjectileBounces", idx);
			this.bool_3 = row.GetClampedBooleanValue("SelfAsAoeCenter", idx);
			if (this.int_24 > this.int_5 + this.int_3)
			{
				Debugger.Error(row.GetName() + " has Damage2Delay greater than the attack speed!");
			}
			if (this.int_13 > 0 && (this.int_3 & 63) != 0)
			{
				Debugger.Error(string.Format("Invalid attack speed {0} (must be multiple of 64)", this.int_3));
			}
			this.int_45 = row.GetClampedIntegerValue("BurstCount", idx);
			this.int_46 = row.GetClampedIntegerValue("BurstDelay", idx);
			this.int_47 = row.GetClampedIntegerValue("AltBurstCount", idx);
			this.int_48 = row.GetClampedIntegerValue("AltBurstDelay", idx);
			this.int_49 = row.GetClampedIntegerValue("DummyProjectileCount", idx);
			this.logicEffectData_14 = LogicDataTables.GetEffectByName(row.GetClampedValue("AttackEffectShared", idx), data);
			this.int_50 = row.GetClampedIntegerValue("ChainAttackDistance", idx);
			this.int_51 = row.GetClampedIntegerValue("NewTargetAttackDelay", idx);
			if (this.int_51 > 0)
			{
				this.int_51 = LogicMath.Clamp(clampedIntegerValue2 - this.int_51, 0, clampedIntegerValue2);
			}
		}

		// Token: 0x060010C5 RID: 4293 RVA: 0x0000B523 File Offset: 0x00009723
		public int GetDamage(int type, bool multi)
		{
			if (multi)
			{
				return this.int_7;
			}
			Debugger.DoAssert(type < 3, string.Empty);
			if (type == 1)
			{
				return this.int_8;
			}
			if (type != 2)
			{
				return this.int_2;
			}
			return this.int_9;
		}

		// Token: 0x060010C6 RID: 4294 RVA: 0x0000B55A File Offset: 0x0000975A
		public int GetAltDamage(int level, bool alt)
		{
			Debugger.DoAssert(level < 3, string.Empty);
			if (alt)
			{
				return this.int_7;
			}
			return this.int_10;
		}

		// Token: 0x060010C7 RID: 4295 RVA: 0x0004B5B0 File Offset: 0x000497B0
		public int GetDamagePerMS(int type, bool multi)
		{
			int damage = this.GetDamage(type, multi);
			int num = this.int_3 + this.int_5;
			if (num != 0)
			{
				return 1000 * damage / (100 * num);
			}
			return 0;
		}

		// Token: 0x060010C8 RID: 4296 RVA: 0x0000B57B File Offset: 0x0000977B
		public int GetDamage2()
		{
			return this.int_22;
		}

		// Token: 0x060010C9 RID: 4297 RVA: 0x0000B583 File Offset: 0x00009783
		public int GetDamage2Delay()
		{
			return this.int_24;
		}

		// Token: 0x060010CA RID: 4298 RVA: 0x0000B58B File Offset: 0x0000978B
		public int GetAttackCooldownOverride()
		{
			return this.int_5;
		}

		// Token: 0x060010CB RID: 4299 RVA: 0x0000B593 File Offset: 0x00009793
		public int GetShockwavePushStrength()
		{
			return this.int_20;
		}

		// Token: 0x060010CC RID: 4300 RVA: 0x0000B59B File Offset: 0x0000979B
		public LogicSpellData GetHitSpell()
		{
			return this.logicSpellData_0;
		}

		// Token: 0x060010CD RID: 4301 RVA: 0x0000B5A3 File Offset: 0x000097A3
		public bool HasAlternativeAttackMode()
		{
			return this.bool_2;
		}

		// Token: 0x060010CE RID: 4302 RVA: 0x0000B5AB File Offset: 0x000097AB
		public int GetAmmoCount()
		{
			return this.int_13;
		}

		// Token: 0x060010CF RID: 4303 RVA: 0x0000B5B3 File Offset: 0x000097B3
		public int GetTargetingConeAngle()
		{
			return this.int_31;
		}

		// Token: 0x060010D0 RID: 4304 RVA: 0x0000B5BB File Offset: 0x000097BB
		public LogicData GetPreferredTargetData()
		{
			return this.logicData_1;
		}

		// Token: 0x060010D1 RID: 4305 RVA: 0x0000B5C3 File Offset: 0x000097C3
		public LogicEffectData GetHitEffect()
		{
			return this.logicEffectData_0;
		}

		// Token: 0x060010D2 RID: 4306 RVA: 0x0000B5CB File Offset: 0x000097CB
		public LogicEffectData GetHitEffect2()
		{
			return this.logicEffectData_1;
		}

		// Token: 0x060010D3 RID: 4307 RVA: 0x0000B5D3 File Offset: 0x000097D3
		public LogicEffectData GetHitEffectActive()
		{
			return this.logicEffectData_2;
		}

		// Token: 0x060010D4 RID: 4308 RVA: 0x0000B5DB File Offset: 0x000097DB
		public LogicEffectData GetAttackEffect()
		{
			return this.logicEffectData_3;
		}

		// Token: 0x060010D5 RID: 4309 RVA: 0x0000B5E3 File Offset: 0x000097E3
		public LogicEffectData GetAttackEffect2()
		{
			return this.logicEffectData_4;
		}

		// Token: 0x060010D6 RID: 4310 RVA: 0x0000B5EB File Offset: 0x000097EB
		public LogicEffectData GetAltAttackEffect()
		{
			return this.logicEffectData_5;
		}

		// Token: 0x060010D7 RID: 4311 RVA: 0x0000B5F3 File Offset: 0x000097F3
		public LogicEffectData GetAttackEffectLv2()
		{
			return this.logicEffectData_6;
		}

		// Token: 0x060010D8 RID: 4312 RVA: 0x0000B5FB File Offset: 0x000097FB
		public LogicEffectData GetAttackEffectLv3()
		{
			return this.logicEffectData_7;
		}

		// Token: 0x060010D9 RID: 4313 RVA: 0x0000B603 File Offset: 0x00009803
		public LogicEffectData GetTransitionEffectLv2()
		{
			return this.logicEffectData_8;
		}

		// Token: 0x060010DA RID: 4314 RVA: 0x0000B60B File Offset: 0x0000980B
		public LogicEffectData GetTransitionEffectLv3()
		{
			return this.logicEffectData_9;
		}

		// Token: 0x060010DB RID: 4315 RVA: 0x0000B613 File Offset: 0x00009813
		public LogicEffectData GetPreAttackEffect()
		{
			return this.logicEffectData_10;
		}

		// Token: 0x060010DC RID: 4316 RVA: 0x0000B61B File Offset: 0x0000981B
		public LogicEffectData GetBecomesTargetableEffect()
		{
			return this.logicEffectData_11;
		}

		// Token: 0x060010DD RID: 4317 RVA: 0x0000B623 File Offset: 0x00009823
		public LogicEffectData GetHideEffect()
		{
			return this.logicEffectData_12;
		}

		// Token: 0x060010DE RID: 4318 RVA: 0x0000B62B File Offset: 0x0000982B
		public LogicEffectData GetSummonEffect()
		{
			return this.logicEffectData_13;
		}

		// Token: 0x060010DF RID: 4319 RVA: 0x0000B633 File Offset: 0x00009833
		public LogicEffectData GetAttackEffectShared()
		{
			return this.logicEffectData_14;
		}

		// Token: 0x060010E0 RID: 4320 RVA: 0x0000B63B File Offset: 0x0000983B
		public LogicProjectileData GetProjectile(bool alt)
		{
			if (alt)
			{
				return this.logicProjectileData_1;
			}
			return this.logicProjectileData_0;
		}

		// Token: 0x060010E1 RID: 4321 RVA: 0x0000B64D File Offset: 0x0000984D
		public LogicCharacterData GetSummonTroop()
		{
			return this.logicCharacterData_0;
		}

		// Token: 0x060010E2 RID: 4322 RVA: 0x0000B655 File Offset: 0x00009855
		public LogicProjectileData GetRageProjectile()
		{
			return this.logicProjectileData_2;
		}

		// Token: 0x060010E3 RID: 4323 RVA: 0x0000B65D File Offset: 0x0000985D
		public int GetPushBack()
		{
			return this.int_1;
		}

		// Token: 0x060010E4 RID: 4324 RVA: 0x0000B665 File Offset: 0x00009865
		public int GetAttackSpeed()
		{
			return this.int_3;
		}

		// Token: 0x060010E5 RID: 4325 RVA: 0x0000B66D File Offset: 0x0000986D
		public int GetAltAttackSpeed()
		{
			return this.int_4;
		}

		// Token: 0x060010E6 RID: 4326 RVA: 0x0000B675 File Offset: 0x00009875
		public int GetPrepareSpeed()
		{
			return this.int_6;
		}

		// Token: 0x060010E7 RID: 4327 RVA: 0x0000B67D File Offset: 0x0000987D
		public int GetAttackRange(bool alt)
		{
			if (alt)
			{
				return this.int_19;
			}
			return this.int_11;
		}

		// Token: 0x060010E8 RID: 4328 RVA: 0x0000B68F File Offset: 0x0000988F
		public int GetDamageRadius()
		{
			return this.int_12;
		}

		// Token: 0x060010E9 RID: 4329 RVA: 0x0000B697 File Offset: 0x00009897
		public int GetDamage2Radius()
		{
			return this.int_23;
		}

		// Token: 0x060010EA RID: 4330 RVA: 0x0000B69F File Offset: 0x0000989F
		public int GetAltNumMultiTargets()
		{
			return this.int_14;
		}

		// Token: 0x060010EB RID: 4331 RVA: 0x0000B6A7 File Offset: 0x000098A7
		public int GetSwitchTimeLv2()
		{
			return this.int_15;
		}

		// Token: 0x060010EC RID: 4332 RVA: 0x0000B6AF File Offset: 0x000098AF
		public int GetSwitchTimeLv3()
		{
			return this.int_16;
		}

		// Token: 0x060010ED RID: 4333 RVA: 0x0000B6B7 File Offset: 0x000098B7
		public int GetStatusEffectTime()
		{
			return this.int_17;
		}

		// Token: 0x060010EE RID: 4334 RVA: 0x0000B6BF File Offset: 0x000098BF
		public int GetSpeedMod()
		{
			return this.int_18;
		}

		// Token: 0x060010EF RID: 4335 RVA: 0x0000B6C7 File Offset: 0x000098C7
		public int GetHitSpellLevel()
		{
			return this.int_21;
		}

		// Token: 0x060010F0 RID: 4336 RVA: 0x0000B6CF File Offset: 0x000098CF
		public int GetDamage2Min()
		{
			return this.int_25;
		}

		// Token: 0x060010F1 RID: 4337 RVA: 0x0000B6D7 File Offset: 0x000098D7
		public int GetAlternatePickNewTargetDelay()
		{
			return this.int_28;
		}

		// Token: 0x060010F2 RID: 4338 RVA: 0x0000B6DF File Offset: 0x000098DF
		public int GetShockwaveArcLength()
		{
			return this.int_29;
		}

		// Token: 0x060010F3 RID: 4339 RVA: 0x0000B6E7 File Offset: 0x000098E7
		public int GetShockwaveExpandRadius()
		{
			return this.int_30;
		}

		// Token: 0x060010F4 RID: 4340 RVA: 0x0000B6EF File Offset: 0x000098EF
		public int GetPenetratingRadius()
		{
			return this.int_32;
		}

		// Token: 0x060010F5 RID: 4341 RVA: 0x0000B6F7 File Offset: 0x000098F7
		public int GetPenetratingExtraRange()
		{
			return this.int_33;
		}

		// Token: 0x060010F6 RID: 4342 RVA: 0x0000B6FF File Offset: 0x000098FF
		public int GetTargetGroupsRadius()
		{
			return this.int_34;
		}

		// Token: 0x060010F7 RID: 4343 RVA: 0x0000B707 File Offset: 0x00009907
		public int GetTargetGroupsRange()
		{
			return this.int_35;
		}

		// Token: 0x060010F8 RID: 4344 RVA: 0x0000B70F File Offset: 0x0000990F
		public int GetTargetGroupsMinWeight()
		{
			return this.int_36;
		}

		// Token: 0x060010F9 RID: 4345 RVA: 0x0000B717 File Offset: 0x00009917
		public int GetWakeUpSpace()
		{
			return this.int_37;
		}

		// Token: 0x060010FA RID: 4346 RVA: 0x0000B71F File Offset: 0x0000991F
		public int GetWakeUpSpeed()
		{
			return this.int_38;
		}

		// Token: 0x060010FB RID: 4347 RVA: 0x0000B727 File Offset: 0x00009927
		public int GetPreferredTargetDamageMod()
		{
			return this.int_39;
		}

		// Token: 0x060010FC RID: 4348 RVA: 0x0000B72F File Offset: 0x0000992F
		public int GetMinAttackRange()
		{
			return this.int_40;
		}

		// Token: 0x060010FD RID: 4349 RVA: 0x0000B737 File Offset: 0x00009937
		public int GetSummonTroopCount()
		{
			return this.int_41;
		}

		// Token: 0x060010FE RID: 4350 RVA: 0x0000B73F File Offset: 0x0000993F
		public int GetSummonCooldown()
		{
			return this.int_42;
		}

		// Token: 0x060010FF RID: 4351 RVA: 0x0000B747 File Offset: 0x00009947
		public int GetSummonLimit()
		{
			return this.int_43;
		}

		// Token: 0x06001100 RID: 4352 RVA: 0x0000B74F File Offset: 0x0000994F
		public int GetProjectileBounces()
		{
			return this.int_44;
		}

		// Token: 0x06001101 RID: 4353 RVA: 0x0000B757 File Offset: 0x00009957
		public int GetBurstCount()
		{
			return this.int_45;
		}

		// Token: 0x06001102 RID: 4354 RVA: 0x0000B75F File Offset: 0x0000995F
		public int GetBurstDelay()
		{
			return this.int_46;
		}

		// Token: 0x06001103 RID: 4355 RVA: 0x0000B767 File Offset: 0x00009967
		public int GetAltBurstCount()
		{
			return this.int_47;
		}

		// Token: 0x06001104 RID: 4356 RVA: 0x0000B76F File Offset: 0x0000996F
		public int GetAltBurstDelay()
		{
			return this.int_48;
		}

		// Token: 0x06001105 RID: 4357 RVA: 0x0000B777 File Offset: 0x00009977
		public int GetDummyProjectileCount()
		{
			return this.int_49;
		}

		// Token: 0x06001106 RID: 4358 RVA: 0x0000B77F File Offset: 0x0000997F
		public int GetChainAttackDistance()
		{
			return this.int_50;
		}

		// Token: 0x06001107 RID: 4359 RVA: 0x0000B787 File Offset: 0x00009987
		public int GetNewTargetAttackDelay()
		{
			return this.int_51;
		}

		// Token: 0x06001108 RID: 4360 RVA: 0x0000B78F File Offset: 0x0000998F
		public bool GetTrackAirTargets(bool alt)
		{
			if (alt)
			{
				return this.bool_10;
			}
			return this.bool_0;
		}

		// Token: 0x06001109 RID: 4361 RVA: 0x0000B7A1 File Offset: 0x000099A1
		public bool GetTrackGroundTargets(bool alt)
		{
			return this.bool_1;
		}

		// Token: 0x0600110A RID: 4362 RVA: 0x0000B7A9 File Offset: 0x000099A9
		public bool IsSelfAsAoeCenter()
		{
			return this.bool_3;
		}

		// Token: 0x0600110B RID: 4363 RVA: 0x0000B7B1 File Offset: 0x000099B1
		public bool IsIncreasingDamage()
		{
			return this.bool_4;
		}

		// Token: 0x0600110C RID: 4364 RVA: 0x0000B7B9 File Offset: 0x000099B9
		public bool GetPreventsHealing()
		{
			return this.bool_5;
		}

		// Token: 0x0600110D RID: 4365 RVA: 0x0000B7C1 File Offset: 0x000099C1
		public bool IsPenetratingProjectile()
		{
			return this.bool_6;
		}

		// Token: 0x0600110E RID: 4366 RVA: 0x0000B7C9 File Offset: 0x000099C9
		public bool GetTargetGroups()
		{
			return this.bool_7;
		}

		// Token: 0x0600110F RID: 4367 RVA: 0x0000B7D1 File Offset: 0x000099D1
		public bool GetFightWithGroups()
		{
			return this.bool_8;
		}

		// Token: 0x06001110 RID: 4368 RVA: 0x0000B7D9 File Offset: 0x000099D9
		public bool GetPreferredTargetNoTargeting()
		{
			return this.bool_9;
		}

		// Token: 0x06001111 RID: 4369 RVA: 0x0000B7E1 File Offset: 0x000099E1
		public bool GetSpawnOnAttack()
		{
			return this.bool_13;
		}

		// Token: 0x06001112 RID: 4370 RVA: 0x0000B7E9 File Offset: 0x000099E9
		public bool GetMultiTargets(bool alt)
		{
			return alt && this.bool_12;
		}

		// Token: 0x06001113 RID: 4371 RVA: 0x0000B7F6 File Offset: 0x000099F6
		public LogicAttackerItemData Clone()
		{
			LogicAttackerItemData logicAttackerItemData = new LogicAttackerItemData();
			logicAttackerItemData.CreateReferences(this.csvrow_0, this.logicData_0, this.int_0);
			return logicAttackerItemData;
		}

		// Token: 0x06001114 RID: 4372 RVA: 0x0000B815 File Offset: 0x00009A15
		public void AddAttackRange(int value)
		{
			this.int_11 += value;
			this.int_19 += value;
		}

		// Token: 0x04000709 RID: 1801
		private LogicData logicData_0;

		// Token: 0x0400070A RID: 1802
		private CSVRow csvrow_0;

		// Token: 0x0400070B RID: 1803
		private int int_0;

		// Token: 0x0400070C RID: 1804
		private LogicEffectData logicEffectData_0;

		// Token: 0x0400070D RID: 1805
		private LogicEffectData logicEffectData_1;

		// Token: 0x0400070E RID: 1806
		private LogicEffectData logicEffectData_2;

		// Token: 0x0400070F RID: 1807
		private LogicEffectData logicEffectData_3;

		// Token: 0x04000710 RID: 1808
		private LogicEffectData logicEffectData_4;

		// Token: 0x04000711 RID: 1809
		private LogicEffectData logicEffectData_5;

		// Token: 0x04000712 RID: 1810
		private LogicEffectData logicEffectData_6;

		// Token: 0x04000713 RID: 1811
		private LogicEffectData logicEffectData_7;

		// Token: 0x04000714 RID: 1812
		private LogicEffectData logicEffectData_8;

		// Token: 0x04000715 RID: 1813
		private LogicEffectData logicEffectData_9;

		// Token: 0x04000716 RID: 1814
		private LogicEffectData logicEffectData_10;

		// Token: 0x04000717 RID: 1815
		private LogicEffectData logicEffectData_11;

		// Token: 0x04000718 RID: 1816
		private LogicEffectData logicEffectData_12;

		// Token: 0x04000719 RID: 1817
		private LogicEffectData logicEffectData_13;

		// Token: 0x0400071A RID: 1818
		private LogicEffectData logicEffectData_14;

		// Token: 0x0400071B RID: 1819
		private LogicProjectileData logicProjectileData_0;

		// Token: 0x0400071C RID: 1820
		private LogicProjectileData logicProjectileData_1;

		// Token: 0x0400071D RID: 1821
		private LogicSpellData logicSpellData_0;

		// Token: 0x0400071E RID: 1822
		private LogicData logicData_1;

		// Token: 0x0400071F RID: 1823
		private LogicCharacterData logicCharacterData_0;

		// Token: 0x04000720 RID: 1824
		private LogicProjectileData logicProjectileData_2;

		// Token: 0x04000721 RID: 1825
		private int int_1;

		// Token: 0x04000722 RID: 1826
		private int int_2;

		// Token: 0x04000723 RID: 1827
		private int int_3;

		// Token: 0x04000724 RID: 1828
		private int int_4;

		// Token: 0x04000725 RID: 1829
		private int int_5;

		// Token: 0x04000726 RID: 1830
		private int int_6;

		// Token: 0x04000727 RID: 1831
		private int int_7;

		// Token: 0x04000728 RID: 1832
		private int int_8;

		// Token: 0x04000729 RID: 1833
		private int int_9;

		// Token: 0x0400072A RID: 1834
		private int int_10;

		// Token: 0x0400072B RID: 1835
		private int int_11;

		// Token: 0x0400072C RID: 1836
		private int int_12;

		// Token: 0x0400072D RID: 1837
		private int int_13;

		// Token: 0x0400072E RID: 1838
		private int int_14;

		// Token: 0x0400072F RID: 1839
		private int int_15;

		// Token: 0x04000730 RID: 1840
		private int int_16;

		// Token: 0x04000731 RID: 1841
		private int int_17;

		// Token: 0x04000732 RID: 1842
		private int int_18;

		// Token: 0x04000733 RID: 1843
		private int int_19;

		// Token: 0x04000734 RID: 1844
		private int int_20;

		// Token: 0x04000735 RID: 1845
		private int int_21;

		// Token: 0x04000736 RID: 1846
		private int int_22;

		// Token: 0x04000737 RID: 1847
		private int int_23;

		// Token: 0x04000738 RID: 1848
		private int int_24;

		// Token: 0x04000739 RID: 1849
		private int int_25;

		// Token: 0x0400073A RID: 1850
		private int int_26;

		// Token: 0x0400073B RID: 1851
		private int int_27;

		// Token: 0x0400073C RID: 1852
		private int int_28;

		// Token: 0x0400073D RID: 1853
		private int int_29;

		// Token: 0x0400073E RID: 1854
		private int int_30;

		// Token: 0x0400073F RID: 1855
		private int int_31;

		// Token: 0x04000740 RID: 1856
		private int int_32;

		// Token: 0x04000741 RID: 1857
		private int int_33;

		// Token: 0x04000742 RID: 1858
		private int int_34;

		// Token: 0x04000743 RID: 1859
		private int int_35;

		// Token: 0x04000744 RID: 1860
		private int int_36;

		// Token: 0x04000745 RID: 1861
		private int int_37;

		// Token: 0x04000746 RID: 1862
		private int int_38;

		// Token: 0x04000747 RID: 1863
		private int int_39;

		// Token: 0x04000748 RID: 1864
		private int int_40;

		// Token: 0x04000749 RID: 1865
		private int int_41;

		// Token: 0x0400074A RID: 1866
		private int int_42;

		// Token: 0x0400074B RID: 1867
		private int int_43;

		// Token: 0x0400074C RID: 1868
		private int int_44;

		// Token: 0x0400074D RID: 1869
		private int int_45;

		// Token: 0x0400074E RID: 1870
		private int int_46;

		// Token: 0x0400074F RID: 1871
		private int int_47;

		// Token: 0x04000750 RID: 1872
		private int int_48;

		// Token: 0x04000751 RID: 1873
		private int int_49;

		// Token: 0x04000752 RID: 1874
		private int int_50;

		// Token: 0x04000753 RID: 1875
		private int int_51;

		// Token: 0x04000754 RID: 1876
		private bool bool_0;

		// Token: 0x04000755 RID: 1877
		private bool bool_1;

		// Token: 0x04000756 RID: 1878
		private bool bool_2;

		// Token: 0x04000757 RID: 1879
		private bool bool_3;

		// Token: 0x04000758 RID: 1880
		private bool bool_4;

		// Token: 0x04000759 RID: 1881
		private bool bool_5;

		// Token: 0x0400075A RID: 1882
		private bool bool_6;

		// Token: 0x0400075B RID: 1883
		private bool bool_7;

		// Token: 0x0400075C RID: 1884
		private bool bool_8;

		// Token: 0x0400075D RID: 1885
		private bool bool_9;

		// Token: 0x0400075E RID: 1886
		private bool bool_10;

		// Token: 0x0400075F RID: 1887
		private bool bool_11;

		// Token: 0x04000760 RID: 1888
		private bool bool_12;

		// Token: 0x04000761 RID: 1889
		private bool bool_13;
	}
}
