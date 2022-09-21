using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Home
{
	// Token: 0x02000061 RID: 97
	public class WaitingToGoHomeMessage : PiranhaMessage
	{
		// Token: 0x06000462 RID: 1122 RVA: 0x0000496F File Offset: 0x00002B6F
		public WaitingToGoHomeMessage() : this(0)
		{
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x0000328C File Offset: 0x0000148C
		public WaitingToGoHomeMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x00004978 File Offset: 0x00002B78
		public override void Decode()
		{
			base.Decode();
			this.int_0 = this.m_stream.ReadInt();
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x00004991 File Offset: 0x00002B91
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt(this.int_0);
		}

		// Token: 0x06000466 RID: 1126 RVA: 0x000049AA File Offset: 0x00002BAA
		public override short GetMessageType()
		{
			return 24112;
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x00003D3D File Offset: 0x00001F3D
		public override int GetServiceNodeType()
		{
			return 10;
		}

		// Token: 0x06000468 RID: 1128 RVA: 0x0000341E File Offset: 0x0000161E
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06000469 RID: 1129 RVA: 0x000049B1 File Offset: 0x00002BB1
		public int GetEstimatedTimeSeconds()
		{
			return this.int_0;
		}

		// Token: 0x0600046A RID: 1130 RVA: 0x000049B9 File Offset: 0x00002BB9
		public void SetEstimatedTimeSeconds(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x040001AA RID: 426
		public const int MESSAGE_TYPE = 24112;

		// Token: 0x040001AB RID: 427
		private int int_0;
	}
}
