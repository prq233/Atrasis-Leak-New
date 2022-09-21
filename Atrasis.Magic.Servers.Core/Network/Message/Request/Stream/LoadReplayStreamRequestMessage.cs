using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request.Stream
{
	// Token: 0x02000098 RID: 152
	public class LoadReplayStreamRequestMessage : ServerRequestMessage
	{
		// Token: 0x170000FD RID: 253
		// (get) Token: 0x06000430 RID: 1072 RVA: 0x000070E2 File Offset: 0x000052E2
		// (set) Token: 0x06000431 RID: 1073 RVA: 0x000070EA File Offset: 0x000052EA
		public LogicLong Id { get; set; }

		// Token: 0x06000432 RID: 1074 RVA: 0x000070F3 File Offset: 0x000052F3
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.Id);
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x00007101 File Offset: 0x00005301
		public override void Decode(ByteStream stream)
		{
			this.Id = stream.ReadLong();
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x0000710F File Offset: 0x0000530F
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.LOAD_REPLAY_STREAM_REQUEST;
		}

		// Token: 0x040001E4 RID: 484
		[CompilerGenerated]
		private LogicLong logicLong_0;
	}
}
