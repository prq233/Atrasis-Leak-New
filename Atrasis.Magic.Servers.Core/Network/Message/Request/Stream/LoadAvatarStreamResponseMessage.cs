using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Message.Avatar.Stream;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request.Stream
{
	// Token: 0x02000097 RID: 151
	public class LoadAvatarStreamResponseMessage : ServerResponseMessage
	{
		// Token: 0x170000FC RID: 252
		// (get) Token: 0x0600042A RID: 1066 RVA: 0x0000707C File Offset: 0x0000527C
		// (set) Token: 0x0600042B RID: 1067 RVA: 0x00007084 File Offset: 0x00005284
		public AvatarStreamEntry Entry { get; set; }

		// Token: 0x0600042C RID: 1068 RVA: 0x0000708D File Offset: 0x0000528D
		public override void Encode(ByteStream stream)
		{
			if (base.Success)
			{
				stream.WriteVInt((int)this.Entry.GetAvatarStreamEntryType());
				this.Entry.Encode(stream);
			}
		}

		// Token: 0x0600042D RID: 1069 RVA: 0x000070B4 File Offset: 0x000052B4
		public override void Decode(ByteStream stream)
		{
			if (base.Success)
			{
				this.Entry = AvatarStreamEntryFactory.CreateStreamEntryByType((AvatarStreamEntryType)stream.ReadVInt());
				this.Entry.Decode(stream);
			}
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x000070DB File Offset: 0x000052DB
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.LOAD_AVATAR_STREAM_RESPONSE;
		}

		// Token: 0x040001E3 RID: 483
		[CompilerGenerated]
		private AvatarStreamEntry avatarStreamEntry_0;
	}
}
