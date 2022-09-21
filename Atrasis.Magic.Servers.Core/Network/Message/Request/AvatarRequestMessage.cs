using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request
{
	// Token: 0x02000074 RID: 116
	public class AvatarRequestMessage : ServerRequestMessage
	{
		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x06000342 RID: 834 RVA: 0x000066F0 File Offset: 0x000048F0
		// (set) Token: 0x06000343 RID: 835 RVA: 0x000066F8 File Offset: 0x000048F8
		public LogicLong AccountId { get; set; }

		// Token: 0x06000344 RID: 836 RVA: 0x00006701 File Offset: 0x00004901
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.AccountId);
		}

		// Token: 0x06000345 RID: 837 RVA: 0x0000670F File Offset: 0x0000490F
		public override void Decode(ByteStream stream)
		{
			this.AccountId = stream.ReadLong();
		}

		// Token: 0x06000346 RID: 838 RVA: 0x0000671D File Offset: 0x0000491D
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.AVATAR_REQUEST;
		}

		// Token: 0x04000187 RID: 391
		[CompilerGenerated]
		private LogicLong logicLong_0;
	}
}
