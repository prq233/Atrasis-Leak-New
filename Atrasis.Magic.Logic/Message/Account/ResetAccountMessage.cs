using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Account
{
	// Token: 0x020000F9 RID: 249
	public class ResetAccountMessage : PiranhaMessage
	{
		// Token: 0x06000B63 RID: 2915 RVA: 0x00008669 File Offset: 0x00006869
		public ResetAccountMessage() : this(0)
		{
		}

		// Token: 0x06000B64 RID: 2916 RVA: 0x0000328C File Offset: 0x0000148C
		public ResetAccountMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000B65 RID: 2917 RVA: 0x00008672 File Offset: 0x00006872
		public override void Decode()
		{
			base.Decode();
			this.int_0 = this.m_stream.ReadInt();
		}

		// Token: 0x06000B66 RID: 2918 RVA: 0x0000868B File Offset: 0x0000688B
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt(this.int_0);
		}

		// Token: 0x06000B67 RID: 2919 RVA: 0x000086A4 File Offset: 0x000068A4
		public override short GetMessageType()
		{
			return 10116;
		}

		// Token: 0x06000B68 RID: 2920 RVA: 0x00002B36 File Offset: 0x00000D36
		public override int GetServiceNodeType()
		{
			return 1;
		}

		// Token: 0x06000B69 RID: 2921 RVA: 0x0000341E File Offset: 0x0000161E
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06000B6A RID: 2922 RVA: 0x000086AB File Offset: 0x000068AB
		public int GetAccountPreset()
		{
			return this.int_0;
		}

		// Token: 0x06000B6B RID: 2923 RVA: 0x000086B3 File Offset: 0x000068B3
		public void SetAccountPreset(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x04000484 RID: 1156
		public const int MESSAGE_TYPE = 10116;

		// Token: 0x04000485 RID: 1157
		private int int_0;
	}
}
