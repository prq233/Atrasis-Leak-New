using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Alliance
{
	// Token: 0x020000C3 RID: 195
	public class JoinAllianceUsingInvitationMessage : PiranhaMessage
	{
		// Token: 0x06000875 RID: 2165 RVA: 0x00006D5B File Offset: 0x00004F5B
		public JoinAllianceUsingInvitationMessage() : this(0)
		{
		}

		// Token: 0x06000876 RID: 2166 RVA: 0x0000328C File Offset: 0x0000148C
		public JoinAllianceUsingInvitationMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000877 RID: 2167 RVA: 0x00006D64 File Offset: 0x00004F64
		public override void Decode()
		{
			base.Decode();
			this.logicLong_0 = this.m_stream.ReadLong();
		}

		// Token: 0x06000878 RID: 2168 RVA: 0x00006D7D File Offset: 0x00004F7D
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteLong(this.logicLong_0);
		}

		// Token: 0x06000879 RID: 2169 RVA: 0x00006D96 File Offset: 0x00004F96
		public override short GetMessageType()
		{
			return 14323;
		}

		// Token: 0x0600087A RID: 2170 RVA: 0x00003D3D File Offset: 0x00001F3D
		public override int GetServiceNodeType()
		{
			return 10;
		}

		// Token: 0x0600087B RID: 2171 RVA: 0x00006D9D File Offset: 0x00004F9D
		public LogicLong GetAvatarStreamEntryId()
		{
			return this.logicLong_0;
		}

		// Token: 0x0600087C RID: 2172 RVA: 0x00006DA5 File Offset: 0x00004FA5
		public void SetAvatarStreamEntryId(LogicLong value)
		{
			this.logicLong_0 = value;
		}

		// Token: 0x04000340 RID: 832
		public const int MESSAGE_TYPE = 14323;

		// Token: 0x04000341 RID: 833
		private LogicLong logicLong_0;
	}
}
