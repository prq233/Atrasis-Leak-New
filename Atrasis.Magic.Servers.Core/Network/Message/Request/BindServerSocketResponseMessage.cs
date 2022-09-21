using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request
{
	// Token: 0x02000077 RID: 119
	public class BindServerSocketResponseMessage : ServerResponseMessage
	{
		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x0600035A RID: 858 RVA: 0x000067BE File Offset: 0x000049BE
		// (set) Token: 0x0600035B RID: 859 RVA: 0x000067C6 File Offset: 0x000049C6
		public int ServerType { get; set; }

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x0600035C RID: 860 RVA: 0x000067CF File Offset: 0x000049CF
		// (set) Token: 0x0600035D RID: 861 RVA: 0x000067D7 File Offset: 0x000049D7
		public int ServerId { get; set; }

		// Token: 0x0600035E RID: 862 RVA: 0x000067E0 File Offset: 0x000049E0
		public override void Encode(ByteStream stream)
		{
			if (base.Success)
			{
				stream.WriteVInt(this.ServerType);
				stream.WriteVInt(this.ServerId);
			}
		}

		// Token: 0x0600035F RID: 863 RVA: 0x00006802 File Offset: 0x00004A02
		public override void Decode(ByteStream stream)
		{
			if (base.Success)
			{
				this.ServerType = stream.ReadVInt();
				this.ServerId = stream.ReadVInt();
			}
		}

		// Token: 0x06000360 RID: 864 RVA: 0x00006824 File Offset: 0x00004A24
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.BIND_SERVER_SOCKET_RESPONSE;
		}

		// Token: 0x0400018D RID: 397
		[CompilerGenerated]
		private int int_2;

		// Token: 0x0400018E RID: 398
		[CompilerGenerated]
		private int int_3;
	}
}
