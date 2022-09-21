using System;
using Atrasis.Magic.Titan.CSV;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000155 RID: 341
	public class LogicHeroData : LogicCharacterData
	{
		// Token: 0x060013CA RID: 5066 RVA: 0x0000D1B0 File Offset: 0x0000B3B0
		public LogicHeroData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x060013CB RID: 5067 RVA: 0x000505B4 File Offset: 0x0004E7B4
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.int_47 = (base.GetIntegerValue("MaxSearchRadiusForDefender", 0) << 9) / 100;
			int biggestArraySize = this.m_row.GetBiggestArraySize();
			this.logicSpellData_3 = new LogicSpellData[biggestArraySize];
			this.int_68 = new int[biggestArraySize];
			this.int_69 = new int[biggestArraySize];
			this.int_57 = new int[biggestArraySize];
			this.int_58 = new int[biggestArraySize];
			this.int_59 = new int[biggestArraySize];
			this.int_60 = new int[biggestArraySize];
			this.int_61 = new int[biggestArraySize];
			this.int_62 = new int[biggestArraySize];
			this.int_63 = new int[biggestArraySize];
			this.int_64 = new int[biggestArraySize];
			this.int_65 = new int[biggestArraySize];
			this.int_66 = new int[biggestArraySize];
			this.int_67 = new int[biggestArraySize];
			this.int_70 = new int[biggestArraySize];
			for (int i = 0; i < biggestArraySize; i++)
			{
				this.int_68[i] = 60 * base.GetClampedIntegerValue("RegenerationTimeMinutes", i);
				this.int_69[i] = base.GetClampedIntegerValue("RequiredTownHallLevel", i) - 1;
				this.int_57[i] = base.GetClampedIntegerValue("AbilityTime", i);
				this.int_58[i] = base.GetClampedIntegerValue("AbilitySpeedBoost", i);
				this.int_59[i] = base.GetClampedIntegerValue("AbilitySpeedBoost2", i);
				this.int_60[i] = base.GetClampedIntegerValue("AbilityDamageBoostPercent", i);
				this.int_61[i] = base.GetClampedIntegerValue("AbilitySummonTroopCount", i);
				this.int_62[i] = base.GetClampedIntegerValue("AbilityHealthIncrease", i);
				this.int_63[i] = base.GetClampedIntegerValue("AbilityShieldProjectileSpeed", i);
				this.int_64[i] = base.GetClampedIntegerValue("AbilityShieldProjectileDamageMod", i);
				this.logicSpellData_3[i] = LogicDataTables.GetSpellByName(base.GetClampedValue("AbilitySpell", i), this);
				this.int_65[i] = base.GetClampedIntegerValue("AbilitySpellLevel", i);
				this.int_66[i] = base.GetClampedIntegerValue("AbilityDamageBoostOffset", i);
				int damagePerMS = this.m_attackerItemData[i].GetDamagePerMS(0, false);
				int num = this.int_66[i];
				this.int_67[i] = (100 * (damagePerMS + num) + damagePerMS / 2) / damagePerMS - 100;
				this.int_70[i] = base.GetClampedIntegerValue("StrengthWeight2", i);
			}
			this.int_51 = (base.GetIntegerValue("AlertRadius", 0) << 9) / 100;
			this.bool_18 = base.GetBooleanValue("AbilityStealth", 0);
			this.int_52 = base.GetIntegerValue("AbilityRadius", 0);
			this.bool_19 = base.GetBooleanValue("AbilityAffectsHero", 0);
			this.logicCharacterData_2 = LogicDataTables.GetCharacterByName(base.GetValue("AbilityAffectsCharacter", 0), this);
			this.logicEffectData_7 = LogicDataTables.GetEffectByName(base.GetValue("AbilityTriggerEffect", 0), this);
			this.bool_17 = base.GetBooleanValue("AbilityOnce", 0);
			this.int_48 = base.GetIntegerValue("AbilityCooldown", 0);
			this.logicCharacterData_3 = LogicDataTables.GetCharacterByName(base.GetValue("AbilitySummonTroop", 0), this);
			this.logicEffectData_8 = LogicDataTables.GetEffectByName(base.GetValue("SpecialAbilityEffect", 0), this);
			this.logicEffectData_9 = LogicDataTables.GetEffectByName(base.GetValue("CelebrateEffect", 0), this);
			this.int_53 = (base.GetIntegerValue("SleepOffsetX", 0) << 9) / 100;
			this.int_54 = (base.GetIntegerValue("SleepOffsetY", 0) << 9) / 100;
			this.int_55 = (base.GetIntegerValue("PatrolRadius", 0) << 9) / 100;
			this.string_8 = base.GetValue("SmallPictureSWF", 0);
			this.string_9 = base.GetValue("SmallPicture", 0);
			this.string_10 = base.GetValue("AbilityTID", 0);
			this.string_11 = base.GetValue("AbilityDescTID", 0);
			this.string_12 = base.GetValue("AbilityIcon", 0);
			this.int_56 = base.GetIntegerValue("AbilityDelay", 0);
			this.string_13 = base.GetValue("AbilityBigPictureExportName", 0);
			this.bool_20 = base.GetBooleanValue("HasAltMode", 0);
			this.bool_21 = base.GetBooleanValue("AltModeFlying", 0);
			this.bool_16 = base.GetBooleanValue("NoDefence", 0);
			this.int_49 = base.GetIntegerValue("ActivationTime", 0);
			this.int_50 = base.GetIntegerValue("ActiveDuration", 0);
		}

		// Token: 0x060013CC RID: 5068 RVA: 0x0000D1BA File Offset: 0x0000B3BA
		public bool GetAbilityStealth()
		{
			return this.bool_18;
		}

		// Token: 0x060013CD RID: 5069 RVA: 0x0000D1C2 File Offset: 0x0000B3C2
		public bool GetAbilityAffectsHero()
		{
			return this.bool_19;
		}

		// Token: 0x060013CE RID: 5070 RVA: 0x0000D1CA File Offset: 0x0000B3CA
		public int GetAbilityHealthIncrease(int upgLevel)
		{
			return this.int_62[upgLevel];
		}

		// Token: 0x060013CF RID: 5071 RVA: 0x0000D1D4 File Offset: 0x0000B3D4
		public bool HasHasAltMode()
		{
			return this.bool_20;
		}

		// Token: 0x060013D0 RID: 5072 RVA: 0x0000D1DC File Offset: 0x0000B3DC
		public bool GetAltModeFlying()
		{
			return this.bool_21;
		}

		// Token: 0x060013D1 RID: 5073 RVA: 0x0000D1E4 File Offset: 0x0000B3E4
		public int GetMaxSearchRadiusForDefender()
		{
			return this.int_47;
		}

		// Token: 0x060013D2 RID: 5074 RVA: 0x0000D1EC File Offset: 0x0000B3EC
		public int GetActivationTime()
		{
			return this.int_49;
		}

		// Token: 0x060013D3 RID: 5075 RVA: 0x0000D1F4 File Offset: 0x0000B3F4
		public int GetActiveDuration()
		{
			return this.int_50;
		}

		// Token: 0x060013D4 RID: 5076 RVA: 0x0000D1FC File Offset: 0x0000B3FC
		public int GetAlertRadius()
		{
			return this.int_51;
		}

		// Token: 0x060013D5 RID: 5077 RVA: 0x0000D204 File Offset: 0x0000B404
		public int GetAbilityRadius()
		{
			return this.int_52;
		}

		// Token: 0x060013D6 RID: 5078 RVA: 0x0000D20C File Offset: 0x0000B40C
		public int GetSleepOffsetX()
		{
			return this.int_53;
		}

		// Token: 0x060013D7 RID: 5079 RVA: 0x0000D214 File Offset: 0x0000B414
		public int GetSleepOffsetY()
		{
			return this.int_54;
		}

		// Token: 0x060013D8 RID: 5080 RVA: 0x0000D21C File Offset: 0x0000B41C
		public int GetPatrolRadius()
		{
			return this.int_55;
		}

		// Token: 0x060013D9 RID: 5081 RVA: 0x0000D224 File Offset: 0x0000B424
		public int GetAbilityDelay()
		{
			return this.int_56;
		}

		// Token: 0x060013DA RID: 5082 RVA: 0x0000D22C File Offset: 0x0000B42C
		public string GetSmallPictureSWF()
		{
			return this.string_8;
		}

		// Token: 0x060013DB RID: 5083 RVA: 0x0000D234 File Offset: 0x0000B434
		public string GetSmallPicture()
		{
			return this.string_9;
		}

		// Token: 0x060013DC RID: 5084 RVA: 0x0000D23C File Offset: 0x0000B43C
		public string GetAbilityTID()
		{
			return this.string_10;
		}

		// Token: 0x060013DD RID: 5085 RVA: 0x0000D244 File Offset: 0x0000B444
		public string GetAbilityDescTID()
		{
			return this.string_11;
		}

		// Token: 0x060013DE RID: 5086 RVA: 0x0000D24C File Offset: 0x0000B44C
		public string GetAbilityIcon()
		{
			return this.string_12;
		}

		// Token: 0x060013DF RID: 5087 RVA: 0x0000D254 File Offset: 0x0000B454
		public string GetAbilityBigPictureExportName()
		{
			return this.string_13;
		}

		// Token: 0x060013E0 RID: 5088 RVA: 0x0000D25C File Offset: 0x0000B45C
		public LogicCharacterData GetAbilityAffectsCharacter()
		{
			return this.logicCharacterData_2;
		}

		// Token: 0x060013E1 RID: 5089 RVA: 0x0000D264 File Offset: 0x0000B464
		public LogicCharacterData GetAbilitySummonTroop()
		{
			return this.logicCharacterData_3;
		}

		// Token: 0x060013E2 RID: 5090 RVA: 0x0000D26C File Offset: 0x0000B46C
		public LogicEffectData GetAbilityTriggerEffect()
		{
			return this.logicEffectData_7;
		}

		// Token: 0x060013E3 RID: 5091 RVA: 0x0000D274 File Offset: 0x0000B474
		public LogicEffectData GetSpecialAbilityEffect()
		{
			return this.logicEffectData_8;
		}

		// Token: 0x060013E4 RID: 5092 RVA: 0x0000D27C File Offset: 0x0000B47C
		public LogicEffectData GetCelebreateEffect()
		{
			return this.logicEffectData_9;
		}

		// Token: 0x060013E5 RID: 5093 RVA: 0x0000D284 File Offset: 0x0000B484
		public LogicSpellData GetAbilitySpell(int upgLevel)
		{
			return this.logicSpellData_3[upgLevel];
		}

		// Token: 0x060013E6 RID: 5094 RVA: 0x0000D28E File Offset: 0x0000B48E
		public int GetAbilitySpellLevel(int upgLevel)
		{
			return this.int_65[upgLevel];
		}

		// Token: 0x060013E7 RID: 5095 RVA: 0x0000D298 File Offset: 0x0000B498
		public int GetRequiredTownHallLevel(int index)
		{
			return this.int_69[index];
		}

		// Token: 0x060013E8 RID: 5096 RVA: 0x0000D2A2 File Offset: 0x0000B4A2
		public int GetAbilityShieldProjectileSpeed(int upgLevel)
		{
			return this.int_63[upgLevel];
		}

		// Token: 0x060013E9 RID: 5097 RVA: 0x0000D2AC File Offset: 0x0000B4AC
		public int GetAbilityShieldProjectileDamageMod(int upgLevel)
		{
			return this.int_64[upgLevel];
		}

		// Token: 0x060013EA RID: 5098 RVA: 0x0000D2B6 File Offset: 0x0000B4B6
		public int GetAbilityTime(int index)
		{
			return this.int_57[index];
		}

		// Token: 0x060013EB RID: 5099 RVA: 0x0000D2C0 File Offset: 0x0000B4C0
		public int GetAbilityCooldown()
		{
			return this.int_48;
		}

		// Token: 0x060013EC RID: 5100 RVA: 0x0000D2C8 File Offset: 0x0000B4C8
		public int GetAbilitySpeedBoost(int index)
		{
			return this.int_58[index];
		}

		// Token: 0x060013ED RID: 5101 RVA: 0x0000D2D2 File Offset: 0x0000B4D2
		public int GetAbilitySpeedBoost2(int index)
		{
			return this.int_59[index];
		}

		// Token: 0x060013EE RID: 5102 RVA: 0x0000D2DC File Offset: 0x0000B4DC
		public int GetAbilityDamageBoostPercent(int index)
		{
			return this.int_60[index];
		}

		// Token: 0x060013EF RID: 5103 RVA: 0x0000D2E6 File Offset: 0x0000B4E6
		public int GetAbilityDamageBoost(int index)
		{
			return this.int_67[index];
		}

		// Token: 0x060013F0 RID: 5104 RVA: 0x0000D2F0 File Offset: 0x0000B4F0
		public int GetAbilitySummonTroopCount(int index)
		{
			return this.int_61[index];
		}

		// Token: 0x060013F1 RID: 5105 RVA: 0x0000D2FA File Offset: 0x0000B4FA
		public bool HasNoDefence()
		{
			return this.bool_16;
		}

		// Token: 0x060013F2 RID: 5106 RVA: 0x0000D302 File Offset: 0x0000B502
		public bool HasOnceAbility()
		{
			return this.bool_17;
		}

		// Token: 0x060013F3 RID: 5107 RVA: 0x00050A10 File Offset: 0x0004EC10
		public int GetHeroHitpoints(int hp, int upgLevel)
		{
			hp = LogicMath.Max(0, hp);
			int num = this.int_68[upgLevel];
			int num2 = this.m_hitpoints[upgLevel];
			if (num != 0)
			{
				num2 = num2 * (LogicMath.Max(num - hp, 0) / 60) / (num / 60);
			}
			return num2;
		}

		// Token: 0x060013F4 RID: 5108 RVA: 0x0000D30A File Offset: 0x0000B50A
		public bool HasEnoughHealthForAttack(int hp, int upgLevel)
		{
			return this.m_hitpoints[upgLevel] == hp;
		}

		// Token: 0x060013F5 RID: 5109 RVA: 0x0000D317 File Offset: 0x0000B517
		public bool HasAbility(int upgLevel)
		{
			return this.int_57[upgLevel] > 0 || this.logicSpellData_3[upgLevel] != null;
		}

		// Token: 0x060013F6 RID: 5110 RVA: 0x0000D331 File Offset: 0x0000B531
		public int GetFullRegenerationTimeSec(int upgLevel)
		{
			return this.int_68[upgLevel];
		}

		// Token: 0x060013F7 RID: 5111 RVA: 0x0000D33B File Offset: 0x0000B53B
		public int GetSecondsToFullHealth(int hp, int upgLevel)
		{
			return 60 * (this.int_68[upgLevel] / 60 * (this.m_hitpoints[upgLevel] - LogicMath.Clamp(hp, 0, this.m_hitpoints[upgLevel])) / this.m_hitpoints[upgLevel]);
		}

		// Token: 0x060013F8 RID: 5112 RVA: 0x0000D36D File Offset: 0x0000B56D
		public int GetStrengthWeight2(int upgLevel)
		{
			return this.int_70[upgLevel];
		}

		// Token: 0x060013F9 RID: 5113 RVA: 0x0000D377 File Offset: 0x0000B577
		public bool IsFlying(int mode)
		{
			if (mode == 1 && this.bool_20)
			{
				return this.bool_21;
			}
			return base.IsFlying();
		}

		// Token: 0x060013FA RID: 5114 RVA: 0x00002B56 File Offset: 0x00000D56
		public override LogicCombatItemType GetCombatItemType()
		{
			return LogicCombatItemType.HERO;
		}

		// Token: 0x04000A1C RID: 2588
		private bool bool_16;

		// Token: 0x04000A1D RID: 2589
		private bool bool_17;

		// Token: 0x04000A1E RID: 2590
		private bool bool_18;

		// Token: 0x04000A1F RID: 2591
		private bool bool_19;

		// Token: 0x04000A20 RID: 2592
		private bool bool_20;

		// Token: 0x04000A21 RID: 2593
		private bool bool_21;

		// Token: 0x04000A22 RID: 2594
		private int int_47;

		// Token: 0x04000A23 RID: 2595
		private int int_48;

		// Token: 0x04000A24 RID: 2596
		private int int_49;

		// Token: 0x04000A25 RID: 2597
		private int int_50;

		// Token: 0x04000A26 RID: 2598
		private int int_51;

		// Token: 0x04000A27 RID: 2599
		private int int_52;

		// Token: 0x04000A28 RID: 2600
		private int int_53;

		// Token: 0x04000A29 RID: 2601
		private int int_54;

		// Token: 0x04000A2A RID: 2602
		private int int_55;

		// Token: 0x04000A2B RID: 2603
		private int int_56;

		// Token: 0x04000A2C RID: 2604
		private int[] int_57;

		// Token: 0x04000A2D RID: 2605
		private int[] int_58;

		// Token: 0x04000A2E RID: 2606
		private int[] int_59;

		// Token: 0x04000A2F RID: 2607
		private int[] int_60;

		// Token: 0x04000A30 RID: 2608
		private int[] int_61;

		// Token: 0x04000A31 RID: 2609
		private int[] int_62;

		// Token: 0x04000A32 RID: 2610
		private int[] int_63;

		// Token: 0x04000A33 RID: 2611
		private int[] int_64;

		// Token: 0x04000A34 RID: 2612
		private int[] int_65;

		// Token: 0x04000A35 RID: 2613
		private int[] int_66;

		// Token: 0x04000A36 RID: 2614
		private int[] int_67;

		// Token: 0x04000A37 RID: 2615
		private int[] int_68;

		// Token: 0x04000A38 RID: 2616
		private int[] int_69;

		// Token: 0x04000A39 RID: 2617
		private int[] int_70;

		// Token: 0x04000A3A RID: 2618
		private string string_8;

		// Token: 0x04000A3B RID: 2619
		private string string_9;

		// Token: 0x04000A3C RID: 2620
		private string string_10;

		// Token: 0x04000A3D RID: 2621
		private string string_11;

		// Token: 0x04000A3E RID: 2622
		private string string_12;

		// Token: 0x04000A3F RID: 2623
		private string string_13;

		// Token: 0x04000A40 RID: 2624
		private LogicCharacterData logicCharacterData_2;

		// Token: 0x04000A41 RID: 2625
		private LogicCharacterData logicCharacterData_3;

		// Token: 0x04000A42 RID: 2626
		private LogicEffectData logicEffectData_7;

		// Token: 0x04000A43 RID: 2627
		private LogicEffectData logicEffectData_8;

		// Token: 0x04000A44 RID: 2628
		private LogicEffectData logicEffectData_9;

		// Token: 0x04000A45 RID: 2629
		private LogicSpellData[] logicSpellData_3;
	}
}
