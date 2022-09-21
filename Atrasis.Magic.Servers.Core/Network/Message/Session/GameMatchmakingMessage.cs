using System;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x02000039 RID: 57
	public class GameMatchmakingMessage : ServerSessionMessage
	{
		// Token: 0x0600015A RID: 346 RVA: 0x00004631 File Offset: 0x00002831
		public override void Encode(ByteStream stream)
		{
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00004631 File Offset: 0x00002831
		public override void Decode(ByteStream stream)
		{
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00005359 File Offset: 0x00003559
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.GAME_MATCHMAKING;
		}
	}
}
