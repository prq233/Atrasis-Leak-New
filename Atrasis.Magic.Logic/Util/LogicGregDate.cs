using System;

namespace Atrasis.Magic.Logic.Util
{
	// Token: 0x0200000C RID: 12
	public class LogicGregDate
	{
		// Token: 0x06000052 RID: 82 RVA: 0x000023F3 File Offset: 0x000005F3
		public LogicGregDate(int year, int month, int day)
		{
			this.int_0 = year;
			this.int_1 = month;
			this.int_2 = day;
			this.CalculateIndex();
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00002416 File Offset: 0x00000616
		public LogicGregDate(int index)
		{
			this.int_3 = index;
			this.CalculateDate();
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00013410 File Offset: 0x00011610
		public void CalculateIndex()
		{
			int num = this.int_0;
			int num2 = this.int_1;
			int num3 = this.int_2;
			if (num2 <= 2)
			{
				num--;
			}
			this.int_3 = 1461 * (num % 100) / 4 + (153 * (num2 + ((num2 <= 2) ? 9 : -3)) + 2) / 5 + num3 + 146097 * (num / 100) / 4 - 719469;
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00013478 File Offset: 0x00011678
		public void CalculateDate()
		{
			int num = 4 * this.int_3 + 2877875;
			int num2 = num % 146097 + (int)((uint)(num % 146097 >> 31) >> 30) | 3;
			int num3 = 5 * ((num2 % 1461 + 4) / 4);
			int num4 = num2 / 1461 + 100 * (num / 146097);
			int num5 = num3 / 153;
			int num6 = (num3 - 153 * (num3 / 153) + 2) / 5;
			if (num5 < 10)
			{
				num5 += 3;
			}
			else
			{
				num5 -= 9;
				num4++;
			}
			this.int_0 = num4;
			this.int_1 = num5;
			this.int_2 = num6;
		}

		// Token: 0x06000056 RID: 86 RVA: 0x0001351C File Offset: 0x0001171C
		public bool Validate()
		{
			int num = this.int_0;
			int num2 = this.int_1;
			int num3 = this.int_2;
			if (num2 <= 2)
			{
				num--;
			}
			int num4 = 1461 * (num % 100) / 4 + (153 * (num2 + ((num2 <= 2) ? 9 : -3)) + 2) / 5 + num3 + 146097 * (num / 100) / 4 - 719469;
			this.CalculateDate();
			return this.int_2 == num3 && this.int_1 == num2 && this.int_0 == num && this.int_3 == num4;
		}

		// Token: 0x06000057 RID: 87 RVA: 0x0000242B File Offset: 0x0000062B
		public int GetYear()
		{
			return this.int_0;
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00002433 File Offset: 0x00000633
		public int GetMonth()
		{
			return this.int_1;
		}

		// Token: 0x06000059 RID: 89 RVA: 0x0000243B File Offset: 0x0000063B
		public int GetDay()
		{
			return this.int_2;
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00002443 File Offset: 0x00000643
		public int GetIndex()
		{
			return this.int_3;
		}

		// Token: 0x0400002B RID: 43
		private int int_0;

		// Token: 0x0400002C RID: 44
		private int int_1;

		// Token: 0x0400002D RID: 45
		private int int_2;

		// Token: 0x0400002E RID: 46
		private int int_3;
	}
}
