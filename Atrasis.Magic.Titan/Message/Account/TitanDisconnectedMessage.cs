using System;

namespace Atrasis.Magic.Titan.Message.Account
{
	// Token: 0x02000011 RID: 17
	public class TitanDisconnectedMessage : PiranhaMessage
	{
		// Token: 0x06000078 RID: 120 RVA: 0x000046E7 File Offset: 0x000028E7
		public TitanDisconnectedMessage() : this(0)
		{
		}

		// Token: 0x06000079 RID: 121 RVA: 0x000044AE File Offset: 0x000026AE
		public TitanDisconnectedMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x0600007A RID: 122 RVA: 0x000046F0 File Offset: 0x000028F0
		public override void Decode()
		{
			base.Decode();
			this.int_0 = this.m_stream.ReadInt();
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00004709 File Offset: 0x00002909
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt(this.int_0);
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00004722 File Offset: 0x00002922
		public override short GetMessageType()
		{
			return 25892;
		}

		// Token: 0x0600007D RID: 125 RVA: 0x000044E6 File Offset: 0x000026E6
		public override int GetServiceNodeType()
		{
			return 1;
		}

		// Token: 0x0600007E RID: 126 RVA: 0x000044E9 File Offset: 0x000026E9
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00004729 File Offset: 0x00002929
		public int GetReason()
		{
			return this.int_0;
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00004731 File Offset: 0x00002931
		public void SetReason(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x0400001F RID: 31
		public const int MESSAGE_TYPE = 25892;

		// Token: 0x04000020 RID: 32
		private int int_0;
	}
}
