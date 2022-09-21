using System;
using System.Collections.Generic;
using Atrasis.Magic.Titan.Math;

namespace ns0
{
	// Token: 0x02000021 RID: 33
	public static class GClass19
	{
		// Token: 0x06000114 RID: 276 RVA: 0x00002C0D File Offset: 0x00000E0D
		public static void smethod_0()
		{
			GClass19.dictionary_0 = new Dictionary<long, GClass17>();
		}

		// Token: 0x06000115 RID: 277 RVA: 0x00007B40 File Offset: 0x00005D40
		public static GClass17 smethod_1(GClass5 gclass5_0, GClass5 gclass5_1, LogicLong logicLong_0, LogicLong logicLong_1)
		{
			long num = GClass19.long_0 += 1L;
			GClass17 gclass = new GClass17(num, gclass5_0, gclass5_1, logicLong_0, logicLong_1);
			GClass19.dictionary_0.Add(num, gclass);
			return gclass;
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00002C19 File Offset: 0x00000E19
		public static void smethod_2(long long_1)
		{
			GClass19.dictionary_0.Remove(long_1);
		}

		// Token: 0x06000117 RID: 279 RVA: 0x00002C27 File Offset: 0x00000E27
		public static bool smethod_3(long long_1, out GClass17 gclass17_0)
		{
			return GClass19.dictionary_0.TryGetValue(long_1, out gclass17_0);
		}

		// Token: 0x04000064 RID: 100
		private static Dictionary<long, GClass17> dictionary_0;

		// Token: 0x04000065 RID: 101
		private static long long_0;
	}
}
