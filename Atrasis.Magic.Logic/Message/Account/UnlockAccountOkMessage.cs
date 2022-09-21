using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Account
{
	// Token: 0x020000FF RID: 255
	public class UnlockAccountOkMessage : PiranhaMessage
	{
		// Token: 0x06000B95 RID: 2965 RVA: 0x0000885B File Offset: 0x00006A5B
		public UnlockAccountOkMessage() : this(0)
		{
		}

		// Token: 0x06000B96 RID: 2966 RVA: 0x0000328C File Offset: 0x0000148C
		public UnlockAccountOkMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000B97 RID: 2967 RVA: 0x00008864 File Offset: 0x00006A64
		public override void Decode()
		{
			base.Decode();
			this.logicLong_0 = this.m_stream.ReadLong();
			this.string_0 = this.m_stream.ReadString(900000);
		}

		// Token: 0x06000B98 RID: 2968 RVA: 0x00008893 File Offset: 0x00006A93
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteLong(this.logicLong_0);
			this.m_stream.WriteString(this.string_0);
		}

		// Token: 0x06000B99 RID: 2969 RVA: 0x000088BD File Offset: 0x00006ABD
		public override short GetMessageType()
		{
			return 20132;
		}

		// Token: 0x06000B9A RID: 2970 RVA: 0x00002B36 File Offset: 0x00000D36
		public override int GetServiceNodeType()
		{
			return 1;
		}

		// Token: 0x06000B9B RID: 2971 RVA: 0x000088C4 File Offset: 0x00006AC4
		public override void Destruct()
		{
			base.Destruct();
			this.logicLong_0 = null;
			this.string_0 = null;
		}

		// Token: 0x06000B9C RID: 2972 RVA: 0x000088DA File Offset: 0x00006ADA
		public LogicLong GetAccountId()
		{
			return this.logicLong_0;
		}

		// Token: 0x06000B9D RID: 2973 RVA: 0x000088E2 File Offset: 0x00006AE2
		public void SetAccountId(LogicLong id)
		{
			this.logicLong_0 = id;
		}

		// Token: 0x06000B9E RID: 2974 RVA: 0x000088EB File Offset: 0x00006AEB
		public string GetPassToken()
		{
			return this.string_0;
		}

		// Token: 0x06000B9F RID: 2975 RVA: 0x000088F3 File Offset: 0x00006AF3
		public void SetPassToken(string value)
		{
			this.string_0 = value;
		}

		// Token: 0x04000495 RID: 1173
		public const int MESSAGE_TYPE = 20132;

		// Token: 0x04000496 RID: 1174
		private LogicLong logicLong_0;

		// Token: 0x04000497 RID: 1175
		private string string_0;
	}
}
