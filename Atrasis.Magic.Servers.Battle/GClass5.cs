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
		// Token: 0x06000016 RID: 22 RVA: 0x000021AC File Offset: 0x000003AC
		public override void OnReceiveAccountMessage(ServerAccountMessage message)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000021AC File Offset: 0x000003AC
		public override void OnReceiveRequestMessage(ServerRequestMessage message)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000018 RID: 24 RVA: 0x0000285C File Offset: 0x00000A5C
		public override void OnReceiveSessionMessage(ServerSessionMessage message)
		{
			ServerMessageType messageType = message.GetMessageType();
			if (messageType == ServerMessageType.START_SERVER_SESSION)
			{
				GClass10.smethod_3((StartServerSessionMessage)message);
				return;
			}
			if (messageType != ServerMessageType.STOP_SERVER_SESSION)
			{
				GClass10.smethod_5(message);
				return;
			}
			GClass10.smethod_4((StopServerSessionMessage)message);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000021B3 File Offset: 0x000003B3
		public override void OnReceiveCoreMessage(ServerCoreMessage message)
		{
			if (message.GetMessageType() == ServerMessageType.SERVER_PERFORMANCE)
			{
				ServerMessageManager.SendMessage(new ServerPerformanceDataMessage
				{
					SessionCount = GClass10.smethod_0(),
					ClusterCount = GClass10.smethod_1()
				}, message.Sender);
				GClass10.smethod_9();
			}
		}
	}
}
