using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000B1 RID: 177
	public class AllianceLeavedMessage : ServerAccountMessage
	{
		// Token: 0x17000128 RID: 296
		// (get) Token: 0x060004E8 RID: 1256 RVA: 0x00007847 File Offset: 0x00005A47
		// (set) Token: 0x060004E9 RID: 1257 RVA: 0x0000784F File Offset: 0x00005A4F
		public LogicLong AllianceId { get; set; }

		// Token: 0x060004EA RID: 1258 RVA: 0x00007858 File Offset: 0x00005A58
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.AllianceId);
		}

		// Token: 0x060004EB RID: 1259 RVA: 0x00007866 File Offset: 0x00005A66
		public override void Decode(ByteStream stream)
		{
			this.AllianceId = stream.ReadLong();
		}

		// Token: 0x060004EC RID: 1260 RVA: 0x00007874 File Offset: 0x00005A74
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.ALLIANCE_LEAVED;
		}

		// Token: 0x0400020F RID: 527
		[CompilerGenerated]
		private LogicLong logicLong_1;
	}
}
