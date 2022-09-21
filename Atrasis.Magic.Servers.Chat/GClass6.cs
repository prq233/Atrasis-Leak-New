using System;
using System.Collections.Generic;
using Atrasis.Magic.Titan.Util;

namespace ns0
{
	// Token: 0x0200000B RID: 11
	public static class GClass6
	{
		// Token: 0x06000023 RID: 35 RVA: 0x0000223E File Offset: 0x0000043E
		public static void smethod_0()
		{
			GClass6.dictionary_0 = new Dictionary<string, LogicArrayList<GClass5>>();
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002B4C File Offset: 0x00000D4C
		public static GClass5 smethod_1(string string_0)
		{
			if (string_0 == null)
			{
				string_0 = "US";
			}
			LogicArrayList<GClass5> logicArrayList;
			if (!GClass6.dictionary_0.TryGetValue(string_0, out logicArrayList))
			{
				GClass6.dictionary_0.Add(string_0, logicArrayList = new LogicArrayList<GClass5>(500));
			}
			GClass5 gclass;
			for (int i = 0; i < logicArrayList.Size(); i++)
			{
				gclass = logicArrayList[i];
				if (!gclass.method_2())
				{
					return gclass;
				}
			}
			gclass = new GClass5();
			logicArrayList.Add(gclass);
			return gclass;
		}

		// Token: 0x0400000C RID: 12
		private static Dictionary<string, LogicArrayList<GClass5>> dictionary_0;
	}
}
