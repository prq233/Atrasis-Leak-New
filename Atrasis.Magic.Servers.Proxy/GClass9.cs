using System;
using Atrasis.Magic.Logic.Message;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Account;
using Atrasis.Magic.Servers.Core.Network.Message.Core;
using Atrasis.Magic.Servers.Core.Network.Message.Request;
using Atrasis.Magic.Servers.Core.Network.Message.Session;
using Atrasis.Magic.Servers.Core.Network.Request;
using Atrasis.Magic.Titan.Message;

namespace ns0
{
	// Token: 0x02000017 RID: 23
	public class GClass9 : ServerMessageManager
	{
		// Token: 0x0600007E RID: 126 RVA: 0x000024E9 File Offset: 0x000006E9
		public override void OnReceiveAccountMessage(ServerAccountMessage message)
		{
		}

		// Token: 0x0600007F RID: 127 RVA: 0x000024EB File Offset: 0x000006EB
		public override void OnReceiveRequestMessage(ServerRequestMessage message)
		{
			if (message.GetMessageType() == ServerMessageType.BIND_SERVER_SOCKET_REQUEST)
			{
				GClass9.smethod_0((BindServerSocketRequestMessage)message);
			}
		}

		// Token: 0x06000080 RID: 128 RVA: 0x000054EC File Offset: 0x000036EC
		private static void smethod_0(BindServerSocketRequestMessage bindServerSocketRequestMessage_0)
		{
			GClass1 gclass;
			if (GClass2.smethod_4(bindServerSocketRequestMessage_0.SessionId, out gclass))
			{
				ServerSocket serverSocket = (bindServerSocketRequestMessage_0.ServerId != -1) ? ServerManager.GetSocket(bindServerSocketRequestMessage_0.ServerType, bindServerSocketRequestMessage_0.ServerId) : ServerManager.GetNextSocket(bindServerSocketRequestMessage_0.ServerType);
				if (serverSocket == null)
				{
					ServerRequestManager.SendResponse(new BindServerSocketResponseMessage
					{
						ServerType = bindServerSocketRequestMessage_0.ServerType,
						ServerId = bindServerSocketRequestMessage_0.ServerId,
						Success = false
					}, bindServerSocketRequestMessage_0);
					return;
				}
				gclass.method_3(serverSocket, bindServerSocketRequestMessage_0);
				if (bindServerSocketRequestMessage_0.InitSessionMessage != null)
				{
					gclass.SendMessage(bindServerSocketRequestMessage_0.InitSessionMessage, serverSocket.ServerType);
					return;
				}
			}
			else
			{
				ServerRequestManager.SendResponse(new BindServerSocketResponseMessage
				{
					ServerType = bindServerSocketRequestMessage_0.ServerType,
					ServerId = bindServerSocketRequestMessage_0.ServerId,
					Success = false
				}, bindServerSocketRequestMessage_0);
			}
		}

