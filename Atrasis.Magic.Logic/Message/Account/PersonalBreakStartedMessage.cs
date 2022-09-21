using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Account
{
	// Token: 0x020000F5 RID: 245
	public class PersonalBreakStartedMessage : PiranhaMessage
	{
		// Token: 0x06000B46 RID: 2886 RVA: 0x0000851E File Offset: 0x0000671E
		public PersonalBreakStartedMessage() : this(0)
		{
		}

		// Token: 0x06000B47 RID: 2887 RVA: 0x0000328C File Offset: 0x0000148C
		public PersonalBreakStartedMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000B48 RID: 2888 RVA: 0x00008527 File Offset: 0x00006727
		public override void Decode()
		{
			base.Decode();
			this.int_0 = this.m_stream.ReadInt();
		}

		// Token: 0x06000B49 RID: 2889 RVA: 0x00008540 File Offset: 0x00006740
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt(this.int_0);
		}

		// Token: 0x06000B4A RID: 2890 RVA: 0x00008559 File Offset: 0x00006759
		public override short GetMessageType()
		{
			return 20171;
		}

		// Token: 0x06000B4B RID: 2891 RVA: 0x00002B36 File Offset: 0x00000D36
		public override int GetServiceNodeType()
		{
			return 1;
		}

		// Token: 0x06000B4C RID: 2892 RVA: 0x0000341E File Offset: 0x0000161E
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06000B4D RID: 2893 RVA: 0x00008560 File Offset: 0x00006760
		public int GetSecondsUntilBreak()
		{
			return this.int_0;
		}

		// Token: 0x06000B4E RID: 2894 RVA: 0x00008568 File Offset: 0x00006768
		public void SetSecondsUntilBreak(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x04000476 RID: 1142
		public const int MESSAGE_TYPE = 20171;

		// Token: 0x04000477 RID: 1143
		private int int_0;
	}
}
