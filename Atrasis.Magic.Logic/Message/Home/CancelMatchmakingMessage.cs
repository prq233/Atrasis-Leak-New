using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Home
{
	// Token: 0x02000046 RID: 70
	public class CancelMatchmakingMessage : PiranhaMessage
	{
		// Token: 0x06000339 RID: 825 RVA: 0x00003F98 File Offset: 0x00002198
		public CancelMatchmakingMessage() : this(0)
		{
		}

		// Token: 0x0600033A RID: 826 RVA: 0x0000328C File Offset: 0x0000148C
		public CancelMatchmakingMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x0600033B RID: 827 RVA: 0x00003E25 File Offset: 0x00002025
		public override void Decode()
		{
			base.Decode();
		}

		// Token: 0x0600033C RID: 828 RVA: 0x00003E2D File Offset: 0x0000202D
		public override void Encode()
		{
			base.Encode();
		}

		// Token: 0x0600033D RID: 829 RVA: 0x00003FA1 File Offset: 0x000021A1
		public override short GetMessageType()
		{
			return 14103;
		}

		// Token: 0x0600033E RID: 830 RVA: 0x00003F09 File Offset: 0x00002109
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x0600033F RID: 831 RVA: 0x0000341E File Offset: 0x0000161E
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x04000143 RID: 323
		public const int MESSAGE_TYPE = 14103;
	}
}
