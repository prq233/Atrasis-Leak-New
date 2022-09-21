using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x0200003F RID: 63
	public class SendAvatarStreamsToClientMessage : ServerSessionMessage
	{
		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000180 RID: 384 RVA: 0x000054BF File Offset: 0x000036BF
		// (set) Token: 0x06000181 RID: 385 RVA: 0x000054C7 File Offset: 0x000036C7
		public LogicArrayList<LogicLong> StreamIds { get; set; }

		// Token: 0x06000182 RID: 386 RVA: 0x0000BEC0 File Offset: 0x0000A0C0
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.StreamIds.Size());
			for (int i = 0; i < this.StreamIds.Size(); i++)
			{
				stream.WriteLong(this.StreamIds[i]);
			}
		}

		// Token: 0x06000183 RID: 387 RVA: 0x0000BF08 File Offset: 0x0000A108
		public override void Decode(ByteStream stream)
		{
			this.StreamIds = new LogicArrayList<LogicLong>();
			for (int i = stream.ReadVInt(); i > 0; i--)
			{
				this.StreamIds.Add(stream.ReadLong());
			}
		}

		// Token: 0x06000184 RID: 388 RVA: 0x000054D0 File Offset: 0x000036D0
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.SEND_AVATAR_STREAMS_TO_CLIENT;
		}

		// Token: 0x040000F7 RID: 247
		[CompilerGenerated]
		private LogicArrayList<LogicLong> logicArrayList_0;
	}
}
