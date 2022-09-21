using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Facebook
{
	// Token: 0x02000074 RID: 116
	public class FacebookAccountUnboundMessage : PiranhaMessage
	{
		// Token: 0x06000515 RID: 1301 RVA: 0x00004FBB File Offset: 0x000031BB
		public FacebookAccountUnboundMessage() : this(0)
		{
		}

		// Token: 0x06000516 RID: 1302 RVA: 0x0000328C File Offset: 0x0000148C
		public FacebookAccountUnboundMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000517 RID: 1303 RVA: 0x00003E25 File Offset: 0x00002025
		public override void Decode()
		{
			base.Decode();
		}

		// Token: 0x06000518 RID: 1304 RVA: 0x00003E2D File Offset: 0x0000202D
		public override void Encode()
		{
			base.Encode();
		}

		// Token: 0x06000519 RID: 1305 RVA: 0x00004FC4 File Offset: 0x000031C4
		public override short GetMessageType()
		{
			return 24214;
		}

		// Token: 0x0600051A RID: 1306 RVA: 0x00002B36 File Offset: 0x00000D36
		public override int GetServiceNodeType()
		{
			return 1;
		}

		// Token: 0x0600051B RID: 1307 RVA: 0x0000341E File Offset: 0x0000161E
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x040001EA RID: 490
		public const int MESSAGE_TYPE = 24214;
	}
}
