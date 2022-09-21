using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Account
{
	// Token: 0x020000F7 RID: 247
	public class ReportUserStatusMessage : PiranhaMessage
	{
		// Token: 0x06000B5A RID: 2906 RVA: 0x000085FE File Offset: 0x000067FE
		public ReportUserStatusMessage() : this(0)
		{
		}

		// Token: 0x06000B5B RID: 2907 RVA: 0x0000328C File Offset: 0x0000148C
		public ReportUserStatusMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000B5C RID: 2908 RVA: 0x00008607 File Offset: 0x00006807
		public override void Decode()
		{
			base.Decode();
			this.errorCode_0 = (ReportUserStatusMessage.ErrorCode)this.m_stream.ReadInt();
			this.m_stream.ReadInt();
		}

		// Token: 0x06000B5D RID: 2909 RVA: 0x0000862C File Offset: 0x0000682C
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt((int)this.errorCode_0);
			this.m_stream.WriteInt(0);
		}

		// Token: 0x06000B5E RID: 2910 RVA: 0x00008651 File Offset: 0x00006851
		public override short GetMessageType()
		{
			return 20117;
		}

		// Token: 0x06000B5F RID: 2911 RVA: 0x00002B36 File Offset: 0x00000D36
		public override int GetServiceNodeType()
		{
			return 1;
		}

		// Token: 0x06000B60 RID: 2912 RVA: 0x0000341E File Offset: 0x0000161E
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06000B61 RID: 2913 RVA: 0x00008658 File Offset: 0x00006858
		public ReportUserStatusMessage.ErrorCode GetErrorCode()
		{
			return this.errorCode_0;
		}

		// Token: 0x06000B62 RID: 2914 RVA: 0x00008660 File Offset: 0x00006860
		public void SetErrorCode(ReportUserStatusMessage.ErrorCode errorCode)
		{
			this.errorCode_0 = errorCode;
		}

		// Token: 0x0400047B RID: 1147
		public const int MESSAGE_TYPE = 20117;

		// Token: 0x0400047C RID: 1148
		private ReportUserStatusMessage.ErrorCode errorCode_0;

		// Token: 0x020000F8 RID: 248
		public enum ErrorCode
		{
			// Token: 0x0400047E RID: 1150
			GENERIC,
			// Token: 0x0400047F RID: 1151
			SUCCESS,
			// Token: 0x04000480 RID: 1152
			TOO_MANY_REPORTS_SENT,
			// Token: 0x04000481 RID: 1153
			PLAYER_ALREADY_REPORTED,
			// Token: 0x04000482 RID: 1154
			TOO_MANY_ALLIANCE_CHAT_REPORTS_SENT = 6,
			// Token: 0x04000483 RID: 1155
			PLAYER_ALLIANCE_ALREADY_REPORTED
		}
	}
}
