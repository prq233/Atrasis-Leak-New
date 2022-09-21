using System;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Titan.CSV
{
	// Token: 0x0200002A RID: 42
	public class CSVTable
	{
		// Token: 0x0600016E RID: 366 RVA: 0x000051CC File Offset: 0x000033CC
		public CSVTable(CSVNode node, int size)
		{
			this.logicArrayList_0 = new LogicArrayList<string>();
			this.logicArrayList_1 = new LogicArrayList<CSVColumn>();
			this.logicArrayList_2 = new LogicArrayList<CSVRow>();
			this.csvnode_0 = node;
			this.int_0 = size;
		}

		// Token: 0x0600016F RID: 367 RVA: 0x000083A4 File Offset: 0x000065A4
		public void AddAndConvertValue(string value, int columnIndex)
		{
			CSVColumn csvcolumn = this.logicArrayList_1[columnIndex];
			if (string.IsNullOrEmpty(value))
			{
				csvcolumn.AddEmptyValue();
				return;
			}
			switch (csvcolumn.GetColumnType())
			{
			case -1:
			case 0:
				csvcolumn.AddStringValue(value);
				return;
			case 1:
				csvcolumn.AddIntegerValue(int.Parse(value));
				return;
			case 2:
			{
				bool value2;
				if (bool.TryParse(value, out value2))
				{
					csvcolumn.AddBooleanValue(value2);
					return;
				}
				Debugger.Warning(string.Format("CSVTable::addAndConvertValue invalid value '{0}' in Boolean column '{1}', {2}", value, this.logicArrayList_0[columnIndex], this.GetFileName()));
				csvcolumn.AddBooleanValue(false);
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x06000170 RID: 368 RVA: 0x00005203 File Offset: 0x00003403
		public void AddColumn(string name)
		{
			this.logicArrayList_0.Add(name);
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00005211 File Offset: 0x00003411
		public void AddColumnType(int type)
		{
			this.logicArrayList_1.Add(new CSVColumn(type, this.int_0));
		}

		// Token: 0x06000172 RID: 370 RVA: 0x0000522A File Offset: 0x0000342A
		public void AddRow(CSVRow row)
		{
			this.logicArrayList_2.Add(row);
		}

		// Token: 0x06000173 RID: 371 RVA: 0x00005238 File Offset: 0x00003438
		public void ColumnNamesLoaded()
		{
			this.logicArrayList_1.EnsureCapacity(this.logicArrayList_0.Size());
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00005250 File Offset: 0x00003450
		public void CreateRow()
		{
			this.logicArrayList_2.Add(new CSVRow(this));
		}

		// Token: 0x06000175 RID: 373 RVA: 0x00008440 File Offset: 0x00006640
		public int GetArraySizeAt(CSVRow row, int columnIdx)
		{
			if (this.logicArrayList_2.Size() > 0)
			{
				int num = this.logicArrayList_2.IndexOf(row);
				if (num != -1)
				{
					CSVColumn csvcolumn = this.logicArrayList_1[columnIdx];
					return csvcolumn.GetArraySize(this.logicArrayList_2[num].GetRowOffset(), (num + 1 >= this.logicArrayList_2.Size()) ? csvcolumn.GetSize() : this.logicArrayList_2[num + 1].GetRowOffset());
				}
			}
			return 0;
		}

		// Token: 0x06000176 RID: 374 RVA: 0x00005263 File Offset: 0x00003463
		public string GetColumnName(int idx)
		{
			return this.logicArrayList_0[idx];
		}

		// Token: 0x06000177 RID: 375 RVA: 0x00005271 File Offset: 0x00003471
		public int GetColumnIndexByName(string name)
		{
			return this.logicArrayList_0.IndexOf(name);
		}

		// Token: 0x06000178 RID: 376 RVA: 0x0000527F File Offset: 0x0000347F
		public int GetColumnCount()
		{
			return this.logicArrayList_0.Size();
		}

		// Token: 0x06000179 RID: 377 RVA: 0x0000528C File Offset: 0x0000348C
		public int GetColumnRowCount()
		{
			return this.logicArrayList_1[0].GetSize();
		}

		// Token: 0x0600017A RID: 378 RVA: 0x0000529F File Offset: 0x0000349F
		public int GetColumnTypeCount()
		{
			return this.logicArrayList_1.Size();
		}

		// Token: 0x0600017B RID: 379 RVA: 0x000052AC File Offset: 0x000034AC
		public string GetFileName()
		{
			return this.csvnode_0.GetFileName();
		}

		// Token: 0x0600017C RID: 380 RVA: 0x000052B9 File Offset: 0x000034B9
		public bool GetBooleanValue(string name, int index)
		{
			return this.GetBooleanValueAt(this.logicArrayList_0.IndexOf(name), index);
		}

		// Token: 0x0600017D RID: 381 RVA: 0x000052CE File Offset: 0x000034CE
		public bool GetBooleanValueAt(int columnIndex, int index)
		{
			return columnIndex != -1 && this.logicArrayList_1[columnIndex].GetBooleanValue(index);
		}

		// Token: 0x0600017E RID: 382 RVA: 0x000052E8 File Offset: 0x000034E8
		public int GetIntegerValue(string name, int index)
		{
			return this.GetIntegerValueAt(this.logicArrayList_0.IndexOf(name), index);
		}

		// Token: 0x0600017F RID: 383 RVA: 0x000084C0 File Offset: 0x000066C0
		public int GetIntegerValueAt(int columnIndex, int index)
		{
			if (columnIndex != -1)
			{
				int num = this.logicArrayList_1[columnIndex].GetIntegerValue(index);
				if (num == 2147483647)
				{
					num = 0;
				}
				return num;
			}
			return 0;
		}

		// Token: 0x06000180 RID: 384 RVA: 0x000052FD File Offset: 0x000034FD
		public string GetValue(string name, int index)
		{
			return this.GetValueAt(this.logicArrayList_0.IndexOf(name), index);
		}

		// Token: 0x06000181 RID: 385 RVA: 0x00005312 File Offset: 0x00003512
		public string GetValueAt(int columnIndex, int index)
		{
			if (columnIndex != -1)
			{
				return this.logicArrayList_1[columnIndex].GetStringValue(index);
			}
			return string.Empty;
		}

		// Token: 0x06000182 RID: 386 RVA: 0x00005330 File Offset: 0x00003530
		public CSVRow GetRowAt(int index)
		{
			return this.logicArrayList_2[index];
		}

		// Token: 0x06000183 RID: 387 RVA: 0x0000533E File Offset: 0x0000353E
		public CSVColumn GetCSVColumn(int index)
		{
			return this.logicArrayList_1[index];
		}

		// Token: 0x06000184 RID: 388 RVA: 0x0000534C File Offset: 0x0000354C
		public int GetRowCount()
		{
			return this.logicArrayList_2.Size();
		}

		// Token: 0x06000185 RID: 389 RVA: 0x000084F4 File Offset: 0x000066F4
		public void ValidateColumnTypes()
		{
			if (this.logicArrayList_0.Size() != this.logicArrayList_1.Size())
			{
				Debugger.Warning(string.Format("Column name count {0}, column type count {1}, file {2}", this.logicArrayList_0.Size(), this.logicArrayList_1.Size(), this.GetFileName()));
			}
		}

		// Token: 0x0400004E RID: 78
		private readonly LogicArrayList<string> logicArrayList_0;

		// Token: 0x0400004F RID: 79
		private readonly LogicArrayList<CSVColumn> logicArrayList_1;

		// Token: 0x04000050 RID: 80
		private readonly LogicArrayList<CSVRow> logicArrayList_2;

		// Token: 0x04000051 RID: 81
		private readonly CSVNode csvnode_0;

		// Token: 0x04000052 RID: 82
		private readonly int int_0;
	}
}
