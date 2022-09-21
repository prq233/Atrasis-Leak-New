using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000158 RID: 344
	public class LogicLeagueVillage2Data : LogicData
	{
		// Token: 0x06001417 RID: 5143 RVA: 0x0000B3C0 File Offset: 0x000095C0
		public LogicLeagueVillage2Data(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x06001418 RID: 5144 RVA: 0x00050C64 File Offset: 0x0004EE64
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.int_0 = base.GetIntegerValue("TrophyLimitLow", 0);
			this.int_1 = base.GetIntegerValue("TrophyLimitHigh", 0);
			this.int_2 = base.GetIntegerValue("GoldReward", 0);
			this.int_3 = base.GetIntegerValue("ElixirReward", 0);
			this.int_4 = base.GetIntegerValue("BonusGold", 0);
			this.int_5 = base.GetIntegerValue("BonusElixir", 0);
			this.int_6 = base.GetIntegerValue("SeasonTrophyReset", 0);
			this.int_7 = base.GetIntegerValue("MaxDiamondCost", 0);
		}

		// Token: 0x06001419 RID: 5145 RVA: 0x0000D45A File Offset: 0x0000B65A
		public int GetTrophyLimitLow()
		{
			return this.int_0;
		}

		// Token: 0x0600141A RID: 5146 RVA: 0x0000D462 File Offset: 0x0000B662
		public int GetTrophyLimitHigh()
		{
			return this.int_1;
		}

		// Token: 0x0600141B RID: 5147 RVA: 0x0000D46A File Offset: 0x0000B66A
		public int GetGoldReward()
		{
			return this.int_2;
		}

		// Token: 0x0600141C RID: 5148 RVA: 0x0000D472 File Offset: 0x0000B672
		public int GetElixirReward()
		{
			return this.int_3;
		}

		// Token: 0x0600141D RID: 5149 RVA: 0x0000D47A File Offset: 0x0000B67A
		public int GetBonusGold()
		{
			return this.int_4;
		}

		// Token: 0x0600141E RID: 5150 RVA: 0x0000D482 File Offset: 0x0000B682
		public int GetBonusElixir()
		{
			return this.int_5;
		}

		// Token: 0x0600141F RID: 5151 RVA: 0x0000D48A File Offset: 0x0000B68A
		public int GetSeasonTrophyReset()
		{
			return this.int_6;
		}

		// Token: 0x06001420 RID: 5152 RVA: 0x0000D492 File Offset: 0x0000B692
		public int GetMaxDiamondCost()
		{
			return this.int_7;
		}

		// Token: 0x04000A5E RID: 2654
		private int int_0;

		// Token: 0x04000A5F RID: 2655
		private int int_1;

		// Token: 0x04000A60 RID: 2656
		private int int_2;

		// Token: 0x04000A61 RID: 2657
		private int int_3;

		// Token: 0x04000A62 RID: 2658
		private int int_4;

		// Token: 0x04000A63 RID: 2659
		private int int_5;

		// Token: 0x04000A64 RID: 2660
		private int int_6;

		// Token: 0x04000A65 RID: 2661
		private int int_7;
	}
}
