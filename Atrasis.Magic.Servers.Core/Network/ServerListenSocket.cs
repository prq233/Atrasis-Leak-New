using System;
using System.Threading;
using Atrasis.Magic.Servers.Core.Settings;
using NetMQ;
using NetMQ.Sockets;
using ns0;

namespace Atrasis.Magic.Servers.Core.Network
{
	// Token: 0x02000021 RID: 33
	public static class ServerListenSocket
	{
		// Token: 0x060000C8 RID: 200 RVA: 0x0000B214 File Offset: 0x00009414
		internal static void smethod_0()
		{
			EnvironmentSettings.ServerConnectionEntry serverConnectionEntry = EnvironmentSettings.Servers[ServerCore.Type][ServerCore.Id];
			ServerListenSocket.bool_0 = true;
			ServerListenSocket.netMQSocket_0 = new PullSocket(string.Format("@tcp://{0}:{1}", serverConnectionEntry.ServerIP, serverConnectionEntry.ServerPort));
			ServerListenSocket.netMQSocket_0.Options.ReceiveHighWatermark = 25000;
			ServerListenSocket.thread_0 = new Thread(new ThreadStart(ServerListenSocket.smethod_1));
			ServerListenSocket.thread_0.Start();
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00004D3C File Offset: 0x00002F3C
		public static void DeInit()
		{
			ServerListenSocket.bool_0 = false;
		}

		// Token: 0x060000CA RID: 202 RVA: 0x0000B298 File Offset: 0x00009498
		private static void smethod_1()
		{
			while (ServerListenSocket.bool_0)
			{
				NetMQMessage netMQMessage = ServerListenSocket.netMQSocket_0.ReceiveMultipartMessage(4);
				if (netMQMessage.FrameCount == 2)
				{
					NetMQFrame netMQFrame = netMQMessage[0];
					NetMQFrame netMQFrame2 = netMQMessage[1];
					ServerListenSocket.smethod_2(netMQFrame.Buffer, netMQFrame.BufferSize, netMQFrame2.Buffer, netMQFrame2.BufferSize);
				}
			}
		}

		// Token: 0x060000CB RID: 203 RVA: 0x0000B2F4 File Offset: 0x000094F4
		private static void smethod_2(byte[] byte_0, int int_0, byte[] byte_1, int int_1)
		{
			byte[] protocolSecureKey = EnvironmentSettings.Settings.ProtocolSecureKey;
			if (int_0 == protocolSecureKey.Length)
			{
				for (int i = 0; i < int_0; i++)
				{
					if (byte_0[i] != protocolSecureKey[i])
					{
						Logging.Error("ServerListenSocket: invalid protocol key");
						return;
					}
				}
				Class2.smethod_2(byte_1, int_1);
				return;
			}
			Logging.Error("ServerListenSocket: invalid protocol key");
		}

		// Token: 0x0400004D RID: 77
		private static NetMQSocket netMQSocket_0;

		// Token: 0x0400004E RID: 78
		private static Thread thread_0;

		// Token: 0x0400004F RID: 79
		private static bool bool_0;
	}
}
