using System;
using Atrasis.Magic.Logic.Data;

namespace Atrasis.Magic.Logic.Util
{
	// Token: 0x02000012 RID: 18
	public class LogicUnitProductionSlot
	{
		// Token: 0x0600009F RID: 159 RVA: 0x00002606 File Offset: 0x00000806
		public LogicUnitProductionSlot(LogicData data, int count, bool terminate)
		{
			this.logicData_0 = data;
			this.int_0 = count;
			this.bool_0 = terminate;
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00002623 File Offset: 0x00000823
		public void Destruct()
		{
			this.logicData_0 = null;
			this.int_0 = 0;
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00002633 File Offset: 0x00000833
		public LogicData GetData()
		{
			return this.logicData_0;
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x0000263B File Offset: 0x0000083B
		public int GetCount()
		{
			return this.int_0;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00002643 File Offset: 0x00000843
		public void SetCount(int count)
		{
			this.int_0 = count;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x0000264C File Offset: 0x0000084C
		public bool IsTerminate()
		{
			return this.bool_0;
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00002654 File Offset: 0x00000854
		public void SetTerminate(bool terminate)
		{
			this.bool_0 = terminate;
		}

		// Token: 0x0400005A RID: 90
		private LogicData logicData_0;

		// Token: 0x0400005B RID: 91
		private int int_0;

		// Token: 0x0400005C RID: 92
		private bool bool_0;
	}
}
