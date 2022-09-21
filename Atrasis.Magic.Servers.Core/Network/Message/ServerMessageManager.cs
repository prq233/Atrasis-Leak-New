using System;
using Atrasis.Magic.Servers.Core.Network.Message.Account;
using Atrasis.Magic.Servers.Core.Network.Message.Core;
using Atrasis.Magic.Servers.Core.Network.Message.Request;
using Atrasis.Magic.Servers.Core.Network.Message.Session;
using Atrasis.Magic.Servers.Core.Settings;
using ns0;

namespace Atrasis.Magic.Servers.Core.Network.Message
{
	// Token: 0x02000030 RID: 48
	public abstract class ServerMessageManager
	{
		// Token: 0x0600010D RID: 269
		public abstract void OnReceiveAccountMessage(ServerAccountMessage message);

		// Token: 0x0600010E RID: 270
		public abstract void OnReceiveRequestMessage(ServerRequestMessage message);

		// Token: 0x0600010F RID: 271
		public abstract void OnReceiveSessionMessage(ServerSessionMessage message);

		// Token: 0x06000110 RID: 272
		public abstract void OnReceiveCoreMessage(ServerCoreMessage message);

		// Token: 0x06000111 RID: 273 RVA: 0x0000BD2C File Offset: 0x00009F2C
		internal static bool smethod_0(ServerCoreMessage serverCoreMessage_0)
		{
			ServerMessageType messageType = serverCoreMessage_0.GetMessageType();
			if (messageType == ServerMessageType.PING)
			{
				ServerMessageManager.SendMessage(new PongMessage(), serverCoreMessage_0.Sender);
				return true;
			}
			if (messageType == ServerMessageType.SERVER_STATUS)
			{
				ServerStatusMessage serverStatusMessage = (ServerStatusMessage)serverCoreMessage_0;
				ServerStatus.SetStatus(serverStatusMessage.Type, serverStatusMessage.Time, serverStatusMessage.NextTime);
				return true;
			}
			if (messageType != ServerMessageType.UPDATE_RESOURCE_SETTINGS)
			{
				return false;
			}
			ResourceSettings.OnUpdateResourceSettingsMessageReceived((UpdateResourceSettingsMessage)serverCoreMessage_0);
			return true;
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00005033 File Offset: 0x00003233
		public static void SendMessage(ServerMessage message, ServerSocket socket)
		{
			Class2.smethod_5(message, socket);
		}

		// Token: 0x06000113 RID: 275 RVA: 0x0000503C File Offset: 0x0000323C
		public static void SendMessage(ServerMessage message, int serverType, int serverId)
		{
			Class2.smethod_5(message, ServerManager.GetSocket(serverType, serverId));
		}

		// Token: 0x06000114 RID: 276 RVA: 0x0000504B File Offset: 0x0000324B
		public static void SendMessage(ServerAccountMessage message, int serverType)
		{
			Class2.smethod_5(message, ServerManager.GetDocumentSocket(serverType, message.AccountId));
		}

		// Token: 0x02000031 RID: 49
		// (Invoke) Token: 0x06000117 RID: 279
		public delegate void ReceiveServerCoreMessage(ServerCoreMessage message);
	}
}
