using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Database.Document;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Titan.Math;

namespace ns0
{
	// Token: 0x02000010 RID: 16
	public static class GClass9
	{
		// Token: 0x06000078 RID: 120 RVA: 0x00005FFC File Offset: 0x000041FC
		public static void smethod_0()
		{
			GClass9.dictionary_0 = new Dictionary<long, GClass8>();
			List<Task> list = new List<Task>();
			long num = 1L;
			long documentHigherID = GClass0.smethod_0().GetDocumentHigherID();
			while (num <= documentHigherID)
			{
				LogicLong id = new LogicLong((int)(num >> 32), (int)num);
				if (ServerManager.GetDocumentSocket(ServerCore.Type, id) == ServerCore.Socket)
				{
					list.Add(GClass9.smethod_1(num));
				}
				num += 1L;
			}
			Task.WaitAll(list.ToArray());
		}

		// Token: 0x06000079 RID: 121 RVA: 0x0000607C File Offset: 0x0000427C
		private static Task smethod_1(LogicLong logicLong_0)
		{
			GClass9.Struct0 @struct;
			@struct.logicLong_0 = logicLong_0;
			@struct.asyncTaskMethodBuilder_0 = AsyncTaskMethodBuilder.Create();
			@struct.int_0 = -1;
			AsyncTaskMethodBuilder asyncTaskMethodBuilder_ = @struct.asyncTaskMethodBuilder_0;
			asyncTaskMethodBuilder_.Start<GClass9.Struct0>(ref @struct);
			return @struct.asyncTaskMethodBuilder_0.Task;
		}

		// Token: 0x0600007A RID: 122 RVA: 0x000022F7 File Offset: 0x000004F7
		private static LogicLong smethod_2()
		{
			if (GClass9.long_0 == 0L)
			{
				return GClass9.long_0 = (long)(ServerCore.Id + 1);
			}
			return GClass9.long_0 += (long)ServerManager.GetServerCount(11);
		}

		// Token: 0x0600007B RID: 123 RVA: 0x0000232D File Offset: 0x0000052D
		public static bool smethod_3(LogicLong logicLong_0, out GClass8 gclass8_0)
		{
			return GClass9.dictionary_0.TryGetValue(logicLong_0, out gclass8_0);
		}

		// Token: 0x0600007C RID: 124 RVA: 0x000060C4 File Offset: 0x000042C4
		public static GClass8 smethod_4()
		{
			LogicLong logicLong = GClass9.smethod_2();
			GClass8 gclass = new GClass8(logicLong);
			GClass9.dictionary_0.Add(logicLong, gclass);
			return gclass;
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00002340 File Offset: 0x00000540
		public static void smethod_5(GClass8 gclass8_0)
		{
			GClass0.smethod_0().InsertOrUpdate(gclass8_0.Id, CouchbaseDocument.Save(gclass8_0));
		}

		// Token: 0x04000015 RID: 21
		private static Dictionary<long, GClass8> dictionary_0;

		// Token: 0x04000016 RID: 22
		private static long long_0;
	}
}
