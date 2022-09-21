using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Core;

namespace Atrasis.Magic.Servers.Core.Cluster
{
	// Token: 0x020000FE RID: 254
	public class ClusterInstance
	{
		// Token: 0x060007BC RID: 1980 RVA: 0x000187C4 File Offset: 0x000169C4
		public ClusterInstance(int id, int logicUpdateFrequency = -1)
		{
			this.bool_0 = true;
			this.m_id = id;
			this.concurrentQueue_0 = new ConcurrentQueue<ServerMessage>();
			this.autoResetEvent_0 = new AutoResetEvent(false);
			this.thread_0 = new Thread(new ThreadStart(this.method_0));
			this.thread_0.Name = "Cluster: Network Thread";
			if (logicUpdateFrequency >= 0)
			{
				this.m_logicUpdateFrequency = logicUpdateFrequency;
				this.thread_1 = new Thread(new ThreadStart(this.method_1));
				this.thread_1.Name = "Cluster: Logic Thread";
				this.thread_1.Start();
			}
			this.thread_0.Start();
			this.stopwatch_0 = new Stopwatch();
		}

		// Token: 0x060007BD RID: 1981 RVA: 0x0000948F File Offset: 0x0000768F
		public void Stop()
		{
			this.bool_0 = false;
		}

		// Token: 0x060007BE RID: 1982 RVA: 0x00018878 File Offset: 0x00016A78
		private void method_0()
		{
			while (this.bool_0)
			{
				this.autoResetEvent_0.WaitOne();
				ServerMessage serverMessage;
				while (this.concurrentQueue_0.TryDequeue(out serverMessage))
				{
					if (serverMessage.GetMessageType() != ServerMessageType.SERVER_CLUSTER_PING)
					{
						this.ReceiveMessage(serverMessage);
					}
					else
					{
						this.stopwatch_0.Stop();
						this.m_ping = (int)this.stopwatch_0.ElapsedMilliseconds;
						this.stopwatch_0.Reset();
						this.OnPingTestCompleted();
					}
				}
			}
		}

		// Token: 0x060007BF RID: 1983 RVA: 0x00009498 File Offset: 0x00007698
		private void method_1()
		{
			while (this.bool_0)
			{
				Thread.Sleep(this.m_logicUpdateFrequency);
				this.Tick();
			}
		}

		// Token: 0x060007C0 RID: 1984 RVA: 0x00004631 File Offset: 0x00002831
		protected virtual void ReceiveMessage(ServerMessage message)
		{
		}

		// Token: 0x060007C1 RID: 1985 RVA: 0x00004631 File Offset: 0x00002831
		protected virtual void Tick()
		{
		}

		// Token: 0x060007C2 RID: 1986 RVA: 0x00004631 File Offset: 0x00002831
		protected virtual void OnPingTestCompleted()
		{
		}

		// Token: 0x060007C3 RID: 1987 RVA: 0x000094B6 File Offset: 0x000076B6
		public void SendMessage(ServerMessage message)
		{
			this.concurrentQueue_0.Enqueue(message);
			this.autoResetEvent_0.Set();
		}

		// Token: 0x060007C4 RID: 1988 RVA: 0x000094D0 File Offset: 0x000076D0
		public void SendPing()
		{
			if (!this.stopwatch_0.IsRunning)
			{
				this.stopwatch_0.Start();
				this.SendMessage(ClusterInstance.serverClusterPingMessage_0);
			}
		}

		// Token: 0x060007C5 RID: 1989 RVA: 0x000094F5 File Offset: 0x000076F5
		public int GetId()
		{
			return this.m_id;
		}

		// Token: 0x0400045D RID: 1117
		private static readonly ServerClusterPingMessage serverClusterPingMessage_0 = new ServerClusterPingMessage();

		// Token: 0x0400045E RID: 1118
		private bool bool_0;

		// Token: 0x0400045F RID: 1119
		protected readonly int m_id;

		// Token: 0x04000460 RID: 1120
		protected readonly int m_logicUpdateFrequency;

		// Token: 0x04000461 RID: 1121
		private readonly Thread thread_0;

		// Token: 0x04000462 RID: 1122
		private readonly Thread thread_1;

		// Token: 0x04000463 RID: 1123
		private readonly ConcurrentQueue<ServerMessage> concurrentQueue_0;

		// Token: 0x04000464 RID: 1124
		private readonly AutoResetEvent autoResetEvent_0;

		// Token: 0x04000465 RID: 1125
		private readonly Stopwatch stopwatch_0;

		// Token: 0x04000466 RID: 1126
		protected int m_ping;
	}
}
