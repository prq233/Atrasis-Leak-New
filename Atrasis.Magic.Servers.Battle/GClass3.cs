using System;
using System.Collections.Generic;
using Atrasis.Magic.Servers.Core.Network.Message.Session;

namespace ns0
{
	// Token: 0x02000006 RID: 6
	public class GClass3
	{
		// Token: 0x0600000E RID: 14 RVA: 0x0000211C File Offset: 0x0000031C
		public int method_0()
		{
			return this.dictionary_0.Count;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002129 File Offset: 0x00000329
		public GClass3()
		{
			this.dictionary_0 = new Dictionary<long, GClass2>();
		}

		// Token: 0x06000010 RID: 16 RVA: 0x0000213C File Offset: 0x0000033C
		public void method_1(StartServerSessionMessage startServerSessionMessage_0)
		{
			if (this.dictionary_0.ContainsKey(startServerSessionMessage_0.SessionId))
			{
				throw new Exception("BattleSessionManager.onStartSessionMessageReceived: session already started!");
			}
			this.dictionary_0.Add(startServerSessionMessage_0.SessionId, new GClass2(startServerSessionMessage_0));
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002800 File Offset: 0x00000A00
		public void method_2(StopServerSessionMessage stopServerSessionMessage_0)
		{
			GClass2 gclass;
			if (this.dictionary_0.Remove(stopServerSessionMessage_0.SessionId, out gclass))
			{
				gclass.Destruct();
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002173 File Offset: 0x00000373
		public bool method_3(long long_0, out GClass2 gclass2_0)
		{
			return this.dictionary_0.TryGetValue(long_0, out gclass2_0);
		}

		// Token: 0x04000003 RID: 3
		private readonly Dictionary<long, GClass2> dictionary_0;
	}
}
