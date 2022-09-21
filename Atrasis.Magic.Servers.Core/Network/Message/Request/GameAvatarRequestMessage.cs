using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request
{
	// Token: 0x0200007B RID: 123
	public class GameAvatarRequestMessage : ServerRequestMessage
	{
		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x06000382 RID: 898 RVA: 0x0000694B File Offset: 0x00004B4B
		// (set) Token: 0x06000383 RID: 899 RVA: 0x00006953 File Offset: 0x00004B53
		public LogicLong AccountId { get; set; }

		// Token: 0x06000384 RID: 900 RVA: 0x0000695C File Offset: 0x00004B5C
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.AccountId);
		}

		// Token: 0x06000385 RID: 901 RVA: 0x0000696A File Offset: 0x00004B6A
		public override void Decode(ByteStream stream)
		{
			this.AccountId = stream.ReadLong();
		}

		// Token: 0x06000386 RID: 902 RVA: 0x00006978 File Offset: 0x00004B78
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.GAME_AVATAR_REQUEST;
		}

		// Token: 0x040001A1 RID: 417
		[CompilerGenerated]
		private LogicLong logicLong_0;
	}
}
