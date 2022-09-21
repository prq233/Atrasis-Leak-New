using System;

namespace Atrasis.Magic.Servers.Core.Util
{
	// Token: 0x0200000E RID: 14
	public static class StringUtil
	{
		// Token: 0x0600003A RID: 58 RVA: 0x00009E58 File Offset: 0x00008058
		public unsafe static string RemoveMultipleSpaces(string str)
		{
			int i = str.Length;
			if (i > 1)
			{
				char[] array = str.ToCharArray();
				char[] array2 = new char[array.Length];
				int length = 0;
				fixed (char[] array3 = array)
				{
					char* ptr;
					if (array != null && array3.Length != 0)
					{
						ptr = &array3[0];
					}
					else
					{
						ptr = null;
					}
					char* ptr2 = ptr;
					array2[length++] = *ptr2;
					ptr2++;
					for (i--; i > 0; i--)
					{
						if (*ptr2 > ' ' || *(ptr2 - 1) > ' ')
						{
							if (*ptr2 < ' ')
							{
								*ptr2 = ' ';
							}
							array2[length++] = *ptr2;
						}
						ptr2++;
					}
				}
				return new string(array2, 0, length);
			}
			return str;
		}
	}
}
