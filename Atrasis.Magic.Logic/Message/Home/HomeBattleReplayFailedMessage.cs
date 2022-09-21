using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Home
{
	// Token: 0x0200004F RID: 79
	public class HomeBattleReplayFailedMessage : PiranhaMessage
	{
		// Token: 0x060003A0 RID: 928 RVA: 0x000042DD File Offset: 0x000024DD
		public HomeBattleReplayFailedMessage() : this(0)
		{
		}

		// Token: 0x060003A1 RID: 929 RVA: 0x0000328C File Offset: 0x0000148C
		public HomeBattleReplayFailedMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x000042E6 File Offset: 0x000024E6
		public override void Decode()
		{
			base.Decode();
			this.reason_0 = (HomeBattleReplayFailedMessage.Reason)this.m_stream.ReadInt();
		}

		// Token: 0x060003A3 RID: 931 RVA: 0x000042FF File Offset: 0x000024FF
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt((int)this.reason_0);
		}

		// Token: 0x060003A4 RID: 932 RVA: 0x00004318 File Offset: 0x00002518
		public override short GetMessageType()
		{
			return 24116;
		}

		// Token: 0x060003A5 RID: 933 RVA: 0x00003F09 File Offset: 0x00002109
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x0000341E File Offset: 0x0000161E
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x04000169 RID: 361
		public const int MESSAGE_TYPE = 24116;

		// Token: 0x0400016A RID: 362
		private HomeBattleReplayFailedMessage.Reason reason_0;

		// Token: 0x02000050 RID: 80
		public enum Reason
		{

		}
	}
}
