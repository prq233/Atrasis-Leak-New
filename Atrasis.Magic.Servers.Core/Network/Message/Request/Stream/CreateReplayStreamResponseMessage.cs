using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request.Stream
{
	// Token: 0x02000090 RID: 144
	public class CreateReplayStreamResponseMessage : ServerResponseMessage
	{
		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x06000400 RID: 1024 RVA: 0x00006ECD File Offset: 0x000050CD
		// (set) Token: 0x06000401 RID: 1025 RVA: 0x00006ED5 File Offset: 0x000050D5
		public LogicLong Id { get; set; }

		// Token: 0x06000402 RID: 1026 RVA: 0x00006EDE File Offset: 0x000050DE
		public override void Encode(ByteStream stream)
		{
			if (base.Success)
			{
				stream.WriteLong(this.Id);
			}
		}

		// Token: 0x06000403 RID: 1027 RVA: 0x00006EF4 File Offset: 0x000050F4
		public override void Decode(ByteStream stream)
		{
			if (base.Success)
			{
				this.Id = stream.ReadLong();
			}
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x00006F0A File Offset: 0x0000510A
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.CREATE_REPLAY_STREAM_RESPONSE;
		}

		// Token: 0x040001D7 RID: 471
		[CompilerGenerated]
		private LogicLong logicLong_0;
	}
}
