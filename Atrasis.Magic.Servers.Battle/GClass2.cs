using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Servers.Core.Network.Message.Session;
using Atrasis.Magic.Servers.Core.Session;

namespace ns0
{
	// Token: 0x02000005 RID: 5
	public class GClass2 : ServerSession
	{
		// Token: 0x06000007 RID: 7 RVA: 0x0000209B File Offset: 0x0000029B
		[CompilerGenerated]
		public GClass4 method_0()
		{
			return this.gclass4_0;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000020A3 File Offset: 0x000002A3
		[CompilerGenerated]
		public GClass6 method_1()
		{
			return this.gclass6_0;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000020AB File Offset: 0x000002AB
		[CompilerGenerated]
		private void method_2(GClass6 gclass6_1)
		{
			this.gclass6_0 = gclass6_1;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000020B4 File Offset: 0x000002B4
		public GClass2(StartServerSessionMessage startServerSessionMessage_0) : base(startServerSessionMessage_0)
		{
			this.gclass4_0 = new GClass4(this);
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000020C9 File Offset: 0x000002C9
		public override void Destruct()
		{
			if (this.method_1() != null)
			{
				this.method_1().method_0();
			}
			base.Destruct();
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000020E4 File Offset: 0x000002E4
		public void method_3(GClass6 gclass6_1)
		{
			if (this.method_1() != null)
			{
				this.method_1().method_0();
			}
			this.method_2(gclass6_1);
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002100 File Offset: 0x00000300
		public void method_4()
		{
			if (this.method_1() != null)
			{
				this.method_1().method_0();
				this.method_2(null);
			}
		}

		// Token: 0x04000001 RID: 1
		[CompilerGenerated]
		private readonly GClass4 gclass4_0;

		// Token: 0x04000002 RID: 2
		[CompilerGenerated]
		private GClass6 gclass6_0;
	}
}
