using System;

namespace Atrasis.Magic.Titan.Message.Security
{
	// Token: 0x0200000E RID: 14
	public class CryptoErrorMessage : PiranhaMessage
	{
		// Token: 0x0600005F RID: 95 RVA: 0x000045AC File Offset: 0x000027AC
		public CryptoErrorMessage() : this(0)
		{
		}

		// Token: 0x06000060 RID: 96 RVA: 0x000044AE File Offset: 0x000026AE
		public CryptoErrorMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000061 RID: 97 RVA: 0x000045B5 File Offset: 0x000027B5
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteVInt(this.int_0);
		}

		// Token: 0x06000062 RID: 98 RVA: 0x000045CE File Offset: 0x000027CE
		public override void Decode()
		{
			base.Decode();
			this.int_0 = this.m_stream.ReadVInt();
		}

		// Token: 0x06000063 RID: 99 RVA: 0x000045E7 File Offset: 0x000027E7
		public override short GetMessageType()
		{
			return 29997;
		}

		// Token: 0x06000064 RID: 100 RVA: 0x000044E6 File Offset: 0x000026E6
		public override int GetServiceNodeType()
		{
			return 1;
		}

		// Token: 0x06000065 RID: 101 RVA: 0x000044E9 File Offset: 0x000026E9
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x04000019 RID: 25
		public const int MESSAGE_TYPE = 29997;

		// Token: 0x0400001A RID: 26
		private int int_0;
	}
}
