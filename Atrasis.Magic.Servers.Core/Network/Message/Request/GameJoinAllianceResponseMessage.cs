using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request
{
	// Token: 0x02000081 RID: 129
	public class GameJoinAllianceResponseMessage : ServerResponseMessage
	{
		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x060003AA RID: 938 RVA: 0x00006ACB File Offset: 0x00004CCB
		// (set) Token: 0x060003AB RID: 939 RVA: 0x00006AD3 File Offset: 0x00004CD3
		public GameJoinAllianceResponseMessage.Reason ErrorReason { get; set; }

		// Token: 0x060003AC RID: 940 RVA: 0x00006ADC File Offset: 0x00004CDC
		public override void Encode(ByteStream stream)
		{
			if (!base.Success)
			{
				stream.WriteVInt((int)this.ErrorReason);
			}
		}

		// Token: 0x060003AD RID: 941 RVA: 0x00006AF2 File Offset: 0x00004CF2
		public override void Decode(ByteStream stream)
		{
			if (!base.Success)
			{
				this.ErrorReason = (GameJoinAllianceResponseMessage.Reason)stream.ReadVInt();
			}
		}

		// Token: 0x060003AE RID: 942 RVA: 0x00006B08 File Offset: 0x00004D08
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.GAME_JOIN_ALLIANCE_RESPONSE;
		}

		// Token: 0x040001B1 RID: 433
		[CompilerGenerated]
		private GameJoinAllianceResponseMessage.Reason reason_0;

		// Token: 0x02000082 RID: 130
		public enum Reason
		{
			// Token: 0x040001B3 RID: 435
			NO_CASTLE,
			// Token: 0x040001B4 RID: 436
			ALREADY_IN_ALLIANCE,
			// Token: 0x040001B5 RID: 437
			GENERIC,
			// Token: 0x040001B6 RID: 438
			FULL,
			// Token: 0x040001B7 RID: 439
			CLOSED,
			// Token: 0x040001B8 RID: 440
			SCORE,
			// Token: 0x040001B9 RID: 441
			BANNED
		}
	}
}
