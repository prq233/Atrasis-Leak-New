using System;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Core
{
	// Token: 0x020000A0 RID: 160
	public class PingMessage : ServerCoreMessage
	{
		// Token: 0x0600046C RID: 1132 RVA: 0x00004631 File Offset: 0x00002831
		public override void Encode(ByteStream stream)
		{
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x00004631 File Offset: 0x00002831
		public override void Decode(ByteStream stream)
		{
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x00007359 File Offset: 0x00005559
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.PING;
		}
	}
}
