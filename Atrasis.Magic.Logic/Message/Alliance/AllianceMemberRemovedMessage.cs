using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Alliance
{
	// Token: 0x020000B8 RID: 184
	public class AllianceMemberRemovedMessage : PiranhaMessage
	{
		// Token: 0x060007F1 RID: 2033 RVA: 0x000068C9 File Offset: 0x00004AC9
		public AllianceMemberRemovedMessage() : this(0)
		{
		}

		// Token: 0x060007F2 RID: 2034 RVA: 0x0000328C File Offset: 0x0000148C
		public AllianceMemberRemovedMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060007F3 RID: 2035 RVA: 0x000068D2 File Offset: 0x00004AD2
		public override void Decode()
		{
			base.Decode();
			this.logicLong_0 = this.m_stream.ReadLong();
		}

		// Token: 0x060007F4 RID: 2036 RVA: 0x000068EB File Offset: 0x00004AEB
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteLong(this.logicLong_0);
		}

		// Token: 0x060007F5 RID: 2037 RVA: 0x00006904 File Offset: 0x00004B04
		public override short GetMessageType()
		{
			return 24309;
		}

		// Token: 0x060007F6 RID: 2038 RVA: 0x000046E0 File Offset: 0x000028E0
		public override int GetServiceNodeType()
		{
			return 11;
		}

		// Token: 0x060007F7 RID: 2039 RVA: 0x0000690B File Offset: 0x00004B0B
		public override void Destruct()
		{
			base.Destruct();
			this.logicLong_0 = null;
		}

		// Token: 0x060007F8 RID: 2040 RVA: 0x0000691A File Offset: 0x00004B1A
		public LogicLong RemoveMemberAvatarId()
		{
			LogicLong result = this.logicLong_0;
			this.logicLong_0 = null;
			return result;
		}

		// Token: 0x060007F9 RID: 2041 RVA: 0x00006929 File Offset: 0x00004B29
		public void SetMemberAvatarId(LogicLong value)
		{
			this.logicLong_0 = value;
		}

		// Token: 0x04000316 RID: 790
		public const int MESSAGE_TYPE = 24309;

		// Token: 0x04000317 RID: 791
		private LogicLong logicLong_0;
	}
}
