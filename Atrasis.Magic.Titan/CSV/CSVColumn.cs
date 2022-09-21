using System;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Titan.CSV
{
	// Token: 0x02000027 RID: 39
	public class CSVColumn
	{
		// Token: 0x0600014E RID: 334 RVA: 0x00007E68 File Offset: 0x00006068
		public CSVColumn(int type, int size)
		{
			this.int_0 = type;
			this.logicArrayList_1 = new LogicArrayList<int>();
			this.logicArrayList_0 = new LogicArrayList<byte>();
			this.logicArrayList_2 = new LogicArrayList<string>();
			switch (type)
			{
			case -1:
			case 0:
				this.logicArrayList_2.EnsureCapacity(size);
				return;
			case 1:
				this.logicArrayList_1.EnsureCapacity(size);
				return;
			case 2:
				this.logicArrayList_0.EnsureCapacity(size);
				return;
			default:
				Debugger.Error("Invalid CSVColumn type");
				return;
			}
		}

		// Token: 0x0600014F RID: 335 RVA: 0x00007EEC File Offset: 0x000060EC
		public void AddEmptyValue()
		{
			switch (this.int_0)
			{
			case -1:
			case 0:
				this.logicArrayList_2.Add(string.Empty);
				return;
			case 1:
				this.logicArrayList_1.Add(int.MaxValue);
				return;
			case 2:
				this.logicArrayList_0.Add(2);
				return;
			default:
				return;
			}
		}

		// Token: 0x06000150 RID: 336 RVA: 0x0000506A File Offset: 0x0000326A
		public void AddBooleanValue(bool value)
		{
			this.logicArrayList_0.Add(value ? 1 : 0);
		}

		// Token: 0x06000151 RID: 337 RVA: 0x0000507F File Offset: 0x0000327F
		public void AddIntegerValue(int value)
		{
			this.logicArrayList_1.Add(value);
		}

		// Token: 0x06000152 RID: 338 RVA: 0x0000508D File Offset: 0x0000328D
		public void AddStringValue(string value)
		{
			this.logicArrayList_2.Add(value);
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00007F48 File Offset: 0x00006148
		public int GetArraySize(int startOffset, int endOffset)
		{
			int num = this.int_0;
			if (num != 1)
			{
				if (num != 2)
				{
					int num2 = endOffset - 1;
					while (num2 + 1 > startOffset)
					{
						if (this.logicArrayList_2[num2].Length > 0)
						{
							return num2 - startOffset + 1;
						}
						num2--;
					}
				}
				else
				{
					int num3 = endOffset - 1;
					while (num3 + 1 > startOffset)
					{
						if (this.logicArrayList_0[num3] != 2)
						{
							return num3 - startOffset + 1;
						}
						num3--;
					}
				}
			}
			else
			{
				int num4 = endOffset - 1;
				while (num4 + 1 > startOffset)
				{
					if (this.logicArrayList_1[num4] != 2147483647)
					{
						return num4 - startOffset + 1;
					}
					num4--;
				}
			}
			return 0;
		}

		// Token: 0x06000154 RID: 340 RVA: 0x0000509B File Offset: 0x0000329B
		public bool GetBooleanValue(int index)
		{
			return this.logicArrayList_0[index] == 1;
		}

		// Token: 0x06000155 RID: 341 RVA: 0x000050AC File Offset: 0x000032AC
		public int GetIntegerValue(int index)
		{
			return this.logicArrayList_1[index];
		}

		// Token: 0x06000156 RID: 342 RVA: 0x000050BA File Offset: 0x000032BA
		public string GetStringValue(int index)
		{
			return this.logicArrayList_2[index];
		}

		// Token: 0x06000157 RID: 343 RVA: 0x00007FE8 File Offset: 0x000061E8
		public int GetSize()
		{
			switch (this.int_0)
			{
			case -1:
			case 0:
				return this.logicArrayList_2.Size();
			case 1:
				return this.logicArrayList_1.Size();
			case 2:
				return this.logicArrayList_0.Size();
			default:
				return 0;
			}
		}

		// Token: 0x06000158 RID: 344 RVA: 0x000050C8 File Offset: 0x000032C8
		public int GetColumnType()
		{
			return this.int_0;
		}

		// Token: 0x04000044 RID: 68
		public const int BOOLEAN_VALUE_NOT_SET = 2;

		// Token: 0x04000045 RID: 69
		public const int INT_VALUE_NOT_SET = 2147483647;

		// Token: 0x04000046 RID: 70
		private readonly LogicArrayList<byte> logicArrayList_0;

		// Token: 0x04000047 RID: 71
		private readonly LogicArrayList<int> logicArrayList_1;

		// Token: 0x04000048 RID: 72
		private readonly LogicArrayList<string> logicArrayList_2;

		// Token: 0x04000049 RID: 73
		private readonly int int_0;
	}
}
