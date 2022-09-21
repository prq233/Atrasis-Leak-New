using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000152 RID: 338
	public class LogicGlobalData : LogicData
	{
		// Token: 0x060012E4 RID: 4836 RVA: 0x0000B3C0 File Offset: 0x000095C0
		public LogicGlobalData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x060012E5 RID: 4837 RVA: 0x0004EBF4 File Offset: 0x0004CDF4
		public override void CreateReferences()
		{
			base.CreateReferences();
			int biggestArraySize = this.m_row.GetBiggestArraySize();
			this.int_1 = new int[biggestArraySize];
			this.int_2 = new int[biggestArraySize];
			this.string_1 = new string[biggestArraySize];
			this.int_0 = base.GetIntegerValue("NumberValue", 0);
			this.bool_0 = base.GetBooleanValue("BooleanValue", 0);
			this.string_0 = base.GetValue("TextValue", 0);
			for (int i = 0; i < biggestArraySize; i++)
			{
				this.int_1[i] = base.GetIntegerValue("NumberArray", i);
				this.int_2[i] = base.GetIntegerValue("AltNumberArray", i);
				this.string_1[i] = base.GetValue("StringArray", i);
			}
		}

		// Token: 0x060012E6 RID: 4838 RVA: 0x0000CA39 File Offset: 0x0000AC39
		public int GetNumberValue()
		{
			return this.int_0;
		}

		// Token: 0x060012E7 RID: 4839 RVA: 0x0000CA41 File Offset: 0x0000AC41
		public bool GetBooleanValue()
		{
			return this.bool_0;
		}

		// Token: 0x060012E8 RID: 4840 RVA: 0x0000CA49 File Offset: 0x0000AC49
		public string GetTextValue()
		{
			return this.string_0;
		}

		// Token: 0x060012E9 RID: 4841 RVA: 0x0000CA51 File Offset: 0x0000AC51
		public int GetNumberArraySize()
		{
			return this.int_1.Length;
		}

		// Token: 0x060012EA RID: 4842 RVA: 0x0000CA5B File Offset: 0x0000AC5B
		public int GetNumberArray(int index)
		{
			return this.int_1[index];
		}

		// Token: 0x060012EB RID: 4843 RVA: 0x0000CA65 File Offset: 0x0000AC65
		public int GetAltNumberArray(int index)
		{
			return this.int_2[index];
		}

		// Token: 0x04000924 RID: 2340
		private int int_0;

		// Token: 0x04000925 RID: 2341
		private bool bool_0;

		// Token: 0x04000926 RID: 2342
		private string string_0;

		// Token: 0x04000927 RID: 2343
		private int[] int_1;

		// Token: 0x04000928 RID: 2344
		private int[] int_2;

		// Token: 0x04000929 RID: 2345
		private string[] string_1;
	}
}
