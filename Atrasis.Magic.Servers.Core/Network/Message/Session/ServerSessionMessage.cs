using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x02000041 RID: 65
	public abstract class ServerSessionMessage : ServerMessage
	{
		// Token: 0x1700005C RID: 92
		// (get) Token: 0x0600018C RID: 396 RVA: 0x000054EF File Offset: 0x000036EF
		// (set) Token: 0x0600018D RID: 397 RVA: 0x000054F7 File Offset: 0x000036F7
		public long SessionId { get; set; }

		// Token: 0x0600018E RID: 398 RVA: 0x00005500 File Offset: 0x00003700
		public sealed override void EncodeHeader(ByteStream stream)
		{
			base.EncodeHeader(stream);
			stream.WriteLongLong(this.SessionId);
		}

		// Token: 0x0600018F RID: 399 RVA: 0x00005515 File Offset: 0x00003715
		public sealed override void DecodeHeader(ByteStream stream)
		{
			base.DecodeHeader(stream);
			this.SessionId = stream.ReadLongLong();
		}

		// Token: 0x06000190 RID: 400 RVA: 0x0000552A File Offset: 0x0000372A
		public sealed override ServerMessageCategory GetMessageCategory()
		{
			return ServerMessageCategory.SESSION;
		}

		// Token: 0x040000F9 RID: 249
		[CompilerGenerated]
		private long long_0;
	}
}
