using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000135 RID: 309
	public class LogicAllianceBadgeData : LogicData
	{
		// Token: 0x060010A9 RID: 4265 RVA: 0x0000B3C0 File Offset: 0x000095C0
		public LogicAllianceBadgeData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x060010AA RID: 4266 RVA: 0x0000B42A File Offset: 0x0000962A
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.string_0 = base.GetValue("IconLayer0", 0);
			this.string_1 = base.GetValue("IconLayer1", 0);
			this.string_2 = base.GetValue("IconLayer2", 0);
		}

		// Token: 0x040006F3 RID: 1779
		private string string_0;

		// Token: 0x040006F4 RID: 1780
		private string string_1;

		// Token: 0x040006F5 RID: 1781
		private string string_2;
	}
}
