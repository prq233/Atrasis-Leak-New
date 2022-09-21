using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x0200014F RID: 335
	public class LogicExperienceLevelData : LogicData
	{
		// Token: 0x060012D5 RID: 4821 RVA: 0x0000B3C0 File Offset: 0x000095C0
		public LogicExperienceLevelData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x060012D6 RID: 4822 RVA: 0x0000C9B7 File Offset: 0x0000ABB7
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.int_0 = base.GetIntegerValue("ExpPoints", 0);
		}

		// Token: 0x060012D7 RID: 4823 RVA: 0x0000C9D1 File Offset: 0x0000ABD1
		public int GetMaxExpPoints()
		{
			return this.int_0;
		}

		// Token: 0x060012D8 RID: 4824 RVA: 0x0000C9D9 File Offset: 0x0000ABD9
		public static int GetLevelCap()
		{
			return LogicDataTables.GetTable(LogicDataType.EXPERIENCE_LEVEL).GetItemCount();
		}

		// Token: 0x040008FA RID: 2298
		private int int_0;
	}
}
