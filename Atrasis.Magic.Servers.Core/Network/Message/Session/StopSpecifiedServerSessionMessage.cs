using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x02000047 RID: 71
	public class StopSpecifiedServerSessionMessage : ServerSessionMessage
	{
		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060001B1 RID: 433 RVA: 0x000055E4 File Offset: 0x000037E4
		// (set) Token: 0x060001B2 RID: 434 RVA: 0x000055EC File Offset: 0x000037EC
		public int ServerType { get; set; }

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x060001B3 RID: 435 RVA: 0x000055F5 File Offset: 0x000037F5
		// (set) Token: 0x060001B4 RID: 436 RVA: 0x000055FD File Offset: 0x000037FD
		public int ServerId { get; set; }

		// Token: 0x060001B5 RID: 437 RVA: 0x00005606 File Offset: 0x00003806
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.ServerType);
			stream.WriteVInt(this.ServerId);
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x00005620 File Offset: 0x00003820
		public override void Decode(ByteStream stream)
		{
			this.ServerType = stream.ReadVInt();
			this.ServerId = stream.ReadVInt();
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x0000563A File Offset: 0x0000383A
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.STOP_SPECIFIED_SERVER_SESSION;
		}

		// Token: 0x04000100 RID: 256
		[CompilerGenerated]
		private int int_2;

		// Token: 0x04000101 RID: 257
		[CompilerGenerated]
		private int int_3;
	}
}
