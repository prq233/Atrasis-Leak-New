using System;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Account
{
	// Token: 0x020000FA RID: 250
	public class SetDeviceTokenMessage : PiranhaMessage
	{
		// Token: 0x06000B6C RID: 2924 RVA: 0x000086BC File Offset: 0x000068BC
		public SetDeviceTokenMessage() : this(0)
		{
		}

		// Token: 0x06000B6D RID: 2925 RVA: 0x0000328C File Offset: 0x0000148C
		public SetDeviceTokenMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000B6E RID: 2926 RVA: 0x00025BB0 File Offset: 0x00023DB0
		public override void Decode()
		{
			base.Decode();
			this.int_0 = this.m_stream.ReadBytesLength();
			if (this.int_0 > 1000)
			{
				Debugger.Error("Illegal byte array length encountered.");
			}
			this.byte_0 = this.m_stream.ReadBytes(this.int_0, 900000);
		}

		// Token: 0x06000B6F RID: 2927 RVA: 0x000086C5 File Offset: 0x000068C5
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteBytes(this.byte_0, this.int_0);
		}

		// Token: 0x06000B70 RID: 2928 RVA: 0x000086E4 File Offset: 0x000068E4
		public override short GetMessageType()
		{
			return 10113;
		}

		// Token: 0x06000B71 RID: 2929 RVA: 0x00002B36 File Offset: 0x00000D36
		public override int GetServiceNodeType()
		{
			return 1;
		}

		// Token: 0x06000B72 RID: 2930 RVA: 0x000086EB File Offset: 0x000068EB
		public override void Destruct()
		{
			base.Destruct();
			this.byte_0 = null;
		}

		// Token: 0x06000B73 RID: 2931 RVA: 0x000086FA File Offset: 0x000068FA
		public byte[] GetDeviceToken()
		{
			return this.byte_0;
		}

		// Token: 0x06000B74 RID: 2932 RVA: 0x00008702 File Offset: 0x00006902
		public int GetDeviceTokenLength()
		{
			return this.int_0;
		}

		// Token: 0x06000B75 RID: 2933 RVA: 0x0000870A File Offset: 0x0000690A
		public void SetDeviceToken(byte[] value, int length)
		{
			this.byte_0 = value;
			this.int_0 = length;
		}

		// Token: 0x04000486 RID: 1158
		public const int MESSAGE_TYPE = 10113;

		// Token: 0x04000487 RID: 1159
		private byte[] byte_0;

		// Token: 0x04000488 RID: 1160
		private int int_0;
	}
}
