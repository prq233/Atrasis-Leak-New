using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Message.Avatar.Stream;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request.Stream
{
	// Token: 0x0200008E RID: 142
	public class CreateAvatarStreamResponseMessage : ServerResponseMessage
	{
		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x060003F4 RID: 1012 RVA: 0x00006E2E File Offset: 0x0000502E
		// (set) Token: 0x060003F5 RID: 1013 RVA: 0x00006E36 File Offset: 0x00005036
		public AvatarStreamEntry Entry { get; set; }

		// Token: 0x060003F6 RID: 1014 RVA: 0x00006E3F File Offset: 0x0000503F
		public override void Encode(ByteStream stream)
		{
			if (base.Success)
			{
				stream.WriteVInt((int)this.Entry.GetAvatarStreamEntryType());
				this.Entry.Encode(stream);
			}
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x00006E66 File Offset: 0x00005066
		public override void Decode(ByteStream stream)
		{
			if (base.Success)
			{
				this.Entry = AvatarStreamEntryFactory.CreateStreamEntryByType((AvatarStreamEntryType)stream.ReadVInt());
				this.Entry.Decode(stream);
			}
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x00006E8D File Offset: 0x0000508D
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.CREATE_AVATAR_STREAM_RESPONSE;
		}

		// Token: 0x040001D5 RID: 469
		[CompilerGenerated]
		private AvatarStreamEntry avatarStreamEntry_0;
	}
}
