using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000139 RID: 313
	public class LogicAlliancePortalData : LogicGameObjectData
	{
		// Token: 0x060010BB RID: 4283 RVA: 0x0000B4F2 File Offset: 0x000096F2
		public LogicAlliancePortalData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x060010BC RID: 4284 RVA: 0x0004ABF0 File Offset: 0x00048DF0
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.string_0 = base.GetValue("SWF", 0);
			this.string_1 = base.GetValue("ExportName", 0);
			this.int_0 = base.GetIntegerValue("Width", 0);
			this.int_1 = base.GetIntegerValue("Height", 0);
		}

		// Token: 0x060010BD RID: 4285 RVA: 0x0000B4FC File Offset: 0x000096FC
		public int GetWidth()
		{
			return this.int_0;
		}

		// Token: 0x060010BE RID: 4286 RVA: 0x0000B504 File Offset: 0x00009704
		public int GetHeight()
		{
			return this.int_1;
		}

		// Token: 0x04000705 RID: 1797
		private string string_0;

		// Token: 0x04000706 RID: 1798
		private string string_1;

		// Token: 0x04000707 RID: 1799
		private int int_0;

		// Token: 0x04000708 RID: 1800
		private int int_1;
	}
}
