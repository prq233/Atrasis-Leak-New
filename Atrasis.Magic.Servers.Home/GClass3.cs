using System;
using System.Collections.Generic;
using Atrasis.Magic.Servers.Core.Network.Message.Session;

namespace ns0
{
	// Token: 0x02000006 RID: 6
	public class GClass3
	{
		// Token: 0x06000010 RID: 16 RVA: 0x0000212D File Offset: 0x0000032D
		public int method_0()
		{
			return this.dictionary_0.Count;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x0000213A File Offset: 0x0000033A
		public GClass3()
		{
			this.dictionary_0 = new Dictionary<long, GClass2>();
		}

		// Token: 0x06000012 RID: 18 RVA: 0x0000214D File Offset: 0x0000034D
		public void method_1(StartServerSessionMessage startServerSessionMessage_0)
		{
			if (this.dictionary_0.ContainsKey(startServerSessionMessage_0.SessionId))
			{
				throw new Exception("HomeSessionManager.onStartSessionMessageReceived: session already started!");
			}
			this.dictionary_0.Add(startServerSessionMessage_0.SessionId, new GClass2(startServerSessionMessage_0));
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000029AC File Offset: 0x00000BAC
		public void method_2(StopServerSessionMessage stopServerSessionMessage_0)
		{
			GClass2 gclass;
			if (this.dictionary_0.Remove(stopServerSessionMessage_0.SessionId, out gclass))
			{
				gclass.Destruct();
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002184 File Offset: 0x00000384
		public bool method_3(long long_0, out GClass2 gclass2_0)
		{
			return this.dictionary_0.TryGetValue(long_0, out gclass2_0);
		}

		// Token: 0x04000004 RID: 4
		private readonly Dictionary<long, GClass2> dictionary_0;
	}
}
