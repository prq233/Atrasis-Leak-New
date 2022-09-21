using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Account
{
	// Token: 0x020000FB RID: 251
	public class ShutdownStartedMessage : PiranhaMessage
	{
		// Token: 0x06000B76 RID: 2934 RVA: 0x0000871A File Offset: 0x0000691A
		public ShutdownStartedMessage() : this(0)
		{
		}

		// Token: 0x06000B77 RID: 2935 RVA: 0x0000328C File Offset: 0x0000148C
		public ShutdownStartedMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000B78 RID: 2936 RVA: 0x00008723 File Offset: 0x00006923
		public override void Decode()
		{
			base.Decode();
			this.int_0 = this.m_stream.ReadInt();
		}

		// Token: 0x06000B79 RID: 2937 RVA: 0x0000873C File Offset: 0x0000693C
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt(this.int_0);
		}

		// Token: 0x06000B7A RID: 2938 RVA: 0x00008755 File Offset: 0x00006955
		public override short GetMessageType()
		{
			return 20161;
		}

		// Token: 0x06000B7B RID: 2939 RVA: 0x00002B36 File Offset: 0x00000D36
		public override int GetServiceNodeType()
		{
			return 1;
		}

		// Token: 0x06000B7C RID: 2940 RVA: 0x0000341E File Offset: 0x0000161E
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06000B7D RID: 2941 RVA: 0x0000875C File Offset: 0x0000695C
		public int GetSecondsUntilShutdown()
		{
			return this.int_0;
		}

		// Token: 0x06000B7E RID: 2942 RVA: 0x00008764 File Offset: 0x00006964
		public void SetSecondsUntilShutdown(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x04000489 RID: 1161
		public const int MESSAGE_TYPE = 20161;

		// Token: 0x0400048A RID: 1162
		private int int_0;
	}
}
