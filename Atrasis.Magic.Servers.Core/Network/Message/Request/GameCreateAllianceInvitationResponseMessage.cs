using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request
{
	// Token: 0x0200007E RID: 126
	public class GameCreateAllianceInvitationResponseMessage : ServerResponseMessage
	{
		// Token: 0x170000DA RID: 218
		// (get) Token: 0x06000396 RID: 918 RVA: 0x00006A2B File Offset: 0x00004C2B
		// (set) Token: 0x06000397 RID: 919 RVA: 0x00006A33 File Offset: 0x00004C33
		public GameCreateAllianceInvitationResponseMessage.Reason ErrorReason { get; set; }

		// Token: 0x06000398 RID: 920 RVA: 0x00006A3C File Offset: 0x00004C3C
		public override void Encode(ByteStream stream)
		{
			if (!base.Success)
			{
				stream.WriteVInt((int)this.ErrorReason);
			}
		}

		// Token: 0x06000399 RID: 921 RVA: 0x00006A52 File Offset: 0x00004C52
		public override void Decode(ByteStream stream)
		{
			if (!base.Success)
			{
				this.ErrorReason = (GameCreateAllianceInvitationResponseMessage.Reason)stream.ReadVInt();
			}
		}

		// Token: 0x0600039A RID: 922 RVA: 0x00006A68 File Offset: 0x00004C68
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.GAME_CREATE_ALLIANCE_INVITATION_RESPONSE;
		}

		// Token: 0x040001A5 RID: 421
		[CompilerGenerated]
		private GameCreateAllianceInvitationResponseMessage.Reason reason_0;

		// Token: 0x0200007F RID: 127
		public enum Reason
		{
			// Token: 0x040001A7 RID: 423
			GENERIC,
			// Token: 0x040001A8 RID: 424
			NO_CASTLE,
			// Token: 0x040001A9 RID: 425
			ALREADY_IN_ALLIANCE,
			// Token: 0x040001AA RID: 426
			ALREADY_HAS_AN_INVITE,
			// Token: 0x040001AB RID: 427
			HAS_TOO_MANY_INVITES
		}
	}
}
