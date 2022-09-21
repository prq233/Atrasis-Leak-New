using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Util
{
	// Token: 0x02000011 RID: 17
	public static class LogicStrengthUtil
	{
		// Token: 0x06000097 RID: 151 RVA: 0x00015210 File Offset: 0x00013410
		public static float GetAttackStrength(int townHallLevel, int castleUpgLevel, LogicArrayList<LogicHeroData> unlockedHeroes, int[] heroUpgLevel, LogicArrayList<LogicCharacterData> unlockedCharacters, int[] characterUpgLevel, int totalHousingSpace, LogicArrayList<LogicSpellData> unlockedSpells, int[] spellUpgLevel, int totalSpellHousingSpace)
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			float[] array = new float[unlockedCharacters.Size()];
			if (castleUpgLevel > -1)
			{
				num = (float)(castleUpgLevel + 1) * 10f * ((castleUpgLevel >= 4) ? 4f : 2f);
			}
			for (int i = 0; i < unlockedHeroes.Size(); i++)
			{
				num2 += LogicStrengthUtil.GetHeroStrength(unlockedHeroes[i], heroUpgLevel[i], false);
			}
			for (int j = 0; j < unlockedCharacters.Size(); j++)
			{
				array[j] = LogicStrengthUtil.GetCharacterStrength(unlockedCharacters[j], characterUpgLevel[j]);
			}
			float globalCharacterStrength = LogicStrengthUtil.GetGlobalCharacterStrength(unlockedCharacters, array, townHallLevel);
			float num4 = (float)totalHousingSpace * 0.01f * globalCharacterStrength;
			for (int k = 0; k < unlockedSpells.Size(); k++)
			{
				num3 += LogicStrengthUtil.GetSpellStrength(unlockedSpells[k], spellUpgLevel[k]);
			}
			float num5 = (float)totalSpellHousingSpace * 0.5f * num3;
			return num + num2 + num4 + num5;
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00015310 File Offset: 0x00013510
		public static float GetHeroStrength(LogicHeroData data, int upgLevel, bool useHeroStrengthWeight)
		{
			if (data.IsProductionEnabled())
			{
				return ((float)data.GetHitpoints(upgLevel) * 0.04f + (float)data.GetAttackerItemData(upgLevel).GetDamagePerMS(0, false) * 0.2f) * 0.1f * (float)(useHeroStrengthWeight ? data.GetStrengthWeight2(upgLevel) : data.GetStrengthWeight(upgLevel));
			}
			return 0f;
		}

		// Token: 0x06000099 RID: 153 RVA: 0x0001536C File Offset: 0x0001356C
		public static float GetCharacterStrength(LogicCharacterData data, int upgLevel)
		{
			if (data.IsProductionEnabled())
			{
				float num = (float)data.GetHitpoints(upgLevel) * 0.04f + (float)LogicMath.Abs(data.GetAttackerItemData(upgLevel).GetDamagePerMS(0, false)) * 0.2f;
				if (data.GetUnitsInCamp(upgLevel) > 0 && data.GetUnitsInCamp(0) > 0)
				{
					num = (float)data.GetUnitsInCamp(upgLevel) / (float)data.GetUnitsInCamp(0) * num;
				}
				for (int i = data.GetSpecialAbilityLevel(upgLevel); i > 0; i--)
				{
					num *= 1.1f;
				}
				return num * 0.01f * (float)data.GetStrengthWeight(upgLevel) / (float)data.GetHousingSpace() * 10f;
			}
			return 0f;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00015414 File Offset: 0x00013614
		public static float GetSpellStrength(LogicSpellData data, int upgLevel)
		{
			if (data.IsProductionEnabled())
			{
				int num = data.GetDamage(upgLevel);
				if (!data.IsDamageSpell())
				{
					num = -num;
				}
				int buildingDamagePermil = data.GetBuildingDamagePermil(upgLevel);
				int troopDamagePermil = data.GetTroopDamagePermil(upgLevel);
				int num2 = num / 100 + buildingDamagePermil + troopDamagePermil;
				if (data.GetDamageBoostPercent(upgLevel) > 0)
				{
					num2 += data.GetDamageBoostPercent(upgLevel) - 100;
				}
				int num3 = num2 + data.GetSpeedBoost(upgLevel);
				if (num3 == 0)
				{
					if (data.GetJumpBoostMS(upgLevel) != 0)
					{
						num3 = data.GetJumpBoostMS(upgLevel) / 1000;
					}
					if (data.GetFreezeTimeMS(upgLevel) != 0)
					{
						num3 = data.GetFreezeTimeMS(upgLevel) / 1000;
					}
					if (data.GetDuplicateHousing(upgLevel) != 0)
					{
						num3 = data.GetDuplicateHousing(upgLevel);
					}
					if (data.GetUnitsToSpawn(upgLevel) != 0)
					{
						num3 = data.GetUnitsToSpawn(upgLevel);
					}
				}
				return (float)num3 * 0.014286f * (float)data.GetStrengthWeight(upgLevel);
			}
			return 0f;
		}

		// Token: 0x0600009B RID: 155 RVA: 0x000154EC File Offset: 0x000136EC
		public static float GetGlobalCharacterStrength(LogicArrayList<LogicCharacterData> characterData, float[] strength, int townHallLevel)
		{
			LogicTownhallLevelData townHallLevel2 = LogicDataTables.GetTownHallLevel(townHallLevel);
			float num = 0f;
			for (int i = LogicMath.Min(townHallLevel2.GetStrengthMaxTroopTypes(), characterData.Size()); i > 0; i--)
			{
				float num2 = 0f;
				int num3 = 0;
				for (int j = 0; j < characterData.Size(); j++)
				{
					if (strength[j] > num2)
					{
						num2 = strength[j];
						num3 = j;
					}
				}
				if (num2 == 0f)
				{
					break;
				}
				num += num2;
				strength[num3] = 0f;
			}
			return num;
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00015564 File Offset: 0x00013764
		public static float GetDefenseStrength(LogicArrayList<LogicGameObject> buildings, LogicArrayList<LogicGameObject> traps, LogicArrayList<LogicHeroData> heroes, int[] heroUpgLevel)
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			for (int i = 0; i < heroes.Size(); i++)
			{
				num += LogicStrengthUtil.GetHeroStrength(heroes[i], heroUpgLevel[i], true);
			}
			for (int j = 0; j < buildings.Size(); j++)
			{
				LogicBuilding logicBuilding = (LogicBuilding)buildings[j];
				if (!logicBuilding.IsLocked() && (!logicBuilding.IsConstructing() || logicBuilding.IsUpgrading()))
				{
					num2 += LogicStrengthUtil.GetBuildingStrength(logicBuilding.GetBuildingData(), logicBuilding.GetUpgradeLevel());
				}
			}
			for (int k = 0; k < traps.Size(); k++)
			{
				LogicTrap logicTrap = (LogicTrap)traps[k];
				if (!logicTrap.IsConstructing() || logicTrap.IsUpgrading())
				{
					num3 += LogicStrengthUtil.GetTrapStrength(logicTrap.GetTrapData(), logicTrap.GetUpgradeLevel());
				}
			}
			return num2 + num3 + num;
		}

		// Token: 0x0600009D RID: 157 RVA: 0x000025D1 File Offset: 0x000007D1
		public static float GetBuildingStrength(LogicBuildingData data, int upgLevel)
		{
			return ((float)data.GetHitpoints(upgLevel) * 0.04f + (float)data.GetAttackerItemData(upgLevel).GetDamagePerMS(0, false) * 0.2f) * 0.1f * (float)data.GetStrengthWeight(upgLevel);
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00015650 File Offset: 0x00013850
		public static float GetTrapStrength(LogicTrapData data, int upgLevel)
		{
			int num = data.GetDamage(upgLevel);
			if (num == 0)
			{
				if (data.GetNumSpawns(upgLevel) != 0)
				{
					num = data.GetNumSpawns(upgLevel);
				}
				if (data.GetEjectHousingLimit(upgLevel) != 0)
				{
					num = data.GetEjectHousingLimit(upgLevel);
				}
				if (data.GetPushback() != 0)
				{
					num = data.GetPushback();
				}
			}
			return (float)num * 0.014286f * (float)data.GetStrengthWeight(upgLevel);
		}
	}
}
