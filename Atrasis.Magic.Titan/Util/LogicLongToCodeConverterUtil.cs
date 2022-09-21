using System;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Titan.Util
{
	// Token: 0x02000006 RID: 6
	public class LogicLongToCodeConverterUtil
	{
		// Token: 0x06000019 RID: 25 RVA: 0x00004365 File Offset: 0x00002565
		public LogicLongToCodeConverterUtil(string hashTag, string conversionChars)
		{
			this.string_0 = hashTag;
			this.string_1 = conversionChars;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00005680 File Offset: 0x00003880
		public string ToCode(LogicLong logicLong)
		{
			int higherInt = logicLong.GetHigherInt();
			if (higherInt < 256)
			{
				return this.string_0 + this.method_1((long)logicLong.GetLowerInt() << 8 | (long)((ulong)higherInt));
			}
			Debugger.Warning("Cannot convert the code to string. Higher int value too large");
			return null;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000056C8 File Offset: 0x000038C8
		public LogicLong ToId(string code)
		{
			if (code.Length < 14)
			{
				string string_ = code.Substring(1);
				long num = this.method_0(string_);
				if (num != -1L)
				{
					return new LogicLong((int)(num % 256L), (int)(num >> 8 & 2147483647L));
				}
			}
			else
			{
				Debugger.Warning("Cannot convert the string to code. String is too long.");
			}
			return new LogicLong(-1, -1);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x0000572C File Offset: 0x0000392C
		private long method_0(string string_2)
		{
			long num = 0L;
			int length = this.string_1.Length;
			int length2 = string_2.Length;
			for (int i = 0; i < length2; i++)
			{
				int num2 = this.string_1.IndexOf(string_2[i]);
				if (num2 == -1)
				{
					Debugger.Warning("Cannot convert the string to code. String contains invalid character(s).");
					num = -1L;
					return num;
				}
				num = num * (long)length + (long)num2;
			}
			return num;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000057A0 File Offset: 0x000039A0
		private string method_1(long long_0)
		{
			char[] array = new char[12];
			if (long_0 > -1L)
			{
				int length = this.string_1.Length;
				for (int i = 11; i >= 0; i--)
				{
					array[i] = this.string_1[(int)(long_0 % (long)length)];
					long_0 /= (long)length;
					if (long_0 == 0L)
					{
						return new string(array, i, 12 - i);
					}
				}
				return new string(array);
			}
			Debugger.Warning("LogicLongToCodeConverter: value to convert cannot be negative");
			return null;
		}

		// Token: 0x04000006 RID: 6
		private readonly string string_0;

		// Token: 0x04000007 RID: 7
		private readonly string string_1;
	}
}
