using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x02000037 RID: 55
	public class GameDuelMatchmakingResultMessage : ServerSessionMessage
	{
		// Token: 0x1700004E RID: 78
		// (get) Token: 0x06000148 RID: 328 RVA: 0x00005263 File Offset: 0x00003463
		// (set) Token: 0x06000149 RID: 329 RVA: 0x0000526B File Offset: 0x0000346B
		public long EnemySessionId { get; set; }

		// Token: 0x0600014A RID: 330 RVA: 0x00005274 File Offset: 0x00003474
		public override void Encode(ByteStream stream)
		{
			stream.WriteLongLong(this.EnemySessionId);
		}

		// Token: 0x0600014B RID: 331 RVA: 0x00005282 File Offset: 0x00003482
		public override void Decode(ByteStream stream)
		{
			this.EnemySessionId = stream.ReadLongLong();
		}

		// Token: 0x0600014C RID: 332 RVA: 0x00005290 File Offset: 0x00003490
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.GAME_DUEL_MATCHMAKING_RESULT;
		}

		// Token: 0x040000EB RID: 235
		[CompilerGenerated]
		private long long_1;
	}
}
