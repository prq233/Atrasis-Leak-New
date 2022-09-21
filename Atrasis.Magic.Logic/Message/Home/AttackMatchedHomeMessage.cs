using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Home
{
	// Token: 0x02000042 RID: 66
	public class AttackMatchedHomeMessage : PiranhaMessage
	{
		// Token: 0x06000315 RID: 789 RVA: 0x00003E1C File Offset: 0x0000201C
		public AttackMatchedHomeMessage() : this(0)
		{
		}

		// Token: 0x06000316 RID: 790 RVA: 0x0000328C File Offset: 0x0000148C
		public AttackMatchedHomeMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000317 RID: 791 RVA: 0x00003E25 File Offset: 0x00002025
		public override void Decode()
		{
			base.Decode();
		}

		// Token: 0x06000318 RID: 792 RVA: 0x00003E2D File Offset: 0x0000202D
		public override void Encode()
		{
			base.Encode();
		}

		// Token: 0x06000319 RID: 793 RVA: 0x00003E35 File Offset: 0x00002035
		public override short GetMessageType()
		{
			return 14123;
		}

		// Token: 0x0600031A RID: 794 RVA: 0x00003D3D File Offset: 0x00001F3D
		public override int GetServiceNodeType()
		{
			return 10;
		}

		// Token: 0x0600031B RID: 795 RVA: 0x0000341E File Offset: 0x0000161E
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0400013B RID: 315
		public const int MESSAGE_TYPE = 14123;
	}
}
