using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Avatar
{
	// Token: 0x02000088 RID: 136
	public class AvatarProfileFailedMessage : PiranhaMessage
	{
		// Token: 0x060005CE RID: 1486 RVA: 0x00005630 File Offset: 0x00003830
		public AvatarProfileFailedMessage() : this(0)
		{
		}

		// Token: 0x060005CF RID: 1487 RVA: 0x0000328C File Offset: 0x0000148C
		public AvatarProfileFailedMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060005D0 RID: 1488 RVA: 0x00005639 File Offset: 0x00003839
		public override void Decode()
		{
			base.Decode();
			this.errorType_0 = (AvatarProfileFailedMessage.ErrorType)this.m_stream.ReadInt();
			this.logicLong_0 = this.m_stream.ReadLong();
		}

		// Token: 0x060005D1 RID: 1489 RVA: 0x00005663 File Offset: 0x00003863
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt((int)this.errorType_0);
			this.m_stream.WriteLong(this.logicLong_0);
		}

		// Token: 0x060005D2 RID: 1490 RVA: 0x0000568D File Offset: 0x0000388D
		public override short GetMessageType()
		{
			return 24339;
		}

		// Token: 0x060005D3 RID: 1491 RVA: 0x00003F09 File Offset: 0x00002109
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x060005D4 RID: 1492 RVA: 0x00005694 File Offset: 0x00003894
		public override void Destruct()
		{
			base.Destruct();
			this.logicLong_0 = null;
		}

		// Token: 0x060005D5 RID: 1493 RVA: 0x000056A3 File Offset: 0x000038A3
		public AvatarProfileFailedMessage.ErrorType GetErrorType()
		{
			return this.errorType_0;
		}

		// Token: 0x060005D6 RID: 1494 RVA: 0x000056AB File Offset: 0x000038AB
		public void SetErrorType(AvatarProfileFailedMessage.ErrorType value)
		{
			this.errorType_0 = value;
		}

		// Token: 0x060005D7 RID: 1495 RVA: 0x000056B4 File Offset: 0x000038B4
		public LogicLong GetAvatarId()
		{
			return this.logicLong_0;
		}

		// Token: 0x060005D8 RID: 1496 RVA: 0x000056BC File Offset: 0x000038BC
		public void SetAvatarId(LogicLong value)
		{
			this.logicLong_0 = value;
		}

		// Token: 0x0400022F RID: 559
		public const int MESSAGE_TYPE = 24339;

		// Token: 0x04000230 RID: 560
		private AvatarProfileFailedMessage.ErrorType errorType_0;

		// Token: 0x04000231 RID: 561
		private LogicLong logicLong_0;

		// Token: 0x02000089 RID: 137
		public enum ErrorType
		{
			// Token: 0x04000233 RID: 563
			GENERIC,
			// Token: 0x04000234 RID: 564
			INTERNAL_ERROR,
			// Token: 0x04000235 RID: 565
			NOT_FOUND
		}
	}
}
