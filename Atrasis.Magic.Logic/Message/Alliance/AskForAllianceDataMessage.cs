using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Alliance
{
	// Token: 0x020000BA RID: 186
	public class AskForAllianceDataMessage : PiranhaMessage
	{
		// Token: 0x06000805 RID: 2053 RVA: 0x000069B8 File Offset: 0x00004BB8
		public AskForAllianceDataMessage() : this(0)
		{
		}

		// Token: 0x06000806 RID: 2054 RVA: 0x0000328C File Offset: 0x0000148C
		public AskForAllianceDataMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000807 RID: 2055 RVA: 0x000069C1 File Offset: 0x00004BC1
		public override void Decode()
		{
			base.Decode();
			this.logicLong_0 = this.m_stream.ReadLong();
		}

		// Token: 0x06000808 RID: 2056 RVA: 0x000069DA File Offset: 0x00004BDA
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteLong(this.logicLong_0);
		}

		// Token: 0x06000809 RID: 2057 RVA: 0x000069F3 File Offset: 0x00004BF3
		public override short GetMessageType()
		{
			return 14302;
		}

		// Token: 0x0600080A RID: 2058 RVA: 0x000046E0 File Offset: 0x000028E0
		public override int GetServiceNodeType()
		{
			return 11;
		}

		// Token: 0x0600080B RID: 2059 RVA: 0x000069FA File Offset: 0x00004BFA
		public LogicLong RemoveAllianceId()
		{
			LogicLong result = this.logicLong_0;
			this.logicLong_0 = null;
			return result;
		}

		// Token: 0x0600080C RID: 2060 RVA: 0x00006A09 File Offset: 0x00004C09
		public void SetAllianceId(LogicLong id)
		{
			this.logicLong_0 = id;
		}

		// Token: 0x0400031B RID: 795
		public const int MESSAGE_TYPE = 14302;

		// Token: 0x0400031C RID: 796
		private LogicLong logicLong_0;
	}
}
