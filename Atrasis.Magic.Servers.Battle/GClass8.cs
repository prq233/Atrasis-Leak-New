using System;
using Atrasis.Magic.Logic.Command;
using Atrasis.Magic.Logic.Command.Listener;
using Atrasis.Magic.Logic.Mode;
using Atrasis.Magic.Titan.Util;

namespace ns0
{
	// Token: 0x0200000E RID: 14
	public class GClass8 : LogicCommandManagerListener
	{
		// Token: 0x0600004E RID: 78 RVA: 0x0000264C File Offset: 0x0000084C
		public GClass8(GClass6 gclass6_1, LogicGameMode logicGameMode_1)
		{
			this.gclass6_0 = gclass6_1;
			this.logicGameMode_0 = logicGameMode_1;
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00002662 File Offset: 0x00000862
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06000050 RID: 80 RVA: 0x0000266A File Offset: 0x0000086A
		public override void CommandExecuted(LogicCommand command)
		{
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00003874 File Offset: 0x00001A74
		public void method_0(int int_0, LogicArrayList<LogicCommand> logicArrayList_0)
		{
			for (int i = 0; i < logicArrayList_0.Size(); i++)
			{
				if (logicArrayList_0[i].IsServerCommand())
				{
					logicArrayList_0.Remove(i--);
				}
			}
		}

		// Token: 0x04000021 RID: 33
		private readonly GClass6 gclass6_0;

		// Token: 0x04000022 RID: 34
		private readonly LogicGameMode logicGameMode_0;
	}
}
