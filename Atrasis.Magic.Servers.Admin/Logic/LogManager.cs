using System;
using System.Collections.Generic;
using Atrasis.Magic.Servers.Core.Network.Message.Core;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Servers.Admin.Logic
{
	// Token: 0x02000018 RID: 24
	public static class LogManager
	{
		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060000AD RID: 173 RVA: 0x000025AA File Offset: 0x000007AA
		public static LogicArrayList<LogServerEntry> ServerLogs
		{
			get
			{
				return LogManager.m_serverLogs;
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060000AE RID: 174 RVA: 0x000025B1 File Offset: 0x000007B1
		public static LogicArrayList<LogGameEntry> GameLogs
		{
			get
			{
				return LogManager.m_gameLogs;
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060000AF RID: 175 RVA: 0x000025B8 File Offset: 0x000007B8
		public static LogicArrayList<LogServerEventEntry> ServerEvents
		{
			get
			{
				return LogManager.m_serverEventLogs;
			}
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x000025BF File Offset: 0x000007BF
		public static void AddClientEventLog(LogClientEventEntry.EventType type, LogicLong accountId, Dictionary<string, object> args)
		{
			LogManager.m_clientEventLogs.Add(new LogClientEventEntry(type, accountId, args));
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x000025D3 File Offset: 0x000007D3
		public static void Init()
		{
			LogManager.m_serverLogs = new LogicArrayList<LogServerEntry>();
			LogManager.m_gameLogs = new LogicArrayList<LogGameEntry>();
			LogManager.m_clientEventLogs = new LogicArrayList<LogClientEventEntry>();
			LogManager.m_serverEventLogs = new LogicArrayList<LogServerEventEntry>();
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x000025FD File Offset: 0x000007FD
		public static void OnGameLogMessageReceived(GameLogMessage message)
		{
			LogManager.m_gameLogs.Add(new LogGameEntry((LogType)message.LogType, message.Message));
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x0000261A File Offset: 0x0000081A
		public static void OnServerLogMessageReceived(ServerLogMessage message)
		{
			LogManager.m_serverLogs.Add(new LogServerEntry((LogType)message.LogType, message.Message, message.SenderType, message.SenderId));
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00002643 File Offset: 0x00000843
		public static void OnServerEventMessageReceived(EventLogMessage message)
		{
			LogManager.m_serverEventLogs.Add(new LogServerEventEntry(message.Type, message.Message));
		}

		// Token: 0x04000041 RID: 65
		private static LogicArrayList<LogServerEntry> m_serverLogs;

		// Token: 0x04000042 RID: 66
		private static LogicArrayList<LogGameEntry> m_gameLogs;

		// Token: 0x04000043 RID: 67
		private static LogicArrayList<LogClientEventEntry> m_clientEventLogs;

		// Token: 0x04000044 RID: 68
		private static LogicArrayList<LogServerEventEntry> m_serverEventLogs;
	}
}
