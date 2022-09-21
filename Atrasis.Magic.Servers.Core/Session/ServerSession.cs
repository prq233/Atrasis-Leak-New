using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Request;
using Atrasis.Magic.Servers.Core.Network.Message.Session;
using Atrasis.Magic.Servers.Core.Network.Request;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Servers.Core.Session
{
	// Token: 0x02000020 RID: 32
	public class ServerSession
	{
		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060000BC RID: 188 RVA: 0x00004C6A File Offset: 0x00002E6A
		public long Id { get; }

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060000BD RID: 189 RVA: 0x00004C72 File Offset: 0x00002E72
		public string Country { get; }

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060000BE RID: 190 RVA: 0x00004C7A File Offset: 0x00002E7A
		public LogicLong AccountId { get; }

		// Token: 0x060000BF RID: 191 RVA: 0x00004C82 File Offset: 0x00002E82
		public ServerSession(long sessionId, LogicLong accountId, string country)
		{
			this.Id = sessionId;
			this.AccountId = accountId;
			this.Country = country;
			this.m_sockets = new ServerSocket[30];
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x0000B114 File Offset: 0x00009314
		public ServerSession(StartServerSessionMessage message) : this(message.SessionId, message.AccountId, message.Country)
		{
			LogicArrayList<int> serverSocketTypeList = message.ServerSocketTypeList;
			LogicArrayList<int> serverSocketIdList = message.ServerSocketIdList;
			for (int i = 0; i < serverSocketTypeList.Size(); i++)
			{
				int num = serverSocketTypeList[i];
				int id = serverSocketIdList[i];
				this.m_sockets[num] = ServerManager.GetSocket(num, id);
			}
			if (message.BindRequestMessage != null)
			{
				ServerRequestManager.SendResponse(new BindServerSocketResponseMessage
				{
					ServerType = ServerCore.Type,
					ServerId = ServerCore.Id,
					Success = true
				}, message.BindRequestMessage);
			}
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00004CAC File Offset: 0x00002EAC
		public virtual void Destruct()
		{
			if (!this.m_destructed)
			{
				Array.Clear(this.m_sockets, 0, 30);
				this.m_destructed = true;
			}
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00004CCB File Offset: 0x00002ECB
		public bool IsDestructed()
		{
			return this.m_destructed;
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00004CD3 File Offset: 0x00002ED3
		public virtual void UpdateSocketServerSessionMessageReceived(UpdateSocketServerSessionMessage message)
		{
			this.m_sockets[message.ServerType] = ((message.ServerId != -1) ? ServerManager.GetSocket(message.ServerType, message.ServerId) : null);
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00004CFF File Offset: 0x00002EFF
		public void SendMessage(ServerSessionMessage message, int serverType)
		{
			message.SessionId = this.Id;
			if (this.m_sockets[serverType] != null)
			{
				ServerMessageManager.SendMessage(message, this.m_sockets[serverType]);
			}
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x0000B1B0 File Offset: 0x000093B0
		public void SendPiranhaMessage(PiranhaMessage message, int serverType)
		{
			if (message.GetByteStream().GetLength() == 0)
			{
				message.Encode();
			}
			this.SendMessage(new ForwardLogicMessage
			{
				MessageType = message.GetMessageType(),
				MessageVersion = (short)message.GetMessageVersion(),
				MessageLength = message.GetEncodingLength(),
				MessageBytes = message.GetByteStream().GetByteArray()
			}, serverType);
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00004D25 File Offset: 0x00002F25
		public ServerSocket GetSocket(int type)
		{
			return this.m_sockets[type];
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00004D2F File Offset: 0x00002F2F
		public bool IsBoundToServerType(int type)
		{
			return this.m_sockets[type] != null;
		}

		// Token: 0x04000048 RID: 72
		[CompilerGenerated]
		private readonly long long_0;

		// Token: 0x04000049 RID: 73
		[CompilerGenerated]
		private readonly string string_0;

		// Token: 0x0400004A RID: 74
		[CompilerGenerated]
		private readonly LogicLong logicLong_0;

		// Token: 0x0400004B RID: 75
		protected readonly ServerSocket[] m_sockets;

		// Token: 0x0400004C RID: 76
		protected bool m_destructed;
	}
}
