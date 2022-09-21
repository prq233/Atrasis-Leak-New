using System;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.State
{
	// Token: 0x02000055 RID: 85
	public class GameStateNullDataMessage : ServerSessionMessage
	{
		// Token: 0x06000237 RID: 567 RVA: 0x00004631 File Offset: 0x00002831
		public override void Encode(ByteStream stream)
		{
		}

		// Token: 0x06000238 RID: 568 RVA: 0x00004631 File Offset: 0x00002831
		public override void Decode(ByteStream stream)
		{
		}

		// Token: 0x06000239 RID: 569 RVA: 0x00005B86 File Offset: 0x00003D86
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.GAME_STATE_NULL_DATA;
		}
	}
}
