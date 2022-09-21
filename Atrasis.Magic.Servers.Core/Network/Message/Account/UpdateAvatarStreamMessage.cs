using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Message.Avatar.Stream;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000C8 RID: 200
	public class UpdateAvatarStreamMessage : ServerAccountMessage
	{
		// Token: 0x17000159 RID: 345
		// (get) Token: 0x060005A6 RID: 1446 RVA: 0x00007ECD File Offset: 0x000060CD
		// (set) Token: 0x060005A7 RID: 1447 RVA: 0x00007ED5 File Offset: 0x000060D5
		public AvatarStreamEntry Entry { get; set; }

		// Token: 0x060005A8 RID: 1448 RVA: 0x00007EDE File Offset: 0x000060DE
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt((int)this.Entry.GetAvatarStreamEntryType());
			this.Entry.Encode(stream);
		}

		// Token: 0x060005A9 RID: 1449 RVA: 0x00007EFD File Offset: 0x000060FD
		public override void Decode(ByteStream stream)
		{
			this.Entry = AvatarStreamEntryFactory.CreateStreamEntryByType((AvatarStreamEntryType)stream.ReadVInt());
			this.Entry.Decode(stream);
		}

		// Token: 0x060005AA RID: 1450 RVA: 0x00007F1C File Offset: 0x0000611C
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.UPDATE_AVATAR_STREAM;
		}

		// Token: 0x04000240 RID: 576
		[CompilerGenerated]
		private AvatarStreamEntry avatarStreamEntry_0;
	}
}
