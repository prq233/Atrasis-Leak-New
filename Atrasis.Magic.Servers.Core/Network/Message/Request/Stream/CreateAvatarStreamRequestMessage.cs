using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Message.Avatar.Stream;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request.Stream
{
	// Token: 0x0200008D RID: 141
	public class CreateAvatarStreamRequestMessage : ServerRequestMessage
	{
		// Token: 0x170000EF RID: 239
		// (get) Token: 0x060003EC RID: 1004 RVA: 0x00006DAF File Offset: 0x00004FAF
		// (set) Token: 0x060003ED RID: 1005 RVA: 0x00006DB7 File Offset: 0x00004FB7
		public LogicLong OwnerId { get; set; }

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x060003EE RID: 1006 RVA: 0x00006DC0 File Offset: 0x00004FC0
		// (set) Token: 0x060003EF RID: 1007 RVA: 0x00006DC8 File Offset: 0x00004FC8
		public AvatarStreamEntry Entry { get; set; }

		// Token: 0x060003F0 RID: 1008 RVA: 0x00006DD1 File Offset: 0x00004FD1
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.OwnerId);
			stream.WriteVInt((int)this.Entry.GetAvatarStreamEntryType());
			this.Entry.Encode(stream);
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x00006DFC File Offset: 0x00004FFC
		public override void Decode(ByteStream stream)
		{
			this.OwnerId = stream.ReadLong();
			this.Entry = AvatarStreamEntryFactory.CreateStreamEntryByType((AvatarStreamEntryType)stream.ReadVInt());
			this.Entry.Decode(stream);
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x00006E27 File Offset: 0x00005027
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.CREATE_AVATAR_STREAM_REQUEST;
		}

		// Token: 0x040001D3 RID: 467
		[CompilerGenerated]
		private LogicLong logicLong_0;

		// Token: 0x040001D4 RID: 468
		[CompilerGenerated]
		private AvatarStreamEntry avatarStreamEntry_0;
	}
}
