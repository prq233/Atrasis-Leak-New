using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Facebook
{
	// Token: 0x02000075 RID: 117
	public class UnbindFacebookAccountMessage : PiranhaMessage
	{
		// Token: 0x0600051C RID: 1308 RVA: 0x00004FCB File Offset: 0x000031CB
		public UnbindFacebookAccountMessage() : this(0)
		{
		}

		// Token: 0x0600051D RID: 1309 RVA: 0x0000328C File Offset: 0x0000148C
		public UnbindFacebookAccountMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x0600051E RID: 1310 RVA: 0x00003E25 File Offset: 0x00002025
		public override void Decode()
		{
			base.Decode();
		}

		// Token: 0x0600051F RID: 1311 RVA: 0x00003E2D File Offset: 0x0000202D
		public override void Encode()
		{
			base.Encode();
		}

		// Token: 0x06000520 RID: 1312 RVA: 0x00004FD4 File Offset: 0x000031D4
		public override short GetMessageType()
		{
			return 14211;
		}

		// Token: 0x06000521 RID: 1313 RVA: 0x00002B36 File Offset: 0x00000D36
		public override int GetServiceNodeType()
		{
			return 1;
		}

		// Token: 0x06000522 RID: 1314 RVA: 0x0000341E File Offset: 0x0000161E
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x040001EB RID: 491
		public const int MESSAGE_TYPE = 14211;
	}
}
