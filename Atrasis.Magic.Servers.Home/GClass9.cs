using System;
using Atrasis.Magic.Logic.Home;
using Atrasis.Magic.Logic.Home.Change;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Account;

namespace ns0
{
	// Token: 0x0200000E RID: 14
	public class GClass9 : LogicHomeChangeListener
	{
		// Token: 0x0600006E RID: 110 RVA: 0x0000270D File Offset: 0x0000090D
		public GClass9(GClass6 gclass6_1, LogicClientHome logicClientHome_1)
		{
			this.logicClientHome_0 = logicClientHome_1;
			this.gclass6_0 = gclass6_1;
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00002723 File Offset: 0x00000923
		public override void GuardActivated(int guard)
		{
			ServerMessageManager.SendMessage(new GameHomeProtectionUpdateMessage
			{
				AccountId = this.logicClientHome_0.GetHomeId(),
				GuardTimeSeconds = guard
			}, 9);
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00002749 File Offset: 0x00000949
		public override void ShieldActivated(int shield, int guard)
		{
			ServerMessageManager.SendMessage(new GameHomeProtectionUpdateMessage
			{
				AccountId = this.logicClientHome_0.GetHomeId(),
				ShieldTimeSeconds = shield,
				GuardTimeSeconds = guard
			}, 9);
		}

		// Token: 0x04000023 RID: 35
		private readonly LogicClientHome logicClientHome_0;

		// Token: 0x04000024 RID: 36
		private readonly GClass6 gclass6_0;
	}
}
