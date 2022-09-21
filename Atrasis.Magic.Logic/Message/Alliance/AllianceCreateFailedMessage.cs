using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Alliance
{
	// Token: 0x020000A6 RID: 166
	public class AllianceCreateFailedMessage : PiranhaMessage
	{
		// Token: 0x0600073F RID: 1855 RVA: 0x0000630F File Offset: 0x0000450F
		public AllianceCreateFailedMessage() : this(0)
		{
		}

		// Token: 0x06000740 RID: 1856 RVA: 0x0000328C File Offset: 0x0000148C
		public AllianceCreateFailedMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000741 RID: 1857 RVA: 0x00006318 File Offset: 0x00004518
		public override void Decode()
		{
			base.Decode();
			this.reason_0 = (AllianceCreateFailedMessage.Reason)this.m_stream.ReadInt();
		}

		// Token: 0x06000742 RID: 1858 RVA: 0x00006331 File Offset: 0x00004531
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt((int)this.reason_0);
		}

		// Token: 0x06000743 RID: 1859 RVA: 0x0000634A File Offset: 0x0000454A
		public override short GetMessageType()
		{
			return 24332;
		}

		// Token: 0x06000744 RID: 1860 RVA: 0x000046E0 File Offset: 0x000028E0
		public override int GetServiceNodeType()
		{
			return 11;
		}

		// Token: 0x06000745 RID: 1861 RVA: 0x0000341E File Offset: 0x0000161E
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06000746 RID: 1862 RVA: 0x00006351 File Offset: 0x00004551
		public AllianceCreateFailedMessage.Reason GetReason()
		{
			return this.reason_0;
		}

		// Token: 0x06000747 RID: 1863 RVA: 0x00006359 File Offset: 0x00004559
		public void SetReason(AllianceCreateFailedMessage.Reason value)
		{
			this.reason_0 = value;
		}

		// Token: 0x040002B6 RID: 694
		public const int MESSAGE_TYPE = 24332;

		// Token: 0x040002B7 RID: 695
		private AllianceCreateFailedMessage.Reason reason_0;

		// Token: 0x020000A7 RID: 167
		public enum Reason
		{
			// Token: 0x040002B9 RID: 697
			GENERIC,
			// Token: 0x040002BA RID: 698
			INVALID_NAME,
			// Token: 0x040002BB RID: 699
			INVALID_DESCRIPTION,
			// Token: 0x040002BC RID: 700
			NAME_TOO_SHORT,
			// Token: 0x040002BD RID: 701
			NAME_TOO_LONG
		}
	}
}
