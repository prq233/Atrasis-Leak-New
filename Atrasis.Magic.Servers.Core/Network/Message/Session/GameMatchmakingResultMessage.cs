using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x0200003A RID: 58
	public class GameMatchmakingResultMessage : ServerSessionMessage
	{
		// Token: 0x17000053 RID: 83
		// (get) Token: 0x0600015E RID: 350 RVA: 0x00005360 File Offset: 0x00003560
		// (set) Token: 0x0600015F RID: 351 RVA: 0x00005368 File Offset: 0x00003568
		public LogicLong EnemyId { get; set; }

		// Token: 0x06000160 RID: 352 RVA: 0x00005371 File Offset: 0x00003571
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.EnemyId);
		}

		// Token: 0x06000161 RID: 353 RVA: 0x0000537F File Offset: 0x0000357F
		public override void Decode(ByteStream stream)
		{
			this.EnemyId = stream.ReadLong();
		}

		// Token: 0x06000162 RID: 354 RVA: 0x0000538D File Offset: 0x0000358D
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.GAME_MATCHMAKING_RESULT;
		}

		// Token: 0x040000F0 RID: 240
		[CompilerGenerated]
		private LogicLong logicLong_0;
	}
}
