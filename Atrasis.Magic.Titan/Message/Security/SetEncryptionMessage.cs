using System;

namespace Atrasis.Magic.Titan.Message.Security
{
	// Token: 0x02000010 RID: 16
	public class SetEncryptionMessage : PiranhaMessage
	{
		// Token: 0x0600006F RID: 111 RVA: 0x00004666 File Offset: 0x00002866
		public SetEncryptionMessage() : this(0)
		{
		}

		// Token: 0x06000070 RID: 112 RVA: 0x000044AE File Offset: 0x000026AE
		public SetEncryptionMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000071 RID: 113 RVA: 0x0000466F File Offset: 0x0000286F
		public override void Decode()
		{
			base.Decode();
			this.byte_0 = this.m_stream.ReadBytes(this.m_stream.ReadBytesLength(), 900000);
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00004698 File Offset: 0x00002898
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteBytes(this.byte_0, this.byte_0.Length);
		}

		// Token: 0x06000073 RID: 115 RVA: 0x000046B9 File Offset: 0x000028B9
		public override short GetMessageType()
		{
			return 20000;
		}

		// Token: 0x06000074 RID: 116 RVA: 0x000044E6 File Offset: 0x000026E6
		public override int GetServiceNodeType()
		{
			return 1;
		}

		// Token: 0x06000075 RID: 117 RVA: 0x000046C0 File Offset: 0x000028C0
		public override void Destruct()
		{
			base.Destruct();
			this.byte_0 = null;
		}

		// Token: 0x06000076 RID: 118 RVA: 0x000046CF File Offset: 0x000028CF
		public byte[] RemoveNonce()
		{
			byte[] result = this.byte_0;
			this.byte_0 = null;
			return result;
		}

		// Token: 0x06000077 RID: 119 RVA: 0x000046DE File Offset: 0x000028DE
		public void SetNonce(byte[] value)
		{
			this.byte_0 = value;
		}

		// Token: 0x0400001D RID: 29
		public const int MESSAGE_TYPE = 20000;

		// Token: 0x0400001E RID: 30
		private byte[] byte_0;
	}
}
