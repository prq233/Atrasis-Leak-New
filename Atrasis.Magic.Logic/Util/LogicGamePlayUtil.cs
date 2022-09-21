using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Util
{
	// Token: 0x0200000B RID: 11
	public static class LogicGamePlayUtil
	{
		// Token: 0x06000049 RID: 73 RVA: 0x000023D5 File Offset: 0x000005D5
		public static int TimeToExp(int time)
		{
			return LogicMath.Sqrt(time);
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00012B98 File Offset: 0x00010D98
		public static int GetSpeedUpCost(int time, int speedUpType, int villageType)
		{
			int multiplier = 100;
			switch (speedUpType)
			{
			case 1:
				multiplier = (LogicDataTables.GetGlobals().UseNewTraining() ? LogicDataTables.GetGlobals().GetSpellTrainingCostMultiplier() : LogicDataTables.GetGlobals().GetSpellSpeedUpCostMultiplier());
				break;
			case 2:
				multiplier = LogicDataTables.GetGlobals().GetHeroHealthSpeedUpCostMultipler();
				break;
			case 3:
				multiplier = LogicDataTables.GetGlobals().GetTroopRequestSpeedUpCostMultiplier();
				break;
			case 4:
				multiplier = LogicDataTables.GetGlobals().GetTroopTrainingCostMultiplier();
				break;
			case 5:
				multiplier = LogicDataTables.GetGlobals().GetSpeedUpBoostCooldownCostMultiplier();
				break;
			case 6:
				multiplier = LogicDataTables.GetGlobals().GetClockTowerSpeedUpMultiplier();
				break;
			}
			return LogicDataTables.GetGlobals().GetSpeedUpCost(time, multiplier, villageType);
		}

		// Token: 0x0600004B RID: 75 RVA: 0x000023DD File Offset: 0x000005DD
		public static int GetResourceDiamondCost(int count, LogicResourceData data)
		{
			return LogicDataTables.GetGlobals().GetResourceDiamondCost(count, data);
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00012C3C File Offset: 0x00010E3C
		public static LogicLeagueVillage2Data GetLeagueVillage2(int score)
		{
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.LEAGUE_VILLAGE2);
			for (int i = table.GetItemCount() - 1; i >= 0; i--)
			{
				LogicLeagueVillage2Data logicLeagueVillage2Data = (LogicLeagueVillage2Data)table.GetItemAt(i);
				if (logicLeagueVillage2Data.GetTrophyLimitHigh() > score && logicLeagueVillage2Data.GetTrophyLimitLow() <= score)
				{
					return logicLeagueVillage2Data;
				}
			}
			return (LogicLeagueVillage2Data)table.GetItemAt(0);
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00012C94 File Offset: 0x00010E94
		public static void CalculateCombatScore(LogicClientAvatar attacker, LogicClientAvatar defender, int stars, bool ignoreLeague, bool revenge, int destructionPercentage, int starBonusMultiplier, bool duelMatch)
		{
			int num = stars;
			if (stars <= 0)
			{
				num = LogicDataTables.GetGlobals().GetScoreMultiplierOnAttackLose();
			}
			int score = attacker.GetScore();
			int score2 = defender.GetScore();
			LogicLeagueData leagueTypeData = attacker.GetLeagueTypeData();
			LogicLeagueData leagueTypeData2 = defender.GetLeagueTypeData();
			int num2;
			int num3;
			if (LogicDataTables.GetGlobals().EloOffsetDampeningEnabled())
			{
				num2 = LogicELOMath.CalculateNewRating(stars > 0, score, score2, 20 * num, LogicDataTables.GetGlobals().GetEloDampeningFactor(), LogicDataTables.GetGlobals().GetEloDampeningLimit(), LogicDataTables.GetGlobals().GetEloDampeningScoreLimit());
				num3 = LogicELOMath.CalculateNewRating(stars <= 0, score2, score, 20 * num, LogicDataTables.GetGlobals().GetEloDampeningFactor(), LogicDataTables.GetGlobals().GetEloDampeningLimit(), LogicDataTables.GetGlobals().GetEloDampeningScoreLimit());
			}
			else
			{
				num2 = LogicELOMath.CalculateNewRating(stars > 0, score, score2, 20 * num);
				num3 = LogicELOMath.CalculateNewRating(stars <= 0, score2, score, 20 * num);
			}
			int num4 = num2 - score;
			int num5 = num3 - score2;
			if (score < 1000 && num4 < 0)
			{
				num4 = score * num4 / 1000;
			}
			if (score2 < 1000 && num5 < 0)
			{
				num5 = score2 * num5 / 1000;
			}
			if (LogicELOMath.CalculateNewRating(true, score, score2, 60) > score)
			{
				if (stars <= 0)
				{
					if (num4 >= 0)
					{
						num4 = -1;
					}
				}
				else
				{
					if (num4 <= 0)
					{
						num4 = 1;
					}
					if (num5 >= 0)
					{
						num5 = -1;
					}
				}
			}
			num2 = LogicMath.Max(score + num4, 0);
			num3 = LogicMath.Max(score2 + num5, 0);
			if (!ignoreLeague)
			{
				attacker.SetScore(num2);
				defender.SetScore(num3);
				if (LogicDataTables.GetGlobals().EnableLeagues() && !duelMatch)
				{
					if (leagueTypeData != null)
					{
						if (stars <= 0)
						{
							attacker.SetAttackLoseCount(attacker.GetAttackLoseCount() + 1);
						}
						else
						{
							attacker.SetAttackWinCount(attacker.GetAttackWinCount() + 1);
						}
					}
					if (leagueTypeData2 != null)
					{
						if (stars > 0)
						{
							defender.SetDefenseLoseCount(defender.GetDefenseLoseCount() + 1);
						}
						else
						{
							defender.SetDefenseWinCount(defender.GetDefenseLoseCount() + 1);
						}
					}
					if (stars > 0 && (!revenge || LogicDataTables.GetGlobals().RevengeGiveLeagueBonus()))
					{
						int leagueBonusPercentage = LogicDataTables.GetGlobals().GetLeagueBonusPercentage(destructionPercentage);
						attacker.CommodityCountChangeHelper(0, LogicDataTables.GetGoldData(), leagueTypeData.GetGoldReward() * leagueBonusPercentage / 100);
						attacker.CommodityCountChangeHelper(0, LogicDataTables.GetElixirData(), leagueTypeData.GetElixirReward() * leagueBonusPercentage / 100);
						if (attacker.IsDarkElixirUnlocked())
						{
							attacker.CommodityCountChangeHelper(0, LogicDataTables.GetDarkElixirData(), leagueTypeData.GetDarkElixirReward() * leagueBonusPercentage / 100);
						}
					}
					LogicGamePlayUtil.UpdateLeagueRank(attacker, num2, false);
					LogicGamePlayUtil.UpdateLeagueRank(defender, num3, true);
				}
			}
			attacker.GetChangeListener().ScoreChanged(attacker.GetCurrentHomeId(), num4, (stars > 0) ? 1 : -1, true, attacker.GetLeagueTypeData(), leagueTypeData, destructionPercentage);
			defender.GetChangeListener().ScoreChanged(defender.GetCurrentHomeId(), num5, (stars > 0) ? -1 : 1, false, defender.GetLeagueTypeData(), leagueTypeData2, destructionPercentage);
			if (stars > 0 && !ignoreLeague && !duelMatch && attacker.CanCollectStarBonus() && (!revenge || LogicDataTables.GetGlobals().RevengeGiveStarBonus()) && !attacker.GetStarBonusCooldown())
			{
				int num6 = stars + attacker.GetStarBonusCounter();
				if (num6 >= LogicDataTables.GetGlobals().GetStarBonusStarCount())
				{
					LogicLeagueData leagueTypeData3 = attacker.GetLeagueTypeData();
					attacker.AddStarBonusReward(leagueTypeData3.GetGoldRewardStarBonus() * starBonusMultiplier, leagueTypeData3.GetElixirRewardStarBonus() * starBonusMultiplier, leagueTypeData3.GetDarkElixirRewardStarBonus() * starBonusMultiplier);
					attacker.StarBonusCollected();
					if (LogicDataTables.GetGlobals().AllowStarsOverflowInStarBonus() && !attacker.GetStarBonusCooldown())
					{
						num6 %= LogicDataTables.GetGlobals().GetStarBonusStarCount();
					}
					else
					{
						num6 = 0;
					}
				}
				attacker.SetStarBonusCounter(num6);
			}
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00012FE0 File Offset: 0x000111E0
		public static void UpdateLeagueRank(LogicClientAvatar clientAvatar, int score, bool defender)
		{
			if (LogicDataTables.GetGlobals().EnableLeagues())
			{
				LogicDataTable table = LogicDataTables.GetTable(LogicDataType.LEAGUE);
				LogicLeagueData leagueTypeData = clientAvatar.GetLeagueTypeData();
				int i = clientAvatar.GetLeagueType();
				if (i != 0)
				{
					int itemCount = table.GetItemCount();
					if (leagueTypeData.GetPromoteLimit() <= score)
					{
						if (leagueTypeData.IsPromoteEnabled())
						{
							while (i + 1 < itemCount)
							{
								LogicLeagueData logicLeagueData = (LogicLeagueData)table.GetItemAt(++i);
								if (logicLeagueData.GetPromoteLimit() > score || !logicLeagueData.IsPromoteEnabled())
								{
									break;
								}
							}
							if (i != clientAvatar.GetLeagueType())
							{
								clientAvatar.SetLeagueType(i);
								return;
							}
						}
					}
					else if (leagueTypeData.GetDemoteLimit() >= score && leagueTypeData.IsDemoteEnabled())
					{
						while (i > 0)
						{
							LogicLeagueData logicLeagueData2 = (LogicLeagueData)table.GetItemAt(--i);
							if (logicLeagueData2.GetDemoteLimit() < score || !logicLeagueData2.IsDemoteEnabled())
							{
								break;
							}
						}
						if (i != clientAvatar.GetLeagueType())
						{
							clientAvatar.SetLeagueType(i);
							return;
						}
					}
				}
				else if (!defender)
				{
					int j = 0;
					while (j < table.GetItemCount())
					{
						LogicLeagueData logicLeagueData3 = (LogicLeagueData)table.GetItemAt(j);
						if (logicLeagueData3.GetPlacementLimitLow() > score || logicLeagueData3.GetPlacementLimitHigh() < score)
						{
							j++;
						}
						else
						{
							if (j != 0)
							{
								clientAvatar.SetLeagueType(j);
								return;
							}
							break;
						}
					}
				}
			}
		}

		// Token: 0x0600004F RID: 79 RVA: 0x000023EB File Offset: 0x000005EB
		public static int DPSToSingleHit(int dps, int ms)
		{
			return dps * ms / 10;
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00013114 File Offset: 0x00011314
		public static bool GetNearestValidAttackPos(LogicLevel level, int x, int y, out int outputX, out int outputY)
		{
			if (x > -2560)
			{
				x = 0;
			}
			if (y > -2560)
			{
				y = 0;
			}
			int num = level.GetWidth();
			int num2 = level.GetHeight();
			if (level.IsNpcVillage())
			{
				if (x <= 0)
				{
					x = 512;
				}
				if (y <= 0)
				{
					y = 512;
				}
				if (x - 2048 > num || y - 2048 > num2)
				{
					outputX = 0;
					outputY = 0;
					return false;
				}
				num -= 512;
				num2 -= 512;
			}
			int num3 = x;
			int num4 = y;
			if (x < num + 2560)
			{
				num3 = ((x <= num) ? x : num);
			}
			if (y < num2 + 2560)
			{
				num4 = ((y <= num2) ? y : num2);
			}
			int num5 = num3 / 512 - 1;
			int num6 = num4 / 512 - 1;
			for (int i = 0; i < 9; i++)
			{
				int num7 = (i + 4) % 9;
				int num8 = num5 + num7 % 3;
				int num9 = num6 + num7 / 3;
				LogicTile tile = level.GetTileMap().GetTile(num8, num9);
				if (tile != null && level.GetTileMap().IsValidAttackPos(num8, num9))
				{
					if (tile.GetPassableFlag() == 0)
					{
						for (int j = 0; j < 4; j++)
						{
							if (tile.IsPassablePathFinder(j & 1, j >> 1))
							{
								outputX = (num8 << 9 | (j & 1) << 8);
								outputY = (num9 << 9) + (j >> 1 << 8);
								return true;
							}
						}
					}
					else
					{
						if (i == 0)
						{
							outputX = num3;
							outputY = num4;
							return true;
						}
						outputX = num8 << 9;
						outputY = num9 << 9;
						return true;
					}
				}
			}
			outputX = 0;
			outputY = 0;
			return false;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00013294 File Offset: 0x00011494
		public static bool FindGoodDuplicatePosAround(LogicLevel level, int x, int y, out int outputX, out int outputY, int radiusInTiles)
		{
			int num = level.GetWidth();
			int num2 = level.GetHeight();
			int num3 = radiusInTiles << 9;
			if (-512 * radiusInTiles < x)
			{
				x = ((x >= 0) ? x : 0);
			}
			if (-512 * radiusInTiles < y)
			{
				y = ((y >= 0) ? y : 0);
			}
			if (level.IsNpcVillage())
			{
				if (x <= 0)
				{
					x = 512;
				}
				if (y <= 0)
				{
					y = 512;
				}
				num -= 512;
				num2 -= 512;
				if (x - num3 > num || y - num3 > num2)
				{
					outputX = 0;
					outputY = 0;
					return false;
				}
			}
			int num4 = x;
			int num5 = y;
			if (x < num + num3)
			{
				num4 = ((x <= num) ? x : num);
			}
			if (y < num2 + num3)
			{
				num5 = ((y <= num2) ? y : num2);
			}
			int num6 = num4 / 512 - 1;
			int num7 = num5 / 512 - 1;
			for (int i = 0; i < 9; i++)
			{
				int num8 = (i + 4) % 9;
				int num9 = num6 + num8 % 3;
				int num10 = num7 + num8 / 3;
				LogicTile tile = level.GetTileMap().GetTile(num9, num10);
				if (tile != null)
				{
					if (tile.GetPassableFlag() == 0)
					{
						for (int j = 0; j < 4; j++)
						{
							if (tile.IsPassablePathFinder(j & 1, j >> 1))
							{
								outputX = (num9 << 9 | (j & 1) << 8);
								outputY = (num10 << 9) + (j >> 1 << 8);
								return true;
							}
						}
					}
					else
					{
						if (i == 0)
						{
							outputX = num4;
							outputY = num5;
							return true;
						}
						outputX = num9 << 9;
						outputY = num10 << 9;
						return true;
					}
				}
			}
			outputX = 0;
			outputY = 0;
			return false;
		}
	}
}
