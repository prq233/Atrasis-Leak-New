using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000BA RID: 186
	public class DuelProgressMessage : ServerAccountMessage
	{
		// Token: 0x17000142 RID: 322
		// (get) Token: 0x06000540 RID: 1344 RVA: 0x00007B6B File Offset: 0x00005D6B
		// (set) Token: 0x06000541 RID: 1345 RVA: 0x00007B73 File Offset: 0x00005D73
		public LogicLong AvatarId { get; set; }

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x06000542 RID: 1346 RVA: 0x00007B7C File Offset: 0x00005D7C
		// (set) Token: 0x06000543 RID: 1347 RVA: 0x00007B84 File Offset: 0x00005D84
		public int RemainingSeconds { get; set; }

		// Token: 0x06000544 RID: 1348 RVA: 0x00007B8D File Offset: 0x00005D8D
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.AvatarId);
			stream.WriteVInt(this.RemainingSeconds);
		}

		// Token: 0x06000545 RID: 1349 RVA: 0x00007BA7 File Offset: 0x00005DA7
		public override void Decode(ByteStream stream)
		{
			this.AvatarId = stream.ReadLong();
			this.RemainingSeconds = stream.ReadVInt();
		}

		// Token: 0x06000546 RID: 1350 RVA: 0x00007BC1 File Offset: 0x00005DC1
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.DUEL_PROGRESS;
		}

		// Token: 0x04000229 RID: 553
		[CompilerGenerated]
		private LogicLong logicLong_1;

		// Token: 0x0400022A RID: 554
		[CompilerGenerated]
		private int int_2;
	}
}
