using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Message.Avatar.Stream;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request
{
	// Token: 0x0200007D RID: 125
	public class GameCreateAllianceInvitationRequestMessage : ServerRequestMessage
	{
		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x0600038E RID: 910 RVA: 0x000069C3 File Offset: 0x00004BC3
		// (set) Token: 0x0600038F RID: 911 RVA: 0x000069CB File Offset: 0x00004BCB
		public LogicLong AccountId { get; set; }

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x06000390 RID: 912 RVA: 0x000069D4 File Offset: 0x00004BD4
		// (set) Token: 0x06000391 RID: 913 RVA: 0x000069DC File Offset: 0x00004BDC
		public AllianceInvitationAvatarStreamEntry Entry { get; set; }

		// Token: 0x06000392 RID: 914 RVA: 0x000069E5 File Offset: 0x00004BE5
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.AccountId);
			this.Entry.Encode(stream);
		}

		// Token: 0x06000393 RID: 915 RVA: 0x000069FF File Offset: 0x00004BFF
		public override void Decode(ByteStream stream)
		{
			this.AccountId = stream.ReadLong();
			this.Entry = new AllianceInvitationAvatarStreamEntry();
			this.Entry.Decode(stream);
		}

		// Token: 0x06000394 RID: 916 RVA: 0x00006A24 File Offset: 0x00004C24
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.GAME_CREATE_ALLIANCE_INVITATION_REQUEST;
		}

		// Token: 0x040001A3 RID: 419
		[CompilerGenerated]
		private LogicLong logicLong_0;

		// Token: 0x040001A4 RID: 420
		[CompilerGenerated]
		private AllianceInvitationAvatarStreamEntry allianceInvitationAvatarStreamEntry_0;
	}
}
