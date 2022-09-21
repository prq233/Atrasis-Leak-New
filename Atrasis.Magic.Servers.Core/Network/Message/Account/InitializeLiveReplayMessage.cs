using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000C1 RID: 193
	public class InitializeLiveReplayMessage : ServerAccountMessage
	{
		// Token: 0x17000153 RID: 339
		// (get) Token: 0x0600057E RID: 1406 RVA: 0x00007D78 File Offset: 0x00005F78
		// (set) Token: 0x0600057F RID: 1407 RVA: 0x00007D80 File Offset: 0x00005F80
		public byte[] StreamData { get; set; }

		// Token: 0x06000580 RID: 1408 RVA: 0x00007D89 File Offset: 0x00005F89
		public override void Encode(ByteStream stream)
		{
			stream.WriteBytes(this.StreamData, this.StreamData.Length);
		}

		// Token: 0x06000581 RID: 1409 RVA: 0x00007D9F File Offset: 0x00005F9F
		public override void Decode(ByteStream stream)
		{
			this.StreamData = stream.ReadBytes(stream.ReadBytesLength(), 900000);
		}

		// Token: 0x06000582 RID: 1410 RVA: 0x00007DB8 File Offset: 0x00005FB8
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.INITIALIZE_LIVE_REPLAY;
		}

		// Token: 0x0400023A RID: 570
		[CompilerGenerated]
		private byte[] byte_0;
	}
}
