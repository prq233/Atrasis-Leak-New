using System;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Account;
using Atrasis.Magic.Servers.Core.Network.Message.Core;
using Atrasis.Magic.Servers.Core.Network.Message.Request;
using Atrasis.Magic.Servers.Core.Network.Message.Session;

namespace ns0
{
	// Token: 0x02000008 RID: 8
	public class GClass5 : ServerMessageManager
	{
		// Token: 0x06000025 RID: 37 RVA: 0x000021D5 File Offset: 0x000003D5
		public override void OnReceiveAccountMessage(ServerAccountMessage message)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000021D5 File Offset: 0x000003D5
		public override void OnReceiveRequestMessage(ServerRequestMessage message)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00003298 File Offset: 0x00001498
		public override void OnReceiveSessionMessage(ServerSessionMessage message)
		{
			ServerMessageType messageType = message.GetMessageType();
			if (messageType == ServerMessageType.START_SERVER_SESSION)
			{
				GClass12.smethod_3((StartServerSessionMessage)message);
				return;
			}
			if (messageType != ServerMessageType.STOP_SERVER_SESSION)
			{
				GClass12.smethod_5(message);
				return;
			}
			GClass12.smethod_4((StopServerSessionMessage)message);
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000021DC File Offset: 0x000003DC
		public override void OnReceiveCoreMessage(ServerCoreMessage message)
		{
			if (message.GetMessageType() == ServerMessageType.SERVER_PERFORMANCE)
			{
				ServerMessageManager.SendMessage(new ServerPerformanceDataMessage
				{
					SessionCount = GClass12.smethod_0(),
					ClusterCount = GClass12.smethod_1()
				}, message.Sender);
				GClass12.smethod_9();
			}
		}
	}
}
