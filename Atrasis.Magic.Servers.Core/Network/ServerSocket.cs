using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Servers.Core.Settings;
using NetMQ;
using NetMQ.Sockets;

namespace Atrasis.Magic.Servers.Core.Network
{
	// Token: 0x02000024 RID: 36
	public class ServerSocket
	{
		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060000DA RID: 218 RVA: 0x00004DF9 File Offset: 0x00002FF9
		public int ServerType { get; }

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060000DB RID: 219 RVA: 0x00004E01 File Offset: 0x00003001
		public int ServerId { get; }

		// Token: 0x060000DC RID: 220 RVA: 0x0000B530 File Offset: 0x00009730
		public ServerSocket(int type, int id, string host, int port)
		{
			this.ServerType = type;
			this.ServerId = id;
			this.netMQSocket_0 = new PushSocket(string.Format(">tcp://{0}:{1}", host, port));
			this.netMQSocket_0.Options.SendHighWatermark = 25000;
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00004E09 File Offset: 0x00003009
		public void Destruct()
		{
			if (this.netMQSocket_0 != null)
			{
				this.netMQSocket_0.Dispose();
				this.netMQSocket_0 = null;
			}
		}

		// Token: 0x060000DE RID: 222 RVA: 0x0000B584 File Offset: 0x00009784
		internal void method_0(byte[] byte_0, int int_2)
		{
			this.netMQSocket_0.SendMoreFrame(EnvironmentSettings.Settings.ProtocolSecureKey).SendFrame(byte_0, int_2, false);
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00004E25 File Offset: 0x00003025
		public override string ToString()
		{
			return this.ServerType + "-" + this.ServerId;
		}

		// Token: 0x04000054 RID: 84
		private NetMQSocket netMQSocket_0;

		// Token: 0x04000055 RID: 85
		[CompilerGenerated]
		private readonly int int_0;

		// Token: 0x04000056 RID: 86
		[CompilerGenerated]
		private readonly int int_1;
	}
}
