using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000154 RID: 340
	public class LogicHelpshiftData : LogicData
	{
		// Token: 0x060013C8 RID: 5064 RVA: 0x0000B3C0 File Offset: 0x000095C0
		public LogicHelpshiftData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x060013C9 RID: 5065 RVA: 0x0000D196 File Offset: 0x0000B396
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.string_0 = base.GetValue("HelpshiftId", 0);
		}

		// Token: 0x04000A1B RID: 2587
		private string string_0;
	}
}
