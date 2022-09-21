using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.State
{
	// Token: 0x02000054 RID: 84
	public class GameStateDataMessage : ServerSessionMessage
	{
		// Token: 0x1700008C RID: 140
		// (get) Token: 0x06000231 RID: 561 RVA: 0x00005B30 File Offset: 0x00003D30
		// (set) Token: 0x06000232 RID: 562 RVA: 0x00005B38 File Offset: 0x00003D38
		public GameState State { get; set; }

		// Token: 0x06000233 RID: 563 RVA: 0x00005B41 File Offset: 0x00003D41
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt((int)this.State.GetGameStateType());
			this.State.Encode(stream);
		}

		// Token: 0x06000234 RID: 564 RVA: 0x00005B60 File Offset: 0x00003D60
		public override void Decode(ByteStream stream)
		{
			this.State = GameStateFactory.CreateByType((GameStateType)stream.ReadVInt());
			this.State.Decode(stream);
		}

		// Token: 0x06000235 RID: 565 RVA: 0x00005B7F File Offset: 0x00003D7F
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.GAME_STATE_DATA;
		}

		// Token: 0x04000134 RID: 308
		[CompilerGenerated]
		private GameState gameState_0;
	}
}
