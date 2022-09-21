using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000AC RID: 172
	public class AllianceChallengeReportMessage : ServerAccountMessage
	{
		// Token: 0x1700011A RID: 282
		// (get) Token: 0x060004B8 RID: 1208 RVA: 0x000075CD File Offset: 0x000057CD
		// (set) Token: 0x060004B9 RID: 1209 RVA: 0x000075D5 File Offset: 0x000057D5
		public LogicLong StreamId { get; set; }

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x060004BA RID: 1210 RVA: 0x000075DE File Offset: 0x000057DE
		// (set) Token: 0x060004BB RID: 1211 RVA: 0x000075E6 File Offset: 0x000057E6
		public LogicLong ReplayId { get; set; }

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x060004BC RID: 1212 RVA: 0x000075EF File Offset: 0x000057EF
		// (set) Token: 0x060004BD RID: 1213 RVA: 0x000075F7 File Offset: 0x000057F7
		public string BattleLog { get; set; }

		// Token: 0x060004BE RID: 1214 RVA: 0x00007600 File Offset: 0x00005800
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.StreamId);
			if (this.ReplayId != null)
			{
				stream.WriteBoolean(true);
				stream.WriteLong(this.ReplayId);
			}
			else
			{
				stream.WriteBoolean(false);
			}
			stream.WriteString(this.BattleLog);
		}

		// Token: 0x060004BF RID: 1215 RVA: 0x0000763E File Offset: 0x0000583E
		public override void Decode(ByteStream stream)
		{
			this.StreamId = stream.ReadLong();
			if (stream.ReadBoolean())
			{
				this.ReplayId = stream.ReadLong();
			}
			this.BattleLog = stream.ReadString(900000);
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x00007671 File Offset: 0x00005871
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.ALLIANCE_CHALLENGE_REPORT;
		}

		// Token: 0x04000201 RID: 513
		[CompilerGenerated]
		private LogicLong logicLong_1;

		// Token: 0x04000202 RID: 514
		[CompilerGenerated]
		private LogicLong logicLong_2;

		// Token: 0x04000203 RID: 515
		[CompilerGenerated]
		private string string_0;
	}
}
