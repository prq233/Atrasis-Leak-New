using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000162 RID: 354
	public class LogicResourcePackData : LogicData
	{
		// Token: 0x060014E1 RID: 5345 RVA: 0x0000B3C0 File Offset: 0x000095C0
		public LogicResourcePackData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x060014E2 RID: 5346 RVA: 0x0000DA29 File Offset: 0x0000BC29
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.logicResourceData_0 = LogicDataTables.GetResourceByName(base.GetValue("Resource", 0), this);
			this.int_0 = base.GetIntegerValue("CapacityPercentage", 0);
		}

		// Token: 0x060014E3 RID: 5347 RVA: 0x0000DA5B File Offset: 0x0000BC5B
		public LogicResourceData GetResourceData()
		{
			return this.logicResourceData_0;
		}

		// Token: 0x060014E4 RID: 5348 RVA: 0x0000DA63 File Offset: 0x0000BC63
		public int GetCapacityPercentage()
		{
			return this.int_0;
		}

		// Token: 0x04000B23 RID: 2851
		private LogicResourceData logicResourceData_0;

		// Token: 0x04000B24 RID: 2852
		private int int_0;
	}
}
