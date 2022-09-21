using System;

namespace Atrasis.Magic.Titan.Message.Security
{
	// Token: 0x0200000C RID: 12
	public class ClientCryptoErrorMessage : PiranhaMessage
	{
		// Token: 0x06000041 RID: 65 RVA: 0x000044A5 File Offset: 0x000026A5
		public ClientCryptoErrorMessage() : this(0)
		{
		}

		// Token: 0x06000042 RID: 66 RVA: 0x000044AE File Offset: 0x000026AE
		public ClientCryptoErrorMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000043 RID: 67 RVA: 0x000044B7 File Offset: 0x000026B7
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt(0);
		}

		// Token: 0x06000044 RID: 68 RVA: 0x000044CB File Offset: 0x000026CB
		public override void Decode()
		{
			base.Decode();
			this.m_stream.ReadInt();
		}

		// Token: 0x06000045 RID: 69 RVA: 0x000044DF File Offset: 0x000026DF
		public override short GetMessageType()
		{
			return 10099;
		}

		// Token: 0x06000046 RID: 70 RVA: 0x000044E6 File Offset: 0x000026E6
		public override int GetServiceNodeType()
		{
			return 1;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x000044E9 File Offset: 0x000026E9
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0400000F RID: 15
		public const int MESSAGE_TYPE = 10099;
	}
}
