using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Servers.Core.Network.Message.Session;
using Atrasis.Magic.Servers.Core.Session;

namespace ns0
{
	// Token: 0x02000004 RID: 4
	public class GClass1 : ServerSession
	{
		// Token: 0x06000004 RID: 4 RVA: 0x000020A4 File Offset: 0x000002A4
		[CompilerGenerated]
		public GClass3 method_0()
		{
			return this.gclass3_0;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000020AC File Offset: 0x000002AC
		[CompilerGenerated]
		public GClass5 method_1()
		{
			return this.gclass5_0;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000020B4 File Offset: 0x000002B4
		[CompilerGenerated]
		private void method_2(GClass5 gclass5_1)
		{
			this.gclass5_0 = gclass5_1;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000020BD File Offset: 0x000002BD
		public GClass1(StartServerSessionMessage startServerSessionMessage_0) : base(startServerSessionMessage_0)
		{
			this.gclass3_0 = new GClass3(this);
			this.method_2(GClass6.smethod_1(base.Country));
			this.method_1().method_0(this);
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000020EF File Offset: 0x000002EF
		public override void Destruct()
		{
			this.method_1().method_1(this);
			this.method_2(null);
			base.Destruct();
		}

		// Token: 0x04000001 RID: 1
		[CompilerGenerated]
		private readonly GClass3 gclass3_0;

		// Token: 0x04000002 RID: 2
		[CompilerGenerated]
		private GClass5 gclass5_0;
	}
}
