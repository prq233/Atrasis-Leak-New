using System;
using System.Runtime.CompilerServices;

namespace ns0
{
	// Token: 0x0200000C RID: 12
	[CompilerGenerated]
	internal sealed class Class3
	{
		// Token: 0x06000025 RID: 37 RVA: 0x00002BBC File Offset: 0x00000DBC
		internal static uint smethod_0(string string_0)
		{
			uint num;
			if (string_0 != null)
			{
				num = 2166136261U;
				for (int i = 0; i < string_0.Length; i++)
				{
					num = ((uint)string_0[i] ^ num) * 16777619U;
				}
			}
			return num;
		}
	}
}
