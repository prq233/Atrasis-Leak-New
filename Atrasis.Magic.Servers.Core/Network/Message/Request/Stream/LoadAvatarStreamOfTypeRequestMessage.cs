using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Message.Avatar.Stream;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request.Stream
{
	// Token: 0x02000093 RID: 147
	public class LoadAvatarStreamOfTypeRequestMessage : ServerRequestMessage
	{
		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x06000414 RID: 1044 RVA: 0x00006FF6 File Offset: 0x000051F6
		// (set) Token: 0x06000415 RID: 1045 RVA: 0x00006FFE File Offset: 0x000051FE
		public LogicArrayList<LogicLong> StreamIds { get; set; }

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x06000416 RID: 1046 RVA: 0x00007007 File Offset: 0x00005207
		// (set) Token: 0x06000417 RID: 1047 RVA: 0x0000700F File Offset: 0x0000520F
		public LogicLong SenderAvatarId { get; set; }

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x06000418 RID: 1048 RVA: 0x00007018 File Offset: 0x00005218
		// (set) Token: 0x06000419 RID: 1049 RVA: 0x00007020 File Offset: 0x00005220
		public AvatarStreamEntryType Type { get; set; }

		// Token: 0x0600041A RID: 1050 RVA: 0x0000CD38 File Offset: 0x0000AF38
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.StreamIds.Size());
			for (int i = 0; i < this.StreamIds.Size(); i++)
			{
				stream.WriteLong(this.StreamIds[i]);
			}
			if (this.SenderAvatarId != null)
			{
				stream.WriteBoolean(true);
				stream.WriteLong(this.SenderAvatarId);
			}
			stream.WriteVInt((int)this.Type);
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x0000CDA8 File Offset: 0x0000AFA8
		public override void Decode(ByteStream stream)
		{
			this.StreamIds = new LogicArrayList<LogicLong>();
			for (int i = stream.ReadVInt(); i > 0; i--)
			{
				this.StreamIds.Add(stream.ReadLong());
			}
			if (stream.ReadBoolean())
			{
				this.SenderAvatarId = stream.ReadLong();
			}
			this.Type = (AvatarStreamEntryType)stream.ReadVInt();
		}

		// Token: 0x0600041C RID: 1052 RVA: 0x00007029 File Offset: 0x00005229
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.LOAD_AVATAR_STREAM_OF_TYPE_REQUEST;
		}

		// Token: 0x040001DB RID: 475
		[CompilerGenerated]
		private LogicArrayList<LogicLong> logicArrayList_0;

		// Token: 0x040001DC RID: 476
		[CompilerGenerated]
		private LogicLong logicLong_0;

		// Token: 0x040001DD RID: 477
		[CompilerGenerated]
		private AvatarStreamEntryType avatarStreamEntryType_0;
	}
}
