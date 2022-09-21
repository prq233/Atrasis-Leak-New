using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Friend
{
	// Token: 0x0200006B RID: 107
	public class AskForFriendListMessage : PiranhaMessage
	{
		// Token: 0x060004AC RID: 1196 RVA: 0x00004C1A File Offset: 0x00002E1A
		public AskForFriendListMessage() : this(0)
		{
		}

		// Token: 0x060004AD RID: 1197 RVA: 0x0000328C File Offset: 0x0000148C
		public AskForFriendListMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060004AE RID: 1198 RVA: 0x00003E25 File Offset: 0x00002025
		public override void Decode()
		{
			base.Decode();
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x00003E2D File Offset: 0x0000202D
		public override void Encode()
		{
			base.Encode();
		}

		// Token: 0x060004B0 RID: 1200 RVA: 0x00004C23 File Offset: 0x00002E23
		public override short GetMessageType()
		{
			return 10504;
		}

		// Token: 0x060004B1 RID: 1201 RVA: 0x00002C4D File Offset: 0x00000E4D
		public override int GetServiceNodeType()
		{
			return 3;
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x0000341E File Offset: 0x0000161E
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x040001C9 RID: 457
		public const int MESSAGE_TYPE = 10504;
	}
}
