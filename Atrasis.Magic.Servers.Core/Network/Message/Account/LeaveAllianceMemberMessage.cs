using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000C2 RID: 194
	public class LeaveAllianceMemberMessage : ServerAccountMessage
	{
		// Token: 0x17000154 RID: 340
		// (get) Token: 0x06000584 RID: 1412 RVA: 0x00007DBF File Offset: 0x00005FBF
		// (set) Token: 0x06000585 RID: 1413 RVA: 0x00007DC7 File Offset: 0x00005FC7
		public LogicLong MemberId { get; set; }

		// Token: 0x06000586 RID: 1414 RVA: 0x00007DD0 File Offset: 0x00005FD0
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.MemberId);
		}

		// Token: 0x06000587 RID: 1415 RVA: 0x00007DDE File Offset: 0x00005FDE
		public override void Decode(ByteStream stream)
		{
			this.MemberId = stream.ReadLong();
		}

		// Token: 0x06000588 RID: 1416 RVA: 0x00007DEC File Offset: 0x00005FEC
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.LEAVE_ALLIANCE_MEMBER;
		}

		// Token: 0x0400023B RID: 571
		[CompilerGenerated]
		private LogicLong logicLong_1;
	}
}
