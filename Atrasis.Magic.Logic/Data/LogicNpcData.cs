using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.CSV;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x0200015C RID: 348
	public class LogicNpcData : LogicData
	{
		// Token: 0x06001473 RID: 5235 RVA: 0x0000D70E File Offset: 0x0000B90E
		public LogicNpcData(CSVRow row, LogicDataTable table) : base(row, table)
		{
			this.logicArrayList_0 = new LogicArrayList<LogicNpcData>();
			this.logicArrayList_1 = new LogicArrayList<LogicDataSlot>();
		}

		// Token: 0x06001474 RID: 5236 RVA: 0x0005176C File Offset: 0x0004F96C
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.string_0 = base.GetValue("MapInstanceName", 0);
			this.int_0 = base.GetIntegerValue("ExpLevel", 0);
			this.string_1 = base.GetValue("LevelFile", 0);
			this.int_1 = base.GetIntegerValue("Gold", 0);
			this.int_2 = base.GetIntegerValue("Elixir", 0);
			this.bool_0 = base.GetBooleanValue("AlwaysUnlocked", 0);
			this.string_2 = base.GetValue("PlayerName", 0);
			this.string_3 = base.GetValue("AllianceName", 0);
			this.int_3 = base.GetIntegerValue("AllianceBadge", 0);
			this.bool_1 = base.GetBooleanValue("SinglePlayer", 0);
			int arraySize = base.GetArraySize("UnitType");
			if (arraySize > 0)
			{
				this.logicArrayList_1.EnsureCapacity(arraySize);
				for (int i = 0; i < arraySize; i++)
				{
					int integerValue = base.GetIntegerValue("UnitCount", i);
					if (integerValue > 0)
					{
						this.logicArrayList_1.Add(new LogicDataSlot(LogicDataTables.GetCharacterByName(base.GetValue("UnitType", i), this), integerValue));
					}
				}
			}
			int arraySize2 = base.GetArraySize("MapDependencies");
			for (int j = 0; j < arraySize2; j++)
			{
				LogicNpcData npcByName = LogicDataTables.GetNpcByName(base.GetValue("MapDependencies", j), this);
				if (npcByName != null)
				{
					this.logicArrayList_0.Add(npcByName);
				}
			}
		}

		// Token: 0x06001475 RID: 5237 RVA: 0x000518D4 File Offset: 0x0004FAD4
		public LogicArrayList<LogicDataSlot> GetClonedUnits()
		{
			LogicArrayList<LogicDataSlot> logicArrayList = new LogicArrayList<LogicDataSlot>();
			for (int i = 0; i < this.logicArrayList_1.Size(); i++)
			{
				logicArrayList.Add(this.logicArrayList_1[i].Clone());
			}
			return logicArrayList;
		}

		// Token: 0x06001476 RID: 5238 RVA: 0x00051918 File Offset: 0x0004FB18
		public bool IsUnlockedInMap(LogicClientAvatar avatar)
		{
			if (!this.bool_0)
			{
				if (!string.IsNullOrEmpty(this.string_0) && this.logicArrayList_0 != null)
				{
					for (int i = 0; i < this.logicArrayList_0.Size(); i++)
					{
						if (avatar.GetNpcStars(this.logicArrayList_0[i]) > 0)
						{
							return true;
						}
					}
				}
				return false;
			}
			return true;
		}

		// Token: 0x06001477 RID: 5239 RVA: 0x0000D72E File Offset: 0x0000B92E
		public string GetMapInstanceName()
		{
			return this.string_0;
		}

		// Token: 0x06001478 RID: 5240 RVA: 0x0000D736 File Offset: 0x0000B936
		public int GetExpLevel()
		{
			return this.int_0;
		}

		// Token: 0x06001479 RID: 5241 RVA: 0x0000D73E File Offset: 0x0000B93E
		public string GetLevelFile()
		{
			return this.string_1;
		}

		// Token: 0x0600147A RID: 5242 RVA: 0x0000D746 File Offset: 0x0000B946
		public int GetGoldCount()
		{
			return this.int_1;
		}

		// Token: 0x0600147B RID: 5243 RVA: 0x0000D74E File Offset: 0x0000B94E
		public int GetElixirCount()
		{
			return this.int_2;
		}

		// Token: 0x0600147C RID: 5244 RVA: 0x0000D756 File Offset: 0x0000B956
		public bool IsAlwaysUnlocked()
		{
			return this.bool_0;
		}

		// Token: 0x0600147D RID: 5245 RVA: 0x0000D75E File Offset: 0x0000B95E
		public string GetPlayerName()
		{
			return this.string_2;
		}

		// Token: 0x0600147E RID: 5246 RVA: 0x0000D766 File Offset: 0x0000B966
		public string GetAllianceName()
		{
			return this.string_3;
		}

		// Token: 0x0600147F RID: 5247 RVA: 0x0000D76E File Offset: 0x0000B96E
		public int GetAllianceBadge()
		{
			return this.int_3;
		}

		// Token: 0x06001480 RID: 5248 RVA: 0x0000D776 File Offset: 0x0000B976
		public bool IsSinglePlayer()
		{
			return this.bool_1;
		}

		// Token: 0x04000AC3 RID: 2755
		private string string_0;

		// Token: 0x04000AC4 RID: 2756
		private string string_1;

		// Token: 0x04000AC5 RID: 2757
		private string string_2;

		// Token: 0x04000AC6 RID: 2758
		private string string_3;

		// Token: 0x04000AC7 RID: 2759
		private int int_0;

		// Token: 0x04000AC8 RID: 2760
		private int int_1;

		// Token: 0x04000AC9 RID: 2761
		private int int_2;

		// Token: 0x04000ACA RID: 2762
		private int int_3;

		// Token: 0x04000ACB RID: 2763
		private bool bool_0;

		// Token: 0x04000ACC RID: 2764
		private bool bool_1;

		// Token: 0x04000ACD RID: 2765
		private readonly LogicArrayList<LogicNpcData> logicArrayList_0;

		// Token: 0x04000ACE RID: 2766
		private readonly LogicArrayList<LogicDataSlot> logicArrayList_1;
	}
}
