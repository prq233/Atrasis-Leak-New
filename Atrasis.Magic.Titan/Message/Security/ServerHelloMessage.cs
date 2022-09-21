using System;

namespace Atrasis.Magic.Titan.Message.Security
{
	// Token: 0x0200000F RID: 15
	public class ServerHelloMessage : PiranhaMessage
	{
		// Token: 0x06000066 RID: 102 RVA: 0x000045EE File Offset: 0x000027EE
		public ServerHelloMessage() : this(0)
		{
		}

		// Token: 0x06000067 RID: 103 RVA: 0x000044AE File Offset: 0x000026AE
		public ServerHelloMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000068 RID: 104 RVA: 0x000045F7 File Offset: 0x000027F7
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteBytes(this.byte_0, this.byte_0.Length);
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00004618 File Offset: 0x00002818
		public override void Decode()
		{
			base.Decode();
			this.byte_0 = this.m_stream.ReadBytes(this.m_stream.ReadBytesLength(), 24);
		}

		// Token: 0x0600006A RID: 106 RVA: 0x0000463E File Offset: 0x0000283E
		public byte[] RemoveServerNonce()
		{
			byte[] result = this.byte_0;
			this.byte_0 = null;
			return result;
		}

		// Token: 0x0600006B RID: 107 RVA: 0x0000464D File Offset: 0x0000284D
		public void SetServerNonce(byte[] value)
		{
			this.byte_0 = value;
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00004656 File Offset: 0x00002856
		public override short GetMessageType()
		{
			return 20100;
		}

		// Token: 0x0600006D RID: 109 RVA: 0x000044E6 File Offset: 0x000026E6
		public override int GetServiceNodeType()
		{
			return 1;
		}

		// Token: 0x0600006E RID: 110 RVA: 0x0000465D File Offset: 0x0000285D
		public override void Destruct()
		{
			this.byte_0 = null;
		}

		// Token: 0x0400001B RID: 27
		public const int MESSAGE_TYPE = 20100;

		// Token: 0x0400001C RID: 28
		private byte[] byte_0;
	}
}
