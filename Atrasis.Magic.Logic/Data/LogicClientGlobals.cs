using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000143 RID: 323
	public class LogicClientGlobals : LogicDataTable
	{
		// Token: 0x060011FF RID: 4607 RVA: 0x0000C0DF File Offset: 0x0000A2DF
		public LogicClientGlobals(CSVTable table, LogicDataType index) : base(table, index)
		{
		}

		// Token: 0x06001200 RID: 4608 RVA: 0x0000C0E9 File Offset: 0x0000A2E9
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.bool_2 = this.method_1("USE_PEPPER_CRYPTO");
			this.bool_3 = this.method_1("POWER_SAVE_MODE_LESS_ENDTURN_MESSAGES");
		}

		// Token: 0x06001201 RID: 4609 RVA: 0x0000C113 File Offset: 0x0000A313
		private LogicGlobalData method_0(string string_1)
		{
			return LogicDataTables.GetClientGlobalByName(string_1, null);
		}

		// Token: 0x06001202 RID: 4610 RVA: 0x0000C11C File Offset: 0x0000A31C
		private bool method_1(string string_1)
		{
			return this.method_0(string_1).GetBooleanValue();
		}

		// Token: 0x06001203 RID: 4611 RVA: 0x0000C12A File Offset: 0x0000A32A
		private int method_2(string string_1)
		{
			return this.method_0(string_1).GetNumberValue();
		}

		// Token: 0x06001204 RID: 4612 RVA: 0x0000C138 File Offset: 0x0000A338
		public bool PepperEnabled()
		{
			return this.bool_2;
		}

		// Token: 0x06001205 RID: 4613 RVA: 0x0000C140 File Offset: 0x0000A340
		public bool PowerSaveModeLessEndTurnMessages()
		{
			return this.bool_3;
		}

		// Token: 0x04000864 RID: 2148
		private bool bool_2;

		// Token: 0x04000865 RID: 2149
		private bool bool_3;
	}
}
