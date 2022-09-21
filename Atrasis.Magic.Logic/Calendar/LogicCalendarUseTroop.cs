using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Calendar
{
	// Token: 0x020001F9 RID: 505
	public class LogicCalendarUseTroop
	{
		// Token: 0x060019C2 RID: 6594 RVA: 0x000111F3 File Offset: 0x0000F3F3
		public LogicCalendarUseTroop(LogicCombatItemData data)
		{
			this.logicCombatItemData_0 = data;
			this.logicArrayList_0 = new LogicArrayList<int>();
		}

		// Token: 0x060019C3 RID: 6595 RVA: 0x0001120D File Offset: 0x0000F40D
		public LogicCombatItemData GetData()
		{
			return this.logicCombatItemData_0;
		}

		// Token: 0x060019C4 RID: 6596 RVA: 0x00011215 File Offset: 0x0000F415
		public void AddParameter(int parameter)
		{
			this.logicArrayList_0.Add(parameter);
		}

		// Token: 0x060019C5 RID: 6597 RVA: 0x00011223 File Offset: 0x0000F423
		public int GetParameter(int idx)
		{
			return this.logicArrayList_0[idx];
		}

		// Token: 0x04000DDB RID: 3547
		private readonly LogicCombatItemData logicCombatItemData_0;

		// Token: 0x04000DDC RID: 3548
		private readonly LogicArrayList<int> logicArrayList_0;
	}
}
