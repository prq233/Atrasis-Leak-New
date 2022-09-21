using System;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Core
{
	// Token: 0x020000A1 RID: 161
	public class PongMessage : ServerCoreMessage
	{
		// Token: 0x06000470 RID: 1136 RVA: 0x00004631 File Offset: 0x00002831
		public override void Encode(ByteStream stream)
		{
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x00004631 File Offset: 0x00002831
		public override void Decode(ByteStream stream)
		{
		}

		// Token: 0x06000472 RID: 1138 RVA: 0x00007360 File Offset: 0x00005560
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.PONG;
		}
	}
}
