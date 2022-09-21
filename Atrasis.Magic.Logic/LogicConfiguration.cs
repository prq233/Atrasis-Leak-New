using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic
{
	// Token: 0x02000002 RID: 2
	public class LogicConfiguration
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public LogicConfiguration()
		{
			this.int_0 = 8;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x0000205F File Offset: 0x0000025F
		public LogicJSONObject GetJson()
		{
			return this.logicJSONObject_0;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002067 File Offset: 0x00000267
		public bool GetBattleWaitForProjectileDestruction()
		{
			return this.bool_1;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x0000206F File Offset: 0x0000026F
		public bool GetBattleWaitForDieDamage()
		{
			return this.bool_0;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002077 File Offset: 0x00000277
		public int GetMaxTownHallLevel()
		{
			return this.int_0;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x0000207F File Offset: 0x0000027F
		public int GetDuelBonusLimitWinsPerDay()
		{
			return this.int_2;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002087 File Offset: 0x00000287
		public int GetDuelLootLimitCooldownInMinutes()
		{
			return this.int_1;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x0000208F File Offset: 0x0000028F
		public int GetDuelBonusMaxDiamondCostPercent()
		{
			return this.int_6;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002097 File Offset: 0x00000297
		public LogicObstacleData GetSpecialObstacleData()
		{
			return this.logicObstacleData_0;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00011BE8 File Offset: 0x0000FDE8
		public void Load(LogicJSONObject jsonObject)
		{
			this.logicJSONObject_0 = jsonObject;
			if (jsonObject != null)
			{
				LogicJSONObject jsonobject = jsonObject.GetJSONObject("Village1");
				Debugger.DoAssert(jsonobject != null, "pVillage1 = NULL!");
				LogicJSONString jsonstring = jsonobject.GetJSONString("SpecialObstacle");
				if (jsonstring != null)
				{
					this.logicObstacleData_0 = LogicDataTables.GetObstacleByName(jsonstring.GetStringValue(), null);
				}
				LogicJSONObject jsonobject2 = jsonObject.GetJSONObject("Village2");
				Debugger.DoAssert(jsonobject2 != null, "pVillage2 = NULL!");
				this.int_0 = LogicJSONHelper.GetInt(jsonobject2, "TownHallMaxLevel");
				LogicJSONArray jsonarray = jsonobject2.GetJSONArray("ScoreChangeForLosing");
				Debugger.DoAssert(jsonarray != null, "ScoreChangeForLosing array is null");
				this.logicArrayList_0 = new LogicArrayList<int>(jsonarray.Size());
				this.logicArrayList_1 = new LogicArrayList<int>(jsonarray.Size());
				for (int i = 0; i < jsonarray.Size(); i++)
				{
					LogicJSONObject jsonobject3 = jsonarray.GetJSONObject(i);
					if (jsonobject3 != null)
					{
						LogicJSONNumber jsonnumber = jsonobject3.GetJSONNumber("Milestone");
						LogicJSONNumber jsonnumber2 = jsonobject3.GetJSONNumber("Percentage");
						if (jsonnumber != null && jsonnumber2 != null)
						{
							this.logicArrayList_0.Add(jsonnumber.GetIntValue());
							this.logicArrayList_1.Add(jsonnumber2.GetIntValue());
						}
					}
				}
				LogicJSONArray jsonarray2 = jsonobject2.GetJSONArray("StrengthRangeForScore");
				Debugger.DoAssert(jsonarray2 != null, "StrengthRangeForScore array is null");
				this.logicArrayList_2 = new LogicArrayList<int>(jsonarray2.Size());
				this.logicArrayList_3 = new LogicArrayList<int>(jsonarray2.Size());
				for (int j = 0; j < jsonarray2.Size(); j++)
				{
					LogicJSONObject jsonobject4 = jsonarray2.GetJSONObject(j);
					if (jsonobject4 != null)
					{
						LogicJSONNumber jsonnumber3 = jsonobject4.GetJSONNumber("Milestone");
						LogicJSONNumber jsonnumber4 = jsonobject4.GetJSONNumber("Percentage");
						if (jsonnumber3 != null && jsonnumber4 != null)
						{
							this.logicArrayList_2.Add(jsonnumber3.GetIntValue());
							this.logicArrayList_3.Add(jsonnumber4.GetIntValue());
						}
					}
				}
				LogicJSONObject jsonobject5 = jsonObject.GetJSONObject("KillSwitches");
				Debugger.DoAssert(jsonobject5 != null, "pKillSwitches = NULL!");
				this.bool_1 = LogicJSONHelper.GetBool(jsonobject5, "BattleWaitForProjectileDestruction");
				this.bool_0 = LogicJSONHelper.GetBool(jsonobject5, "BattleWaitForDieDamage");
				LogicJSONObject jsonobject6 = jsonObject.GetJSONObject("Globals");
				Debugger.DoAssert(jsonobject6 != null, "pGlobals = NULL!");
				this.string_0 = LogicJSONHelper.GetString(jsonobject6, "GiftPackExtension");
				this.int_1 = LogicJSONHelper.GetInt(jsonobject6, "DuelLootLimitCooldownInMinutes");
				this.int_2 = LogicJSONHelper.GetInt(jsonobject6, "DuelBonusLimitWinsPerDay");
				this.int_3 = LogicJSONHelper.GetInt(jsonobject6, "DuelBonusPercentWin");
				this.int_4 = LogicJSONHelper.GetInt(jsonobject6, "DuelBonusPercentLose");
				this.int_5 = LogicJSONHelper.GetInt(jsonobject6, "DuelBonusPercentDraw");
				this.int_6 = LogicJSONHelper.GetInt(jsonobject6, "DuelBonusMaxDiamondCostPercent");
				return;
			}
			Debugger.Error("pConfiguration = NULL!");
		}

		// Token: 0x0600000B RID: 11 RVA: 0x0000209F File Offset: 0x0000029F
		public int GetDuelBonusPercentWin()
		{
			return this.int_3;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000020A7 File Offset: 0x000002A7
		public void SetDuelBonusPercentWin(int value)
		{
			this.int_3 = value;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000020B0 File Offset: 0x000002B0
		public int GetDuelBonusPercentLose()
		{
			return this.int_4;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000020B8 File Offset: 0x000002B8
		public void SetDuelBonusPercentLose(int value)
		{
			this.int_4 = value;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000020C1 File Offset: 0x000002C1
		public int GetDuelBonusPercentDraw()
		{
			return this.int_5;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000020C9 File Offset: 0x000002C9
		public void SetDuelBonusPercentDraw(int value)
		{
			this.int_5 = value;
		}

		// Token: 0x04000001 RID: 1
		private LogicJSONObject logicJSONObject_0;

		// Token: 0x04000002 RID: 2
		private LogicObstacleData logicObstacleData_0;

		// Token: 0x04000003 RID: 3
		private LogicArrayList<int> logicArrayList_0;

		// Token: 0x04000004 RID: 4
		private LogicArrayList<int> logicArrayList_1;

		// Token: 0x04000005 RID: 5
		private LogicArrayList<int> logicArrayList_2;

		// Token: 0x04000006 RID: 6
		private LogicArrayList<int> logicArrayList_3;

		// Token: 0x04000007 RID: 7
		private bool bool_0;

		// Token: 0x04000008 RID: 8
		private bool bool_1;

		// Token: 0x04000009 RID: 9
		private int int_0;

		// Token: 0x0400000A RID: 10
		private int int_1;

		// Token: 0x0400000B RID: 11
		private int int_2;

		// Token: 0x0400000C RID: 12
		private int int_3;

		// Token: 0x0400000D RID: 13
		private int int_4;

		// Token: 0x0400000E RID: 14
		private int int_5;

		// Token: 0x0400000F RID: 15
		private int int_6;

		// Token: 0x04000010 RID: 16
		private string string_0;
	}
}
