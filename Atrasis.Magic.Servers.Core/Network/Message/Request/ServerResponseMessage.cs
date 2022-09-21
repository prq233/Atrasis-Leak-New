using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request
{
	// Token: 0x0200008C RID: 140
	public abstract class ServerResponseMessage : ServerMessage
	{
		// Token: 0x170000ED RID: 237
		// (get) Token: 0x060003E4 RID: 996 RVA: 0x00006D4B File Offset: 0x00004F4B
		// (set) Token: 0x060003E5 RID: 997 RVA: 0x00006D53 File Offset: 0x00004F53
		internal long RequestId { get; set; }

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x060003E6 RID: 998 RVA: 0x00006D5C File Offset: 0x00004F5C
		// (set) Token: 0x060003E7 RID: 999 RVA: 0x00006D64 File Offset: 0x00004F64
		public bool Success { get; set; }

		// Token: 0x060003E8 RID: 1000 RVA: 0x00006D6D File Offset: 0x00004F6D
		public sealed override void EncodeHeader(ByteStream stream)
		{
			base.EncodeHeader(stream);
			stream.WriteLongLong(this.RequestId);
			stream.WriteBoolean(this.Success);
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x00006D8E File Offset: 0x00004F8E
		public sealed override void DecodeHeader(ByteStream stream)
		{
			base.DecodeHeader(stream);
			this.RequestId = stream.ReadLongLong();
			this.Success = stream.ReadBoolean();
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x00005A9C File Offset: 0x00003C9C
		public sealed override ServerMessageCategory GetMessageCategory()
		{
			return ServerMessageCategory.RESPONSE;
		}

		// Token: 0x040001D1 RID: 465
		[CompilerGenerated]
		private long long_0;

		// Token: 0x040001D2 RID: 466
		[CompilerGenerated]
		private bool bool_0;
	}
}
