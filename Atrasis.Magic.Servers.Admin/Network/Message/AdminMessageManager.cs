using System;
using Atrasis.Magic.Servers.Admin.Logic;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Account;
using Atrasis.Magic.Servers.Core.Network.Message.Core;
using Atrasis.Magic.Servers.Core.Network.Message.Request;
using Atrasis.Magic.Servers.Core.Network.Message.Session;

namespace Atrasis.Magic.Servers.Admin.Network.Message
{
	// Token: 0x02000006 RID: 6
	public class AdminMessageManager : ServerMessageManager
	{
		// Token: 0x06000018 RID: 24 RVA: 0x0000213B File Offset: 0x0000033B
		public override void OnReceiveAccountMessage(ServerAccountMessage message)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000019 RID: 25 RVA: 0x0000213B File Offset: 0x0000033B
		public override void OnReceiveRequestMessage(ServerRequestMessage message)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600001A RID: 26 RVA: 0x0000213B File Offset: 0x0000033B
		public override void OnReceiveSessionMessage(ServerSessionMessage message)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002FA4 File Offset: 0x000011A4
		public override void OnReceiveCoreMessage(ServerCoreMessage message)
		{
			ServerMessageType messageType = message.GetMessageType();
			if (messageType <= ServerMessageType.EVENT_LOG)
			{
				if (messageType == ServerMessageType.ASK_FOR_SERVER_STATUS)
				{
					ServerMessageManager.SendMessage(new ServerStatusMessage
					{
						Type = ServerStatus.Status,
						Time = ServerStatus.Time,
						NextTime = ServerStatus.NextTime
					}, message.Sender);
					return;
				}
				if (messageType == ServerMessageType.CLUSTER_PERFORMANCE_DATA)
				{
					ServerManager.OnClusterPerformanceDataMessageReceived((ClusterPerformanceDataMessage)message);
					return;
				}
				if (messageType != ServerMessageType.EVENT_LOG)
				{
					return;
				}
				LogManager.OnServerEventMessageReceived((EventLogMessage)message);
				return;
			}
			else
			{
				if (messageType == ServerMessageType.GAME_LOG)
				{
					LogManager.OnGameLogMessageReceived((GameLogMessage)message);
					return;
				}
				if (messageType == ServerMessageType.PONG)
				{
					ServerManager.OnPongMessageReceived((PongMessage)message);
					return;
				}
				switch (messageType)
				{
				case ServerMessageType.SERVER_LOG:
					LogManager.OnServerLogMessageReceived((ServerLogMessage)message);
					return;
				case ServerMessageType.SERVER_PERFORMANCE:
					ServerMessageManager.SendMessage(new ServerPerformanceDataMessage(), message.SenderType, message.SenderId);
					return;
				case ServerMessageType.SERVER_PERFORMANCE_DATA:
					ServerManager.OnServerPerformanceDataMessageReceived((ServerPerformanceDataMessage)message);
					return;
				default:
					return;
				}
			}
		}
	}
}
