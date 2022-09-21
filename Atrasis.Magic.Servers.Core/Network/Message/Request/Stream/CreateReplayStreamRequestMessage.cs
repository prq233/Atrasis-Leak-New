using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request.Stream
{
	// Token: 0x0200008F RID: 143
	public class CreateReplayStreamRequestMessage : ServerRequestMessage
	{
		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x060003FA RID: 1018 RVA: 0x00006E94 File Offset: 0x00005094
		// (set) Token: 0x060003FB RID: 1019 RVA: 0x00006E9C File Offset: 0x0000509C
		public string JSON { get; set; }

		// Token: 0x060003FC RID: 1020 RVA: 0x00006EA5 File Offset: 0x000050A5
		public override void Encode(ByteStream stream)
		{
			stream.WriteString(this.JSON);
		}

		// Token: 0x060003FD RID: 1021 RVA: 0x00006EB3 File Offset: 0x000050B3
		public override void Decode(ByteStream stream)
		{
			this.JSON = stream.ReadString(900000);
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x00006EC6 File Offset: 0x000050C6
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.CREATE_REPLAY_STREAM_REQUEST;
		}

		// Token: 0x040001D6 RID: 470
		[CompilerGenerated]
		private string string_0;
	}
}
