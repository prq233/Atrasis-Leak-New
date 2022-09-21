using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Home
{
	// Token: 0x02000053 RID: 83
	public class LiveReplayEndMessage : PiranhaMessage
	{
		// Token: 0x060003C1 RID: 961 RVA: 0x00004408 File Offset: 0x00002608
		public LiveReplayEndMessage() : this(0)
		{
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x0000328C File Offset: 0x0000148C
		public LiveReplayEndMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060003C3 RID: 963 RVA: 0x00004411 File Offset: 0x00002611
		public override short GetMessageType()
		{
			return 24126;
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x00003F09 File Offset: 0x00002109
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x0000341E File Offset: 0x0000161E
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x04000174 RID: 372
		public const int MESSAGE_TYPE = 24126;
	}
}
