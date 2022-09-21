using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x02000048 RID: 72
	public class UpdateSocketServerSessionMessage : ServerSessionMessage
	{
		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060001B9 RID: 441 RVA: 0x00005641 File Offset: 0x00003841
		// (set) Token: 0x060001BA RID: 442 RVA: 0x00005649 File Offset: 0x00003849
		public int ServerType { get; set; }

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060001BB RID: 443 RVA: 0x00005652 File Offset: 0x00003852
		// (set) Token: 0x060001BC RID: 444 RVA: 0x0000565A File Offset: 0x0000385A
		public int ServerId { get; set; }

		// Token: 0x060001BD RID: 445 RVA: 0x00005663 File Offset: 0x00003863
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.ServerType);
			stream.WriteVInt(this.ServerId);
		}

		// Token: 0x060001BE RID: 446 RVA: 0x0000567D File Offset: 0x0000387D
		public override void Decode(ByteStream stream)
		{
			this.ServerType = stream.ReadVInt();
			this.ServerId = stream.ReadVInt();
		}

		// Token: 0x060001BF RID: 447 RVA: 0x00005697 File Offset: 0x00003897
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.UPDATE_SOCKET_SERVER_SESSION;
		}

		// Token: 0x04000102 RID: 258
		[CompilerGenerated]
		private int int_2;

		// Token: 0x04000103 RID: 259
		[CompilerGenerated]
		private int int_3;
	}
}
