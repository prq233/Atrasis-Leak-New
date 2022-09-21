using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Google
{
	// Token: 0x02000062 RID: 98
	public class BindGoogleServiceAccountMessage : PiranhaMessage
	{
		// Token: 0x0600046B RID: 1131 RVA: 0x000049C2 File Offset: 0x00002BC2
		public BindGoogleServiceAccountMessage() : this(0)
		{
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x0000328C File Offset: 0x0000148C
		public BindGoogleServiceAccountMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x0001CD18 File Offset: 0x0001AF18
		public override void Decode()
		{
			base.Decode();
			this.bool_0 = this.m_stream.ReadBoolean();
			this.string_0 = this.m_stream.ReadString(900000);
			this.string_1 = this.m_stream.ReadString(900000);
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x000049CB File Offset: 0x00002BCB
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteBoolean(this.bool_0);
			this.m_stream.WriteString(this.string_0);
			this.m_stream.WriteString(this.string_1);
		}

		// Token: 0x0600046F RID: 1135 RVA: 0x00004A06 File Offset: 0x00002C06
		public override short GetMessageType()
		{
			return 14262;
		}

		// Token: 0x06000470 RID: 1136 RVA: 0x00002B36 File Offset: 0x00000D36
		public override int GetServiceNodeType()
		{
			return 1;
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x00004A0D File Offset: 0x00002C0D
		public override void Destruct()
		{
			base.Destruct();
			this.string_0 = null;
			this.string_1 = null;
		}

		// Token: 0x06000472 RID: 1138 RVA: 0x00004A23 File Offset: 0x00002C23
		public string RemoveGoogleServiceId()
		{
			string result = this.string_0;
			this.string_0 = null;
			return result;
		}

		// Token: 0x06000473 RID: 1139 RVA: 0x00004A32 File Offset: 0x00002C32
		public void SetGoogleServiceId(string value)
		{
			this.string_0 = value;
		}

		// Token: 0x06000474 RID: 1140 RVA: 0x00004A3B File Offset: 0x00002C3B
		public string RemoveAccessToken()
		{
			string result = this.string_1;
			this.string_1 = null;
			return result;
		}

		// Token: 0x06000475 RID: 1141 RVA: 0x00004A4A File Offset: 0x00002C4A
		public void SetAccessToken(string value)
		{
			this.string_1 = value;
		}

		// Token: 0x040001AC RID: 428
		public const int MESSAGE_TYPE = 14262;

		// Token: 0x040001AD RID: 429
		private bool bool_0;

		// Token: 0x040001AE RID: 430
		private string string_0;

		// Token: 0x040001AF RID: 431
		private string string_1;
	}
}
