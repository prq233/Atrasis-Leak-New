using System;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000C4 RID: 196
	public class RemoveAvatarStreamMessage : ServerAccountMessage
	{
		// Token: 0x06000592 RID: 1426 RVA: 0x00004631 File Offset: 0x00002831
		public override void Encode(ByteStream stream)
		{
		}

		// Token: 0x06000593 RID: 1427 RVA: 0x00004631 File Offset: 0x00002831
		public override void Decode(ByteStream stream)
		{
		}

		// Token: 0x06000594 RID: 1428 RVA: 0x00007E50 File Offset: 0x00006050
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.REMOVE_AVATAR_STREAM;
		}
	}
}
