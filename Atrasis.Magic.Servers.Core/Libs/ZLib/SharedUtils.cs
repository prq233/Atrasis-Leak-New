using System;
using System.IO;
using System.Text;

namespace Atrasis.Magic.Servers.Core.Libs.ZLib
{
	// Token: 0x020000E3 RID: 227
	internal class SharedUtils
	{
		// Token: 0x0600069B RID: 1691 RVA: 0x0000880D File Offset: 0x00006A0D
		public static int URShift(int number, int bits)
		{
			return (int)((uint)number >> bits);
		}

		// Token: 0x0600069C RID: 1692 RVA: 0x00014AF4 File Offset: 0x00012CF4
		public static int ReadInput(TextReader sourceTextReader, byte[] target, int start, int count)
		{
			if (target.Length == 0)
			{
				return 0;
			}
			char[] array = new char[target.Length];
			int num = sourceTextReader.Read(array, start, count);
			if (num == 0)
			{
				return -1;
			}
			for (int i = start; i < start + num; i++)
			{
				target[i] = (byte)array[i];
			}
			return num;
		}

		// Token: 0x0600069D RID: 1693 RVA: 0x00008815 File Offset: 0x00006A15
		internal static byte[] ToByteArray(string sourceString)
		{
			return Encoding.UTF8.GetBytes(sourceString);
		}

		// Token: 0x0600069E RID: 1694 RVA: 0x00008822 File Offset: 0x00006A22
		internal static char[] ToCharArray(byte[] byteArray)
		{
			return Encoding.UTF8.GetChars(byteArray);
		}
	}
}
