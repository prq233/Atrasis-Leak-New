using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Account
{
	// Token: 0x020000F0 RID: 240
	public class KeepAliveServerMessage : PiranhaMessage
	{
		// Token: 0x06000AC0 RID: 2752 RVA: 0x0000810A File Offset: 0x0000630A
		public KeepAliveServerMessage() : this(0)
		{
		}

		// Token: 0x06000AC1 RID: 2753 RVA: 0x0000328C File Offset: 0x0000148C
		public KeepAliveServerMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000AC2 RID: 2754 RVA: 0x00003E25 File Offset: 0x00002025
		public override void Decode()
		{
			base.Decode();
		}

		// Token: 0x06000AC3 RID: 2755 RVA: 0x00003E2D File Offset: 0x0000202D
		public override void Encode()
		{
			base.Encode();
		}

		// Token: 0x06000AC4 RID: 2756 RVA: 0x00008113 File Offset: 0x00006313
		public override short GetMessageType()
		{
			return 20108;
		}

		// Token: 0x06000AC5 RID: 2757 RVA: 0x00002B36 File Offset: 0x00000D36
		public override int GetServiceNodeType()
		{
			return 1;
		}

		// Token: 0x06000AC6 RID: 2758 RVA: 0x0000341E File Offset: 0x0000161E
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0400042E RID: 1070
		public const int MESSAGE_TYPE = 20108;
	}
}
