using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Account
{
	// Token: 0x020000FC RID: 252
	public class UnlockAccountFailedMessage : PiranhaMessage
	{
		// Token: 0x06000B7F RID: 2943 RVA: 0x0000876D File Offset: 0x0000696D
		public UnlockAccountFailedMessage() : this(0)
		{
		}

		// Token: 0x06000B80 RID: 2944 RVA: 0x0000328C File Offset: 0x0000148C
		public UnlockAccountFailedMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000B81 RID: 2945 RVA: 0x00008776 File Offset: 0x00006976
		public override void Decode()
		{
			base.Decode();
			this.errorCode_0 = (UnlockAccountFailedMessage.ErrorCode)this.m_stream.ReadInt();
		}

		// Token: 0x06000B82 RID: 2946 RVA: 0x0000878F File Offset: 0x0000698F
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt((int)this.errorCode_0);
		}

		// Token: 0x06000B83 RID: 2947 RVA: 0x000087A8 File Offset: 0x000069A8
		public override short GetMessageType()
		{
			return 20133;
		}

		// Token: 0x06000B84 RID: 2948 RVA: 0x00002B36 File Offset: 0x00000D36
		public override int GetServiceNodeType()
		{
			return 1;
		}

		// Token: 0x06000B85 RID: 2949 RVA: 0x0000341E File Offset: 0x0000161E
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06000B86 RID: 2950 RVA: 0x000087AF File Offset: 0x000069AF
		public UnlockAccountFailedMessage.ErrorCode GetErrorCode()
		{
			return this.errorCode_0;
		}

		// Token: 0x06000B87 RID: 2951 RVA: 0x000087B7 File Offset: 0x000069B7
		public void SetErrorCode(UnlockAccountFailedMessage.ErrorCode errorCode)
		{
			this.errorCode_0 = errorCode;
		}

		// Token: 0x0400048B RID: 1163
		public const int MESSAGE_TYPE = 20133;

		// Token: 0x0400048C RID: 1164
		private UnlockAccountFailedMessage.ErrorCode errorCode_0;

		// Token: 0x020000FD RID: 253
		public enum ErrorCode
		{
			// Token: 0x0400048E RID: 1166
			UNLOCK_FAILED = 4,
			// Token: 0x0400048F RID: 1167
			UNLOCK_UNAVAILABLE,
			// Token: 0x04000490 RID: 1168
			SERVER_MAINTENANCE = 10
		}
	}
}
