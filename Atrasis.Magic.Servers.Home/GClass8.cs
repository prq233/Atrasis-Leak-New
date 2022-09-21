using System;
using Atrasis.Magic.Logic.Mode;
using Atrasis.Magic.Servers.Core.Network.Message.Session;

namespace ns0
{
	// Token: 0x0200000D RID: 13
	public class GClass8 : LogicGameListener
	{
		// Token: 0x06000069 RID: 105 RVA: 0x00002679 File Offset: 0x00000879
		public GClass8(GClass6 gclass6_1)
		{
			this.gclass6_0 = gclass6_1;
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00002688 File Offset: 0x00000888
		public override void MatchmakingCommandExecuted()
		{
			this.gclass6_0.method_8().SendMessage(new GameMatchmakingMessage(), 9);
			this.gclass6_0.method_7();
		}

		// Token: 0x0600006B RID: 107 RVA: 0x000026AC File Offset: 0x000008AC
		public override void MatchmakingVillage2CommandExecuted()
		{
			this.gclass6_0.method_8().SendMessage(new GameDuelMatchmakingMessage
			{
				Snapshot = this.gclass6_0.method_15()
			}, 9);
			this.gclass6_0.method_7();
		}

		// Token: 0x0600006C RID: 108 RVA: 0x000026E1 File Offset: 0x000008E1
		public override void NameChanged(string name)
		{
			this.gclass6_0.method_11().method_1(name, this.gclass6_0.method_10().GetNameChangeState());
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00002704 File Offset: 0x00000904
		public override void ShieldActivated(int hours)
		{
			base.ShieldActivated(hours);
		}

		// Token: 0x04000022 RID: 34
		private readonly GClass6 gclass6_0;
	}
}
