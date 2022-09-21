using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Alliance
{
	// Token: 0x020000C8 RID: 200
	public class SendAllianceInvitationMessage : PiranhaMessage
	{
		// Token: 0x060008B0 RID: 2224 RVA: 0x00006F7F File Offset: 0x0000517F
		public SendAllianceInvitationMessage() : this(0)
		{
		}

		// Token: 0x060008B1 RID: 2225 RVA: 0x0000328C File Offset: 0x0000148C
		public SendAllianceInvitationMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060008B2 RID: 2226 RVA: 0x00006F88 File Offset: 0x00005188
		public override void Decode()
		{
			base.Decode();
			this.logicLong_0 = this.m_stream.ReadLong();
		}

		// Token: 0x060008B3 RID: 2227 RVA: 0x00006FA1 File Offset: 0x000051A1
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteLong(this.logicLong_0);
		}

		// Token: 0x060008B4 RID: 2228 RVA: 0x00006FBA File Offset: 0x000051BA
		public override short GetMessageType()
		{
			return 14322;
		}

		// Token: 0x060008B5 RID: 2229 RVA: 0x000046E0 File Offset: 0x000028E0
		public override int GetServiceNodeType()
		{
			return 11;
		}

		// Token: 0x060008B6 RID: 2230 RVA: 0x00006FC1 File Offset: 0x000051C1
		public LogicLong GetAvatarId()
		{
			return this.logicLong_0;
		}

		// Token: 0x060008B7 RID: 2231 RVA: 0x00006FC9 File Offset: 0x000051C9
		public void SetAvatarId(LogicLong id)
		{
			this.logicLong_0 = id;
		}

		// Token: 0x04000353 RID: 851
		public const int MESSAGE_TYPE = 14322;

		// Token: 0x04000354 RID: 852
		private LogicLong logicLong_0;
	}
}
