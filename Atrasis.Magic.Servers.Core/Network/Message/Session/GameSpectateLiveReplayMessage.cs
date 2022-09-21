using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x0200003B RID: 59
	public class GameSpectateLiveReplayMessage : ServerSessionMessage
	{
		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000164 RID: 356 RVA: 0x00005394 File Offset: 0x00003594
		// (set) Token: 0x06000165 RID: 357 RVA: 0x0000539C File Offset: 0x0000359C
		public LogicLong LiveReplayId { get; set; }

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x06000166 RID: 358 RVA: 0x000053A5 File Offset: 0x000035A5
		// (set) Token: 0x06000167 RID: 359 RVA: 0x000053AD File Offset: 0x000035AD
		public bool IsEnemy { get; set; }

		// Token: 0x06000168 RID: 360 RVA: 0x000053B6 File Offset: 0x000035B6
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.LiveReplayId);
			stream.WriteBoolean(this.IsEnemy);
		}

		// Token: 0x06000169 RID: 361 RVA: 0x000053D0 File Offset: 0x000035D0
		public override void Decode(ByteStream stream)
		{
			this.LiveReplayId = stream.ReadLong();
			this.IsEnemy = stream.ReadBoolean();
		}

		// Token: 0x0600016A RID: 362 RVA: 0x000053EA File Offset: 0x000035EA
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.GAME_SPECTATE_LIVE_REPLAY;
		}

		// Token: 0x040000F1 RID: 241
		[CompilerGenerated]
		private LogicLong logicLong_0;

		// Token: 0x040000F2 RID: 242
		[CompilerGenerated]
		private bool bool_0;
	}
}
