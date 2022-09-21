using System;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Core
{
	// Token: 0x0200009C RID: 156
	public class AskForServerStatusMessage : ServerCoreMessage
	{
		// Token: 0x0600044E RID: 1102 RVA: 0x00004631 File Offset: 0x00002831
		public override void Encode(ByteStream stream)
		{
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x00004631 File Offset: 0x00002831
		public override void Decode(ByteStream stream)
		{
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x000071FB File Offset: 0x000053FB
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.ASK_FOR_SERVER_STATUS;
		}
	}
}
