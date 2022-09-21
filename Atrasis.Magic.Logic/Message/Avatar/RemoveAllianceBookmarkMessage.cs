using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Avatar
{
	// Token: 0x0200008F RID: 143
	public class RemoveAllianceBookmarkMessage : PiranhaMessage
	{
		// Token: 0x0600060C RID: 1548 RVA: 0x000058E2 File Offset: 0x00003AE2
		public RemoveAllianceBookmarkMessage() : this(0)
		{
		}

		// Token: 0x0600060D RID: 1549 RVA: 0x0000328C File Offset: 0x0000148C
		public RemoveAllianceBookmarkMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x0600060E RID: 1550 RVA: 0x000058EB File Offset: 0x00003AEB
		public override void Decode()
		{
			base.Decode();
			this.logicLong_0 = this.m_stream.ReadLong();
		}

		// Token: 0x0600060F RID: 1551 RVA: 0x00005904 File Offset: 0x00003B04
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteLong(this.logicLong_0);
		}

		// Token: 0x06000610 RID: 1552 RVA: 0x0000591D File Offset: 0x00003B1D
		public override short GetMessageType()
		{
			return 14344;
		}

		// Token: 0x06000611 RID: 1553 RVA: 0x00003F09 File Offset: 0x00002109
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x06000612 RID: 1554 RVA: 0x00005924 File Offset: 0x00003B24
		public override void Destruct()
		{
			base.Destruct();
			this.logicLong_0 = null;
		}

		// Token: 0x06000613 RID: 1555 RVA: 0x00005933 File Offset: 0x00003B33
		public LogicLong GetAllianceId()
		{
			return this.logicLong_0;
		}

		// Token: 0x06000614 RID: 1556 RVA: 0x0000593B File Offset: 0x00003B3B
		public void SetAllianceId(LogicLong value)
		{
			this.logicLong_0 = value;
		}

		// Token: 0x04000244 RID: 580
		public const int MESSAGE_TYPE = 14344;

		// Token: 0x04000245 RID: 581
		private LogicLong logicLong_0;
	}
}
