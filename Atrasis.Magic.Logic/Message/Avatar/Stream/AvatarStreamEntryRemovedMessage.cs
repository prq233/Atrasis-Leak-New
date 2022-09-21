using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Avatar.Stream
{
	// Token: 0x02000098 RID: 152
	public class AvatarStreamEntryRemovedMessage : PiranhaMessage
	{
		// Token: 0x0600067B RID: 1659 RVA: 0x00005C4A File Offset: 0x00003E4A
		public AvatarStreamEntryRemovedMessage() : this(0)
		{
		}

		// Token: 0x0600067C RID: 1660 RVA: 0x0000328C File Offset: 0x0000148C
		public AvatarStreamEntryRemovedMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x0600067D RID: 1661 RVA: 0x00005C53 File Offset: 0x00003E53
		public override void Decode()
		{
			base.Decode();
			this.logicLong_0 = this.m_stream.ReadLong();
		}

		// Token: 0x0600067E RID: 1662 RVA: 0x00005C6C File Offset: 0x00003E6C
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteLong(this.logicLong_0);
		}

		// Token: 0x0600067F RID: 1663 RVA: 0x00005C85 File Offset: 0x00003E85
		public override short GetMessageType()
		{
			return 24418;
		}

		// Token: 0x06000680 RID: 1664 RVA: 0x000046E0 File Offset: 0x000028E0
		public override int GetServiceNodeType()
		{
			return 11;
		}

		// Token: 0x06000681 RID: 1665 RVA: 0x00005C8C File Offset: 0x00003E8C
		public override void Destruct()
		{
			base.Destruct();
			this.logicLong_0 = null;
		}

		// Token: 0x06000682 RID: 1666 RVA: 0x00005C9B File Offset: 0x00003E9B
		public LogicLong GetStreamEntryId()
		{
			return this.logicLong_0;
		}

		// Token: 0x06000683 RID: 1667 RVA: 0x00005CA3 File Offset: 0x00003EA3
		public void SetStreamEntryId(LogicLong value)
		{
			this.logicLong_0 = value;
		}

		// Token: 0x04000270 RID: 624
		public const int MESSAGE_TYPE = 24418;

		// Token: 0x04000271 RID: 625
		private LogicLong logicLong_0;
	}
}
