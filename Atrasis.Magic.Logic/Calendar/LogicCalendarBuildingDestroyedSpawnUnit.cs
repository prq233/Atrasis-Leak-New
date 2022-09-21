using System;
using Atrasis.Magic.Logic.Data;

namespace Atrasis.Magic.Logic.Calendar
{
	// Token: 0x020001F3 RID: 499
	public class LogicCalendarBuildingDestroyedSpawnUnit
	{
		// Token: 0x06001962 RID: 6498 RVA: 0x00010E00 File Offset: 0x0000F000
		public LogicCalendarBuildingDestroyedSpawnUnit(LogicBuildingData buildingData, LogicCharacterData unitData, int count)
		{
			this.logicBuildingData_0 = buildingData;
			this.logicCharacterData_0 = unitData;
			this.int_0 = count;
		}

		// Token: 0x06001963 RID: 6499 RVA: 0x00010E1D File Offset: 0x0000F01D
		public LogicBuildingData GetBuildingData()
		{
			return this.logicBuildingData_0;
		}

		// Token: 0x06001964 RID: 6500 RVA: 0x00010E25 File Offset: 0x0000F025
		public LogicCharacterData GetCharacterData()
		{
			return this.logicCharacterData_0;
		}

		// Token: 0x06001965 RID: 6501 RVA: 0x00010E2D File Offset: 0x0000F02D
		public int GetCount()
		{
			return this.int_0;
		}

		// Token: 0x04000DAF RID: 3503
		private readonly LogicBuildingData logicBuildingData_0;

		// Token: 0x04000DB0 RID: 3504
		private readonly LogicCharacterData logicCharacterData_0;

		// Token: 0x04000DB1 RID: 3505
		private readonly int int_0;
	}
}
