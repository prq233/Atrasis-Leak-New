using System;
using System.Text;
using Atrasis.Magic.Titan.Debug;

namespace Atrasis.Magic.Titan.Util
{
	// Token: 0x02000007 RID: 7
	public static class LogicStringUtil
	{
		// Token: 0x0600001E RID: 30 RVA: 0x0000437B File Offset: 0x0000257B
		public static byte[] GetBytes(string str)
		{
			return Encoding.UTF8.GetBytes(str);
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00004388 File Offset: 0x00002588
		public static string CreateString(byte[] value, int offset, int length)
		{
			return Encoding.UTF8.GetString(value, offset, length);
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00004397 File Offset: 0x00002597
		public static int ConvertToInt(string value)
		{
			return LogicStringUtil.ConvertToInt(value, 0, value.Length);
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00005814 File Offset: 0x00003A14
		public static int ConvertToInt(string value, int startIndex, int endIndex)
		{
			int num = endIndex - startIndex;
			if (num <= 0)
			{
				Debugger.Warning("LogicStringUtil::convertToInt empty String");
			}
			else
			{
				if (num < 12)
				{
					if (value[startIndex] == '-')
					{
						startIndex++;
					}
					for (int i = 0; i < num; i++)
					{
						if (value[startIndex + i] < '0' || value[startIndex + i] > '9')
						{
							Debugger.Warning("LogicStringUtil::convertToInt invalid value: : " + value.Substring(startIndex, num));
							return 0;
						}
					}
					return int.Parse(value.Substring(startIndex, num));
				}
				Debugger.Warning("LogicStringUtil::convertToInt too long value: " + value.Substring(startIndex, num));
			}
			return 0;
		}
	}
}
