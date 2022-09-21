using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Avatar.Attack
{
	// Token: 0x020000A2 RID: 162
	public class Village2AttackEntryRemovedMessage : PiranhaMessage
	{
		// Token: 0x060006F2 RID: 1778 RVA: 0x0000602F File Offset: 0x0000422F
		public Village2AttackEntryRemovedMessage() : this(0)
		{
		}

		// Token: 0x060006F3 RID: 1779 RVA: 0x0000328C File Offset: 0x0000148C
		public Village2AttackEntryRemovedMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060006F4 RID: 1780 RVA: 0x00006038 File Offset: 0x00004238
		public override void Decode()
		{
			base.Decode();
			this.logicLong_0 = this.m_stream.ReadLong();
		}

		// Token: 0x060006F5 RID: 1781 RVA: 0x00006051 File Offset: 0x00004251
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteLong(this.logicLong_0);
		}

		// Token: 0x060006F6 RID: 1782 RVA: 0x0000606A File Offset: 0x0000426A
		public override short GetMessageType()
		{
			return 24373;
		}

		// Token: 0x060006F7 RID: 1783 RVA: 0x00003F09 File Offset: 0x00002109
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x060006F8 RID: 1784 RVA: 0x0000341E File Offset: 0x0000161E
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060006F9 RID: 1785 RVA: 0x00006071 File Offset: 0x00004271
		public LogicLong GetStreamId()
		{
			return this.logicLong_0;
		}

		// Token: 0x060006FA RID: 1786 RVA: 0x00006079 File Offset: 0x00004279
		public void SetStreamId(LogicLong id)
		{
			this.logicLong_0 = id;
		}

		// Token: 0x0400029A RID: 666
		public const int MESSAGE_TYPE = 24373;

		// Token: 0x0400029B RID: 667
		private LogicLong logicLong_0;
	}
}
