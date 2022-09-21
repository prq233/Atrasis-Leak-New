using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request
{
	// Token: 0x02000072 RID: 114
	public class AllianceJoinResponseMessage : ServerResponseMessage
	{
		// Token: 0x170000BC RID: 188
		// (get) Token: 0x06000332 RID: 818 RVA: 0x0000667B File Offset: 0x0000487B
		// (set) Token: 0x06000333 RID: 819 RVA: 0x00006683 File Offset: 0x00004883
		public LogicLong AllianceId { get; set; }

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x06000334 RID: 820 RVA: 0x0000668C File Offset: 0x0000488C
		// (set) Token: 0x06000335 RID: 821 RVA: 0x00006694 File Offset: 0x00004894
		public string AllianceName { get; set; }

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x06000336 RID: 822 RVA: 0x0000669D File Offset: 0x0000489D
		// (set) Token: 0x06000337 RID: 823 RVA: 0x000066A5 File Offset: 0x000048A5
		public int AllianceLevel { get; set; }

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x06000338 RID: 824 RVA: 0x000066AE File Offset: 0x000048AE
		// (set) Token: 0x06000339 RID: 825 RVA: 0x000066B6 File Offset: 0x000048B6
		public int AllianceBadgeId { get; set; }

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x0600033A RID: 826 RVA: 0x000066BF File Offset: 0x000048BF
		// (set) Token: 0x0600033B RID: 827 RVA: 0x000066C7 File Offset: 0x000048C7
		public bool Created { get; set; }

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x0600033C RID: 828 RVA: 0x000066D0 File Offset: 0x000048D0
		// (set) Token: 0x0600033D RID: 829 RVA: 0x000066D8 File Offset: 0x000048D8
		public AllianceJoinResponseMessage.Reason ErrorReason { get; set; }

		// Token: 0x0600033E RID: 830 RVA: 0x0000C8B8 File Offset: 0x0000AAB8
		public override void Encode(ByteStream stream)
		{
			if (base.Success)
			{
				stream.WriteLong(this.AllianceId);
				stream.WriteString(this.AllianceName);
				stream.WriteVInt(this.AllianceLevel);
				stream.WriteVInt(this.AllianceBadgeId);
				stream.WriteBoolean(this.Created);
				return;
			}
			stream.WriteVInt((int)this.ErrorReason);
		}

		// Token: 0x0600033F RID: 831 RVA: 0x0000C918 File Offset: 0x0000AB18
		public override void Decode(ByteStream stream)
		{
			if (base.Success)
			{
				this.AllianceId = stream.ReadLong();
				this.AllianceName = stream.ReadString(900000);
				this.AllianceLevel = stream.ReadVInt();
				this.AllianceBadgeId = stream.ReadVInt();
				this.Created = stream.ReadBoolean();
				return;
			}
			this.ErrorReason = (AllianceJoinResponseMessage.Reason)stream.ReadVInt();
		}

		// Token: 0x06000340 RID: 832 RVA: 0x000066E1 File Offset: 0x000048E1
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.ALLIANCE_JOIN_RESPONSE;
		}

		// Token: 0x0400017B RID: 379
		[CompilerGenerated]
		private LogicLong logicLong_0;

		// Token: 0x0400017C RID: 380
		[CompilerGenerated]
		private string string_0;

		// Token: 0x0400017D RID: 381
		[CompilerGenerated]
		private int int_2;

		// Token: 0x0400017E RID: 382
		[CompilerGenerated]
		private int int_3;

		// Token: 0x0400017F RID: 383
		[CompilerGenerated]
		private bool bool_1;

		// Token: 0x04000180 RID: 384
		[CompilerGenerated]
		private AllianceJoinResponseMessage.Reason reason_0;

		// Token: 0x02000073 RID: 115
		public enum Reason
		{
			// Token: 0x04000182 RID: 386
			GENERIC,
			// Token: 0x04000183 RID: 387
			FULL,
			// Token: 0x04000184 RID: 388
			CLOSED,
			// Token: 0x04000185 RID: 389
			SCORE,
			// Token: 0x04000186 RID: 390
			BANNED
		}
	}
}
