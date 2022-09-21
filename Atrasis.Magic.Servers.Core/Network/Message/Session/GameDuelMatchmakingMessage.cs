using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x02000036 RID: 54
	public class GameDuelMatchmakingMessage : ServerSessionMessage
	{
		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000142 RID: 322 RVA: 0x0000521C File Offset: 0x0000341C
		// (set) Token: 0x06000143 RID: 323 RVA: 0x00005224 File Offset: 0x00003424
		public byte[] Snapshot { get; set; }

		// Token: 0x06000144 RID: 324 RVA: 0x0000522D File Offset: 0x0000342D
		public override void Encode(ByteStream stream)
		{
			stream.WriteBytes(this.Snapshot, this.Snapshot.Length);
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00005243 File Offset: 0x00003443
		public override void Decode(ByteStream stream)
		{
			this.Snapshot = stream.ReadBytes(stream.ReadBytesLength(), 900000);
		}

		// Token: 0x06000146 RID: 326 RVA: 0x0000525C File Offset: 0x0000345C
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.GAME_DUEL_MATCHMAKING;
		}

		// Token: 0x040000EA RID: 234
		[CompilerGenerated]
		private byte[] byte_0;
	}
}
