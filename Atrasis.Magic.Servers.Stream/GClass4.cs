using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Account;
using Atrasis.Magic.Servers.Core.Network.Message.Request;
using Atrasis.Magic.Servers.Core.Network.Message.Session;
using Atrasis.Magic.Servers.Core.Network.Request;
using Atrasis.Magic.Servers.Core.Session;

namespace ns0
{
	// Token: 0x02000007 RID: 7
	public class GClass4 : ServerSession
	{
		// Token: 0x06000011 RID: 17 RVA: 0x000020F0 File Offset: 0x000002F0
		[CompilerGenerated]
		public GClass6 method_0()
		{
			return this.gclass6_0;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000020F8 File Offset: 0x000002F8
		[CompilerGenerated]
		public GClass8 method_1()
		{
			return this.gclass8_0;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002100 File Offset: 0x00000300
		[CompilerGenerated]
		private void method_2(GClass8 gclass8_1)
		{
			this.gclass8_0 = gclass8_1;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002109 File Offset: 0x00000309
		[CompilerGenerated]
		public LogicClientAvatar method_3()
		{
			return this.logicClientAvatar_0;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002111 File Offset: 0x00000311
		[CompilerGenerated]
		private void method_4(LogicClientAvatar logicClientAvatar_1)
		{
			this.logicClientAvatar_0 = logicClientAvatar_1;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002628 File Offset: 0x00000828
		public GClass4(StartServerSessionMessage startServerSessionMessage_0) : base(startServerSessionMessage_0)
		{
			this.gclass6_0 = new GClass6(this);
			ServerRequestManager.Create(new AvatarRequestMessage
			{
				AccountId = base.AccountId
			}, ServerManager.GetDocumentSocket(9, base.AccountId), 30).OnComplete = new ServerRequestArgs.CompleteHandler(this.method_5);
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002680 File Offset: 0x00000880
		private void method_5(ServerRequestArgs serverRequestArgs_0)
		{
			if (serverRequestArgs_0.ErrorCode != ServerRequestError.Success || !serverRequestArgs_0.ResponseMessage.Success)
			{
				base.SendMessage(new StopServerSessionMessage(), 1);
				GClass5.smethod_5(base.Id);
				return;
			}
			this.method_4(((AvatarResponseMessage)serverRequestArgs_0.ResponseMessage).LogicClientAvatar);
			GClass8 gclass;
			if (GClass9.smethod_3(this.method_3().GetAllianceId(), out gclass) && gclass.Members.ContainsKey(base.AccountId))
			{
				this.method_2(gclass);
				this.method_1().method_4(base.AccountId, this);
				base.SendPiranhaMessage(this.method_1().method_22(), 1);
				base.SendPiranhaMessage(this.method_1().method_23(), 1);
				GClass2.smethod_1(this.method_3(), this.method_1().Members[base.AccountId], this.method_1());
				GClass9.smethod_5(this.method_1());
				return;
			}
			base.SendMessage(new StopServerSessionMessage(), 1);
			ServerMessageManager.SendMessage(new AllianceLeavedMessage
			{
				AccountId = base.AccountId,
				AllianceId = this.method_3().GetAllianceId()
			}, 9);
			GClass5.smethod_5(base.Id);
		}

		// Token: 0x06000018 RID: 24 RVA: 0x0000211A File Offset: 0x0000031A
		public override void Destruct()
		{
			base.Destruct();
			if (this.method_1() != null)
			{
				this.method_1().method_5(this.method_3().GetId(), this);
			}
		}

		// Token: 0x04000003 RID: 3
		[CompilerGenerated]
		private readonly GClass6 gclass6_0;

		// Token: 0x04000004 RID: 4
		[CompilerGenerated]
		private GClass8 gclass8_0;

		// Token: 0x04000005 RID: 5
		[CompilerGenerated]
		private LogicClientAvatar logicClientAvatar_0;
	}
}
