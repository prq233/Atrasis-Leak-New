using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x0200014C RID: 332
	public class LogicDeeplinkData : LogicData
	{
		// Token: 0x06001288 RID: 4744 RVA: 0x0000B3C0 File Offset: 0x000095C0
		public LogicDeeplinkData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x06001289 RID: 4745 RVA: 0x0004E2FC File Offset: 0x0004C4FC
		public override void CreateReferences()
		{
			base.CreateReferences();
			int arraySize = base.GetArraySize("ParameterType");
			this.string_0 = new string[arraySize];
			this.string_1 = new string[arraySize];
			this.string_2 = new string[arraySize];
			for (int i = 0; i < arraySize; i++)
			{
				this.string_0[i] = base.GetValue("ParameterType", i);
				this.string_1[i] = base.GetValue("ParameterName", i);
				this.string_2[i] = base.GetValue("Description", i);
			}
		}

		// Token: 0x0600128A RID: 4746 RVA: 0x0000C750 File Offset: 0x0000A950
		public string GetParameterType(int index)
		{
			return this.string_0[index];
		}

		// Token: 0x0600128B RID: 4747 RVA: 0x0000C75A File Offset: 0x0000A95A
		public string GetParameterName(int index)
		{
			return this.string_1[index];
		}

		// Token: 0x0600128C RID: 4748 RVA: 0x0000C764 File Offset: 0x0000A964
		public string GetDescription(int index)
		{
			return this.string_2[index];
		}

		// Token: 0x040008D3 RID: 2259
		private string[] string_0;

		// Token: 0x040008D4 RID: 2260
		private string[] string_1;

		// Token: 0x040008D5 RID: 2261
		private string[] string_2;
	}
}
