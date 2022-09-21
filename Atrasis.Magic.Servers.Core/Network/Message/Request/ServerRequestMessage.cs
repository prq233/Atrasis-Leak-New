using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request
{
	// Token: 0x0200008B RID: 139
	public abstract class ServerRequestMessage : ServerMessage
	{
		// Token: 0x170000EC RID: 236
		// (get) Token: 0x060003DE RID: 990 RVA: 0x00006D10 File Offset: 0x00004F10
		// (set) Token: 0x060003DF RID: 991 RVA: 0x00006D18 File Offset: 0x00004F18
		internal long RequestId { get; set; }

		// Token: 0x060003E0 RID: 992 RVA: 0x00006D21 File Offset: 0x00004F21
		public sealed override void EncodeHeader(ByteStream stream)
		{
			base.EncodeHeader(stream);
			stream.WriteLongLong(this.RequestId);
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x00006D36 File Offset: 0x00004F36
		public sealed override void DecodeHeader(ByteStream stream)
		{
			base.DecodeHeader(stream);
			this.RequestId = stream.ReadLongLong();
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x00005A53 File Offset: 0x00003C53
		public sealed override ServerMessageCategory GetMessageCategory()
		{
			return ServerMessageCategory.REQUEST;
		}

		// Token: 0x040001D0 RID: 464
		[CompilerGenerated]
		private long long_0;
	}
}
