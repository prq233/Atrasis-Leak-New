using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Alliance
{
	// Token: 0x020000BC RID: 188
	public class CancelChallengeMessage : PiranhaMessage
	{
		// Token: 0x06000814 RID: 2068 RVA: 0x00006A26 File Offset: 0x00004C26
		public CancelChallengeMessage() : this(0)
		{
		}

		// Token: 0x06000815 RID: 2069 RVA: 0x0000328C File Offset: 0x0000148C
		public CancelChallengeMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000816 RID: 2070 RVA: 0x00003E25 File Offset: 0x00002025
		public override void Decode()
		{
			base.Decode();
		}

		// Token: 0x06000817 RID: 2071 RVA: 0x00003E2D File Offset: 0x0000202D
		public override void Encode()
		{
			base.Encode();
		}

		// Token: 0x06000818 RID: 2072 RVA: 0x00006A2F File Offset: 0x00004C2F
		public override short GetMessageType()
		{
			return 14125;
		}

		// Token: 0x06000819 RID: 2073 RVA: 0x000046E0 File Offset: 0x000028E0
		public override int GetServiceNodeType()
		{
			return 11;
		}

		// Token: 0x0600081A RID: 2074 RVA: 0x0000341E File Offset: 0x0000161E
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0400031E RID: 798
		public const int MESSAGE_TYPE = 14125;
	}
}
