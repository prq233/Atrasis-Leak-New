using System;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Core
{
	// Token: 0x020000A7 RID: 167
	public class ServerPerformanceMessage : ServerCoreMessage
	{
		// Token: 0x06000492 RID: 1170 RVA: 0x00004631 File Offset: 0x00002831
		public override void Encode(ByteStream stream)
		{
		}

		// Token: 0x06000493 RID: 1171 RVA: 0x00004631 File Offset: 0x00002831
		public override void Decode(ByteStream stream)
		{
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x000074A9 File Offset: 0x000056A9
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.SERVER_PERFORMANCE;
		}
	}
}
