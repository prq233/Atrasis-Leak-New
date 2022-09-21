using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Message.Avatar.Stream;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000B8 RID: 184
	public class CreateAvatarStreamMessage : ServerAccountMessage
	{
		// Token: 0x1700013E RID: 318
		// (get) Token: 0x06000530 RID: 1328 RVA: 0x00007A8F File Offset: 0x00005C8F
		// (set) Token: 0x06000531 RID: 1329 RVA: 0x00007A97 File Offset: 0x00005C97
		public AvatarStreamEntry Entry { get; set; }

		// Token: 0x06000532 RID: 1330 RVA: 0x00007AA0 File Offset: 0x00005CA0
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt((int)this.Entry.GetAvatarStreamEntryType());
			this.Entry.Encode(stream);
		}

		// Token: 0x06000533 RID: 1331 RVA: 0x00007ABF File Offset: 0x00005CBF
		public override void Decode(ByteStream stream)
		{
			this.Entry = AvatarStreamEntryFactory.CreateStreamEntryByType((AvatarStreamEntryType)stream.ReadVInt());
			this.Entry.Decode(stream);
		}

		// Token: 0x06000534 RID: 1332 RVA: 0x00007ADE File Offset: 0x00005CDE
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.CREATE_AVATAR_STREAM;
		}

		// Token: 0x04000225 RID: 549
		[CompilerGenerated]
		private AvatarStreamEntry avatarStreamEntry_0;
	}
}
