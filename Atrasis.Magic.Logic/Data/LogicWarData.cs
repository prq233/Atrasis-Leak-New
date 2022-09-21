using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000169 RID: 361
	public class LogicWarData : LogicData
	{
		// Token: 0x06001599 RID: 5529 RVA: 0x0000B3C0 File Offset: 0x000095C0
		public LogicWarData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x0600159A RID: 5530 RVA: 0x000539A4 File Offset: 0x00051BA4
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.int_0 = base.GetIntegerValue("TeamSize", 0);
			this.int_1 = base.GetIntegerValue("PreparationMinutes", 0);
			this.int_2 = base.GetIntegerValue("WarMinutes", 0);
			this.bool_0 = base.GetBooleanValue("DisableProduction", 0);
		}

		// Token: 0x0600159B RID: 5531 RVA: 0x0000E0FB File Offset: 0x0000C2FB
		public int GetTeamSize()
		{
			return this.int_0;
		}

		// Token: 0x0600159C RID: 5532 RVA: 0x0000E103 File Offset: 0x0000C303
		public int GetPreparationMinutes()
		{
			return this.int_1;
		}

		// Token: 0x0600159D RID: 5533 RVA: 0x0000E10B File Offset: 0x0000C30B
		public int GetWarMinutes()
		{
			return this.int_2;
		}

		// Token: 0x0600159E RID: 5534 RVA: 0x0000E113 File Offset: 0x0000C313
		public bool IsDisableProduction()
		{
			return this.bool_0;
		}

		// Token: 0x04000BCC RID: 3020
		private int int_0;

		// Token: 0x04000BCD RID: 3021
		private int int_1;

		// Token: 0x04000BCE RID: 3022
		private int int_2;

		// Token: 0x04000BCF RID: 3023
		private bool bool_0;
	}
}
