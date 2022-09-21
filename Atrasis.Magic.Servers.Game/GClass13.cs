using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Session;
using Atrasis.Magic.Titan.Message;

namespace ns0
{
	// Token: 0x0200001A RID: 26
	public class GClass13
	{
		// Token: 0x060000B8 RID: 184 RVA: 0x0000277E File Offset: 0x0000097E
		[CompilerGenerated]
		public long method_0()
		{
			return this.long_0;
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00002786 File Offset: 0x00000986
		public GClass13(long long_1)
		{
			this.long_0 = long_1;
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00006C48 File Offset: 0x00004E48
		public void method_1(PiranhaMessage piranhaMessage_0)
		{
			if (piranhaMessage_0.GetEncodingLength() == 0)
			{
				piranhaMessage_0.Encode();
			}
			ServerMessageManager.SendMessage(new ForwardLogicMessage
			{
				SessionId = this.method_0(),
				MessageType = piranhaMessage_0.GetMessageType(),
				MessageVersion = (short)piranhaMessage_0.GetMessageVersion(),
				MessageLength = piranhaMessage_0.GetEncodingLength(),
				MessageBytes = piranhaMessage_0.GetMessageBytes()
			}, ServerManager.GetProxySocket(this.method_0()));
		}

		// Token: 0x04000044 RID: 68
		[CompilerGenerated]
		private readonly long long_0;
	}
}
