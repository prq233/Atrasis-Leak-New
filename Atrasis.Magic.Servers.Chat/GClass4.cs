using System;
using Atrasis.Magic.Logic.Message;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Account;
using Atrasis.Magic.Servers.Core.Network.Message.Core;
using Atrasis.Magic.Servers.Core.Network.Message.Request;
using Atrasis.Magic.Servers.Core.Network.Message.Session;
using Atrasis.Magic.Titan.Message;

namespace ns0
{
	// Token: 0x02000009 RID: 9
	public class GClass4 : ServerMessageManager
	{
		// Token: 0x06000017 RID: 23 RVA: 0x0000218F File Offset: 0x0000038F
		public override void OnReceiveAccountMessage(ServerAccountMessage message)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000018 RID: 24 RVA: 0x0000218F File Offset: 0x0000038F
		public override void OnReceiveRequestMessage(ServerRequestMessage message)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002970 File Offset: 0x00000B70
		public override void OnReceiveSessionMessage(ServerSessionMessage message)
		{
			ServerMessageType messageType = message.GetMessageType();
			if (messageType <= ServerMessageType.START_SERVER_SESSION)
			{
				if (messageType == ServerMessageType.FORWARD_LOGIC_MESSAGE)
				{
					GClass4.smethod_1((ForwardLogicMessage)message);
					return;
				}
				if (messageType != ServerMessageType.START_SERVER_SESSION)
				{
					return;
				}
				GClass2.smethod_2((StartServerSessionMessage)message);
				return;
			}
			else
			{
				if (messageType == ServerMessageType.STOP_SERVER_SESSION)
				{
					GClass2.smethod_3((StopServerSessionMessage)message);
					return;
				}
				if (messageType != ServerMessageType.UPDATE_SOCKET_SERVER_SESSION)
				{
					return;
				}
				GClass4.smethod_0((UpdateSocketServerSessionMessage)message);
				return;
			}
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000029E0 File Offset: 0x00000BE0
		private static void smethod_0(UpdateSocketServerSessionMessage updateSocketServerSessionMessage_0)
		{
			GClass1 gclass;
			if (GClass2.smethod_4(updateSocketServerSessionMessage_0.SessionId, out gclass))
			{
				gclass.UpdateSocketServerSessionMessageReceived(updateSocketServerSessionMessage_0);
			}
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002A04 File Offset: 0x00000C04
		private static void smethod_1(ForwardLogicMessage forwardLogicMessage_0)
		{
			GClass1 gclass;
			if (GClass2.smethod_4(forwardLogicMessage_0.SessionId, out gclass))
			{
				PiranhaMessage piranhaMessage = LogicMagicMessageFactory.Instance.CreateMessageByType((int)forwardLogicMessage_0.MessageType);
				if (piranhaMessage == null)
				{
					throw new Exception("logicMessage should not be NULL!");
				}
				piranhaMessage.GetByteStream().SetByteArray(forwardLogicMessage_0.MessageBytes, forwardLogicMessage_0.MessageLength);
				piranhaMessage.SetMessageVersion((int)forwardLogicMessage_0.MessageVersion);
				piranhaMessage.Decode();
				if (!piranhaMessage.IsServerToClientMessage())
				{
					gclass.method_0().method_0(piranhaMessage);
				}
			}
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002196 File Offset: 0x00000396
		public override void OnReceiveCoreMessage(ServerCoreMessage message)
		{
			if (message.GetMessageType() == ServerMessageType.SERVER_PERFORMANCE)
			{
				ServerMessageManager.SendMessage(new ServerPerformanceDataMessage
				{
					SessionCount = GClass2.smethod_0()
				}, message.Sender);
			}
		}
	}
}
