using System;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Core
{
	// Token: 0x020000A3 RID: 163
	public class ServerClusterPingMessage : ServerCoreMessage
	{
		// Token: 0x0600047C RID: 1148 RVA: 0x00004631 File Offset: 0x00002831
		public override void Encode(ByteStream stream)
		{
		}

		// Token: 0x0600047D RID: 1149 RVA: 0x00004631 File Offset: 0x00002831
		public override void Decode(ByteStream stream)
		{
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x000073E3 File Offset: 0x000055E3
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.SERVER_CLUSTER_PING;
		}
	}
}
