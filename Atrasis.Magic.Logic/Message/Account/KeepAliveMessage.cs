using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Account
{
	// Token: 0x020000EF RID: 239
	public class KeepAliveMessage : PiranhaMessage
	{
		// Token: 0x06000AB9 RID: 2745 RVA: 0x000080FA File Offset: 0x000062FA
		public KeepAliveMessage() : this(0)
		{
		}

		// Token: 0x06000ABA RID: 2746 RVA: 0x0000328C File Offset: 0x0000148C
		public KeepAliveMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000ABB RID: 2747 RVA: 0x00003E25 File Offset: 0x00002025
		public override void Decode()
		{
			base.Decode();
		}

		// Token: 0x06000ABC RID: 2748 RVA: 0x00003E2D File Offset: 0x0000202D
		public override void Encode()
		{
			base.Encode();
		}

		// Token: 0x06000ABD RID: 2749 RVA: 0x00008103 File Offset: 0x00006303
		public override short GetMessageType()
		{
			return 10108;
		}

		// Token: 0x06000ABE RID: 2750 RVA: 0x00002B36 File Offset: 0x00000D36
		public override int GetServiceNodeType()
		{
			return 1;
		}

		// Token: 0x06000ABF RID: 2751 RVA: 0x0000341E File Offset: 0x0000161E
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0400042D RID: 1069
		public const int MESSAGE_TYPE = 10108;
	}
}
