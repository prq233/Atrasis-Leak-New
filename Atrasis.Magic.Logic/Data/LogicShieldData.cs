using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000164 RID: 356
	public class LogicShieldData : LogicData
	{
		// Token: 0x060014E7 RID: 5351 RVA: 0x0000B3C0 File Offset: 0x000095C0
		public LogicShieldData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x060014E8 RID: 5352 RVA: 0x00052458 File Offset: 0x00050658
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.int_0 = base.GetIntegerValue("Diamonds", 0);
			this.int_1 = base.GetIntegerValue("CooldownS", 0);
			this.int_2 = base.GetIntegerValue("LockedAboveScore", 0);
			this.int_3 = base.GetIntegerValue("TimeH", 0);
			this.int_4 = base.GetIntegerValue("GuardTimeH", 0);
		}

		// Token: 0x060014E9 RID: 5353 RVA: 0x0000DA6B File Offset: 0x0000BC6B
		public int GetDiamondsCost()
		{
			return this.int_0;
		}

		// Token: 0x060014EA RID: 5354 RVA: 0x0000DA73 File Offset: 0x0000BC73
		public int GetCooldownSecs()
		{
			return this.int_1;
		}

		// Token: 0x060014EB RID: 5355 RVA: 0x0000DA7B File Offset: 0x0000BC7B
		public int GetScoreLimit()
		{
			return this.int_2;
		}

		// Token: 0x060014EC RID: 5356 RVA: 0x0000DA83 File Offset: 0x0000BC83
		public int GetTimeHours()
		{
			return this.int_3;
		}

		// Token: 0x060014ED RID: 5357 RVA: 0x0000DA8B File Offset: 0x0000BC8B
		public int GetGuardTimeHours()
		{
			return this.int_4;
		}

		// Token: 0x04000B25 RID: 2853
		private int int_0;

		// Token: 0x04000B26 RID: 2854
		private int int_1;

		// Token: 0x04000B27 RID: 2855
		private int int_2;

		// Token: 0x04000B28 RID: 2856
		private int int_3;

		// Token: 0x04000B29 RID: 2857
		private int int_4;
	}
}
