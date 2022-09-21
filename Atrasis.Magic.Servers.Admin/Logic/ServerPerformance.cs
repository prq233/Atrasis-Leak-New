using System;
using System.Diagnostics;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Core;

namespace Atrasis.Magic.Servers.Admin.Logic
{
	// Token: 0x0200001F RID: 31
	public class ServerPerformance
	{
		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060000D2 RID: 210 RVA: 0x000027EE File Offset: 0x000009EE
		// (set) Token: 0x060000D3 RID: 211 RVA: 0x000027F6 File Offset: 0x000009F6
		public ServerPerformanceStatus Status { get; private set; }

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060000D4 RID: 212 RVA: 0x000027FF File Offset: 0x000009FF
		public ServerSocket Socket { get; }

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060000D5 RID: 213 RVA: 0x00002807 File Offset: 0x00000A07
		// (set) Token: 0x060000D6 RID: 214 RVA: 0x0000280F File Offset: 0x00000A0F
		public ClusterPerformance[] ClusterPerformances { get; private set; }

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060000D7 RID: 215 RVA: 0x00002818 File Offset: 0x00000A18
		// (set) Token: 0x060000D8 RID: 216 RVA: 0x00002820 File Offset: 0x00000A20
		public int Ping { get; private set; }

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060000D9 RID: 217 RVA: 0x00002829 File Offset: 0x00000A29
		// (set) Token: 0x060000DA RID: 218 RVA: 0x00002831 File Offset: 0x00000A31
		public int SessionCount { get; private set; }

		// Token: 0x060000DB RID: 219 RVA: 0x0000283A File Offset: 0x00000A3A
		public ServerPerformance(ServerSocket socket)
		{
			this.Socket = socket;
			this.Status = ServerPerformanceStatus.UNKNOWN;
			this.m_watch = new Stopwatch();
		}

		// Token: 0x060000DC RID: 220 RVA: 0x0000285B File Offset: 0x00000A5B
		public void SendPingMessage()
		{
			if (this.m_watch.IsRunning)
			{
				this.Status = ServerPerformanceStatus.OFFLINE;
			}
			ServerMessageManager.SendMessage(new PingMessage(), this.Socket);
			this.m_watch.Restart();
		}

		// Token: 0x060000DD RID: 221 RVA: 0x0000288C File Offset: 0x00000A8C
		public void OnPongMessageReceived()
		{
			this.m_watch.Stop();
			this.Ping = (int)this.m_watch.ElapsedMilliseconds;
			this.Status = ServerPerformanceStatus.ONLINE;
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00003BC4 File Offset: 0x00001DC4
		public void OnServerPerformanceDataMessageReceived(ServerPerformanceDataMessage message)
		{
			this.SessionCount = message.SessionCount;
			if ((this.ClusterPerformances == null) ? (message.ClusterCount != 0) : (this.ClusterPerformances.Length != message.ClusterCount))
			{
				this.ClusterPerformances = new ClusterPerformance[message.ClusterCount];
				for (int i = 0; i < this.ClusterPerformances.Length; i++)
				{
					this.ClusterPerformances[i] = new ClusterPerformance();
				}
			}
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00003C38 File Offset: 0x00001E38
		public void OnClusterPerformanceDataMessageReceived(ClusterPerformanceDataMessage message)
		{
			this.ClusterPerformances[message.Id].Ping = message.Ping;
			this.ClusterPerformances[message.Id].SessionCount = message.SessionCount;
			this.ClusterPerformances[message.Id].Defined = true;
		}

		// Token: 0x0400005F RID: 95
		private readonly Stopwatch m_watch;
	}
}
