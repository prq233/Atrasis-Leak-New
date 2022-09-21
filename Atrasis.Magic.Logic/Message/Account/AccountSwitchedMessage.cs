using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Account
{
	// Token: 0x020000E9 RID: 233
	public class AccountSwitchedMessage : PiranhaMessage
	{
		// Token: 0x06000A80 RID: 2688 RVA: 0x00007ECE File Offset: 0x000060CE
		public AccountSwitchedMessage() : this(0)
		{
		}

		// Token: 0x06000A81 RID: 2689 RVA: 0x0000328C File Offset: 0x0000148C
		public AccountSwitchedMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000A82 RID: 2690 RVA: 0x00007ED7 File Offset: 0x000060D7
		public override void Decode()
		{
			base.Decode();
			this.logicLong_0 = this.m_stream.ReadLong();
		}

		// Token: 0x06000A83 RID: 2691 RVA: 0x00007EF0 File Offset: 0x000060F0
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteLong(this.logicLong_0);
		}

		// Token: 0x06000A84 RID: 2692 RVA: 0x00007F09 File Offset: 0x00006109
		public override short GetMessageType()
		{
			return 10118;
		}

		// Token: 0x06000A85 RID: 2693 RVA: 0x00002B36 File Offset: 0x00000D36
		public override int GetServiceNodeType()
		{
			return 1;
		}

		// Token: 0x06000A86 RID: 2694 RVA: 0x0000341E File Offset: 0x0000161E
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06000A87 RID: 2695 RVA: 0x00007F10 File Offset: 0x00006110
		public LogicLong RemoveSwitchedToAccountId()
		{
			LogicLong result = this.logicLong_0;
			this.logicLong_0 = null;
			return result;
		}

		// Token: 0x06000A88 RID: 2696 RVA: 0x00007F1F File Offset: 0x0000611F
		public void SetSwitchedToAccountId(LogicLong id)
		{
			this.logicLong_0 = id;
		}

		// Token: 0x0400041E RID: 1054
		public const int MESSAGE_TYPE = 10118;

		// Token: 0x0400041F RID: 1055
		private LogicLong logicLong_0;
	}
}
