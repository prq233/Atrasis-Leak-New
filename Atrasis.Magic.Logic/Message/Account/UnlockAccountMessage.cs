using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Account
{
	// Token: 0x020000FE RID: 254
	public class UnlockAccountMessage : PiranhaMessage
	{
		// Token: 0x06000B88 RID: 2952 RVA: 0x000087C0 File Offset: 0x000069C0
		public UnlockAccountMessage() : this(0)
		{
		}

		// Token: 0x06000B89 RID: 2953 RVA: 0x0000328C File Offset: 0x0000148C
		public UnlockAccountMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000B8A RID: 2954 RVA: 0x00025C08 File Offset: 0x00023E08
		public override void Decode()
		{
			base.Decode();
			this.logicLong_0 = this.m_stream.ReadLong();
			this.string_0 = this.m_stream.ReadString(900000);
			this.string_1 = this.m_stream.ReadString(900000);
		}

		// Token: 0x06000B8B RID: 2955 RVA: 0x000087C9 File Offset: 0x000069C9
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteLong(this.logicLong_0);
			this.m_stream.WriteString(this.string_0);
			this.m_stream.WriteString(this.string_1);
		}

		// Token: 0x06000B8C RID: 2956 RVA: 0x00008804 File Offset: 0x00006A04
		public override short GetMessageType()
		{
			return 10121;
		}

		// Token: 0x06000B8D RID: 2957 RVA: 0x00002B36 File Offset: 0x00000D36
		public override int GetServiceNodeType()
		{
			return 1;
		}

		// Token: 0x06000B8E RID: 2958 RVA: 0x0000880B File Offset: 0x00006A0B
		public override void Destruct()
		{
			base.Destruct();
			this.logicLong_0 = null;
			this.string_0 = null;
			this.string_1 = null;
		}

		// Token: 0x06000B8F RID: 2959 RVA: 0x00008828 File Offset: 0x00006A28
		public LogicLong GetAccountId()
		{
			return this.logicLong_0;
		}

		// Token: 0x06000B90 RID: 2960 RVA: 0x00008830 File Offset: 0x00006A30
		public void SetAccountId(LogicLong id)
		{
			this.logicLong_0 = id;
		}

		// Token: 0x06000B91 RID: 2961 RVA: 0x00008839 File Offset: 0x00006A39
		public string GetPassToken()
		{
			return this.string_0;
		}

		// Token: 0x06000B92 RID: 2962 RVA: 0x00008841 File Offset: 0x00006A41
		public void SetPassToken(string value)
		{
			this.string_0 = value;
		}

		// Token: 0x06000B93 RID: 2963 RVA: 0x0000884A File Offset: 0x00006A4A
		public string GetUnlockCode()
		{
			return this.string_1;
		}

		// Token: 0x06000B94 RID: 2964 RVA: 0x00008852 File Offset: 0x00006A52
		public void SetUnlockCode(string value)
		{
			this.string_1 = value;
		}

		// Token: 0x04000491 RID: 1169
		public const int MESSAGE_TYPE = 10121;

		// Token: 0x04000492 RID: 1170
		private LogicLong logicLong_0;

		// Token: 0x04000493 RID: 1171
		private string string_0;

		// Token: 0x04000494 RID: 1172
		private string string_1;
	}
}