		// Token: 0x06000081 RID: 129 RVA: 0x000055AC File Offset: 0x000037AC
		public override void OnReceiveSessionMessage(ServerSessionMessage message)
		{
			ServerMessageType messageType = message.GetMessageType();
			if (messageType == ServerMessageType.CHAT_ACCOUNT_BAN_STATUS_UPDATED)
			{
				GClass9.smethod_6((ChatAccountBanStatusUpdatedMessage)message);
				return;
			}
			if (messageType == ServerMessageType.FORWARD_LOGIC_MESSAGE)
			{
				GClass9.smethod_5((ForwardLogicMessage)message);
				return;
			}
			switch (messageType)
			{
			case ServerMessageType.START_SERVER_SESSION_FAILED:
				GClass9.smethod_1((StartServerSessionFailedMessage)message);
				return;
			case ServerMessageType.STOP_SERVER_SESSION:
				GClass9.smethod_3((StopServerSessionMessage)message);
				return;
			case ServerMessageType.STOP_SESSION:
				GClass9.smethod_2((StopSessionMessage)message);
				return;
			case ServerMessageType.STOP_SPECIFIED_SERVER_SESSION:
				GClass9.smethod_4((StopSpecifiedServerSessionMessage)message);
				return;
			default:
				return;
			}
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00005634 File Offset: 0x00003834
		private static void smethod_1(StartServerSessionFailedMessage startServerSessionFailedMessage_0)
		{
			GClass1 gclass;
			if (GClass2.smethod_4(startServerSessionFailedMessage_0.SessionId, out gclass) && gclass.IsBoundToServerType(startServerSessionFailedMessage_0.SenderType) && gclass.method_5(startServerSessionFailedMessage_0.SenderType).ServerId == startServerSessionFailedMessage_0.SenderId)
			{
				gclass.method_4(startServerSessionFailedMessage_0.SenderType, true);
			}
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00005684 File Offset: 0x00003884
		private static void smethod_2(StopSessionMessage stopSessionMessage_0)
		{
			GClass1 gclass;
			if (GClass2.smethod_4(stopSessionMessage_0.SessionId, out gclass))
			{
				GClass4.smethod_7(gclass.method_0(), stopSessionMessage_0.Reason);
			}
		}

		// Token: 0x06000084 RID: 132 RVA: 0x000056B4 File Offset: 0x000038B4
		private static void smethod_3(StopServerSessionMessage stopServerSessionMessage_0)
		{
			GClass1 gclass;
			if (GClass2.smethod_4(stopServerSessionMessage_0.SessionId, out gclass))
			{
				ServerSocket serverSocket = gclass.method_5(stopServerSessionMessage_0.SenderType);
				if (serverSocket != null && serverSocket.ServerId == stopServerSessionMessage_0.SenderId)
				{
					gclass.method_4(stopServerSessionMessage_0.SenderType, false);
				}
			}
		}

		// Token: 0x06000085 RID: 133 RVA: 0x000056FC File Offset: 0x000038FC
		private static void smethod_4(StopSpecifiedServerSessionMessage stopSpecifiedServerSessionMessage_0)
		{
			GClass1 gclass;
			if (GClass2.smethod_4(stopSpecifiedServerSessionMessage_0.SessionId, out gclass))
			{
				ServerSocket serverSocket = gclass.method_5(stopSpecifiedServerSessionMessage_0.ServerType);
				if (serverSocket != null && serverSocket.ServerId == stopSpecifiedServerSessionMessage_0.ServerId)
				{
					gclass.method_4(stopSpecifiedServerSessionMessage_0.ServerType, true);
				}
			}
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00005744 File Offset: 0x00003944
		private static void smethod_5(ForwardLogicMessage forwardLogicMessage_0)
		{
			GClass1 gclass;
			if (GClass2.smethod_4(forwardLogicMessage_0.SessionId, out gclass))
			{
				PiranhaMessage piranhaMessage = LogicMagicMessageFactory.Instance.CreateMessageByType((int)forwardLogicMessage_0.MessageType);
				if (piranhaMessage == null)
				{
					Logging.Error("ProxyMessageManager.onForwardLogicMessageReceived: unknown logic message type: " + forwardLogicMessage_0.MessageType);
					return;
				}
				piranhaMessage.SetMessageVersion((int)forwardLogicMessage_0.MessageVersion);
				piranhaMessage.GetByteStream().SetByteArray(forwardLogicMessage_0.MessageBytes, forwardLogicMessage_0.MessageLength);
				piranhaMessage.GetByteStream().SetOffset(forwardLogicMessage_0.MessageLength);
				gclass.method_0().method_1().method_10(piranhaMessage);
			}
		}

		// Token: 0x06000087 RID: 135 RVA: 0x000057D4 File Offset: 0x000039D4
		private static void smethod_6(ChatAccountBanStatusUpdatedMessage chatAccountBanStatusUpdatedMessage_0)
		{
			GClass1 gclass;
			if (GClass2.smethod_4(chatAccountBanStatusUpdatedMessage_0.SessionId, out gclass))
			{
				gclass.method_1(chatAccountBanStatusUpdatedMessage_0.EndTime);
			}
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00002505 File Offset: 0x00000705
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
