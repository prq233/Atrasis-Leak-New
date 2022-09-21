using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request.Stream
{
	// Token: 0x02000096 RID: 150
	public class LoadAvatarStreamRequestMessage : ServerRequestMessage
	{
		// Token: 0x170000FB RID: 251
		// (get) Token: 0x06000424 RID: 1060 RVA: 0x00007048 File Offset: 0x00005248
		// (set) Token: 0x06000425 RID: 1061 RVA: 0x00007050 File Offset: 0x00005250
		public LogicLong Id { get; set; }

		// Token: 0x06000426 RID: 1062 RVA: 0x00007059 File Offset: 0x00005259
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.Id);
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x00007067 File Offset: 0x00005267
		public override void Decode(ByteStream stream)
		{
			this.Id = stream.ReadLong();
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x00007075 File Offset: 0x00005275
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.LOAD_AVATAR_STREAM_REQUEST;
		}

		// Token: 0x040001E2 RID: 482
		[CompilerGenerated]
		private LogicLong logicLong_0;
	}
}
