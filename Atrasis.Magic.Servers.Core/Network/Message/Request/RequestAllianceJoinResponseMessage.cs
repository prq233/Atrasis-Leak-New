using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request
{
	// Token: 0x02000089 RID: 137
	public class RequestAllianceJoinResponseMessage : ServerResponseMessage
	{
		// Token: 0x170000EB RID: 235
		// (get) Token: 0x060003D8 RID: 984 RVA: 0x00006CCC File Offset: 0x00004ECC
		// (set) Token: 0x060003D9 RID: 985 RVA: 0x00006CD4 File Offset: 0x00004ED4
		public RequestAllianceJoinResponseMessage.Reason ErrorReason { get; set; }

		// Token: 0x060003DA RID: 986 RVA: 0x00006CDD File Offset: 0x00004EDD
		public override void Encode(ByteStream stream)
		{
			if (!base.Success)
			{
				stream.WriteVInt((int)this.ErrorReason);
			}
		}

		// Token: 0x060003DB RID: 987 RVA: 0x00006CF3 File Offset: 0x00004EF3
		public override void Decode(ByteStream stream)
		{
			if (!base.Success)
			{
				this.ErrorReason = (RequestAllianceJoinResponseMessage.Reason)stream.ReadVInt();
			}
		}

		// Token: 0x060003DC RID: 988 RVA: 0x00006D09 File Offset: 0x00004F09
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.REQUEST_ALLIANCE_JOIN_RESPONSE;
		}

		// Token: 0x040001C7 RID: 455
		[CompilerGenerated]
		private RequestAllianceJoinResponseMessage.Reason reason_0;

		// Token: 0x0200008A RID: 138
		public enum Reason
		{
			// Token: 0x040001C9 RID: 457
			GENERIC,
			// Token: 0x040001CA RID: 458
			CLOSED,
			// Token: 0x040001CB RID: 459
			ALREADY_SENT,
			// Token: 0x040001CC RID: 460
			NO_SCORE,
			// Token: 0x040001CD RID: 461
			BANNED,
			// Token: 0x040001CE RID: 462
			TOO_MANY_PENDING_REQUESTS,
			// Token: 0x040001CF RID: 463
			NO_DUEL_SCORE
		}
	}
}
