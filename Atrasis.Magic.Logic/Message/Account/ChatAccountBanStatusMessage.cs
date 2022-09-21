using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Account
{
	// Token: 0x020000EC RID: 236
	public class ChatAccountBanStatusMessage : PiranhaMessage
	{
		// Token: 0x06000AA3 RID: 2723 RVA: 0x0000805C File Offset: 0x0000625C
		public ChatAccountBanStatusMessage() : this(0)
		{
		}

		// Token: 0x06000AA4 RID: 2724 RVA: 0x0000328C File Offset: 0x0000148C
		public ChatAccountBanStatusMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000AA5 RID: 2725 RVA: 0x00003E25 File Offset: 0x00002025
		public override void Decode()
		{
			base.Decode();
		}

		// Token: 0x06000AA6 RID: 2726 RVA: 0x00008065 File Offset: 0x00006265
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt(this.int_0);
		}

		// Token: 0x06000AA7 RID: 2727 RVA: 0x0000807E File Offset: 0x0000627E
		public override void Destruct()
		{
			base.Destruct();
			this.int_0 = this.m_stream.ReadInt();
		}

		// Token: 0x06000AA8 RID: 2728 RVA: 0x00008097 File Offset: 0x00006297
		public override short GetMessageType()
		{
			return 20118;
		}

		// Token: 0x06000AA9 RID: 2729 RVA: 0x0000809E File Offset: 0x0000629E
		public int GetBanSeconds()
		{
			return this.int_0;
		}

		// Token: 0x06000AAA RID: 2730 RVA: 0x000080A6 File Offset: 0x000062A6
		public void SetBanSeconds(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x04000429 RID: 1065
		public const int MESSAGE_TYPE = 20118;

		// Token: 0x0400042A RID: 1066
		private int int_0;
	}
}
