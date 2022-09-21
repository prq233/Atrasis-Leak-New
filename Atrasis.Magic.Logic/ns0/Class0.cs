using System;
using System.Runtime.CompilerServices;

namespace ns0
{
	// Token: 0x02000205 RID: 517
	[CompilerGenerated]
	internal sealed class Class0
	{
		// Token: 0x06001B64 RID: 7012 RVA: 0x00069798 File Offset: 0x00067998
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
