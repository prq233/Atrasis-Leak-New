using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request
{
	// Token: 0x02000083 RID: 131
	public class LeaderboardRequestMessage : ServerRequestMessage
	{
		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x060003B0 RID: 944 RVA: 0x00006B0F File Offset: 0x00004D0F
		// (set) Token: 0x060003B1 RID: 945 RVA: 0x00006B17 File Offset: 0x00004D17
		public int Count { get; set; }

		// Token: 0x060003B2 RID: 946 RVA: 0x00006B20 File Offset: 0x00004D20
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.Count);
		}

		// Token: 0x060003B3 RID: 947 RVA: 0x00006B2E File Offset: 0x00004D2E
		public override void Decode(ByteStream stream)
		{
			this.Count = stream.ReadVInt();
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x00006B3C File Offset: 0x00004D3C
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.LEADERBOARD_REQUEST;
		}

		// Token: 0x040001BA RID: 442
		[CompilerGenerated]
		private int int_2;
	}
}
