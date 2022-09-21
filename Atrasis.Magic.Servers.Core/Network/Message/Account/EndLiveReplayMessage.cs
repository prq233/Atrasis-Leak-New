using System;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000BD RID: 189
	public class EndLiveReplayMessage : ServerAccountMessage
	{
		// Token: 0x0600055C RID: 1372 RVA: 0x00004631 File Offset: 0x00002831
		public override void Encode(ByteStream stream)
		{
		}

		// Token: 0x0600055D RID: 1373 RVA: 0x00004631 File Offset: 0x00002831
		public override void Decode(ByteStream stream)
		{
		}

		// Token: 0x0600055E RID: 1374 RVA: 0x00007C58 File Offset: 0x00005E58
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.END_LIVE_REPLAY;
		}
	}
}
