using System;
using Atrasis.Magic.Titan.CSV;
using Atrasis.Magic.Titan.Debug;
using ns0;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000141 RID: 321
	public class LogicCalendarEventFunctionData : LogicData
	{
		// Token: 0x0600119C RID: 4508 RVA: 0x0000B3C0 File Offset: 0x000095C0
		public LogicCalendarEventFunctionData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x0600119D RID: 4509 RVA: 0x0004C650 File Offset: 0x0004A850
		public override void CreateReferences()
		{
			base.CreateReferences();
			int arraySize = base.GetArraySize("ParameterType");
			this.int_0 = new int[arraySize];
			this.string_0 = new string[arraySize];
			this.string_1 = new string[arraySize];
			this.int_1 = new int[arraySize];
			this.int_2 = new int[arraySize];
			for (int i = 0; i < arraySize; i++)
			{
				this.int_0[i] = this.method_0(base.GetValue("ParameterType", i));
				this.string_0[i] = base.GetValue("ParameterName", i);
				this.string_1[i] = base.GetValue("Description", i);
				this.int_1[i] = base.GetIntegerValue("MinValue", i);
				this.int_2[i] = base.GetIntegerValue("MaxValue", i);
			}
			this.int_3 = this.GetCategoryByName(base.GetValue("Category", 0));
			this.int_4 = this.GetFunctionByName(base.GetName());
			this.bool_0 = base.GetBooleanValue("TargetingSupported", 0);
			this.bool_1 = base.GetBooleanValue("Deprecated", 0);
			for (int j = 0; j < arraySize; j++)
			{
				Debugger.DoAssert(this.string_0[j] != null, "Parameter index " + j + " name missing!");
			}
		}

		// Token: 0x0600119E RID: 4510 RVA: 0x0000BCEC File Offset: 0x00009EEC
		public int GetCategoryByName(string name)
		{
			if (name != null)
			{
				if (name == "Modifier")
				{
					return 1;
				}
				if (name == "Targeting")
				{
					return 2;
				}
			}
			Debugger.Error("Unknown category. " + name);
			return -1;
		}

		// Token: 0x0600119F RID: 4511 RVA: 0x0004C7A4 File Offset: 0x0004A9A4
		public int GetFunctionByName(string name)
		{
			if (name != null)
			{
				uint num = Class0.smethod_0(name);
				if (num <= 1848328328U)
				{
					if (num <= 1113840044U)
					{
						if (num <= 428891278U)
						{
							if (num != 54873975U)
							{
								if (num == 428891278U)
								{
									if (name == "UseSpell")
									{
										return 22;
									}
								}
							}
							else if (name == "TargetingTownHallLevel")
							{
								return 13;
							}
						}
						else if (num != 838382445U)
						{
							if (num != 1111522333U)
							{
								if (num == 1113840044U)
								{
									if (name == "TroopTrainingBoost")
									{
										return 1;
									}
								}
							}
							else if (name == "OfferBundle")
							{
								return 7;
							}
						}
						else if (name == "EnableTrap")
						{
							return 11;
						}
					}
					else if (num <= 1494031475U)
					{
						if (num != 1220454212U)
						{
							if (num != 1323533486U)
							{
								if (num == 1494031475U)
								{
									if (name == "GiveFreeTroops")
									{
										return 17;
									}
								}
							}
							else if (name == "EnableTroop")
							{
								return 9;
							}
						}
						else if (name == "TargetingPurchasedDiamonds")
						{
							return 14;
						}
					}
					else if (num != 1620050692U)
					{
						if (num != 1810702708U)
						{
							if (num == 1848328328U)
							{
								if (name == "EnableSpell")
								{
									return 10;
								}
							}
						}
						else if (name == "BuildingSign")
						{
							return 20;
						}
					}
					else if (name == "UseTroop")
					{
						return 12;
					}
				}
				else if (num <= 2373157434U)
				{
					if (num <= 1931567949U)
					{
						if (num != 1854484302U)
						{
							if (num != 1887108980U)
							{
								if (num == 1931567949U)
								{
									if (name == "GiveFreeSpells")
									{
										return 18;
									}
								}
							}
							else if (name == "ChangeWorkerLook")
							{
								return 16;
							}
						}
						else if (name == "ClanXPMultiplier")
						{
							return 6;
						}
					}
					else if (num != 1973887804U)
					{
						if (num != 2146830132U)
						{
							if (num == 2373157434U)
							{
								if (name == "SpellDiscount")
								{
									return 5;
								}
							}
						}
						else if (name == "TroopDiscount")
						{
							return 4;
						}
					}
					else if (name == "BuildingBoost")
					{
						return 3;
					}
				}
				else if (num <= 3143419465U)
				{
					if (num != 3024029335U)
					{
						if (num != 3077777290U)
						{
							if (num == 3143419465U)
							{
								if (name == "BuildingDestroyedSpawnUnit")
								{
									return 21;
								}
							}
						}
						else if (name == "SpellBrewingBoost")
						{
							return 2;
						}
					}
					else if (name == "StarBonusMultiplier")
					{
						return 8;
					}
				}
				else if (num != 3379366463U)
				{
					if (num != 3593538804U)
					{
						if (num == 3863626312U)
						{
							if (name == "GiveFreeHeroHealth")
							{
								return 19;
							}
						}
					}
					else if (name == "ClanWarLootMultiplier")
					{
						return 23;
					}
				}
				else if (name == "EnableBillingPackage")
				{
					return 15;
				}
			}
			Debugger.Error("Unknown function. " + name);
			return -1;
		}

		// Token: 0x060011A0 RID: 4512 RVA: 0x0004CA88 File Offset: 0x0004AC88
		private int method_0(string string_2)
		{
			string text = string_2.ToLowerInvariant();
			if (text != null)
			{
				uint num = Class0.smethod_0(text);
				if (num <= 1280269460U)
				{
					if (num <= 398550328U)
					{
						if (num != 304701189U)
						{
							if (num == 398550328U)
							{
								if (text == "string")
								{
									return 2;
								}
							}
						}
						else if (text == "bundle")
						{
							return 7;
						}
					}
					else if (num != 456875097U)
					{
						if (num != 954139509U)
						{
							if (num == 1280269460U)
							{
								if (text == "billingpackage")
								{
									return 8;
								}
							}
						}
						else if (text == "building")
						{
							return 5;
						}
					}
					else if (text == "hero")
					{
						return 10;
					}
				}
				else if (num <= 2515107422U)
				{
					if (num != 1619038978U)
					{
						if (num != 1710517951U)
						{
							if (num == 2515107422U)
							{
								if (text == "int")
								{
									return 1;
								}
							}
						}
						else if (text == "boolean")
						{
							return 0;
						}
					}
					else if (text == "trap")
					{
						return 6;
					}
				}
				else if (num != 2626724755U)
				{
					if (num != 2842674889U)
					{
						if (num == 3779456605U)
						{
							if (text == "animation")
							{
								return 9;
							}
						}
					}
					else if (text == "spell")
					{
						return 4;
					}
				}
				else if (text == "troop")
				{
					return 3;
				}
			}
			Debugger.Error("Unknown parameter type " + string_2);
			return -1;
		}

		// Token: 0x060011A1 RID: 4513 RVA: 0x0000BD20 File Offset: 0x00009F20
		public int GetParameterType(int index)
		{
			if (index > this.int_0.Length)
			{
				Debugger.Error(string.Format("Functions can only takes {0} parameters. index={1}", this.int_0.Length, index));
			}
			return this.int_0[index];
		}

		// Token: 0x060011A2 RID: 4514 RVA: 0x0000BD57 File Offset: 0x00009F57
		public string GetParameterName(int index)
		{
			return this.string_0[index];
		}

		// Token: 0x060011A3 RID: 4515 RVA: 0x0000BD61 File Offset: 0x00009F61
		public string GetDescription(int index)
		{
			return this.string_1[index];
		}

		// Token: 0x060011A4 RID: 4516 RVA: 0x0000BD6B File Offset: 0x00009F6B
		public int GetMinValue(int index)
		{
			return this.int_1[index];
		}

		// Token: 0x060011A5 RID: 4517 RVA: 0x0000BD75 File Offset: 0x00009F75
		public int GetMaxValue(int index)
		{
			return this.int_2[index];
		}

		// Token: 0x060011A6 RID: 4518 RVA: 0x0000BD7F File Offset: 0x00009F7F
		public int GetFunctionType()
		{
			return this.int_4;
		}

		// Token: 0x060011A7 RID: 4519 RVA: 0x0000BD87 File Offset: 0x00009F87
		public int GetParameterCount()
		{
			return this.int_0.Length;
		}

		// Token: 0x060011A8 RID: 4520 RVA: 0x0000BD91 File Offset: 0x00009F91
		public bool IsDeprecated()
		{
			return this.bool_1;
		}

		// Token: 0x040007DF RID: 2015
		public const int FUNCTION_TYPE_TROOP_TRAINING_BOOST = 1;

		// Token: 0x040007E0 RID: 2016
		public const int FUNCTION_TYPE_SPELL_BREWING_BOOST = 2;

		// Token: 0x040007E1 RID: 2017
		public const int FUNCTION_TYPE_BUILDING_BOOST = 3;

		// Token: 0x040007E2 RID: 2018
		public const int FUNCTION_TYPE_TROOP_DISCOUNT = 4;

		// Token: 0x040007E3 RID: 2019
		public const int FUNCTION_TYPE_SPELL_DISCOUNT = 5;

		// Token: 0x040007E4 RID: 2020
		public const int FUNCTION_TYPE_CLAN_XP_MULTIPLIER = 6;

		// Token: 0x040007E5 RID: 2021
		public const int FUNCTION_TYPE_OFFER_BUNDLE = 7;

		// Token: 0x040007E6 RID: 2022
		public const int FUNCTION_TYPE_STAR_BONUS_MULTIPLIER = 8;

		// Token: 0x040007E7 RID: 2023
		public const int FUNCTION_TYPE_ENABLE_TROOP = 9;

		// Token: 0x040007E8 RID: 2024
		public const int FUNCTION_TYPE_ENABLE_SPELL = 10;

		// Token: 0x040007E9 RID: 2025
		public const int FUNCTION_TYPE_ENABLE_TRAP = 11;

		// Token: 0x040007EA RID: 2026
		public const int FUNCTION_TYPE_USE_TROOP = 12;

		// Token: 0x040007EB RID: 2027
		public const int FUNCTION_TYPE_TARGETING_TOWN_HALL_LEVEL = 13;

		// Token: 0x040007EC RID: 2028
		public const int FUNCTION_TYPE_TARGETING_PURCHASED_DIAMONDS = 14;

		// Token: 0x040007ED RID: 2029
		public const int FUNCTION_TYPE_ENABLE_BILLING_PACKAGE = 15;

		// Token: 0x040007EE RID: 2030
		public const int FUNCTION_TYPE_CHANGE_WORKER_LOOK = 16;

		// Token: 0x040007EF RID: 2031
		public const int FUNCTION_TYPE_GIVE_FREE_TROOPS = 17;

		// Token: 0x040007F0 RID: 2032
		public const int FUNCTION_TYPE_GIVE_FREE_SPELLS = 18;

		// Token: 0x040007F1 RID: 2033
		public const int FUNCTION_TYPE_GIVE_FREE_HERO_HEALTH = 19;

		// Token: 0x040007F2 RID: 2034
		public const int FUNCTION_TYPE_BUILDING_SIGN = 20;

		// Token: 0x040007F3 RID: 2035
		public const int FUNCTION_TYPE_BUILDING_DESTROYED_SPAWN_UNIT = 21;

		// Token: 0x040007F4 RID: 2036
		public const int FUNCTION_TYPE_USE_SPELL = 22;

		// Token: 0x040007F5 RID: 2037
		public const int FUNCTION_TYPE_CLAN_WAR_LOOT_MULTIPLIER = 23;

		// Token: 0x040007F6 RID: 2038
		public const int PARAMETER_TYPE_BOOLEAN = 0;

		// Token: 0x040007F7 RID: 2039
		public const int PARAMETER_TYPE_INT = 1;

		// Token: 0x040007F8 RID: 2040
		public const int PARAMETER_TYPE_STRING = 2;

		// Token: 0x040007F9 RID: 2041
		public const int PARAMETER_TYPE_TROOP = 3;

		// Token: 0x040007FA RID: 2042
		public const int PARAMETER_TYPE_SPELL = 4;

		// Token: 0x040007FB RID: 2043
		public const int PARAMETER_TYPE_BUILDING = 5;

		// Token: 0x040007FC RID: 2044
		public const int PARAMETER_TYPE_TRAP = 6;

		// Token: 0x040007FD RID: 2045
		public const int PARAMETER_TYPE_BUNDLE = 7;

		// Token: 0x040007FE RID: 2046
		public const int PARAMETER_TYPE_BILLING_PACKAGE = 8;

		// Token: 0x040007FF RID: 2047
		public const int PARAMETER_TYPE_ANIMATION = 9;

		// Token: 0x04000800 RID: 2048
		public const int PARAMETER_TYPE_HERO = 10;

		// Token: 0x04000801 RID: 2049
		private bool bool_0;

		// Token: 0x04000802 RID: 2050
		private bool bool_1;

		// Token: 0x04000803 RID: 2051
		private int[] int_0;

		// Token: 0x04000804 RID: 2052
		private string[] string_0;

		// Token: 0x04000805 RID: 2053
		private string[] string_1;

		// Token: 0x04000806 RID: 2054
		private int[] int_1;

		// Token: 0x04000807 RID: 2055
		private int[] int_2;

		// Token: 0x04000808 RID: 2056
		private int int_3;

		// Token: 0x04000809 RID: 2057
		private int int_4;
	}
}
