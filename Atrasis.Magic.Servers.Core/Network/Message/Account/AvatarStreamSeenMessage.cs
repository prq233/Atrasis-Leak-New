using System;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000B6 RID: 182
	public class AvatarStreamSeenMessage : ServerAccountMessage
	{
		// Token: 0x06000524 RID: 1316 RVA: 0x00004631 File Offset: 0x00002831
		public override void Encode(ByteStream stream)
		{
		}

		// Token: 0x06000525 RID: 1317 RVA: 0x00004631 File Offset: 0x00002831
		public override void Decode(ByteStream stream)
		{
		}

		// Token: 0x06000526 RID: 1318 RVA: 0x00007A5F File Offset: 0x00005C5F
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.AVATAR_STREAM_SEEN;
		}
	}
}
