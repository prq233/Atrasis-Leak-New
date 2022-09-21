using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Alliance
{
	// Token: 0x020000B0 RID: 176
	public class AllianceJoinFailedMessage : PiranhaMessage
	{
		// Token: 0x06000799 RID: 1945 RVA: 0x000065D7 File Offset: 0x000047D7
		public AllianceJoinFailedMessage() : this(0)
		{
		}

		// Token: 0x0600079A RID: 1946 RVA: 0x0000328C File Offset: 0x0000148C
		public AllianceJoinFailedMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x0600079B RID: 1947 RVA: 0x000065E0 File Offset: 0x000047E0
		public override void Decode()
		{
			base.Decode();
			this.reason_0 = (AllianceJoinFailedMessage.Reason)this.m_stream.ReadInt();
		}

		// Token: 0x0600079C RID: 1948 RVA: 0x000065F9 File Offset: 0x000047F9
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt((int)this.reason_0);
		}

		// Token: 0x0600079D RID: 1949 RVA: 0x00006612 File Offset: 0x00004812
		public override short GetMessageType()
		{
			return 24302;
		}

		// Token: 0x0600079E RID: 1950 RVA: 0x000046E0 File Offset: 0x000028E0
		public override int GetServiceNodeType()
		{
			return 11;
		}

		// Token: 0x0600079F RID: 1951 RVA: 0x0000341E File Offset: 0x0000161E
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060007A0 RID: 1952 RVA: 0x00006619 File Offset: 0x00004819
		public AllianceJoinFailedMessage.Reason GetReason()
		{
			return this.reason_0;
		}

		// Token: 0x060007A1 RID: 1953 RVA: 0x00006621 File Offset: 0x00004821
		public void SetReason(AllianceJoinFailedMessage.Reason reason)
		{
			this.reason_0 = reason;
		}

		// Token: 0x040002EB RID: 747
		public const int MESSAGE_TYPE = 24302;

		// Token: 0x040002EC RID: 748
		private AllianceJoinFailedMessage.Reason reason_0;

		// Token: 0x020000B1 RID: 177
		public enum Reason
		{
			// Token: 0x040002EE RID: 750
			GENERIC,
			// Token: 0x040002EF RID: 751
			FULL,
			// Token: 0x040002F0 RID: 752
			CLOSED,
			// Token: 0x040002F1 RID: 753
			ALREADY_IN_ALLIANCE,
			// Token: 0x040002F2 RID: 754
			SCORE,
			// Token: 0x040002F3 RID: 755
			BANNED
		}
	}
}
