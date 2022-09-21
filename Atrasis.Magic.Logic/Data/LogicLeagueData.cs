using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000157 RID: 343
	public class LogicLeagueData : LogicData
	{
		// Token: 0x060013FD RID: 5117 RVA: 0x0000B3C0 File Offset: 0x000095C0
		public LogicLeagueData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x060013FE RID: 5118 RVA: 0x00050A50 File Offset: 0x0004EC50
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.string_0 = base.GetValue("LeagueBannerIcon", 0);
			this.string_1 = base.GetValue("LeagueBannerIconNum", 0);
			this.string_2 = base.GetValue("LeagueBannerIconHUD", 0);
			this.int_0 = base.GetIntegerValue("GoldReward", 0);
			this.int_1 = base.GetIntegerValue("ElixirReward", 0);
			this.int_2 = base.GetIntegerValue("DarkElixirReward", 0);
			this.bool_0 = base.GetBooleanValue("UseStarBonus", 0);
			this.int_3 = base.GetIntegerValue("GoldRewardStarBonus", 0);
			this.int_4 = base.GetIntegerValue("ElixirRewardStarBonus", 0);
			this.int_5 = base.GetIntegerValue("DarkElixirRewardStarBonus", 0);
			this.int_6 = base.GetIntegerValue("PlacementLimitLow", 0);
			this.int_7 = base.GetIntegerValue("PlacementLimitHigh", 0);
			this.int_8 = base.GetIntegerValue("DemoteLimit", 0);
			this.int_9 = base.GetIntegerValue("PromoteLimit", 0);
			this.bool_1 = base.GetBooleanValue("IgnoredByServer", 0);
			this.bool_2 = base.GetBooleanValue("DemoteEnabled", 0);
			this.bool_3 = base.GetBooleanValue("PromoteEnabled", 0);
			this.int_10 = base.GetIntegerValue("AllocateAmount", 0);
			this.int_11 = base.GetIntegerValue("SaverCount", 0);
			this.int_12 = base.GetIntegerValue("VillageGuardInMins", 0);
			int biggestArraySize = this.m_row.GetBiggestArraySize();
			this.int_13 = new int[biggestArraySize];
			this.int_14 = new int[biggestArraySize];
			this.int_15 = new int[biggestArraySize];
			this.int_16 = new int[biggestArraySize];
			for (int i = 0; i < biggestArraySize; i++)
			{
				this.int_13[i] = base.GetIntegerValue("BucketPlacementRangeLow", i);
				this.int_14[i] = base.GetIntegerValue("BucketPlacementRangeHigh", i);
				this.int_15[i] = base.GetIntegerValue("BucketPlacementSoftLimit", i);
				this.int_16[i] = base.GetIntegerValue("BucketPlacementHardLimit", i);
			}
		}

		// Token: 0x060013FF RID: 5119 RVA: 0x0000D392 File Offset: 0x0000B592
		public int GetBucketPlacementRangeLow(int index)
		{
			return this.int_13[index];
		}

		// Token: 0x06001400 RID: 5120 RVA: 0x0000D39C File Offset: 0x0000B59C
		public int GetBucketPlacementRangeHigh(int index)
		{
			return this.int_14[index];
		}

		// Token: 0x06001401 RID: 5121 RVA: 0x0000D3A6 File Offset: 0x0000B5A6
		public int GetBucketPlacementSoftLimit(int index)
		{
			return this.int_15[index];
		}

		// Token: 0x06001402 RID: 5122 RVA: 0x0000D3B0 File Offset: 0x0000B5B0
		public int GetBucketPlacementHardLimit(int index)
		{
			return this.int_16[index];
		}

		// Token: 0x06001403 RID: 5123 RVA: 0x0000D3BA File Offset: 0x0000B5BA
		public string GetLeagueBannerIcon()
		{
			return this.string_0;
		}

		// Token: 0x06001404 RID: 5124 RVA: 0x0000D3C2 File Offset: 0x0000B5C2
		public string GetLeagueBannerIconNum()
		{
			return this.string_1;
		}

		// Token: 0x06001405 RID: 5125 RVA: 0x0000D3CA File Offset: 0x0000B5CA
		public string GetLeagueBannerIconHUD()
		{
			return this.string_2;
		}

		// Token: 0x06001406 RID: 5126 RVA: 0x0000D3D2 File Offset: 0x0000B5D2
		public int GetGoldReward()
		{
			return this.int_0;
		}

		// Token: 0x06001407 RID: 5127 RVA: 0x0000D3DA File Offset: 0x0000B5DA
		public int GetElixirReward()
		{
			return this.int_1;
		}

		// Token: 0x06001408 RID: 5128 RVA: 0x0000D3E2 File Offset: 0x0000B5E2
		public int GetDarkElixirReward()
		{
			return this.int_2;
		}

		// Token: 0x06001409 RID: 5129 RVA: 0x0000D3EA File Offset: 0x0000B5EA
		public bool GetUseStarBonus()
		{
			return this.bool_0;
		}

		// Token: 0x0600140A RID: 5130 RVA: 0x0000D3F2 File Offset: 0x0000B5F2
		public int GetGoldRewardStarBonus()
		{
			return this.int_3;
		}

		// Token: 0x0600140B RID: 5131 RVA: 0x0000D3FA File Offset: 0x0000B5FA
		public int GetElixirRewardStarBonus()
		{
			return this.int_4;
		}

		// Token: 0x0600140C RID: 5132 RVA: 0x0000D402 File Offset: 0x0000B602
		public int GetDarkElixirRewardStarBonus()
		{
			return this.int_5;
		}

		// Token: 0x0600140D RID: 5133 RVA: 0x0000D40A File Offset: 0x0000B60A
		public int GetPlacementLimitLow()
		{
			return this.int_6;
		}

		// Token: 0x0600140E RID: 5134 RVA: 0x0000D412 File Offset: 0x0000B612
		public int GetPlacementLimitHigh()
		{
			return this.int_7;
		}

		// Token: 0x0600140F RID: 5135 RVA: 0x0000D41A File Offset: 0x0000B61A
		public int GetDemoteLimit()
		{
			return this.int_8;
		}

		// Token: 0x06001410 RID: 5136 RVA: 0x0000D422 File Offset: 0x0000B622
		public int GetPromoteLimit()
		{
			return this.int_9;
		}

		// Token: 0x06001411 RID: 5137 RVA: 0x0000D42A File Offset: 0x0000B62A
		public bool IsIgnoredByServer()
		{
			return this.bool_1;
		}

		// Token: 0x06001412 RID: 5138 RVA: 0x0000D432 File Offset: 0x0000B632
		public bool IsDemoteEnabled()
		{
			return this.bool_2;
		}

		// Token: 0x06001413 RID: 5139 RVA: 0x0000D43A File Offset: 0x0000B63A
		public bool IsPromoteEnabled()
		{
			return this.bool_3;
		}

		// Token: 0x06001414 RID: 5140 RVA: 0x0000D442 File Offset: 0x0000B642
		public int GetAllocateAmount()
		{
			return this.int_10;
		}

		// Token: 0x06001415 RID: 5141 RVA: 0x0000D44A File Offset: 0x0000B64A
		public int GetSaverCount()
		{
			return this.int_11;
		}

		// Token: 0x06001416 RID: 5142 RVA: 0x0000D452 File Offset: 0x0000B652
		public int GetVillageGuardInMins()
		{
			return this.int_12;
		}

		// Token: 0x04000A46 RID: 2630
		private string string_0;

		// Token: 0x04000A47 RID: 2631
		private string string_1;

		// Token: 0x04000A48 RID: 2632
		private string string_2;

		// Token: 0x04000A49 RID: 2633
		private int int_0;

		// Token: 0x04000A4A RID: 2634
		private int int_1;

		// Token: 0x04000A4B RID: 2635
		private int int_2;

		// Token: 0x04000A4C RID: 2636
		private int int_3;

		// Token: 0x04000A4D RID: 2637
		private int int_4;

		// Token: 0x04000A4E RID: 2638
		private int int_5;

		// Token: 0x04000A4F RID: 2639
		private int int_6;

		// Token: 0x04000A50 RID: 2640
		private int int_7;

		// Token: 0x04000A51 RID: 2641
		private int int_8;

		// Token: 0x04000A52 RID: 2642
		private int int_9;

		// Token: 0x04000A53 RID: 2643
		private int int_10;

		// Token: 0x04000A54 RID: 2644
		private int int_11;

		// Token: 0x04000A55 RID: 2645
		private int int_12;

		// Token: 0x04000A56 RID: 2646
		private int[] int_13;

		// Token: 0x04000A57 RID: 2647
		private int[] int_14;

		// Token: 0x04000A58 RID: 2648
		private int[] int_15;

		// Token: 0x04000A59 RID: 2649
		private int[] int_16;

		// Token: 0x04000A5A RID: 2650
		private bool bool_0;

		// Token: 0x04000A5B RID: 2651
		private bool bool_1;

		// Token: 0x04000A5C RID: 2652
		private bool bool_2;

		// Token: 0x04000A5D RID: 2653
		private bool bool_3;
	}
}
