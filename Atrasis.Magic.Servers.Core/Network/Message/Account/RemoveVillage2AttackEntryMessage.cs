using System;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000C5 RID: 197
	public class RemoveVillage2AttackEntryMessage : ServerAccountMessage
	{
		// Token: 0x06000596 RID: 1430 RVA: 0x00004631 File Offset: 0x00002831
		public override void Encode(ByteStream stream)
		{
		}

		// Token: 0x06000597 RID: 1431 RVA: 0x00004631 File Offset: 0x00002831
		public override void Decode(ByteStream stream)
		{
		}

		// Token: 0x06000598 RID: 1432 RVA: 0x00007E57 File Offset: 0x00006057
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.REMOVE_VILLAGE2_ATTACK_ENTRY;
		}
	}
}
