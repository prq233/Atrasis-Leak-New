using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000B3 RID: 179
	public class AllianceShareDuelReplayMessage : ServerAccountMessage
	{
		// Token: 0x17000130 RID: 304
		// (get) Token: 0x06000500 RID: 1280 RVA: 0x000078F9 File Offset: 0x00005AF9
		// (set) Token: 0x06000501 RID: 1281 RVA: 0x00007901 File Offset: 0x00005B01
		public LogicLong MemberId { get; set; }

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x06000502 RID: 1282 RVA: 0x0000790A File Offset: 0x00005B0A
		// (set) Token: 0x06000503 RID: 1283 RVA: 0x00007912 File Offset: 0x00005B12
		public LogicLong ReplayId { get; set; }

		// Token: 0x06000504 RID: 1284 RVA: 0x0000791B File Offset: 0x00005B1B
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.MemberId);
			stream.WriteLong(this.ReplayId);
		}

		// Token: 0x06000505 RID: 1285 RVA: 0x00007935 File Offset: 0x00005B35
		public override void Decode(ByteStream stream)
		{
			this.MemberId = stream.ReadLong();
			this.ReplayId = stream.ReadLong();
		}

		// Token: 0x06000506 RID: 1286 RVA: 0x0000794F File Offset: 0x00005B4F
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.ALLIANCE_SHARE_DUEL_REPLAY;
		}

		// Token: 0x04000217 RID: 535
		[CompilerGenerated]
		private LogicLong logicLong_1;

		// Token: 0x04000218 RID: 536
		[CompilerGenerated]
		private LogicLong logicLong_2;
	}
}
