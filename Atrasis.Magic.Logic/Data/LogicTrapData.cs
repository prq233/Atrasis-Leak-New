using System;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.CSV;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000167 RID: 359
	public class LogicTrapData : LogicGameObjectData
	{
		// Token: 0x0600154E RID: 5454 RVA: 0x0000B4F2 File Offset: 0x000096F2
		public LogicTrapData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x0600154F RID: 5455 RVA: 0x000531B4 File Offset: 0x000513B4
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.int_24 = base.GetIntegerValue("Width", 0);
			this.int_25 = base.GetIntegerValue("Height", 0);
			this.int_0 = this.m_row.GetBiggestArraySize();
			this.int_17 = new int[this.int_0];
			this.int_18 = new int[this.int_0];
			this.int_16 = new int[this.int_0];
			this.int_19 = new int[this.int_0];
			this.int_20 = new int[this.int_0];
			this.int_21 = new int[this.int_0];
			this.int_22 = new int[this.int_0];
			this.int_23 = new int[this.int_0];
			this.int_15 = new int[this.int_0];
			this.logicProjectileData_0 = new LogicProjectileData[this.int_0];
			for (int i = 0; i < this.int_0; i++)
			{
				this.int_17[i] = base.GetClampedIntegerValue("BuildCost", i);
				this.int_18[i] = base.GetClampedIntegerValue("RearmCost", i);
				this.int_16[i] = LogicMath.Max(base.GetClampedIntegerValue("TownHallLevel", i) - 1, 0);
				this.int_19[i] = base.GetClampedIntegerValue("StrengthWeight", i);
				this.int_20[i] = LogicGamePlayUtil.DPSToSingleHit(base.GetClampedIntegerValue("Damage", i), 1000);
				this.int_21[i] = (base.GetClampedIntegerValue("DamageRadius", i) << 9) / 100;
				this.int_22[i] = base.GetIntegerValue("EjectHousingLimit", i);
				this.int_23[i] = base.GetClampedIntegerValue("NumSpawns", i);
				this.int_15[i] = 86400 * base.GetClampedIntegerValue("BuildTimeD", i) + 3600 * base.GetClampedIntegerValue("BuildTimeH", i) + 60 * base.GetClampedIntegerValue("BuildTimeM", i) + base.GetClampedIntegerValue("BuildTimeS", i);
				this.logicProjectileData_0[i] = LogicDataTables.GetProjectileByName(base.GetValue("Projectile", i), this);
			}
			this.logicCharacterData_0 = LogicDataTables.GetCharacterByName(base.GetValue("PreferredTarget", 0), this);
			this.int_1 = base.GetIntegerValue("PreferredTargetDamageMod", 0);
			if (this.int_1 == 0)
			{
				this.int_1 = 100;
			}
			this.logicResourceData_0 = LogicDataTables.GetResourceByName(base.GetValue("BuildResource", 0), this);
			if (this.logicResourceData_0 == null)
			{
				Debugger.Error("build resource is not defined for trap: " + base.GetName());
			}
			this.bool_2 = base.GetBooleanValue("EjectVictims", 0);
			this.int_8 = 1000 * base.GetIntegerValue("ActionFrame", 0) / 24;
			this.int_9 = base.GetIntegerValue("Pushback", 0);
			this.bool_3 = base.GetBooleanValue("DoNotScalePushByDamage", 0);
			this.logicEffectData_0 = LogicDataTables.GetEffectByName(base.GetValue("Effect", 0), this);
			this.logicEffectData_1 = LogicDataTables.GetEffectByName(base.GetValue("Effect2", 0), this);
			this.logicEffectData_2 = LogicDataTables.GetEffectByName(base.GetValue("EffectBroken", 0), this);
			this.logicEffectData_3 = LogicDataTables.GetEffectByName(base.GetValue("DamageEffect", 0), this);
			this.logicEffectData_4 = LogicDataTables.GetEffectByName(base.GetValue("PickUpEffect", 0), this);
			this.logicEffectData_5 = LogicDataTables.GetEffectByName(base.GetValue("PlacingEffect", 0), this);
			this.logicEffectData_6 = LogicDataTables.GetEffectByName(base.GetValue("AppearEffect", 0), this);
			this.logicEffectData_7 = LogicDataTables.GetEffectByName(base.GetValue("ToggleAttackModeEffect", 0), this);
			this.int_6 = (base.GetIntegerValue("TriggerRadius", 0) << 9) / 100;
			this.int_7 = base.GetIntegerValue("DirectionCount", 0);
			this.logicSpellData_0 = LogicDataTables.GetSpellByName(base.GetValue("Spell", 0), this);
			this.bool_4 = base.GetBooleanValue("AirTrigger", 0);
			this.bool_5 = base.GetBooleanValue("GroundTrigger", 0);
			this.bool_6 = base.GetBooleanValue("HealerTrigger", 0);
			this.int_10 = base.GetIntegerValue("SpeedMod", 0);
			this.int_11 = base.GetIntegerValue("DamageMod", 0);
			this.int_12 = base.GetIntegerValue("DurationMS", 0);
			this.int_13 = base.GetIntegerValue("HitDelayMS", 0);
			this.int_14 = base.GetIntegerValue("HitCnt", 0);
			this.int_2 = base.GetIntegerValue("MinTriggerHousingLimit", 0);
			this.logicCharacterData_1 = LogicDataTables.GetCharacterByName(base.GetValue("SpawnedCharGround", 0), this);
			this.logicCharacterData_2 = LogicDataTables.GetCharacterByName(base.GetValue("SpawnedCharAir", 0), this);
			this.int_3 = base.GetIntegerValue("TimeBetweenSpawnsMs", 0);
			this.int_4 = base.GetIntegerValue("SpawnInitialDelayMs", 0);
			this.int_5 = base.GetIntegerValue("ThrowDistance", 0);
			this.bool_1 = base.GetBooleanValue("HasAltMode", 0);
			this.bool_0 = base.GetBooleanValue("EnabledByCalendar", 0);
			if (this.bool_0 && this.int_0 > 1)
			{
				Debugger.Error("Temporary traps should not have upgrade levels!");
			}
		}

		// Token: 0x06001550 RID: 5456 RVA: 0x0000DEB1 File Offset: 0x0000C0B1
		public int GetWidth()
		{
			return this.int_24;
		}

		// Token: 0x06001551 RID: 5457 RVA: 0x0000DEB9 File Offset: 0x0000C0B9
		public int GetHeight()
		{
			return this.int_25;
		}

		// Token: 0x06001552 RID: 5458 RVA: 0x0000DEC1 File Offset: 0x0000C0C1
		public int GetUpgradeLevelCount()
		{
			return this.int_0;
		}

		// Token: 0x06001553 RID: 5459 RVA: 0x0000DEC9 File Offset: 0x0000C0C9
		public int GetSpawnInitialDelayMS()
		{
			return this.int_4;
		}

		// Token: 0x06001554 RID: 5460 RVA: 0x0000DED1 File Offset: 0x0000C0D1
		public int GetNumSpawns(int upgLevel)
		{
			return this.int_23[upgLevel];
		}

		// Token: 0x06001555 RID: 5461 RVA: 0x0000DEDB File Offset: 0x0000C0DB
		public int GetBuildTime(int upgLevel)
		{
			return this.int_15[upgLevel];
		}

		// Token: 0x06001556 RID: 5462 RVA: 0x0000DEE5 File Offset: 0x0000C0E5
		public LogicResourceData GetBuildResource()
		{
			return this.logicResourceData_0;
		}

		// Token: 0x06001557 RID: 5463 RVA: 0x0000DEED File Offset: 0x0000C0ED
		public int GetBuildCost(int upgLevel)
		{
			return this.int_17[upgLevel];
		}

		// Token: 0x06001558 RID: 5464 RVA: 0x0000DEF7 File Offset: 0x0000C0F7
		public int GetRequiredTownHallLevel(int upgLevel)
		{
			return this.int_16[upgLevel];
		}

		// Token: 0x06001559 RID: 5465 RVA: 0x0000DF01 File Offset: 0x0000C101
		public LogicCharacterData GetSpawnedCharAir()
		{
			return this.logicCharacterData_2;
		}

		// Token: 0x0600155A RID: 5466 RVA: 0x0000DF09 File Offset: 0x0000C109
		public LogicCharacterData GetSpawnedCharGround()
		{
			return this.logicCharacterData_1;
		}

		// Token: 0x0600155B RID: 5467 RVA: 0x0000DF11 File Offset: 0x0000C111
		public bool HasAlternativeMode()
		{
			return this.bool_1;
		}

		// Token: 0x0600155C RID: 5468 RVA: 0x0000DF19 File Offset: 0x0000C119
		public int GetThrowDistance()
		{
			return this.int_5;
		}

		// Token: 0x0600155D RID: 5469 RVA: 0x0000DF21 File Offset: 0x0000C121
		public int GetDirectionCount()
		{
			return this.int_7;
		}

		// Token: 0x0600155E RID: 5470 RVA: 0x0000DF29 File Offset: 0x0000C129
		public int GetDamage(int idx)
		{
			return this.int_20[idx];
		}

		// Token: 0x0600155F RID: 5471 RVA: 0x0000DF33 File Offset: 0x0000C133
		public int GetDamageRadius(int idx)
		{
			return this.int_21[idx];
		}

		// Token: 0x06001560 RID: 5472 RVA: 0x0000DF3D File Offset: 0x0000C13D
		public override bool IsEnableByCalendar()
		{
			return this.bool_0;
		}

		// Token: 0x06001561 RID: 5473 RVA: 0x0000DF45 File Offset: 0x0000C145
		public int GetRearmCost(int idx)
		{
			return this.int_18[idx];
		}

		// Token: 0x06001562 RID: 5474 RVA: 0x0000DF4F File Offset: 0x0000C14F
		public int GetStrengthWeight(int idx)
		{
			return this.int_19[idx];
		}

		// Token: 0x06001563 RID: 5475 RVA: 0x0000DF59 File Offset: 0x0000C159
		public int GetEjectHousingLimit(int idx)
		{
			return this.int_22[idx];
		}

		// Token: 0x06001564 RID: 5476 RVA: 0x0000DF63 File Offset: 0x0000C163
		public int GetPushback()
		{
			return this.int_9;
		}

		// Token: 0x06001565 RID: 5477 RVA: 0x000536E4 File Offset: 0x000518E4
		public int GetMaxUpgradeLevelForTownHallLevel(int townHallLevel)
		{
			int i = this.int_0;
			while (i > 0)
			{
				if (this.GetRequiredTownHallLevel(--i) <= townHallLevel)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06001566 RID: 5478 RVA: 0x0000DF6B File Offset: 0x0000C16B
		public bool GetEjectVictims()
		{
			return this.bool_2;
		}

		// Token: 0x06001567 RID: 5479 RVA: 0x0000DF73 File Offset: 0x0000C173
		public bool GetDoNotScalePushByDamage()
		{
			return this.bool_3;
		}

		// Token: 0x06001568 RID: 5480 RVA: 0x0000DF7B File Offset: 0x0000C17B
		public bool GetAirTrigger()
		{
			return this.bool_4;
		}

		// Token: 0x06001569 RID: 5481 RVA: 0x0000DF83 File Offset: 0x0000C183
		public bool GetGroundTrigger()
		{
			return this.bool_5;
		}

		// Token: 0x0600156A RID: 5482 RVA: 0x0000DF8B File Offset: 0x0000C18B
		public bool GetHealerTrigger()
		{
			return this.bool_6;
		}

		// Token: 0x0600156B RID: 5483 RVA: 0x0000DF93 File Offset: 0x0000C193
		public int GetMinTriggerHousingLimit()
		{
			return this.int_2;
		}

		// Token: 0x0600156C RID: 5484 RVA: 0x0000DF9B File Offset: 0x0000C19B
		public int GetTimeBetweenSpawnsMS()
		{
			return this.int_3;
		}

		// Token: 0x0600156D RID: 5485 RVA: 0x0000DFA3 File Offset: 0x0000C1A3
		public int GetTriggerRadius()
		{
			return this.int_6;
		}

		// Token: 0x0600156E RID: 5486 RVA: 0x0000DFAB File Offset: 0x0000C1AB
		public int GetActionFrame()
		{
			return this.int_8;
		}

		// Token: 0x0600156F RID: 5487 RVA: 0x0000DFB3 File Offset: 0x0000C1B3
		public int GetSpeedMod()
		{
			return this.int_10;
		}

		// Token: 0x06001570 RID: 5488 RVA: 0x0000DFBB File Offset: 0x0000C1BB
		public int GetDamageMod()
		{
			return this.int_11;
		}

		// Token: 0x06001571 RID: 5489 RVA: 0x0000DFC3 File Offset: 0x0000C1C3
		public int GetDurationMS()
		{
			return this.int_12;
		}

		// Token: 0x06001572 RID: 5490 RVA: 0x0000DFCB File Offset: 0x0000C1CB
		public int GetHitDelayMS()
		{
			return this.int_13;
		}

		// Token: 0x06001573 RID: 5491 RVA: 0x0000DFD3 File Offset: 0x0000C1D3
		public int GetHitCount()
		{
			return this.int_14;
		}

		// Token: 0x06001574 RID: 5492 RVA: 0x0000DFDB File Offset: 0x0000C1DB
		public LogicSpellData GetSpell()
		{
			return this.logicSpellData_0;
		}

		// Token: 0x06001575 RID: 5493 RVA: 0x0000DFE3 File Offset: 0x0000C1E3
		public LogicProjectileData GetProjectile(int idx)
		{
			return this.logicProjectileData_0[idx];
		}

		// Token: 0x06001576 RID: 5494 RVA: 0x0000DFED File Offset: 0x0000C1ED
		public LogicEffectData GetEffect()
		{
			return this.logicEffectData_0;
		}

		// Token: 0x06001577 RID: 5495 RVA: 0x0000DFF5 File Offset: 0x0000C1F5
		public LogicEffectData GetEffect2()
		{
			return this.logicEffectData_1;
		}

		// Token: 0x06001578 RID: 5496 RVA: 0x0000DFFD File Offset: 0x0000C1FD
		public LogicEffectData GetEffectBroken()
		{
			return this.logicEffectData_2;
		}

		// Token: 0x06001579 RID: 5497 RVA: 0x0000E005 File Offset: 0x0000C205
		public LogicEffectData GetDamageEffect()
		{
			return this.logicEffectData_3;
		}

		// Token: 0x0600157A RID: 5498 RVA: 0x0000E00D File Offset: 0x0000C20D
		public LogicEffectData GetPickUpEffect()
		{
			return this.logicEffectData_4;
		}

		// Token: 0x0600157B RID: 5499 RVA: 0x0000E015 File Offset: 0x0000C215
		public LogicEffectData GetPlacingEffect()
		{
			return this.logicEffectData_5;
		}

		// Token: 0x0600157C RID: 5500 RVA: 0x0000E01D File Offset: 0x0000C21D
		public LogicEffectData GetAppearEffect()
		{
			return this.logicEffectData_6;
		}

		// Token: 0x0600157D RID: 5501 RVA: 0x0000E025 File Offset: 0x0000C225
		public LogicEffectData GetToggleAttackModeEffect()
		{
			return this.logicEffectData_7;
		}

		// Token: 0x0600157E RID: 5502 RVA: 0x0000E02D File Offset: 0x0000C22D
		public LogicCharacterData GetPreferredTarget()
		{
			return this.logicCharacterData_0;
		}

		// Token: 0x0600157F RID: 5503 RVA: 0x0000E035 File Offset: 0x0000C235
		public int GetPreferredTargetDamageMod()
		{
			return this.int_1;
		}

		// Token: 0x04000B86 RID: 2950
		private bool bool_0;

		// Token: 0x04000B87 RID: 2951
		private bool bool_1;

		// Token: 0x04000B88 RID: 2952
		private bool bool_2;

		// Token: 0x04000B89 RID: 2953
		private bool bool_3;

		// Token: 0x04000B8A RID: 2954
		private bool bool_4;

		// Token: 0x04000B8B RID: 2955
		private bool bool_5;

		// Token: 0x04000B8C RID: 2956
		private bool bool_6;

		// Token: 0x04000B8D RID: 2957
		private int int_0;

		// Token: 0x04000B8E RID: 2958
		private int int_1;

		// Token: 0x04000B8F RID: 2959
		private int int_2;

		// Token: 0x04000B90 RID: 2960
		private int int_3;

		// Token: 0x04000B91 RID: 2961
		private int int_4;

		// Token: 0x04000B92 RID: 2962
		private int int_5;

		// Token: 0x04000B93 RID: 2963
		private int int_6;

		// Token: 0x04000B94 RID: 2964
		private int int_7;

		// Token: 0x04000B95 RID: 2965
		private int int_8;

		// Token: 0x04000B96 RID: 2966
		private int int_9;

		// Token: 0x04000B97 RID: 2967
		private int int_10;

		// Token: 0x04000B98 RID: 2968
		private int int_11;

		// Token: 0x04000B99 RID: 2969
		private int int_12;

		// Token: 0x04000B9A RID: 2970
		private int int_13;

		// Token: 0x04000B9B RID: 2971
		private int int_14;

		// Token: 0x04000B9C RID: 2972
		private int[] int_15;

		// Token: 0x04000B9D RID: 2973
		private int[] int_16;

		// Token: 0x04000B9E RID: 2974
		private int[] int_17;

		// Token: 0x04000B9F RID: 2975
		private int[] int_18;

		// Token: 0x04000BA0 RID: 2976
		private int[] int_19;

		// Token: 0x04000BA1 RID: 2977
		private int[] int_20;

		// Token: 0x04000BA2 RID: 2978
		private int[] int_21;

		// Token: 0x04000BA3 RID: 2979
		private int[] int_22;

		// Token: 0x04000BA4 RID: 2980
		private int[] int_23;

		// Token: 0x04000BA5 RID: 2981
		private int int_24;

		// Token: 0x04000BA6 RID: 2982
		private int int_25;

		// Token: 0x04000BA7 RID: 2983
		private LogicProjectileData[] logicProjectileData_0;

		// Token: 0x04000BA8 RID: 2984
		private LogicSpellData logicSpellData_0;

		// Token: 0x04000BA9 RID: 2985
		private LogicEffectData logicEffectData_0;

		// Token: 0x04000BAA RID: 2986
		private LogicEffectData logicEffectData_1;

		// Token: 0x04000BAB RID: 2987
		private LogicEffectData logicEffectData_2;

		// Token: 0x04000BAC RID: 2988
		private LogicEffectData logicEffectData_3;

		// Token: 0x04000BAD RID: 2989
		private LogicEffectData logicEffectData_4;

		// Token: 0x04000BAE RID: 2990
		private LogicEffectData logicEffectData_5;

		// Token: 0x04000BAF RID: 2991
		private LogicEffectData logicEffectData_6;

		// Token: 0x04000BB0 RID: 2992
		private LogicEffectData logicEffectData_7;

		// Token: 0x04000BB1 RID: 2993
		private LogicCharacterData logicCharacterData_0;

		// Token: 0x04000BB2 RID: 2994
		private LogicCharacterData logicCharacterData_1;

		// Token: 0x04000BB3 RID: 2995
		private LogicCharacterData logicCharacterData_2;

		// Token: 0x04000BB4 RID: 2996
		private LogicResourceData logicResourceData_0;
	}
}
