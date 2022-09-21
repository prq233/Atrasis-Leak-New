using System;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000149 RID: 329
	public class LogicDataTableResource
	{
		// Token: 0x06001241 RID: 4673 RVA: 0x0000C36D File Offset: 0x0000A56D
		public LogicDataTableResource(string fileName, LogicDataType tableIndex, int type)
		{
			this.string_0 = fileName;
			this.logicDataType_0 = tableIndex;
			this.int_0 = type;
		}

		// Token: 0x06001242 RID: 4674 RVA: 0x0000C38A File Offset: 0x0000A58A
		public void Destruct()
		{
			this.string_0 = null;
			this.logicDataType_0 = LogicDataType.BUILDING;
			this.int_0 = 0;
		}

		// Token: 0x06001243 RID: 4675 RVA: 0x0000C3A1 File Offset: 0x0000A5A1
		public string GetFileName()
		{
			return this.string_0;
		}

		// Token: 0x06001244 RID: 4676 RVA: 0x0000C3A9 File Offset: 0x0000A5A9
		public LogicDataType GetTableIndex()
		{
			return this.logicDataType_0;
		}

		// Token: 0x06001245 RID: 4677 RVA: 0x0000C3B1 File Offset: 0x0000A5B1
		public int GetTableType()
		{
			return this.int_0;
		}

		// Token: 0x040008B2 RID: 2226
		private string string_0;

		// Token: 0x040008B3 RID: 2227
		private LogicDataType logicDataType_0;

		// Token: 0x040008B4 RID: 2228
		private int int_0;
	}
}
