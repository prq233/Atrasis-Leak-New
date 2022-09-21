using System;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Titan.CSV
{
	// Token: 0x02000029 RID: 41
	public class CSVRow
	{
		// Token: 0x0600015E RID: 350 RVA: 0x000050F6 File Offset: 0x000032F6
		public CSVRow(CSVTable table)
		{
			this.csvtable_0 = table;
			this.int_0 = table.GetColumnRowCount();
		}

		// Token: 0x0600015F RID: 351 RVA: 0x0000824C File Offset: 0x0000644C
		public int GetArraySize(string column)
		{
			int columnIndexByName = this.GetColumnIndexByName(column);
			if (columnIndexByName == -1)
			{
				return 0;
			}
			return this.csvtable_0.GetArraySizeAt(this, columnIndexByName);
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00008274 File Offset: 0x00006474
		public int GetBiggestArraySize()
		{
			int columnCount = this.csvtable_0.GetColumnCount();
			int num = 1;
			for (int i = columnCount - 1; i >= 0; i--)
			{
				num = LogicMath.Max(this.csvtable_0.GetArraySizeAt(this, i), num);
			}
			return num;
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00005111 File Offset: 0x00003311
		public int GetColumnCount()
		{
			return this.csvtable_0.GetColumnCount();
		}

		// Token: 0x06000162 RID: 354 RVA: 0x0000511E File Offset: 0x0000331E
		public int GetColumnIndexByName(string name)
		{
			return this.csvtable_0.GetColumnIndexByName(name);
		}

		// Token: 0x06000163 RID: 355 RVA: 0x0000512C File Offset: 0x0000332C
		public bool GetBooleanValue(string columnName, int index)
		{
			return this.csvtable_0.GetBooleanValue(columnName, this.int_0 + index);
		}

		// Token: 0x06000164 RID: 356 RVA: 0x00005142 File Offset: 0x00003342
		public bool GetBooleanValueAt(int columnIndex, int index)
		{
			return this.csvtable_0.GetBooleanValueAt(columnIndex, this.int_0 + index);
		}

		// Token: 0x06000165 RID: 357 RVA: 0x000082B0 File Offset: 0x000064B0
		public bool GetClampedBooleanValue(string columnName, int index)
		{
			int columnIndexByName = this.GetColumnIndexByName(columnName);
			if (columnIndexByName != -1)
			{
				int arraySizeAt = this.csvtable_0.GetArraySizeAt(this, columnIndexByName);
				if (index >= arraySizeAt || arraySizeAt < 1)
				{
					index = LogicMath.Max(arraySizeAt - 1, 0);
				}
				return this.csvtable_0.GetBooleanValueAt(columnIndexByName, this.int_0 + index);
			}
			return false;
		}

		// Token: 0x06000166 RID: 358 RVA: 0x00005158 File Offset: 0x00003358
		public int GetIntegerValue(string columnName, int index)
		{
			return this.csvtable_0.GetIntegerValue(columnName, this.int_0 + index);
		}

		// Token: 0x06000167 RID: 359 RVA: 0x0000516E File Offset: 0x0000336E
		public int GetIntegerValueAt(int columnIndex, int index)
		{
			return this.csvtable_0.GetIntegerValueAt(columnIndex, this.int_0 + index);
		}

		// Token: 0x06000168 RID: 360 RVA: 0x00008300 File Offset: 0x00006500
		public int GetClampedIntegerValue(string columnName, int index)
		{
			int columnIndexByName = this.GetColumnIndexByName(columnName);
			if (columnIndexByName != -1)
			{
				int arraySizeAt = this.csvtable_0.GetArraySizeAt(this, columnIndexByName);
				if (index >= arraySizeAt || arraySizeAt < 1)
				{
					index = LogicMath.Max(arraySizeAt - 1, 0);
				}
				return this.csvtable_0.GetIntegerValueAt(columnIndexByName, this.int_0 + index);
			}
			return 0;
		}

		// Token: 0x06000169 RID: 361 RVA: 0x00005184 File Offset: 0x00003384
		public string GetValue(string columnName, int index)
		{
			return this.csvtable_0.GetValue(columnName, this.int_0 + index);
		}

		// Token: 0x0600016A RID: 362 RVA: 0x0000519A File Offset: 0x0000339A
		public string GetValueAt(int columnIndex, int index)
		{
			return this.csvtable_0.GetValueAt(columnIndex, this.int_0 + index);
		}

		// Token: 0x0600016B RID: 363 RVA: 0x00008350 File Offset: 0x00006550
		public string GetClampedValue(string columnName, int index)
		{
			int columnIndexByName = this.GetColumnIndexByName(columnName);
			if (columnIndexByName != -1)
			{
				int arraySizeAt = this.csvtable_0.GetArraySizeAt(this, columnIndexByName);
				if (index >= arraySizeAt || arraySizeAt < 1)
				{
					index = LogicMath.Max(arraySizeAt - 1, 0);
				}
				return this.csvtable_0.GetValueAt(columnIndexByName, this.int_0 + index);
			}
			return string.Empty;
		}

		// Token: 0x0600016C RID: 364 RVA: 0x000051B0 File Offset: 0x000033B0
		public string GetName()
		{
			return this.csvtable_0.GetValueAt(0, this.int_0);
		}

		// Token: 0x0600016D RID: 365 RVA: 0x000051C4 File Offset: 0x000033C4
		public int GetRowOffset()
		{
			return this.int_0;
		}

		// Token: 0x0400004C RID: 76
		private readonly int int_0;

		// Token: 0x0400004D RID: 77
		private readonly CSVTable csvtable_0;
	}
}
